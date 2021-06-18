namespace MyEasyOS
{
    partial class complier
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.complie = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.init = new System.Windows.Forms.Button();
            this.result = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(75, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(623, 128);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "using System;\r\nusing System.Collections.Generic;";
            this.textBox1.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "头文件";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(75, 135);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(623, 30);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "public static class DynamicClass {";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(75, 172);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(623, 30);
            this.textBox3.TabIndex = 3;
            this.textBox3.Text = "  public static object CalcValue() {";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(75, 210);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox4.Size = new System.Drawing.Size(623, 462);
            this.textBox4.TabIndex = 4;
            this.textBox4.WordWrap = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "程序体";
            // 
            // complie
            // 
            this.complie.Location = new System.Drawing.Point(704, 0);
            this.complie.Name = "complie";
            this.complie.Size = new System.Drawing.Size(42, 747);
            this.complie.TabIndex = 6;
            this.complie.Text = "编\r\n译";
            this.complie.UseVisualStyleBackColor = true;
            this.complie.Click += new System.EventHandler(this.complie_Click);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(75, 678);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(623, 30);
            this.textBox5.TabIndex = 7;
            this.textBox5.Text = "    return";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 678);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 40);
            this.label3.TabIndex = 8;
            this.label3.Text = "返回值\r\n(必须)";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(75, 714);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(623, 30);
            this.textBox6.TabIndex = 9;
            this.textBox6.Text = "  }";
            // 
            // init
            // 
            this.init.Location = new System.Drawing.Point(752, 364);
            this.init.Name = "init";
            this.init.Size = new System.Drawing.Size(42, 383);
            this.init.TabIndex = 11;
            this.init.Text = "初始化";
            this.init.UseVisualStyleBackColor = true;
            this.init.Click += new System.EventHandler(this.init_Click);
            // 
            // result
            // 
            this.result.FormattingEnabled = true;
            this.result.HorizontalScrollbar = true;
            this.result.ItemHeight = 20;
            this.result.Location = new System.Drawing.Point(800, 400);
            this.result.Name = "result";
            this.result.ScrollAlwaysVisible = true;
            this.result.Size = new System.Drawing.Size(616, 344);
            this.result.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(764, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 60);
            this.label4.TabIndex = 13;
            this.label4.Text = "剩\r\n余\r\n段";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(800, 3);
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox7.Size = new System.Drawing.Size(616, 355);
            this.textBox7.TabIndex = 14;
            this.textBox7.WordWrap = false;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(800, 364);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(616, 30);
            this.textBox8.TabIndex = 15;
            this.textBox8.Text = "}";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(4, 234);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 35);
            this.button1.TabIndex = 16;
            this.button1.Text = "open";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(4, 275);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(65, 35);
            this.button2.TabIndex = 17;
            this.button2.Text = "save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(752, 63);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(42, 62);
            this.button3.TabIndex = 18;
            this.button3.Text = "open";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(752, 131);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(42, 58);
            this.button4.TabIndex = 19;
            this.button4.Text = "save";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // complier
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1418, 749);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.result);
            this.Controls.Add(this.init);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.complie);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "complier";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "简单编译器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button complie;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Button init;
        private System.Windows.Forms.ListBox result;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

