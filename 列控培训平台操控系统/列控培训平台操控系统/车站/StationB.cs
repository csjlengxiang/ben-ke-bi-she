using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 列控培训平台操控系统.车站
{
    partial class Station
    {
        public class Signal
        {
            /// <summary>
            /// 读入数据
            /// </summary>
            public string name;
            public int offset;
            public int dir;
            public int trackNo;

            /// <summary>
            /// 计算获得数据
            /// </summary>
            public int position;

            /// <summary>
            /// 坐标
            /// </summary>
            public int coordinateX;
            public int coordinateY;

            /// <summary>
            /// btn坐标
            /// </summary>
            public int BtnX;
            public int BtnY;
            /// <summary>
            /// 信号机状态,0空闲，1被某条进路占用(但车还没有压过来，只要有压就变红，变成空闲0 )，2以上就是故障了
            /// </summary>
            public int status;
            public int stationPos;
            public Route occupyRoute;
            public string color;             //根据表显示灯色用

            public MouseArea mouseArea = new MouseArea();
            public class MouseArea
            {
                public int left;
                public int right;
                public int top;
                public int bottom;
            }
        }
        public class Switch
        {
            /// <summary>
            /// 读入数据
            /// </summary>
            public int no;
            public int trackNo;
            public int type;              // 1: /_  4： \~  2：~/  3: _\
            public int offset;

            /// <summary>
            /// 计算获得数据
            /// </summary>
            public int position;

            /// <summary>
            /// 坐标
            /// </summary>
            public int coordinateX;
            public int coordinateY;

            /// <summary>
            /// 道岔状态，0定位，1反为，2失去表示定位，3失去表示反位
            /// </summary>
            public int status = 0;
            public int isLock = 0; //0未锁闭，1锁闭
            /// <summary>
            /// 定反位坐标
            /// </summary>
            public int Dx;
            public int Dy;
            public int Fx;
            public int Fy;

            public MouseArea mouseArea = new MouseArea();
            public class MouseArea
            {
                public int left;
                public int right;
                public int top;
                public int bottom;
            }
        }
        public class Crossover
        {
            /// <summary>
            /// 读入数据
            /// </summary>
            public string name;
            public int startSwitchNo;
            public int endSwitchNo;
            public string startRefDgName;
            public string endRefDgName;
        }
        public class XTrack
        {
            /// <summary>
            /// 读入数据
            /// </summary>
            public string name;
            public int trackNo;
            //public int startCrossSwitchNo; //这里都是0
            //public int endCrossSwitchNo;   //这里都是0
            public double leftScale;
            public double rightScale;
            public int startSwitchNo;
            public int endSwitchNo;
        }
        public class STrack
        {
            /// <summary>
            /// 读入数据
            /// </summary>
            public string name;
            public int trackNo;
            //public int startCrossSwitchNo; //这里都是0
            //public int endCrossSwitchNo;   //这里都是0
            public double leftScale;
            public double rightScale;
            public int startSwitchNo;
            public int endSwitchNo;
        }
        public class InsulationJoint
        {
            /// <summary>
            /// 读入数据
            /// </summary>
            public string name;
            public int leftSwitchNo;
            public int rightSwitchNo;
            public string leftSignalName;
            public string rightSignalName;
            public int type;

            public int coordinateX;
            public int coordinateY;

            public int x1, x2, y1, y2;
        }

        public class DummyPoint
        {
            /// <summary>
            /// 读入数据
            /// </summary>
            public string name;
            public int refSwitchNo;
            public int refDir;
            public int trackNo;

            public int coordinateX;
            public int coordinateY;
        }

        public class DG
        {
            /// <summary>
            /// 读入数据
            /// </summary>
            public string name;
            public int branchNumber;
            public List<Branch> branchs = new List<Branch>();

            /// <summary>
            /// // 0,空闲，1故障，2,等待车占用，3，车占用
            /// </summary>
            public int status = 0;

            /// <summary>
            /// 分支id 
            /// </summary>
            public int branchPos;
            public class Branch
            {
                public int pointNumber;
                public List<Point> points = new List<Point>();
                public MouseArea mouseArea = new MouseArea();
                public class MouseArea
                {
                    public int left;
                    public int right;
                    public int top;
                    public int bottom;
                }
                public class Point
                {
                    public string name;
                    public int X;
                    public int Y;
                    /// <summary>
                    /// // 0 sig 1 dp 2 ij 3 sw
                    /// </summary>
                    public int type;
                    public int pos;
                }
            }
        }

        public class AlreadyHandleRoutes
        {
            public Route route;
            /// <summary>
            /// 已经办理的进路的状态:0空闲，1占用
            /// </summary>
            public int status = 0;
            public AlreadyHandleRoutes(Route route)
            {
                this.route = route;
            }
        }

        public class Route
        {
            public int no;
            //public int type;
            public int dgNumber;
            public int signalNumber; //此处已经没有意义了，只是读数据的时候用一下下，没有实际意义 
            public List<RouteDG> dgs = new List<RouteDG>();
            //public List<RouteSignal> signals = new List<RouteSignal>();
            public RouteSignal StartSignal = new RouteSignal();
            public RouteSignal EndSignal = new RouteSignal();
            //public RouteBtn StartBtn;
            //public RouteBtn EndBtn;
            //public List<RouteBtn> btns = new List<RouteBtn>();
            public List<RouteSwitch> switchs = new List<RouteSwitch>();

            //public class RouteBtn
            //{
            //    public string name;
            //}
            public class RouteSwitch
            {
                public int no;

                /// <summary>
                /// 道岔状态,0定位，1反位
                /// </summary>
                public int status;
                public int pos;
            }
            public class RouteDG
            {
                public string name;
                public int branch;
                public int pos;
            }
            public class RouteSignal
            {
                public string name;
                public string color;
                public int pos;
            }
        }

        public class TransponderGroup
        {
            public List<Transponder> transponders = new List<Transponder>();

            public int status = 0;

            public class Transponder
            {
                public string name;
                public int trackNo;
                public int groupNumber;
                public bool active;
                public int position;

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
