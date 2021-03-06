﻿using FPlug.AlertUI;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FPlug.Tools
{
    class AlertTool
    {
        #region 暴露出去的方法
        //显示Item弹框
        public static void showItemAlertUI(int index = -1)
        {
            ItemAlertUI itemAlertUI = new ItemAlertUI(index);
            //初始化窗体
            Window window = initWindow("Project Config", 200);
            //设置window窗体内容
            window.Content = itemAlertUI;
            //自动聚焦
            itemAlertUI.name.Focus();
            //显示窗体
            window.ShowDialog();
        }

        //显示rule弹框
        public static void showRuleAlertUI(int parentIndex, int index = -1, string handleType = "")
        {
            string type = Main.mainData.type;
            //初始化窗体
            Window window = initWindow("Rule Config", 310);
            //设置window窗体内容
            if (type == "host")
            {
                HostAlertUI hostAlertUI = new HostAlertUI(parentIndex, index, handleType);
                window.Content = hostAlertUI;
                //自动聚焦
                hostAlertUI.ip.Focus();
            }
            else if (type == "file")
            {
                FIleAlertUI fileAlertUI = new FIleAlertUI(parentIndex, index, handleType);
                window.Content = fileAlertUI;
                //自动聚焦
                fileAlertUI.url.Focus();
            }
            else if (type == "https")
            {
                HttpsAlertUI httpsAlertUI = new HttpsAlertUI(parentIndex, index, handleType);
                window.Content = httpsAlertUI;
                //重置一下高度
                window.Height = 260 + 30;
                //自动聚焦
                httpsAlertUI.url.Focus();
            }
            else if (type == "header")
            {
                HeaderAlertUI headerAlertUI = new HeaderAlertUI(parentIndex, index, handleType);
                window.Content = headerAlertUI;
                //重置一下高度
                window.Height = 460 + 30;
                //自动聚焦
                headerAlertUI.url.Focus();
            }
            //显示窗体
            window.ShowDialog();
        }

        //显示说明弹框
        public static void showExplainAlertUI(string type)
        {
            string title = "";
            if (type == "host")
            {
                title = "Host Mapping";
            }
            else if (type == "file")
            {
                title = "File Mapping";
            }
            else if (type == "https")
            {
                title = "Https To Http";
            }
            else if (type == "header")
            {
                title = "Header Replace";
            }
            else if (type == "tools")
            {
                title = "Tools";
            }
            else if (type == "console")
            {
                title = "Console Log";
            }
            ExplainAlertUI explainAlertUI = new ExplainAlertUI(type);
            //初始化窗体
            Window window = initWindow(title, 450, 700);
            //设置window窗体内容
            window.Content = explainAlertUI;
            //显示窗体
            window.ShowDialog();
        }
        #endregion

        #region 内部方法
        //初始化窗体
        private static Window initWindow(string tilte, int height, int width = 500)
        {
            IntPtr iconPtr = Properties.Resources.icon.GetHbitmap();
            ImageSource icon = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(iconPtr, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

            Window window = new Window();
            //设置宽和高
            window.Width = width;
            window.Height = height + 30;//状态栏的高度是30
            //去掉最小化、最大化按钮
            window.ResizeMode = 0;
            window.Title = tilte;
            //设置显示在中间
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //设置icon
            window.Icon = icon;
            //返回对应的窗体
            return window;
        }
        #endregion
    }
}
