namespace ImageProcessing
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProcessReset = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuProcessInvert = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProcessDarken = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProcessWhiten = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuProcessFlipX = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProcessFlipY = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuProcessMirrorH = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProcessMirrorV = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuProcessScale50 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProcessScale200 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuProcessRotate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuProcessBlur = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuProcess});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(600, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileOpen,
            this.toolStripMenuItem1,
            this.mnuFileExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "File";
            // 
            // mnuFileOpen
            // 
            this.mnuFileOpen.Name = "mnuFileOpen";
            this.mnuFileOpen.Size = new System.Drawing.Size(112, 22);
            this.mnuFileOpen.Text = "Open...";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(109, 6);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(152, 22);
            this.mnuFileExit.Text = "Exit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // mnuProcess
            // 
            this.mnuProcess.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuProcessReset,
            this.toolStripMenuItem6,
            this.mnuProcessInvert,
            this.mnuProcessDarken,
            this.mnuProcessWhiten,
            this.toolStripMenuItem2,
            this.mnuProcessFlipX,
            this.mnuProcessFlipY,
            this.toolStripMenuItem3,
            this.mnuProcessMirrorH,
            this.mnuProcessMirrorV,
            this.toolStripMenuItem4,
            this.mnuProcessScale50,
            this.mnuProcessScale200,
            this.toolStripMenuItem5,
            this.mnuProcessRotate,
            this.toolStripMenuItem7,
            this.mnuProcessBlur});
            this.mnuProcess.Name = "mnuProcess";
            this.mnuProcess.Size = new System.Drawing.Size(59, 20);
            this.mnuProcess.Text = "Process";
            // 
            // mnuProcessReset
            // 
            this.mnuProcessReset.Name = "mnuProcessReset";
            this.mnuProcessReset.Size = new System.Drawing.Size(165, 22);
            this.mnuProcessReset.Text = "Reset";
            this.mnuProcessReset.Click += new System.EventHandler(this.mnuProcessReset_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(162, 6);
            // 
            // mnuProcessInvert
            // 
            this.mnuProcessInvert.Name = "mnuProcessInvert";
            this.mnuProcessInvert.Size = new System.Drawing.Size(165, 22);
            this.mnuProcessInvert.Text = "Invert";
            this.mnuProcessInvert.Click += new System.EventHandler(this.mnuProcessInvert_Click);
            // 
            // mnuProcessDarken
            // 
            this.mnuProcessDarken.Name = "mnuProcessDarken";
            this.mnuProcessDarken.Size = new System.Drawing.Size(165, 22);
            this.mnuProcessDarken.Text = "Darken";
            this.mnuProcessDarken.Click += new System.EventHandler(this.mnuProcessDarken_Click);
            // 
            // mnuProcessWhiten
            // 
            this.mnuProcessWhiten.Name = "mnuProcessWhiten";
            this.mnuProcessWhiten.Size = new System.Drawing.Size(165, 22);
            this.mnuProcessWhiten.Text = "Whiten";
            this.mnuProcessWhiten.Click += new System.EventHandler(this.mnuProcessWhiten_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(162, 6);
            // 
            // mnuProcessFlipX
            // 
            this.mnuProcessFlipX.Name = "mnuProcessFlipX";
            this.mnuProcessFlipX.Size = new System.Drawing.Size(165, 22);
            this.mnuProcessFlipX.Text = "Flip X";
            this.mnuProcessFlipX.Click += new System.EventHandler(this.mnuProcessFlipX_Click);
            // 
            // mnuProcessFlipY
            // 
            this.mnuProcessFlipY.Name = "mnuProcessFlipY";
            this.mnuProcessFlipY.Size = new System.Drawing.Size(165, 22);
            this.mnuProcessFlipY.Text = "Flip Y";
            this.mnuProcessFlipY.Click += new System.EventHandler(this.mnuProcessFlipY_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(162, 6);
            // 
            // mnuProcessMirrorH
            // 
            this.mnuProcessMirrorH.Name = "mnuProcessMirrorH";
            this.mnuProcessMirrorH.Size = new System.Drawing.Size(165, 22);
            this.mnuProcessMirrorH.Text = "Mirror Horizontal";
            this.mnuProcessMirrorH.Click += new System.EventHandler(this.mnuProcessMirrorH_Click);
            // 
            // mnuProcessMirrorV
            // 
            this.mnuProcessMirrorV.Name = "mnuProcessMirrorV";
            this.mnuProcessMirrorV.Size = new System.Drawing.Size(165, 22);
            this.mnuProcessMirrorV.Text = "Mirror Vertical";
            this.mnuProcessMirrorV.Click += new System.EventHandler(this.mnuProcessMirrorV_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(162, 6);
            // 
            // mnuProcessScale50
            // 
            this.mnuProcessScale50.Name = "mnuProcessScale50";
            this.mnuProcessScale50.Size = new System.Drawing.Size(165, 22);
            this.mnuProcessScale50.Text = "Scale 50";
            this.mnuProcessScale50.Click += new System.EventHandler(this.mnuProcessScale50_Click);
            // 
            // mnuProcessScale200
            // 
            this.mnuProcessScale200.Name = "mnuProcessScale200";
            this.mnuProcessScale200.Size = new System.Drawing.Size(165, 22);
            this.mnuProcessScale200.Text = "Scale 200";
            this.mnuProcessScale200.Click += new System.EventHandler(this.mnuProcessScale200_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(162, 6);
            // 
            // mnuProcessRotate
            // 
            this.mnuProcessRotate.Name = "mnuProcessRotate";
            this.mnuProcessRotate.Size = new System.Drawing.Size(165, 22);
            this.mnuProcessRotate.Text = "Rotate";
            this.mnuProcessRotate.Click += new System.EventHandler(this.mnuProcessRotate_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(162, 6);
            // 
            // mnuProcessBlur
            // 
            this.mnuProcessBlur.Name = "mnuProcessBlur";
            this.mnuProcessBlur.Size = new System.Drawing.Size(165, 22);
            this.mnuProcessBlur.Text = "Blur";
            this.mnuProcessBlur.Click += new System.EventHandler(this.mnuProcessBlur_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 330);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 2;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(600, 373);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Processing";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.ToolStripMenuItem mnuProcess;
        private System.Windows.Forms.ToolStripMenuItem mnuProcessInvert;
        private System.Windows.Forms.ToolStripMenuItem mnuProcessDarken;
        private System.Windows.Forms.ToolStripMenuItem mnuProcessWhiten;
        private System.Windows.Forms.ToolStripMenuItem mnuProcessReset;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuProcessFlipX;
        private System.Windows.Forms.ToolStripMenuItem mnuProcessFlipY;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mnuProcessMirrorH;
        private System.Windows.Forms.ToolStripMenuItem mnuProcessMirrorV;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem mnuProcessScale50;
        private System.Windows.Forms.ToolStripMenuItem mnuProcessScale200;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem mnuProcessBlur;
        private System.Windows.Forms.ToolStripMenuItem mnuProcessRotate;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.Label label1;
    }
}

