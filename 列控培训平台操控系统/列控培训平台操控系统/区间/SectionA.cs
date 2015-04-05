using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace 列控培训平台操控系统.区间
{
    public partial class Section
    {
        public List<Track> Xtracks = new List<Track>();
        public List<Track> Stracks = new List<Track>();
        public List<ChainScission> chainScissions = new List<ChainScission>();
        public List<TransponderGroup> XtransponderGroups = new List<TransponderGroup>();
        public List<TransponderGroup> StransponderGroups = new List<TransponderGroup>();
        public int realStartPosition;
        public int realEndPosition;
        public int startPosition;
        public int endPosition;
        public string startStation;
        public string endStation;
        public int startCoordinateX;
        public int endCoordinateX;

        public Section(string startStation, string endStation, string sectionInfMdbPath)
        {
            try
            {
                ReadXtrack(startStation, endStation, sectionInfMdbPath);
            }
            catch
            {
                MessageBox.Show("读取下行轨道电路有问题");
            }
            try
            {
                ReadStrack(startStation, endStation, sectionInfMdbPath);
            }
            catch
            {
                MessageBox.Show("读取上行轨道电路有问题");
            }
            try
            {
                ReadXTransponder(startStation, endStation, sectionInfMdbPath);
            }
            catch
            {
                MessageBox.Show("读取下行应答器表有问题");
            }
            try
            {
                ReadSTransponder(startStation, endStation, sectionInfMdbPath);
            }
            catch
            {
                MessageBox.Show("读取上行应答器表有问题");
            }
            try
            {
                ReadChainScission(startStation, endStation, sectionInfMdbPath);
            }
            catch
            {
                MessageBox.Show("读取长短链信息表有问题");
            }
            //MessageBox.Show("读取区间的数据库成功");
        }
        public int ti(string s)
        {
            return Convert.ToInt32(s);
        }
        public void ReadXtrack(string startStation, string endStation, string sectionInfMdbPath)
        {
            OleDbConnection con = new OleDbConnection(sectionInfMdbPath);
            con.Open();
            OleDbCommand com = con.CreateCommand();
            DataSet dataset = new DataSet();
            string sqlstr = "select 车站名称,信号点里程,信号点类型,轨道电路名称,长度 from 区间轨道电路信息表 where 线别='下行线' and 适用方向='正向' order by 信号点里程";
            OleDbDataAdapter adapter = new OleDbDataAdapter(sqlstr, con);
            adapter.Fill(dataset);
            con.Close();
            for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
            {
                DataRow r = dataset.Tables[0].Rows[i];
                if (r["车站名称"].ToString() == startStation && r["信号点类型"].ToString() == "出站口")
                {
                    while (i < dataset.Tables[0].Rows.Count)
                    {
                        r = dataset.Tables[0].Rows[i];
                        if (r["信号点类型"].ToString() == "出站口" && r["车站名称"].ToString() == endStation)
                        {
                            break;
                        }
                        Track track = new Track();
                        track.haveTrack = (r["信号点类型"].ToString() == "通过信号机") ? true : false;
                        track.name = r["轨道电路名称"].ToString();
                        track.trackLen = ti(r["长度"].ToString());
                        track.realStartPosition = ti(r["信号点里程"].ToString());
                        Xtracks.Add(track);
                        i++;
                    }
                    break;
                }
            }
        }
        public void ReadStrack(string startStation, string endStation, string sectionInfMdbPath)
        {
            OleDbConnection con = new OleDbConnection(sectionInfMdbPath);
            con.Open();
            OleDbCommand com = con.CreateCommand();
            DataSet dataset = new DataSet();
            string sqlstr = "select 车站名称,信号点里程,信号点类型,轨道电路名称,长度 from 区间轨道电路信息表 where 线别='上行线' and 适用方向='反向' order by 信号点里程";
            OleDbDataAdapter adapter = new OleDbDataAdapter(sqlstr, con);
            adapter.Fill(dataset);
            con.Close();
            for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
            {
                DataRow r = dataset.Tables[0].Rows[i];
                if (r["车站名称"].ToString() == startStation && r["信号点类型"].ToString() == "出站口")
                {
                    while (i < dataset.Tables[0].Rows.Count)
                    {
                        r = dataset.Tables[0].Rows[i];
                        if (r["信号点类型"].ToString() == "出站口" && r["车站名称"].ToString() == endStation)
                        {
                            break;
                        }
                        Track track = new Track();
                        track.haveTrack = (r["信号点类型"].ToString() == "通过信号机") ? true : false;
                        track.name = r["轨道电路名称"].ToString();
                        track.trackLen = ti(r["长度"].ToString());
                        track.realStartPosition = ti(r["信号点里程"].ToString());
                        Stracks.Add(track);
                        i++;
                    }
                    break;
                }
            }
        }
        public void ReadXTransponder(string startStation, string endStation, string sectionInfMdbPath)
        {
            OleDbConnection con = new OleDbConnection(sectionInfMdbPath);
            con.Open();
            OleDbCommand com = con.CreateCommand();
            DataSet dataset = new DataSet();
            string sqlstr = "select * from 区间应答器表 where 线别='下行线' order by 里程"; //station.Name, "BSF-1",  "select * from 区间应答器表 where 线别='下行线' order by 信号点里程
            OleDbDataAdapter adapter = new OleDbDataAdapter(sqlstr, con);
            adapter.Fill(dataset);
            con.Close();
            string pre = "";
            TransponderGroup transponderGroup = new TransponderGroup();
            for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
            {
                DataRow r = dataset.Tables[0].Rows[i];
                if (r["所属车站"].ToString() == startStation && r["应答器名称"].ToString() == "BSF-1")
                {
                    while (i < dataset.Tables[0].Rows.Count)
                    {
                        r = dataset.Tables[0].Rows[i];
                        if ((r["应答器名称"].ToString() == "BSF-1") && (r["所属车站"].ToString() == endStation))
                        {
                            break;
                        }
                        TransponderGroup.Transponder transponder = new TransponderGroup.Transponder();
                        transponder.groupNumber = ti(r["组内编号"].ToString());
                        transponder.active = (r["应答器类型"].ToString() == "有源") ? true : false;
                        transponder.realPosition = ti(r["里程"].ToString());
                        transponder.name = r["应答器名称"].ToString();

                        string[] str = transponder.name.Split('-');
                        if (str[0] != pre)
                        {
                            if (pre != "")
                                XtransponderGroups.Add(transponderGroup);
                            transponderGroup = new TransponderGroup();
                        }
                        transponderGroup.transponders.Add(transponder);
                        i++;
                        pre = str[0];
                    }
                    break;
                }
            }

        }
        public void ReadSTransponder(string startStation, string endStation, string sectionInfMdbPath)
        {
            OleDbConnection con = new OleDbConnection(sectionInfMdbPath);
            con.Open();
            OleDbCommand com = con.CreateCommand();
            DataSet dataset = new DataSet();
            string sqlstr = "select * from 区间应答器表 where 线别='上行线' order by 里程"; //station.Name, "BSF-1",  "select * from 区间应答器表 where 线别='下行线' order by 信号点里程
            OleDbDataAdapter adapter = new OleDbDataAdapter(sqlstr, con);
            adapter.Fill(dataset);
            con.Close();
            string pre = "";
            TransponderGroup transponderGroup = new TransponderGroup();
            for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
            {
                DataRow r = dataset.Tables[0].Rows[i];
                if (r["所属车站"].ToString() == startStation && r["应答器名称"].ToString() == "BS-3")
                {
                    while (i < dataset.Tables[0].Rows.Count)
                    {
                        r = dataset.Tables[0].Rows[i];
                        if ((r["应答器名称"].ToString() == "BS-3") && (r["所属车站"].ToString() == endStation))
                        {
                            break;
                        }
                        TransponderGroup.Transponder transponder = new TransponderGroup.Transponder();
                        transponder.groupNumber = ti(r["组内编号"].ToString());
                        transponder.active = (r["应答器类型"].ToString() == "有源") ? true : false;
                        transponder.realPosition = ti(r["里程"].ToString());
                        transponder.name = r["应答器名称"].ToString();

                        string[] str = transponder.name.Split('-');
                        if (str[0] != pre)
                        {
                            if (pre != "") 
                                StransponderGroups.Add(transponderGroup);
                            transponderGroup = new TransponderGroup();
                        }
                        transponderGroup.transponders.Add(transponder);
                        i++;
                        pre = str[0];
                    }
                    break;
                }
            }

        }
        public void ReadChainScission(string startStation, string endStation, string sectionInfMdbPath)
        {
            OleDbConnection con = new OleDbConnection(sectionInfMdbPath);
            con.Open();
            OleDbCommand com = con.CreateCommand();
            DataSet dataset = new DataSet();
            string sqlstr = "select 起点,终点 from 长短链信息表 where 线别='下行线' order by 起点"; //station.Name, "BSF-1",  "select * from 区间应答器表 where 线别='下行线' order by 信号点里程
            OleDbDataAdapter adapter = new OleDbDataAdapter(sqlstr, con);
            adapter.Fill(dataset);
            con.Close();
            for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
            {
                DataRow r = dataset.Tables[0].Rows[i];
                ChainScission chainScission = new ChainScission();
                chainScission.startPosition = ti(r["起点"].ToString());
                chainScission.endPosition = ti(r["终点"].ToString());
                chainScissions.Add(chainScission);
            }
        }
    }
}
