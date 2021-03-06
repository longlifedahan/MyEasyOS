using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;

namespace MyEasyOS
{
    public static class player//玩家类
    {
        public static string username;//用户名
        public static int lv;//等级
        public static int expnow;//现在有的经验
        public static int expmax;//总共有的经验
        public static int gold;//拥有的金币
        public static int[] seeds = new int[17];//种子数量，1-16有效
        public static int[] unlocked = new int[13];//每块土地是否解锁
        public static int[] planted = new int[13];//每块土地的种植情况，0为未种植，1-16位种植的编号
        public static int[] timestart = new int[13];//每块地开始种植的时间(当前时间距离1970年1月1日的秒数）
        public static int readdata(string Username,string Password)//读取玩家数据，需要先验证密码匹配
        {
            //1成功登陆，2找不到账号，3密码错误
            var fileName = common.userfile()+"gameuser.db";
            SQLiteConnection cn = new SQLiteConnection("data source=" + fileName);//建立连接对象
            SQLiteCommand cmd = new SQLiteCommand();
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandText = $"SELECT password FROM user where username='{Username}'";
            var result = cmd.ExecuteScalar();
            cn.Close();
            if (result == null)//返回为空，没这个用户
            {
                return 2;
            }
            else//有这个用户
            {
                //登陆成功
                if ((string)result == Password)//登陆成功
                {
                    username = Username;
                    //具体读取数据
                    cn.Open();
                    cmd.CommandText = $"SELECT lv FROM user where username='{Username}'";
                    lv = (int)cmd.ExecuteScalar();
                    cmd.CommandText = $"SELECT expnow FROM user where username='{Username}'";
                    expnow = (int)cmd.ExecuteScalar();
                    cmd.CommandText = $"SELECT expmax FROM user where username='{Username}'";
                    expmax = (int)cmd.ExecuteScalar();
                    cmd.CommandText = $"SELECT gold FROM user where username='{Username}'";
                    gold = (int)cmd.ExecuteScalar();
                    for(int i=1;i<=16;i++)
                    {
                        cmd.CommandText = $"SELECT {"seed"+i} FROM user where username='{Username}'";
                        seeds[i] = (int)cmd.ExecuteScalar();
                    }
                    for (int i = 1; i <= 12; i++)
                    {
                        cmd.CommandText = $"SELECT {"unlocked" + i} FROM user where username='{Username}'";
                        unlocked[i] = (int)cmd.ExecuteScalar();
                    }
                    for (int i = 1; i <= 12; i++)
                    {
                        cmd.CommandText = $"SELECT {"planted" + i} FROM user where username='{Username}'";
                        planted[i] = (int)cmd.ExecuteScalar();
                    }
                    for (int i = 1; i <= 12; i++)
                    {
                        cmd.CommandText = $"SELECT {"ts" + i} FROM user where username='{Username}'";
                        timestart[i] = (int)cmd.ExecuteScalar();
                    }
                    cn.Close();
                    return 1;
                }
                else//密码错误
                {
                    return 3;
                }
            }
        }
        public static void savedata()//保存玩家数据
        {
            //连接数据库
            var fileName = common.userfile()+"gameuser.db";
            SQLiteConnection cn = new SQLiteConnection("data source=" + fileName);//建立连接对象
            SQLiteCommand cmd = new SQLiteCommand();
            cn.Open();
            cmd.Connection = cn;
            //更新数据
            cmd.CommandText = $"UPDATE user SET lv={lv},expnow={expnow},expmax={expmax},gold={gold} WHERE username='{username}'";
            cmd.ExecuteNonQuery();            
            for(int i=1;i<=16;i++)
            {
                cmd.CommandText = $"UPDATE user SET seed{i}={seeds[i]} WHERE username='{username}'";
                cmd.ExecuteNonQuery();
            }
            for (int i = 1; i <= 12; i++)
            {
                cmd.CommandText = $"UPDATE user SET unlocked{i}={unlocked[i]} WHERE username='{username}'";
                cmd.ExecuteNonQuery();
                cmd.CommandText = $"UPDATE user SET planted{i}={planted[i]} WHERE username='{username}'";
                cmd.ExecuteNonQuery();
                cmd.CommandText = $"UPDATE user SET ts{i}={timestart[i]} WHERE username='{username}'";
                cmd.ExecuteNonQuery();
            }
            cn.Close();
        }
        public static int initnewplayer(string Username,string Password)//生成一个新的玩家
        {
            //1为成功 0为失败
            var fileName = common.userfile()+"gameuser.db";
            SQLiteConnection cn = new SQLiteConnection("data source=" + fileName);//建立连接对象
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = cn;
            cn.Open();
            cmd.CommandText = $"SELECT username FROM user where username='{Username}'";
            var result = cmd.ExecuteScalar();
            cn.Close();
            if (result != null)
                return 0;
            //初始化玩家数据
            username = Username;
            lv = 1;
            expnow = 0;
            expmax = 100;
            gold = 100;
            //所有种子为0
            for (int i = 1; i <= 16; i++)
                seeds[i] = 0;
            //只解锁两块地
            for (int i = 1; i <= 2; i++)
                unlocked[i] = 1;
            for (int i = 3; i <= 12; i++)
                unlocked[i] = 0;
            //所有地未耕种
            for (int i = 1; i <= 12; i++)
                planted[i] = 0;
            //所有地的开始时间为0
            for (int i = 1; i <= 12; i++)
                timestart[i] = 0;
            //保存玩家
            cmd.Connection = cn;            
            cmd.CommandText = $"INSERT INTO user VALUES('{Username}','{Password}',{lv},{expnow},{expmax},{gold}," +
                $"{seeds[1]},{seeds[2]},{seeds[3]},{seeds[4]},{seeds[5]},{seeds[6]},{seeds[7]},{seeds[8]},{seeds[9]},{seeds[10]},{seeds[11]},{seeds[12]},{seeds[13]},{seeds[14]},{seeds[15]},{seeds[16]}," +
                $"{unlocked[1]},{unlocked[2]},{unlocked[3]},{unlocked[4]},{unlocked[5]},{unlocked[6]},{unlocked[7]},{unlocked[8]},{unlocked[9]},{unlocked[10]},{unlocked[11]},{unlocked[12]}," +
                $"{planted[1]},{planted[2]},{planted[3]},{planted[4]},{planted[5]},{planted[6]},{planted[7]},{planted[8]},{planted[9]},{planted[10]},{planted[11]},{planted[12]}," +
                $"{timestart[1]},{timestart[2]},{timestart[3]},{timestart[4]},{timestart[5]},{timestart[6]},{timestart[7]},{timestart[8]},{timestart[9]},{timestart[10]},{timestart[11]},{timestart[12]}" +
                $")";//保存数据
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            return 1;
        }
        public static void lvup()//升级
        {
            for(;expnow>=expmax;)
            {
                lv++;
                expnow -= expmax;
                expmax = lv * 100;
                gold += lv * 10;
                MessageBox.Show($"恭喜你升到{lv}级，获得金币{lv * 10}！");
            }
        }
        public static void getexp(int i)//得到经验
        {
            expnow += i;
            lvup();
        }
    }
}
