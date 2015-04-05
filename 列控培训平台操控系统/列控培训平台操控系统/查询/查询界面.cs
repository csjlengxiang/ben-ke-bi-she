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
namespace 列控培训平台操控系统.查询
{
    public partial class 查询界面 : Form
    {
        操控界面 f;
        public 查询界面(操控界面 f)
        {
            this.f = f;
            InitializeComponent();
        }

        private void 查询界面_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < InitializationInformation.stationNum; i++)
            {
                cb_查询车站.Items.Add(f.stations[i].name);
            }
            cb_查询车站.SelectedIndex = 0;
        }

        private DataGridViewTextBoxColumn NewOneColumn(string head)
        {
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            column.HeaderText = head;
            return column;
        }

        private void FillSignalInf()
        {
            int spos = cb_查询车站.SelectedIndex;
            dgv_查询数据.Columns.Clear();
            dgv_查询数据.ReadOnly = true;
            dgv_查询数据.AllowUserToAddRows = false;
            dgv_查询数据.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridViewTextBoxColumn a = NewOneColumn("信号机名称");
            DataGridViewTextBoxColumn b = NewOneColumn("公里标");
            DataGridViewTextBoxColumn c = NewOneColumn("方向");
            DataGridViewTextBoxColumn d = NewOneColumn("当前状态");
            DataGridViewTextBoxColumn e = NewOneColumn("当前颜色");
            dgv_查询数据.Columns.AddRange(new DataGridViewTextBoxColumn[] { a, b, c,d, e });
            for (int i = 0; i < f.stations[spos].signalNumber; i++)
            {
                Station.Signal sig = f.stations[spos].signals[i];
                string s;
                if(sig.status == 0)
                    s = "空闲";
                else if(sig.status == 1)
                    s = "占用";
                else s = "故障";
                dgv_查询数据.Rows.Add(new string[] { sig.name, sig.position.ToString(), sig.dir == 0 ? "正向" : "反向", s, (sig.color == "" || sig.color == null) ? "H" : sig.color });
            }
        }
        private void FillDGInf()
        {
            int spos = cb_查询车站.SelectedIndex;
            dgv_查询数据.Columns.Clear();
            dgv_查询数据.ReadOnly = true;
            dgv_查询数据.AllowUserToAddRows = false;
            dgv_查询数据.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridViewTextBoxColumn a = NewOneColumn("股道名称");
            DataGridViewTextBoxColumn b = NewOneColumn("分支数");
            DataGridViewTextBoxColumn c = NewOneColumn("状态");
            dgv_查询数据.Columns.AddRange(new DataGridViewTextBoxColumn[] { a, b, c});
            for (int i = 0; i < f.stations[spos].dgNumber; i++)
            {
                Station.DG dg = f.stations[spos].dgs[i];
                string s;
                if (dg.status == 0)
                    s = "空闲";
                else if (dg.status == 1)
                    s = "故障";
                else if (dg.status == 2)
                    s = "等待接发车";
                else if (dg.status == 3)
                    s = "占用";
                else s = "";
                dgv_查询数据.Rows.Add(new string[] { dg.name, dg.branchNumber.ToString(), s });
            }
        }
        private void FillSwitchInf()
        {
            int spos = cb_查询车站.SelectedIndex;
            dgv_查询数据.Columns.Clear();
            dgv_查询数据.ReadOnly = true;
            dgv_查询数据.AllowUserToAddRows = false;
            dgv_查询数据.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridViewTextBoxColumn a = NewOneColumn("道岔编号");
            DataGridViewTextBoxColumn b = NewOneColumn("公里标");
            DataGridViewTextBoxColumn c = NewOneColumn("状态");
            DataGridViewTextBoxColumn d = NewOneColumn("是否锁闭");
            dgv_查询数据.Columns.AddRange(new DataGridViewTextBoxColumn[] { a, b, c,d });
            for (int i = 0; i < f.stations[spos].switchNumber; i++)
            {
                Station.Switch sw = f.stations[spos].switchs[i];
                string s;
                if (sw.status == 0)
                    s = "定位";
                else if (sw.status == 1)
                    s = "反位";
                else if (sw.status == 2)
                    s = "双开";
                else if (sw.status == 3)
                    s = "故障";
                else s = "";
                dgv_查询数据.Rows.Add(new string[] { sw.no.ToString(), sw.position.ToString(), s, sw.isLock == 1 ? "是" : "否" });
            }
        }

        private void cb_车站设备_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_车站设备.SelectedItem.ToString() == "信号机")
            {
                FillSignalInf();
            }
            else if (cb_车站设备.SelectedItem.ToString() == "股道")
            {
                FillDGInf();
            }
            else if (cb_车站设备.SelectedItem.ToString() == "道岔")
            {
                FillSwitchInf();
            }
        }
    }
}
