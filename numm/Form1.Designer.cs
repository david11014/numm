namespace numm
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.T_Line1 = new System.Windows.Forms.RadioButton();
            this.T_Buzier1 = new System.Windows.Forms.RadioButton();
            this.Curve1PList = new System.Windows.Forms.RichTextBox();
            this.ClearCurve1Btn = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.T_Line2 = new System.Windows.Forms.RadioButton();
            this.T_Buzier2 = new System.Windows.Forms.RadioButton();
            this.Curve2PList = new System.Windows.Forms.RichTextBox();
            this.ClearCurve2Btn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Find = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.debug = new System.Windows.Forms.Label();
            this.MouseLoc = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(3, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(486, 530);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(492, 45);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(206, 303);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.T_Line1);
            this.tabPage1.Controls.Add(this.T_Buzier1);
            this.tabPage1.Controls.Add(this.Curve1PList);
            this.tabPage1.Controls.Add(this.ClearCurve1Btn);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(198, 274);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Curve1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // T_Line1
            // 
            this.T_Line1.AutoSize = true;
            this.T_Line1.Location = new System.Drawing.Point(66, 37);
            this.T_Line1.Name = "T_Line1";
            this.T_Line1.Size = new System.Drawing.Size(49, 20);
            this.T_Line1.TabIndex = 13;
            this.T_Line1.Text = "Line";
            this.T_Line1.UseVisualStyleBackColor = true;
            this.T_Line1.Click += new System.EventHandler(this.curve1LineMenuItem_Click);
            // 
            // T_Buzier1
            // 
            this.T_Buzier1.AutoSize = true;
            this.T_Buzier1.Checked = true;
            this.T_Buzier1.Location = new System.Drawing.Point(6, 37);
            this.T_Buzier1.Name = "T_Buzier1";
            this.T_Buzier1.Size = new System.Drawing.Size(60, 20);
            this.T_Buzier1.TabIndex = 12;
            this.T_Buzier1.TabStop = true;
            this.T_Buzier1.Text = "Buzier";
            this.T_Buzier1.UseVisualStyleBackColor = true;
            this.T_Buzier1.Click += new System.EventHandler(this.curve1BezierMenuItem1_Click);
            // 
            // Curve1PList
            // 
            this.Curve1PList.Location = new System.Drawing.Point(5, 59);
            this.Curve1PList.Name = "Curve1PList";
            this.Curve1PList.ReadOnly = true;
            this.Curve1PList.Size = new System.Drawing.Size(188, 209);
            this.Curve1PList.TabIndex = 11;
            this.Curve1PList.Text = "";
            // 
            // ClearCurve1Btn
            // 
            this.ClearCurve1Btn.Location = new System.Drawing.Point(5, 5);
            this.ClearCurve1Btn.Name = "ClearCurve1Btn";
            this.ClearCurve1Btn.Size = new System.Drawing.Size(188, 26);
            this.ClearCurve1Btn.TabIndex = 1;
            this.ClearCurve1Btn.Text = "Clear Curve1";
            this.ClearCurve1Btn.UseVisualStyleBackColor = true;
            this.ClearCurve1Btn.Click += new System.EventHandler(this.ClearCurve1Btn_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.T_Line2);
            this.tabPage2.Controls.Add(this.T_Buzier2);
            this.tabPage2.Controls.Add(this.Curve2PList);
            this.tabPage2.Controls.Add(this.ClearCurve2Btn);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(198, 274);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Curve2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // T_Line2
            // 
            this.T_Line2.AutoSize = true;
            this.T_Line2.Location = new System.Drawing.Point(66, 37);
            this.T_Line2.Name = "T_Line2";
            this.T_Line2.Size = new System.Drawing.Size(49, 20);
            this.T_Line2.TabIndex = 15;
            this.T_Line2.Text = "Line";
            this.T_Line2.UseVisualStyleBackColor = true;
            this.T_Line2.Click += new System.EventHandler(this.curve2LineToolStripMenuItem_Click);
            // 
            // T_Buzier2
            // 
            this.T_Buzier2.AutoSize = true;
            this.T_Buzier2.Checked = true;
            this.T_Buzier2.Location = new System.Drawing.Point(6, 37);
            this.T_Buzier2.Name = "T_Buzier2";
            this.T_Buzier2.Size = new System.Drawing.Size(60, 20);
            this.T_Buzier2.TabIndex = 14;
            this.T_Buzier2.TabStop = true;
            this.T_Buzier2.Text = "Buzier";
            this.T_Buzier2.UseVisualStyleBackColor = true;
            this.T_Buzier2.Click += new System.EventHandler(this.curve2BezierToolStripMenuItem_Click);
            // 
            // Curve2PList
            // 
            this.Curve2PList.Location = new System.Drawing.Point(5, 59);
            this.Curve2PList.Name = "Curve2PList";
            this.Curve2PList.ReadOnly = true;
            this.Curve2PList.Size = new System.Drawing.Size(188, 249);
            this.Curve2PList.TabIndex = 12;
            this.Curve2PList.Text = "";
            // 
            // ClearCurve2Btn
            // 
            this.ClearCurve2Btn.Location = new System.Drawing.Point(5, 5);
            this.ClearCurve2Btn.Name = "ClearCurve2Btn";
            this.ClearCurve2Btn.Size = new System.Drawing.Size(188, 26);
            this.ClearCurve2Btn.TabIndex = 2;
            this.ClearCurve2Btn.Text = "Clear Curve2";
            this.ClearCurve2Btn.UseVisualStyleBackColor = true;
            this.ClearCurve2Btn.Click += new System.EventHandler(this.ClearCurve2Btn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(5, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(188, 26);
            this.button1.TabIndex = 7;
            this.button1.Text = "Clear ALL";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ClearALL);
            // 
            // Find
            // 
            this.Find.Location = new System.Drawing.Point(5, 32);
            this.Find.Name = "Find";
            this.Find.Size = new System.Drawing.Size(188, 26);
            this.Find.TabIndex = 8;
            this.Find.Text = "Find intersection point";
            this.Find.UseVisualStyleBackColor = true;
            this.Find.Click += new System.EventHandler(this.Find_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Controls.Add(this.Find);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(494, 350);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 188);
            this.panel1.TabIndex = 9;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBox1.Location = new System.Drawing.Point(5, 64);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(188, 121);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = "";
            // 
            // debug
            // 
            this.debug.AutoSize = true;
            this.debug.Location = new System.Drawing.Point(601, 8);
            this.debug.Name = "debug";
            this.debug.Size = new System.Drawing.Size(33, 12);
            this.debug.TabIndex = 9;
            this.debug.Text = "label3";
            // 
            // MouseLoc
            // 
            this.MouseLoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MouseLoc.AutoSize = true;
            this.MouseLoc.BackColor = System.Drawing.SystemColors.Control;
            this.MouseLoc.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MouseLoc.Location = new System.Drawing.Point(493, 8);
            this.MouseLoc.Name = "MouseLoc";
            this.MouseLoc.Size = new System.Drawing.Size(53, 34);
            this.MouseLoc.TabIndex = 11;
            this.MouseLoc.Text = "0,0";
            // 
            // timer1
            // 
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 541);
            this.Controls.Add(this.MouseLoc);
            this.Controls.Add(this.debug);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "numm-Bézier curve generator";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button ClearCurve1Btn;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button ClearCurve2Btn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Find;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label debug;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox Curve1PList;
        private System.Windows.Forms.RichTextBox Curve2PList;
        private System.Windows.Forms.RadioButton T_Line1;
        private System.Windows.Forms.RadioButton T_Buzier1;
        private System.Windows.Forms.RadioButton T_Line2;
        private System.Windows.Forms.RadioButton T_Buzier2;
        private System.Windows.Forms.Label MouseLoc;
        private System.Windows.Forms.Timer timer1;
    }
}

