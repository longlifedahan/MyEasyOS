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
    //摘抄自https://www.cnblogs.com/sosoft/p/3520091.html
    public partial class clock : Form
    {
        DateTime date = DateTime.Now;
        public clock()
        {
            InitializeComponent();
        }

        private void clock_Load(object sender, EventArgs e)
        {
            date = DateTime.Now;
        }

        private void clock_Paint(object sender, PaintEventArgs e)
        {
            Font font = new Font("Times New Roman", 20);
            Graphics g = CreateGraphics();
            g.DrawString(date.ToString(), font, Brushes.Firebrick, 10, 330);
            g.DrawString(date.DayOfWeek.ToString(), font, Brushes.Red, 250, 330);
            DrawDial(g);
            DrawSecondPointer(g);
            DrawMinutePointer(g);
            DrawHourPointer(g);
        }

        //刷新时间
        private void timer1_Tick(object sender, EventArgs e)
        {
            date = DateTime.Now;
            Invalidate();
        }
        //画钟表
        //表盘部分
        Point GetPosition(int s, Point center, double radius)//定位
        {
            Point p = new Point();
            double x = center.X + radius * Math.Sin(Math.PI / 30 * s);
            double y = center.Y - radius * Math.Cos(Math.PI / 30 * s);
            p.X = (int)x;
            p.Y = (int)y;
            return p;
        }
        //外圆及刻度
        void DrawDial(Graphics g)
        {
            int n;
            Rectangle rect = new Rectangle(40, 10, 300, 300);
            //g.FillEllipse(Brushes.White, 40, 10, 300, 300);
            g.DrawEllipse(new Pen(Color.Black, 3), rect);
            Point p1, p2;
            Point center = new Point(190, 160);
            for (n = 0; n < 60; n++)
            {
                p1 = GetPosition(n, center, 150);
                if (n % 5 == 0)
                {
                    p2 = GetPosition(n, center, 130);
                    g.DrawLine(new Pen(Color.Black, 2), p1, p2);
                }
                else
                {
                    p2 = GetPosition(n, center, 140);
                    g.DrawLine(Pens.Red, p1, p2);
                }
            }
            Font font = new Font("Times New Roman", 20);
            n = 0;
            p1 = GetPosition(n, center, 130);
            g.DrawString("XII", font, Brushes.Black, p1.X - 25, p1.Y);
            n += 15;
            p1 = GetPosition(n, center, 130);
            g.DrawString("III", font, Brushes.Black, p1.X - 35, p1.Y - 15);
            n += 15;
            p1 = GetPosition(n, center, 130);
            g.DrawString("VI", font, Brushes.Black, p1.X - 20, p1.Y - 30);
            n += 15;
            p1 = GetPosition(n, center, 130);
            g.DrawString("IX", font, Brushes.Black, p1.X, p1.Y - 15);
        }
        //秒针部分
        void DrawSecondPointer(Graphics g)
        {
            Point center = new Point(190, 160);
            Point p;
            p = GetPosition(date.Second, center, 130);
            g.DrawLine(Pens.Red, center, p);
            g.FillEllipse(Brushes.Red, new Rectangle(p.X - 2, p.Y - 2, 4, 4));

        }
        //分针部分
        void DrawMinutePointer(Graphics g)
        {
            Point center = new Point(190, 160);
            Point p;
            p = GetPosition(date.Minute, center, 120);
            g.DrawLine(Pens.Blue, center, p);
            //g.FillEllipse(Brushes.Blue, new Rectangle(p.X - 4, p.Y - 4, 8, 8));
        }
        //时针部分
        Point GetHourPosition(Point center, double radius)
        {
            Point p = new Point();
            int h = date.Hour;
            int m = date.Minute;
            double t = Math.PI / 6 * h + Math.PI / 360 * m;
            double x = center.X + radius * Math.Sin(t);
            double y = center.Y - radius * Math.Cos(t);
            p.X = (int)x;
            p.Y = (int)y;
            return p;
        }
        void DrawHourPointer(Graphics g)
        {
            Point center = new Point(190, 160);
            Point p = GetHourPosition(center, 100);
            g.DrawLine(new Pen(Brushes.Black, 2), center, p);
            //去指针圆尖 http://www.cnblogs.com/sosoft/
            // g.FillEllipse(Brushes.Black,
            //              new Rectangle(p.X - 6, p.Y - 6, 12, 12));
            g.FillEllipse(Brushes.YellowGreen,
            new Rectangle(center.X - 6, center.Y - 6, 12, 12));
        }
    }
}
