using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace numm
{
    

    public partial class Form1 : Form
    {

        Bezier B = new Bezier();
        Graphics G;

        public Form1()
        {
            InitializeComponent();
            G = pictureBox1.CreateGraphics();

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:

                    B.addP(new Point(e.X, e.Y));
                    
                    Draw();
                    label1.Text = B.listP();
                    

                    break;
                case MouseButtons.Right:
                    
                    break;
            }
        }


        void Draw()
        {
            foreach(Point p in B.CtrlPoint)
            {
                System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
                G.FillEllipse( myBrush, new Rectangle(p,new Size(5,5)) );
               
            }
        }

        
    }

    public class Bezier
    {
        public List<Point> CtrlPoint = new List<Point>();

        public Bezier()
        {

        }

        public Point P(double t)
        {
            Point p = new  Point(0, 0);

            // 點賦值方法
            p.X = 10;
            p.Y = 20;
            // 另一點賦值方法
            p = new Point(30, 50);

           
            return p;
        }

        public void addP(Point a)
        {                        
            CtrlPoint.Add( a);
        }

        public string listP()
        {
            string s = "";
            foreach (Point p in CtrlPoint)
            {
                s += p.ToString() + '\n';
            }
            return s;
        }
    }
}
