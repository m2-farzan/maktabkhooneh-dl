namespace maktabkhooneh_link_finder
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.txtInputURL = new System.Windows.Forms.TextBox();
            this.radHq = new System.Windows.Forms.RadioButton();
            this.radLq = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtOutputURLs = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkArea = new System.Windows.Forms.LinkArea(37, 80);
            this.linkLabel1.Location = new System.Drawing.Point(15, 18);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(649, 26);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Enter link of the course page: (e.g. https://maktabkhooneh.org/course/golshani40)" +
    "";
            this.linkLabel1.UseCompatibleTextRendering = true;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // txtInputURL
            // 
            this.txtInputURL.Location = new System.Drawing.Point(15, 47);
            this.txtInputURL.Name = "txtInputURL";
            this.txtInputURL.Size = new System.Drawing.Size(696, 28);
            this.txtInputURL.TabIndex = 1;
            // 
            // radHq
            // 
            this.radHq.AutoSize = true;
            this.radHq.Checked = true;
            this.radHq.Location = new System.Drawing.Point(335, 89);
            this.radHq.Name = "radHq";
            this.radHq.Size = new System.Drawing.Size(64, 25);
            this.radHq.TabIndex = 2;
            this.radHq.TabStop = true;
            this.radHq.Text = "High";
            this.radHq.UseVisualStyleBackColor = true;
            // 
            // radLq
            // 
            this.radLq.AutoSize = true;
            this.radLq.Location = new System.Drawing.Point(405, 89);
            this.radLq.Name = "radLq";
            this.radLq.Size = new System.Drawing.Size(61, 25);
            this.radLq.TabIndex = 3;
            this.radLq.Text = "Low";
            this.radLq.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(257, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Quality: ";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(255, 120);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(212, 40);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtOutputURLs
            // 
            this.txtOutputURLs.Location = new System.Drawing.Point(15, 166);
            this.txtOutputURLs.Multiline = true;
            this.txtOutputURLs.Name = "txtOutputURLs";
            this.txtOutputURLs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutputURLs.Size = new System.Drawing.Size(695, 318);
            this.txtOutputURLs.TabIndex = 6;
            this.txtOutputURLs.WordWrap = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 496);
            this.Controls.Add(this.txtOutputURLs);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radLq);
            this.Controls.Add(this.radHq);
            this.Controls.Add(this.txtInputURL);
            this.Controls.Add(this.linkLabel1);
            this.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maktabkhooneh Link Finder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox txtInputURL;
        private System.Windows.Forms.RadioButton radHq;
        private System.Windows.Forms.RadioButton radLq;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtOutputURLs;
    }
}

