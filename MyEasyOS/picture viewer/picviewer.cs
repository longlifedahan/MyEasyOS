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
    public partial class picviewer : Form
    {
        public picviewer()
        {
            InitializeComponent();
        }

        public picviewer(string filename)
        {
            InitializeComponent();
            pictureBox1.BackgroundImage = Image.FromFile(filename);
            piclist.Items.Add(filename);
            canchange = false;
            piclist.SelectedIndex = piclist.Items.Count - 1;
            canchange = true;
        }

        private void button1_Click(object sender, EventArgs e)//打开图片
        {
            OpenFileDialog ofg = new OpenFileDialog();
            ofg.Filter = "jpg文件(*.jpg)|*.jpg|png文件(*.png) | *.png";
            ofg.InitialDirectory = common.userfile() + "pic";
            if (ofg.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.BackgroundImage = Image.FromFile(ofg.FileName);
                piclist.Items.Add(ofg.FileName);
                canchange = false;
                piclist.SelectedIndex = piclist.Items.Count - 1;
                canchange = true;
            }
        }

        bool canchange = true;
        private void piclist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (canchange)
                pictureBox1.BackgroundImage = Image.FromFile(piclist.Items[piclist.SelectedIndex].ToString());
        }
    }
}
