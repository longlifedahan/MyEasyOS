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
    public partial class login : Form
    {       
        public login()
        {
            InitializeComponent();
            //建立数据库
            var fileName = "user.db";
            if (File.Exists(fileName) == false)//不存在用户文件
                SQLiteConnection.CreateFile(fileName);//创建数据库
            SQLiteConnection cn = new SQLiteConnection("data source=" + fileName);//建立连接对象
            SQLiteCommand cmd = new SQLiteCommand();
            //当没有用户表时建立用户表
            cn.Open();//连接
            cmd.Connection = cn;
            cmd.CommandText = "CREATE TABLE IF NOT EXISTS user(username varchar(100) UNIQUE,password varchar(20))";
            cmd.ExecuteNonQuery();
            cn.Close();//关闭连接
        }

        private void button1_Click(object sender, EventArgs e)//登陆
        {
            //连接数据库
            var fileName = "user.db";
            SQLiteConnection cn = new SQLiteConnection("data source=" + fileName);//建立连接对象
            SQLiteCommand cmd = new SQLiteCommand();
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandText = $"SELECT password FROM user where username='{textBox1.Text}'";
            var result=cmd.ExecuteScalar();
            cn.Close();
            if (result == null)//返回为空，每用户
                MessageBox.Show("找不到相应的用户！");
            else
            {
                if((string)result==textBox2.Text)//登陆成功
                {
                    common.basedir = Directory.GetCurrentDirectory();
                    common.user = textBox1.Text;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    Main newform=new Main();//打开主界面
                    this.Hide();
                    newform.ShowDialog();
                    this.Show();
                }
                else//密码错误
                    MessageBox.Show("密码错误");
            }

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
            else//检查通过
            {
                //连接数据库
                var fileName = "user.db";
                SQLiteConnection cn = new SQLiteConnection("data source=" + fileName);//建立连接对象
                SQLiteCommand cmd = new SQLiteCommand();
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = $"SELECT username FROM user WHERE username='{textBox3.Text}'";
                var result = cmd.ExecuteScalar();
                cn.Close();
                if (result!=null)//已有同名账号
                    MessageBox.Show("已有相同账号名的账号！");
                else//可以注册
                {
                    //创建数据库文件
                    cmd.CommandText = $"INSERT INTO user VALUES('{textBox3.Text}','{textBox4.Text}')";
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("注册成功！");
                    //创建系统目录
                    Directory.CreateDirectory(textBox3.Text);
                    Directory.CreateDirectory(textBox3.Text+"\\text");
                    Directory.CreateDirectory(textBox3.Text + "\\pic");
                    Directory.CreateDirectory(textBox3.Text + "\\media");
                    Directory.CreateDirectory(textBox3.Text + "\\cs");
                    Directory.CreateDirectory(textBox3.Text + "\\db");
                    //其余处理
                    textBox1.Text = textBox3.Text;
                    textBox2.Text = textBox4.Text;
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    tabControl1.SelectedTab = tabControl1.TabPages[0];//返回页面
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)//是否显示密码
        {
            if (checkBox1.Checked == false)
                textBox2.PasswordChar = '*';
            else
                textBox2.PasswordChar = new char();
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

        private void button2_Click(object sender, EventArgs e)//前往注册界面
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];
        }
    }
}
