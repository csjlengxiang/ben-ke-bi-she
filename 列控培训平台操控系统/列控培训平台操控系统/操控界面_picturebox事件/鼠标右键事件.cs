using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 列控培训平台操控系统.初始信息;
using 列控培训平台操控系统.车站;
using System.Drawing;
using 列控培训平台操控系统.区间;
namespace 列控培训平台操控系统
{
    public partial class 操控界面 : Form
    {
        private void 股道占用或故障ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int x, y;
            x = preMouse.x;
            y = preMouse.y;
            for (int i = 0; i < InitializationInformation.stationNum; i++)
            {
                for (int j = 0; j < stations[i].dgNumber; j++)
                {
                    Station.DG dg = stations[i].dgs[j];
                    for (int k = 0; k < dg.branchNumber; k++)
                    {
                        Station.DG.Branch.MouseArea a = dg.branchs[k].mouseArea;
                        if (x > a.left && x < a.right && y > a.top && y < a.bottom)
                        {
                            if (dg.status == 0 || dg.status == 2)
                                dg.status++;
                            stations[i].DrawDynamicMap(g);
                            pb_界面图片.Image = bp;
                            return;
                        }
                    }
                }
                if (i == InitializationInformation.stationNum - 1) continue;
                #region 判定是否在区间轨道电路区域
                for (int j = 0; j < sections[i].Xtracks.Count; j++)
                {
                    Section.Track.MouseArea a = sections[i].Xtracks[j].mouseArea;
                    if (x > a.left && x < a.right && y > a.top && y < a.bottom)
                    {
                        MessageBox.Show(sections[i].Xtracks[j].startPosition.ToString() + " " + sections[i].Xtracks[j].endPosition.ToString());
                        sections[i].Xtracks[j].status = 2;
                        sections[i].DrawTrack(g, sections[i].Xtracks[j]);
                        pb_界面图片.Image = bp;
                        return;
                    }
                }
                for (int j = 0; j < sections[i].Stracks.Count; j++)
                {
                    Section.Track.MouseArea a = sections[i].Stracks[j].mouseArea;
                    if (x > a.left && x < a.right && y > a.top && y < a.bottom)
                    {
                        sections[i].Stracks[j].status = 2;
                        sections[i].DrawTrack(g, sections[i].Stracks[j]);
                        pb_界面图片.Image = bp;
                        return;
                    }
                }
                #endregion
            }

        }

        private void 取消占用或故障ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int x, y;
            x = preMouse.x;
            y = preMouse.y;
            for (int i = 0; i < InitializationInformation.stationNum; i++)
            {
                for (int j = 0; j < stations[i].dgNumber; j++)
                {
                    Station.DG dg = stations[i].dgs[j];
                    for (int k = 0; k < dg.branchNumber; k++)
                    {
                        Station.DG.Branch.MouseArea a = dg.branchs[k].mouseArea;
                        if (x > a.left && x < a.right && y > a.top && y < a.bottom)
                        {
                            if (dg.status == 1 || dg.status == 3)
                                dg.status--;
                            stations[i].DrawDynamicMap(g);
                            pb_界面图片.Image = bp;
                            return;
                        }
                    }
                }
                if (i == InitializationInformation.stationNum - 1) continue;
                #region 判定是否在区间轨道电路区域
                for (int j = 0; j < sections[i].Xtracks.Count; j++)
                {
                    Section.Track.MouseArea a = sections[i].Xtracks[j].mouseArea;
                    if (x > a.left && x < a.right && y > a.top && y < a.bottom)
                    {
                        sections[i].Xtracks[j].status = 0;
                        sections[i].DrawTrack(g, sections[i].Xtracks[j]);
                        pb_界面图片.Image = bp;
                        return;
                    }
                }
                for (int j = 0; j < sections[i].Stracks.Count; j++)
                {
                    Section.Track.MouseArea a = sections[i].Stracks[j].mouseArea;
                    if (x > a.left && x < a.right && y > a.top && y < a.bottom)
                    {
                        sections[i].Stracks[j].status = 0;
                        sections[i].DrawTrack(g, sections[i].Stracks[j]);
                        pb_界面图片.Image = bp;
                        return;
                    }
                }
                #endregion
            }
        }
        private void 区段故障解锁ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int x, y;
            x = preMouse.x;
            y = preMouse.y;
            for (int i = 0; i < InitializationInformation.stationNum; i++)
            {
                for (int j = 0; j < stations[i].dgNumber; j++)
                {
                    Station.DG dg = stations[i].dgs[j];
                    for (int k = 0; k < dg.branchNumber; k++)
                    {
                        Station.DG.Branch.MouseArea a = dg.branchs[k].mouseArea;
                        if (x > a.left && x < a.right && y > a.top && y < a.bottom)
                        {
                            //通过渡线，干掉双动道岔
                            dg.status = 0;
                            for (int l = 0; l < dg.branchNumber; l++)
                            {
                                for (int p = 0; p < dg.branchs[l].pointNumber; p++)
                                {
                                    if (dg.branchs[l].points[p].type == 3)
                                    {
                                        Station.Switch sw = stations[i].switchs[dg.branchs[l].points[p].pos];
                                        sw.isLock = 0;

                                        //判断双动道岔
                                        for (int q = 0; q < stations[i].crossoverNumber; q++)
                                        {
                                            Station.Crossover co = stations[i].crossovers[q];
                                            if (co.startSwitchNo == sw.no)
                                            {
                                                int pos = stations[i].FindSwitchFromSwitchNo(co.endSwitchNo);
                                                Station.Switch sw1 = stations[i].switchs[pos];
                                                sw1.isLock = 0;
                                            }
                                            else if (co.endSwitchNo == sw.no)
                                            {
                                                int pos = stations[i].FindSwitchFromSwitchNo(co.startSwitchNo);
                                                Station.Switch sw1 = stations[i].switchs[pos];
                                                sw1.isLock = 0;
                                            }
                                        }
                                    }
                                }
                            }
                            stations[i].DrawDynamicMap(g);
                            pb_界面图片.Image = bp;
                            return;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 道岔失去表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 道岔失去表示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int x, y;
            x = preMouse.x;
            y = preMouse.y;
            for (int i = 0; i < InitializationInformation.stationNum; i++)
            {
                for (int j = 0; j < stations[i].switchNumber; j++)
                {
                    Station.Switch sw = stations[i].switchs[j];
                    Station.Switch.MouseArea a = sw.mouseArea;
                    if (x > a.left && x < a.right && y > a.top && y < a.bottom)
                    {
                        if (sw.status < 2)
                        {
                            sw.status += 2;
                            stations[i].DrawDynamicMap(g);
                            pb_界面图片.Image = bp;
                        }
                        return;
                    }
                }
            }
        }

        private void 道岔恢复表示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int x, y;
            x = preMouse.x;
            y = preMouse.y;
            for (int i = 0; i < InitializationInformation.stationNum; i++)
            {
                for (int j = 0; j < stations[i].switchNumber; j++)
                {
                    Station.Switch sw = stations[i].switchs[j];
                    Station.Switch.MouseArea a = sw.mouseArea;
                    if (x > a.left && x < a.right && y > a.top && y < a.bottom)
                    {
                        if (sw.status >= 2)
                        {
                            sw.status -= 2;
                            stations[i].DrawDynamicMap(g);
                            pb_界面图片.Image = bp;
                        }
                        return;
                    }
                }
            }
        }

        private void 灯丝熔断toolStripMenuItem_Click(object sender, EventArgs e)
        {
            int x, y;
            x = preMouse.x;
            y = preMouse.y;
            for (int i = 0; i < InitializationInformation.stationNum; i++)
            {
                for (int j = 0; j < stations[i].signalNumber; j++)
                {
                    Station.Signal sig = stations[i].signals[j];
                    Station.Signal.MouseArea a = sig.mouseArea;
                    if (x > a.left && x < a.right && y > a.top && y < a.bottom)
                    {
                        if (sig.status < 2)
                        {
                            sig.status += 2;

                            stations[i].DrawDynamicMap(g);
                            pb_界面图片.Image = bp;
                        }
                        return;
                    }
                }
            }
        }

        private void 更换好灯丝toolStripMenuItem_Click(object sender, EventArgs e)
        {
            int x, y;
            x = preMouse.x;
            y = preMouse.y;
            for (int i = 0; i < InitializationInformation.stationNum; i++)
            {
                for (int j = 0; j < stations[i].signalNumber; j++)
                {
                    Station.Signal sig = stations[i].signals[j];
                    Station.Signal.MouseArea a = sig.mouseArea;
                    if (x > a.left && x < a.right && y > a.top && y < a.bottom)
                    {
                        if (sig.status >= 2)
                        {
                            sig.status -= 2;

                            stations[i].DrawDynamicMap(g);
                            pb_界面图片.Image = bp;
                        }
                        return;
                    }
                }
            }
        }

        private void 报文丢失toolStripMenuItem_Click(object sender, EventArgs e)
        {
            int x, y;
            x = preMouse.x;
            y = preMouse.y;
            for (int i = 0; i < InitializationInformation.stationNum; i++)
            {
                for (int j = 0; j < stations[i].transponderGroups.Count; j++)
                {
                    Station.TransponderGroup t = stations[i].transponderGroups[j];
                    Station.TransponderGroup.MouseArea a = t.mouseArea;
                    if (x > a.left && x < a.right && y > a.top && y < a.bottom)
                    {
                        if (t.status==0)
                        {
                            t.status = 1;

                            stations[i].DrawDynamicMap(g);
                            pb_界面图片.Image = bp;
                        }
                        return;
                    }
                }
                if (i == InitializationInformation.stationNum - 1) continue;
                for (int j = 0; j < sections[i].XtransponderGroups.Count; j++)
                {
                    Section.TransponderGroup t = sections[i].XtransponderGroups[j];
                    Section.TransponderGroup.MouseArea a = t.mouseArea;
                    if (x > a.left && x < a.right && y > a.top && y < a.bottom)
                    {
                        if (t.status == 0)
                        {
                            t.status = 1;
                            sections[i].DrawDynamicMap(g);
                            pb_界面图片.Image = bp;
                        }
                        return;
                    }
                }
                for (int j = 0; j < sections[i].StransponderGroups.Count; j++)
                {
                    Section.TransponderGroup t = sections[i].StransponderGroups[j];
                    Section.TransponderGroup.MouseArea a = t.mouseArea;
                    if (x > a.left && x < a.right && y > a.top && y < a.bottom)
                    {
                        if (t.status == 0)
                        {
                            t.status = 1;
                            sections[i].DrawDynamicMap(g);
                            pb_界面图片.Image = bp;
                        }
                        return;
                    }
                }
            }
        }

        private void 报文正确ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int x, y;
            x = preMouse.x;
            y = preMouse.y;
            for (int i = 0; i < InitializationInformation.stationNum; i++)
            {
                for (int j = 0; j < stations[i].transponderGroups.Count; j++)
                {
                    Station.TransponderGroup t = stations[i].transponderGroups[j];
                    Station.TransponderGroup.MouseArea a = t.mouseArea;
                    if (x > a.left && x < a.right && y > a.top && y < a.bottom)
                    {
                        if (t.status == 1)
                        {
                            t.status = 0;
                            stations[i].DrawDynamicMap(g);
                            pb_界面图片.Image = bp;
                        }
                        return;
                    }
                }
                if (i == InitializationInformation.stationNum - 1) continue;
                for (int j = 0; j < sections[i].XtransponderGroups.Count; j++)
                {
                    Section.TransponderGroup t = sections[i].XtransponderGroups[j];
                    Section.TransponderGroup.MouseArea a = t.mouseArea;
                    if (x > a.left && x < a.right && y > a.top && y < a.bottom)
                    {
                        MessageBox.Show(t.transponders[0].name + " " + t.transponders[0].realPosition.ToString() + " "  + t.transponders[0].position.ToString());
                           
                        if (t.status == 1)
                        {
                            t.status = 0;
                            sections[i].DrawDynamicMap(g);
                            pb_界面图片.Image = bp;
                        }
                        return;
                    }
                }
                for (int j = 0; j < sections[i].StransponderGroups.Count; j++)
                {
                    Section.TransponderGroup t = sections[i].StransponderGroups[j];
                    Section.TransponderGroup.MouseArea a = t.mouseArea;
                    if (x > a.left && x < a.right && y > a.top && y < a.bottom)
                    {
                        if (t.status == 1)
                        {
                            t.status = 0;
                            sections[i].DrawDynamicMap(g);
                            pb_界面图片.Image = bp;
                        }
                        return;
                    }
                }
            }
        }

    }
}
