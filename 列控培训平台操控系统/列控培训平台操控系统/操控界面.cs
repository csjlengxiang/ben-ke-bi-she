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
using 列控培训平台操控系统.区间;
using 列控培训平台操控系统.列车初始化;
using 列控培训平台操控系统.查询;
using 列控培训平台操控系统.临时限速;
namespace 列控培训平台操控系统
{
    public partial class 操控界面 : Form
    {
        public 操控界面()
        {
            InitializeComponent();
        }
        //界面相关
        public Bitmap bp;
        public Graphics g;

        InitializationInformation initInf;

        public Station[] stations;
        public Section[] sections;

        public List<Train> trains = new List<Train>();
        public List<TSRS> tsrss = new List<TSRS>();
        public int TSRSIndex = 1;

        public class BtnDown
        {
            public int stationPos;
            public int stationSignalPos;
            public string name;
            public BtnDown(int spos, int sspos, string n)
            {
                stationPos = spos;
                stationSignalPos = sspos;
                name = n;
            }
        }

        List<BtnDown> btnDowns = new List<BtnDown>();

        private void 操控界面_Load(object sender, EventArgs e)
        {
            //Stopwatch sww = new Stopwatch();
            //sww.Start();
            //sww.Stop();
            //MessageBox.Show(sww.Elapsed.Seconds.ToString() + " " + sww.Elapsed.Milliseconds.ToString());

            this.tsbtn_进路建立.Text = "进路\n建立";
            this.tsbtn_命令下达.Text = "命令\n下达";
            this.tsbtn_命令清除.Text = "命令\n清除";
            this.tsbtn_总取消.Text = " 总\n取消";
            this.tsbtn_区故解.Text = "区故\n 解";
            this.tsbtn_信号重开.Text = "信号\n重开";
            this.tsbtn_道岔总定.Text = "道岔\n总定";
            this.tsbtn_道岔总反.Text = "道岔\n总反";

            TsBtunInit(tsbtn_进路建立);
            #region 初始化界面相关
            //最大化
            panel_放置图片.Visible = false;
            this.WindowState = FormWindowState.Maximized;
            bp = new Bitmap(20000, 1500);
            g = Graphics.FromImage(bp);
            g.Clear(Color.Black);

            pb_界面图片.Image = bp;
            panel_放置图片.Left = 0;
            panel_放置图片.Top = this.ms_操控界面.Height;
            panel_放置图片.Width = this.ClientSize.Width;
            panel_放置图片.Height = this.ClientSize.Height - this.ms_操控界面.Height - this.ts_联锁工具条.Height;

            //this.toolStripContainer1.Top = this.ClientSize.Height - this.ms_操控界面.Height;
            this.MaximizeBox = false;
            panel_放置图片.Visible = true;
            #endregion
            initInf = new InitializationInformation();
            stations = new Station[InitializationInformation.stationNum];
            sections = new Section[InitializationInformation.stationNum - 1];
            for (int i = 0; i < InitializationInformation.stationNum; i++)
            {
                stations[i] = new Station(InitializationInformation.stationInfPath[i], InitializationInformation.stationRouteTablePath[i], InitializationInformation.stationRouteMdbPath, InitializationInformation.stationTransponderMdbPath, i);
                stations[i].SignalDevicePositionCalculation();
            }
            for (int i = 0; i < InitializationInformation.stationNum - 1; i++)
            {
                sections[i] = new Section(stations[i].name, stations[i + 1].name, InitializationInformation.sectionInfMdbPath);
                sections[i].SignalDevicePositionCalculation();
            }
            int stx = DrawingInformation.startX, sty = DrawingInformation.startY;
            for (int i = 0; i < InitializationInformation.stationNum; i++)
            {
                stations[i].SignalDeviceCoordinatesCalculation(stx, sty);
                if (i == InitializationInformation.stationNum - 1) continue;
                sections[i].SignalDeviceCoordinatesCalculation(stations[i].coordinateEndX, sty, g);
                stx = sections[i].endCoordinateX;
            }
            for (int i = 0; i < InitializationInformation.stationNum; i++)
            {
                stations[i].DrawStaticMap(g);
                stations[i].DrawDynamicMap(g);
                if (i == InitializationInformation.stationNum - 1) continue;
                sections[i].DrawStaticMap(g);
            }
            pb_界面图片.Image = bp;
            ms_操控界面.Visible = true;
            t_刷进路占用.Enabled = true;
        }

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            查询界面 f = new 查询界面(this);
            f.Show();
        }

        private void 放大ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawingInformation.startX = 50;
            DrawingInformation.startY = 500;
            DrawingInformation.pixelsPerKilometer = 850;
            DrawingInformation.trackHeight = 100;
            DrawingInformation.scale = 1.3;
            DrawingInformation.penWidth = 4;
            DrawingInformation.textSize = 20;
            //public static Color textColor = Color.White;

            DrawingInformation.transponderLen = 10;


            DrawingInformation.p1.Width = DrawingInformation.penWidth; //用于画静态图股道
            DrawingInformation.p2.Width = 4;                   //用于画静态图的按钮边框，再加上按钮的
            DrawingInformation.p4.Width = 3;                   //按钮按下时候边框
            DrawingInformation.p3.Width = 2;                   //用于画绝缘节的画笔
            DrawingInformation.p5.Width = DrawingInformation.penWidth;                //动态图故障、占用
            DrawingInformation.p6.Width = DrawingInformation.penWidth;                //动态图进路等待状态

            DrawingInformation.TSRSPen.Width = DrawingInformation.penWidth;
            DrawingInformation.TSRSPenEraser.Width = DrawingInformation.penWidth + 2;
            DrawingInformation.transponderPen.Width = 2;

            DrawingInformation.font1 = new Font("Arial", DrawingInformation.textSize);                 //"IG","X"等字的大小
            DrawingInformation.font2 = new Font("Arial", DrawingInformation.textSize * 3);
            DrawingInformation.fontTrackName = new Font("Arial", DrawingInformation.textSize / 2);

     
            DrawingInformation.arrowHeight = 10;
            DrawingInformation.signalRadiu = 14;
            DrawingInformation.signalBtnLen = 20;                               //用于画静态图的按钮边框，再加上按钮的
            DrawingInformation.insulationJointLen = 18;
            DrawingInformation.switchLen = 23;
            DrawingInformation.switchAreaLen = 12;

            //////////////////////////////////////////////////以下是区段/////////////////////////////////////////////////////

            DrawingInformation.sectionPixelsPerKilometer = 130;
            DrawingInformation.sectionTrackGap = 6;
            DrawingInformation.transponderGap = 6;
            DrawingInformation.trackAreaHeight = 8;
            ////////////////////////////////////////////////////////////////

            g.Clear(Color.Black);
            int stx = DrawingInformation.startX, sty = DrawingInformation.startY;
            for (int i = 0; i < InitializationInformation.stationNum; i++)
            {
                stations[i].SignalDeviceCoordinatesCalculation(stx, sty);
                if (i == InitializationInformation.stationNum - 1) continue;
                sections[i].SignalDeviceCoordinatesCalculation(stations[i].coordinateEndX, sty, g);
                stx = sections[i].endCoordinateX;
            }
            for (int i = 0; i < InitializationInformation.stationNum; i++)
            {
                stations[i].DrawStaticMap(g);
                stations[i].DrawDynamicMap(g);
                if (i == InitializationInformation.stationNum - 1) continue;
                sections[i].DrawStaticMap(g);
            }
            pb_界面图片.Image = bp;
        }

        private void 缩小ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawingInformation.startX = 30;
            DrawingInformation.startY = 330;
            DrawingInformation.pixelsPerKilometer = 400;
            DrawingInformation.trackHeight = 40;
            DrawingInformation.scale = 1.3;
            DrawingInformation.penWidth = 2;
            DrawingInformation.textSize = 10
                ;
            //public static Color textColor = Color.White;

            DrawingInformation.transponderLen = 5;


            DrawingInformation.p1.Width = DrawingInformation.penWidth; //用于画静态图股道
            DrawingInformation.p2.Width = 2;                   //用于画静态图的按钮边框，再加上按钮的
            DrawingInformation.p4.Width = 2;                   //按钮按下时候边框
            DrawingInformation.p3.Width = 1;                   //用于画绝缘节的画笔
            DrawingInformation.p5.Width = DrawingInformation.penWidth;                //动态图故障、占用
            DrawingInformation.p6.Width = DrawingInformation.penWidth;                //动态图进路等待状态

            DrawingInformation.TSRSPen.Width = DrawingInformation.penWidth;
            DrawingInformation.TSRSPenEraser.Width = DrawingInformation.penWidth + 2;
            DrawingInformation.transponderPen.Width = 1;

            DrawingInformation.font1 = new Font("Arial", DrawingInformation.textSize);                 //"IG","X"等字的大小
            DrawingInformation.font2 = new Font("Arial", DrawingInformation.textSize * 3);
            DrawingInformation.fontTrackName = new Font("Arial", DrawingInformation.textSize / 2);


            DrawingInformation.arrowHeight = 5;
            DrawingInformation.signalRadiu = 6;
            DrawingInformation.signalBtnLen = 11;                               //用于画静态图的按钮边框，再加上按钮的
            DrawingInformation.insulationJointLen = 12;
            DrawingInformation.switchLen = 12;
            DrawingInformation.switchAreaLen = 5;

            //////////////////////////////////////////////////以下是区段/////////////////////////////////////////////////////

            DrawingInformation.sectionPixelsPerKilometer = 70;
            DrawingInformation.sectionTrackGap = 3;
            DrawingInformation.transponderGap = 3;
            DrawingInformation.trackAreaHeight = 4;
            ////////////////////////////////////////////////////////////////

            g.Clear(Color.Black);
            int stx = DrawingInformation.startX, sty = DrawingInformation.startY;
            for (int i = 0; i < InitializationInformation.stationNum; i++)
            {
                stations[i].SignalDeviceCoordinatesCalculation(stx, sty);
                if (i == InitializationInformation.stationNum - 1) continue;
                sections[i].SignalDeviceCoordinatesCalculation(stations[i].coordinateEndX, sty, g);
                stx = sections[i].endCoordinateX;
            }
            for (int i = 0; i < InitializationInformation.stationNum; i++)
            {
                stations[i].DrawStaticMap(g);
                stations[i].DrawDynamicMap(g);
                if (i == InitializationInformation.stationNum - 1) continue;
                sections[i].DrawStaticMap(g);
            }
            pb_界面图片.Image = bp;
        }

        private void 还原ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawingInformation.startX = 50;
            DrawingInformation.startY = 330;
            DrawingInformation.pixelsPerKilometer = 650;
            DrawingInformation.trackHeight = 80;
            DrawingInformation.scale = 1.3;
            DrawingInformation.penWidth = 3;
            DrawingInformation.textSize = 15;
            //public static Color textColor = Color.White;

            DrawingInformation.transponderLen = 8;


            DrawingInformation.p1.Width = DrawingInformation.penWidth; //用于画静态图股道
            DrawingInformation.p2.Width = 3;                   //用于画静态图的按钮边框，再加上按钮的
            DrawingInformation.p4.Width = 2;                   //按钮按下时候边框
            DrawingInformation.p3.Width = 1;                   //用于画绝缘节的画笔
            DrawingInformation.p5.Width = DrawingInformation.penWidth;                //动态图故障、占用
            DrawingInformation.p6.Width = DrawingInformation.penWidth;                //动态图进路等待状态
            DrawingInformation.transponderPen.Width = 1;

            DrawingInformation.TSRSPen.Width = DrawingInformation.penWidth;

            DrawingInformation.TSRSPenEraser.Width = DrawingInformation.penWidth + 2;
            DrawingInformation.font1 = new Font("Arial", DrawingInformation.textSize);                 //"IG","X"等字的大小
            DrawingInformation.font2 = new Font("Arial", DrawingInformation.textSize * 3);
            DrawingInformation.fontTrackName = new Font("Arial", DrawingInformation.textSize / 2);


            DrawingInformation.arrowHeight = 7;
            DrawingInformation.signalRadiu = 8;
            DrawingInformation.signalBtnLen = 15;                               //用于画静态图的按钮边框，再加上按钮的
            DrawingInformation.insulationJointLen = 16;
            DrawingInformation.switchLen = 18;
            DrawingInformation.switchAreaLen = 8;

            //////////////////////////////////////////////////以下是区段/////////////////////////////////////////////////////

            DrawingInformation.sectionPixelsPerKilometer = 100;
            DrawingInformation.sectionTrackGap = 3;
            DrawingInformation.transponderGap = 3;
            DrawingInformation.trackAreaHeight = 5;
            ////////////////////////////////////////////////////////////////

            g.Clear(Color.Black);
            int stx = DrawingInformation.startX, sty = DrawingInformation.startY;
            for (int i = 0; i < InitializationInformation.stationNum; i++)
            {
                stations[i].SignalDeviceCoordinatesCalculation(stx, sty);
                if (i == InitializationInformation.stationNum - 1) continue;
                sections[i].SignalDeviceCoordinatesCalculation(stations[i].coordinateEndX, sty, g);
                stx = sections[i].endCoordinateX;
            }
            for (int i = 0; i < InitializationInformation.stationNum; i++)
            {
                stations[i].DrawStaticMap(g);
                stations[i].DrawDynamicMap(g);
                if (i == InitializationInformation.stationNum - 1) continue;
                sections[i].DrawStaticMap(g);
            }
            pb_界面图片.Image = bp;
        }

        private void 添加临时限速ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            临时限速界面 f = new 临时限速界面(this);
            f.Show();
        }

        private void 管理临时限速ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            管理临时限速 f = new 管理临时限速(this);
            f.Show();
        }

        private void 添加列车ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            列车初始化界面 f = new 列车初始化界面(this);
            f.Show();
        }

        private void 管理列车ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            管理列车 f = new 管理列车(this);
            f.Show();
        }

 

 
 
    }
}
