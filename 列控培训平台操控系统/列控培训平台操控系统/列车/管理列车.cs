using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 列控培训平台操控系统.列车初始化
{
    public partial class 管理列车 : Form
    {
        操控界面 f;
        public 管理列车(操控界面 f)
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

        private void 管理列车_Load(object sender, EventArgs e)
        {
            if (this.f.trains.Count == 0)
            {
                MessageBox.Show("未加载列车");
                this.Close();
                return;
            }
            dgv_列车管理.Columns.Clear();
            dgv_列车管理.ReadOnly = true;
            dgv_列车管理.AllowUserToAddRows = false;
            dgv_列车管理.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridViewTextBoxColumn a = NewOneColumn("车次号");
            DataGridViewTextBoxColumn b = NewOneColumn("列车当前位置");
            DataGridViewTextBoxColumn c = NewOneColumn("速度");
            dgv_列车管理.Columns.AddRange(new DataGridViewTextBoxColumn[] { a, b, c });


            for (int i = 0; i < this.f.trains.Count; i++)
            {
                Train t = this.f.trains[i];

                string s;
                if (t.inStation) s = "列车在"+ f.stations[t.stationPos].name + "的" + t.dgName + "股道上";
                else s = "列车在区间" + t.dgName;
                
                dgv_列车管理.Rows.Add(new string[] { t.name , " " + s,t.runInf.curSpeed.ToString() + " km/h"});

                cb_车次.Items.Add(t.name);
            }
            cb_车次.SelectedIndex = 0;

        }

        private void btn_删除_Click(object sender, EventArgs e)
        {
            int pos = cb_车次.SelectedIndex;
            //f.trains.RemoveAt(cb_车次.SelectedIndex);

            if (f.trains[pos].inStation == false)
            {
                MessageBox.Show("车不在站内，无法删除");
            }
            else
            {
                f.trains[pos].p.Visible = false;
                f.trains[pos].DrawTrackStatus(f, 0);
                f.trains.RemoveAt(cb_车次.SelectedIndex);
            }
            this.Close();
        }

        private void btn_关闭_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
