using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 列控培训平台操控系统.初始信息;
using 列控培训平台操控系统.车站;
using System.Drawing;
using 列控培训平台操控系统.区间;
namespace 列控培训平台操控系统
{
    public partial class 操控界面 : Form
    {
        private bool isMouseDown = false;

        private void pb_界面图片_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            preMouse.x = e.X;
            preMouse.y = e.Y;
            Cursor = Cursors.Hand;
        }

        private void pb_界面图片_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            Cursor = Cursors.Default;
        }
    }
}
