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

namespace MyEasyOS
{
    public partial class mpr : Form
    {
        public mpr()
        {
            InitializeComponent();
        }

        public mpr(string filename)
        {
            InitializeComponent();
            history.Items.Add(filename.Substring(common.userfile().Length));
            WMP.URL = filename;
            canchange = false;
            history.SelectedIndex = history.Items.Count - 1;
            canchange = true;
        }

        bool canchange = true;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofg = new OpenFileDialog();
            ofg.Filter = "mp3文件(*.mp3)|*.mp3|mp4文件(*.mp4) | *.mp4|wav文件(*.wav)|*.wav";
            ofg.InitialDirectory = common.userfile() + "media";
            if (ofg.ShowDialog() == DialogResult.OK)
            {
                history.Items.Add(ofg.FileName.Substring(common.userfile().Length));
                WMP.URL = ofg.FileName;
                canchange = false;
                history.SelectedIndex = history.Items.Count - 1;
                canchange = true;
            }

        }

        private void history_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (canchange)
                WMP.URL = common.userfile() + history.Items[history.SelectedIndex];
        }
    }
}
