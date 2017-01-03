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
        Bezier B1 = new Bezier();
        Bezier B2 = new Bezier();

        

        public Form1()
        {
            InitializeComponent();        
            B2.PointCo = Color.Green;
            B2.CurveCo = Color.Black;

            label1.Text = B1.listP();
            label2.Text = B2.listP();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            
            switch (e.Button)
            {
                case MouseButtons.Left:

                    if(tabControl1.SelectedIndex ==0 )
                        B1.addP(new PointF(e.X, e.Y));
                    else
                        B2.addP(new PointF(e.X, e.Y));

                    G = pictureBox1.CreateGraphics();
                    
                    label1.Text = B1.listP();
                    label2.Text = B2.listP();
                    DrawP(B1.CtrlPoint,B1.PointCo);
                    DrawP(B2.CtrlPoint, B2.PointCo);
                    break;
                case MouseButtons.Right:
                    if (tabControl1.SelectedIndex == 0)
                    {
                        ClearCurve1();
                        Bezier_curve(B1);
                    }
                    else
                    {
                        ClearCurve1();
                        Bezier_curve(B2);
                    }
                        

                    break;
            }
        }

        void Bezier_curve(Bezier b )  // Draw the Bezier curve 
        {
            b.BezierCalculate();
            Pen pen_line = new Pen(b.CurveCo);
            for (int i = 0; i < (b.Point_Bezier.Count - 1); i++)
                G.DrawLine(pen_line, b.Point_Bezier[i], b.Point_Bezier[i + 1]);
        }
           
        void DrawP(List<PointF> CP, Color c)
        {
            if (CP.Count <= 0)
                return;
                    
            foreach (PointF p in CP)
            {
                System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(c);                
                G.FillEllipse(myBrush, new Rectangle((int)p.X,(int)p.Y,4,4));
            }
        }

        void ClearCurve1()
        {
            G.Clear(Color.White);
            B1.clear();
            DrawP(B2.CtrlPoint, B1.PointCo);
            Bezier_curve(B1);
            label1.Text = B1.listP();
        }

        void ClearCurve2()
        {
            G.Clear(Color.White);
            B2.clear();
            DrawP(B1.CtrlPoint, B1.PointCo);
            Bezier_curve(B1);
            label2.Text = B2.listP();
        }

        private void ClearCurve1(object sender, EventArgs e)
        {
            G.Clear(Color.White);
            B1.clear();
            DrawP(B2.CtrlPoint,B1.PointCo);
            Bezier_curve(B1);
            label1.Text = B1.listP();
        }
        private void ClearCurve2(object sender, EventArgs e)
        {
            G.Clear(Color.White);
            B2.clear();
            DrawP(B1.CtrlPoint, B1.PointCo);
            Bezier_curve(B1);
            label2.Text = B2.listP();
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

       public Color PointCo = Color.Red;
       public Color CurveCo = Color.Blue;

        float h = 0.01f; // Resolution of each point

        public Bezier()
        {

        }

        public void BezierCalculate() // Calculate each point
        {

            PointF[,] Stack = new PointF[CtrlPoint.Count, CtrlPoint.Count];

            for (int i = 0; i < CtrlPoint.Count; i++)
                Stack[i, 0] = CtrlPoint[i];  

            for (float u = 0; u <= 1; u = u + h)
            {
                for (int j = 0; j < (CtrlPoint.Count - 1); j++)
                {
                    for (int i = 0; i < (CtrlPoint.Count - 1); i++)
                        Stack[i, j + 1] = new PointF((1 - u) * Stack[i + 1, j].X + u * Stack[i, j].X, (1 - u) * Stack[i + 1, j].Y + u * Stack[i, j].Y);
                }
                Point_Bezier.Add(Stack[0, (CtrlPoint.Count - 1)]);
            }
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

