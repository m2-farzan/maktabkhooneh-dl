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
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnTotalSize = new System.Windows.Forms.Button();
            this.chkRename = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkArea = new System.Windows.Forms.LinkArea(32, 36);
            this.linkLabel1.Location = new System.Drawing.Point(15, 18);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(547, 26);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Enter link of the course page: (https://maktabkhooneh.org/course/...)";
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
            this.radHq.Location = new System.Drawing.Point(90, 89);
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
            this.radLq.Location = new System.Drawing.Point(160, 89);
            this.radLq.Name = "radLq";
            this.radLq.Size = new System.Drawing.Size(61, 25);
            this.radLq.TabIndex = 3;
            this.radLq.Text = "Low";
            this.radLq.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 91);
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
            this.txtOutputURLs.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutputURLs.Size = new System.Drawing.Size(695, 272);
            this.txtOutputURLs.TabIndex = 6;
            this.txtOutputURLs.WordWrap = false;
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(15, 444);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(224, 40);
            this.btnCopy.TabIndex = 5;
            this.btnCopy.Text = "Copy To Clipboard";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(245, 444);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(235, 40);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnTotalSize
            // 
            this.btnTotalSize.Location = new System.Drawing.Point(486, 444);
            this.btnTotalSize.Name = "btnTotalSize";
            this.btnTotalSize.Size = new System.Drawing.Size(224, 40);
            this.btnTotalSize.TabIndex = 5;
            this.btnTotalSize.Text = "Estimate Total Size";
            this.btnTotalSize.UseVisualStyleBackColor = true;
            this.btnTotalSize.Click += new System.EventHandler(this.btnTotalSize_Click);
            // 
            // chkRename
            // 
            this.chkRename.AutoSize = true;
            this.chkRename.Checked = true;
            this.chkRename.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRename.Location = new System.Drawing.Point(435, 91);
            this.chkRename.Name = "chkRename";
            this.chkRename.Size = new System.Drawing.Size(276, 25);
            this.chkRename.TabIndex = 7;
            this.chkRename.Text = "Rename Videos (Recommended)";
            this.chkRename.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 496);
            this.Controls.Add(this.chkRename);
            this.Controls.Add(this.txtOutputURLs);
            this.Controls.Add(this.btnTotalSize);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radLq);
            this.Controls.Add(this.radHq);
            this.Controls.Add(this.txtInputURL);
            this.Controls.Add(this.linkLabel1);
            this.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
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
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnTotalSize;
        private System.Windows.Forms.CheckBox chkRename;
    }
}

