using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using 列控培训平台操控系统.车站;

namespace 列控培训平台操控系统.区间
{
    public partial class Section
    {
        public void SignalDevicePositionCalculation()
        {
            int offset = 0;
            for (int i = 0; i < Xtracks.Count ; i++)
            {
                Track a, b;
                a = Xtracks[i];
                
                a.chainScissionOffset = offset;
                a.startPosition = a.realStartPosition - offset; 
                if (i == Xtracks.Count - 1) continue;
                b = Xtracks[i + 1];
                if (a.realStartPosition + a.trackLen != b.realStartPosition)
                {
                    for (int j = 0; j < chainScissions.Count; j++)
                    {
                        ChainScission c = chainScissions[j];
                        if (c.startPosition >= a.realStartPosition && c.endPosition <= b.realStartPosition)
                            offset += (c.endPosition - c.startPosition);
                    }
                }
            }
            this.startPosition = Xtracks[0].startPosition;
            this.endPosition = Xtracks[Xtracks.Count - 1].startPosition + Xtracks[Xtracks.Count - 1].trackLen;
            this.realStartPosition = Xtracks[0].realStartPosition;
            //第一、最后一个区段必定木有断链！！！
            this.realEndPosition = Xtracks[Xtracks.Count - 1].realStartPosition + Xtracks[Xtracks.Count - 1].trackLen;
            offset = 0;
            for (int i = 0; i < Stracks.Count ; i++)
            {
                Track a, b;
                a = Stracks[i];
                
                a.chainScissionOffset = offset;
                a.startPosition = a.realStartPosition - offset;
                if (i == Stracks.Count - 1) continue;
                b = Stracks[i + 1];
                if (a.realStartPosition + a.trackLen != b.realStartPosition)
                {
                    for (int j = 0; j < chainScissions.Count; j++)
                    {
                        ChainScission c = chainScissions[j];
                        if (c.startPosition >= a.realStartPosition && c.endPosition <= b.realStartPosition)
                            offset += (c.endPosition - c.startPosition);
                    }
                }
            }
            offset = 0;

            int k = 0, ii = 0, jj = 0;
            TransponderGroup.Transponder t;

            bool fnd = false;
            while (k < chainScissions.Count)
            {
                ChainScission c = chainScissions[k];
                if (c.startPosition >= this.realStartPosition && c.endPosition <= this.realEndPosition)
                {
                    fnd = true;
                    while (jj < XtransponderGroups[ii].transponders.Count)
                    {
                        t = XtransponderGroups[ii].transponders[jj];
                        if (t.realPosition > c.startPosition)
                        {
                            offset += (c.endPosition - c.startPosition);
                            k++;
                            c = chainScissions[k];
                        }
                        t.chainScissionOffset = offset;
                        t.position = t.realPosition - offset;
                        jj++;
                        if (jj == XtransponderGroups[ii].transponders.Count)
                        {
                            jj = 0;
                            ii++;
                            if (ii == XtransponderGroups.Count)
                                break;
                        }
                    }
                    if (ii == XtransponderGroups.Count)
                        break;
                }
                else
                {
                    k++;
                    continue;
                }
            }
            k = 0; ii = 0; jj = 0;
            offset = 0;
            while (k < chainScissions.Count)
            {
                ChainScission c = chainScissions[k];
                if (c.startPosition >= this.realStartPosition && c.endPosition <= this.realEndPosition)
                {
                    while (jj < StransponderGroups[ii].transponders.Count)
                    {
                        t = StransponderGroups[ii].transponders[jj];
                        if (t.realPosition > c.startPosition)
                        {
                            offset += (c.endPosition - c.startPosition);
                            k++;
                            c = chainScissions[k];
                        }
                        t.chainScissionOffset = offset;
                        t.position = t.realPosition - offset;
                        jj++;
                        if (jj == StransponderGroups[ii].transponders.Count)
                        {
                            jj = 0;
                            ii++;
                            if (ii == StransponderGroups.Count)
                                break;
                        }
                    }
                    if (ii == StransponderGroups.Count)
                        break;
                }
                else
                {
                    k++;
                    continue;
                }
            }
            if (fnd == false)
            {
                for (int i = 0; i < XtransponderGroups.Count; i++)
                {
                    for (int j = 0; j < XtransponderGroups[i].transponders.Count; j++)
                    {
                        TransponderGroup.Transponder a = XtransponderGroups[i].transponders[j];
                        a.position = a.realPosition;
                    }
                }
                for (int i = 0; i < StransponderGroups.Count; i++)
                {
                    for (int j = 0; j < StransponderGroups[i].transponders.Count; j++)
                    {
                        TransponderGroup.Transponder a = StransponderGroups[i].transponders[j];
                        a.position = a.realPosition;
                    }
                }
            }
            //MessageBox.Show("ok");
        }

        public void SignalDeviceCoordinatesCalculation(int coordinateOffsetX, int coordinateOffsetY, Graphics g)
        {
            int x = coordinateOffsetX;
            int y = coordinateOffsetY;
            int stp = this.startPosition;
            
            for (int i = 0; i < Xtracks.Count; i++)
            {
                Track a = Xtracks[i];
                a.startCoordinateX = x + (int)((long)(a.startPosition - stp) * DrawingInformation.sectionPixelsPerKilometer / 1000);
                a.endCoordinateX = x + (int)((long)(a.startPosition + a.trackLen - stp) * DrawingInformation.sectionPixelsPerKilometer / 1000);
                a.CoordinateY = y;
                a.mouseArea.left = a.startCoordinateX;
                a.mouseArea.right = a.endCoordinateX;
                a.mouseArea.top = a.CoordinateY - DrawingInformation.trackAreaHeight;
                a.mouseArea.bottom = a.CoordinateY + DrawingInformation.trackAreaHeight;
            }
            for (int i = 0; i < Stracks.Count; i++)
            {
                Track a = Stracks[i];
                a.startCoordinateX = x + (int)((long)(a.startPosition - stp) * DrawingInformation.sectionPixelsPerKilometer / 1000);
                a.endCoordinateX = x + (int)((long)(a.startPosition + a.trackLen - stp) * DrawingInformation.sectionPixelsPerKilometer / 1000);
                a.CoordinateY = y + DrawingInformation.trackHeight;
                a.mouseArea.left = a.startCoordinateX;
                a.mouseArea.right = a.endCoordinateX;
                a.mouseArea.top = a.CoordinateY - DrawingInformation.trackAreaHeight;
                a.mouseArea.bottom = a.CoordinateY + DrawingInformation.trackAreaHeight;
            }
            for (int i = 0; i < XtransponderGroups.Count; i++)
            {
                for (int j = 0; j < XtransponderGroups[i].transponders.Count; j++)
                {
                    TransponderGroup.Transponder a = XtransponderGroups[i].transponders[j];
                    a.coordinateX = x + (int)((long)(a.position - stp) * DrawingInformation.sectionPixelsPerKilometer / 1000);
                    a.coordinateY = y;
                    a.coordinateY += DrawingInformation.penWidth * 3 / 2;//改变应答器坐标
                    TransponderGroup.Transponder tp = a;
                    tp.mouseArea.left = tp.coordinateX - DrawingInformation.transponderLen;
                    tp.mouseArea.right = tp.coordinateX + DrawingInformation.transponderLen;
                    tp.mouseArea.top = tp.coordinateY;
                    tp.mouseArea.bottom = tp.coordinateY + DrawingInformation.transponderLen * 14 / 9;
                }
                int cnt = XtransponderGroups[i].transponders.Count - 1;
                XtransponderGroups[i].mouseArea.left = XtransponderGroups[i].transponders[0].mouseArea.left;
                XtransponderGroups[i].mouseArea.top = XtransponderGroups[i].transponders[0].mouseArea.top;
                XtransponderGroups[i].mouseArea.bottom = XtransponderGroups[i].transponders[0].mouseArea.bottom;
                XtransponderGroups[i].mouseArea.right = XtransponderGroups[i].transponders[0].mouseArea.right + cnt * DrawingInformation.transponderGap;
            
            }
            for (int i = 0; i < StransponderGroups.Count; i++)
            {
                for (int j = 0; j < StransponderGroups[i].transponders.Count; j++)
                {
                    TransponderGroup.Transponder a = StransponderGroups[i].transponders[j];
                    a.coordinateX = x + (int)((long)(a.position - stp) * DrawingInformation.sectionPixelsPerKilometer / 1000);
                    a.coordinateY = y + DrawingInformation.trackHeight;
                    a.coordinateY += DrawingInformation.penWidth * 3 / 2;//改变应答器坐标
                    TransponderGroup.Transponder tp = a;
                    tp.mouseArea.left = tp.coordinateX - DrawingInformation.transponderLen;
                    tp.mouseArea.right = tp.coordinateX + DrawingInformation.transponderLen;
                    tp.mouseArea.top = tp.coordinateY;
                    tp.mouseArea.bottom = tp.coordinateY + DrawingInformation.transponderLen * 14 / 9;
                }
                int cnt = StransponderGroups[i].transponders.Count - 1;
                StransponderGroups[i].mouseArea.left = StransponderGroups[i].transponders[0].mouseArea.left;
                StransponderGroups[i].mouseArea.top = StransponderGroups[i].transponders[0].mouseArea.top;
                StransponderGroups[i].mouseArea.bottom = StransponderGroups[i].transponders[0].mouseArea.bottom;
                StransponderGroups[i].mouseArea.right = StransponderGroups[i].transponders[0].mouseArea.right + cnt * DrawingInformation.transponderGap;
            
            }
            this.startCoordinateX = Xtracks[0].startCoordinateX;
            this.endCoordinateX = Xtracks[Xtracks.Count - 1].endCoordinateX;
        }
    }
}
