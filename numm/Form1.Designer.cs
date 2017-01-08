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
            this.pictureBox1.Location = new System.Drawing.Point(7, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1053, 1079);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1066, 15);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(446, 681);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.T_Line1);
            this.tabPage1.Controls.Add(this.T_Buzier1);
            this.tabPage1.Controls.Add(this.Curve1PList);
            this.tabPage1.Controls.Add(this.ClearCurve1Btn);
            this.tabPage1.Location = new System.Drawing.Point(8, 39);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tabPage1.Size = new System.Drawing.Size(430, 634);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Curve1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // T_Line1
            // 
            this.T_Line1.AutoSize = true;
            this.T_Line1.Location = new System.Drawing.Point(137, 76);
            this.T_Line1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.T_Line1.Name = "T_Line1";
            this.T_Line1.Size = new System.Drawing.Size(82, 28);
            this.T_Line1.TabIndex = 13;
            this.T_Line1.Text = "Line";
            this.T_Line1.UseVisualStyleBackColor = true;
            this.T_Line1.Click += new System.EventHandler(this.curve1LineMenuItem_Click);
            // 
            // T_Buzier1
            // 
            this.T_Buzier1.AutoSize = true;
            this.T_Buzier1.Checked = true;
            this.T_Buzier1.Location = new System.Drawing.Point(7, 76);
            this.T_Buzier1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.T_Buzier1.Name = "T_Buzier1";
            this.T_Buzier1.Size = new System.Drawing.Size(101, 28);
            this.T_Buzier1.TabIndex = 12;
            this.T_Buzier1.TabStop = true;
            this.T_Buzier1.Text = "Buzier";
            this.T_Buzier1.UseVisualStyleBackColor = true;
            this.T_Buzier1.Click += new System.EventHandler(this.curve1BezierMenuItem1_Click);
            // 
            // Curve1PList
            // 
            this.Curve1PList.Location = new System.Drawing.Point(7, 134);
            this.Curve1PList.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Curve1PList.Name = "Curve1PList";
            this.Curve1PList.ReadOnly = true;
            this.Curve1PList.Size = new System.Drawing.Size(401, 488);
            this.Curve1PList.TabIndex = 11;
            this.Curve1PList.Text = "";
            // 
            // ClearCurve1Btn
            // 
            this.ClearCurve1Btn.Location = new System.Drawing.Point(7, 10);
            this.ClearCurve1Btn.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ClearCurve1Btn.Name = "ClearCurve1Btn";
            this.ClearCurve1Btn.Size = new System.Drawing.Size(405, 52);
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
            this.tabPage2.Location = new System.Drawing.Point(8, 39);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tabPage2.Size = new System.Drawing.Size(430, 595);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Curve2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // T_Line2
            // 
            this.T_Line2.AutoSize = true;
            this.T_Line2.Location = new System.Drawing.Point(143, 74);
            this.T_Line2.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.T_Line2.Name = "T_Line2";
            this.T_Line2.Size = new System.Drawing.Size(82, 28);
            this.T_Line2.TabIndex = 15;
            this.T_Line2.Text = "Line";
            this.T_Line2.UseVisualStyleBackColor = true;
            this.T_Line2.Click += new System.EventHandler(this.curve2LineToolStripMenuItem_Click);
            // 
            // T_Buzier2
            // 
            this.T_Buzier2.AutoSize = true;
            this.T_Buzier2.Checked = true;
            this.T_Buzier2.Location = new System.Drawing.Point(13, 74);
            this.T_Buzier2.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.T_Buzier2.Name = "T_Buzier2";
            this.T_Buzier2.Size = new System.Drawing.Size(101, 28);
            this.T_Buzier2.TabIndex = 14;
            this.T_Buzier2.TabStop = true;
            this.T_Buzier2.Text = "Buzier";
            this.T_Buzier2.UseVisualStyleBackColor = true;
            this.T_Buzier2.Click += new System.EventHandler(this.curve2BezierToolStripMenuItem_Click);
            // 
            // Curve2PList
            // 
            this.Curve2PList.Location = new System.Drawing.Point(7, 122);
            this.Curve2PList.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Curve2PList.Name = "Curve2PList";
            this.Curve2PList.ReadOnly = true;
            this.Curve2PList.Size = new System.Drawing.Size(401, 452);
            this.Curve2PList.TabIndex = 12;
            this.Curve2PList.Text = "";
            // 
            // ClearCurve2Btn
            // 
            this.ClearCurve2Btn.Location = new System.Drawing.Point(7, 10);
            this.ClearCurve2Btn.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ClearCurve2Btn.Name = "ClearCurve2Btn";
            this.ClearCurve2Btn.Size = new System.Drawing.Size(405, 52);
            this.ClearCurve2Btn.TabIndex = 2;
            this.ClearCurve2Btn.Text = "Clear Curve2";
            this.ClearCurve2Btn.UseVisualStyleBackColor = true;
            this.ClearCurve2Btn.Click += new System.EventHandler(this.ClearCurve2Btn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 6);
            this.button1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(405, 52);
            this.button1.TabIndex = 7;
            this.button1.Text = "Clear ALL";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ClearALL);
            // 
            // Find
            // 
            this.Find.Location = new System.Drawing.Point(15, 64);
            this.Find.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Find.Name = "Find";
            this.Find.Size = new System.Drawing.Size(405, 52);
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
            this.panel1.Controls.Add(this.debug);
            this.panel1.Controls.Add(this.Find);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(1070, 700);
            this.panel1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(433, 394);
            this.panel1.TabIndex = 9;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBox1.Location = new System.Drawing.Point(17, 154);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(394, 230);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = "";
            // 
            // debug
            // 
            this.debug.AutoSize = true;
            this.debug.Location = new System.Drawing.Point(13, 124);
            this.debug.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.debug.Name = "debug";
            this.debug.Size = new System.Drawing.Size(64, 24);
            this.debug.TabIndex = 9;
            this.debug.Text = "label3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1515, 1044);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
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
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

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
    }
}

