using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 列控培训平台操控系统.初始信息;

namespace 列控培训平台操控系统.临时限速
{
    public partial class 临时限速界面 : Form
    {
        操控界面 f;
        public 临时限速界面(操控界面 f)
        {
            this.f = f;
            InitializeComponent();
        }
        private void 临时限速界面_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < InitializationInformation.stationNum; i++)
            {
                cb_车站.Items.Add(f.stations[i].name);
            }
            cb_车站.Enabled = false;
            cb_命令类型.SelectedIndex = 0;
            cb_限速原因.SelectedIndex = 1;
            cb_线路.SelectedIndex = 0;
            cb_限速值.SelectedIndex = 5;
            rb_立即执行.Checked = true;
            rb_持久有效.Checked = true;
            cb_定时开始.Enabled = false;
            cb_定时结束.Enabled = false;
            tb_startkm.Text = "2026";
            tb_startm.Text = "800";
            tb_endkm.Text = "2030";
            tb_endm.Text = "100";
        }

        private void cb_命令类型_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_命令类型.SelectedItem.ToString() == "正线限速")
            {
                cb_车站.Enabled = false;
                //MessageBox.Show("ok");
            }
            else if (cb_命令类型.SelectedItem.ToString() == "车站限速")
            {
                cb_车站.Enabled = true;
            }
        }
        private int ti(string s)
        {
            return Convert.ToInt32(s);
        }
        private void btn_确定_Click(object sender, EventArgs e)
        {
            TSRS tsrs = new TSRS(
                    this.f,
                    ti(tb_startkm.Text.ToString()),
                    ti(tb_startm.Text.ToString()),
                    ti(tb_endkm.Text.ToString()),
                    ti(tb_endm.Text.ToString()),
                    ti(cb_限速值.SelectedItem.ToString()),
                    cb_线路.SelectedItem.ToString(),
                    cb_限速原因.SelectedItem.ToString(),
                    (cb_线路.SelectedItem.ToString() == "武广线下行线路") ? 0 : 1,
                    f.TSRSIndex
                );
            f.TSRSIndex++;
            f.tsrss.Add(tsrs);
            this.Close();
        }

        private void btn_取消_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
