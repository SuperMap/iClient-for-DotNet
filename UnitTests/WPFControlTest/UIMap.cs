namespace MapControlTest
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Input;
    using System.CodeDom.Compiler;
    using System.Text.RegularExpressions;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
    using System.Diagnostics;
    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
    using System.IO;


    public partial class UIMap
    {
        /// <summary>
        /// 开启一个新的供测试的UI进程
        /// </summary>
        public ApplicationUnderTest OpenApp()
        {
            CloseProcesses();
            string currentPath = Environment.CurrentDirectory;
#if DEBUG
            string demoPath = currentPath + @"..\..\..\..\demo\demo.WpfApplication\bin\debug\demo.WpfApplication.exe";
            demoPath = Path.GetFullPath(demoPath);
#else
            string demoPath = currentPath + @"..\..\..\..\demo\demo.WpfApplication\bin\release\demo.WpfApplication.exe";
            demoPath = Path.GetFullPath(demoPath);
#endif
            ApplicationUnderTest testApp = ApplicationUnderTest.Launch(demoPath);
            this.mUI提示Window = new MapControlTest.UI提示Window();
            this.UI提示Window.UI地图加载成功Window.UI地图加载成功Text.WaitForControlExist(30000);
            Mouse.Click(this.UI提示Window.UI确定Window.UI确定Button, new Point(1, 1));
            this.UI提示Window.WaitForControlNotExist(30000);
            return testApp;
        }

        /// <summary>
        /// 清理之前没有关闭的进程
        /// </summary>
        public void CloseProcesses()
        {
            Process[] array = Process.GetProcessesByName("demo.WpfApplication");
            for (int i = array.Length - 1; i >= 0; i--)
            {
                try
                {
                    array[i].Kill();
                }
                catch
                {

                }
            }
        }

        /// <summary>
        /// 关闭测试用的UI进程
        /// </summary>
        public void CloseApp(ApplicationUnderTest app)
        {
            try
            {
                app.Close();
            }
            catch
            {

            }
            if (!app.WaitForControlNotExist(5000))
            {
                try
                {
                    app.Process.Kill();
                }
                catch
                {

                }
            }
        }

        public void InitUI提示Window()
        {
            this.mUI提示Window = new UI提示Window();
        }

        /// <summary>
        /// 拖动地图的操作，将地图从Start点拖动到End点
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public void DragMap(Point start, Point end)
        {
            #region Variable Declarations
            WpfCustom uIMapCustom = this.UIMainWindowWindow.UIMapCustom;
            #endregion

            // 将  “Map” 自定义控件 从start移至end
            Mouse.StartDragging(uIMapCustom, start);
            Mouse.StopDragging(uIMapCustom, end.X - start.X, end.Y - start.Y);
        }

        /// <summary>
        /// 获取当前中心点的值
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void GetNowCenter(out double x, out double y)
        {
            x = 0;
            double.TryParse(this.UIMainWindowWindow.UINowCenterXEdit.Text, out x);
            y = 0;
            double.TryParse(this.UIMainWindowWindow.UINowCenterYEdit.Text, out y);
        }

        /// <summary>
        /// 点击拖动按钮，使地图能够拖动。
        /// </summary>
        public void ClickDragButton()
        {
            #region Variable Declarations
            WpfButton uI拖动Button = this.UIMainWindowWindow.UI拖动Button;
            #endregion

            // 单击 “拖动” 按钮
            Mouse.Click(uI拖动Button, new Point(69, 5));
        }

    }
}
