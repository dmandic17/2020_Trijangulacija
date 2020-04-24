using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrijangulacijaTacaka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        Graphics g;
        private int NUM_OF_POINTS = 0;
        private List<PointF> allPoints = new List<PointF>();
        private List<Tuple<PointF, PointF>> solution;
        bool clickEnabled = true;
        Pen olovka = new Pen(Color.Red, 3);
        PointF[] konv;
        int j,timer;

        private void generatePoints()
        {
            Random r = new Random();
            int width = pictureBox1.Width;
            int height = pictureBox1.Height;
            allPoints = new List<PointF>();
            
            for (int i = 0; i < NUM_OF_POINTS; i++)
            {
                int x = r.Next(0, width);
                int y = r.Next(0, height);
                allPoints.Add(new Point(x, y));
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            g = pictureBox1.CreateGraphics();
        }

        int cnt = 0;
        private void btGenerateNext_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            clickEnabled = true;
            pictureBox1.Refresh();
            cnt = 0;
            NUM_OF_POINTS = 20;
            generatePoints();
            allPoints = allPoints.OrderBy(p => p.X).ThenBy(p => p.Y).ToList();
            for (int i = 0; i < NUM_OF_POINTS - 1; i++)
            {
                if (allPoints[i].X == allPoints[i + 1].X)
                {
                    allPoints.RemoveAt(i + 1);
                    i--;
                    NUM_OF_POINTS--;
                }


            }
            Graphics g = pictureBox1.CreateGraphics();
            int radius = 5;
            if (NUM_OF_POINTS != 0)
            {

                for (int i = 0; i < NUM_OF_POINTS; i++)
                {
                    g.FillEllipse(Brushes.Black, allPoints.ElementAt(i).X - radius, allPoints.ElementAt(i).Y - radius, 2 * radius, 2 * radius);
                }
            }
            
        }

        private void btFileInput_Click(object sender, EventArgs e)
        {

        }

        private void btSaveToFile_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer == 1)
            {


                if (cnt < solution.Count)
                {
                    int radius = 5;
                    // Graphics g = pictureBox1.CreateGraphics();
                    Tuple<PointF, PointF> curr = solution[cnt];
                    Pen pen = new Pen(Color.Purple, 2);
                    g.DrawLine(pen, curr.Item1.X, curr.Item1.Y, curr.Item2.X, curr.Item2.Y);
                    g.FillEllipse(Brushes.Black, curr.Item1.X - radius, curr.Item1.Y - radius, 2 * radius, 2 * radius);
                    g.FillEllipse(Brushes.Black, curr.Item2.X - radius, curr.Item2.Y - radius, 2 * radius, 2 * radius);
                    cnt++;
                }
                else
                {
                    clickEnabled = true;
                    timer1.Stop();
                }
            } //triangulacija
            else if (timer == 2)
            {
                if (cnt < NUM_OF_POINTS - 1)
                {
                    g.DrawLine(olovka, allPoints[cnt], allPoints[cnt + 1]);
                    cnt++;
                }
                else
                {
                    g.DrawLine(olovka, allPoints[0], allPoints[NUM_OF_POINTS - 1]);
                    timer1.Stop();
                    cnt = 0;
                    clickEnabled = true;
                }
            }//prost
            else if (timer == 3) {
                if (cnt < NUM_OF_POINTS)
                {

                    while ((konv[j].X - konv[j - 1].X) * (allPoints[cnt].Y - konv[j - 1].Y) - (konv[j].Y - konv[j - 1].Y) * (allPoints[cnt].X - konv[j - 1].X) < 0)
                    {
                        olovka.Color = Color.Blue;
                        g.DrawLine(olovka, konv[j], konv[--j]);
                    }
                    olovka.Color = Color.Red;
                    g.DrawLine(olovka, konv[j], allPoints[cnt]);
                    j++;
                    konv[j] = allPoints[cnt];
                    cnt++;
                }
                else
                {
                    cnt = 0;
                    clickEnabled = true;
                    g.DrawLine(olovka, konv[0], konv[j]);
                    timer1.Stop();

                }
            }
            
        }


        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (clickEnabled)
            {
                Graphics g = pictureBox1.CreateGraphics();
                g.FillEllipse(Brushes.Black, e.X - 5, e.Y - 5, 10, 10);
                allPoints.Add(new PointF(e.X, e.Y));
                NUM_OF_POINTS++;
                Console.WriteLine(allPoints.Count);
            }

        } //ucituje tacke klikom na pictureBox

        private void bt_triangulation_Click(object sender, EventArgs e)
        {
            if (NUM_OF_POINTS > 0)
            {
                solution = new SolverTriangulation().solveProblem(allPoints);
                clickEnabled = false;
                cnt = 0;
                ocisti();
                timer = 1;
                timer1.Start();
            }
        }
       
        private void ocisti() {
            pictureBox1.Refresh();
            int radius = 5;
            for (int i = 0; i < NUM_OF_POINTS; i++)
            {
                g.FillEllipse(Brushes.Black, allPoints.ElementAt(i).X - radius, allPoints.ElementAt(i).Y - radius, 2 * radius, 2 * radius);
            }
        } //brise linije a ostavlja tacke
        
        


        private void bt_clear_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            clickEnabled = true;
            allPoints.Clear();
            NUM_OF_POINTS = 0;
            pictureBox1.Refresh();
        }//brise sve i prazni listu

        private void bt_prost_Click(object sender, EventArgs e)
        {
            if (NUM_OF_POINTS > 0)
            {
                clickEnabled = false;
                ocisti();
                TrijangulacijaTacaka.GA.prost(NUM_OF_POINTS, allPoints);
                cnt = 0;
                timer = 2;
                timer1.Start();
            }
        }
        
        

        private void bt_hull_Click(object sender, EventArgs e)
        {
            if (NUM_OF_POINTS > 0)
            {
                ocisti();
                TrijangulacijaTacaka.GA.prost(NUM_OF_POINTS, allPoints);
                clickEnabled = false;
                konv = new PointF[NUM_OF_POINTS];
                konv[0] = allPoints[0];
                konv[1] = allPoints[1];
                konv[2] = allPoints[2];
                j = 2;
                cnt = 3;
                g.DrawLine(olovka, konv[0], konv[1]);
                g.DrawLine(olovka, konv[1], konv[2]);
                timer = 3;
                timer1.Start();                
            }
        
    }//konveksni omotac

       
    }
}
