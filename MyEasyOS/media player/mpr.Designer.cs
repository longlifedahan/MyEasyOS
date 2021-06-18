namespace MyEasyOS
{
    partial class mpr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mpr));
            this.WMP = new AxWMPLib.AxWindowsMediaPlayer();
            this.button1 = new System.Windows.Forms.Button();
            this.history = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.WMP)).BeginInit();
            this.SuspendLayout();
            // 
            // WMP
            // 
            this.WMP.Enabled = true;
            this.WMP.Location = new System.Drawing.Point(0, 0);
            this.WMP.Name = "WMP";
            this.WMP.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("WMP.OcxState")));
            this.WMP.Size = new System.Drawing.Size(1150, 750);
            this.WMP.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1150, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(270, 100);
            this.button1.TabIndex = 1;
            this.button1.Text = "打开文件";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // history
            // 
            this.history.FormattingEnabled = true;
            this.history.HorizontalScrollbar = true;
            this.history.ItemHeight = 15;
            this.history.Location = new System.Drawing.Point(1150, 100);
            this.history.Name = "history";
            this.history.ScrollAlwaysVisible = true;
            this.history.Size = new System.Drawing.Size(270, 649);
            this.history.TabIndex = 2;
            this.history.SelectedIndexChanged += new System.EventHandler(this.history_SelectedIndexChanged);
            // 
            // mpr
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1418, 749);
            this.Controls.Add(this.history);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.WMP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "mpr";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "媒体播放器";
            ((System.ComponentModel.ISupportInitialize)(this.WMP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer WMP;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox history;
    }
}