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
        /// <summary>
        /// 计算精确位置
        /// </summary>
        public int position;
        public int startPosition;
        public int endPosition;
        public void SignalDevicePositionCalculation()
        {
            position = kilometerPost * 1000 + offset;
            for (int i = 0; i < signalNumber; i++)
            {
                signals[i].position = position + signals[i].offset;
            }
            for (int i = 0; i < switchNumber; i++)
            {
                switchs[i].position = position + switchs[i].offset;
            }
            startPosition = signals[0].position;
            endPosition = signals[signalNumber - 1].position;

        }

        public int coordinateOffsetX;
        public int coordinateOffsetY;
        public int coordinateCenterX;
        public int coordinateStartX;
        public int coordinateEndX;
        public int coordinateIGY;

        public void SignalDeviceCoordinatesCalculation(int coordinateOffsetX, int coordinateOffsetY)
        {
            #region 车站坐标的一些信息
            this.coordinateOffsetX = coordinateOffsetX;
            this.coordinateOffsetY = coordinateOffsetY;
            this.coordinateCenterX = coordinateOffsetX + (int)((long)(position - startPosition) * DrawingInformation.pixelsPerKilometer / 1000); //注意相乘可能越界
            this.coordinateStartX = coordinateOffsetX;
            this.coordinateEndX = coordinateOffsetX + (int)((long)(endPosition - startPosition) * DrawingInformation.pixelsPerKilometer / 1000);
            this.coordinateIGY = coordinateOffsetY;
            #endregion
            #region 计算道岔的坐标
            //道岔坐标
            for (int i = 0; i < switchNumber; i++)
            {
                Switch sw = switchs[i];
                sw.coordinateX = coordinateOffsetX + (int)((long)(sw.position - startPosition) * DrawingInformation.pixelsPerKilometer / 1000);
                if (sw.trackNo % 2 == 0)
                    sw.coordinateY = coordinateIGY + sw.trackNo / 2 * DrawingInformation.trackHeight;
                else sw.coordinateY = coordinateIGY - sw.trackNo / 2 * DrawingInformation.trackHeight;
                sw.mouseArea.left = sw.coordinateX - DrawingInformation.switchAreaLen;
                sw.mouseArea.right = sw.coordinateX + DrawingInformation.switchAreaLen;
                sw.mouseArea.top = sw.coordinateY - DrawingInformation.switchAreaLen;
                sw.mouseArea.bottom = sw.coordinateY + DrawingInformation.switchAreaLen;
            }
            #endregion
            #region 计算信号机的坐标
            //信号机坐标
            for (int i = 0; i < signalNumber; i++)
            {
                Signal sig = signals[i];
                sig.coordinateX = coordinateOffsetX + (int)((long)(sig.position - startPosition) * DrawingInformation.pixelsPerKilometer / 1000);
                if (sig.trackNo % 2 == 0)
                    sig.coordinateY = coordinateIGY + sig.trackNo / 2 * DrawingInformation.trackHeight;
                else sig.coordinateY = coordinateIGY - sig.trackNo / 2 * DrawingInformation.trackHeight;

                if (sig.dir == 0)
                {
                    sig.BtnX = sig.coordinateX - DrawingInformation.signalBtnLen * 3 / 2;
                    sig.BtnY = sig.coordinateY - DrawingInformation.signalBtnLen * 2;

                    #region 信号机色灯区域
                    int X = sig.coordinateX;
                    int Y = sig.coordinateY;
                    int R = DrawingInformation.signalRadiu;

                    sig.mouseArea.left = X + R / 2;
                    sig.mouseArea.top = Y - 3 * R;
                    sig.mouseArea.right = X + 4 * R + R / 2;
                    sig.mouseArea.bottom = Y - R;
                    #endregion
                }
                else
                {
                    sig.BtnX = sig.coordinateX + DrawingInformation.signalBtnLen / 2;
                    sig.BtnY = sig.coordinateY + DrawingInformation.signalBtnLen;

                    #region 信号机色灯区域
                    int X = sig.coordinateX;
                    int Y = sig.coordinateY;
                    int R = DrawingInformation.signalRadiu;

                    sig.mouseArea.left = X - 4 * R - R / 2;
                    sig.mouseArea.top = Y + 1 * R;
                    sig.mouseArea.right = X - R / 2;
                    sig.mouseArea.bottom = Y + 3 * R;
                    #endregion 
                }
            }
            #endregion
            #region 计算虚拟点的坐标
            //虚拟点坐标
            for (int i = 0; i < dummyPointNumber; i++)
            {
                DummyPoint dp = dummyPoints[i];
                Switch sw = switchs[FindSwitchFromSwitchNo(dp.refSwitchNo)];
                int h = DrawingInformation.trackHeight * (dp.trackNo - sw.trackNo) / 2;
                switch (dp.refDir)
                {
                    case 1:
                        dp.coordinateX = sw.coordinateX - (int)(h / DrawingInformation.scale);
                        break;
                    case 2:
                        dp.coordinateX = sw.coordinateX + (int)(h / DrawingInformation.scale);
                        break;
                    case 3:
                        dp.coordinateX = sw.coordinateX + (int)(h / DrawingInformation.scale);
                        break;
                    case 4:
                        dp.coordinateX = sw.coordinateX - (int)(h / DrawingInformation.scale);
                        break;
                    default:
                        MessageBox.Show("虚拟点有问题");
                        break;
                }
                if (dp.trackNo % 2 == 0)
                    dp.coordinateY = coordinateIGY + dp.trackNo / 2 * DrawingInformation.trackHeight;
                else dp.coordinateY = coordinateIGY - dp.trackNo / 2 * DrawingInformation.trackHeight;
            }
            #endregion
            #region 计算绝缘节的坐标
            //绝缘节坐标
            for (int i = 0; i < insulationJointNumber; i++)
            {
                InsulationJoint ij = insulationJoints[i];
                int x1, x2, y1, y2;
                if (ij.leftSwitchNo == 0)
                {
                    Signal sig = signals[FindSignalFromName(ij.leftSignalName)];
                    x1 = sig.coordinateX;
                    y1 = sig.coordinateY;
                }
                else
                {
                    if (ij.leftSwitchNo > 900)
                    {
                        DummyPoint dp = dummyPoints[FindDummyPointFromName(ij.leftSwitchNo)];
                        x1 = dp.coordinateX;
                        y1 = dp.coordinateY;
                    }
                    else
                    {
                        Switch sw = switchs[FindSwitchFromSwitchNo(ij.leftSwitchNo)];
                        x1 = sw.coordinateX;
                        y1 = sw.coordinateY;
                    }
                }
                if (ij.rightSwitchNo == 0)
                {
                    Signal sig = signals[FindSignalFromName(ij.rightSignalName)];
                    x2 = sig.coordinateX;
                    y2 = sig.coordinateY;
                }
                else
                {
                    Switch sw = switchs[FindSwitchFromSwitchNo(ij.rightSwitchNo)];
                    x2 = sw.coordinateX;
                    y2 = sw.coordinateY;
                }
                ij.coordinateX = (x1 + x2) / 2;
                ij.coordinateY = (y1 + y2) / 2;
                ij.x1 = ij.coordinateX - (int)(1.0 * DrawingInformation.insulationJointLen / 2 * (y2 - y1) / Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1)));
                ij.y1 = ij.coordinateY + (int)(1.0 * DrawingInformation.insulationJointLen / 2 * (x2 - x1) / Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1)));
                ij.x2 = ij.coordinateX + (int)(1.0 * DrawingInformation.insulationJointLen / 2 * (y2 - y1) / Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1)));
                ij.y2 = ij.coordinateY - (int)(1.0 * DrawingInformation.insulationJointLen / 2 * (x2 - x1) / Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1)));
            }
            #endregion
            #region 计算股道分支的每一个点的坐标，和鼠标点击区域
            //计算股道的具体坐标点和mouseArea
            for (int i = 0; i < dgNumber; i++)
            {
                DG dg = dgs[i];
                for (int j = 0; j < dg.branchNumber; j++)
                {
                    DG.Branch b = dg.branchs[j];
                    for (int k = 0; k < b.pointNumber; k++)
                    {
                        DG.Branch.Point p = b.points[k];
                        if (p.name[0] == 'X' || p.name[0] == 'S')
                        {
                            p.pos = FindSignalFromName(p.name);
                            Signal sig = signals[p.pos];
                            p.X = sig.coordinateX;
                            p.Y = sig.coordinateY;
                            p.type = 0;
                        }
                        else if ((p.name.Length == 3) && (p.name[0] == '9'))
                        {
                            p.pos = FindDummyPointFromName(ti(p.name));
                            DummyPoint dp = dummyPoints[p.pos];
                            p.X = dp.coordinateX;
                            p.Y = dp.coordinateY;
                            p.type = 1;
                        }
                        else if ((p.name.Length == 3) && (p.name[0] == '8'))
                        {
                            p.pos = FindInsulationJointFromName(p.name);
                            InsulationJoint ij = insulationJoints[p.pos];
                            p.X = ij.coordinateX;
                            p.Y = ij.coordinateY;
                            p.type = 2;
                        }
                        else
                        {
                            p.pos = FindSwitchFromSwitchNo(ti(p.name));
                            Switch sw = switchs[p.pos];
                            p.X = sw.coordinateX;
                            p.Y = sw.coordinateY;
                            p.type = 3;
                        }
                    }
                    int tmpx1, tmpx2, tmpy1, tmpy2;
                    tmpx1 = b.points[0].X;
                    tmpy1 = b.points[0].Y;
                    tmpx2 = b.points[b.pointNumber - 1].X;
                    tmpy2 = b.points[b.pointNumber - 1].Y;
                    if (Math.Abs(tmpy1 - tmpy2) < 3)
                    {
                        b.mouseArea.left = tmpx1;
                        b.mouseArea.top = tmpy1 - DrawingInformation.trackAreaHeight;
                        b.mouseArea.right = tmpx2;
                        b.mouseArea.bottom = tmpy2 + DrawingInformation.trackAreaHeight;
                    }
                    else
                    {
                        if (tmpy1 < tmpy2)
                        {
                            b.mouseArea.left = tmpx1;
                            b.mouseArea.top = tmpy1;
                            b.mouseArea.right = tmpx2;
                            b.mouseArea.bottom = tmpy2;
                        }
                        else
                        {
                            b.mouseArea.left = tmpx1;
                            b.mouseArea.top = tmpy2;
                            b.mouseArea.right = tmpx2;
                            b.mouseArea.bottom = tmpy1;
                        }
                    }
                }
            }
            #endregion
            #region 计算定反位坐标
            //计算sw定反位坐标
            int Length = DrawingInformation.switchLen;
            for (int k = 0; k < dgNumber; k++)
            {
                DG dg = dgs[k];
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

                                //定反位坐标
                                stx += (int)(Length / dis * dx);
                                sty += (int)(Length / dis * dy);
                                if (Math.Abs(dy) < 5)
                                {
                                    sw.Dx = stx;
                                    sw.Dy = sty;
                                }
                                else
                                {
                                    sw.Fx = stx;
                                    sw.Fy = sty;
                                }
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
                                if (Math.Abs(dy) < 5)
                                {
                                    sw.Dx = enx;
                                    sw.Dy = eny;
                                }
                                else
                                {
                                    sw.Fx = enx;
                                    sw.Fy = eny;
                                }
                            }
                        }
                    }
                }
            }
            #endregion
            #region 计算车站应答器坐标
            for (int i = 0; i < transponderGroups.Count; i++)
            {
                for (int j = 0; j < transponderGroups[i].transponders.Count; j++)
                {
                    TransponderGroup.Transponder tp = transponderGroups[i].transponders[j];

                    tp.coordinateX = coordinateOffsetX + (int)((long)(tp.position - startPosition) * DrawingInformation.pixelsPerKilometer / 1000);
                    if (tp.trackNo % 2 == 0)
                        tp.coordinateY = coordinateIGY + tp.trackNo / 2 * DrawingInformation.trackHeight;
                    else tp.coordinateY = coordinateIGY - tp.trackNo / 2 * DrawingInformation.trackHeight;

                    tp.coordinateY += DrawingInformation.penWidth * 3 / 2;//改变应答器坐标
                    tp.mouseArea.left = tp.coordinateX - DrawingInformation.transponderLen;
                    tp.mouseArea.right = tp.coordinateX + DrawingInformation.transponderLen;
                    tp.mouseArea.top = tp.coordinateY;
                    tp.mouseArea.bottom = tp.coordinateY + DrawingInformation.transponderLen * 14 / 9;
                }
                int cnt = transponderGroups[i].transponders.Count - 1;
                transponderGroups[i].mouseArea.left = transponderGroups[i].transponders[0].mouseArea.left;
                transponderGroups[i].mouseArea.top = transponderGroups[i].transponders[0].mouseArea.top;
                transponderGroups[i].mouseArea.bottom = transponderGroups[i].transponders[0].mouseArea.bottom;
                transponderGroups[i].mouseArea.right = transponderGroups[i].transponders[0].mouseArea.right + cnt * DrawingInformation.transponderGap;
            }
            #endregion
        }

        public int FindInsulationJointFromName(string name)
        {
            for (int i = 0; i < insulationJointNumber; i++)
            {
                if (insulationJoints[i].name == name)
                    return i;
            }
            MessageBox.Show("找不到绝缘节通过名字");
            return -1;
        }

        public int FindSignalFromName(string name)
        {
            for (int i = 0; i < signalNumber; i++)
            {
                if (signals[i].name == name)
                    return i;
            }
            MessageBox.Show("找不到对应名字的信号机");
            return -1;
        }

        public int FindSwitchFromSwitchNo(int No)
        {
            for (int i = 0; i < switchNumber; i++)
            {
                if (switchs[i].no == No)
                    return i;
            }
            MessageBox.Show("找不到对应编号的道岔");
            return -1;
        }

        public int FindDummyPointFromName(int name)
        {
            for (int i = 0; i < dummyPointNumber; i++)
            {
                if (ti(dummyPoints[i].name) == name)
                    return i;
            }
            MessageBox.Show("找不到虚拟点从名字");
            return -1;
        }
    }
}
