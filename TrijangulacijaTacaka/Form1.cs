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

        private void Form1_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            g = pictureBox1.CreateGraphics();
        }

        private void btGenerateNext_Click(object sender, EventArgs e)
        {

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
