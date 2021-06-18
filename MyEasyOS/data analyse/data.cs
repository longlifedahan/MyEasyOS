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
    public partial class data : Form
    {
        public data()
        {
            InitializeComponent();       
        }

        public data(double[] input)
        {
            InitializeComponent();
            for (int i = 0; i < input.Length; i++)
            {
                textBox1.AppendText(input[i].ToString());
                if (i != input.Length - 1)//非最后一行换行
                    textBox1.AppendText("\r\n");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                return;
            //清楚老的进度条
            this.panel1.Controls.Clear();
            //生成和初始化进度条
            ProgressBar[] pbs = new ProgressBar[textBox1.Lines.Length];
            for (int i = 0; i < textBox1.Lines.Length; i++)
            {
                pbs[i] = new ProgressBar();
                pbs[i].Size = new System.Drawing.Size(500, (int)(450.0/ textBox1.Lines.Length));
                pbs[i].Location = new Point(0, (int)(450.0 / textBox1.Lines.Length) * i);
                pbs[i].Visible = false;
                panel1.Controls.Add(pbs[i]);
            }
            double maxvalue = 0;
            double minvalue = double.MaxValue;
            double sum = 0;
            for(int i=0;i<textBox1.Lines.Length;i++)
            {
                if (textBox1.Lines[i] == "")
                {
                    MessageBox.Show("不可以有为空的项！");
                    return;
                }                
                try
                {
                    double value = Convert.ToDouble(textBox1.Lines[i]);
                    if(value<0)
                    {
                        MessageBox.Show("数据只能为正数（整数/小数），请勿进行非法操作！");
                        return;
                    }
                    maxvalue = (maxvalue > value) ? maxvalue : value;
                    minvalue = (minvalue < value) ? minvalue : value;
                    sum += value;
                }
                catch
                {
                    MessageBox.Show("数据只能为正数（整数/小数），请勿进行非法操作！");
                    return;
                }
            }
            textBox2.Clear();
            textBox2.AppendText($"max:{maxvalue}\r\n");
            textBox2.AppendText($"min:{minvalue}\r\n");
            textBox2.AppendText($"ave:{sum/ textBox1.Lines.Length}\r\n");
            for (int i = 0; i < textBox1.Lines.Length; i++)
            {
                if (textBox1.Lines[i] != "")
                {
                    //扩大1000倍缩小差异
                    pbs[i].Maximum = (int)(maxvalue*1000);
                    pbs[i].Value = (int)(Convert.ToDouble(textBox1.Lines[i])*1000);
                    pbs[i].Visible = true;
                }
            }
        }
        //键盘只可以输入数字、字母和小数点
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!((e.KeyChar>='0'&&e.KeyChar<='9')||e.KeyChar=='.'||e.KeyChar==(int)(char)Keys.Back|| e.KeyChar == (int)(char)Keys.Enter))
            {
                e.Handled = true;
            }
        }
        //Ctrl+C
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)//用户是否按下了Ctrl键
            {
                if (e.KeyCode == Keys.V)
                {
                    textBox1.AppendText(Clipboard.GetText());
                }
                if (e.KeyCode == Keys.C)
                {
                    Clipboard.SetText(textBox1.Text);
                }
            }
        }

        private void data_Shown(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                button1_Click(new object(), new EventArgs());
        }
    }
}
