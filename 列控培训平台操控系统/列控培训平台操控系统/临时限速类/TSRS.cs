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
    public class TSRS
    {
        public int startPosition;
        public int endPosition;
        public int startkm;
        public int startm;
        public int endm;
        public int endkm;
        /// <summary>
        /// 0下行正向，1上行正向
        /// </summary>
        public int type;
        public int limitSpeed;
        public string reason;
        public string lineName;

        public int index;

        public TSRS(操控界面 f,int startkm, int startm, int endkm, int endm, int limitSpeed, string lineName, string reason, int type,int index)
        {
            this.startkm = startkm;
            this.startm = startm;
            this.endkm = endkm;
            this.endm = endm;
            this.limitSpeed = limitSpeed;
            this.lineName = lineName;
            this.reason = reason;
            this.type = type;
            this.index = index;
            startPosition = startkm * 1000 + startm;
            endPosition = endkm * 1000 + endm;

            if (type == 0)
            {
                for (int i = 0; i < InitializationInformation.stationNum-1;i++ )
                {
                    for (int j = 0; j < f.sections[i].Xtracks.Count; j++)
                    {
                        Section.Track xt = f.sections[i].Xtracks[j];
                        //if(xt.realStartPosition <= startPosition && startPosition <= xt.realEndPosition) || (xt.realEndPosition <= startPosition && )
                        if ((startPosition <= xt.realStartPosition && xt.realStartPosition <= endPosition) || (endPosition <= xt.realEndPosition && xt.realEndPosition <= endPosition))
                        {
                            xt.speeds.Add(new Section.Track.SpeedLimitInf(limitSpeed, index));
                            xt.limitSpeed = Math.Min(xt.limitSpeed, limitSpeed);
                        }
                    }
                }
            }
            else 
            {
                for (int i = 0; i < InitializationInformation.stationNum-1; i++)
                {
                    for (int j = 0; j < f.sections[i].Stracks.Count; j++)
                    {
                        Section.Track xt = f.sections[i].Stracks[j];
                        //if(xt.realStartPosition <= startPosition && startPosition <= xt.realEndPosition) || (xt.realEndPosition <= startPosition && )
                        if ((startPosition <= xt.realStartPosition && xt.realStartPosition <= endPosition) || (endPosition <= xt.realEndPosition && xt.realEndPosition <= endPosition))
                        {
                            xt.speeds.Add(new Section.Track.SpeedLimitInf(limitSpeed, index));
                            xt.limitSpeed = Math.Min(xt.limitSpeed, limitSpeed);
                        }
                    }
                }
            }
            for (int i = 0; i < InitializationInformation.stationNum-1; i++)
            {
                f.sections[i].DrawDynamicMap(f.g);
            }
            f.pb_界面图片.Image = f.bp;

              

        }
    }
}
