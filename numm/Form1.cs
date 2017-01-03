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

        Graphics G;
        Bezier B = new Bezier();
        float h = 0.01f; // Resolution of each point
                       
        public Form1()
        {
            InitializeComponent();        
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            
            switch (e.Button)
            {
                case MouseButtons.Left:
                    B.addP(new PointF(e.X, e.Y));
                    DrawP();
                    label1.Text = B.listP();
                    
                    break;
                case MouseButtons.Right:
                    //Line_spline(B.CtrlPoint);
                    Bezier_curve();
                    break;
            }
        }

        void Bezier_curve()  // Draw the Bezier curve 
        {
            Bezier_calculate();

            Pen pen_line = new Pen(Color.Blue);
            for (int i = 0; i < (B.Point_Bezier.Count - 1); i++)
                G.DrawLine(pen_line, B.Point_Bezier[i], B.Point_Bezier[i + 1]);
        }

        void Bezier_calculate() // Calculate each point
        {
            PointF[,] Stack = new PointF[B.CtrlPoint.Count, B.CtrlPoint.Count];
            for (int i = 0; i < B.CtrlPoint.Count; i++)
            {
                Stack[i, 0] = B.CtrlPoint[i];
            }


            for (float u = 0; u <= 1; u = u + h)
            {
                for (int j = 0; j < (B.CtrlPoint.Count-1); j++)
                {
                    for (int i = 0; i < (B.CtrlPoint.Count - 1); i++)
                        Stack[i, j + 1] = new PointF((1 - u) * Stack[i + 1, j].X + u * Stack[i, j].X, (1 - u) * Stack[i + 1, j].Y + u * Stack[i, j].Y);
                }
                B.Point_Bezier.Add(Stack[0, (B.CtrlPoint.Count - 1)]);
            }
        }
          
        void DrawP()
        {
            G = pictureBox1.CreateGraphics();
            foreach (PointF p in B.CtrlPoint)
            {
                System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
                
                G.FillEllipse(myBrush, new Rectangle((int)p.X,(int)p.Y,2,2));

            }
        }

        private void Clear(object sender, EventArgs e)
        {
            G.Clear(Color.White);
            B.clear();
            label1.Text = B.listP();
        }

        /*public struct PointD  //因為Point宣告是int，只好自己定義double
        {
            public double X;
            public double Y;

            public PointD(double x, double y)
            {
                X = x;
                Y = y;
            }

            public Point ToPoint()
            {
                return new Point((int)X, (int)Y);
            }

            public override bool Equals(object obj)
            {
                return obj is PointD && this == (PointD)obj;
            }
            public override int GetHashCode()
            {
                return X.GetHashCode() ^ Y.GetHashCode();
            }
            public static bool operator ==(PointD a, PointD b)
            {
                return a.X == b.X && a.Y == b.Y;
            }
            public static bool operator !=(PointD a, PointD b)
            {
                return !(a == b);
            }
        }*/

    }

    public class Bezier
    {
        public List<PointF> CtrlPoint = new List<PointF>();
        public List<PointF> Point_Bezier = new List<PointF>();

        public Bezier()
        {

        }

        public Point P(double t)
        {
            Point p = new Point(0, 0);

            // 點賦值方法
            p.X = 10;
            p.Y = 20;
            // 另一點賦值方法
            p = new Point(30, 50);
            return p;
        }

        public void addP(PointF a)
        {
            CtrlPoint.Add(a);
        }

        public string listP()
        {
            string s = "Number: ";

            s += CtrlPoint.Count.ToString() + "\nPoint:\n";

            foreach (PointF p in CtrlPoint)
            {
                s += p.ToString() + '\n';
            }
            return s;
        }

        public void clear()
        {
            CtrlPoint.Clear();
            Point_Bezier.Clear();
        }
    }

}

