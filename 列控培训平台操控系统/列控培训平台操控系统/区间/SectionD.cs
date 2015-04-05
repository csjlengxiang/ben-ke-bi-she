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
        public void DrawTrack(Graphics g, Track a)
        {
            if (a.status == 0)
                g.DrawLine(DrawingInformation.p1, a.startCoordinateX, a.CoordinateY, a.endCoordinateX - DrawingInformation.sectionTrackGap, a.CoordinateY);
            else g.DrawLine(DrawingInformation.p5, a.startCoordinateX, a.CoordinateY, a.endCoordinateX - DrawingInformation.sectionTrackGap, a.CoordinateY);

            if (a.speeds.Count > 0)
            {
                int len = (int)DrawingInformation.TSRSPen.Width;

                g.DrawLine(DrawingInformation.TSRSPen, a.startCoordinateX, a.CoordinateY + len, a.endCoordinateX, a.CoordinateY + len);

                g.DrawLine(DrawingInformation.TSRSPen, a.startCoordinateX, a.CoordinateY - len, a.endCoordinateX, a.CoordinateY - len);
            }
            else
            {
                int len = (int)DrawingInformation.TSRSPenEraser.Width;

                g.DrawLine(DrawingInformation.TSRSPenEraser, a.startCoordinateX, a.CoordinateY + len, a.endCoordinateX, a.CoordinateY + len);

                g.DrawLine(DrawingInformation.TSRSPenEraser, a.startCoordinateX, a.CoordinateY - len, a.endCoordinateX, a.CoordinateY - len);
            }
        }
        public void DrawStaticMap(Graphics g)
        {
            for (int i = 0; i < Xtracks.Count; i++)
            {
                Track a = Xtracks[i];
                DrawTrack(g, a);
                //g.DrawLine(DrawingInformation.p1, a.startCoordinateX, a.CoordinateY, a.endCoordinateX - DrawingInformation.sectionTrackGap, a.CoordinateY);
                Font font = DrawingInformation.fontTrackName;
                SolidBrush brush = (SolidBrush)DrawingInformation.brush1;
                g.DrawString(a.name, font, brush, (a.startCoordinateX + a.endCoordinateX) / 2 - (int)g.MeasureString(a.name, font).Width / 2, a.CoordinateY - (int)g.MeasureString(a.name, font).Height * 3 / 2);

                if (a.haveTrack)
                {
                    int l = 27;
                    int ll = l * 3 / 4;
                    g.DrawLine(new Pen(Color.White, 2), a.startCoordinateX, a.CoordinateY, a.startCoordinateX, a.CoordinateY - l);
                    int x = a.startCoordinateX;
                    int y = a.CoordinateY;

                    PointF[] pi = new PointF[3];

                    pi[0] = new PointF(x, y - l);
                    pi[1] = new PointF(x + ll, y - l * 3 / 4);
                    pi[2] = new PointF(x, y - l / 2);
                    g.FillPolygon(new SolidBrush(Color.Yellow), pi);
                    pi[2] = new PointF(x + ll, y - l);
                    g.FillPolygon(new SolidBrush(Color.Blue), pi);
                    pi[0] = new PointF(x, y - l / 2);
                    pi[2] = new PointF(x + ll, y - l / 2);
                    g.FillPolygon(new SolidBrush(Color.Blue), pi);
                }
            }
            for (int i = 0; i < Stracks.Count; i++)
            {
                Track a = Stracks[i];
                DrawTrack(g, a);
                Font font = DrawingInformation.fontTrackName;
                SolidBrush brush = (SolidBrush)DrawingInformation.brush1;
                g.DrawString(a.name, font, brush, (a.startCoordinateX + a.endCoordinateX) / 2 - (int)g.MeasureString(a.name, font).Width / 2, a.CoordinateY - (int)g.MeasureString(a.name, font).Height * 3 / 2);

                if (a.haveTrack)
                {
                    int l = 27;
                    int ll = -l * 3 / 4;
                    g.DrawLine(new Pen(Color.White, 2), a.startCoordinateX, a.CoordinateY, a.startCoordinateX, a.CoordinateY - l);
                    int x = a.startCoordinateX;
                    int y = a.CoordinateY;

                    PointF[] pi = new PointF[3];

                    pi[0] = new PointF(x, y - l);
                    pi[1] = new PointF(x + ll, y - l * 3 / 4);
                    pi[2] = new PointF(x, y - l / 2);
                    g.FillPolygon(new SolidBrush(Color.Yellow), pi);
                    pi[2] = new PointF(x + ll, y - l);
                    g.FillPolygon(new SolidBrush(Color.Blue), pi);
                    pi[0] = new PointF(x, y - l / 2);
                    pi[2] = new PointF(x + ll, y - l / 2);
                    g.FillPolygon(new SolidBrush(Color.Blue), pi);
                }
            }
            for (int i = 0; i < XtransponderGroups.Count; i++)
            {
                DrawTransponderGroup(g, XtransponderGroups[i]);
            }
            for (int i = 0; i < StransponderGroups.Count; i++)
            {
                DrawTransponderGroup(g, StransponderGroups[i]);
            }
        }

        public void DrawDynamicMap(Graphics g)
        {
            for (int i = 0; i < Xtracks.Count; i++)
            {
                Track a = Xtracks[i];
                DrawTrack(g, a);
            }
            for (int i = 0; i < Stracks.Count; i++)
            {
                Track a = Stracks[i];
                DrawTrack(g, a);
            }
            for (int i = 0; i < XtransponderGroups.Count; i++)
            {
                TransponderGroup t = XtransponderGroups[i];
                DrawTransponderGroup(g, t);
            }
            for (int i = 0; i < StransponderGroups.Count; i++)
            {
                TransponderGroup t = StransponderGroups[i];
                DrawTransponderGroup(g, t);
            }

        }
        public void DrawTransponderGroup(Graphics g, TransponderGroup t)
        {
            int x = t.transponders[0].coordinateX;
            int y = t.transponders[0].coordinateY;
            TransponderGroup.MouseArea a = t.mouseArea;
            g.FillRectangle(DrawingInformation.signalColorBrushB, a.left, a.top, a.right - a.left, a.bottom - a.top);
            
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
    }
}
