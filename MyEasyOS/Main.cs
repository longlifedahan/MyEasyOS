using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

//功能

//多用户-注册+登录——享有不同的文件系统，创建不同的文件夹即可√
//快捷键
//帮助和提示

//1)√计算器——调用函数实现
//2)√时钟——主页面也有时钟(借用了别人的代码实现)
//3)√农场游戏——我的项目 
//4)√浏览器——使用控件实现
//5)√简易数据分析工具——我的项目
//10)√简单的C#语言编译器——可以支持if、while甚至是数组！！！只要可以返回结果均可哦——动态编译实现
//8)√图片浏览器——使用picturebox实现，不支持修改、放大，只有简单的查看
//11)√画图——只支持画线，但支持保存
//9)√媒体播放器——使用Media组件实现，网上找的资料

//6)简易文件系统——打开文件夹（√）；新建文件/文件夹（√|√）；删除文件/文件夹（√|√）执行文件（txt、db、cs√、jpg√、png√、mp3√、exe√、文件夹√）
//导入文件（√）

//7)文本编辑器——使用richtextbox实现，但增加打开、保存、另存为（text目录下）等额外功能
//12)一个数据库查询工具（仅针对sqlite）-（可以执行命令）——我的项目，支持打开、新建、查询数据库等功能

//一个控制台——执行计算、打开其余的功能
/*
指令：
	info 开发者信息 √
    time 返回当前时间√
    clock 时钟 √
    calc 计算器 √
    calc 表达式 计算 √
    farm 游戏 √
    farm 账号密码 直接登录√
    browser 浏览器√
    complier 编译器√
    data 数据分析√
    data 一串数据 数据分析√
    exit 退出√
    pic 图片浏览器√
    draw 画图√
    file 打开文件系统√
    media 媒体播放器√

    ls 列出目录和文件
    cd 进入下一个单级的目录 不支持多级进入
    help 帮助

    text 打开文本编辑器
    sql 打开数据库
*/
namespace MyEasyOS
{
    public partial class Main : Form
    {
        //长1420 宽720 分布 4x3+1 1420=40x5+305x4 720=30x4+200x3
        public Main()
        {
            InitializeComponent();
        }

        #region cmd_命令行工具
        private void 打开命令行工具ToolStripMenuItem_Click(object sender, EventArgs e)//打开命令行工具
        {
            Cmd newform = new Cmd();
            this.Hide();
            newform.ShowDialog();
            this.Show();
        }
        #endregion

        #region 打开浏览器
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            surfer newform = new surfer();
            this.Hide();
            newform.ShowDialog();
            this.Show();
        }
        #endregion

        #region 打开时钟
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            clock newform = new clock();
            this.Hide();
            newform.ShowDialog();
            this.Show();
        }
        #endregion

        #region 打开计算器
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            calc newform = new calc();
            this.Hide();
            newform.ShowDialog();
            this.Show();
        }
        #endregion

        #region 打开农场
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            gamelogin newform = new gamelogin();
            this.Hide();
            newform.ShowDialog();
            this.Show();
        }
        #endregion

        #region 图片浏览器
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            picviewer newform = new picviewer();
            this.Hide();
            newform.ShowDialog();
            this.Show();
        }
        #endregion

        #region 数据分析器
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            data newform = new data();
            this.Hide();
            newform.ShowDialog();
            this.Show();
        }
        #endregion

        #region 简单编译器
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            complier newform = new complier();
            this.Hide();
            newform.ShowDialog();
            this.Show();
        }
        #endregion

        #region 简单画图
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            paint newform = new paint();
            this.Hide();
            newform.ShowDialog();
            this.Show();
        }
        #endregion

        #region 文件系统
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            filesys newform = new filesys ();
            this.Hide();
            newform.ShowDialog();
            this.Show();
        }
        #endregion

        #region 文本编辑器
        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 媒体播放器
        private void pictureBox11_Click(object sender, EventArgs e)
        {
            mpr mprf = new mpr();
            this.Hide();
            mprf.ShowDialog();
            this.Show();
            mprf.Dispose();
        }
        #endregion

        #region 简易数据库
        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
    public static class common
    {
        public static string basedir = "";//基础目录
        public static string user = "";//当前用户
        public static string curdir = "";//当前目录
        public static string fullfile()//真实地址
        {
            return basedir + "\\" + user + "\\" + curdir;
        }
        public static string virtualfile()//虚拟地址
        {
            return user + "\\" + curdir;
        }
        public static string userfile()//用户真实地址
        {
            return basedir + "\\" + user + "\\";
        }
    }
}
