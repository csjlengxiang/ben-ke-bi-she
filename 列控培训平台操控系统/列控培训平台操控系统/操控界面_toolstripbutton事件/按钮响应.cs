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
using System.Diagnostics;

namespace 列控培训平台操控系统
{
    public partial class 操控界面 : Form
    {
        private void IsTsBtnDownChange()
        {
            for (int i = 0; i < ts_联锁工具条.Items.Count; i++)
            {
                if (ts_联锁工具条.Items[i] is ToolStripSeparator) continue;
                if (ts_联锁工具条.Items[i] is ToolStripButton)
                {
                    ToolStripButton ts = (ToolStripButton)ts_联锁工具条.Items[i];
                    if (ts.Checked)
                    {
                        ts.CheckState = CheckState.Unchecked;
                        ts.ForeColor = Color.Black;
                    }
                }
            }
        }
        private ToolStripButton WhichTsBtnDown()
        {
            for (int i = 0; i < ts_联锁工具条.Items.Count; i++)
            {
                if (ts_联锁工具条.Items[i] is ToolStripSeparator) continue;
                if (ts_联锁工具条.Items[i] is ToolStripButton)
                {
                    ToolStripButton ts = (ToolStripButton)ts_联锁工具条.Items[i];
                    if (ts.Checked)
                    {
                        return ts;
                    }
                }
            }
            MessageBox.Show("防护没有按钮被选中");
            return null;
        }
        private void TsBtunInit(ToolStripButton tsbtn)
        {
            IsTsBtnDownChange();
            tsbtn.CheckState = CheckState.Checked;
            tsbtn.ForeColor = Color.DimGray;
        }
        private void ClearBtnDowns()
        {
            for (int i = 0; i < btnDowns.Count(); i++)
            {
                stations[btnDowns[i].stationPos].DrawSignalBtnUp(g, stations[btnDowns[i].stationPos].signals[btnDowns[i].stationSignalPos]);
            }
            pb_界面图片.Image = bp;
            btnDowns.Clear();
        }

        private void tsbtn_进路建立_Click(object sender, EventArgs e)
        {
            ToolStripButton tsbtn = (ToolStripButton)sender;
            TsBtunInit(tsbtn);
        }

        private void tsbtn_总取消_Click(object sender, EventArgs e)
        {
            ToolStripButton tsbtn = (ToolStripButton)sender;
            TsBtunInit(tsbtn);
        }

        private void tsbtn_信号重开_Click(object sender, EventArgs e)
        {
            ToolStripButton tsbtn = (ToolStripButton)sender;
            TsBtunInit(tsbtn);
        }

        private void tsbtn_区故解_Click(object sender, EventArgs e)
        {
            ToolStripButton tsbtn = (ToolStripButton)sender;
            TsBtunInit(tsbtn);
        }
        private void tsbtn_道岔总定_Click(object sender, EventArgs e)
        {
            ToolStripButton tsbtn = (ToolStripButton)sender;
            TsBtunInit(tsbtn);
        }

        private void tsbtn_道岔总反_Click(object sender, EventArgs e)
        {
            ToolStripButton tsbtn = (ToolStripButton)sender;
            TsBtunInit(tsbtn);
        }

        private void tsbtn_命令下达_Click(object sender, EventArgs e)
        {
            ToolStripButton tsbtn = WhichTsBtnDown();
            if (tsbtn.Name == "tsbtn_进路建立")
            {
                if (btnDowns.Count != 2)
                {
                    MessageBox.Show("办理进路请点击始端按钮，再点击终端按钮，最后点击命令下达");
                }
                else
                {
                    if (btnDowns[0].stationPos != btnDowns[1].stationPos)
                    {
                        MessageBox.Show("您2到点的两个按钮不在同一个车站");
                    }
                    else
                    {
                        stations[btnDowns[0].stationPos].HandleRoute(stations[btnDowns[0].stationPos].signals[btnDowns[0].stationSignalPos], stations[btnDowns[1].stationPos].signals[btnDowns[1].stationSignalPos]);
                        stations[btnDowns[0].stationPos].DrawDynamicMap(g);
                        pb_界面图片.Image = bp;
                    }
                }
            }
            if (tsbtn.Name == "tsbtn_总取消")
            {
                if (btnDowns.Count != 1)
                {
                    MessageBox.Show("总取消请点击总取消，再点击进路始端按钮，最后点击命令下达");
                }
                else
                {
                    Station.Signal sig = stations[btnDowns[0].stationPos].signals[btnDowns[0].stationSignalPos];

                    if (sig.status == 1)
                    {
                        stations[sig.stationPos].CancelRoute(sig.occupyRoute);
                        stations[sig.stationPos].DrawDynamicMap(g);
                        pb_界面图片.Image = bp;
                    }
                    else
                    {
                        MessageBox.Show("该按钮进路不是始端按钮或信号机有问题无法取消进路");
                    }
                }
            }
            else if (tsbtn.Name == "tsbtn_信号重开") //只考虑到轨道故障和道岔失去表示的情况重新开放信号，
            {
                if (btnDowns.Count != 1)
                {
                    MessageBox.Show("信号重开请点击信号重开，再点击进路始端按钮，最后点击命令下达");
                }
                else
                {
                    for (int i = 0; i < InitializationInformation.stationNum; i++)
                    {
                        for (int j = 0; j < stations[i].alreadyHandleRoutes.Count; j++)
                        {
                            Station.Route aroute = stations[i].alreadyHandleRoutes[j].route;
                            Station.Signal routesig = stations[i].signals[aroute.StartSignal.pos];

                            Station.Signal realsig = stations[btnDowns[0].stationPos].signals[btnDowns[0].stationSignalPos];

                            if (routesig == realsig)
                            {
                                Station.Signal sig = realsig;
                                if (sig.status != 0) continue;
                                int flag = 0;
                                for (int k = 0; k < aroute.dgNumber; k++)
                                {
                                    Station.DG dg = stations[i].dgs[aroute.dgs[k].pos];
                                    if (dg.status != 2)
                                    {
                                        flag = 1;
                                    }
                                    Station.DG.Branch b = dg.branchs[dg.branchPos];
                                    for (int l = 0; l < b.pointNumber; l++)
                                    {
                                        Station.DG.Branch.Point p = b.points[l];
                                        if (p.type == 3)
                                        {
                                            int swpos = p.pos;
                                            Station.Switch sw = stations[i].switchs[swpos];
                                            if (sw.status >= 2)
                                            {
                                                flag = 1;
                                                break;
                                            }
                                        }
                                    }
                                    if (flag == 1) break;
                                }
                                if (flag == 1)
                                {
                                    MessageBox.Show("无法重新开放信号");
                                    continue;
                                }
                                sig.color = aroute.StartSignal.color;
                                sig.status = 1;
                                sig.occupyRoute = aroute;
                                stations[i].DrawDynamicMap(g);
                                pb_界面图片.Image = bp;
                            }
                            //MessageBox.Show(stations[i].alreadyHandleRoutes.Count.ToString());
                        }
                    }
                }
            }
            ClearBtnDowns(); 
        }

        private void tsbtn_命令清除_Click(object sender, EventArgs e)
        {
            ClearBtnDowns();
        }
    }
}
