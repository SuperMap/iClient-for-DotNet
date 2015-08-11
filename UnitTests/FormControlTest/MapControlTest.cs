using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using SuperMap.UI.Testing;
using System.Windows.Forms;

namespace FormMapControlTest
{
    /// <summary>
    /// MapControlTest 的摘要说明
    /// </summary>
    [TestClass]
    public class MapControlTest
    {
        public MapControlTest()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        private TestContext testContextInstance;

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

        #region 附加测试特性
        public MainForm _MainForm = null;
        public Thread _thread = null;
        //
        // 编写测试时，可以使用以下附加特性:
        //
        // 在运行类中的第一个测试之前使用 ClassInitialize 运行代码
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在运行每个测试之前，使用 TestInitialize 来运行代码
        [TestInitialize()]
        public void MyTestInitialize()
        {
            _thread = new Thread(new ThreadStart(StartTestForm));
            _thread.SetApartmentState(ApartmentState.STA);
            _thread.Start();
            UIApplication.WaitForWindowOpen();
            UIApplication.DeclareMainWindow("MainForm");
        }

        private void StartTestForm()
        {
            _MainForm = new MainForm();
            _MainForm.TopMost = true;
            _MainForm.ShowDialog();
        }
        //
        // 在每个测试运行完之后，使用 TestCleanup 来运行代码
        [TestCleanup()]
        public void MyTestCleanup()
        {
            if (_MainForm != null)
            {
                _MainForm.Close();
                _MainForm.Dispose();
            }
        }

        #endregion

        [TestMethod]
        public void TestMethod1()
        {
            Thread.Sleep(1000);
            Button graphiclayer = (Button)UIControl.SearchControl(_MainForm, "btnTestGraphicsLayer");
            UIMouse.Click(graphiclayer, MouseButtons.Left);
        }
    }
}
