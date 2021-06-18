using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using Microsoft.VisualBasic;
using System.IO;
using System.Threading;

namespace 学生管理
{
    public partial class Form1 : Form
    {
        string fileName = "data.db";
        List<string> records = new List<string>();
        public Form1()
        {
            InitializeComponent();
            if (File.Exists(fileName) == false)
                File.Create(fileName);
            Thread.Sleep(20);
            SQLiteConnection cn = new SQLiteConnection("data source=" + fileName);//建立连接对象
            cn.Open();
            SQLiteCommand cmd = new SQLiteCommand(cn);
            cmd.CommandText = "CREATE TABLE IF NOT EXISTS students(id varchar(20) UNIQUE,name varchar(20),school varchar(20))";
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = "";
            if (textBox1.Text == "" || textBox1.Text == null)
                input = Interaction.InputBox("请输入sql语句", "请输入sql语句", "");
            else
                input = textBox1.Text;
            string fileName = "data.db";
            SQLiteConnection cn = new SQLiteConnection("data source=" + fileName);//建立连接对象
            SQLiteCommand cmd = new SQLiteCommand(cn);
            if (input.ToLower().Contains("insert") || input.ToLower().Contains("delete") || input.ToLower().Contains("update"))
            {
                records.Add(input);
                cn.Open();
                cmd.CommandText = input;
                try
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i != 0)
                    {
                        MessageBox.Show("成功！");
                    }
                    else
                    {
                        MessageBox.Show("失败！");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("失败：" + ex.Message);
                    cn.Close();
                }
                cn.Close();
            }
            else if (input.ToLower().Contains("select"))
            {
                records.Add(input);
                cn.Open();
                cmd.CommandText = input;
                try
                {
                    SQLiteDataReader sr = cmd.ExecuteReader();
                    if (sr.Read() == true)//可以查的到
                    {
                        sr.Close();
                        SQLiteDataReader sr2 = cmd.ExecuteReader();
                        BindingSource Bs = new BindingSource();
                        Bs.DataSource = sr2;
                        dataGridView1.DataSource = Bs;
                        sr2.Close();
                    }
                    else//查不到，什么也不干
                    {
                        sr.Close();
                        BindingSource Bs = new BindingSource();
                        dataGridView1.DataSource = Bs;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("失败：" + ex.Message);
                    cn.Close();
                }
            }
            else if(input=="addstudents")
            {
                cn.Open();
                string id = "";
                string name = "";
                string school = "";
                Random rd = new Random();
                for(int j=0;j<100;j++)
                {
                    id = rd.Next(0, 9999).ToString() + rd.Next(0, 9999).ToString();
                    int[] arrOld2 = new int[4] { 1, 2, 3, 4 };
                    string[] name1 = new string[] {"赵","刘","叶","姚","李","张","王","龙","孙","周" };
                    string[] name2 = new string[] { "无敌", "建国", "立业", "破天", "援朝", "开山", "强人", "傲天", "小平", "克强" };
                    name = name1[rd.Next(0, 10)] + name2[rd.Next(0, 10)];
                    string[] school1 = new string[] { "沙河", "深圳", "大汉", "广东", "家轩" };
                    string[] school2 = new string[] { "幼儿园", "小学", "初中", "高中", "大学", "研究所" };
                    school = school1[rd.Next(0, 5)] + school2[rd.Next(0, 6)];
                    cmd.CommandText = $"Insert into students values('{id}','{name}','{school}')";
                    try { cmd.ExecuteNonQuery(); } catch { }
                }
                cn.Close();
            }
            else
            {
                MessageBox.Show("暂时不支持非增删查该的语句！");
            }
        }

        int i = 0;
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                int max = records.Count;
                if (max == 0)
                    return;
                textBox1.Text = records[i];
                i--;
                if (i < 0)
                    i = max - 1;
            }
            else if (e.KeyCode == Keys.Enter)
                button1.PerformClick();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SQLiteConnection cn = new SQLiteConnection("data source=" + fileName);//建立连接对象
            SQLiteCommand cmd = new SQLiteCommand(cn);
            cn.Open();
            cmd.CommandText = "select count(*) from students";
            string a = cmd.ExecuteScalar().ToString();
            MessageBox.Show(a);
        }
    }
}
