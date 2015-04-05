using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 列控培训平台操控系统.初始信息;
using 列控培训平台操控系统.车站;
using System.Drawing;
namespace 列控培训平台操控系统
{
    public partial class 操控界面 : Form
    {
        private void t_刷进路占用_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < InitializationInformation.stationNum; i++)
            {
                for (int j = 0; j < stations[i].alreadyHandleRoutes.Count; j++)
                {
                    Station.Route aroute = stations[i].alreadyHandleRoutes[j].route;
                    Station.Signal sig = stations[i].signals[aroute.StartSignal.pos];
                    for (int k = 0; k < aroute.dgNumber; k++)
                    {
                        #region 进路中对应到车站的dg,若有一个dg被占用或者怎么滴吧，信号机关闭
                        Station.DG dg = stations[i].dgs[aroute.dgs[k].pos];
                        if (dg.status != 2)
                        {
                            sig.color = "H";
                            sig.status = 0;
                            sig.occupyRoute = null;
                            stations[i].DrawDynamicMap(g);
                            pb_界面图片.Image = bp;
                            //当发生此类情况适合，可以信号重开，或者区故解。所以先区故解。
                        }
                        #endregion
                        #region 当发现道岔出问题的时候，也让信号关闭
                        Station.DG.Branch b = dg.branchs[dg.branchPos];
                        for (int l = 0; l < b.pointNumber; l++)
                        {
                            Station.DG.Branch.Point p = b.points[l];
                            if (p.type == 3)
                            {
                                int swpos = p.pos;
                                Station.Switch sw = stations[i].switchs[swpos];
                                if (sw.status >= 2)
                                {
                                    sig.color = "H";
                                    sig.status = 0;
                                    sig.occupyRoute = null;
                                    stations[i].DrawDynamicMap(g);
                                    pb_界面图片.Image = bp;
                                }
                            }
                        }
                        #endregion
                    }

                    #region (删除该进路)当发现某条进路，信号灯status为0，所有道岔（包括双动道岔也解锁），轨道电路status全为0状态

                    if (sig.status != 0) continue;
                    int flag = 0;
                    for (int k = 0; k < aroute.dgNumber; k++)
                    {
                        Station.DG dg = stations[i].dgs[aroute.dgs[k].pos];
                        if (dg.status != 0)
                        {
                            flag = 1;
                            break;
                        }
                    }
                    if (flag == 1) continue;
                    for (int k = 0; k < aroute.switchs.Count; k++)
                    {
                        Station.Switch sw = stations[i].switchs[aroute.switchs[k].pos];
                        if (sw.isLock != 0)
                        {
                            flag = 1;
                            break;
                        }
                    }
                    if (flag == 1) continue;
                    stations[i].alreadyHandleRoutes.Remove(stations[i].alreadyHandleRoutes[j]);
                    #endregion
                    //MessageBox.Show(stations[i].alreadyHandleRoutes.Count.ToString());
                }
            }
        }
    }
}
