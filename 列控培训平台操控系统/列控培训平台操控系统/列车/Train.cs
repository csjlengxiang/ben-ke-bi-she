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
namespace 列控培训平台操控系统
{
    public partial class Train
    {
        /// <summary>
        /// 用于填充列车
        /// </summary>
        public PictureBox p;
        /// <summary>
        /// 用于鼠标放于列车上，显示列车信息
        /// </summary>
        public ToolTip t;

        public int len;
        public string name;
        /// <summary>
        /// 在车站为true
        /// </summary>
        public bool inStation;
        /// <summary>
        /// 所在车站的id
        /// </summary>
        public int stationPos;
        /// <summary>
        /// 所在车站股道名字
        /// </summary>
        public string dgName;
        /// <summary>
        /// 所在车站股道id
        /// </summary>
        //public int dgPos;
        /// <summary>
        /// 下行还是上行track，XS为true为上行
        /// </summary>
        public bool XS;
        /// <summary>
        /// 所在区间的股道名字
        /// </summary>
        public string trackName;
        /// <summary>
        /// 所在区间的股道id
        /// </summary>
        public int trackPos;
        /// <summary>
        /// 1正向,距离X信号机，0反向,距离S信号机
        /// </summary>
        public bool dir;
        /// <summary>
        /// 长度
        /// </summary>
        public int disFromXsignal;
        public int disFromSsignal;

        /////////////////////////////////////////////////////////////////////

        public int startPosition;
        public int endPosition;
        public int initialPosition;
        public int initialX;
        public int initialY;

        public RunInf runInf = new RunInf();
        public class RunInf
        {
            public bool preInstation;
            public int preStationOrSectionPos;
            public string preTrackName;
            public bool curInstation;
            public int curStationOrSectionPos;
            public string curTrackName;
            public int curSpeed;
        }

        public int ti(string s)
        {
            if (s == "") return -1;
            return Convert.ToInt32(s);
        }
        public Train(操控界面 f
            , int len
            , string name
            , bool inStation
            , int stationPos
            , string dgName
            , string trackName
            , bool dir
            , string disFromXsignal
            , string disFromSsignal)
        {
            #region 读入数据
            this.len = len;
            this.name = name;
            this.inStation = inStation;
            if (inStation)
            {
                this.stationPos = stationPos;
                this.dgName = dgName;
                //this.dgPos = f.stations[stationPos].FindDgFromName(dgName);
                this.dir = dir;
                if (dir)
                    this.disFromXsignal = ti(disFromXsignal);
                else this.disFromSsignal = ti(disFromSsignal);
            }
            this.p = new PictureBox();
            this.t = new ToolTip();
            this.p.BackgroundImage = global::列控培训平台操控系统.Properties.Resources.train;
            this.p.BackgroundImageLayout = ImageLayout.Stretch;
            this.p.Name = name;
            this.p.Size = new Size(60, 20);
            this.p.TabIndex = 20;
            this.p.TabStop = false;
            this.t.SetToolTip(this.p, name);
            this.p.Location = new Point(0, 0);
            f.pb_界面图片.Controls.Add(this.p);
            #endregion

            if (inStation)
            {
                #region 计算列车初始位置数据，并摆放
                string num = csj(dgName);
                int spos = f.stations[stationPos].FindSignalFromName("S" + num);
                int xpos = f.stations[stationPos].FindSignalFromName("X" + num);
                this.startPosition = f.stations[stationPos].signals[spos].position;
                this.endPosition = f.stations[stationPos].signals[xpos].position;

                MessageBox.Show(this.startPosition.ToString());

                if (dir)
                    this.initialPosition = this.endPosition - this.disFromXsignal;
                else this.initialPosition = this.startPosition + this.disFromSsignal;


                int stx = f.stations[stationPos].signals[spos].coordinateX;
                int enx = f.stations[stationPos].signals[xpos].coordinateX;
                int x = stx + (int)((long)(this.initialPosition - this.startPosition) * (long)(enx - stx) / (long)(this.endPosition - this.startPosition));
                int y = f.stations[stationPos].signals[spos].coordinateY - this.p.Height;
                if (dir) //下行车头
                    x -= this.p.Width;
                this.p.Left = x;
                this.p.Top = y;

                this.runInf.curInstation = true;
                this.runInf.preInstation = true;
                this.runInf.curStationOrSectionPos = stationPos;
                this.runInf.preStationOrSectionPos = stationPos;
                this.runInf.preTrackName = dgName;
                this.runInf.curTrackName = dgName;
                this.runInf.curSpeed = 0;
                #endregion
                DrawTrackStatus(f, 3);
                #region 找到股道并画占用
                #endregion
            }
            else
            {
                MessageBox.Show("有待讨论!!!");
            }
        }

        public void DrawTrackStatus(操控界面 f, int status)
        {
            int fnd = 0;
            for (int i = 0; i < f.stations[this.stationPos].dgNumber; i++)
            {
                Station.DG dg = f.stations[this.stationPos].dgs[i];
                if (dg.name == dgName)
                {
                    fnd = 1;
                    dg.status = status;
                }
            }
            if (fnd == 0)
            {
                for (int i = 0; i < f.stations[this.stationPos].dgNumber; i++)
                {
                    Station.DG dg = f.stations[this.stationPos].dgs[i];
                    if (dg.name.Substring(0, dg.name.Length - 1) == dgName)
                    {
                        dg.status = status;
                    }
                }
            }
            f.stations[this.stationPos].DrawDynamicMap(f.g);
            f.pb_界面图片.Image = f.bp;
        }
        private string csj(string s)
        {
            if (s == "IG") return "I";
            if (s == "IIG") return "II";
            int ret = 0;
            for (int i = 0; i < s.Length; i++)
                if (s[i] >= '0' && s[i] <= '9')
                    ret = ret + (int)(s[i] - '0');
                else break;
            return ret.ToString();
        }
    }
}
