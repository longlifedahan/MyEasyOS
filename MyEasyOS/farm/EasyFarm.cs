using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyEasyOS
{
    public partial class EasyFarm : Form
    {
        public PictureBox[] groundlist = new PictureBox[13];//图片表
        public Label[] seednumlist = new Label[17];//种子数量表
        public Label[] timelist = new Label[13];//时间表
        public Label[] namelist = new Label[13];//名称表
        public PictureBox[] seedpiclist = new PictureBox[17];//种子图片表
        private int selectedseed = 0;//0表示未选择，1-16表示16种种子
        private int openground = 0;//已解锁土地
        private int[] opencost = new int[13] { 0, 0, 100, 300, 1000, 3000, 10000, 30000,100000, 200000,300000,500000,0 };//解锁土地消费
        private bool kill = false;//铲除模式
        private bool plant = false;//种植模式
        private bool voice = true;//音效

        SoundPlayer bgm = new SoundPlayer(Properties.Resources.backgrond);
        SoundPlayer plantm = new SoundPlayer(Properties.Resources.plant);
        SoundPlayer digm = new SoundPlayer(Properties.Resources.dig);
        SoundPlayer finishm = new SoundPlayer(Properties.Resources.finish);

        public EasyFarm()
        {
            InitializeComponent();//初始化组件
            initgroundlist();//初始化图片列表，便于管理
            initseednumlist();//初始化种子数量表，便于管理
            inittimelist();//初始化时间表，便于管理
            initnamelist();//初始化名称表，便于管理
            initseedpiclist();//初始化种子图片表，便于管理
            seedlist.initseeds();//初始化种子数据
            username.Text = player.username;
            level.Text = player.lv.ToString();
            expnow.Text = player.expnow.ToString();
            expmax.Text = player.expmax.ToString();
            gold.Text = player.gold.ToString();
            for (int i = 1; i <= 16; i++)//种子数
            {
                seednumlist[i].Text = player.seeds[i].ToString();
            }
            for(int i=1;i<=12;i++)//大地是否解锁
            {
                setgroundpic(i, (player.unlocked[i] == 1) ? 0 : -1);
                if (player.unlocked[i] == 1)
                    openground++;//增加了一块开辟的土地
            }
            for (int i = 1; i <= 12; i++)//planted 每块土地的种植情况，0为未种植，1-16位种植的编号
            {
                if (player.planted[i] > 0)//种植了改成幼苗状态
                {
                    setgroundpic(i, 17);
                    namelist[i].Text = seedlist.seeds[player.planted[i]].name;
                }
            }
            for (int i = 1; i <= 12; i++)//timestart 每块地开始种植的时间(当前时间距离1970年1月1日的秒数）
            {
                if(player.unlocked[i]==1&&player.planted[i]>0)//地已经解锁，并且种植
                {
                    timelist[i].Text = (player.timestart[i]+seedlist.seeds[player.planted[i]].time-calctime() ).ToString();//成熟时间
                    if (Convert.ToInt32(timelist[i].Text)<= 0)//已成熟
                    {
                        timelist[i].Text = "可收割";
                        setgroundpic(i, player.planted[i]);
                    }
                    else if (Convert.ToInt32(timelist[i].Text) <= (int)(seedlist.seeds[player.planted[i]].time * 0.33))//快熟了
                    {
                        setgroundpic(i, 19);
                    }
                    else if (Convert.ToInt32(timelist[i].Text) <= (int)(seedlist.seeds[player.planted[i]].time * 0.66))//中等
                    {
                        setgroundpic(i, 18);
                    }
                }
            }
            settooltip();//设置提示
        }

        //种子生长
        private void timer1_Tick(object sender, EventArgs e)//循环是所有地的时间减一
        {
            for(int i=1;i<=12;i++)
            {
                if(player.unlocked[i]==1)//某块地已经解锁
                {
                    if(player.planted[i]>0)//某块地已经种植
                    {
                        if(timelist[i].Text!="可收割")//没有成熟
                        {
                            timelist[i].Text = (Convert.ToInt32(timelist[i].Text)-1).ToString();//时间减少一
                            if(Convert.ToInt32(timelist[i].Text)<=0)//已成熟
                            {
                                timelist[i].Text = "可收割";
                                setgroundpic(i, player.planted[i]);
                            }
                            else if(Convert.ToInt32(timelist[i].Text)==(int)(seedlist.seeds[player.planted[i]].time*0.66))//中等
                            {
                                setgroundpic(i, 18);
                            }
                            else if (Convert.ToInt32(timelist[i].Text) == (int)(seedlist.seeds[player.planted[i]].time * 0.33))//快熟了
                            {
                                setgroundpic(i, 19);
                            }
                        }
                    }
                }
            }
        }

        #region 购买
        private void buy1_Click(object sender, EventArgs e)
        {
            buy(1);
        }

        private void buy2_Click(object sender, EventArgs e)
        {
            buy(2);
        }

        private void buy3_Click(object sender, EventArgs e)
        {
            buy(3);
        }

        private void buy4_Click(object sender, EventArgs e)
        {
            buy(4);
        }

        private void buy5_Click(object sender, EventArgs e)
        {
            buy(5);
        }

        private void buy6_Click(object sender, EventArgs e)
        {
            buy(6);
        }

        private void buy7_Click(object sender, EventArgs e)
        {
            buy(7);
        }

        private void buy8_Click(object sender, EventArgs e)
        {
            buy(8);
        }

        private void buy9_Click(object sender, EventArgs e)
        {
            buy(9);
        }

        private void buy10_Click(object sender, EventArgs e)
        {
            buy(10);
        }

        private void buy11_Click(object sender, EventArgs e)
        {
            buy(11);
        }

        private void buy12_Click(object sender, EventArgs e)
        {
            buy(12);
        }

        private void buy13_Click(object sender, EventArgs e)
        {
            buy(13);
        }

        private void buy14_Click(object sender, EventArgs e)
        {
            buy(14);
        }

        private void buy15_Click(object sender, EventArgs e)
        {
            buy(15);
        }

        private void buy16_Click(object sender, EventArgs e)
        {
            buy(16);
        }

        public void buy(int id)//购买
        {
            if(player.gold>=seedlist.seeds[id].price)
            {
                player.gold -= seedlist.seeds[id].price;
                gold.Text = player.gold.ToString();
                player.seeds[id] += 1;
                seednumlist[id].Text = player.seeds[id].ToString();
                player.savedata();
            }
            else
            {
                MessageBox.Show("金币不足！");
            }
        }
        #endregion

        #region 常用函数

        //计算当前时间距离1970年1月1日的秒数
        //种子种植时间以这个作为基准，方便计算
        public int calctime()
        {
            TimeSpan timeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1));
            return (int)timeSpan.TotalSeconds;
        }

        //初始化土地列表，便于管理
        public void initgroundlist()
        {
            groundlist[1] = pictureBox1;
            groundlist[2] = pictureBox2;
            groundlist[3] = pictureBox3;
            groundlist[4] = pictureBox4;
            groundlist[5] = pictureBox5;
            groundlist[6] = pictureBox6;
            groundlist[7] = pictureBox7;
            groundlist[8] = pictureBox8;
            groundlist[9] = pictureBox9;
            groundlist[10] = pictureBox10;
            groundlist[11] = pictureBox11;
            groundlist[12] = pictureBox12;
        }

        //初始化种子数量列表，便于管理
        public void initseednumlist()
        {
            seednumlist[1] = num1;
            seednumlist[2] = num2;
            seednumlist[3] = num3;
            seednumlist[4] = num4;
            seednumlist[5] = num5;
            seednumlist[6] = num6;
            seednumlist[7] = num7;
            seednumlist[8] = num8;
            seednumlist[9] = num9;
            seednumlist[10] = num10;
            seednumlist[11] = num11;
            seednumlist[12] = num12;
            seednumlist[13] = num13;
            seednumlist[14] = num14;
            seednumlist[15] = num15;
            seednumlist[16] = num16;
        }

        //初始化时间列表，便于管理
        public void inittimelist()
        {
            timelist[1] = time1;
            timelist[2] = time2;
            timelist[3] = time3;
            timelist[4] = time4;
            timelist[5] = time5;
            timelist[6] = time6;
            timelist[7] = time7;
            timelist[8] = time8;
            timelist[9] = time9;
            timelist[10] = time10;
            timelist[11] = time11;
            timelist[12] = time12;
        }

        //初始化名称列表，便于管理
        public void initnamelist()
        {
            namelist[1] = name1;
            namelist[2] = name2;
            namelist[3] = name3;
            namelist[4] = name4;
            namelist[5] = name5;
            namelist[6] = name6;
            namelist[7] = name7;
            namelist[8] = name8;
            namelist[9] = name9;
            namelist[10] = name10;
            namelist[11] = name11;
            namelist[12] = name12;
        }

        //初始化种子图片列表，便于管理
        public void initseedpiclist()
        {
            seedpiclist[1] = pictureBox13;
            seedpiclist[2] = pictureBox14;
            seedpiclist[3] = pictureBox15;
            seedpiclist[4] = pictureBox16;
            seedpiclist[8] = pictureBox17;
            seedpiclist[7] = pictureBox18;
            seedpiclist[6] = pictureBox19;
            seedpiclist[5] = pictureBox20;
            seedpiclist[12] = pictureBox21;
            seedpiclist[11] = pictureBox22;
            seedpiclist[10] = pictureBox23;
            seedpiclist[9] = pictureBox24;
            seedpiclist[16] = pictureBox25;
            seedpiclist[15] = pictureBox26;
            seedpiclist[14] = pictureBox27;
            seedpiclist[13] = pictureBox28;
        }

        //设置土地列表的图片
        //grnid为土地列表
        //picid=-1，锁；0，空的土地；1-16为16种种子（成熟）,17为幼苗，18中等成熟，19大成熟
        public void setgroundpic(int grnid,int picid)
        {
            if(picid==-1)
            {
                groundlist[grnid].BackgroundImage = Properties.Resources.LOCK;
            }
            else if(picid==0)
            {
                groundlist[grnid].BackgroundImage = Properties.Resources.GROUND;
            }
            else//反射机制得到图片
            {
                groundlist[grnid].BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("_"+picid.ToString(), Properties.Resources.Culture);
            }
        }

        //开辟新的土地
        private void button4_Click(object sender, EventArgs e)
        {
            if(openground>=12)
            {
                MessageBox.Show("你已经解锁了所有土地！");
            }
            else
            {
                MessageBox.Show($"解锁第{openground + 1}块土地要{opencost[openground]}元");
                if (player.gold<opencost[openground])//钱不够
                {
                    MessageBox.Show("你的金币不足，解锁失败！");
                }
                else
                {
                    MessageBox.Show("你的金币足够，解锁成功！");
                    player.gold -= opencost[openground];//花钱
                    if (player.gold == 0)
                    {
                        player.gold += 10;
                        MessageBox.Show("获得破产补助——10元！");
                    }
                    gold.Text = player.gold.ToString();
                    player.unlocked[openground+1] = 1;//解锁
                    setgroundpic(openground+1, 0);//空的土地
                    player.planted[openground+1] = 0;//啥都没种
                    openground++;
                    player.savedata();
                    if (openground != 12)
                        toolTip1.SetToolTip(button4, $"开辟第{openground + 1}块地要{opencost[openground]}元");
                    else
                        toolTip1.SetToolTip(button4, "所有土地已解锁");
                }
            }
        }

        //铲除植物
        private void button5_Click(object sender, EventArgs e)
        {
            kill = true;
            plant = false;
            this.Cursor = Cursors.No;
        }

        //取消铲除
        private void button6_Click(object sender, EventArgs e)
        {
            if(kill==true)
            {
                kill = false;
                this.Cursor = Cursors.Default;
            }
        }

        //设置tooltip
        private void settooltip()
        {
            for(int i=1;i<=16;i++)
            {
                string tips="";
                tips += $"种子id:{seedlist.seeds[i].id}\r\n";
                tips += $"种子名称:{seedlist.seeds[i].name}\r\n";
                tips += $"种子价格:{seedlist.seeds[i].price}\r\n";
                tips += $"成熟时间:{seedlist.seeds[i].time}\r\n";
                tips += $"收割经验:{seedlist.seeds[i].exp}\r\n";
                tips += $"出售价格:{seedlist.seeds[i].gold}\r\n";
                toolTip1.SetToolTip(seedpiclist[i], tips);
            }
            if (openground != 12)
                toolTip1.SetToolTip(button4, $"开辟第{openground + 1}块地要{opencost[openground]}元");
            else
                toolTip1.SetToolTip(button4, "所有土地已解锁");
        }

        #endregion

        #region 选择种子

        private void selectseed(int i)
        {
            kill = false;//不铲除
            if (player.seeds[i] > 0)//有种子则选中
            {
                selectedseed = i;
                seedid.Text = seedlist.seeds[i].name;
                plant = true;//选择种子可以种植
                this.Cursor = Cursors.Cross;
            }
            else
            {
                MessageBox.Show("请先购买该种子哦！");
                plant = false;
                this.Cursor = Cursors.Default;
            }
        }

        private void button3_Click(object sender, EventArgs e)//取消种子选择
        {
            selectedseed = 0;
            seedid.Text = "无";
            if (plant == true)
            {
                plant = false;
                this.Cursor = Cursors.Default;
            }
        }

        private void pictureBox13_Click(object sender, EventArgs e)//1
        {
            selectseed(1);
        }

        private void pictureBox14_Click(object sender, EventArgs e)//2
        {
            selectseed(2);
        }

        private void pictureBox15_Click(object sender, EventArgs e)//3
        {
            selectseed(3);
        }

        private void pictureBox16_Click(object sender, EventArgs e)//4
        {
            selectseed(4);
        }

        private void pictureBox20_Click(object sender, EventArgs e)//5
        {
            selectseed(5);
        }

        private void pictureBox19_Click(object sender, EventArgs e)//6
        {
            selectseed(6);
        }

        private void pictureBox18_Click(object sender, EventArgs e)//7
        {
            selectseed(7);
        }

        private void pictureBox17_Click(object sender, EventArgs e)//8
        {
            selectseed(8);
        }

        private void pictureBox24_Click(object sender, EventArgs e)//9
        {
            selectseed(9);
        }

        private void pictureBox23_Click(object sender, EventArgs e)//10
        {
            selectseed(10);
        }

        private void pictureBox22_Click(object sender, EventArgs e)//11
        {
            selectseed(11);
        }

        private void pictureBox21_Click(object sender, EventArgs e)//12
        {
            selectseed(12);
        }

        private void pictureBox28_Click(object sender, EventArgs e)//13
        {
            selectseed(13);
        }

        private void pictureBox27_Click(object sender, EventArgs e)//14
        {
            selectseed(14);
        }

        private void pictureBox26_Click(object sender, EventArgs e)//15
        {
            selectseed(15);
        }

        private void pictureBox25_Click(object sender, EventArgs e)//16
        {
            selectseed(16);
        }

        #endregion

        #region 处理土地
        private void dealwithground(int i)//处理第i快土地
        {
            if (player.unlocked[i] == 0)//没解锁，啥都不做
            {
                MessageBox.Show("未解锁，不可操作！");
                return;
            }
            else//解锁了
            {
                if (timelist[i].Text == "可收割")//优先处理收割
                {
                    kill = false;//不收割
                    plant = false;//不种植
                    if (voice)
                        finishm.Play();
                    this.Cursor = Cursors.Default;//正常鼠标
                    player.gold += seedlist.seeds[player.planted[i]].gold;
                    gold.Text = player.gold.ToString();
                    player.getexp(seedlist.seeds[player.planted[i]].exp);
                    expnow.Text = player.expnow.ToString();
                    expmax.Text = player.expmax.ToString();
                    gold.Text = player.gold.ToString();
                    level.Text = player.lv.ToString();
                    player.planted[i] = 0;//没有种植
                    player.timestart[i] = 0;//没种植没有开始时间
                    setgroundpic(i, 0);//设置为空地
                    timelist[i].Text = "0";//没有种植
                    namelist[i].Text = "无";//没有种植
                    player.savedata();
                }
                else//不可以收割，分为种植和铲除
                {
                    if (plant == true)//种植
                    {
                        if (player.unlocked[i] == 1)//已解锁
                        {
                            if (player.planted[i] > 0)//已种植
                            {
                                MessageBox.Show("该地已种植，不可以继续种植！");
                            }
                            else//没种植才可以种
                            {
                                if (player.seeds[selectedseed] >= 1)//还有种子
                                {
                                    if (voice)
                                        plantm.Play();
                                    player.seeds[selectedseed]--;//消耗一个种子
                                    player.planted[i] = selectedseed;//已种植
                                    player.timestart[i] = calctime();//开始种植时间
                                    seednumlist[selectedseed].Text = player.seeds[selectedseed].ToString();//种子数
                                    timelist[i].Text = seedlist.seeds[selectedseed].time.ToString();//成熟时间
                                    namelist[i].Text = seedlist.seeds[selectedseed].name;
                                    setgroundpic(i, 17);
                                    player.savedata();

                                }
                                else//种子不够了
                                {
                                    MessageBox.Show("该种子已不足，请更换种子进行种植！");
                                    selectedseed = 0;
                                    seedid.Text = "无";
                                    plant = false;
                                    this.Cursor = Cursors.Default;
                                }
                            }
                        }
                        else//没解锁，不可以种
                        {
                            MessageBox.Show("该地未解锁，不可以继续种植！");
                        }
                    }
                    else if (kill == true)//铲除
                    {
                        if (player.unlocked[i] == 1)//已解锁
                        {
                            if (player.planted[i] > 0)//可以铲除
                            {
                                if (voice)
                                    digm.Play();
                                player.planted[i] = 0;//没有种植
                                player.timestart[i] = 0;//没种植没有开始时间
                                setgroundpic(i, 0);//设置为空地
                                timelist[i].Text = "0";//没有种植   
                                namelist[i].Text = "无";//没有种植
                                player.savedata();
                            }
                            else
                            {
                                MessageBox.Show("该地未种植，不可以铲除！");
                            }
                        }
                        else
                        {
                            MessageBox.Show("该地还没有解锁，不可以进行铲除操作！");
                        }
                    }
                    else//没选择
                    {
                        MessageBox.Show("作物成熟后才可以收割，或者使用铲除工具进行铲除，点击种子进行耕种~");
                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            dealwithground(1);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            dealwithground(2);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            dealwithground(3);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            dealwithground(4);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            dealwithground(5);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            dealwithground(6);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            dealwithground(7);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            dealwithground(8);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            dealwithground(9);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            dealwithground(10);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            dealwithground(11);
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            dealwithground(12);
        }
        #endregion

        #region 音效
        private void button7_Click(object sender, EventArgs e)
        {
            voice = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
                voice = true;
        }
        #endregion
    }
}
