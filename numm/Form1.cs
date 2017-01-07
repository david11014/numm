using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows;

namespace numm
{

    public partial class Form1 : Form
    {
        const float h = 0.01f;
        Graphics G;
        Bezier B1 = new Bezier();
        Bezier B2 = new Bezier();
        bool draw1 = false;
        bool draw2 = false;

        public Form1()
        {
            InitializeComponent();
            B2.PointCo = Color.Green;
            B2.CurveCo = Color.Black;
            richTextBox2.Text = B1.listP();
            richTextBox3.Text = B2.listP();
            G = pictureBox1.CreateGraphics();
            debug.Text = "";
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

            switch (e.Button)
            {
                case MouseButtons.Left:


                    if (tabControl1.SelectedIndex == 0)
                    {
                        B1.addP(new PointF(e.X, e.Y));
                        if (draw1)
                        {
                            ClearCurve1();
                            draw1 = false;
                        }
                    }
                    else
                    {
                        B2.addP(new PointF(e.X, e.Y));
                        if (draw2)
                        {
                            ClearCurve2();
                            draw2 = false;
                        }
                    }

                    richTextBox2.Text = B1.listP();
                    richTextBox3.Text = B2.listP();
                    DrawP(B1.CtrlPoint, B1.PointCo);
                    DrawP(B2.CtrlPoint, B2.PointCo);
                    break;
                case MouseButtons.Right:
                    G = pictureBox1.CreateGraphics();
                    if (tabControl1.SelectedIndex == 0)
                    {
                        // ClearCurve2();
                        Bezier_curve(B1);
                        draw1 = true;
                    }
                    else
                    {
                        //  ClearCurve1();
                        Bezier_curve(B2);
                        draw2 = true;
                    }

                    break;
            }
        }

        void Bezier_curve(Bezier b)  // Draw the Bezier curve 
        {
            b.BezierCalculate();
            Pen pen_line = new Pen(b.CurveCo);
            for (int i = 0; i < (b.Point_Bezier.Count - 1); i++)
                G.DrawLine(pen_line, b.Point_Bezier[i], b.Point_Bezier[i + 1]);
        }

        //draw muti point
        void DrawP(List<PointF> CP, Color c)
        {
            if (CP.Count <= 0)
                return;

            foreach (PointF p in CP)
            {
                System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(c);
                G.FillEllipse(myBrush, new Rectangle((int)p.X - 2, (int)p.Y - 2, 4, 4));
            }
        }

        //draw single point
        void DrawP(PointF P, Color c)
        {
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(c);
            G.FillEllipse(myBrush, new Rectangle((int)P.X - 2, (int)P.Y - 2, 5, 5));
        }

        void ClearCurve1()
        {
            G.Clear(Color.White);
            B1.Point_Bezier.Clear();
            DrawP(B2.CtrlPoint, B2.PointCo);
            Bezier_curve(B2);
            richTextBox2.Text = B1.listP();
        }

        void ClearCurve2()
        {
            G.Clear(Color.White);
            B2.Point_Bezier.Clear();
            DrawP(B1.CtrlPoint, B1.PointCo);
            Bezier_curve(B1);
            richTextBox3.Text = B2.listP();
        }

        private void ClearALL(object sender, EventArgs e)
        {
            G.Clear(Color.White);
            B1.clear();
            B2.clear();
            richTextBox2.Text = B1.listP();
            richTextBox3.Text = B2.listP();
        }

        private void ClearCurve1Btn_Click(object sender, EventArgs e)
        {
            G.Clear(Color.White);
            B1.clear();
            DrawP(B2.CtrlPoint, B2.PointCo);
            Bezier_curve(B2);
            richTextBox2.Text = B1.listP();
        }

        private void ClearCurve2Btn_Click(object sender, EventArgs e)
        {
            G.Clear(Color.White);
            B2.clear();
            DrawP(B1.CtrlPoint, B1.PointCo);
            Bezier_curve(B1);
            richTextBox3.Text = B2.listP();
        }

        private void Find_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            float t1 =0, t2 = 00;
            float det = 0;
            float fx, fy, fx1, fx2, fy1, fy2;
            int i = 0;


            float dx=0, dy=0;
            List<PointF> root = new List<PointF>();

            for(int j=0; j < B1.Point_Bezier.Count-1; j++)
            {
                for (int k= 0; k < B2.Point_Bezier.Count; k++)
                {
                    dx = B1.Point_Bezier[j].X - B2.Point_Bezier[k].X;
                    dy = B1.Point_Bezier[j].Y - B2.Point_Bezier[k].Y;

                    if((dx*dx + dy*dy) < 1)
                    {
                        
                        if (intersect(B1.Point_Bezier[j], B1.Point_Bezier[j + 1], B2.Point_Bezier[k], B2.Point_Bezier[k + 1]))
                        {

                            //DrawP(B1.Point_Bezier[j], Color.Aqua);
                            //DrawP(B2.Point_Bezier[k], Color.Aqua);

                            root.Add(intersection(B1.Point_Bezier[j], B1.Point_Bezier[j + 1], B2.Point_Bezier[k], B2.Point_Bezier[k + 1]));
                            
                            richTextBox1.Text += "Point " + root.Count.ToString() + "---\n";
                            //richTextBox1.Text += "B1= " + B1.Point_Bezier[j].ToString() + "\nB2= " + B2.Point_Bezier[k].ToString() + "\n";
                            richTextBox1.Text += "P = " + root.Last().ToString() + "\n";

                        }                        
                    }
                }
            }

            DrawP(root,Color.Aqua);
            /*
            while (i<1000)
            {

                richTextBox1.Text += "t1= " + t1.ToString() + "t2= " + t2.ToString() + "\n";
                richTextBox1.Text += "Fx= " + Fx(t1, t2).ToString() + "Fy= " + Fy(t1, t2).ToString() + "\n";

                fx   = Fx(t1,t2);
                fy   = Fy(t1, t2);
                fx1 = dFx1(t1, t2).X;
                fy1 = dFx1(t1, t2).Y;
                fx2 = dFx2(t1, t2).X;
                fy2 = dFx2(t1, t2).Y;
                det = fx1 * fy2 - fx2 * fy1;

                t1 = t1 - (fy2 * fx - fx2 * fy) / det;
                t2 = t1 - (-fy1 * fx + fx1 * fy) / det;

                if (t1 > 1 || t2 >1|| t1 < 0 || t2 < 0)
                {
                    debug.Text = "out of range" + "t1= " + t1.ToString() + "t2= " + t2.ToString() + "\n";
                    break;
                }else if (Fx(t1, t2)<0.1 && Fy(t1, t2) < 0.1)
                {
                    richTextBox1.Text += "find!! \n";
                    richTextBox1.Text += "t1= " + t1.ToString() + "t2= " + t2.ToString() + "\n";
                    richTextBox1.Text += "Fx= " + Fx(t1, t2).ToString() + "Fy= " + Fy(t1, t2).ToString() + "\n";
                }
                i++;
            }*/
        }

        float Fx(float t1, float t2)
        {
            return B1.getPoint(t1).X - B1.getPoint(t2).X;
        }

        float Fy(float t1, float t2)
        {
            return B1.getPoint(t1).Y - B1.getPoint(t2).Y;
        }

        PointF dFx1(float t1, float t2)
        {

            float x = (Fx(t1, t2) - Fx(t1 + h, t2))/h, y = (Fy(t1, t2) - Fy(t1 + h, t2)) / h;

           return new PointF( x, y);
        }

        PointF dFx2(float t1, float t2)
        {
            float x = (Fx(t1, t2) - Fx(t1, t2 + h)) / h, y = (Fy(t1, t2) - Fy(t1, t2 + h)) / h;

            return new PointF(x, y);
        }

        //交點判斷
        bool intersect(PointF a1, PointF a2, PointF b1, PointF b2)
        {

            float c1 = cross(a1, a2, b1);
            float c2 = cross(a1, a2, b2);
            float c3 = cross(b1, b2, a1);
            float c4 = cross(b1, b2, a2);

            // 端點不共線
            if (c1 * c2 < 0 && c3 * c4 < 0) return true;
            // 端點共線
            if (c1 == 0 && intersect(a1, a2, b1)) return true;
            if (c2 == 0 && intersect(a1, a2, b2)) return true;
            if (c3 == 0 && intersect(b1, b2, a1)) return true;
            if (c4 == 0 && intersect(b1, b2, a2)) return true;
            return false;
        }

        //計算交點
        PointF intersection(PointF a1, PointF a2, PointF b1, PointF b2)
        {
            float[] a = new float[2], b = new float[2];

            a[0] = (a1.Y - a2.Y) / (a1.X - a2.X);
            a[1] = (b1.Y - b2.Y) / (b1.X - b2.X);
            b[0] = (a1.X * a2.Y - a2.X * a1.Y) / (a1.X - a2.X);
            b[1] = (b1.X * b2.Y - b2.X * b1.Y) / (b1.X - b2.X);

            return new PointF((b[0] - b[1]) / (a[1] - a[0]), (b[0] * a[1] - a[0] * b[1]) / (a[1] - a[0]));

        }
        bool intersect(PointF p, PointF p1, PointF p2)
        {
            return distance(p, p1) + distance(p, p2) == distance(p1, p2);
        }

        float distance(PointF p1, PointF p2)
        {
            float X = p1.X - p2.X;
            float Y = p1.Y - p2.Y;
            return (float)Math.Sqrt(X * X + Y * Y);
        }

        float cross(PointF o, PointF a, PointF b)
        {
            return (a.X - o.X) * (b.Y - o.Y) - (a.Y - o.Y) * (b.X - o.X);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            G = pictureBox1.CreateGraphics();
            DrawP(B1.CtrlPoint, B1.PointCo);
            DrawP(B2.CtrlPoint, B2.PointCo);
            if (draw1 == true)
                Bezier_curve(B1);

            if (draw2 == true)
                Bezier_curve(B2);
        }

    }

    public class Bezier
    {
        public List<PointF> CtrlPoint = new List<PointF>();
        public List<PointF> Point_Bezier = new List<PointF>();

        public Color PointCo = Color.Red;
        public Color CurveCo = Color.Blue;

        float h = 0.001f; // Resolution of each point

        public Bezier()
        {

        }

        public void BezierCalculate() // Calculate each point of Bezier curve
        {
            Point_Bezier.Clear();
            PointF[,] Stack = new PointF[CtrlPoint.Count, CtrlPoint.Count];
            if (CtrlPoint.Count != 0)
            {
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
        }

        public PointF getPoint(float u)
        {
            PointF[,] Stack = new PointF[CtrlPoint.Count, CtrlPoint.Count];

            if (CtrlPoint.Count != 0)
            {
                for (int i = 0; i < CtrlPoint.Count; i++)
                    Stack[i, 0] = CtrlPoint[i];
 
                for (int j = 0; j < (CtrlPoint.Count - 1); j++)
                {
                    for (int i = 0; i < (CtrlPoint.Count - 1); i++)
                        Stack[i, j + 1] = new PointF((1 - u) * Stack[i + 1, j].X + u * Stack[i, j].X, (1 - u) * Stack[i + 1, j].Y + u * Stack[i, j].Y);
                } 

                return Stack[0, (CtrlPoint.Count - 1)];
            }
            else
                return new PointF(0, 0);
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

    public class Vector
    {
        public float X, Y;

        public Vector(float x,float y)
        {
            X = x;
            Y = y;
        }

        public Vector(PointF a, PointF b)
        {
            X = a.X - b.X;
            Y = a.Y = b.Y;
        }
        public Vector(Point a, Point b)
        {
            X = a.X - b.X;
            Y = a.Y = b.Y;
        }
        public float length()
        {
            return (float)Math.Sqrt(X * X + Y * Y);
        }
        public float Cross(Vector a)
        {
            return X * a.Y - a.X * Y;
        }
        public float dot(Vector a)
        {
            return X * a.X + a.Y * Y;
        }

        public static Vector operator +(Vector c1, Vector c2) =>
            new Vector(c1.X+c2.X, c1.Y+ c2.Y);

        public static PointF operator +(PointF c1, Vector c2) =>
            new PointF(c1.X + c2.X, c1.Y + c2.Y);

        public static PointF operator +(Vector c1, PointF c2) =>
            new PointF(c1.X + c2.X, c1.Y + c2.Y);

        public static Vector operator *(Vector c1, double a) =>
           new Vector(c1.X* (float)a, c1.Y * (float)a);

        public static float operator *(Vector c1, Vector c2) =>
           c1.X * c2.X + c1.Y * c2.Y;

    }

}

