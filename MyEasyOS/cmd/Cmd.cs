using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyEasyOS
{
    public partial class Cmd : Form
    {
        //禁用鼠标
        [DllImport("user32", EntryPoint = "ShowCursor")]
        public extern static bool ShowCursor(bool show);

        //长1420 宽720 分布
        int rowid = 0;
        public Cmd()
        {
            InitializeComponent();//隐藏鼠标
            textBox1.ReadOnly = true;//禁止编辑，所有编辑重写
            ShowCursor(false);
        }

        private void Cmd_FormClosed(object sender, FormClosedEventArgs e)//恢复鼠标
        {
            ShowCursor(true);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)//按下按键
        {
            if (e.KeyChar == (int)(char)Keys.Enter)
            {
                //处理命令
                string command = textBox1.Lines[rowid].Substring(common.virtualfile().Length + 1).Trim().ToLower();//实际命令，取空格，转为小写
                deal(command);//处理指令
                //其余处理
                rowid++;
                textBox1.AppendText("\r\n");
                textBox1.AppendText(common.virtualfile() + ">");
                textBox1.Focus();//获取焦点
                textBox1.Select(this.textBox1.TextLength, 0);//光标定位到文本最后
                textBox1.ScrollToCaret();//滚动到光标处
            }
            else if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z'))//允许输入
            {
                textBox1.AppendText(e.KeyChar.ToString());
                e.Handled = true;
            }
            else if (e.KeyChar == (int)(char)Keys.Back)//实现退格，需要刷新所有控件
            {
                if (textBox1.Lines[rowid].Length > common.virtualfile().Length + 1)
                {
                    textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
                    textBox1.Focus();//获取焦点
                    textBox1.Select(this.textBox1.TextLength, 0);//光标定位到文本最后
                    textBox1.ScrollToCaret();//滚动到光标处
                }
                e.Handled = true;
            }
            else if (e.KeyChar == (int)(char)Keys.Space)
            {
                e.Handled = true;
                textBox1.AppendText(" ");
            }
            else if(e.KeyChar=='+'|| e.KeyChar == '-'|| e.KeyChar == '*' || e.KeyChar == '/'|| e.KeyChar == '.'|| e.KeyChar == '('|| e.KeyChar == ')')
            {
                textBox1.AppendText(e.KeyChar.ToString());
                e.Handled = true;
            }
        }

        private void Cmd_Shown(object sender, EventArgs e)//增加开始头
        {
            textBox1.AppendText(common.virtualfile() + ">");
            textBox1.Focus();//获取焦点
            textBox1.Select(this.textBox1.TextLength, 0);//光标定位到文本最后
            textBox1.ScrollToCaret();//滚动到光标处
        }

        private void deal(string command)
        {
            if (command == "exit")//退出
            {
                textBox1.AppendText("\r\nquitting......");
                Thread.Sleep(300);
                this.Close();
            }
            else if (command == "time")//展示时间
            {
                textBox1.AppendText($"\r\n{DateTime.Now}");
                rowid++;//必须有
            }
            else if(command=="clock")
            {
                ShowCursor(true);
                clock newform = new clock();
                this.Hide();
                newform.ShowDialog();
                this.Show();
                ShowCursor(false);
            }
            else if (command == "surfer"|| command == "browser")//浏览器
            {
                ShowCursor(true);
                surfer newform = new surfer();
                this.Hide();
                newform.ShowDialog();
                this.Show();
                ShowCursor(false);
            }
            else if(command=="calc")//计算器
            {
                ShowCursor(true);
                calc newform = new calc();
                this.Hide();
                newform.ShowDialog();
                this.Show();
                ShowCursor(false);
            }
            else if(command.Length>=5&&command.Substring(0,5)=="calc ")//直接计算
            {
                try
                {
                    object answer = new DataTable().Compute(command.Substring(5), "");
                    textBox1.AppendText($"\r\n{answer.ToString()}");
                    rowid++;
                }
                catch
                {
                    textBox1.AppendText("\r\nillegal expression!");
                    rowid++;
                }
            }
            else if (command == "info")//程序信息
            {
                textBox1.AppendText("\r\nAn Easy Operating System!");
                rowid++;
                textBox1.AppendText("\r\nCreated By Johnny!");
                rowid++;
                textBox1.AppendText("\r\nType help for more info!");
                rowid++;
                textBox1.AppendText("\r\nhave fun!");
                rowid++;
            }
            else if (command == "farm")//农场
            {
                ShowCursor(true);
                gamelogin newform = new gamelogin();                
                this.Hide();
                newform.ShowDialog();
                this.Show();
                ShowCursor(false);
            }
            else if(command.Length >= 5 && command.Substring(0, 5) == "farm ")//账号密码直接登录农场
            {
                string others = command.Substring(5);//账号 密码
                string[] spilts = others.Split(' ');
                if(spilts.Length==2)
                {
                    //1成功登陆，2找不到账号，3密码错误
                    int result =player.readdata(spilts[0], spilts[1]);
                    if(result==2)
                    {
                        textBox1.AppendText("\r\nCan't Find Account!");
                        rowid++;
                    }
                    if(result==3)
                    {
                        textBox1.AppendText("\r\nError Password!");
                        rowid++;
                    }
                    if(result==1)
                    {
                        textBox1.AppendText("\r\nSuccess!Entering game!");
                        rowid++;
                        Thread.Sleep(300);
                        ShowCursor(true);
                        EasyFarm newform = new EasyFarm();
                        this.Hide();//隐藏旧窗体
                        newform.ShowDialog();//展示新窗体
                        newform.Dispose();//销毁老窗体
                        this.Show();//重新展示旧窗体
                        ShowCursor(false);
                    }
                }
                else
                {
                    textBox1.AppendText("\r\nillegal inputs!Try code farm instead!");
                    rowid++;
                }               
            }
            else if (command == "data")//数据分析
            {
                ShowCursor(true);
                data newform = new data();
                this.Hide();
                newform.ShowDialog();
                this.Show();
                ShowCursor(false);
            }
            else if (command.Length >= 5 && command.Substring(0, 5) == "data ")//直接输入数据进行数据分析
            {
                string others = command.Substring(5);//要分析的数据
                string[] spilts = others.Split(' ');
                double[] input = new double[spilts.Length];
                for(int i=0;i<spilts.Length;i++)
                {
                    try
                    {
                        input[i] = Convert.ToDouble(spilts[i]);
                    }
                    catch
                    {
                        textBox1.AppendText("\r\nInvalid Input!Try code data instead!");
                        rowid++;
                        return;
                    }
                }
                ShowCursor(true);
                data newform = new data(input);
                this.Hide();//隐藏旧窗体
                newform.ShowDialog();//展示新窗体
                newform.Dispose();//销毁老窗体
                this.Show();//重新展示旧窗体
                ShowCursor(false);
            }
            else if(command=="complier")
            {
                ShowCursor(true);
                complier newform = new complier();
                this.Hide();
                newform.ShowDialog();
                this.Show();
                ShowCursor(false);
            }
            else if (command == "pic")
            {
                ShowCursor(true);
                picviewer newform = new picviewer();
                this.Hide();
                newform.ShowDialog();
                this.Show();
                ShowCursor(false);
            }
            else if (command == "draw")
            {
                ShowCursor(true);
                paint newform = new paint();
                this.Hide();
                newform.ShowDialog();
                this.Show();
                ShowCursor(false);
            }
            else if(command=="file")
            {
                ShowCursor(true);
                filesys newform = new filesys();
                this.Hide();
                newform.ShowDialog();
                this.Show();
                ShowCursor(false);
            }
            else if(command=="media")
            {
                ShowCursor(true);
                mpr mprf = new mpr();
                this.Hide();
                mprf.ShowDialog();
                this.Show();
                mprf.Dispose();
                ShowCursor(false);
            }
            else if(command=="")
            {
                //什么都不做
            }
            else
            {
                textBox1.AppendText("\r\nillegal code entered");
                rowid++;//必须有
            }
        }
    }
}
