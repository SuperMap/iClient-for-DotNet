using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;


namespace MapControlTest
{
    /// <summary>
    /// WPFMapTest 的摘要说明
    /// </summary>
    [CodedUITest]
    public class WPFMapTest
    {
        public WPFMapTest()
        {
        }

        ApplicationUnderTest _app;

        [TestInitialize]
        public void TestInit()
        {
            _app = this.UIMap.OpenApp();
        }

        [TestCleanup]
        public void Test()
        {
            this.UIMap.CloseApp(_app);
        }

        /// <summary>
        /// 测试当MapControl中的CurrentAction不等于PanAction时，是否能拖动地图。
        /// 如果地图中心点没有变化，则不能拖动；如果变化，则能拖动。
        /// </summary>
        [TestMethod]
        public void UnableDragTest()
        {
            // 若要为此测试生成代码，请从快捷菜单中选择“为编码的 UI 测试生成代码”，然后选择菜单项之一。
            // 有关生成的代码的详细信息，请参见 http://go.microsoft.com/fwlink/?LinkId=179463
            
            Point start = new Point(234, 112);
            Point end = new Point(441, 255);
            double xOld = 0;
            double yOld = 0;
            UIMap.GetNowCenter(out xOld, out yOld);

            UIMap.DragMap(start, end);
            
            double xNew = 0;
            double yNew = 0;
            UIMap.GetNowCenter(out xNew, out yNew);

            Assert.AreEqual(xOld, xNew, "在不能拖动时，拖动地图发现中心点X的值发生变化");
            Assert.AreEqual(yOld, yNew, "在不能拖动时，拖动地图发现中心点Y的值发生变化");
            
        }

        /// <summary>
        /// 测试当MapControl中的CurrentAction等于PanAction时，是否能拖动地图。
        /// 如果地图中心点没有变化，则不能拖动；如果变化，则能拖动。
        /// </summary>
        [TestMethod]
        public void EnableDragTest()
        {
            this.UIMap.ClickDragButton();
            //线拖动地图一次，避免在第一次操作时出现空值的情况。
            UIMap.DragMap(new Point(12, 12), new Point(24, 24));

            UIMap.InitUI提示Window();
            //等待地图加载完成，弹出提示框
            Assert.IsTrue(UIMap.UI提示Window.UI地图加载成功Window.UI地图加载成功Text.WaitForControlExist(30000), "拖动地图后，地图未能加载");
            //点击确定按钮，关闭提示框
            Microsoft.VisualStudio.TestTools.UITesting.Mouse.Click(UIMap.UI提示Window.UI确定Window.UI确定Button, new Point(1, 1));
            //等待提示框消失
            Assert.IsTrue(UIMap.UI提示Window.WaitForControlNotExist(30000), "点击确定按钮后，提示框未能关闭");

            Point start = new Point(234, 112);
            Point end = new Point(441, 255);
            double xOld = 0;
            double yOld = 0;
            UIMap.GetNowCenter(out xOld, out yOld);

            UIMap.DragMap(start, end);

            UIMap.InitUI提示Window();
            //等待地图加载完成，弹出提示框
            Assert.IsTrue(UIMap.UI提示Window.UI地图加载成功Window.UI地图加载成功Text.WaitForControlExist(30000), "拖动地图后，地图未能加载");
            //点击确定按钮，关闭提示框
            Microsoft.VisualStudio.TestTools.UITesting.Mouse.Click(UIMap.UI提示Window.UI确定Window.UI确定Button, new Point(1, 1));
            //等待提示框消失
            Assert.IsTrue(UIMap.UI提示Window.WaitForControlNotExist(30000), "点击确定按钮后，提示框未能关闭");

            double xNew = 0;
            double yNew = 0;
            UIMap.GetNowCenter(out xNew, out yNew);

            Assert.IsTrue(xOld != xNew || yOld != yNew, "在能拖动时，地图拖动后，中心点的值没有变化");
            Assert.IsTrue(xOld > xNew, "中心点X值变化方向与预期方向不一致");
            Assert.IsTrue(yOld < yNew, "中心点Y值变化方向与预期方向不一致");
        }

        [TestMethod]
        public void ZoomAndMouseWheelTest()
        {
            #region Variable Declarations
            WpfEdit uIZoomEdit = UIMap.UIMainWindowWindow.UIZoomEdit;
            WpfButton uI确定Button1 = UIMap.UIMainWindowWindow.UI确定Button1;
            WpfCustom map = UIMap.UIMainWindowWindow.UIMapCustom;
            #endregion

            // 在 “Zoom” 文本框 中键入“3”
            uIZoomEdit.Text = "3";

            // 单击 “确定” 按钮
            Microsoft.VisualStudio.TestTools.UITesting.Mouse.Click(uI确定Button1, new Point(21, 8));

            UIMap.InitUI提示Window();
            //等待地图加载完成，弹出提示框
            Assert.IsTrue(UIMap.UI提示Window.UI地图加载成功Window.UI地图加载成功Text.WaitForControlExist(30000), "设置缩放级别后，地图未能加载");
            //点击确定按钮，关闭提示框
            Microsoft.VisualStudio.TestTools.UITesting.Mouse.Click(UIMap.UI提示Window.UI确定Window.UI确定Button, new Point(1, 1));
            //等待提示框消失
            Assert.IsTrue(UIMap.UI提示Window.WaitForControlNotExist(30000),"点击确定按钮后，提示框未能关闭");

            Assert.AreEqual(3, double.Parse(UIMap.UIMainWindowWindow.UIItemEdit.Text), "当前缩放级别与预期的不一致");

            Microsoft.VisualStudio.TestTools.UITesting.Mouse.Move(map, new Point(100, 100));
            //滚轮滚动一次，缩回一级
            Microsoft.VisualStudio.TestTools.UITesting.Mouse.MoveScrollWheel(-1);

            UIMap.InitUI提示Window();
            //等待地图加载完成，弹出提示框
            Assert.IsTrue(UIMap.UI提示Window.UI地图加载成功Window.UI地图加载成功Text.WaitForControlExist(30000), "鼠标滚轮滚动后，地图未能加载");
            //点击确定按钮，关闭提示框
            Microsoft.VisualStudio.TestTools.UITesting.Mouse.Click(UIMap.UI提示Window.UI确定Window.UI确定Button, new Point(1, 1));
            //等待提示框消失
            Assert.IsTrue(UIMap.UI提示Window.WaitForControlNotExist(30000), "点击确定按钮后，提示框未能关闭");

            Assert.AreEqual(2, double.Parse(UIMap.UIMainWindowWindow.UIItemEdit.Text), "当前缩放级别与预期的不一致");
        }

        [TestMethod]
        public void PanToCenterTest()
        {
            #region Variable Declarations
            WpfEdit uIPanCenterEdit = UIMap.UIMainWindowWindow.UIPanCenterEdit;
            WpfButton uI确定Button = UIMap.UIMainWindowWindow.UI确定Button;
            #endregion

            // 在 “PanCenter” 文本框 中键入“30,50”
            uIPanCenterEdit.Text = "30,50";

            // 单击 “确定” 按钮
            Microsoft.VisualStudio.TestTools.UITesting.Mouse.Click(uI确定Button, new Point(9, 13));

            UIMap.InitUI提示Window();
            //等待地图加载完成，弹出提示框
            Assert.IsTrue(UIMap.UI提示Window.UI地图加载成功Window.UI地图加载成功Text.WaitForControlExist(30000), "修改地图中心点后，地图未能加载");
            //点击确定按钮，关闭提示框
            Microsoft.VisualStudio.TestTools.UITesting.Mouse.Click(UIMap.UI提示Window.UI确定Window.UI确定Button, new Point(1, 1));
            //等待提示框消失
            Assert.IsTrue(UIMap.UI提示Window.WaitForControlNotExist(30000), "点击确定按钮后，提示框未能关闭");

            double xNew = 0;
            double yNew = 0;
            UIMap.GetNowCenter(out xNew, out yNew);

            Assert.AreEqual(30, xNew, "设置中心点后，中心点的X值变化与预期不一致");
            Assert.AreEqual(50, yNew, "设置中心点后，中心点的Y值变化与预期不一致");
        }

        [TestMethod]
        public void PanOutCenterTest()
        {
            #region Variable Declarations
            WpfEdit uIPanCenterEdit = UIMap.UIMainWindowWindow.UIPanCenterEdit;
            WpfButton uI确定Button = UIMap.UIMainWindowWindow.UI确定Button;
            #endregion

            // 在 “PanCenter” 文本框 中键入“30,50”
            uIPanCenterEdit.Text = "300,500";

            // 单击 “确定” 按钮
            Microsoft.VisualStudio.TestTools.UITesting.Mouse.Click(uI确定Button, new Point(9, 13));

            UIMap.InitUI提示Window();
            //等待地图加载完成，弹出提示框
            Assert.IsTrue(UIMap.UI提示Window.UI地图加载成功Window.UI地图加载成功Text.WaitForControlExist(30000), "修改地图中心点后，地图未能加载");
            //点击确定按钮，关闭提示框
            Microsoft.VisualStudio.TestTools.UITesting.Mouse.Click(UIMap.UI提示Window.UI确定Window.UI确定Button, new Point(1, 1));
            //等待提示框消失
            Assert.IsTrue(UIMap.UI提示Window.WaitForControlNotExist(30000), "点击确定按钮后，提示框未能关闭");

            double xNew = 0;
            double yNew = 0;
            UIMap.GetNowCenter(out xNew, out yNew);

            Assert.AreEqual(double.Parse(UIMap.UIMainWindowWindow.UI全幅地图范围Group.UIBoundsRightEdit.Text), xNew, "当X变化超过地图范围时，X应等于最接进的范围的值");
            Assert.AreEqual(double.Parse(UIMap.UIMainWindowWindow.UI全幅地图范围Group.UIBoundsTopEdit.Text), yNew, "当Y变化超过范围时，Y应等于最接近的范围的值");
            
        }

        [TestMethod]
        public void ChangeMapLayerTest()
        {

            UIMap.UIMainWindowWindow.UIUrlEdit.Text = "http://192.168.116.114:8090/iserver/services/map-jingjin/rest";
            UIMap.UIMainWindowWindow.UIMapNameEdit.Text = "京津地区地图";

            Microsoft.VisualStudio.TestTools.UITesting.Mouse.Click(UIMap.UIMainWindowWindow.UI修改服务Button, new Point(1, 1));

            UIMap.InitUI提示Window();
            //等待地图加载完成，弹出提示框
            Assert.IsTrue(UIMap.UI提示Window.UI地图加载成功Window.UI地图加载成功Text.WaitForControlExist(30000), "修改地图服务地址后，地图未能加载");
            //点击确定按钮，关闭提示框
            Microsoft.VisualStudio.TestTools.UITesting.Mouse.Click(UIMap.UI提示Window.UI确定Window.UI确定Button, new Point(1, 1));
            //等待提示框消失
            Assert.IsTrue(UIMap.UI提示Window.WaitForControlNotExist(30000), "点击确定按钮后，提示框未能关闭");

        }

        [TestMethod]
        public void LoadErrorMapServer()
        {

            UIMap.UIMainWindowWindow.UIUrlEdit.Text = "http://192.168.116.114:8090/iserver/services/map-jingjin/rest";
            UIMap.UIMainWindowWindow.UIMapNameEdit.Text = "京津地区地图12345";

            Microsoft.VisualStudio.TestTools.UITesting.Mouse.Click(UIMap.UIMainWindowWindow.UI修改服务Button, new Point(1, 1));

            UIMap.InitUI提示Window();
            //等待地图加载完成，弹出提示框
            Assert.IsTrue(UIMap.UI提示Window.UI地图加载成功Window.UI地图图层异常Text.WaitForControlExist(30000), "修改地图服务地址后，地图正常加载");
            //点击确定按钮，关闭提示框
            Microsoft.VisualStudio.TestTools.UITesting.Mouse.Click(UIMap.UI提示Window.UI确定Window.UI确定Button, new Point(1, 1));
            //等待提示框消失
            Assert.IsTrue(UIMap.UI提示Window.WaitForControlNotExist(30000), "点击确定按钮后，提示框未能关闭");

        }

        #region 附加测试特性

        // 编写测试时，可以使用以下附加特性:

        ////运行每项测试之前使用 TestInitialize 运行代码 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // 若要为此测试生成代码，请从快捷菜单中选择“为编码的 UI 测试生成代码”，然后选择菜单项之一。
        //    // 有关生成的代码的详细信息，请参见 http://go.microsoft.com/fwlink/?LinkId=179463
        //}

        ////运行每项测试之后使用 TestCleanup 运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // 若要为此测试生成代码，请从快捷菜单中选择“为编码的 UI 测试生成代码”，然后选择菜单项之一。
        //    // 有关生成的代码的详细信息，请参见 http://go.microsoft.com/fwlink/?LinkId=179463
        //}

        #endregion

        /// <summary>
        ///获取或设置测试上下文，该上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
