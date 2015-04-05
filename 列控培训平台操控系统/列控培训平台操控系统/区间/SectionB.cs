using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 列控培训平台操控系统.区间
{
    public partial class Section
    {
        public class Track
        {
            public string name;
            public int realStartPosition;
            public int realEndPosition;
            public int trackLen;

            public bool haveTrack;
            /// <summary>
            ///  断链偏移量，画图有需求
            /// </summary>
            public int chainScissionOffset;
            /// <summary>
            ///  == realStartPosition - chainScissionOffset
            /// </summary>
            public int startPosition;
            public int endPosition;
            public int startCoordinateX;
            public int endCoordinateX;
            public int CoordinateY;

            public MouseArea mouseArea = new MouseArea();
            public class MouseArea
            {
                public int left;
                public int right;
                public int top;
                public int bottom;
            }
            /// <summary>
            /// 股道状态,0空闲，1占用，2故障
            /// </summary>
            public int status;

            public List<SpeedLimitInf> speeds = new List<SpeedLimitInf>();
            public int limitSpeed = 1000;
            public class SpeedLimitInf
            {
                public int limitSpeed;
                public int index;
                public SpeedLimitInf(int l,int i)
                {
                    limitSpeed = l;
                    index = i;
                }
            }
        }

        public class ChainScission
        {
            public int startPosition;
            public int endPosition;
        }

        public class TransponderGroup
        {
            public List<Transponder> transponders = new List<Transponder>();

            public int status = 0;

            public class Transponder
            {
                public string name;
                public int groupNumber;
                public bool active;
                /// <summary>
                /// 真实位置
                /// </summary>
                public int realPosition;
                /// <summary>
                /// 转换后的位置  realPosition - 断链
                /// </summary>
                public int position;
                public int chainScissionOffset;

                public int coordinateX;
                public int coordinateY;

                public MouseArea mouseArea = new MouseArea();
                public class MouseArea
                {
                    public int left;
                    public int right;
                    public int top;
                    public int bottom;
                }
            }
            public MouseArea mouseArea = new MouseArea();
            public class MouseArea
            {
                public int left;
                public int right;
                public int top;
                public int bottom;
            }
        }
    }
}
