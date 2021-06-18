using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace MyEasyOS
{
    public partial class paint : Form
    {
        public paint()
        {
            InitializeComponent();
        }
        int xbefore = -1;
        int ybefore = -1;
        int color = 1;
        int eraser = 0;//非橡皮擦
        int erasersize = 10;//橡皮擦大小
        int pensize = 1;//笔粗细
        int savex = 0;
        int savey = 0;

        #region 基础绘制和橡皮擦
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            label3.Text = $"x={e.X},y={e.Y}";
            Graphics g = panel1.CreateGraphics();
            if (e.Button == MouseButtons.Left)
            {
                if (eraser == 0)
                {
                    Pen mypen = new Pen(Brushes.Black, pensize);
                    if (color == 2)
                        mypen = new Pen(Brushes.Red, pensize);
                    else if (color == 3)
                        mypen = new Pen(Brushes.Green, pensize);
                    else if (color == 4)
                        mypen = new Pen(Brushes.Yellow, pensize);
                    else if (color == 5)
                        mypen = new Pen(Brushes.Purple, pensize);
                    else if (color == 6)
                        mypen = new Pen(Brushes.Blue, pensize);
                    if (xbefore != -1)
                        g.DrawLine(mypen, xbefore, ybefore, e.X, e.Y);
                    xbefore = e.X;
                    ybefore = e.Y;
                }
                else if (eraser == 1)
                {
                    g.FillEllipse(Brushes.White, e.X - erasersize / 2, e.Y - erasersize / 2, erasersize, erasersize);
                }
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            xbefore = -1;
            ybefore = -1;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            label4.Text = $"取坐标结果:({e.X}, {e.Y})";
            savex = e.X;
            savey = e.Y;
            if (eraser == 0)
            {
                Graphics g = panel1.CreateGraphics();
                Pen mypen = Pens.Black;
                if (color == 2)
                    mypen = Pens.Red;
                else if (color == 3)
                    mypen = Pens.Green;
                else if (color == 4)
                    mypen = Pens.Yellow;
                else if (color == 5)
                    mypen = Pens.Purple;
                else if (color == 6)
                    mypen = Pens.Blue;
                g.DrawEllipse(mypen, e.X, e.Y, 1, 1);
            }
            else if (eraser == 1)
            {
                Graphics g = panel1.CreateGraphics();
                g.FillEllipse(Brushes.White, e.X - erasersize / 2, e.Y - erasersize / 2, erasersize, erasersize);
            }
        }
        #endregion

        #region 保存纵断面截图

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveImageDialog = new SaveFileDialog();
            saveImageDialog.Title = "保存画图";
            saveImageDialog.DefaultExt = ".jpg";
            saveImageDialog.FileName = "画图结果";
            saveImageDialog.Filter = "jpg文件(*.jpg)|*.jpg";
            saveImageDialog.InitialDirectory = common.userfile() + "pic";

            DialogResult dr = saveImageDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                CaptureImage(saveImageDialog.FileName);
                MessageBox.Show("保存成功！");
            }

        }

        private void CaptureImage(string path)
        {
            try
            {
                //获得当前屏幕的大小
                Rectangle rect = new Rectangle();
                rect = Screen.GetWorkingArea(panel1);

                //创建一个以当前屏幕为模板的图象
                Graphics g1 = panel1.CreateGraphics();

                //创建以屏幕大小为标准的位图 
                Image MyImage = new Bitmap(1000, 500, g1);
                Graphics g2 = Graphics.FromImage(MyImage);

                //得到屏幕的DC
                IntPtr dc1 = g1.GetHdc();

                //得到Bitmap的DC 
                IntPtr dc2 = g2.GetHdc();

                //调用此API函数，实现屏幕捕获
                BitBlt(dc2, 0, 0, 1000, 5000, dc1, 0, 0, 13369376);

                //释放掉屏幕的DC
                g1.ReleaseHdc(dc1);

                //释放掉Bitmap的DC 
                g2.ReleaseHdc(dc2);

                //以JPG文件格式来保存
                MyImage.Save(path, ImageFormat.Jpeg);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message + " 保存图片失败！");
            }
        }

        //声明一个API函数
        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        private static extern bool BitBlt(
            IntPtr hdcDest, // 目标 DC的句柄
            int nXDest,
            int nYDest,
            int nWidth,
            int nHeight,
            IntPtr hdcSrc,  // 源DC的句柄
            int nXSrc,
            int nYSrc,
            System.Int32 dwRop  // 光栅的处理数值
            );
        #endregion

        #region 清理屏幕
        private void 清屏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel1.CreateGraphics().Clear(Color.White);
        }
        #endregion

        #region 设置笔的颜色
        private void 黑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            color = 1;
            label1.Text = "当前颜色：黑色";
        }

        private void 红ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            color = 2;
            label1.Text = "当前颜色：红色";
        }

        private void 绿ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            color = 3;
            label1.Text = "当前颜色：绿色";
        }

        private void 黄ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            color = 4;
            label1.Text = "当前颜色：黄色";
        }

        private void 紫ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            color = 5;
            label1.Text = "当前颜色：紫色";
        }

        private void 蓝ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            color = 6;
            label1.Text = "当前颜色：蓝色";
        }
        #endregion

        #region 画圆和矩形和文字
        //画圆空心
        private void 执行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text != "" && toolStripTextBox2.Text != "" && toolStripTextBox3.Text != "")//均非空
            {
                try
                {
                    int x = Convert.ToInt32(toolStripTextBox1.Text);
                    int y = Convert.ToInt32(toolStripTextBox2.Text);
                    int r = Convert.ToInt32(toolStripTextBox3.Text);
                    Graphics g = panel1.CreateGraphics();
                    Pen mypen = Pens.Black;
                    if (color == 2)
                        mypen = Pens.Red;
                    else if (color == 3)
                        mypen = Pens.Green;
                    else if (color == 4)
                        mypen = Pens.Yellow;
                    else if (color == 5)
                        mypen = Pens.Purple;
                    else if (color == 6)
                        mypen = Pens.Blue;
                    g.DrawEllipse(mypen, x - r / 2, y - r / 2, r, r);
                }
                catch
                {
                    MessageBox.Show("参数错误！");
                }
            }
        }
        //画矩形空心
        private void 执行ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (toolStripTextBox4.Text != "" && toolStripTextBox5.Text != "" && toolStripTextBox6.Text != "" && toolStripTextBox7.Text != "")//均非空
            {
                try
                {
                    int x = Convert.ToInt32(toolStripTextBox4.Text);
                    int y = Convert.ToInt32(toolStripTextBox5.Text);
                    int x1 = Convert.ToInt32(toolStripTextBox6.Text);
                    int y1 = Convert.ToInt32(toolStripTextBox7.Text);
                    Graphics g = panel1.CreateGraphics();
                    Pen mypen = Pens.Black;
                    if (color == 2)
                        mypen = Pens.Red;
                    else if (color == 3)
                        mypen = Pens.Green;
                    else if (color == 4)
                        mypen = Pens.Yellow;
                    else if (color == 5)
                        mypen = Pens.Purple;
                    else if (color == 6)
                        mypen = Pens.Blue;
                    g.DrawRectangle(mypen, x, y, x1, y1);
                }
                catch
                {
                    MessageBox.Show("参数错误！");
                }
            }
        }
        //画圆实心
        private void 执行填充ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text != "" && toolStripTextBox2.Text != "" && toolStripTextBox3.Text != "")//均非空
            {
                try
                {
                    int x = Convert.ToInt32(toolStripTextBox1.Text);
                    int y = Convert.ToInt32(toolStripTextBox2.Text);
                    int r = Convert.ToInt32(toolStripTextBox3.Text);
                    Graphics g = panel1.CreateGraphics();
                    Brush mybursh = Brushes.Black;
                    if (color == 2)
                        mybursh = Brushes.Red;
                    else if (color == 3)
                        mybursh = Brushes.Green;
                    else if (color == 4)
                        mybursh = Brushes.Yellow;
                    else if (color == 5)
                        mybursh = Brushes.Purple;
                    else if (color == 6)
                        mybursh = Brushes.Blue;
                    g.FillEllipse(mybursh, x - r / 2, y - r / 2, r, r);
                }
                catch
                {
                    MessageBox.Show("参数错误！");
                }
            }
        }
        //画矩形实心
        private void 执行填充ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (toolStripTextBox4.Text != "" && toolStripTextBox5.Text != "" && toolStripTextBox6.Text != "" && toolStripTextBox7.Text != "")//均非空
            {
                try
                {
                    int x = Convert.ToInt32(toolStripTextBox4.Text);
                    int y = Convert.ToInt32(toolStripTextBox5.Text);
                    int x1 = Convert.ToInt32(toolStripTextBox6.Text);
                    int y1 = Convert.ToInt32(toolStripTextBox7.Text);
                    Graphics g = panel1.CreateGraphics();
                    Brush mybursh = Brushes.Black;
                    if (color == 2)
                        mybursh = Brushes.Red;
                    else if (color == 3)
                        mybursh = Brushes.Green;
                    else if (color == 4)
                        mybursh = Brushes.Yellow;
                    else if (color == 5)
                        mybursh = Brushes.Purple;
                    else if (color == 6)
                        mybursh = Brushes.Blue;
                    g.FillRectangle(mybursh, x, y, x1, y1);
                }
                catch
                {
                    MessageBox.Show("参数错误！");
                }
            }
        }
        //写字
        private void 执行ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (toolStripTextBox8.Text != "" && toolStripTextBox9.Text != "" && toolStripTextBox10.Text != "")//均非空
            {
                try
                {
                    int x = Convert.ToInt32(toolStripTextBox9.Text);
                    int y = Convert.ToInt32(toolStripTextBox10.Text);
                    Graphics g = panel1.CreateGraphics();
                    Font myfont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    g.DrawString(toolStripTextBox8.Text, myfont, Brushes.Black, x, y);
                }
                catch
                {
                    MessageBox.Show("参数错误！");
                }
            }
        }
        #endregion

        #region 橡皮擦
        private void 使用ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            eraser = 1;//橡皮擦
            panel1.Cursor = Cursors.No;
        }

        private void 停止ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            eraser = 0;//非橡皮擦
            panel1.Cursor = Cursors.Cross;
        }

        #region 设置橡皮擦大小
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            erasersize = 2;
            label1.Text = "橡皮擦大小：2";
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            erasersize = 4;
            label1.Text = "橡皮擦大小：4";
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            erasersize = 6;
            label1.Text = "橡皮擦大小：6";
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            erasersize = 8;
            label1.Text = "橡皮擦大小：8";
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            erasersize = 10;
            label1.Text = "橡皮擦大小：10";
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            erasersize = 12;
            label1.Text = "橡皮擦大小：12";
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            erasersize = 14;
            label1.Text = "橡皮擦大小：14";
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            erasersize = 16;
            label1.Text = "橡皮擦大小：16";
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            erasersize = 18;
            label1.Text = "橡皮擦大小：18";
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            erasersize = 20;
            label1.Text = "橡皮擦大小：20";
        }
        #endregion

        #endregion

        #region 设置笔粗细
        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            pensize = 1;
            label5.Text = "笔粗细：1";
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            pensize = 2;
            label5.Text = "笔粗细：2";
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            pensize = 3;
            label5.Text = "笔粗细：3";
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            pensize = 4;
            label5.Text = "笔粗细：4";
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            pensize = 5;
            label5.Text = "笔粗细：5";
        }
        #endregion

        #region 画线
        private void 执行ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (toolStripTextBox11.Text != "" && toolStripTextBox12.Text != "" && toolStripTextBox13.Text != "" && toolStripTextBox14.Text != "")//均非空
            {
                try
                {
                    int x1 = Convert.ToInt32(toolStripTextBox11.Text);
                    int y1 = Convert.ToInt32(toolStripTextBox12.Text);
                    int x2 = Convert.ToInt32(toolStripTextBox13.Text);
                    int y2 = Convert.ToInt32(toolStripTextBox14.Text);
                    Graphics g = panel1.CreateGraphics();
                    Pen mypen = new Pen(Brushes.Black, pensize);
                    if (color == 2)
                        mypen = new Pen(Brushes.Red, pensize);
                    else if (color == 3)
                        mypen = new Pen(Brushes.Green, pensize);
                    else if (color == 4)
                        mypen = new Pen(Brushes.Yellow, pensize);
                    else if (color == 5)
                        mypen = new Pen(Brushes.Purple, pensize);
                    else if (color == 6)
                        mypen = new Pen(Brushes.Blue, pensize);
                    g.DrawLine(mypen, x1, y1, x2, y2);
                }
                catch
                {
                    MessageBox.Show("参数错误！");
                }
            }
        }

        private void 取坐标结果存入点1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripTextBox11.Text = savex.ToString();
            toolStripTextBox12.Text = savey.ToString();
        }

        private void 取坐标结果存入点2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripTextBox13.Text = savex.ToString();
            toolStripTextBox14.Text = savey.ToString();
        }
        #endregion

        #region 打开背景
        private void 打开背景ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofg = new OpenFileDialog();
            ofg.Filter = "jpg文件(*.jpg)|*.jpg|png文件(*.png) | *.png";
            ofg.InitialDirectory = common.userfile() + "pic";
            if (ofg.ShowDialog() == DialogResult.OK)
            {
                panel1.BackgroundImage = Image.FromFile(ofg.FileName);
            }
        }
        #endregion
    }
}
