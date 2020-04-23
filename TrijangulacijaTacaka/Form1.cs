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

        }

        

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.FillEllipse(Brushes.Black, e.X - 5, e.Y - 5, 10, 10);
            allPoints.Add(new PointF(e.X, e.Y));
            NUM_OF_POINTS++;

        }
        
       
    }
}
