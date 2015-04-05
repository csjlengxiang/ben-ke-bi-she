using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using System.Data;
using System.Diagnostics;
namespace 列控培训平台操控系统.车站
{
    public partial class Station
    {
        public string name;
        public string stationLogicID;
        public int kilometerPost;
        public int offset;
        public int trackNumber;       //股道数目
        public int XTrackNumber;
        public int STrackNumber;
        public int signalNumber;
        public int switchNumber;
        public int crossoverNumber;
        public int insulationJointNumber;
        public int dummyPointNumber;
        public int dgNumber;
        public int routeNumber;
        public int pos;

        public Signal[] signals;
        public Switch[] switchs;
        public XTrack[] xtracks;
        public STrack[] stracks;
        public Crossover[] crossovers;
        public InsulationJoint[] insulationJoints;
        public DummyPoint[] dummyPoints;
        public DG[] dgs;
        public Route[] routes;
        public List<AlreadyHandleRoutes> alreadyHandleRoutes = new List<AlreadyHandleRoutes>();
        public List<TransponderGroup> transponderGroups = new List<TransponderGroup>();
        /// <summary>
        /// 以下部分为函数
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public Station(string stationFilePath, string routeFilePath, string routeMdbFilePath, string transponderMdbPath, int pos)
        {
            this.pos = pos;
            //Stopwatch sww = new Stopwatch();
            //sww.Start();
            //sww.Stop();
            //MessageBox.Show(sww.Elapsed.Seconds.ToString() + " " + sww.Elapsed.Milliseconds.ToString());
            try
            {
                ReadSationFile(stationFilePath);
            }
            catch
            {
                MessageBox.Show("读取站场表错误");
            }
           
            try
            {
                ReadRouteFile(routeFilePath);
            }
            catch
            {
                MessageBox.Show("读取进路表错误");
            }
            
            try
            {
                ReadRouteMdbFile(routeMdbFilePath);
            }
            catch
            {
                MessageBox.Show("读取联锁数据.mdb出错");
            }

            try
            {
                ReadTransponderMdbFile(transponderMdbPath);
            }
            catch
            {
                MessageBox.Show("读取车站应答器数据出错");
            }
        }
        private int ti(string s)
        {
            return Convert.ToInt32(s);
        }
        private double td(string s)
        {
            return Convert.ToDouble(s);
        }
        private void ReadSationFile(string stationFilePath)
        {
            string s;
            string[] str;

            FileStream aFile = new FileStream(stationFilePath, FileMode.Open);
            StreamReader sr = new StreamReader(aFile, System.Text.Encoding.GetEncoding("gb2312"));

            //第一行：站场名字
            s = sr.ReadLine();
            name = s;

            //第二行：stationLogicID
            s = sr.ReadLine();
            str = s.Split(new char[] { ' ' });
            stationLogicID = str[1];

            //第三行：整体信息
            s = sr.ReadLine();
            str = s.Split(new char[] { ' ' });
            kilometerPost = ti(str[0]);
            offset = ti(str[1]);
            trackNumber = ti(str[2]);
            XTrackNumber = ti(str[4]);
            STrackNumber = ti(str[5]);

            //第四行：还是整体信息
            s = sr.ReadLine();
            str = s.Split(new char[] { ' ' });
            signalNumber = ti(str[0]);
            switchNumber = ti(str[1]);
            //DummyEndNum = ti(str[2]); 该数据一直为0，不考虑
            crossoverNumber = ti(str[3]);
            XTrackNumber = ti(str[4]);
            //ShuntXTrackNum = ti(str[5]); 该数据一直为0，不考虑
            STrackNumber = ti(str[6]);
            //ShuntSTrackNum = ti(str[7]); 该数据一直为0，不考虑
            insulationJointNumber = ti(str[8]);

            //随后signalNumber行
            signals = new Signal[signalNumber];
            for (int i = 0; i < signalNumber; i++)
            {
                s = sr.ReadLine();
                str = s.Split(new char[] { ' ' });
                signals[i] = new Signal();
                Signal signal = signals[i];
                signal.name = str[0];
                signal.offset = ti(str[1]);
                signal.dir = ti(str[2]);
                signal.trackNo = ti(str[3]);
            }
            //随后switchNumber行
            switchs = new Switch[switchNumber];
            for (int i = 0; i < switchNumber; i++)
            {
                s = sr.ReadLine();
                str = s.Split(new char[] { ' ' });
                //int id = ti(str[0]) - 1;
                int id = i;
                switchs[id] = new Switch();
                Switch _switch = switchs[id];
                _switch.no = ti(str[0]);
                _switch.offset = ti(str[1]);
                _switch.trackNo = ti(str[2]);
                _switch.type = ti(str[3]);
            }
            //随后crossoverNumber行
            crossovers = new Crossover[crossoverNumber];
            for (int i = 0; i < crossoverNumber; i++)
            {
                s = sr.ReadLine();
                str = s.Split(new char[] { ' ' });
                crossovers[i] = new Crossover();
                Crossover crossover = crossovers[i];
                crossover.name = str[0];
                crossover.startSwitchNo = ti(str[1]);
                crossover.endSwitchNo = ti(str[2]);
                crossover.startRefDgName = str[3];
                crossover.endRefDgName = str[4];
            }
            /*
             * 随后XTrackNumber行
             * 为什么这里是1
             * 因为最开始的主轨道不算
             */
            xtracks = new XTrack[XTrackNumber];
            for (int i = 1; i < XTrackNumber; i++)
            {
                s = sr.ReadLine();
                str = s.Split(new char[] { ' ' });
                xtracks[i] = new XTrack();
                XTrack xtrack = xtracks[i];
                xtrack.name = str[0];
                xtrack.trackNo = ti(str[1]);
                xtrack.startSwitchNo = ti(str[2]);
                xtrack.endSwitchNo = ti(str[3]);
                //xtrack.startCrossSwitchNo = ti(str[3]);  数据一直为0
                //xtrack.endCrossSwitchNo = ti(str[4]);    数据一直为0
                xtrack.leftScale = td(str[6]);
                xtrack.rightScale = td(str[7]);
            }

            //随后STrackNumber行
            stracks = new STrack[STrackNumber];
            for (int i = 1; i < STrackNumber; i++)
            {
                s = sr.ReadLine();
                str = s.Split(new char[] { ' ' });
                stracks[i] = new STrack();
                STrack strack = stracks[i];
                strack.name = str[0];
                strack.trackNo = ti(str[1]);
                strack.startSwitchNo = ti(str[2]);
                strack.endSwitchNo = ti(str[3]);
                //strack.startCrossSwitchNo = ti(str[3]);  数据一直为0
                //strack.endCrossSwitchNo = ti(str[4]);    数据一直为0
                strack.leftScale = td(str[6]);
                strack.rightScale = td(str[7]);
            }
            //随后insulationJointNumber行
            insulationJoints = new InsulationJoint[insulationJointNumber];
            for (int i = 0; i < insulationJointNumber; i++)
            {
                s = sr.ReadLine();
                str = s.Split(new char[] { ' ' });
                insulationJoints[i] = new InsulationJoint();
                InsulationJoint insulationJoint = insulationJoints[i];
                insulationJoint.name = str[0];
                if (str[1][0] == 'X' || str[1][0] == 'S')
                {
                    insulationJoint.leftSignalName = str[1];
                    insulationJoint.leftSwitchNo = 0;   //0意思是没有
                }
                else insulationJoint.leftSwitchNo = ti(str[1]);
                if (str[2][0] == 'X' || str[2][0] == 'S')
                {
                    insulationJoint.rightSignalName = str[2];
                    insulationJoint.rightSwitchNo = 0;  //0意思是没有
                }
                else insulationJoint.rightSwitchNo = ti(str[2]);
                insulationJoint.type = ti(str[3]);
            }
            sr.Close();
        }
        private void ReadRouteFile(string routeFilePath)
        {
            string s;
            string[] str;

            FileStream aFile = new FileStream(routeFilePath, FileMode.Open);
            StreamReader sr = new StreamReader(aFile, System.Text.Encoding.GetEncoding("gb2312"));

            //读站名
            s = sr.ReadLine();
            if (s != name)
            {
                MessageBox.Show("连锁表与站名不匹配");
                return;
            }
            //虚拟点获取
            s = sr.ReadLine();//跳过
            s = sr.ReadLine();//只适用str[2]
            str = s.Split(new char[] { ' ' });
            dummyPointNumber = ti(str[2]);
            s = sr.ReadLine();//跳过

            dummyPoints = new DummyPoint[dummyPointNumber];
            for (int i = 0; i < dummyPointNumber; i++)
            {
                s = sr.ReadLine();
                str = s.Split(new char[] { ' ' });
                dummyPoints[i] = new DummyPoint();
                DummyPoint dp = dummyPoints[i];
                dp.name = str[1];
                dp.refSwitchNo = ti(str[2]);
                dp.refDir = ti(str[3]);
                dp.trackNo = ti(str[4]);
            }

            //获取DG table
            s = sr.ReadLine();//跳过
            s = sr.ReadLine();//跳过
            s = sr.ReadLine();
            str = s.Split(new char[] { ' ' });
            dgNumber = ti(str[2]);

            dgs = new DG[dgNumber];
            for (int i = 0; i < dgNumber; i++)
            {
                s = sr.ReadLine();
                str = s.Split(new char[] { ' ' });
                dgs[i] = new DG();
                dgs[i].name = str[0];
                dgs[i].branchNumber = ti(str[1]);
                for (int j = 0; j < dgs[i].branchNumber; j++)
                {
                    s = sr.ReadLine();
                    str = s.Split(new char[] { ' ' });

                    DG.Branch branch = new DG.Branch();
                    branch.pointNumber = ti(str[0]);
                    for (int k = 0; k < branch.pointNumber; k++)
                    {
                        DG.Branch.Point p = new DG.Branch.Point();
                        p.name = str[k + 1];
                        branch.points.Add(p);
                    }
                    dgs[i].branchs.Add(branch);
                }
            }

            //获取联锁表
            s = sr.ReadLine();//跳过
            s = sr.ReadLine();//跳过
            s = sr.ReadLine();
            str = s.Split(new char[] { ' ' });

            routeNumber = ti(str[2]);
            routes = new Route[routeNumber];

            for (int i = 0; i < routeNumber; i++)
            {
                s = sr.ReadLine();
                str = s.Split(new char[] { ' ' });
                routes[i] = new Route();
                routes[i].no = ti(str[0]);
                //routes[i].type = ti(str[1]);
                routes[i].dgNumber = ti(str[2]);
                routes[i].signalNumber = ti(str[3]);
                for (int j = 0; j < routes[i].dgNumber; j++)
                {
                    s = sr.ReadLine();
                    str = s.Split(new char[] { ' ' });
                    Route.RouteDG dg = new Route.RouteDG();
                    dg.name = str[0];
                    dg.branch = ti(str[1]);
                    dg.pos = FindDgFromName(str[0]);
                    routes[i].dgs.Add(dg);
                }

                for (int j = 0; j < routes[i].signalNumber; j++)
                {
                    s = sr.ReadLine();

                    //这里dat的数据进路有问题，我sb了，还得读数据库
                    //str = s.Split(new char[] { ' ' });
                    //Route.RouteSignal sig = new Route.RouteSignal();
                    //sig.name = str[0];
                    //sig.pos = FindSignalFromName(str[0]);
                    //routes[i].signals.Add(sig);
                    //Route.RouteBtn btn = new Route.RouteBtn();
                    //btn.name = str[0] + "LA";
                    //routes[i].btns.Add(btn);
                }
                //这里只考虑两个点的btn，当然有其他很多类型，但是数据没有，以后可以改进
                //routes[i].StartSignal = routes[i].signals[0];   //这里是指针
                //routes[i].EndSignal = routes[i].signals[1];     //指针
                //routes[i].StartBtn = routes[i].btns[0];
                //routes[i].EndBtn = routes[i].btns[1];
            }
            sr.Close();
        }
        public int FindDgFromName(string name)
        {
            for (int i = 0; i < dgNumber; i++)
            {
                if (dgs[i].name == name) return i;
            }
            MessageBox.Show("通过名字找dg有问题");
            return -1;
        }
        public int FindRouteFromNo(int no)
        {
            for (int i = 0; i < routeNumber; i++)
                if (routes[i].no == no) return i;
            MessageBox.Show("由编号找不到进路");
            return -1;
        }
        public bool Hav(string s, char c)
        {
            for (int i = 0; i < s.Length; i++)
                if (s[i] == c)
                    return true;
            return false;
        }
        public int ChangeStrToInt(string s)
        {
            if (s == "I") return 1;
            else if (s == "II") return 2;
            int num = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] >= '0' && s[i] <= '9')
                    num = num * 10 + (int)(s[i] - '0');
                else break;
            }
            return num;
        }
        private void ReadRouteMdbFile(string routeMdbFilePath)
        {
            //MessageBox.Show(routeMdbFilePath);
            //Stopwatch sww = new Stopwatch();
            //sww.Start();

            OleDbConnection con = new OleDbConnection(routeMdbFilePath);
            con.Open();
            OleDbCommand com = con.CreateCommand();
            DataSet dataset = new DataSet();
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT 进路号码,信号机名称,信号机显示,敌对信号,道岔 FROM 联锁表_" + name, con);
            adapter.Fill(dataset);
            con.Close();

            //sww.Stop();
            //MessageBox.Show(sww.Elapsed.Seconds.ToString() + " " + sww.Elapsed.Milliseconds.ToString());
            
            foreach (DataRow r in dataset.Tables[0].Rows)
            {
                int no = ti(r["进路号码"].ToString()); 
                Route route = routes[no - 1]; //因为数据一一对应，考虑效率不用上面的方法了 
                route.StartSignal.name = r["信号机名称"].ToString();
                route.StartSignal.color = r["信号机显示"].ToString();
                route.EndSignal.name = r["敌对信号"].ToString();
                route.StartSignal.pos = FindSignalFromName(route.StartSignal.name);
                route.EndSignal.pos = FindSignalFromName(route.EndSignal.name);
                string tstr = r["道岔"].ToString();
                string[] str = tstr.Split(',');
                
                foreach (string st in str)
                {
                    if (st == "") continue;
                    if (Hav(st, '/'))
                    {
                        string stt;
                        if (st[0] == '(')
                            stt = st.Substring(1, st.Length - 2);
                        else stt = st;
                        string[] str1 = stt.Split('/');
                        Route.RouteSwitch sw1 = new Route.RouteSwitch();
                        Route.RouteSwitch sw2 = new Route.RouteSwitch();
                        sw1.no = ti(str1[0]);
                        sw2.no = ti(str1[1]);
                        sw1.pos = FindSwitchFromSwitchNo(sw1.no);
                        sw2.pos = FindSwitchFromSwitchNo(sw2.no);
                        if (st[0] == '(')
                        {
                            sw1.status = 1;
                            sw2.status = 1;
                        }
                        else
                        {
                            sw1.status = 0;
                            sw2.status = 0;
                        }
                        route.switchs.Add(sw1);
                        route.switchs.Add(sw2);
                    }
                    else
                    {
                        if (st[0] == '(')
                        {
                            Route.RouteSwitch sw = new Route.RouteSwitch();
                            string sst = st.Substring(1, st.Length - 2);
                            sw.no = ti(sst);
                            sw.pos = FindSwitchFromSwitchNo(sw.no);
                            sw.status = 1;
                            route.switchs.Add(sw);
                        }
                        else
                        {
                            Route.RouteSwitch sw = new Route.RouteSwitch();
                            string sst = st;
                            sw.no = ti(sst);
                            sw.pos = FindSwitchFromSwitchNo(sw.no);
                            sw.status = 0;
                            route.switchs.Add(sw);
                        }
                    }
                }
            }
        }

        private void ReadTransponderMdbFile(string transponderMdbPath)
        {
            OleDbConnection con = new OleDbConnection(transponderMdbPath);
            con.Open();
            OleDbCommand com = con.CreateCommand();
            DataSet dataset = new DataSet();
            string sqlstr = "select 应答器名称,所属股道,组内编号,里程,应答器类型 from 车站应答器表 where 所属车站='" + name + "'";
            OleDbDataAdapter adapter = new OleDbDataAdapter(sqlstr, con);
            adapter.Fill(dataset);
            con.Close();

            List<TransponderGroup.Transponder> a = new List<TransponderGroup.Transponder>();
            for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
            {
                DataRow r = dataset.Tables[0].Rows[i];
                TransponderGroup.Transponder t = new TransponderGroup.Transponder();
                t.name = r["应答器名称"].ToString();
                t.trackNo = ChangeStrToInt(r["所属股道"].ToString());
                t.groupNumber = ti(r["组内编号"].ToString());
                t.position = ti(r["里程"].ToString());
                t.active = (r["应答器类型"].ToString() == "有源");
                a.Add(t);
            }
             //初始化
            int[] v = new int[a.Count];
            for (int i = 0; i < a.Count; i++)
                v[i] = 0;
            //编组
            for (int i = 0; i < a.Count; i++)
            {
                if (v[i] == 1) continue;
                TransponderGroup z = new TransponderGroup();
                z.transponders.Add(a[i]);
                string[] str1 = a[i].name.Split('-');
                for (int j = 0; j < a.Count; j++)
                {
                    if (i == j) continue;
                    if (v[j] == 1) continue;
                    string[] str2 = a[j].name.Split('-');
                    if (str1[0] == str2[0])
                    {
                        v[j] = 1;
                        z.transponders.Add(a[j]);
                    }
                }
                transponderGroups.Add(z);
            }
        }
    }
}
