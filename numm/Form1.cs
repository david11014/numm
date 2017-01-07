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
        Color intersectionPCo =new Color();
        Bezier B1 = new Bezier();
        Bezier B2 = new Bezier();
        bool draw1 = false;
        bool draw2 = false;
        //int FitType1 = 0, FitType2 = 0;

        public Form1()
        {
            InitializeComponent();
            B1.PointCo = Color.FromArgb(255, 234, 87, 50); 
            B1.CurveCo = Color.FromArgb(255, 54, 132, 193);
            B2.PointCo = Color.FromArgb(255, 92, 149, 74);
            B2.CurveCo = Color.FromArgb(255,0 ,0,0);
            intersectionPCo = Color.FromArgb(255, 255, 180, 85);

            Curve1PList.Text = B1.listP();
            Curve2PList.Text = B2.listP();
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
                        ClearCurve1();                       
                    }
                    else
                    {
                        B2.addP(new PointF(e.X, e.Y));
                        ClearCurve2();
                    }

                    Curve1PList.Text = B1.listP();
                    Curve2PList.Text = B2.listP();
                    DrawP(B1.CtrlPoint, B1.PointCo);
                    DrawP(B2.CtrlPoint, B2.PointCo);
                    break;
                case MouseButtons.Right:
                    G = pictureBox1.CreateGraphics();
                    if (tabControl1.SelectedIndex == 0)
                    {
                        ClearCurve1();
                        Generate_curve(B1);
                        draw1 = true;
                    }
                    else
                    {
                        ClearCurve2();
                        Generate_curve(B2);
                        draw2 = true;
                    }

                    break;
            }
        }

        // Draw the Bezier curve 
        void Generate_curve(Bezier b)  
        {
            b.CalcuateCurve(b.Type);
            Pen pen_line = new Pen(b.CurveCo);
            for (int i = 0; i < (b.Point_Curve.Count - 1); i++)
                G.DrawLine(pen_line, b.Point_Curve[i], b.Point_Curve[i + 1]);             
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
        void DrawP(List<PointF> CP, Color c,int size)
        {
            if (CP.Count <= 0)
                return;

            foreach (PointF p in CP)
            {
                System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(c);
                G.FillEllipse(myBrush, new Rectangle((int)(p.X - size / 2), (int)(p.Y - size / 2), size, size));
            }
        }

        //draw single point
        void DrawP(PointF P, Color c)
        {
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(c);
            G.FillEllipse(myBrush, new Rectangle((int)P.X - 2, (int)P.Y - 2, 5, 5));
        }
        void DrawP(PointF P, Color c,int size)
        {
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(c);
            G.FillEllipse(myBrush, new Rectangle((int)(P.X - size/2), (int)(P.Y - size/2), 5, size));
        }

        /**clear curve functuons**/
        void ClearCurve1()
        {
            G.Clear(Color.White);
            B1.Point_Curve.Clear();
            Curve1PList.Text = B1.listP();

            DrawP(B1.CtrlPoint, B1.PointCo);
            DrawP(B2.CtrlPoint, B2.PointCo);
            Generate_curve(B2);
            
        }

        void ClearCurve2()
        {
            G.Clear(Color.White);
            B2.Point_Curve.Clear();
            Curve2PList.Text = B2.listP();

            DrawP(B1.CtrlPoint, B1.PointCo);
            DrawP(B2.CtrlPoint, B2.PointCo);
            Generate_curve(B1);
            
        }

        private void ClearALL(object sender, EventArgs e)
        {
            G.Clear(Color.White);
            B1.clear();
            B2.clear();
            Curve1PList.Text = B1.listP();
            Curve2PList.Text = B2.listP();
        }

        private void ClearCurve1Btn_Click(object sender, EventArgs e)
        {
            G.Clear(Color.White);
            B1.clear();
            Curve1PList.Text = B1.listP();

            DrawP(B2.CtrlPoint, B2.PointCo);
            Generate_curve(B2);
            
        }

        private void ClearCurve2Btn_Click(object sender, EventArgs e)
        {
            G.Clear(Color.White);
            B2.clear();
            Curve2PList.Text = B2.listP();

            DrawP(B1.CtrlPoint, B1.PointCo);
            Generate_curve(B1);
            
        }
        
        //find intersect
        private void Find_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            
            List<PointF> intersectionP = new List<PointF>();
           
            for(int j=0; j < B1.Point_Curve.Count-1; j++)
                for (int k = 0; k < B2.Point_Curve.Count - 1; k++)
                    if (intersect(B1.Point_Curve[j], B1.Point_Curve[j + 1], B2.Point_Curve[k], B2.Point_Curve[k + 1]))
                        intersectionP.Add(intersection(B1.Point_Curve[j], B1.Point_Curve[j + 1], B2.Point_Curve[k], B2.Point_Curve[k + 1]));           

            //display the point
            DrawP(intersectionP, intersectionPCo,8);

            richTextBox1.Text += "Find " + intersectionP.Count.ToString() + " point.\n";
            foreach (PointF p in intersectionP)
                richTextBox1.Text += "P = " + p.ToString() + "\n";
                       
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
                Generate_curve(B1);

            if (draw2 == true)
                Generate_curve(B2);
        }

        private void curve1BezierMenuItem1_Click(object sender, EventArgs e)
        {
            B1.Type = 0;            
        }

        private void curve2BezierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            B2.Type = 0;
        }       

        private void curve1LineMenuItem_Click(object sender, EventArgs e)
        {
            B1.Type = 1;
        }

        private void curve2LineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            B2.Type = 1;
        }
    }

    public class Bezier
    {
        public List<PointF> CtrlPoint = new List<PointF>();
        public List<PointF> Point_Curve = new List<PointF>();

        public Color PointCo = Color.Red;
        public Color CurveCo = Color.Blue;
        public int Type = 0; // 0: Buzier 1: Line
        float h = 0.001f; // Resolution of each point

        public Bezier()
        {

        }

        public void CalcuateCurve()
        {
            switch(Type)
            {
                //Buzier
                case 0:
                    BezierCalculate();
                    break;
                //line
                case 1:
                    Line_Calculate();
                    break;
            }
        }

        public void CalcuateCurve(int T)
        {
            Type = T;
            CalcuateCurve();
        }

        void BezierCalculate() // Calculate each point of Bezier curve
        {
            Point_Curve.Clear();
            PointF[,] Stack = new PointF[CtrlPoint.Count, CtrlPoint.Count];
            if (CtrlPoint.Count != 0)
            {
                for (int i = 0; i < CtrlPoint.Count; i++)
                    Stack[i, 0] = CtrlPoint[i];

                for (float u = 0; u <= 1; u = u + h)
                {
                    /*
                    for (int j = 0; j < (CtrlPoint.Count - 1); j++)
                    {
                        for (int i = 0; i < (CtrlPoint.Count - 1); i++)
                            Stack[i, j + 1] = new PointF((1 - u) * Stack[i + 1, j].X + u * Stack[i, j].X, (1 - u) * Stack[i + 1, j].Y + u * Stack[i, j].Y);
                    }*/
                    Point_Curve.Add(getPoint(u));
                }
            }
        }

        void Line_Calculate() // Calculate each point of Line curve
        {
            Point_Curve.Clear();

            Point_Curve =   CtrlPoint.ToList();
            /*
           PointF[] Stack = new PointF[CtrlPoint.Count];
            if (CtrlPoint.Count != 0)
            {
                for (int i = 0; i < CtrlPoint.Count; i++)
                    Stack[i] = CtrlPoint[i];

                for (int i = 0; i < (CtrlPoint.Count - 1); i++)
                {
                    for (float u = 0; u <= 1; u = u + h)
                    {
                        Point_Curve.Add(new PointF(u * Stack[i + 1].X + (1 - u) * Stack[i].X, u * Stack[i + 1].Y + (1 - u) * Stack[i].Y));
                    }
                }
            }*/
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
                        Stack[i, j + 1] = new PointF(u * Stack[i + 1, j].X + (1-u) * Stack[i, j].X, u * Stack[i + 1, j].Y + (1-u) * Stack[i, j].Y);
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
            Point_Curve.Clear();
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