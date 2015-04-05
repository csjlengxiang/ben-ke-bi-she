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
using 列控培训平台操控系统.区间;

namespace 列控培训平台操控系统.临时限速
{
    public partial class 管理临时限速 : Form
    {
        操控界面 f;
        public 管理临时限速(操控界面 f)
        {
            this.f = f;
            InitializeComponent();
        }

        private DataGridViewTextBoxColumn NewOneColumn(string head)
        {
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            column.HeaderText = head;
            return column;
        }
        private void 管理临时限速_Load(object sender, EventArgs e)
        {
            dgv_限速管理.Columns.Clear();
            dgv_限速管理.ReadOnly = true;
            dgv_限速管理.AllowUserToAddRows = false;
            dgv_限速管理.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridViewTextBoxColumn a = NewOneColumn("限速命令号");
            DataGridViewTextBoxColumn b = NewOneColumn("限速线路");
            DataGridViewTextBoxColumn c = NewOneColumn("开始公里标");
            DataGridViewTextBoxColumn d = NewOneColumn("结束公里标");
            DataGridViewTextBoxColumn ee = NewOneColumn("限速值");
            DataGridViewTextBoxColumn f = NewOneColumn("计划开始时间");
            DataGridViewTextBoxColumn g = NewOneColumn("计划结束时间");
            DataGridViewTextBoxColumn h = NewOneColumn("状态");
            dgv_限速管理.Columns.AddRange(new DataGridViewTextBoxColumn[] { a, b, c, d, ee, f, g, h });


            for (int i = 0; i < this.f.tsrss.Count; i++)
            {
                TSRS t = this.f.tsrss[i];
                dgv_限速管理.Rows.Add(new string[] { t.index.ToString(), t.lineName, "K" + t.startkm.ToString() + "+" + t.startm.ToString(), "K" + t.endkm.ToString() + "+" + t.endm.ToString(), t.limitSpeed.ToString() + "km/h", "立即执行", "持续有效", "已激活" });

                cb_命令号.Items.Add(t.index);
            }
            if (this.f.tsrss.Count == 0)
            {
                MessageBox.Show("没有临时限速信息");
                this.Close();
                return;
            }
            cb_命令号.SelectedIndex = 0;
        }

        private void btn_删除_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(cb_命令号.SelectedItem.ToString());

            for (int i = 0; i < f.tsrss.Count; i++)
            {
                TSRS t = f.tsrss[i];
                if (t.index == index)
                {
                    f.tsrss.RemoveAt(i);
                    break;
                }
            }
            for (int i = 0; i < InitializationInformation.stationNum - 1; i++)
            {
                for (int j = 0; j < f.sections[i].Xtracks.Count; j++)
                {
                    Section.Track xt = f.sections[i].Xtracks[j];
                    for (int k = 0; k < xt.speeds.Count; k++)
                    {
                        if (xt.speeds[k].index == index)
                        {
                            xt.speeds.RemoveAt(k);
                            break;
                        }
                    }
                    xt.limitSpeed = 1000;
                    for (int k = 0; k < xt.speeds.Count; k++)
                    {
                        xt.limitSpeed = Math.Min(xt.limitSpeed, xt.speeds[k].limitSpeed);
                    }
                    //if (xt.speeds.Count == 0)
                    //{
                    //    f.sections[i].DrawTrack(f.g, xt);
                    //}
                }
            }
            for (int i = 0; i < InitializationInformation.stationNum - 1; i++)
            {
                for (int j = 0; j < f.sections[i].Stracks.Count; j++)
                {
                    Section.Track xt = f.sections[i].Stracks[j];
                    for (int k = 0; k < xt.speeds.Count; k++)
                    {
                        if (xt.speeds[k].index == index)
                        {
                            xt.speeds.RemoveAt(k);
                            break;
                        }
                    }
                    xt.limitSpeed = 1000;
                    for (int k = 0; k < xt.speeds.Count; k++)
                    {
                        xt.limitSpeed = Math.Min(xt.limitSpeed, xt.speeds[k].limitSpeed);
                    }
                    //if (xt.speeds.Count == 0)
                    //{
                    //    f.sections[i].DrawTrack(f.g, xt);
                    //}
                }
            }
            for (int i = 0; i < InitializationInformation.stationNum - 1; i++)
            {
                f.sections[i].DrawDynamicMap(f.g);
            }
            f.pb_界面图片.Image = f.bp;
            this.Close();
        }

        private void btn_关闭_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
