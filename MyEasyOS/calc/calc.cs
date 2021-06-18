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
    public partial class calc : Form
    {
        public calc()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("3");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("5");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("6");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("7");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("8");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("9");
        }

        private void button0_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("0");
        }

        private void dot_Click(object sender, EventArgs e)
        {
            textBox1.AppendText(".");
        }

        private void clear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void left_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("(");
        }

        private void right_Click(object sender, EventArgs e)
        {
            textBox1.AppendText(")");
        }

        private void back_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Substring(0,textBox1.Text.Length - 1);
        }

        private void add_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("+");
        }

        private void minus_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("-");
        }

        private void multi_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("*");
        }

        private void devide_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("/");
        }

        private bool calcing=false;//只有非计算时选择有效
        private void equal_Click(object sender, EventArgs e)
        {
            try
            {
                calcing = true;
                object answer = new DataTable().Compute(textBox1.Text, "");
                result.Items.Add(textBox1.Text);
                result.Items.Add(answer.ToString());
                result.SelectedIndex = result.Items.Count - 1;//定位到最后一行
                calcing = false;
            }
            catch
            {
                MessageBox.Show("表达式异常！");
            }
        }

        private void result_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!calcing)
                textBox1.Text = (string)result.Items[result.SelectedIndex];
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)(char)Keys.Enter)
            {
                e.Handled = true;
                equal.PerformClick();
            }
        }
    }
}
