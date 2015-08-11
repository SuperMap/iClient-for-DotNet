using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperMap.Connector.Utility;
using System.Threading;

namespace SuperMap.Connector.UTests
{
    [TestClass]
    public class TrafficTransferAnalystTest
    {
        string ip = "192.168.116.114";
        //string ip = "192.168.120.116";
        [TestMethod]
        public void GetNamesTest()
        {
            TrafficTransferAnalyst transfer = new TrafficTransferAnalyst("http://" + ip + ":8090/iserver/services/traffictransferanalyst-sample/restjsr/");
            List<string> names = transfer.GetNames();
            Assert.IsNotNull(names, "获取交通网络为空");
            Assert.IsTrue(names.Count > 0, "获取交通网络数量为零");
            Assert.IsTrue(names[0] == "Traffic-Changchun", "第一个交通网络名字与预期不一致");
        }

        [TestMethod]
        public void InitErrorTest()
        {
            bool error = false;
            try
            {
                TrafficTransferAnalyst transfer = new TrafficTransferAnalyst(string.Empty);
            }
            catch (ArgumentNullException ex)
            {
                error = true;
            }
            catch (Exception ex)
            {

            }
            Assert.IsTrue(error, "没有抛出ArgumentNullException异常");
        }

        [TestMethod]
        public void GetNamesErrorTest()
        {
            bool error = false;
            List<string> names = null;
            try
            {
                TrafficTransferAnalyst transfer = new TrafficTransferAnalyst("http://" + ip + ":8090/iserver/services/traffictransferanalyst-sample/error/");
                names = transfer.GetNames();
            }
            catch
            {
                error = true;
            }
            if (names == null)
            {
                error = true;
            }
            Assert.IsTrue(error, "异常Url不应该能查询成功");
        }

        [TestMethod]
        public void GetNamesAsyncTest()
        {
            AutoResetEvent wait = new AutoResetEvent(false);
            List<string> names = null;
            TrafficTransferAnalyst transfer = new TrafficTransferAnalyst("http://" + ip + ":8090/iserver/services/traffictransferanalyst-sample/restjsr/");
            transfer.GetNames((sender, e) =>
                {
                    names = e.Names;
                    wait.Set();
                },
                (sender, e) =>
                {
                    names = null;
                    wait.Set();
                });
            wait.WaitOne();
            Assert.IsNotNull(names, "获取交通网络为空");
            Assert.IsTrue(names.Count > 0, "获取交通网络数量为零");
            Assert.IsTrue(names[0] == "Traffic-Changchun", "第一个交通网络名字与预期不一致");
        }

        [TestMethod]
        public void GetNamesAsyncErrorTest()
        {
            bool error = false;
            AutoResetEvent wait = new AutoResetEvent(false);
            List<string> names = null;
            try
            {
                TrafficTransferAnalyst transfer = new TrafficTransferAnalyst("http://" + ip + ":8090/iserver/services/traffictransferanalyst-sample/error/");
                transfer.GetNames((sender, e) =>
                {
                    names = e.Names;
                    wait.Set();
                },
                    (sender, e) =>
                    {
                        names = null;
                        wait.Set();
                    });
                wait.WaitOne();
            }
            catch
            {
                error = true;
            }
            if (names == null)
            {
                error = true;
            }
            Assert.IsTrue(error, "异常Url不应该能查询成功");
        }

        [TestMethod]
        public void FindStopsByKeyWordNoPositionTest()
        {
            TrafficTransferAnalyst transfer = new TrafficTransferAnalyst("http://" + ip + ":8090/iserver/services/traffictransferanalyst-sample/restjsr/");
            List<TransferStopInfo> list = transfer.FindStopsByKeyWord("Traffic-Changchun", "人民广场", false);
            Assert.IsNotNull(list, "获取人民广场为空");
            Assert.IsTrue(list.Count > 0, "获取人民广场公交站数量为零");
            Assert.IsTrue(list[0].Name == "人民广场");
            Assert.IsTrue(list[0].Id == 164);
            Assert.IsTrue(list[0].Position == null);
        }

        [TestMethod]
        public void FindStopsByKeyWordNoPositionNone1Test()
        {
            bool error = false;
            TrafficTransferAnalyst transfer = new TrafficTransferAnalyst("http://" + ip + ":8090/iserver/services/traffictransferanalyst-sample/restjsr/");
            List<TransferStopInfo> list = null;
            try
            {
                list = transfer.FindStopsByKeyWord(string.Empty, "人民广场", false);
            }
            catch (ArgumentNullException ex)
            {
                error = true;
            }
            Assert.IsTrue(error, "没有抛出ArgumentNullException异常");
        }

        [TestMethod]
        public void FindStopsByKeyWordNoPositionNone2Test()
        {
            bool error = false;
            TrafficTransferAnalyst transfer = new TrafficTransferAnalyst("http://" + ip + ":8090/iserver/services/traffictransferanalyst-sample/restjsr/");
            List<TransferStopInfo> list = null;
            try
            {
                list = transfer.FindStopsByKeyWord("Traffic-Changchun", string.Empty, false);
            }
            catch (ArgumentNullException ex)
            {
                error = true;
            }
            Assert.IsTrue(error, "没有抛出ArgumentNullException异常");
        }

        [TestMethod]
        public void FindStopsByKeyWordNoPositionNone3Test()
        {
            TrafficTransferAnalyst transfer = new TrafficTransferAnalyst("http://" + ip + ":8090/iserver/services/traffictransferanalyst-sample/restjsr/");
            List<TransferStopInfo> list = null;
            list = transfer.FindStopsByKeyWord("Traffic-Changchun", "gsfuisheijrfhie", false);
            Assert.IsNull(list, "查找结果应该为空");
        }

        [TestMethod]
        public void FindStopsByKeyWordNoPositionAsyncTest()
        {
            AutoResetEvent wait = new AutoResetEvent(false);
            List<TransferStopInfo> list = null;
            TrafficTransferAnalyst transfer = new TrafficTransferAnalyst("http://" + ip + ":8090/iserver/services/traffictransferanalyst-sample/restjsr/");
            transfer.FindStopsByKeyWord("Traffic-Changchun", "人民广场", false,
                (sender, e) =>
                {
                    list = e.Stops;
                    wait.Set();
                },
                (sender, e) =>
                {
                    list = null;
                    wait.Set();
                });
            wait.WaitOne();
            Assert.IsNotNull(list, "获取人民广场公交站为空");
            Assert.IsTrue(list.Count > 0, "获取人民广场公交站数量为零");
            Assert.IsTrue(list[0].Id == 164);
            Assert.IsTrue(list[0].Position == null);
        }

        [TestMethod]
        public void FindStopsByKeyWordNoPositionAsyncErrorTest()
        {
            bool error = false;
            AutoResetEvent wait = new AutoResetEvent(false);
            List<TransferStopInfo> list = null;
            TrafficTransferAnalyst transfer = new TrafficTransferAnalyst("http://" + ip + ":8000/iserver/services/traffictransferanalyst-sample/restjsr/");
            transfer.FindStopsByKeyWord("Traffic-Changchun", "人民广场", false,
                (sender, e) =>
                {
                    list = e.Stops;
                    wait.Set();
                },
                (sender, e) =>
                {
                    error = true;
                    list = null;
                    wait.Set();
                });
            wait.WaitOne();
            Assert.IsTrue(error, "访问应该发生异常");
        }

        [TestMethod]
        public void FindStopsByKeyWordHasPositionTest()
        {
            TrafficTransferAnalyst transfer = new TrafficTransferAnalyst("http://" + ip + ":8090/iserver/services/traffictransferanalyst-sample/restjsr/");
            List<TransferStopInfo> list = transfer.FindStopsByKeyWord("Traffic-Changchun", "人民广场", true);
            Assert.IsNotNull(list, "获取人民广场公交站为空");
            Assert.IsTrue(list.Count > 0, "获取人民广场公交站数量为零");
            Assert.IsTrue(list[0].StopId == 164);
            Assert.IsNotNull(list[0].Position);
            Assert.IsTrue(list[0].Position.X == 5308.6140370997082);
            Assert.IsTrue(list[0].Position.Y == -3935.573639156803);
        }

        [TestMethod]
        public void FindStopsByKeyWordHasPositionAsyncTest()
        {
            AutoResetEvent wait = new AutoResetEvent(false);
            List<TransferStopInfo> list = null;
            TrafficTransferAnalyst transfer = new TrafficTransferAnalyst("http://" + ip + ":8090/iserver/services/traffictransferanalyst-sample/restjsr/");
            transfer.FindStopsByKeyWord("Traffic-Changchun", "人民广场", true,
                (sender, e) =>
                {
                    list = e.Stops;
                    wait.Set();
                },
                (sender, e) =>
                {
                    list = null;
                    wait.Set();
                });
            wait.WaitOne();
            Assert.IsNotNull(list, "获取人民广场公交站为空");
            Assert.IsTrue(list.Count > 0, "获取人民广场公交站数量为零");
            Assert.IsTrue(list[0].StopId == 164);
            Assert.IsNotNull(list[0].Position);
            Assert.IsTrue(list[0].Position.X == 5308.6140370997082);
            Assert.IsTrue(list[0].Position.Y == -3935.573639156803);
        }

        [TestMethod]
        public void FindSolutionsById()
        {
            TrafficTransferAnalyst transfer = new TrafficTransferAnalyst("http://" + ip + ":8090/iserver/services/traffictransferanalyst-sample/restjsr/");
            TransferSolutions solutions = transfer.FindTransferSolutions("Traffic-Changchun", 175, 164, new TrafficTransferAnalystParameter());
            Assert.IsNotNull(solutions);
            Assert.IsNotNull(solutions.SolutionItems);
            Assert.IsNotNull(solutions.DefaultGuide);
            Assert.IsNotNull(solutions.DefaultGuide.Items);
            Assert.IsTrue(solutions.DefaultGuide.Items.Length ==2);
            Assert.IsTrue(solutions.DefaultGuide.Items[0].StartStopName=="儿童医院");
            Assert.IsTrue(solutions.DefaultGuide.Items[1].StartStopName == "金都饭店");
            Assert.IsTrue(solutions.SolutionItems.Length == 5);
            Assert.IsNotNull(solutions.SolutionItems[0]);
            Assert.IsTrue(solutions.SolutionItems[1].TransferCount==1);
            Assert.IsNotNull(solutions.SolutionItems[1].LinesItems);
            Assert.IsTrue(solutions.SolutionItems[1].LinesItems.Length == 2);
            Assert.IsTrue(solutions.SolutionItems[1].LinesItems[0].LineItems[0].StartStopName == "百菊大厦");
        }

        [TestMethod]
        public void FindSolutionsByPoint()
        {
            TrafficTransferAnalyst transfer = new TrafficTransferAnalyst("http://" + ip + ":8090/iserver/services/traffictransferanalyst-sample/restjsr/");
            TransferSolutions solutions = transfer.FindTransferSolutions("Traffic-Changchun", new Point2D(4941.4295161, -3566.82310317), new Point2D(5308.6140371, -3935.57363916), new TrafficTransferAnalystParameter());
            Assert.IsNotNull(solutions);
            Assert.IsNotNull(solutions.SolutionItems);
            Assert.IsNotNull(solutions.DefaultGuide);
            Assert.IsNotNull(solutions.DefaultGuide.Items);
            Assert.IsTrue(solutions.DefaultGuide.Items.Length == 3);
            Assert.IsTrue(solutions.DefaultGuide.Items[0].StartStopName == "");
            Assert.IsTrue(solutions.DefaultGuide.Items[1].StartStopName == "金都饭店");
            Assert.IsTrue(solutions.SolutionItems.Length == 5);
            Assert.IsNotNull(solutions.SolutionItems[0]);
            Assert.IsTrue(solutions.SolutionItems[1].TransferCount == 1);
            Assert.IsNotNull(solutions.SolutionItems[1].LinesItems);
            Assert.IsTrue(solutions.SolutionItems[1].LinesItems.Length == 2);
            Assert.IsTrue(solutions.SolutionItems[1].LinesItems[0].LineItems[0].StartStopName == "百菊大厦");
        }

        [TestMethod]
        public void FindPathById()
        {
            TrafficTransferAnalyst transfer = new TrafficTransferAnalyst("http://" + ip + ":8090/iserver/services/traffictransferanalyst-sample/restjsr/");
            TransferSolutions solutions = transfer.FindTransferSolutions("Traffic-Changchun", 175, 164, new TrafficTransferAnalystParameter());
            List<TransferLine> slines = new List<TransferLine>();
            foreach (TransferLines lines in solutions.SolutionItems[1].LinesItems)
            {
                slines.Add(lines.LineItems[0]);
            }
            TransferGuide guide = transfer.FindTransferPath("Traffic-Changchun", 175, 164, slines.ToArray());
            Assert.IsTrue(guide.Count == 3);
            Assert.IsTrue(guide.TransferCount == 1);
            Assert.IsTrue(guide.Items[0].IsWalking);
            Assert.IsTrue(Math.Round(guide.Items[1].Route.Points[0].X,6) == Math.Round(4796.1216816732649,6));
        }

        [TestMethod]
        public void FindPathByPoint()
        {
            TrafficTransferAnalyst transfer = new TrafficTransferAnalyst("http://" + ip + ":8090/iserver/services/traffictransferanalyst-sample/restjsr/");
            TransferSolutions solutions = transfer.FindTransferSolutions("Traffic-Changchun", new Point2D(4941.4295161, -3566.82310317), new Point2D(5308.6140371, -3935.57363916), new TrafficTransferAnalystParameter());
            List<TransferLine> slines = new List<TransferLine>();
            foreach (TransferLines lines in solutions.SolutionItems[1].LinesItems)
            {
                slines.Add(lines.LineItems[0]);
            }
            TransferGuide guide = transfer.FindTransferPath("Traffic-Changchun", 175, 164, slines.ToArray());
            Assert.IsTrue(guide.Count == 3);
            Assert.IsTrue(guide.TransferCount == 1);
            Assert.IsTrue(guide.Items[0].IsWalking);
            Assert.IsTrue(Math.Round(guide.Items[1].Route.Points[0].X,6) == Math.Round(4796.1216816732649,6));
        }

        //[TestMethod]
        //public void FindTransferPathById()
        //{
        //    TrafficTransferAnalyst transfer = new TrafficTransferAnalyst("http://" + ip + ":8090/iserver/services/traffictransferanalyst-sample/restjsr/");
        //    TrafficTransferAnalystParameter param = new TrafficTransferAnalystParameter();
        //    Assert.IsTrue(param.MaxTransferGuideCount == 10);
        //    Assert.IsTrue(param.WalkingRatio == 10);
        //    Assert.IsTrue(param.TransferTactic == TransferTactic.LESS_TIME);
        //    TrafficTransferAnalystResult result = transfer.FindTransferPath("Traffic-BeiJing", 12, 23, param);
        //    Assert.IsTrue(result != null && result.TransferGuides != null, "查询结果为空");
        //    Assert.IsTrue(result.TransferGuides.Length == 4);
        //    Assert.IsTrue(result.TransferGuides[0].Count == 10);
        //    Assert.IsTrue(result.TransferGuides[0].TransferCount == 5);
        //    Assert.IsTrue(result.TransferGuides[0].TotalDistance == 0.31045887478138035);
        //    Assert.IsTrue(result.TransferGuides[0].Items.Length == 10);
        //    Assert.IsTrue(result.TransferGuides[0].Items[2].PassStopCount == 5);
        //    Assert.IsTrue(result.TransferGuides[0].Items[2].StartStopInfo.Name == "湾子");
        //    Assert.IsTrue(result.TransferGuides[0].Items[2].LineInfo.Name == "6(六里桥东-北京游乐园)");
        //    Assert.IsTrue(result.TransferGuides[0].Items[2].LineInfo.Line.Type == GeometryType.LINE);
        //    Assert.IsTrue(result.TransferGuides[0].Items[2].LineInfo.Line.Points.Length == 141);
        //    Assert.IsTrue(result.TransferGuides[0].Items[2].LineInfo.Line.Points[111].X == 116.41588524);
        //    Assert.IsTrue(result.TransferGuides[0].Items[2].LineInfo.Line.Points[111].Y == 39.88825119);
        //}

        //[TestMethod]
        //public void FindTransferPathByIdError()
        //{
        //    TrafficTransferAnalyst transfer = new TrafficTransferAnalyst("http://" + ip + ":8090/iserver/services/traffictransferanalyst-sample/restjsr/");
        //    TrafficTransferAnalystParameter param = new TrafficTransferAnalystParameter();
        //    TrafficTransferAnalystResult result = transfer.FindTransferPath("Traffic-BeiJing", 111111, 222222, param);
        //    Assert.IsNull(result.TransferGuides,"查找结果应该为空");
        //}

        //[TestMethod]
        //public void FindTransferPathByIdSetParam()
        //{
        //    TrafficTransferAnalyst transfer = new TrafficTransferAnalyst("http://" + ip + ":8090/iserver/services/traffictransferanalyst-sample/restjsr/");
        //    TrafficTransferAnalystParameter param = new TrafficTransferAnalystParameter();
        //    param.MaxTransferGuideCount = 2;
        //    TrafficTransferAnalystResult result = transfer.FindTransferPath("Traffic-BeiJing", 12, 23, param);

        //    Assert.IsTrue(result.TransferGuides.Length == 2,"查询结果应该只有两条");
        //}

        //[TestMethod]
        //public void FindTransferPathByIdAsync()
        //{
        //    AutoResetEvent wait = new AutoResetEvent(false);
        //    TrafficTransferAnalyst transfer = new TrafficTransferAnalyst("http://" + ip + ":8090/iserver/services/traffictransferanalyst-sample/restjsr/");
        //    TrafficTransferAnalystParameter param = new TrafficTransferAnalystParameter();
        //    Assert.IsTrue(param.MaxTransferGuideCount == 10);
        //    Assert.IsTrue(param.WalkingRatio == 10);
        //    Assert.IsTrue(param.TransferTactic == TransferTactic.LESS_TIME);
        //    TrafficTransferAnalystResult result = null;
        //    transfer.FindTransferPath("Traffic-BeiJing", 12, 23, param,
        //        (sender, e) =>
        //        {
        //            result = e.Result;
        //            wait.Set();
        //        },
        //        (sender, e) =>
        //        {
        //            result = null;
        //            wait.Set();
        //        });
        //    wait.WaitOne();
        //    Assert.IsTrue(result != null && result.TransferGuides != null, "查询结果为空");
        //    Assert.IsTrue(result.TransferGuides.Length == 4);
        //    Assert.IsTrue(result.TransferGuides[0].Count == 10);
        //    Assert.IsTrue(result.TransferGuides[0].TransferCount == 5);
        //    Assert.IsTrue(result.TransferGuides[0].TotalDistance == 0.31045887478138035);
        //    Assert.IsTrue(result.TransferGuides[0].Items.Length == 10);
        //    Assert.IsTrue(result.TransferGuides[0].Items[2].PassStopCount == 5);
        //    Assert.IsTrue(result.TransferGuides[0].Items[2].StartStopInfo.Name == "湾子");
        //    Assert.IsTrue(result.TransferGuides[0].Items[2].LineInfo.Name == "6(六里桥东-北京游乐园)");
        //    Assert.IsTrue(result.TransferGuides[0].Items[2].LineInfo.Line.Type == GeometryType.LINE);
        //    Assert.IsTrue(result.TransferGuides[0].Items[2].LineInfo.Line.Points.Length == 141);
        //    Assert.IsTrue(result.TransferGuides[0].Items[2].LineInfo.Line.Points[111].X == 116.41588524);
        //    Assert.IsTrue(result.TransferGuides[0].Items[2].LineInfo.Line.Points[111].Y == 39.88825119);
        //}

        //[TestMethod]
        //public void FindTransferPathByPoint()
        //{
        //    TrafficTransferAnalyst transfer = new TrafficTransferAnalyst("http://" + ip + ":8090/iserver/services/traffictransferanalyst-sample/restjsr/");
        //    TrafficTransferAnalystParameter param = new TrafficTransferAnalystParameter();
        //    Assert.IsTrue(param.MaxTransferGuideCount == 10);
        //    Assert.IsTrue(param.WalkingRatio == 10);
        //    Assert.IsTrue(param.TransferTactic == TransferTactic.LESS_TIME);
        //    TrafficTransferAnalystResult result = transfer.FindTransferPath("Traffic-BeiJing", new Point2D(116.330733381105, 39.9272621453375), new Point2D(116.327900901105, 39.9215383253375), param);
        //    Assert.IsTrue(result != null && result.TransferGuides != null, "查询结果为空");
        //    Assert.IsTrue(result.TransferGuides.Length == 4);
        //    Assert.IsTrue(result.TransferGuides[0].Count == 9);
        //    Assert.IsTrue(result.TransferGuides[0].TransferCount == 5);
        //    Assert.IsTrue(result.TransferGuides[0].TotalDistance == 0.2148820242175995);
        //    Assert.IsTrue(result.TransferGuides[0].Items.Length == 9);
        //    Assert.IsTrue(result.TransferGuides[0].Items[2].PassStopCount == 8);
        //    Assert.IsTrue(result.TransferGuides[0].Items[2].StartStopInfo.Name == "东侧路");
        //    Assert.IsTrue(result.TransferGuides[0].Items[2].LineInfo.Name == "25(城外诚-北京站东)");
        //    Assert.IsTrue(result.TransferGuides[0].Items[2].LineInfo.Line.Type == GeometryType.LINE);
        //    Assert.IsTrue(result.TransferGuides[0].Items[2].LineInfo.Line.Points.Length == 220);
        //    Assert.IsTrue(result.TransferGuides[0].Items[2].LineInfo.Line.Points[111].X == 116.43212087999999);
        //    Assert.IsTrue(result.TransferGuides[0].Items[2].LineInfo.Line.Points[111].Y == 39.85891839);
        //}

        //[TestMethod]
        //public void FindTransferPathByPointAsync()
        //{
        //    AutoResetEvent wait = new AutoResetEvent(false);
        //    TrafficTransferAnalyst transfer = new TrafficTransferAnalyst("http://" + ip + ":8090/iserver/services/traffictransferanalyst-sample/restjsr/");
        //    TrafficTransferAnalystParameter param = new TrafficTransferAnalystParameter();
        //    Assert.IsTrue(param.MaxTransferGuideCount == 10);
        //    Assert.IsTrue(param.WalkingRatio == 10);
        //    Assert.IsTrue(param.TransferTactic == TransferTactic.LESS_TIME);
        //    TrafficTransferAnalystResult result = null;
        //    transfer.FindTransferPath("Traffic-BeiJing", new Point2D(116.330733381105, 39.9272621453375), new Point2D(116.327900901105, 39.9215383253375), param,
        //         (sender, e) =>
        //         {
        //             result = e.Result;
        //             wait.Set();
        //         },
        //        (sender, e) =>
        //        {
        //            result = null;
        //            wait.Set();
        //        });
        //    wait.WaitOne();
        //    Assert.IsTrue(result != null && result.TransferGuides != null, "查询结果为空");
        //    Assert.IsTrue(result.TransferGuides.Length == 4);
        //    Assert.IsTrue(result.TransferGuides[0].Count == 9);
        //    Assert.IsTrue(result.TransferGuides[0].TransferCount == 5);
        //    Assert.IsTrue(result.TransferGuides[0].TotalDistance == 0.2148820242175995);
        //    Assert.IsTrue(result.TransferGuides[0].Items.Length == 9);
        //    Assert.IsTrue(result.TransferGuides[0].Items[2].PassStopCount == 8);
        //    Assert.IsTrue(result.TransferGuides[0].Items[2].StartStopInfo.Name == "东侧路");
        //    Assert.IsTrue(result.TransferGuides[0].Items[2].LineInfo.Name == "25(城外诚-北京站东)");
        //    Assert.IsTrue(result.TransferGuides[0].Items[2].LineInfo.Line.Type == GeometryType.LINE);
        //    Assert.IsTrue(result.TransferGuides[0].Items[2].LineInfo.Line.Points.Length == 220);
        //    Assert.IsTrue(result.TransferGuides[0].Items[2].LineInfo.Line.Points[111].X == 116.43212087999999);
        //    Assert.IsTrue(result.TransferGuides[0].Items[2].LineInfo.Line.Points[111].Y == 39.85891839);
        //}
    }
}
