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
using System.Data.SQLite;
using System.Media;

namespace MyEasyOS
{
    public partial class gamelogin : Form
    {       
        public gamelogin()
        {
            InitializeComponent();
            //建立数据库
            var fileName = common.userfile()+"gameuser.db";
            if (File.Exists(fileName) == false)//不存在用户文件
            {
                SQLiteConnection.CreateFile(fileName);//创建数据库
            }
            SQLiteConnection cn = new SQLiteConnection("data source=" + fileName);//建立连接对象
            SQLiteCommand cmd = new SQLiteCommand();

            //当没有用户表时建立用户表
            cn.Open();//连接
            cmd.Connection = cn;
            cmd.CommandText = 
                "CREATE TABLE IF NOT EXISTS user(" +
                "username varchar(10) UNIQUE," +
                "password varchar(100)," +
                "lv int," +
                "expnow int," +
                "expmax int," +
                "gold int,"+
                "seed1 int,seed2 int,seed3 int,seed4 int,seed5 int,seed6 int,seed7 int,seed8 int,seed9 int,seed10 int,seed11 int,seed12 int,seed13 int,seed14 int,seed15 int,seed16 int," +
                "unlocked1 int,unlocked2 int,unlocked3 int,unlocked4 int,unlocked5 int,unlocked6 int,unlocked7 int,unlocked8 int,unlocked9 int,unlocked10 int,unlocked11 int,unlocked12 int," +
                "planted1 int,planted2 int,planted3 int,planted4 int,planted5 int,planted6 int,planted7 int,planted8 int,planted9 int,planted10 int,planted11 int,planted12 int," +
                "ts1 int,ts2 int,ts3 int,ts4 int,ts5 int,ts6 int,ts7 int,ts8 int,ts9 int,ts10 int,ts11 int,ts12 int" +
                ")";
            cmd.ExecuteNonQuery();
            cn.Close();//关闭连接
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)//是否显示密码
        {
            if (checkBox1.Checked == false)
            {
                textBox2.PasswordChar = '*';
            }
            else
            {
                textBox2.PasswordChar = new char();
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)//是否显示密码
        {
            if (checkBox2.Checked == false)
            {
                textBox4.PasswordChar = '*';
                textBox5.PasswordChar = '*';
            }
            else
            {
                textBox4.PasswordChar = new char();
                textBox5.PasswordChar = new char();
            }
        }

        private void button1_Click(object sender, EventArgs e)//登陆，调用user类的方法
        {
            int returncode=player.readdata(textBox1.Text, textBox2.Text);//读取玩家数据
            //1成功登陆，2找不到账号，3密码错误
            if (returncode==1)
            {
                textBox1.Text = "";//清楚信息
                textBox2.Text = "";
                EasyFarm newform = new EasyFarm();
                this.Hide();//隐藏旧窗体
                newform.ShowDialog();//展示新窗体
                newform.Dispose();//销毁老窗体
                this.Show();//重新展示旧窗体
            }
            else if(returncode==2)
            {
                MessageBox.Show("找不到账号");
            }
            else if(returncode==3)
            {
                MessageBox.Show("密码错误");
            }
        }

        private void button2_Click(object sender, EventArgs e)//前往注册界面
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];
        }

        private void button3_Click(object sender, EventArgs e)//完成注册
        {
            if (textBox3.Text == "")
                MessageBox.Show("账号不可为空！");
            else if (textBox4.Text == "")
                MessageBox.Show("密码不可为空！");
            else if (textBox5.Text == "")
                MessageBox.Show("确认密码不可为空！");
            else if (textBox4.Text != textBox5.Text)
                MessageBox.Show("两次输入的密码不同！");
            else//密码检查通过
            {
                //连接
                int result = player.initnewplayer(textBox3.Text, textBox4.Text);//初始化玩家并保存
                if (result==0)//重名的提示
                    MessageBox.Show("已有相同账号名的账号！");
                else//没有重名，可以注册！
                {
                    MessageBox.Show("注册成功！");
                    textBox1.Text = textBox3.Text;
                    textBox2.Text = textBox4.Text;
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    tabControl1.SelectedTab = tabControl1.TabPages[0];//返回页面
                }
            }
        }
    }
}
