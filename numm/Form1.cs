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
        List<PointF> Pos_list = new List<PointF>();
        List<PointF> Point_Bezier = new List<PointF>();
        Bezier B = new Bezier();
        float h = 0.01f; // Resolution of each point
        int count = 0;
               
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
                    Pen pen_dot = new Pen(Color.Red);
                    G.DrawRectangle(pen_dot, e.X, e.Y, 1, 1);
                    PointF Pos_mouse = new PointF(e.X, e.Y);
                    Pos_list.Add(Pos_mouse);
                    label2.Text = Convert.ToString(Pos_list.Count);
                    count++;
                    break;
                case MouseButtons.Right:
                    //Line_spline(Pos_list);
                    Bezier_curve();
                    break;
            }
        }

        private void Line_spline(List<PointF> points)
        {
            Pen pen_line = new Pen(Color.Blue);
            for (int i = 0; i < (points.Count - 1); i++)
                G.DrawLine(pen_line, points[i], points[i + 1]);
        }

        private void Bezier_curve()  // Draw the Bezier curve 
        {
            Bezier_calculate();            
            Line_spline(Point_Bezier);
        }

        private void Bezier_calculate() // Calculate each point
        {
            PointF[,] Stack = new PointF[Pos_list.Count, Pos_list.Count];
            for (int i = 0; i < Pos_list.Count; i++)
            {
                Stack[i, 0] = Pos_list[i];
            }


            for (float u = 0; u <= 1; u = u + h)
            {
                for (int j = 0; j < (Pos_list.Count-1); j++)
                {
                    for (int i = 0; i < (Pos_list.Count - 1); i++)
                        Stack[i, j + 1] = new PointF((1 - u) * Stack[i + 1, j].X + u * Stack[i, j].X, (1 - u) * Stack[i + 1, j].Y + u * Stack[i, j].Y);
                }
                Point_Bezier.Add(Stack[0, (Pos_list.Count - 1)]);
                //label1.Text = Convert.ToString(Stack[0, (Pos_list.Count - 1)]);
                //label1.Text = Convert.ToString(h);
            }
        }
          

        private void button1_Click(object sender, EventArgs e)
        {
            G.Clear(Color.White);
            Pos_list.Clear();
            Point_Bezier.Clear();
            label2.Text = Convert.ToString(Pos_list.Count);
            count = 0;           
        }

        //public struct PointD  //因為Point宣告是int，只好自己定義double
        //{
        //    public double X;
        //    public double Y;

        //    public PointD(double x, double y)
        //    {
        //        X = x;
        //        Y = y;
        //    }

        //    public Point ToPoint()
        //    {
        //        return new Point((int)X, (int)Y);
        //    }

        //    public override bool Equals(object obj)
        //    {
        //        return obj is PointD && this == (PointD)obj;
        //    }
        //    public override int GetHashCode()
        //    {
        //        return X.GetHashCode() ^ Y.GetHashCode();
        //    }
        //    public static bool operator ==(PointD a, PointD b)
        //    {
        //        return a.X == b.X && a.Y == b.Y;
        //    }
        //    public static bool operator !=(PointD a, PointD b)
        //    {
        //        return !(a == b);
        //    }
        //}

    }

    

    public class Bezier
    {
        public Point[] CtrlPoint;


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
    }
}
