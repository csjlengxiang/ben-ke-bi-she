using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 列控培训平台操控系统.车站
{
    class DrawingInformation
    {
        public static int startX = 50;
        public static int startY = 330;
        public static int pixelsPerKilometer = 650;
        public static int trackHeight = 80;
        public static double scale = 1.3;
        public static int penWidth = 3;
        public static int textSize = 15;
        //public static Color textColor = Color.White;

        public static int transponderLen = 8;

        public static Pen p1 = new Pen(Color.FromArgb(92, 135, 202), penWidth); //用于画静态图股道
        public static Pen p2 = new Pen(Color.DimGray, 3);                   //用于画静态图的按钮边框，再加上按钮的
        public static Pen p4 = new Pen(Color.DimGray, 2);                   //按钮按下时候边框
        public static Pen p3 = new Pen(Color.FromArgb(92, 135, 202), 1);     //用于画绝缘节的画笔
        public static Pen p5 = new Pen(Color.Red, penWidth);                 //动态图故障、占用
        public static Pen p6 = new Pen(Color.Aqua, penWidth);                //动态图进路等待状态
        public static Pen SignalEorrPen1 = new Pen(Color.White, 1);
        public static Pen SignalEorrPen2 = new Pen(Color.Red, 1);

        public static Pen TSRSPen = new Pen(Color.Yellow, penWidth);
        public static Pen TSRSPenEraser = new Pen(Color.Black, penWidth);
        public static Pen transponderPen = new Pen(Color.Yellow, 1);
        
        public static Font font1 = new Font("Arial", textSize);                 //"IG","X"等字的大小
        public static Font font2 = new Font("Arial", textSize * 3);
        public static Font fontTrackName = new Font("Arial", textSize / 2);

        public static Brush brush1 = new SolidBrush(Color.White);
        public static Brush brush2 = new SolidBrush(Color.LimeGreen);              //btnup的颜色
        public static Brush brush7 = new SolidBrush(Color.Blue);            //btndown的颜色  
        public static Brush brush3 = new SolidBrush(Color.FromArgb(0, 255, 0));                   //定位的brush，颜色为绿色
        public static Brush brush4 = new SolidBrush(Color.FromArgb(255,255,0));                   //反................黄色
        public static Brush brush5 = new SolidBrush(Color.Red);                                   //故障              红色


        public static Brush signalColorBrushH = new SolidBrush(Color.Red);
        public static Brush signalColorBrushL = new SolidBrush(Color.Green);
        public static Brush signalColorBrushU = new SolidBrush(Color.Yellow);
        public static Brush signalColorBrushB = new SolidBrush(Color.Black);
        
        public static int arrowHeight = 7;
        public static int signalRadiu = 8;
        public static int signalBtnLen = 15;                               //用于画静态图的按钮边框，再加上按钮的
        public static int insulationJointLen = 16;
        public static int switchLen = 18;
        public static int switchAreaLen = 8;
        public static Brush brush6 = new SolidBrush(Color.FromArgb(80,80,80));

        //////////////////////////////////////////////////以下是区段/////////////////////////////////////////////////////

        public static int sectionPixelsPerKilometer = 100;
        public static int sectionTrackGap = 3;
        public static int transponderGap = 3;
        public static int trackAreaHeight = 5;
    }
}
