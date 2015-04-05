using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace 列控培训平台操控系统.车站
{
    partial class Station
    {
        public void DrawText(Graphics g, string s, int x, int y)
        {
            g.DrawString(s, DrawingInformation.font1, DrawingInformation.brush1, x - g.MeasureString(s, DrawingInformation.font1).Width / 2, y - g.MeasureString(s, DrawingInformation.font1).Height);
        }
        public void DrawStationName(Graphics g, string s, int x, int y)
        {
            g.DrawString(s, DrawingInformation.font2, DrawingInformation.brush1, x - g.MeasureString(s, DrawingInformation.font2).Width / 2, y - g.MeasureString(s, DrawingInformation.font2).Height);
        }
        public void DrawArrow(Graphics g, int x, int y)
        {
            int h = DrawingInformation.arrowHeight;
            PointF[] points = new PointF[3];
            points[0] = new PointF(x, y);
            points[1] = new PointF(x - h, y + h / 2);
            points[2] = new PointF(x - h, y - h / 2);
            g.DrawPolygon(DrawingInformation.p1, points);
            points[1] = new PointF(x + h, y + h / 2);
            points[2] = new PointF(x + h, y - h / 2);
            g.DrawPolygon(DrawingInformation.p1, points);
        }
        public void DrawStaticMap(Graphics g)
        {
            //画主轨并画上编号
            g.DrawLine(DrawingInformation.p1, coordinateStartX, coordinateIGY, coordinateEndX, coordinateIGY);
            g.DrawLine(DrawingInformation.p1, coordinateStartX, coordinateIGY + DrawingInformation.trackHeight, coordinateEndX, coordinateIGY + DrawingInformation.trackHeight);
            DrawText(g, "IG", coordinateCenterX, coordinateIGY);
            DrawText(g, "IIG", coordinateCenterX, coordinateIGY + DrawingInformation.trackHeight);
            //画站名
            DrawStationName(g, name, coordinateCenterX, coordinateIGY - XTrackNumber * DrawingInformation.trackHeight);
            //画箭头
            DrawArrow(g, coordinateCenterX, coordinateIGY);
            DrawArrow(g, coordinateCenterX, coordinateIGY + DrawingInformation.trackHeight);
            //画下行
            for (int i = 1; i < XTrackNumber; i++)
            {
                int lsw = xtracks[i].startSwitchNo;
                int rsw = xtracks[i].endSwitchNo;
                int ty = this.coordinateIGY - xtracks[i].trackNo / 2 * DrawingInformation.trackHeight;
                Switch sw1 = switchs[FindSwitchFromSwitchNo(lsw)];
                Switch sw2 = switchs[FindSwitchFromSwitchNo(rsw)];
                int h1 = sw1.coordinateY - ty;
                int h2 = sw2.coordinateY - ty;
                g.DrawLine(DrawingInformation.p1, sw1.coordinateX, sw1.coordinateY, sw1.coordinateX + (int)(h1 / DrawingInformation.scale), ty);
                g.DrawLine(DrawingInformation.p1, sw2.coordinateX, sw2.coordinateY, sw2.coordinateX - (int)(h2 / DrawingInformation.scale), ty);
                g.DrawLine(DrawingInformation.p1, sw1.coordinateX + (int)(h1 / DrawingInformation.scale), ty, sw2.coordinateX - (int)(h2 / DrawingInformation.scale), ty);
                DrawText(g, xtracks[i].name, coordinateCenterX, ty);
                DrawArrow(g, coordinateCenterX, ty);
            }
            //画上行
            for (int i = 1; i < STrackNumber; i++)
            {
                int lsw = stracks[i].startSwitchNo;
                int rsw = stracks[i].endSwitchNo;
                int ty = this.coordinateIGY + DrawingInformation.trackHeight + xtracks[i].trackNo / 2 * DrawingInformation.trackHeight;
                Switch sw1 = switchs[FindSwitchFromSwitchNo(lsw)];
                Switch sw2 = switchs[FindSwitchFromSwitchNo(rsw)];
                int h1 = sw1.coordinateY - ty;
                int h2 = sw2.coordinateY - ty;
                g.DrawLine(DrawingInformation.p1, sw1.coordinateX, sw1.coordinateY, sw1.coordinateX - (int)(h1 / DrawingInformation.scale), ty);
                g.DrawLine(DrawingInformation.p1, sw2.coordinateX, sw2.coordinateY, sw2.coordinateX + (int)(h2 / DrawingInformation.scale), ty);
                g.DrawLine(DrawingInformation.p1, sw1.coordinateX - (int)(h1 / DrawingInformation.scale), ty, sw2.coordinateX + (int)(h2 / DrawingInformation.scale), ty);
                DrawText(g, stracks[i].name, coordinateCenterX, ty);
                DrawArrow(g, coordinateCenterX, ty);
            }
            for (int i = 0; i < crossoverNumber; i++)
            {
                Switch sw1 = switchs[FindSwitchFromSwitchNo(crossovers[i].startSwitchNo)];
                Switch sw2 = switchs[FindSwitchFromSwitchNo(crossovers[i].endSwitchNo)];
                g.DrawLine(DrawingInformation.p1, sw1.coordinateX, sw1.coordinateY, sw2.coordinateX, sw2.coordinateY);
            }
            for (int i = 0; i < signalNumber; i++)
            {
                DrawSignalAndBtn(g, signals[i]);
            }
            //画道岔的字，画道岔的圈圈
            for (int i = 0; i < switchNumber; i++)
            {
                Switch sw = switchs[i];
                DrawSwitchName(g, sw);
                Switch.MouseArea a = sw.mouseArea;
                g.FillEllipse(DrawingInformation.brush6, a.left, a.top, a.right - a.left, a.bottom - a.top);
            }

            for (int i = 0; i < insulationJointNumber; i++)
            {
                InsulationJoint ij = insulationJoints[i];
                g.DrawLine(DrawingInformation.p3, ij.x1, ij.y1, ij.x2, ij.y2);
            }
            //画应答器 
            for (int i = 0; i < transponderGroups.Count; i++)
            {
                DrawTransponderGroup(g, transponderGroups[i]);
                //for (int j = 0; j < transponderGroups[i].transponders.Count; j++)
                //{
                //    TransponderGroup.Transponder tp = transponderGroups[i].transponders[j];
                //    DrawTransponder(g, tp);
                //}
            }
            //MessageBox.Show("OK");
        }
        public void DrawTransponderGroup(Graphics g, TransponderGroup t)
        {
            Station.TransponderGroup.MouseArea a = t.mouseArea;
            g.FillRectangle(DrawingInformation.signalColorBrushB, a.left, a.top, a.right - a.left, a.bottom - a.top);
            
            int x = t.transponders[0].coordinateX;
            int y = t.transponders[0].coordinateY;
            if (t.transponders.Count >= 1)
                DrawTransponder(g, x, y);
            if (t.transponders.Count >= 2)
                DrawTransponder(g, x + DrawingInformation.transponderGap, y);
            if (t.transponders.Count >= 3)
                DrawTransponder(g, x + 2 * DrawingInformation.transponderGap, y);
            if (t.status == 1)
            {
                g.DrawLine(DrawingInformation.SignalEorrPen1, t.mouseArea.left + 2, t.mouseArea.top + 2, t.mouseArea.right - 2, t.mouseArea.bottom - 2);
                g.DrawLine(DrawingInformation.SignalEorrPen2, t.mouseArea.left + 2, t.mouseArea.top + 3, t.mouseArea.right - 2, t.mouseArea.bottom - 1);
                g.DrawLine(DrawingInformation.SignalEorrPen2, t.mouseArea.left + 2, t.mouseArea.top + 1, t.mouseArea.right - 2, t.mouseArea.bottom - 3);
                g.DrawLine(DrawingInformation.SignalEorrPen1, t.mouseArea.left + 2, t.mouseArea.bottom - 2, t.mouseArea.right - 2, t.mouseArea.top + 2);
                g.DrawLine(DrawingInformation.SignalEorrPen2, t.mouseArea.left + 2, t.mouseArea.bottom - 3, t.mouseArea.right - 2, t.mouseArea.top + 1);
                g.DrawLine(DrawingInformation.SignalEorrPen2, t.mouseArea.left + 2, t.mouseArea.bottom - 1, t.mouseArea.right - 2, t.mouseArea.top + 3);
            }
        }
        public void DrawTransponder(Graphics g, TransponderGroup.Transponder t)
        {
            Pen p = DrawingInformation.transponderPen;
            int len = DrawingInformation.transponderLen;
            int x = t.coordinateX;
            int y = t.coordinateY;
            g.DrawLine(p, x, y, x + len, y + len * 14 / 9);
            g.DrawLine(p, x + len, y + len * 14 / 9, x - len, y + len * 14 / 9);
            g.DrawLine(p, x, y, x - len, y + len * 14 / 9);
        }
        public void DrawTransponder(Graphics g, int x, int y)
        {
            Pen p = DrawingInformation.transponderPen;
            int len = DrawingInformation.transponderLen;
            g.DrawLine(p, x, y, x + len, y + len * 14 / 9);
            g.DrawLine(p, x + len, y + len * 14 / 9, x - len, y + len * 14 / 9);
            g.DrawLine(p, x, y, x - len, y + len * 14 / 9);
        }
        public void DrawSwitchName(Graphics g, Switch sw)
        {
            Font font = DrawingInformation.font1;
            SolidBrush brush;
            if (sw.status == 0)
                brush = (SolidBrush)DrawingInformation.brush3;
            else if (sw.status == 1)
                brush = (SolidBrush)DrawingInformation.brush4;
            else
                brush = (SolidBrush)DrawingInformation.brush5;
            switch (sw.type)
            {
                case 1:
                    g.DrawString(sw.no.ToString(), font, brush, sw.coordinateX + g.MeasureString(sw.no.ToString(), font).Height, sw.coordinateY - g.MeasureString(sw.no.ToString(), font).Height);
                    break;
                case 2:
                    g.DrawString(sw.no.ToString(), font, brush, sw.coordinateX - g.MeasureString(sw.no.ToString(), font).Height - g.MeasureString(sw.no.ToString(), font).Width, sw.coordinateY);
                    break;
                case 3:
                    g.DrawString(sw.no.ToString(), font, brush, sw.coordinateX - g.MeasureString(sw.no.ToString(), font).Height - g.MeasureString(sw.no.ToString(), font).Width, sw.coordinateY - g.MeasureString(sw.no.ToString(), font).Height);
                    break;
                case 4:
                    g.DrawString(sw.no.ToString(), font, brush, sw.coordinateX + g.MeasureString(sw.no.ToString(), font).Height, sw.coordinateY);
                    break;
                default:
                    break;
            }
        }
        public void ClearDg(Graphics g, DG dg)
        {
            Pen p = new Pen(Color.Black, DrawingInformation.p1.Width);
            for (int i = 0; i < dg.branchNumber; i++)
            {
                for (int j = 0; j < dg.branchs[i].pointNumber - 1; j++)
                {
                    DG.Branch.Point p1 = dg.branchs[i].points[j];
                    DG.Branch.Point p2 = dg.branchs[i].points[j + 1];
                    g.DrawLine(p, p1.X, p1.Y, p2.X, p2.Y);
                }
            }
            p.Dispose();
        }
        public void DrawDg(Graphics g, DG dg)
        {
            if (dg.status == 0 || dg.status == 1)
            {
                DrawDgWithSW(g, dg);
            }
            else if (dg.status == 2 || dg.status == 3)
            {
                DrawDgWithOutSW(g, dg);
                Pen p;
                if (dg.status == 2)
                    p = DrawingInformation.p6;
                else if (dg.status == 3)
                    p = DrawingInformation.p5;
                else
                {
                    p = DrawingInformation.p5;
                    MessageBox.Show("dg还能上4？");
                }
                int Length = DrawingInformation.switchLen;
                for (int i = 0; i < dg.branchs[dg.branchPos].pointNumber - 1; i++)
                {
                    DG.Branch.Point p1 = dg.branchs[dg.branchPos].points[i];
                    DG.Branch.Point p2 = dg.branchs[dg.branchPos].points[i + 1];
                    int stx = p1.X;
                    int sty = p1.Y;
                    int enx = p2.X;
                    int eny = p2.Y;
                    int dx = enx - stx;
                    int dy = eny - sty;
                    double dis = Math.Sqrt(dx * dx + dy * dy);
                    if (p1.type == 3)
                    {
                        int swpos = p1.pos;
                        Switch sw = switchs[swpos];
                        if (sw.status >= 2)
                        {
                            if (sw.type == 1 || sw.type == 4)
                            {
                                stx += (int)(Length / dis * dx);
                                sty += (int)(Length / dis * dy);
                            }
                        }
                    }
                    if(p2.type == 3)
                    {
                        int swpos = p2.pos;
                        Switch sw = switchs[swpos];
                        if (sw.status >= 2)
                        {
                            if (sw.type == 2 || sw.type == 3)
                            {
                                enx -= (int)(Length / dis * dx);
                                eny -= (int)(Length / dis * dy);
                            }
                        }
                    }
                    g.DrawLine(p, stx, sty, enx, eny);
                }

            }
        }
        public void DrawDgWithSW(Graphics g, DG dg)
        {
            Pen p = DrawingInformation.p1;
            int Length = DrawingInformation.switchLen;
            for (int i = 0; i < dg.branchNumber; i++)
            {
                for (int j = 0; j < dg.branchs[i].pointNumber - 1; j++)
                {
                    DG.Branch.Point p1 = dg.branchs[i].points[j];
                    DG.Branch.Point p2 = dg.branchs[i].points[j + 1];
                    int stx = p1.X;
                    int sty = p1.Y;
                    int enx = p2.X;
                    int eny = p2.Y;
                    int dx = enx - stx;
                    int dy = eny - sty;
                    double dis = Math.Sqrt(dx * dx + dy * dy);
                    if (p1.type == 3)
                    {
                        int swpos = p1.pos;
                        Switch sw = switchs[swpos];
                        if (sw.type == 1 || sw.type == 4)
                        {

                            if (sw.status == 0) //道岔定位
                            {
                                if (Math.Abs(dy) > 5)
                                {
                                    stx += (int)(Length / dis * dx);
                                    sty += (int)(Length / dis * dy);
                                }
                            }
                            else if (sw.status == 1)
                            {
                                if (Math.Abs(dy) < 5)
                                {
                                    stx += (int)(Length / dis * dx);
                                    sty += (int)(Length / dis * dy);
                                }
                            }
                            else if (sw.status == 2 || sw.status == 3)
                            {
                                stx += (int)(Length / dis * dx);
                                sty += (int)(Length / dis * dy);
                            }
                        }
                    }
                    if (p2.type == 3)
                    {
                        int swpos = p2.pos;
                        Switch sw = switchs[swpos];
                        if (sw.type == 2 || sw.type == 3)
                        {
                            if (sw.status == 0)
                            {
                                if (Math.Abs(dy) > 5)
                                {
                                    enx -= (int)(Length / dis * dx);
                                    eny -= (int)(Length / dis * dy);
                                }
                            }
                            else if (sw.status == 1)
                            {
                                if (Math.Abs(dy) < 5)
                                {
                                    enx -= (int)(Length / dis * dx);
                                    eny -= (int)(Length / dis * dy);
                                }
                            }
                            else if (sw.status == 2 || sw.status == 3)
                            {
                                enx -= (int)(Length / dis * dx);
                                eny -= (int)(Length / dis * dy);
                            }
                        }
                    }
                    if (dg.status == 1)
                        p = DrawingInformation.p5;
                    g.DrawLine(p, stx, sty, enx, eny);
                }
            }
        }
        public void DrawDgWithOutSW(Graphics g, DG dg)
        {
            Pen p = DrawingInformation.p1;
            int Length = DrawingInformation.switchLen;
            for (int i = 0; i < dg.branchNumber; i++)
            {
                for (int j = 0; j < dg.branchs[i].pointNumber - 1; j++)
                {
                    DG.Branch.Point p1 = dg.branchs[i].points[j];
                    DG.Branch.Point p2 = dg.branchs[i].points[j + 1];
                    int stx = p1.X;
                    int sty = p1.Y;
                    int enx = p2.X;
                    int eny = p2.Y;
                    int dx = enx - stx;
                    int dy = eny - sty;
                    double dis = Math.Sqrt(dx * dx + dy * dy);
                    if (p1.type == 3)
                    {
                        int swpos = p1.pos;
                        Switch sw = switchs[swpos];
                        if (sw.type == 1 || sw.type == 4)
                        {
                            stx += (int)(Length / dis * dx);
                            sty += (int)(Length / dis * dy);
                        }
                    }
                    if (p2.type == 3)
                    {
                        int swpos = p2.pos;
                        Switch sw = switchs[swpos];
                        if (sw.type == 2 || sw.type == 3)
                        {
                            enx -= (int)(Length / dis * dx);
                            eny -= (int)(Length / dis * dy);
                        }
                    }
                    g.DrawLine(p, stx, sty, enx, eny);
                }
            }
        }
        public void DrawDynamicMap(Graphics g)
        {
            for (int i = 0; i < dgNumber; i++)
            {
                DG dg = dgs[i];
                ClearDg(g, dg);
                DrawDg(g, dg);
            }
            for (int i = 0; i < switchNumber; i++)
            {
                DrawSwitchName(g, switchs[i]);
            }
            for (int i = 0; i < signalNumber; i++)
            {
                DrawSignalColor(g, signals[i]);
            }

            for (int i = 0; i < transponderGroups.Count; i++)
            {

                DrawTransponderGroup(g, transponderGroups[i]);
                //for (int j = 0; j < transponderGroups[i].transponders.Count; j++)
                //{
                //    Station.TransponderGroup.Transponder t = transponderGroups[i].transponders[j];
                //    DrawTransponder(g, t);
                //}
            }
        }
        public void FillEllipses(Graphics g, Brush brush, Pen p, int a, int b, int c, int d)
        {
            g.FillEllipse(brush, a, b, c, d); //填充内部
            g.DrawEllipse(p, a, b, c, d);     //外部画圆
        }
        public void DrawSignalBtnUp(Graphics g, Signal sig)
        {
            int X = sig.BtnX;
            int Y = sig.BtnY;
            SolidBrush b = (SolidBrush)DrawingInformation.brush2;
            Pen p = DrawingInformation.p2; ;
            int len = DrawingInformation.signalBtnLen;
            g.FillRectangle(b, X, Y, len, len);
            g.DrawRectangle(p, X, Y, len, len);
            //p.Color = Color.White;
            Pen p1 = new Pen(Color.White, p.Width - 2);
            g.DrawLine(p1, X, Y, X + len, Y);
            g.DrawLine(p1, X, Y, X, Y + len);
            g.DrawLine(p1, X, Y + 1, X + len, Y + 1);
            g.DrawLine(p1, X + 1, Y, X + 1, Y + len);
        }
        public void DrawSignalBtnDown(Graphics g, Signal sig)
        {
            int X = sig.BtnX;
            int Y = sig.BtnY;
            SolidBrush b = (SolidBrush)DrawingInformation.brush7;
            Pen p = DrawingInformation.p4;
            int len = DrawingInformation.signalBtnLen;
            g.FillRectangle(b, X, Y, len, len);
            g.DrawRectangle(p, X, Y, len, len);
            Pen p1 = new Pen(Color.White, p.Width - 1);
            X = X + len;
            Y = Y + len;
            g.DrawLine(p1, X, Y, X - len, Y);
            g.DrawLine(p1, X, Y, X, Y - len);
            g.DrawLine(p1, X, Y - 1, X - len, Y - 1);
            g.DrawLine(p1, X - 1, Y, X - 1, Y - len);
            g.DrawLine(p1, X, Y + 1, X - len, Y + 1);
            g.DrawLine(p1, X + 1, Y, X + 1, Y - len);
        }
        public void DrawSignalAndBtn(Graphics g, Signal signal)
        {
            int X = signal.coordinateX;
            int Y = signal.coordinateY;
            int R = DrawingInformation.signalRadiu;
            Font font = DrawingInformation.font1;
            SolidBrush brush = new SolidBrush(Color.Red);
            SolidBrush brush1 = (SolidBrush)DrawingInformation.brush1;
            Pen p = new Pen(DrawingInformation.p1.Color, 1);

            string s;

            if (signal.dir == 0)
            {
                g.DrawLine(p, X, Y + R / 2, X, Y - R / 2);
                g.DrawLine(p, X, Y - R, X, Y - 3 * R);
                g.DrawLine(p, X, Y - 2 * R, X + R, Y - 2 * R);
                FillEllipses(g, brush, p, X + R / 2, Y - 3 * R, 2 * R, 2 * R);
                FillEllipses(g, brush, p, X + 2 * R + R / 2, Y - 3 * R, 2 * R, 2 * R);
                s = signal.name;
                g.DrawString(s, font, brush1, X, Y - 3 * R - DrawingInformation.p1.Width - g.MeasureString(s, font).Height);
                DrawSignalBtnUp(g, signal);
            }
            else
            {
                g.DrawLine(p, X, Y + R / 2, X, Y - R / 2);
                g.DrawLine(p, X, Y + R, X, Y + 3 * R);
                g.DrawLine(p, X, Y + 2 * R, X - R, Y + 2 * R);
                FillEllipses(g, brush, p, X - 2 * R - R / 2, Y + 1 * R, 2 * R, 2 * R);
                FillEllipses(g, brush, p, X - 4 * R - R / 2, Y + 1 * R, 2 * R, 2 * R);
                s = signal.name;
                g.DrawString(s, font, brush1, X - g.MeasureString(s, font).Width, Y + 3 * R + DrawingInformation.p1.Width);
                DrawSignalBtnUp(g, signal);
            }
        }
        public void DrawSignalColor(Graphics g, Signal signal)
        {
            int X = signal.coordinateX;
            int Y = signal.coordinateY;
            int R = DrawingInformation.signalRadiu;
            SolidBrush brush1 = (SolidBrush)DrawingInformation.signalColorBrushH;
            SolidBrush brush2 = (SolidBrush)DrawingInformation.signalColorBrushH;
            Signal.MouseArea a = signal.mouseArea;
            g.FillRectangle(DrawingInformation.signalColorBrushB, a.left, a.top, a.right - a.left, a.bottom - a.top);
            if (signal.status >= 1)
            {
                if (signal.color == "UU")
                {
                    brush1 = (SolidBrush)DrawingInformation.signalColorBrushU;
                    brush2 = (SolidBrush)DrawingInformation.signalColorBrushU;
                }
                else if (signal.color == "L")
                {
                    brush1 = (SolidBrush)DrawingInformation.signalColorBrushL;
                    brush2 = (SolidBrush)DrawingInformation.signalColorBrushB;
                }
                else if (signal.color == "U")
                {
                    brush1 = (SolidBrush)DrawingInformation.signalColorBrushU;
                    brush2 = (SolidBrush)DrawingInformation.signalColorBrushB;
                }
            }
            else if (signal.status == 2)
            {
                //已经是双红了
            }
            Pen p = new Pen(DrawingInformation.p1.Color, 1);
            if (signal.dir == 0)
            {
                FillEllipses(g, brush1, p, X + R / 2, Y - 3 * R, 2 * R, 2 * R);
                FillEllipses(g, brush2, p, X + 2 * R + R / 2, Y - 3 * R, 2 * R, 2 * R);
            }
            else
            {
                FillEllipses(g, brush1, p, X - 2 * R - R / 2, Y + 1 * R, 2 * R, 2 * R);
                FillEllipses(g, brush2, p, X - 4 * R - R / 2, Y + 1 * R, 2 * R, 2 * R);
            }
            if (signal.status >= 2)
            {
                g.DrawLine(DrawingInformation.SignalEorrPen1, signal.mouseArea.left + 2, signal.mouseArea.top + 2, signal.mouseArea.right - 2, signal.mouseArea.bottom - 2);
                g.DrawLine(DrawingInformation.SignalEorrPen2, signal.mouseArea.left + 2, signal.mouseArea.top + 3, signal.mouseArea.right - 2, signal.mouseArea.bottom - 1);
                g.DrawLine(DrawingInformation.SignalEorrPen2, signal.mouseArea.left + 2, signal.mouseArea.top + 1, signal.mouseArea.right - 2, signal.mouseArea.bottom - 3);
                g.DrawLine(DrawingInformation.SignalEorrPen1, signal.mouseArea.left + 2, signal.mouseArea.bottom - 2, signal.mouseArea.right - 2, signal.mouseArea.top + 2);
                g.DrawLine(DrawingInformation.SignalEorrPen2, signal.mouseArea.left + 2, signal.mouseArea.bottom - 3, signal.mouseArea.right - 2, signal.mouseArea.top + 1);
                g.DrawLine(DrawingInformation.SignalEorrPen2, signal.mouseArea.left + 2, signal.mouseArea.bottom - 1, signal.mouseArea.right - 2, signal.mouseArea.top + 3);
            
            }
        }
    }
}
