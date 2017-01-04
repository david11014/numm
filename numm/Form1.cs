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
        bool draw1 = false;
        bool draw2 = false;    

        public Form1()
        {
            InitializeComponent();        
            B2.PointCo = Color.Green;
            B2.CurveCo = Color.Black;            
            label1.Text = B1.listP();
            label2.Text = B2.listP();
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
                                        
                    label1.Text = B1.listP();
                    label2.Text = B2.listP();                    
                    DrawP(B1.CtrlPoint,B1.PointCo);
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
                G.FillEllipse(myBrush, new Rectangle((int)p.X-2,(int)p.Y-2,4,4));
            }
        }

        void ClearCurve1()
        {
            G.Clear(Color.White);
            B1.Point_Bezier.Clear();
            DrawP(B2.CtrlPoint, B2.PointCo);
            Bezier_curve(B2);            
            label1.Text = B1.listP();
        }

        void ClearCurve2()
        {
            G.Clear(Color.White);
            B2.Point_Bezier.Clear();
            DrawP(B1.CtrlPoint, B1.PointCo);
            Bezier_curve(B1);
            label2.Text = B2.listP();
        }

        private void ClearALL(object sender, EventArgs e)
        {
            G.Clear(Color.White);
            B1.clear();
            B2.clear();            
            label1.Text = B1.listP();
            label2.Text = B2.listP();
        }

        private void ClearCurve1Btn_Click(object sender, EventArgs e)
        {
            G.Clear(Color.White);
            B1.clear();
            DrawP(B2.CtrlPoint, B2.PointCo);
            Bezier_curve(B2);
            label1.Text = B1.listP();
        }

        private void ClearCurve2Btn_Click(object sender, EventArgs e)
        {
            G.Clear(Color.White);
            B2.clear();
            DrawP(B1.CtrlPoint, B1.PointCo);
            Bezier_curve(B1);
            label2.Text = B2.listP();
        }

        private void Find_Click(object sender, EventArgs e)
        {

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

        float h = 0.01f; // Resolution of each point

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
                            Stack[i, j + 1] = new PointF( (1 - u) * Stack[i + 1, j].X + u * Stack[i, j].X, (1 - u) * Stack[i + 1, j].Y + u * Stack[i, j].Y );
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

}

