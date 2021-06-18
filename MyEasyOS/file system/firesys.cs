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
using System.Diagnostics;
//编写基于winform的简单的文件浏览器程序：
//窗口分左右结构，包含菜单、工具栏、树形视图和列表；
//展示c:盘及其下所有文件夹，点击左边树形视图中的文件夹，右侧列表可显示该文件夹中的子文件夹和文件；
//对于exe文件，可以双击运行；对于txt文件，可以通过记事本(notepad.exe)打开；其他类型的文件不做要求。


namespace MyEasyOS
{
    public partial class filesys : Form
    {

        string file = common.userfile();
        string curentfile = "";
        string curdir = "";
        public filesys()
        {
            InitializeComponent();
            //取文件夹功能
            var dirs = Directory.GetDirectories(file, "*");//获得目录下所有文件夹（目录）
            foreach (var dir in dirs)//一一处理
            {
                treeView1.Nodes.Add(dir.ToString().Substring(common.userfile().Length));
            }
            //取文件功能  
            var files = Directory.GetFiles(file, "*");//获得目录下所有文件
            foreach (var file in files)//一一处理
            {
                treeView1.Nodes.Add(file.ToString().Substring(common.userfile().Length));
            }
        }

        #region 常规操作
        //选中提取内容
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(treeView1.SelectedNode.ToString().Substring(9).Trim().Contains("."))
            {
                curdir = "";
                excuate(common.userfile() + treeView1.SelectedNode.ToString().Substring(9).Trim());
            }
            else
            {
                curentfile = common.userfile() + treeView1.SelectedNode.ToString().Substring(9).Trim();
                curdir = treeView1.SelectedNode.ToString().Substring(9).Trim();
                listBox1.Items.Clear();
                try
                {
                    var dirs = Directory.GetDirectories(curentfile, "*");//获得目录下所有文件夹（目录）
                    foreach (var dir in dirs)//一一处理
                    {
                        listBox1.Items.Add(dir.ToString().Substring(curentfile.Length + 1));//+1为斜杠
                    }//取文件夹功能
                    listBox1.Items.Add("————————————————————————");
                    var files = Directory.GetFiles(curentfile, "*");//获得目录下所有文件
                    foreach (var file in files)//一一处理
                    {
                        listBox1.Items.Add(file.ToString().Substring(curentfile.Length + 1));
                    }//取文件功能
                }
                catch { }
            }
        }

        //执行文件
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)//没选
            {
                MessageBox.Show("未选中文件");
                return;
            }
            else
            {
                string filename = "";
                filename += common.userfile();
                filename += curdir;
                filename += "\\";
                filename += listBox1.Items[listBox1.SelectedIndex].ToString();
                excuate(filename);//执行文件              
            }
        }

        //打开目录
        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("未选中");
                return;
            }
            else
            {
                if (treeView1.SelectedNode.Nodes.Count == 0)
                {
                    curentfile = common.userfile() + treeView1.SelectedNode.ToString().Substring(9).Trim();
                    listBox1.Items.Clear();
                    try
                    {
                        //取文件夹功能
                        var dirs = Directory.GetDirectories(curentfile, "*");//获得目录下所有文件夹（目录）
                        foreach (var dir in dirs)//一一处理
                        {
                            listBox1.Items.Add(dir.ToString().Substring(curentfile.Length + 1));
                        }
                        listBox1.Items.Add("————————————————————————");
                        //取文件功能
                        var files = Directory.GetFiles(curentfile, "*");//获得目录下所有文件
                        foreach (var file in files)//一一处理
                        {
                            listBox1.Items.Add(file.ToString().Substring(curentfile.Length + 1));
                        }
                    }
                    catch { }
                    try
                    {
                        //新增节点
                        var dirs = Directory.GetDirectories(curentfile, "*");//获得目录下所有文件夹（目录）
                        foreach (var dir in dirs)//一一处理
                        {
                            treeView1.SelectedNode.Nodes.Add(dir.ToString().Substring(common.userfile().Length));
                        }
                    }
                    catch { }
                }
            }
        }
        #endregion

        //执行文件
        private void excuate(string filename)
        {
            //可以打开.txt;.pic;.png;.mp3;.cs;.exe

            //打开.txt，暂时使用notepad，应更换为自己的
            if (filename.Contains(".txt"))
            {
                try
                {
                    Process.Start("notepad.exe", filename);
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
            //打开.exe√
            else if (filename.Contains(".exe"))
            {
                Process myProcess = new Process();
                try
                {
                    myProcess.StartInfo.UseShellExecute = false;
                    myProcess.StartInfo.FileName = filename;
                    myProcess.StartInfo.CreateNoWindow = false;
                    myProcess.Start();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
            //打开.jpg或.png√
            else if (filename.Contains(".jpg") || filename.Contains(".png"))
            {
                picviewer pv = new picviewer(filename);
                pv.Show();
            }
            //打开.cs√
            else if (filename.Contains(".cs"))
            {
                complier cm = new complier(filename);
                cm.Show();
            }
            //打开.mp3或.mp4或.wav√
            else if (filename.Contains(".mp3") || filename.Contains(".mp4") || filename.Contains(".wav"))
            {
                mpr mprf = new mpr(filename);
                this.Hide();
                mprf.ShowDialog();
                this.Show();
                mprf.Dispose();
            }
            //打开.db
            else if (filename.Contains(".db"))
            {

            }
            //文件夹
            else if(!filename.Contains("."))
            {
                if (treeView1.SelectedNode.Nodes.Count == 0)
                {
                    curentfile = common.userfile() + treeView1.SelectedNode.ToString().Substring(9).Trim();
                    listBox1.Items.Clear();
                    try
                    {
                        //取文件夹功能
                        var dirs = Directory.GetDirectories(curentfile, "*");//获得目录下所有文件夹（目录）
                        foreach (var dir in dirs)//一一处理
                        {
                            listBox1.Items.Add(dir.ToString().Substring(curentfile.Length + 1));
                        }
                        listBox1.Items.Add("————————————————————————");
                        //取文件功能
                        var files = Directory.GetFiles(curentfile, "*");//获得目录下所有文件
                        foreach (var file in files)//一一处理
                        {
                            listBox1.Items.Add(file.ToString().Substring(curentfile.Length + 1));
                        }
                    }
                    catch { }
                    try
                    {
                        //新增节点
                        var dirs = Directory.GetDirectories(curentfile, "*");//获得目录下所有文件夹（目录）
                        foreach (var dir in dirs)//一一处理
                        {
                            treeView1.SelectedNode.Nodes.Add(dir.ToString().Substring(common.userfile().Length));
                        }
                    }
                    catch { }
                }
            }
            //其余的不支持
            else
            {
                MessageBox.Show("不支持打开该文件");
                return;
            }
        }

        #region 重要操作

        private void 新建文件夹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfg = new SaveFileDialog();
            sfg.InitialDirectory = common.userfile()+curdir;
            sfg.Title = "请选择文件夹名称和路径";
            if(sfg.ShowDialog()==DialogResult.OK)
            {
                Directory.CreateDirectory(sfg.FileName);
            }
            //刷新
            filesys newsys = new filesys();
            this.Hide();
            newsys.ShowDialog();
            this.Close();
        }

        private void 删除文件夹ToolStripMenuItem_Click(object sender, EventArgs e)
        {     
            if(curdir=="")
            {
                MessageBox.Show("未选中文件夹！");
                return;
            }
            Directory.Delete(common.userfile()+curdir,true);
            //刷新
            filesys newsys = new filesys();
            this.Hide();
            newsys.ShowDialog();
            this.Close();
        }

        private void 新建文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfg = new SaveFileDialog();
            sfg.InitialDirectory = common.userfile() + curdir;
            sfg.Title = "请选择文件名称（请带上后缀）和路径";
            if (sfg.ShowDialog() == DialogResult.OK)
            {
                File.Create(sfg.FileName).Dispose();
            }
            //刷新
            filesys newsys = new filesys();
            this.Hide();
            newsys.ShowDialog();
            this.Close();
        }

        private void 删除文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((curdir !=""&&listBox1.SelectedIndex!=-1)||curdir=="")
            {
                //curdir==""文件夹在树的根目录
                if(curdir=="")
                {
                    File.Delete(common.userfile() + treeView1.SelectedNode.ToString().Substring(9).Trim());
                    //刷新
                    filesys newsys = new filesys();
                    this.Hide();
                    newsys.ShowDialog();
                    this.Close();
                }
                //curdir !=""&&listBox1.SelectedIndex==-1 非根目录
                if(curdir != "" && listBox1.SelectedIndex != -1)
                {
                    File.Delete(common.userfile() + curdir+"\\"+listBox1.Items[listBox1.SelectedIndex]);
                    //刷新
                    filesys newsys = new filesys();
                    this.Hide();
                    newsys.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("未选中文件！");
                return;
            }

        }

        private void 拷贝文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofg = new OpenFileDialog();
            ofg.Title = "选择拷贝的文件";
            ofg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);//桌面
            if (ofg.ShowDialog()==DialogResult.OK)
            {
                string[] spilt = ofg.FileName.Split('\\');
                File.Copy(ofg.FileName, common.userfile() + curdir+"\\"+spilt[spilt.Length-1]);
                //刷新
                filesys newsys = new filesys();
                this.Hide();
                newsys.ShowDialog();
                this.Close();
            }
        }

        private void 拷贝文件自内部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofg = new OpenFileDialog();
            ofg.Title = "选择拷贝的文件";
            ofg.InitialDirectory = common.userfile();
            if (ofg.ShowDialog() == DialogResult.OK)
            {
                string[] spilt = ofg.FileName.Split('\\');
                File.Copy(ofg.FileName, common.userfile() + curdir + "\\" + spilt[spilt.Length - 1]);
                //刷新
                filesys newsys = new filesys();
                this.Hide();
                newsys.ShowDialog();
                this.Close();
            }
        }

        #endregion

        #region 快捷键
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            新建文件夹ToolStripMenuItem_Click(new object(), new EventArgs());
        }

        private void 删除文件夹ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            删除文件夹ToolStripMenuItem_Click(new object(), new EventArgs());
        }

        private void 新建文件ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            新建文件ToolStripMenuItem_Click(new object(), new EventArgs());
        }

        private void 删除文件ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            删除文件ToolStripMenuItem_Click(new object(), new EventArgs());
        }

        private void 拷贝文件从外部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            拷贝文件ToolStripMenuItem_Click(new object(), new EventArgs());
        }

        private void 拷贝文件从内部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            拷贝文件自内部ToolStripMenuItem_Click(new object(), new EventArgs());
        }
        #endregion
    }
}
