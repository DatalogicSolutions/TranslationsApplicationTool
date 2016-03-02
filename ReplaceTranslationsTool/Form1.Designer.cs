namespace ReplaceTranslationsTool
{
    partial class Form1
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
            this.gBStep1 = new System.Windows.Forms.GroupBox();
            this.lblResultsOut = new System.Windows.Forms.Label();
            this.lblFounds = new System.Windows.Forms.Label();
            this.pBFiles = new System.Windows.Forms.ProgressBar();
            this.lblResultsFiles = new System.Windows.Forms.Label();
            this.bFindFiles = new System.Windows.Forms.Button();
            this.gBStep2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.gBStep3 = new System.Windows.Forms.GroupBox();
            this.pBReplace = new System.Windows.Forms.ProgressBar();
            this.lblTextsReplaced = new System.Windows.Forms.Label();
            this.bReplace = new System.Windows.Forms.Button();
            this.lblErrors = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lBErrors = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lBResultsOut = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.gBStep1.SuspendLayout();
            this.gBStep2.SuspendLayout();
            this.gBStep3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBStep1
            // 
            this.gBStep1.Controls.Add(this.lblResultsOut);
            this.gBStep1.Controls.Add(this.lblFounds);
            this.gBStep1.Controls.Add(this.pBFiles);
            this.gBStep1.Controls.Add(this.lblResultsFiles);
            this.gBStep1.Controls.Add(this.bFindFiles);
            this.gBStep1.Location = new System.Drawing.Point(12, 12);
            this.gBStep1.Name = "gBStep1";
            this.gBStep1.Size = new System.Drawing.Size(300, 127);
            this.gBStep1.TabIndex = 2;
            this.gBStep1.TabStop = false;
            this.gBStep1.Text = "Step 1";
            // 
            // lblResultsOut
            // 
            this.lblResultsOut.AutoSize = true;
            this.lblResultsOut.Location = new System.Drawing.Point(200, 73);
            this.lblResultsOut.Name = "lblResultsOut";
            this.lblResultsOut.Size = new System.Drawing.Size(68, 13);
            this.lblResultsOut.TabIndex = 6;
            this.lblResultsOut.Text = "0 Strings Out";
            // 
            // lblFounds
            // 
            this.lblFounds.AutoSize = true;
            this.lblFounds.Location = new System.Drawing.Point(200, 44);
            this.lblFounds.Name = "lblFounds";
            this.lblFounds.Size = new System.Drawing.Size(81, 13);
            this.lblFounds.TabIndex = 5;
            this.lblFounds.Text = "0 Strings Found";
            // 
            // pBFiles
            // 
            this.pBFiles.Location = new System.Drawing.Point(15, 98);
            this.pBFiles.Name = "pBFiles";
            this.pBFiles.Size = new System.Drawing.Size(279, 23);
            this.pBFiles.TabIndex = 4;
            // 
            // lblResultsFiles
            // 
            this.lblResultsFiles.AutoSize = true;
            this.lblResultsFiles.Location = new System.Drawing.Point(200, 16);
            this.lblResultsFiles.Name = "lblResultsFiles";
            this.lblResultsFiles.Size = new System.Drawing.Size(70, 13);
            this.lblResultsFiles.TabIndex = 3;
            this.lblResultsFiles.Text = "0 Files Found";
            // 
            // bFindFiles
            // 
            this.bFindFiles.BackColor = System.Drawing.Color.Gold;
            this.bFindFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bFindFiles.Location = new System.Drawing.Point(15, 24);
            this.bFindFiles.Name = "bFindFiles";
            this.bFindFiles.Size = new System.Drawing.Size(75, 23);
            this.bFindFiles.TabIndex = 2;
            this.bFindFiles.Text = "Find Files";
            this.bFindFiles.UseVisualStyleBackColor = false;
            this.bFindFiles.Click += new System.EventHandler(this.bFindFiles_Click);
            // 
            // gBStep2
            // 
            this.gBStep2.Controls.Add(this.button1);
            this.gBStep2.Location = new System.Drawing.Point(12, 145);
            this.gBStep2.Name = "gBStep2";
            this.gBStep2.Size = new System.Drawing.Size(300, 84);
            this.gBStep2.TabIndex = 4;
            this.gBStep2.TabStop = false;
            this.gBStep2.Text = "Step 2";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gold;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(74, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Save Excluded Files Path";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gBStep3
            // 
            this.gBStep3.Controls.Add(this.pBReplace);
            this.gBStep3.Controls.Add(this.lblTextsReplaced);
            this.gBStep3.Controls.Add(this.bReplace);
            this.gBStep3.Location = new System.Drawing.Point(12, 236);
            this.gBStep3.Name = "gBStep3";
            this.gBStep3.Size = new System.Drawing.Size(300, 96);
            this.gBStep3.TabIndex = 5;
            this.gBStep3.TabStop = false;
            this.gBStep3.Text = "Step 3";
            // 
            // pBReplace
            // 
            this.pBReplace.Location = new System.Drawing.Point(15, 68);
            this.pBReplace.Name = "pBReplace";
            this.pBReplace.Size = new System.Drawing.Size(279, 23);
            this.pBReplace.TabIndex = 5;
            // 
            // lblTextsReplaced
            // 
            this.lblTextsReplaced.AutoSize = true;
            this.lblTextsReplaced.Location = new System.Drawing.Point(170, 45);
            this.lblTextsReplaced.Name = "lblTextsReplaced";
            this.lblTextsReplaced.Size = new System.Drawing.Size(91, 13);
            this.lblTextsReplaced.TabIndex = 4;
            this.lblTextsReplaced.Text = "0 Texts Replaced";
            // 
            // bReplace
            // 
            this.bReplace.BackColor = System.Drawing.Color.Gold;
            this.bReplace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bReplace.Location = new System.Drawing.Point(15, 35);
            this.bReplace.Name = "bReplace";
            this.bReplace.Size = new System.Drawing.Size(102, 23);
            this.bReplace.TabIndex = 4;
            this.bReplace.Text = "Replace Text";
            this.bReplace.UseVisualStyleBackColor = false;
            this.bReplace.Click += new System.EventHandler(this.bReplace_Click);
            // 
            // lblErrors
            // 
            this.lblErrors.AutoSize = true;
            this.lblErrors.Location = new System.Drawing.Point(24, 359);
            this.lblErrors.Name = "lblErrors";
            this.lblErrors.Size = new System.Drawing.Size(43, 13);
            this.lblErrors.TabIndex = 7;
            this.lblErrors.Text = "0 Errors";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tabControl1.Location = new System.Drawing.Point(324, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(988, 729);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(980, 703);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Results";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(3, 3);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(974, 697);
            this.listBox1.TabIndex = 6;
            this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lBErrors);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(980, 703);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Errors";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lBErrors
            // 
            this.lBErrors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lBErrors.FormattingEnabled = true;
            this.lBErrors.HorizontalScrollbar = true;
            this.lBErrors.Location = new System.Drawing.Point(3, 3);
            this.lBErrors.Name = "lBErrors";
            this.lBErrors.Size = new System.Drawing.Size(974, 697);
            this.lBErrors.TabIndex = 7;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lBResultsOut);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(980, 703);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Results Out";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lBResultsOut
            // 
            this.lBResultsOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lBResultsOut.FormattingEnabled = true;
            this.lBResultsOut.HorizontalScrollbar = true;
            this.lBResultsOut.Location = new System.Drawing.Point(0, 0);
            this.lBResultsOut.Name = "lBResultsOut";
            this.lBResultsOut.Size = new System.Drawing.Size(980, 703);
            this.lBResultsOut.TabIndex = 7;
            this.lBResultsOut.Click += new System.EventHandler(this.lBResultsOut_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Gold;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(27, 445);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(102, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Combine 2 files";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.ClientSize = new System.Drawing.Size(1312, 729);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblErrors);
            this.Controls.Add(this.gBStep3);
            this.Controls.Add(this.gBStep2);
            this.Controls.Add(this.gBStep1);
            this.Name = "Form1";
            this.Text = "Replace Translations Tool";
            this.gBStep1.ResumeLayout(false);
            this.gBStep1.PerformLayout();
            this.gBStep2.ResumeLayout(false);
            this.gBStep3.ResumeLayout(false);
            this.gBStep3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gBStep1;
        private System.Windows.Forms.Label lblResultsFiles;
        private System.Windows.Forms.Button bFindFiles;
        private System.Windows.Forms.GroupBox gBStep2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox gBStep3;
        private System.Windows.Forms.Label lblTextsReplaced;
        private System.Windows.Forms.Button bReplace;
        private System.Windows.Forms.ProgressBar pBFiles;
        private System.Windows.Forms.ProgressBar pBReplace;
        private System.Windows.Forms.Label lblErrors;
        private System.Windows.Forms.Label lblFounds;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox lBErrors;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListBox lBResultsOut;
        private System.Windows.Forms.Label lblResultsOut;
        private System.Windows.Forms.Button button3;
    }
}

