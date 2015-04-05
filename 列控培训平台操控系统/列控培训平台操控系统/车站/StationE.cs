using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace 列控培训平台操控系统.车站
{
    partial class Station
    {
        private List<int> FindRoute(Signal st, Signal en)
        {
            List<int> a = new List<int>();
            for (int i = 0; i < routeNumber; i++)
            {
                Route route = routes[i];
                if (route.StartSignal.name == st.name && route.EndSignal.name == en.name)
                {
                    a.Add(i);
                }
            }
            return a;
        }
        /// <summary>
        /// 负责判定进路是否可以办理或者取消，若可以办理或取消更新进路状态
        /// </summary>
        /// <param name="route"></param>
        /// <returns></returns>
        private bool CanHandleRoute(Route route)
        {
            if (signals[route.StartSignal.pos].status != 0)
            {
                MessageBox.Show("信号机有问题，无法办理进路");
                return false;
            }
            for (int i = 0; i < route.switchs.Count; i++)
            {
                Station.Route.RouteSwitch rsw = route.switchs[i];
                if (switchs[rsw.pos].isLock == 1 && switchs[rsw.pos].status != rsw.status)
                {
                    MessageBox.Show("有道岔已经锁闭，但办理进路要动已锁闭道岔，无法办理");
                    return false;
                }
                if (switchs[rsw.pos].status >= 2)
                {
                    MessageBox.Show("道岔有问题，无法办理");
                    return false;
                }
            }
            for (int i = 0; i < route.dgNumber; i++)
            {
                Station.Route.RouteDG rdg = route.dgs[i];
                if (dgs[rdg.pos].status != 0)
                {
                    MessageBox.Show("轨道电路有问题，无法办理");
                    return false;
                }
            }

            #region 更新信号机状态，更改信号机颜色，稍后刷新用
            Signal sig = signals[route.StartSignal.pos];
            sig.status = 1;
            sig.occupyRoute = route;
            sig.stationPos = this.pos;
            sig.color = route.StartSignal.color;
            #endregion

            #region 更新道岔状态
            for (int i = 0; i < route.switchs.Count; i++)
            {
                Station.Route.RouteSwitch rsw = route.switchs[i];
                Switch sw = switchs[rsw.pos];
                sw.status = rsw.status;
                sw.isLock = 1;
            }
            #endregion

            #region 更新轨道电路状态
            for (int i = 0; i < route.dgNumber; i++)
            {
                Station.Route.RouteDG rdg = route.dgs[i];
                dgs[rdg.pos].status = 2;
                dgs[rdg.pos].branchPos = rdg.branch;
            }
            #endregion
            MessageBox.Show("进路" + route.no.ToString() + "办理");
            return true;
        }
        private bool CanCancelRoute(Route route)
        {
            if (signals[route.StartSignal.pos].status != 1)
            {
                MessageBox.Show("信号机有问题，无法取消进路");
                return false;
            }
            //for (int i = 0; i < route.switchs.Count; i++)
            //{
            //    Station.Route.RouteSwitch rsw = route.switchs[i];
            //    if (switchs[rsw.pos].isLock == 1)
            //    {
            //        MessageBox.Show("有道岔已经锁闭，无法办理");
            //        return false;
            //    }
            //    if (switchs[rsw.pos].status >= 2)
            //    {
            //        MessageBox.Show("道岔有问题，无法办理");
            //        return false;
            //    }
            //}
            for (int i = 0; i < route.dgNumber; i++)
            {
                Station.Route.RouteDG rdg = route.dgs[i];
                if (dgs[rdg.pos].status != 2)
                {
                    MessageBox.Show("轨道电路有问题，无法取消");
                    return false;
                }
            }

            #region 更新信号机状态，更改信号机颜色，稍后刷新用
            Signal sig = signals[route.StartSignal.pos];
            sig.status = 0;
            sig.occupyRoute = null;
            sig.color = "H";
            #endregion

            #region 更新道岔状态
            for (int i = 0; i < route.switchs.Count; i++)
            {
                Station.Route.RouteSwitch rsw = route.switchs[i];
                Switch sw = switchs[rsw.pos];
                //sw.status = rsw.status;
                sw.isLock = 0;
            }
            #endregion

            #region 更新轨道电路状态
            for (int i = 0; i < route.dgNumber; i++)
            {
                Station.Route.RouteDG rdg = route.dgs[i];
                dgs[rdg.pos].status = 0;
                //dgs[rdg.pos].branchPos = rdg.branch;
            }
            #endregion
            MessageBox.Show("进路" + route.no.ToString() + "取消");
            return true;
        }

        public void CancelRoute(Route route)
        {
            if (CanCancelRoute(route))
            {
                for (int i = 0; i < alreadyHandleRoutes.Count; i++)
                {
                    if (alreadyHandleRoutes[i].route == route)
                    {
                        alreadyHandleRoutes.Remove(alreadyHandleRoutes[i]);
                        //MessageBox.Show(alreadyHandleRoutes.Count.ToString());
                        return;
                    }
                }
            }
        }
        public void HandleRoute(Signal st, Signal en)
        {
            List<int> routeNums = FindRoute(st, en);
            for (int i = 0; i < routeNums.Count; i++)
            {
                if (CanHandleRoute(routes[routeNums[i]]))
                {
                    alreadyHandleRoutes.Add(new AlreadyHandleRoutes(routes[routeNums[i]]));
                    return;
                }
            }
        }
    }
}
