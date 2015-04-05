using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace 列控培训平台操控系统.初始信息
{
    class InitializationInformation
    {
        private static string path = System.IO.Directory.GetCurrentDirectory();
        public static string stationRouteMdbPath = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + @"\数据\联锁数据.mdb";
        public static string stationTransponderMdbPath = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + @"\数据\CTCS-3级列控系统仿真测试平台总体数据库-武广线.mdb";
        public static string sectionInfMdbPath = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + @"\数据\CTCS-3级列控系统仿真测试平台总体数据库-武广线.mdb";
        
        public static int stationNum;
        public static string[] stationInfPath;
        public static string[] stationRouteTablePath;

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public InitializationInformation()
        {
            if (ReadInitFile("配置信息","车站数目") == false) return;
            stationInfPath = new string[stationNum];
            stationRouteTablePath = new string[stationNum];
            for (int i = 0; i < stationNum; i++)
            {
                string key = ReadInitFileKey("配置信息", "车站ID[" + i.ToString() + "]");
                stationInfPath[i] = ReadFile(key, "站场文件路径");
                if (stationInfPath[i] == "") return;
                stationRouteTablePath[i] = ReadFile(key, "进路表文件路径");
                if (stationRouteTablePath[i] == "") return;
            }
            for (int i = 0; i < stationNum; i++)
            {
                stationInfPath[i] = Change(stationInfPath[i]);
                stationRouteTablePath[i] = Change(stationRouteTablePath[i]);
                //MessageBox.Show(stationInfPath[i] + " " + stationRouteTablePath[i]);
            }
        }
        private string Change(string s)
        {
            string t = InitializationInformation.path;
            for (int i = 1; i < s.Length; i++)
                if (s[i] == '/')
                    t += '\\';
                else t += s[i];
            return t;
        }
        private bool ReadInitFile(string section,string key)
        {
            try
            {
                string path = InitializationInformation.path + @"\初始化数据\配置文件.ini";
                StringBuilder ret = new StringBuilder(512);
                GetPrivateProfileString(section, key, null, ret, 255, path);
                stationNum = ti(ret.ToString()); 
                //MessageBox.Show("读取车站配置文件成功");
                return true;
            }
            catch
            {
                MessageBox.Show("读取车站配置文件出错");
                return false;
            }
        }
        private string ReadInitFileKey(string section, string key)
        {
            try
            {
                string path = InitializationInformation.path + @"\初始化数据\配置文件.ini";
                StringBuilder ret = new StringBuilder(512);
                GetPrivateProfileString(section, key, null, ret, 255, path);
                return ret.ToString();
            }
            catch
            {
                MessageBox.Show("读取车站配置文件出错");
                return "";
            }
        }
        private string ReadFile(string Key, string Key1)
        {
            try
            {
                string path = InitializationInformation.path + @"\初始化数据\站场配置文件.ini";
                string section = "车站" + Key + "配置";
                string key = Key1;
                StringBuilder ret = new StringBuilder(512);
                GetPrivateProfileString(section, key, null, ret, 255, path);
                return ret.ToString();
            }
            catch
            {
                MessageBox.Show("读取站场配置文件出错");
                return "";
            }
        }
        private int ti(string s)
        {
            return Convert.ToInt32(s);
        }
    }
}
