using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 列控培训平台操控系统.初始信息;
using 列控培训平台操控系统.车站;
namespace 列控培训平台操控系统.列车初始化
{
    public partial class 列车初始化界面 : Form
    {
        操控界面 f;

        public 列车初始化界面(操控界面 f)
        {
            this.f = f;
            InitializeComponent();
        }

        private void 列车初始化界面_Load(object sender, EventArgs e)
        {
            tb_车长.Text = "100";
            tb_车次号.Text = "D1";
            rb_站内.Checked = true;
            panel_站内.Visible = true;
            panel_区段.Visible = false;
            rb_站内_Click(sender, e);
            cb_选择站名.SelectedIndex = 0;
            cb_选择股道.SelectedIndex = 0;
            tb_反向.Visible = false;
            rb_正向.Checked = true;
            tb_正向.Text = "200"; 
            tb_反向.Text = "200";
            rb_区段正向.Checked = true;
        }

        private void btn_取消_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rb_正向_CheckedChanged(object sender, EventArgs e)
        {
            tb_正向.Visible = true;
            tb_反向.Visible = false;
        }

        private void rb_反向_CheckedChanged(object sender, EventArgs e)
        {
            tb_正向.Visible = false;
            tb_反向.Visible = true;
        }

        private void rb_站内_Click(object sender, EventArgs e)
        {
            panel_站内.Visible = true;
            panel_区段.Visible = false;
            cb_选择站名.Items.Clear();
            for (int i = 0; i < InitializationInformation.stationNum; i++)
            {
                cb_选择站名.Items.Add(f.stations[i].name);
            }
        }

        private void rb_区间_Click(object sender, EventArgs e)
        {
            panel_区段.Visible = true;
            panel_站内.Visible = false;
            cb_区段.Items.Clear();
            for (int i = 0; i < InitializationInformation.stationNum - 1; i++)
            {
                for (int j = 0; j < f.sections[i].Xtracks.Count; j++)
                    cb_区段.Items.Add(f.sections[i].Xtracks[j].name);
                for (int j = 0; j < f.sections[i].Stracks.Count; j++)
                    cb_区段.Items.Add(f.sections[i].Stracks[j].name);
            }
            cb_区段.SelectedIndex = 0;
        }

        #region 选择站场，弹出股道的响应
        private void cb_选择站名_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_选择股道.Items.Clear();
            for (int i = 0; i < f.stations[cb_选择站名.SelectedIndex].dgNumber; i++)
            {
                Station.DG dg = f.stations[cb_选择站名.SelectedIndex].dgs[i];
                if (IsWantDg(dg.name))
                    cb_选择股道.Items.Add(dg.name);
            }
            List<string> a = new List<string>();
            for (int i = 0; i < cb_选择股道.Items.Count; i++)
            {
                int flag = 0;
                string s = cb_选择股道.Items[i].ToString();
                if (s != "IG" && s != "IIG")
                {
                    for (int j = i + 1; j < cb_选择股道.Items.Count; j++)
                    {
                        if (i == j) continue;
                        string t = cb_选择股道.Items[j].ToString();
                        if (s.Substring(0, s.Length - 1) == t.Substring(0, s.Length - 1))
                        {
                            flag = 1;
                            cb_选择股道.Items.RemoveAt(j);
                        }
                    }
                }
                if (flag == 0)
                    a.Add(s);
                else a.Add(s.Substring(0, s.Length - 1));
            }
            cb_选择股道.Items.Clear();
            for (int i = 0; i < a.Count; i++)
                cb_选择股道.Items.Add(a[i]);
        }
        private bool IsWantDg(string s) //是否是下行
        {
            if (s.Substring(0, 2) == "II")
                return true;
            if (s.Substring(0, 1) == "I")
                return true;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'D') return false;
            }
            return true;
        }
        #endregion

        private void btn_确定_Click(object sender, EventArgs e)
        {
            if (rb_站内.Checked)
                f.trains.Add(new Train(this.f, Convert.ToInt32(tb_车长.Text), tb_车次号.Text, rb_站内.Checked, cb_选择站名.SelectedIndex, cb_选择股道.SelectedItem.ToString(), "", rb_正向.Checked, tb_正向.Text.ToString(), tb_反向.Text.ToString()));
            else
                f.trains.Add(new Train(this.f, Convert.ToInt32(tb_车长.Text), tb_车次号.Text, rb_站内.Checked, -1, "", cb_区段.SelectedItem.ToString(), rb_区段正向.Checked, "", ""));
            this.Close();
        }
    }
}
