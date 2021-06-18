namespace MyEasyOS
{
    partial class filesys
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.文件夹操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建文件夹ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除文件夹ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.文件操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.拷贝文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.拷贝文件自内部ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.删除文件夹ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.拷贝文件从外部ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.拷贝文件从内部ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 28);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(481, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1418, 749);
            this.splitContainer1.SplitterDistance = 481;
            this.splitContainer1.TabIndex = 3;
            // 
            // treeView1
            // 
            this.treeView1.ContextMenuStrip = this.contextMenuStrip1;
            this.treeView1.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.treeView1.Location = new System.Drawing.Point(4, 30);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(474, 718);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件夹操作ToolStripMenuItem,
            this.文件操作ToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(481, 28);
            this.menuStrip2.TabIndex = 2;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // 文件夹操作ToolStripMenuItem
            // 
            this.文件夹操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建文件夹ToolStripMenuItem,
            this.删除文件夹ToolStripMenuItem});
            this.文件夹操作ToolStripMenuItem.Name = "文件夹操作ToolStripMenuItem";
            this.文件夹操作ToolStripMenuItem.Size = new System.Drawing.Size(96, 24);
            this.文件夹操作ToolStripMenuItem.Text = "文件夹操作";
            // 
            // 新建文件夹ToolStripMenuItem
            // 
            this.新建文件夹ToolStripMenuItem.Name = "新建文件夹ToolStripMenuItem";
            this.新建文件夹ToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.新建文件夹ToolStripMenuItem.Text = "新建文件夹";
            this.新建文件夹ToolStripMenuItem.Click += new System.EventHandler(this.新建文件夹ToolStripMenuItem_Click);
            // 
            // 删除文件夹ToolStripMenuItem
            // 
            this.删除文件夹ToolStripMenuItem.Name = "删除文件夹ToolStripMenuItem";
            this.删除文件夹ToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.删除文件夹ToolStripMenuItem.Text = "删除文件夹";
            this.删除文件夹ToolStripMenuItem.Click += new System.EventHandler(this.删除文件夹ToolStripMenuItem_Click);
            // 
            // 文件操作ToolStripMenuItem
            // 
            this.文件操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建文件ToolStripMenuItem,
            this.删除文件ToolStripMenuItem,
            this.拷贝文件ToolStripMenuItem,
            this.拷贝文件自内部ToolStripMenuItem});
            this.文件操作ToolStripMenuItem.Name = "文件操作ToolStripMenuItem";
            this.文件操作ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.文件操作ToolStripMenuItem.Text = "文件操作";
            // 
            // 新建文件ToolStripMenuItem
            // 
            this.新建文件ToolStripMenuItem.Name = "新建文件ToolStripMenuItem";
            this.新建文件ToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.新建文件ToolStripMenuItem.Text = "新建文件";
            this.新建文件ToolStripMenuItem.Click += new System.EventHandler(this.新建文件ToolStripMenuItem_Click);
            // 
            // 删除文件ToolStripMenuItem
            // 
            this.删除文件ToolStripMenuItem.Name = "删除文件ToolStripMenuItem";
            this.删除文件ToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.删除文件ToolStripMenuItem.Text = "删除文件";
            this.删除文件ToolStripMenuItem.Click += new System.EventHandler(this.删除文件ToolStripMenuItem_Click);
            // 
            // 拷贝文件ToolStripMenuItem
            // 
            this.拷贝文件ToolStripMenuItem.Name = "拷贝文件ToolStripMenuItem";
            this.拷贝文件ToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.拷贝文件ToolStripMenuItem.Text = "拷贝文件自外部";
            this.拷贝文件ToolStripMenuItem.Click += new System.EventHandler(this.拷贝文件ToolStripMenuItem_Click);
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 23;
            this.listBox1.Location = new System.Drawing.Point(3, 3);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(927, 740);
            this.listBox1.TabIndex = 0;
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // 拷贝文件自内部ToolStripMenuItem
            // 
            this.拷贝文件自内部ToolStripMenuItem.Name = "拷贝文件自内部ToolStripMenuItem";
            this.拷贝文件自内部ToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.拷贝文件自内部ToolStripMenuItem.Text = "拷贝文件自内部";
            this.拷贝文件自内部ToolStripMenuItem.Click += new System.EventHandler(this.拷贝文件自内部ToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.删除文件夹ToolStripMenuItem1,
            this.拷贝文件从外部ToolStripMenuItem,
            this.拷贝文件从内部ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(184, 100);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(210, 24);
            this.toolStripMenuItem2.Text = "新建文件夹";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // 删除文件夹ToolStripMenuItem1
            // 
            this.删除文件夹ToolStripMenuItem1.Name = "删除文件夹ToolStripMenuItem1";
            this.删除文件夹ToolStripMenuItem1.Size = new System.Drawing.Size(210, 24);
            this.删除文件夹ToolStripMenuItem1.Text = "删除文件夹";
            this.删除文件夹ToolStripMenuItem1.Click += new System.EventHandler(this.删除文件夹ToolStripMenuItem1_Click);
            // 
            // 拷贝文件从外部ToolStripMenuItem
            // 
            this.拷贝文件从外部ToolStripMenuItem.Name = "拷贝文件从外部ToolStripMenuItem";
            this.拷贝文件从外部ToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.拷贝文件从外部ToolStripMenuItem.Text = "拷贝文件从外部";
            this.拷贝文件从外部ToolStripMenuItem.Click += new System.EventHandler(this.拷贝文件从外部ToolStripMenuItem_Click);
            // 
            // 拷贝文件从内部ToolStripMenuItem
            // 
            this.拷贝文件从内部ToolStripMenuItem.Name = "拷贝文件从内部ToolStripMenuItem";
            this.拷贝文件从内部ToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.拷贝文件从内部ToolStripMenuItem.Text = "拷贝文件从内部";
            this.拷贝文件从内部ToolStripMenuItem.Click += new System.EventHandler(this.拷贝文件从内部ToolStripMenuItem_Click);
            // 
            // filesys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1418, 749);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "filesys";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "简单文件浏览器(单机树节点展示内容，双击树节点打开下一层，双击可执行文件可执行，双击文件夹展开下一层)";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 文件夹操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 文件操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建文件夹ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除文件夹ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 拷贝文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 拷贝文件自内部ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 删除文件夹ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 拷贝文件从外部ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 拷贝文件从内部ToolStripMenuItem;
    }
}

