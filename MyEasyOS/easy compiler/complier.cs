using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyEasyOS
{
    public partial class complier : Form
    {
        //长1420 宽720 分布
        public complier()
        {
            InitializeComponent();
        }

        public complier(string filename)
        {
            InitializeComponent();
            textBox7.Text = File.ReadAllText(filename);
        }

        private void complie_Click(object sender, EventArgs e)
        {
            string code = "";
            code += textBox1.Text+"\r\n";
            code += textBox2.Text + "\r\n";
            code += textBox3.Text + "\r\n";
            code += textBox4.Text + "\r\n";
            code += textBox5.Text + "\r\n";
            code += textBox6.Text + "\r\n";
            code += textBox7.Text + "\r\n";
            code += textBox8.Text + "\r\n";
            try
            {
                object myresult = dongtaibianyi.CalcValue(code);
                result.Items.Add(myresult.ToString());
                result.SelectedIndex = result.Items.Count - 1;//定位到最后一行
            }
            catch(Exception mye)
            {
                result.Items.Add(mye.ToString());
            }
        }

        private void init_Click(object sender, EventArgs e)
        {
            textBox1.Text = "using System;\r\nusing System.Collections.Generic;\r\n";
            textBox4.Text = "";
            textBox5.Text = "    return";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofg = new OpenFileDialog();
            ofg.Filter = "cs文件(*.cs)|*.cs|文本文件(*.txt) | *.txt";
            ofg.InitialDirectory = common.userfile()+"cs";
            if(ofg.ShowDialog()==DialogResult.OK)
                textBox4.Text = File.ReadAllText(ofg.FileName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfg = new SaveFileDialog();
            sfg.DefaultExt = ".cs"; //设置默认扩展名
            sfg.InitialDirectory = common.userfile() + "cs";
            sfg.Filter= "cs文件(*.cs)|*.cs|文本文件(*.txt) | *.txt";
            if (sfg.ShowDialog() == DialogResult.OK)
                File.WriteAllText(sfg.FileName, textBox4.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofg = new OpenFileDialog();
            ofg.Filter = "cs文件(*.cs)|*.cs|文本文件(*.txt) | *.txt";
            ofg.InitialDirectory = common.userfile() + "cs";
            if (ofg.ShowDialog() == DialogResult.OK)
                textBox7.Text = File.ReadAllText(ofg.FileName);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfg = new SaveFileDialog();
            sfg.DefaultExt = ".cs"; //设置默认扩展名
            sfg.InitialDirectory = common.userfile() + "cs";
            sfg.Filter = "cs文件(*.cs)|*.cs|文本文件(*.txt) | *.txt";
            if (sfg.ShowDialog() == DialogResult.OK)
                File.WriteAllText(sfg.FileName, textBox7.Text);
        }
    }
}
