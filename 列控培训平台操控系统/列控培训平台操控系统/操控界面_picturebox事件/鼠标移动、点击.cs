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
        /// <summary>
        /// 最后鼠标所在picturebox位置
        /// </summary>
        private class PreMousePlace
        {
            public int x, y;
        }
        private PreMousePlace preMouse = new PreMousePlace();

        private void pb_界面图片_MouseMove(object sender, MouseEventArgs e)
        {
            int x, y;
            #region 拖动图片
            if (isMouseDown)
            {
                int dx = e.X - preMouse.x;
                int dy = e.Y - preMouse.y;
                y = panel_放置图片.VerticalScroll.Value + dy;
                x = panel_放置图片.HorizontalScroll.Value + dx;

                if (x > panel_放置图片.HorizontalScroll.Minimum && x < panel_放置图片.HorizontalScroll.Maximum)
                    panel_放置图片.HorizontalScroll.Value += dx;
                if (y > panel_放置图片.VerticalScroll.Minimum && y < panel_放置图片.VerticalScroll.Maximum)
                    panel_放置图片.VerticalScroll.Value += dy / 6;
                preMouse.x = e.X;
                preMouse.y = e.Y;
                return;
            }
            #endregion

            x = e.X;
            y = e.Y;
            preMouse.x = x;
            preMouse.y = y;
            for (int i = 0; i < InitializationInformation.stationNum; i++)
            {
                #region 判定是否在信号机按钮区域
                for (int j = 0; j < stations[i].signalNumber; j++)
                {
                    Station.Signal sig = stations[i].signals[j];
                    if (x > sig.BtnX && y > sig.BtnY && x < sig.BtnX + DrawingInformation.signalBtnLen && y < sig.BtnY + DrawingInformation.signalBtnLen)
                    {
                        this.Cursor = System.Windows.Forms.Cursors.Hand;
                        return;
                    }
                    Station.Signal.MouseArea a = stations[i].signals[j].mouseArea;
                    if (x > a.left && x < a.right && y > a.top && y < a.bottom)
                    {
                        this.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.pb_界面图片.ContextMenuStrip = cms_关联车站信号机;
                        return;
                    }
                }
                #endregion
                #region 判定是否在道岔区域
                for (int j = 0; j < stations[i].switchNumber; j++)
                {
                    Station.Switch.MouseArea a = stations[i].switchs[j].mouseArea;
                    if (x > a.left && x < a.right && y > a.top && y < a.bottom)
                    {
                        this.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.pb_界面图片.ContextMenuStrip = cms_关联车站道岔;
                        return;
                    }
                }
                #endregion
                #region 判定是否在车站应答器区域
                for (int j = 0; j < stations[i].transponderGroups.Count; j++)
                {
                    Station.TransponderGroup tg = stations[i].transponderGroups[j];

                    Station.TransponderGroup.MouseArea a = tg.mouseArea;
                    if (x > a.left && x < a.right && y > a.top && y < a.bottom)
                    {
                        this.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.pb_界面图片.ContextMenuStrip = cms_关联车站应答器;
                        return;
                    }
                }
                #endregion
                #region 判定是否在DG区域
                for (int j = 0; j < stations[i].dgNumber; j++)
                {
                    Station.DG dg = stations[i].dgs[j];
                    for (int k = 0; k < dg.branchNumber; k++)
                    {
                        Station.DG.Branch.MouseArea a = dg.branchs[k].mouseArea;
                        if (x > a.left && x < a.right && y > a.top && y < a.bottom)
                        {
                            this.Cursor = System.Windows.Forms.Cursors.Cross;
                            this.pb_界面图片.ContextMenuStrip = cms_关联股道;
                            return;
                        }
                    }
                }
                #endregion
                if (i == InitializationInformation.stationNum - 1) continue;
                #region 判定是否在区间轨道电路区域
                for (int j = 0; j < sections[i].Xtracks.Count; j++)
                {
                    Section.Track.MouseArea a = sections[i].Xtracks[j].mouseArea;
                    if (x > a.left && x < a.right && y > a.top && y < a.bottom)
                    {
                        this.Cursor = System.Windows.Forms.Cursors.Cross;
                        this.pb_界面图片.ContextMenuStrip = cms_关联股道;
                        return;
                    }
                }
                for (int j = 0; j < sections[i].Stracks.Count; j++)
                {
                    Section.Track.MouseArea a = sections[i].Stracks[j].mouseArea;
                    if (x > a.left && x < a.right && y > a.top && y < a.bottom)
                    {
                        this.Cursor = System.Windows.Forms.Cursors.Cross;
                        this.pb_界面图片.ContextMenuStrip = cms_关联股道;
                        return;
                    }
                }
                for (int j = 0; j < sections[i].StransponderGroups.Count; j++)
                {
                    //for (int k = 0; k < sections[i].StransponderGroups[j].transponders.Count; k++)
                    //{
                    //    Section.TransponderGroup.Transponder.MouseArea a = sections[i].StransponderGroups[j].transponders[k].mouseArea;
                    //    if (x > a.left && x < a.right && y > a.top && y < a.bottom)
                    //    {
                    //        this.Cursor = System.Windows.Forms.Cursors.Hand;
                    //        AssociateTransponder(sections[i].StransponderGroups[j]);
                    //        return;
                    //    }
                    //}
                    Section.TransponderGroup.MouseArea a = sections[i].StransponderGroups[j].mouseArea;
                    if (x > a.left && x < a.right && y > a.top && y < a.bottom)
                    {
                        this.Cursor = System.Windows.Forms.Cursors.Hand;
                        AssociateTransponder(sections[i].StransponderGroups[j]);
                        return;
                    }
                }
                for (int j = 0; j < sections[i].XtransponderGroups.Count; j++)
                {
                    //for (int k = 0; k < sections[i].XtransponderGroups[j].transponders.Count; k++)
                    //{
                    //    Section.TransponderGroup.Transponder.MouseArea a = sections[i].XtransponderGroups[j].transponders[k].mouseArea;
                    //    if (x > a.left && x < a.right && y > a.top && y < a.bottom)
                    //    {
                    //        this.Cursor = System.Windows.Forms.Cursors.Hand;
                    //        AssociateTransponder(sections[i].XtransponderGroups[j]);
                    //        return;
                    //    }
                    //}
                    Section.TransponderGroup.MouseArea a = sections[i].XtransponderGroups[j].mouseArea;
                    if (x > a.left && x < a.right && y > a.top && y < a.bottom)
                    {
                        this.Cursor = System.Windows.Forms.Cursors.Hand;
                        AssociateTransponder(sections[i].XtransponderGroups[j]);
                        return;
                    }
                }
                #endregion
            }
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pb_界面图片.ContextMenuStrip = cms_关联空白地方;
        }
        private void AssociateTransponder(Section.TransponderGroup t)
        {
            if (t.transponders.Count == 1)
            {
                this.pb_界面图片.ContextMenuStrip = cms_关联区间应答器1;
            }
            else if (t.transponders.Count == 2)
            {

                this.pb_界面图片.ContextMenuStrip = cms_关联区间应答器2;
            }
            else if (t.transponders.Count == 3)
            {
                this.pb_界面图片.ContextMenuStrip = cms_关联区间应答器3;
            }
            else MessageBox.Show("应答器太多了吧");
        }
        private void pb_界面图片_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;
            for (int i = 0; i < InitializationInformation.stationNum; i++)
            {
                #region 判定是否在信号机按钮区域
                for (int j = 0; j < stations[i].signalNumber; j++)
                {
                    Station.Signal sig = stations[i].signals[j];
                    if (x > sig.BtnX && y > sig.BtnY && x < sig.BtnX + DrawingInformation.signalBtnLen && y < sig.BtnY + DrawingInformation.signalBtnLen)
                    {
                        btnDowns.Add(new BtnDown(i, j, sig.name + "LA"));
                        stations[i].DrawSignalBtnDown(g, sig);
                        pb_界面图片.Image = bp;
                        return;
                    }
                }
                #endregion
                #region 判断是否在道岔区域
                if ((tsbtn_道岔总反.CheckState == CheckState.Checked) || (tsbtn_道岔总定.CheckState == CheckState.Checked))
                {
                    for (int j = 0; j < stations[i].switchNumber; j++)
                    {
                        Station.Switch sw = stations[i].switchs[j];
                        Station.Switch.MouseArea a = sw.mouseArea;
                        if (x > a.left && x < a.right && y > a.top && y < a.bottom)
                        {
                            if (sw.isLock == 1)
                            {
                                MessageBox.Show("道岔已经锁闭无法操作");
                                return;
                            }
                            if (tsbtn_道岔总定.CheckState == CheckState.Checked)
                            {
                                if (sw.status == 0)
                                {
                                    MessageBox.Show("已经是定位了");
                                }
                                else
                                {
                                    sw.status = 0;
                                    stations[i].DrawDynamicMap(g);
                                }
                            }
                            else if (tsbtn_道岔总反.CheckState == CheckState.Checked)
                            {
                                if (sw.status == 1)
                                {
                                    MessageBox.Show("已经是反位了");
                                }
                                else
                                {
                                    sw.status = 1;
                                    stations[i].DrawDynamicMap(g);
                                }
                            }
                            pb_界面图片.Image = bp;
                        }

                    }
                }
                #endregion
                #region 判定是否在DG区域
                for (int j = 0; j < stations[i].dgNumber; j++)
                {
                    Station.DG dg = stations[i].dgs[j];
                    for (int k = 0; k < dg.branchNumber; k++)
                    {
                        Station.DG.Branch.MouseArea a = dg.branchs[k].mouseArea;
                        if (x > a.left && x < a.right && y > a.top && y < a.bottom)
                        {
                            if (tsbtn_区故解.CheckState == CheckState.Checked)
                                区段故障解锁ToolStripMenuItem_Click(new object(), new EventArgs());
                            return;
                        }
                    }
                }
                #endregion
            }
            this.Cursor = System.Windows.Forms.Cursors.Arrow;

        }
    }
}
