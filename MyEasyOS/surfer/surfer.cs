using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyEasyOS
{
    public partial class surfer : Form
    {
        //长1420 宽720 分布
        public surfer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.ScriptErrorsSuppressed = true;//禁止弹出错误
            string add="";
            if(!textBox1.Text.Trim().StartsWith("https://"))//增加头部
            {
                add = "https://" + textBox1.Text.Trim();
                textBox1.Text = add;
            }
            webBrowser1.Url = new Uri(add);
        }

        private void webBrowser1_NewWindow(object sender, CancelEventArgs e)//创建新窗口
        {
            e.Cancel = true;//防止弹窗
            textBox1.Text= webBrowser1.StatusText;//更换当前网页值
            string url = webBrowser1.StatusText;
            webBrowser1.Url = new Uri(url);
        }

        private void surfer_FormClosed(object sender, FormClosedEventArgs e)//显示关闭webBrowser
        {
            webBrowser1.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
            textBox1.Text = webBrowser1.Url.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
            textBox1.Text = webBrowser1.Url.ToString();
        }
    }
}
