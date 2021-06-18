using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEasyOS
{
    public class seed//种子类
    {
        public int id;//标号，1-16
        public string name;//种子名称
        public int price;//价格
        public int time;//成熟时间
        public int exp;//得到的经验
        public int gold;//得到的金币
        public seed(int id,string name,int price,int time,int exp,int gold)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.time = time;
            this.exp = exp;
            this.gold = gold;
        }
    }

    public static class seedlist//种子列表类
    {
        public static seed[] seeds = new seed[17];
        public static void initseeds()//初始化所有种子
        {
            //基础作物 1.5+0/5/10+5/15+10
            seeds[1] = new seed(1, "苹果", 10, 10, 15, 15);
            seeds[2] = new seed(2, "香梨", 30, 30, 50, 50);
            seeds[3] = new seed(3, "香蕉", 60, 60, 105, 105);            
            seeds[4] = new seed(4, "芒果", 90, 90, 160, 160);
            //进阶作物（经验）1.3 1.7 经验10/30/50/70
            seeds[5] = new seed(5, "李子", 200, 600, 260, 350);
            seeds[6] = new seed(6, "橘子", 400, 1800, 520, 710);
            seeds[7] = new seed(7, "橙子", 600, 2700, 780,1070);
            seeds[8] = new seed(8, "桃子", 800, 3600, 1040, 1430);
            //进阶作物（金币） 1.7 1.3 金币10/30/50/70
            seeds[9] = new seed(9, "草莓", 200, 600, 350, 260);        
            seeds[10] = new seed(10, "香瓜", 400, 1800, 710, 520);
            seeds[11] = new seed(11, "葡萄", 600, 2700, 1070, 780);
            seeds[12] = new seed(12, "椰子", 800, 3600, 1430, 1040);
            //大型作物 1.25 1.25 金币经验 50 100 200 300
            seeds[13] = new seed(13, "柚子", 1000, 7200, 1300, 1300);
            seeds[14] = new seed(14, "西瓜", 3000, 14400, 3850, 3850);
            seeds[15] = new seed(15, "龙眼", 6000, 28800, 7700, 7700);
            seeds[16] = new seed(16, "荔枝", 10000, 43200, 12800, 12800);
        }
        //返回种子
        public static seed gs(int i)//返回种子
        {
            return seeds[i];
        }
    }
}
