using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperMap.Connector.Utility;

namespace SuperMap.Connector.UTests
{
    /// <summary>
    /// NetworkAnalystTest 的摘要说明
    /// </summary>
    [TestClass]
    public class NetworkAnalystTest
    {
        string ip = "192.168.116.114";
        public NetworkAnalystTest()
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
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // 在每个测试运行完之后，使用 TestCleanup 来运行代码
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        #region FindPath
        [TestMethod]
        public void FindPathTest()
        {
            int[] nodeIDs = new int[] { 2, 3 };
            string networkDatasetName = "RoadNet@Changchun";
            TransportationAnalystParameter parameter = new TransportationAnalystParameter();
            parameter.ResultSetting = new TransportationAnalystResultSetting();
            parameter.ResultSetting.ReturnEdgeIDs = true;
            parameter.ResultSetting.ReturnNodeIDs = true;
            parameter.ResultSetting.ReturnPathGuides = true;
            parameter.ResultSetting.ReturnRoutes = true;
            parameter.ResultSetting.ReturnEdgeFeatures = true;
            parameter.ResultSetting.ReturnEdgeGeometry = true;
            parameter.ResultSetting.ReturnNodeFeatures = true;
            parameter.ResultSetting.ReturnNodeGeometry = true;
            parameter.WeightFieldName = "length";
            parameter.TurnWeightField = "TurnCost";

            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
            List<Path> paths = networkAnalyst.FindPath(networkDatasetName, nodeIDs, true, parameter);
            Assert.IsNotNull(paths);
            Assert.IsNotNull(paths[0]);
            Assert.IsNotNull(paths[0].EdgeFeatures[0]);
            Assert.IsNotNull(paths[0].EdgeIDs[0]);
            Assert.IsNotNull(paths[0].NodeFeatures[0]);
            Assert.IsNotNull(paths[0].NodeIDs[0]);
            Assert.IsNotNull(paths[0].PathGuideItems[0]);
            Assert.IsNotNull(paths[0].Route);
            Assert.IsNotNull(paths[0].Route.Length);
            Assert.IsNotNull(paths[0].Route.Points[0]);
            Assert.AreEqual(paths[0].Route.Points[1].Measure, 42.273803871316005);
            Assert.IsNotNull(paths[0].Route.Type);
            Assert.AreEqual(paths[0].Route.MaxM, 53);
            Assert.AreEqual(paths[0].Route.MinM, 0.0);
            Assert.AreEqual(paths[0].Route.Type, GeometryType.LINEM);
        }

        [TestMethod]
        public void FindPathTest_ParameterNUll()
        {
            int[] nodeIDs = new int[] { 2, 3 };
            string networkDatasetName = "RoadNet@Changchun";

            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
            List<Path> paths = networkAnalyst.FindPath(networkDatasetName, nodeIDs, true, null);
            Assert.IsNotNull(paths);
            Assert.IsNotNull(paths[0]);
            Assert.IsNotNull(paths[0].EdgeIDs[0]);
            Assert.IsNotNull(paths[0].NodeIDs[0]);
            Assert.IsNotNull(paths[0].Route);
            Assert.IsNotNull(paths[0].Route.Length);
            Assert.IsNotNull(paths[0].Route.Points[0]);
            Assert.AreEqual(paths[0].Route.Points[1].Measure, 42.273803871316005);
            Assert.IsNotNull(paths[0].Route.Type);
            Assert.AreEqual(paths[0].Route.MaxM, 53);
            Assert.AreEqual(paths[0].Route.MinM, 0.0);
            Assert.AreEqual(paths[0].StopWeights[0], 53);
            Assert.AreEqual(paths[0].Weight, 53);
        }

        [TestMethod]
        public void FindPathTest_RouteType()
        {
            int[] nodeIDs = new int[] { 2, 3 };
            string networkDatasetName = "RoadNet@Changchun";

            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
            List<Path> paths = networkAnalyst.FindPath(networkDatasetName, nodeIDs, true, null);
            Assert.IsNotNull(paths);
            Assert.IsNotNull(paths[0]);
            Assert.AreEqual(paths[0].Route.Type, GeometryType.LINEM);
        }

        [TestMethod]
        public void FindPathTest_Parameter()
        {
            int[] nodeIDs = new int[] { 2, 3 };
            string networkDatasetName = "RoadNet@Changchun";
            TransportationAnalystParameter parameter = new TransportationAnalystParameter();
            parameter.ResultSetting = new TransportationAnalystResultSetting();
            parameter.WeightFieldName = "length";
            parameter.TurnWeightField = "TurnCost";

            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
            List<Path> paths = networkAnalyst.FindPath(networkDatasetName, nodeIDs, true, parameter);
            Assert.IsNotNull(paths);
            Assert.IsNotNull(paths[0]);
            Assert.IsNull(paths[0].EdgeFeatures);
            Assert.AreEqual(paths[0].EdgeIDs.Count(), 1);
            Assert.IsNull(paths[0].NodeFeatures);
            Assert.AreEqual(paths[0].NodeIDs.Count(), 2);
            Assert.IsNull(paths[0].PathGuideItems);
            Assert.IsNotNull(paths[0].Route);
            Assert.AreEqual(paths[0].Weight, 53);
            Assert.AreEqual(paths[0].StopWeights[0], 53);

        }

        [TestMethod]
        public void FindPathTest_NodeIDs()
        {
            int[] nodeIDs = new int[] { };
            string networkDatasetName = "RoadNet@Changchun";
            TransportationAnalystParameter parameter = new TransportationAnalystParameter();
            parameter.ResultSetting = new TransportationAnalystResultSetting();
            parameter.WeightFieldName = "length";
            parameter.TurnWeightField = "TurnCost";

            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
            try
            {
                List<Path> paths = networkAnalyst.FindPath(networkDatasetName, nodeIDs, true, parameter);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual(e.Message, "参数不能为空。\r\n参数名: nodeIDs");
            }
        }

        [TestMethod]
        public void FindPathTest_networkDatasetName()
        {
            int[] nodeIDs = new int[] { 2, 3 };
            //string networkDatasetName = "RoadNet@Changchun";
            TransportationAnalystParameter parameter = new TransportationAnalystParameter();
            parameter.ResultSetting = new TransportationAnalystResultSetting();
            parameter.WeightFieldName = "length";
            parameter.TurnWeightField = "TurnCost";

            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
            try
            {
                List<Path> paths = networkAnalyst.FindPath(string.Empty, nodeIDs, true, parameter);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual(e.Message, "参数不能为空。\r\n参数名: networkDatasetName");
            }
        }

        [TestMethod]
        public void FindPathTest_Points()
        {
            int[] nodeIDs = new int[] { 2, 3 };
            string networkDatasetName = "RoadNet@Changchun";
            TransportationAnalystParameter parameter = new TransportationAnalystParameter();
            parameter.ResultSetting = new TransportationAnalystResultSetting();
            parameter.ResultSetting.ReturnEdgeIDs = true;
            parameter.ResultSetting.ReturnNodeIDs = true;
            parameter.ResultSetting.ReturnPathGuides = true;
            parameter.ResultSetting.ReturnRoutes = true;
            parameter.ResultSetting.ReturnEdgeFeatures = true;
            parameter.ResultSetting.ReturnEdgeGeometry = true;
            parameter.ResultSetting.ReturnNodeFeatures = true;
            parameter.ResultSetting.ReturnNodeGeometry = true;
            parameter.WeightFieldName = "length";
            parameter.TurnWeightField = "TurnCost";

            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
            List<Path> paths = networkAnalyst.FindPath(networkDatasetName, nodeIDs, true, parameter);
            Assert.IsNotNull(paths);
            Assert.IsNotNull(paths[0]);
            Assert.IsNotNull(paths[0].EdgeFeatures[0]);
            Assert.IsNotNull(paths[0].EdgeIDs[0]);
            Assert.IsNotNull(paths[0].NodeFeatures[0]);
            Assert.IsNotNull(paths[0].NodeIDs[0]);
            Assert.IsNotNull(paths[0].PathGuideItems[0]);
            Assert.IsNotNull(paths[0].Route);
            Assert.IsNotNull(paths[0].Route.Length);
            Assert.IsNotNull(paths[0].Route.Points[0]);
            Assert.AreEqual(paths[0].Route.Points[1].Measure, 42.273803871316005);
            Assert.IsNotNull(paths[0].Route.Type);
            Assert.AreEqual(paths[0].Route.MaxM, 53);
            Assert.AreEqual(paths[0].Route.MinM, 0.0);
            Assert.AreEqual(paths[0].Route.Type, GeometryType.LINEM);
        }

        [TestMethod]
        public void FindPathTest_Points_ParameterNUll()
        {
            Point2D[] points = new Point2D[2];
            points[0] = new Point2D(119.6100397551, -122.6278394459);
            points[1] = new Point2D(171.9035599945, -113.2491141857);
            string networkDatasetName = "RoadNet@Changchun";

            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
            List<Path> paths = networkAnalyst.FindPath(networkDatasetName, points, true, null);
            Assert.IsNotNull(paths);
            Assert.IsNotNull(paths[0]);
            Assert.IsNotNull(paths[0].EdgeIDs[0]);
            Assert.IsNotNull(paths[0].NodeIDs[0]);
            Assert.IsNotNull(paths[0].Route);
            Assert.IsNotNull(paths[0].Route.Length);
            Assert.IsNotNull(paths[0].Route.Points[0]);
            Assert.AreEqual(paths[0].Route.Points[1].Measure, 42.273803871316005);
            Assert.IsNotNull(paths[0].Route.Type);
            Assert.AreEqual(paths[0].Route.MaxM, 53);
            Assert.AreEqual(paths[0].Route.MinM, 0.0);
            Assert.AreEqual(paths[0].StopWeights[0], 53);
            Assert.AreEqual(paths[0].Weight, 53);
        }

        [TestMethod]
        public void FindPathTest_Points_RouteType()
        {
            Point2D[] points = new Point2D[2];
            points[0] = new Point2D(119.6100397551, -122.6278394459);
            points[1] = new Point2D(171.9035599945, -113.2491141857);
            string networkDatasetName = "RoadNet@Changchun";

            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
            List<Path> paths = networkAnalyst.FindPath(networkDatasetName, points, true, null);
            Assert.IsNotNull(paths);
            Assert.IsNotNull(paths[0]);
            Assert.AreEqual(paths[0].Route.Type, GeometryType.LINEM);
        }

        [TestMethod]
        public void FindPathTest_Points_Parameter()
        {
            Point2D[] points = new Point2D[2];
            points[0] = new Point2D(119.6100397551, -122.6278394459);
            points[1] = new Point2D(171.9035599945, -113.2491141857);
            string networkDatasetName = "RoadNet@Changchun";
            TransportationAnalystParameter parameter = new TransportationAnalystParameter();
            parameter.ResultSetting = new TransportationAnalystResultSetting();
            parameter.WeightFieldName = "length";
            parameter.TurnWeightField = "TurnCost";

            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
            List<Path> paths = networkAnalyst.FindPath(networkDatasetName, points, true, parameter);
            Assert.IsNotNull(paths);
            Assert.IsNotNull(paths[0]);
            Assert.IsNull(paths[0].EdgeFeatures);
            Assert.AreEqual(paths[0].EdgeIDs.Count(), 1);
            Assert.IsNull(paths[0].NodeFeatures);
            Assert.AreEqual(paths[0].NodeIDs.Count(), 2);
            Assert.IsNull(paths[0].PathGuideItems);
            Assert.IsNotNull(paths[0].Route);
            Assert.AreEqual(paths[0].Weight, 53);
            Assert.AreEqual(paths[0].StopWeights[0], 53);

        }

        [TestMethod]
        public void FindPathTest_PointssNull()
        {
            Point2D[] points = new Point2D[2];
            string networkDatasetName = "RoadNet@Changchun";
            TransportationAnalystParameter parameter = new TransportationAnalystParameter();
            parameter.ResultSetting = new TransportationAnalystResultSetting();
            parameter.WeightFieldName = "length";
            parameter.TurnWeightField = "TurnCost";

            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
            try
            {
                List<Path> paths = networkAnalyst.FindPath(networkDatasetName, points, true, parameter);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual(e.Message, "参数不能为空。\r\n参数名: point");
            }
        }

        [TestMethod]
        public void FindPathTest_PointssNull1()
        {
            Point2D[] points = new Point2D[1];
            string networkDatasetName = "RoadNet@Changchun";
            TransportationAnalystParameter parameter = new TransportationAnalystParameter();
            parameter.ResultSetting = new TransportationAnalystResultSetting();
            parameter.WeightFieldName = "length";
            parameter.TurnWeightField = "TurnCost";

            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
            try
            {
                List<Path> paths = networkAnalyst.FindPath(networkDatasetName, points, true, parameter);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual(e.Message, "参数 points 不合法，必须至少包含两个二维点。");
            }
        }

        [TestMethod]
        public void FindPathTest_Points_networkDatasetNameNull()
        {
            Point2D[] points = new Point2D[2];
            points[0] = new Point2D(119.6100397551, -122.6278394459);
            points[1] = new Point2D(171.9035599945, -113.2491141857);
            //string networkDatasetName = "RoadNet@Changchun";
            TransportationAnalystParameter parameter = new TransportationAnalystParameter();
            parameter.ResultSetting = new TransportationAnalystResultSetting();
            parameter.WeightFieldName = "length";
            parameter.TurnWeightField = "TurnCost";

            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
            try
            {
                List<Path> paths = networkAnalyst.FindPath(string.Empty, points, true, parameter);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual(e.Message, "参数不能为空。\r\n参数名: networkDatasetName");
            }
        }

        [TestMethod]
        public void Json_RoutePoints()
        {
            Route route = new Route();

            PointWithMeasure[] points = new PointWithMeasure[2];
            PointWithMeasure p1 = new PointWithMeasure();
            p1.X = 1;
            p1.Y = 2;
            p1.Measure = 2.2;
            PointWithMeasure p2 = new PointWithMeasure();
            p2.X = 1;
            p2.Y = 2;
            p2.Measure = 2.3;
            points[0] = p1;
            points[1] = p2;
            route.Points = points;
            route.Id = 1;
            route.Length = 3;
            route.Line = new Geometry();
            route.MaxM = 1.3;
            route.MinM = 0.3;
            route.Parts = new int[2] { 1, 3 };
            route.Region = new Geometry();
            route.Style = new Style();
            string strroute = Newtonsoft.Json.JsonConvert.SerializeObject(route);
            Route r1 = Newtonsoft.Json.JsonConvert.DeserializeObject<Route>(strroute);
            Assert.AreEqual(r1.Points[0].Measure, 2.2);
            Assert.AreEqual(r1.Points[1].Measure, 2.3);
        }
        #endregion

        #region ClosestFacilityPath
        [TestMethod]
        public void Json_ClosestFacilityPath()
        {
            ClosestFacilityPath<int> cPath = new ClosestFacilityPath<int>();
            cPath.FacilityIndex = 1;
            cPath.Facility = 2;
            cPath.Weight = 30;
            string strcPath = Newtonsoft.Json.JsonConvert.SerializeObject(cPath);

            ClosestFacilityPath<int> cPathJson = Newtonsoft.Json.JsonConvert.DeserializeObject<ClosestFacilityPath<int>>(strcPath);

            Assert.AreEqual(cPathJson.Weight, 30);
            Assert.AreEqual(cPathJson.Facility, (Int64)2);
            Assert.AreEqual(cPathJson.FacilityIndex, 1);
        }

        [TestMethod]
        public void Json_ClosestFacilityPathPoint()
        {
            ClosestFacilityPath<Point2D> cPath = new ClosestFacilityPath<Point2D>();
            cPath.FacilityIndex = 1;
            cPath.Facility = new Point2D(2.2, 3.5);
            cPath.Weight = 30;
            string strcPath = Newtonsoft.Json.JsonConvert.SerializeObject(cPath);
            ClosestFacilityPath<Point2D> cPathJson = Newtonsoft.Json.JsonConvert.DeserializeObject<ClosestFacilityPath<Point2D>>(strcPath);
            Assert.AreEqual(cPathJson.Weight, 30);
            Assert.AreEqual(((Point2D)cPathJson.Facility).X, 2.2);
            Assert.AreEqual(((Point2D)cPathJson.Facility).Y, 3.5);
            Assert.AreEqual(cPathJson.FacilityIndex, 1);
        }

        /// <summary>
        /// FindClosestFacility 参数为ID
        /// </summary>
        [TestMethod]
        public void FindClosestFacilityTest_ID()
        {
            string networkDatasetName = "RoadNet@Changchun";
            int[] facilityIDs = new int[] { 1, 6, 52 };
            int eventID = 2;
            int expectFacilityCount = 2;
            bool fromEvent = false;
            double maxWeight = 0;
            TransportationAnalystParameter parameter = new TransportationAnalystParameter();
            parameter.WeightFieldName = "length";
            parameter.TurnWeightField = "TurnCost";
            parameter.ResultSetting = new TransportationAnalystResultSetting();
            parameter.ResultSetting.ReturnEdgeFeatures = true;
            parameter.ResultSetting.ReturnEdgeGeometry = true;
            parameter.ResultSetting.ReturnEdgeIDs = true;
            parameter.ResultSetting.ReturnNodeFeatures = true;
            parameter.ResultSetting.ReturnNodeGeometry = true;
            parameter.ResultSetting.ReturnNodeIDs = true;
            parameter.ResultSetting.ReturnPathGuides = true;
            parameter.ResultSetting.ReturnRoutes = true;

            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
            List<ClosestFacilityPath<int>> pathResult = networkAnalyst.FindClosestFacility(networkDatasetName, facilityIDs,
                eventID, expectFacilityCount, fromEvent, maxWeight, parameter);
            Assert.IsNotNull(pathResult);
            Assert.AreEqual(pathResult.Count, 2);
            Assert.AreEqual(pathResult[0].FacilityIndex, 0);
            Assert.AreEqual(pathResult[0].Facility, 1);
            Assert.AreEqual(pathResult[1].FacilityIndex, 1);
            Assert.AreEqual(pathResult[1].Facility, 6);
            Assert.AreEqual(pathResult[0].Weight, 125);
            Assert.AreEqual(pathResult[1].Weight, 484);
            Assert.IsNotNull(pathResult[0].StopWeights);
            Assert.IsNotNull(pathResult[0].Route);
            Assert.IsNotNull(pathResult[0].PathGuideItems);
            Assert.IsNotNull(pathResult[0].NodeIDs);
            Assert.IsNotNull(pathResult[0].NodeFeatures);
            Assert.IsNotNull(pathResult[0].EdgeFeatures);
            Assert.IsNotNull(pathResult[0].EdgeIDs);
        }

        /// <summary>
        /// FindClosestFacility 参数为ID
        /// networkDatasetName 为空
        /// </summary>
        [TestMethod]
        public void FindClosestFacilityTest_ID_DatasetNULL()
        {
            //string networkDatasetName = "RoadNet@Changchun";
            int[] facilityIDs = new int[] { 1, 6, 52 };
            int eventID = 2;
            int expectFacilityCount = 2;
            bool fromEvent = false;
            double maxWeight = 0;
            TransportationAnalystParameter parameter = new TransportationAnalystParameter();
            parameter.WeightFieldName = "length";
            parameter.TurnWeightField = "TurnCost";

            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
            try
            {
                List<ClosestFacilityPath<int>> pathResult = networkAnalyst.FindClosestFacility(string.Empty, facilityIDs,
                    eventID, expectFacilityCount, fromEvent, maxWeight, parameter);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual(e.Message, "参数不能为空。\r\n参数名: networkDatasetName");
            }
        }

        /// <summary>
        /// FindClosestFacility 参数为ID
        /// 未设置TransportationAnalystParameter参数
        /// </summary>
        [TestMethod]
        public void FindClosestFacilityTest_ID_TAParameterNULL()
        {
            string networkDatasetName = "RoadNet@Changchun";
            int[] facilityIDs = new int[] { 1, 6, 52 };
            int eventID = 2;
            int expectFacilityCount = 2;
            bool fromEvent = false;
            double maxWeight = 0;

            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
            List<ClosestFacilityPath<int>> pathResult = networkAnalyst.FindClosestFacility(networkDatasetName, facilityIDs,
                eventID, expectFacilityCount, fromEvent, maxWeight, null);
            Assert.IsNotNull(pathResult);
            Assert.AreEqual(pathResult.Count, 2);
            Assert.AreEqual(pathResult[0].FacilityIndex, 0);
            Assert.AreEqual(pathResult[0].Facility, 1);
            Assert.AreEqual(pathResult[1].FacilityIndex, 1);
            Assert.AreEqual(pathResult[1].Facility, 6);
            Assert.AreEqual(pathResult[0].Weight, 125);
            Assert.AreEqual(pathResult[1].Weight, 454);
            Assert.IsNotNull(pathResult[0].Route);
            Assert.IsNull(pathResult[0].PathGuideItems);
            Assert.IsNotNull(pathResult[0].NodeIDs);
            Assert.IsNull(pathResult[0].NodeFeatures);
            Assert.IsNull(pathResult[0].EdgeFeatures);
            Assert.IsNotNull(pathResult[0].EdgeIDs);
        }

        /// <summary>
        /// FindClosestFacility 参数为ID
        /// ReturnNodeFeatures为false,ReturnNodeGeometry 为true时，设置无效。
        /// </summary>
        [TestMethod]
        public void FindClosestFacilityTest_ID_Geometry()
        {
            string networkDatasetName = "RoadNet@Changchun";
            int[] facilityIDs = new int[] { 1, 6, 52 };
            int eventID = 2;
            int expectFacilityCount = 2;
            bool fromEvent = false;
            double maxWeight = 0;
            TransportationAnalystParameter parameter = new TransportationAnalystParameter();
            parameter.WeightFieldName = "length";
            parameter.TurnWeightField = "TurnCost";
            parameter.ResultSetting = new TransportationAnalystResultSetting();
            parameter.ResultSetting.ReturnEdgeFeatures = false;
            parameter.ResultSetting.ReturnEdgeGeometry = true;
            parameter.ResultSetting.ReturnEdgeIDs = true;
            parameter.ResultSetting.ReturnNodeFeatures = false;
            parameter.ResultSetting.ReturnNodeGeometry = true;
            parameter.ResultSetting.ReturnNodeIDs = true;
            parameter.ResultSetting.ReturnPathGuides = true;
            parameter.ResultSetting.ReturnRoutes = true;

            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
            List<ClosestFacilityPath<int>> pathResult = networkAnalyst.FindClosestFacility(networkDatasetName, facilityIDs,
                eventID, expectFacilityCount, fromEvent, maxWeight, parameter);
            Assert.IsNotNull(pathResult);
            Assert.AreEqual(pathResult.Count, 2);
            Assert.AreEqual(pathResult[0].FacilityIndex, 0);
            Assert.AreEqual(pathResult[0].Facility, 1);
            Assert.AreEqual(pathResult[1].FacilityIndex, 1);
            Assert.AreEqual(pathResult[1].Facility, 6);
            Assert.AreEqual(pathResult[0].Weight, 125);
            Assert.AreEqual(pathResult[1].Weight, 484);
            Assert.IsNotNull(pathResult[0].StopWeights);
            Assert.IsNotNull(pathResult[0].Route);
            Assert.IsNotNull(pathResult[0].PathGuideItems);
            Assert.IsNotNull(pathResult[0].NodeIDs);
            Assert.IsNotNull(pathResult[0].EdgeIDs);
        }


        /// <summary>
        /// FindClosestFacility 参数为坐标点
        /// </summary>
        [TestMethod]
        public void FindClosestFacilityTest_Point()
        {
            string networkDatasetName = "RoadNet@Changchun";
            Point2D[] facilities = new Point2D[3];
            facilities[0] = new Point2D(70.1515638201, -54.7406354454);
            facilities[1] = new Point2D(550.6770595320, -56.1050211383);
            facilities[2] = new Point2D(445.6471889264, -229.2074549041);
            Point2D eventPoint = new Point2D(119.6100397551, -122.6278394459);
            int expectFacilityCount = 2;
            bool fromEvent = false;
            double maxWeight = 0;
            TransportationAnalystParameter parameter = new TransportationAnalystParameter();
            parameter.WeightFieldName = "length";
            parameter.TurnWeightField = "TurnCost";
            parameter.ResultSetting = new TransportationAnalystResultSetting();
            parameter.ResultSetting.ReturnEdgeFeatures = true;
            parameter.ResultSetting.ReturnEdgeGeometry = true;
            parameter.ResultSetting.ReturnEdgeIDs = true;
            parameter.ResultSetting.ReturnNodeFeatures = true;
            parameter.ResultSetting.ReturnNodeGeometry = true;
            parameter.ResultSetting.ReturnNodeIDs = true;
            parameter.ResultSetting.ReturnPathGuides = true;
            parameter.ResultSetting.ReturnRoutes = true;

            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
            List<ClosestFacilityPath<Point2D>> pathResult = networkAnalyst.FindClosestFacility(networkDatasetName, facilities,
                eventPoint, expectFacilityCount, fromEvent, maxWeight, parameter);
            Assert.IsNotNull(pathResult);
            Assert.AreEqual(pathResult.Count, 2);
            Assert.AreEqual(pathResult[0].FacilityIndex, 0);
            Assert.AreEqual(pathResult[0].Facility.X, 70.1515638201);
            Assert.AreEqual(pathResult[0].Facility.Y, -54.7406354454);
            Assert.AreEqual(pathResult[1].FacilityIndex, 1);
            Assert.AreEqual(pathResult[1].Facility.X, 550.677059532);
            Assert.AreEqual(pathResult[1].Facility.Y, -56.1050211383);
            Assert.AreEqual(pathResult[0].Weight, 125);
            Assert.AreEqual(pathResult[1].Weight, 484);
            Assert.IsNotNull(pathResult[0].StopWeights);
            Assert.IsNotNull(pathResult[0].Route);
            Assert.IsNotNull(pathResult[0].PathGuideItems);
            Assert.IsNotNull(pathResult[0].NodeIDs);
            Assert.IsNotNull(pathResult[0].NodeFeatures);
            Assert.IsNotNull(pathResult[0].EdgeFeatures);
            Assert.IsNotNull(pathResult[0].EdgeIDs);
        }

        /// <summary>
        /// FindClosestFacility 参数为坐标点
        /// networkDatasetName 为空
        /// </summary>
        [TestMethod]
        public void FindClosestFacilityTest_Point_DatasetNULL()
        {
            //string networkDatasetName = "RoadNet@Changchun";
            Point2D[] facilities = new Point2D[3];
            facilities[0] = new Point2D(70.1515638201, -54.7406354454);
            facilities[1] = new Point2D(550.6770595320, -56.1050211383);
            facilities[2] = new Point2D(445.6471889264, -229.2074549041);
            Point2D eventPoint = new Point2D(119.6100397551, -122.6278394459);
            int expectFacilityCount = 2;
            bool fromEvent = false;
            double maxWeight = 0;
            TransportationAnalystParameter parameter = new TransportationAnalystParameter();
            parameter.WeightFieldName = "length";
            parameter.TurnWeightField = "TurnCost";

            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
            try
            {
                List<ClosestFacilityPath<Point2D>> pathResult = networkAnalyst.FindClosestFacility(string.Empty, facilities,
                    eventPoint, expectFacilityCount, fromEvent, maxWeight, parameter);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual(e.Message, "参数不能为空。\r\n参数名: networkDatasetName");
            }
        }

        /// <summary>
        /// FindClosestFacility 参数为坐标点
        /// 未设置TransportationAnalystParameter参数
        /// </summary>
        [TestMethod]
        public void FindClosestFacilityTest_Point_TAParameterNULL()
        {
            string networkDatasetName = "RoadNet@Changchun";
            Point2D[] facilities = new Point2D[3];
            facilities[0] = new Point2D(70.1515638201, -54.7406354454);
            facilities[1] = new Point2D(550.6770595320, -56.1050211383);
            facilities[2] = new Point2D(445.6471889264, -229.2074549041);
            Point2D eventPoint = new Point2D(119.6100397551, -122.6278394459);
            int expectFacilityCount = 2;
            bool fromEvent = false;
            double maxWeight = 0;

            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
            List<ClosestFacilityPath<Point2D>> pathResult = networkAnalyst.FindClosestFacility(networkDatasetName, facilities,
                eventPoint, expectFacilityCount, fromEvent, maxWeight, null);
            Assert.IsNotNull(pathResult);
            Assert.AreEqual(pathResult.Count, 2);
            Assert.AreEqual(pathResult[0].FacilityIndex, 0);
            Assert.AreEqual(pathResult[0].Facility.X, 70.1515638201);
            Assert.AreEqual(pathResult[0].Facility.Y, -54.7406354454);
            Assert.AreEqual(pathResult[1].FacilityIndex, 1);
            Assert.AreEqual(pathResult[1].Facility.X, 550.677059532);
            Assert.AreEqual(pathResult[1].Facility.Y, -56.1050211383);
            Assert.AreEqual(pathResult[0].Weight, 125);
            Assert.AreEqual(pathResult[1].Weight, 454);
            Assert.IsNotNull(pathResult[0].Route);
            Assert.IsNull(pathResult[0].PathGuideItems);
            Assert.IsNotNull(pathResult[0].NodeIDs);
            Assert.IsNull(pathResult[0].NodeFeatures);
            Assert.IsNull(pathResult[0].EdgeFeatures);
            Assert.IsNotNull(pathResult[0].EdgeIDs);
        }

        /// <summary>
        /// FindClosestFacility 参数为坐标点
        /// ReturnNodeFeatures为false,ReturnNodeGeometry 为true时，设置无效。
        /// </summary>
        [TestMethod]
        public void FindClosestFacilityTest_Point_Geometry()
        {
            string networkDatasetName = "RoadNet@Changchun";
            Point2D[] facilities = new Point2D[3];
            facilities[0] = new Point2D(70.1515638201, -54.7406354454);
            facilities[1] = new Point2D(550.6770595320, -56.1050211383);
            facilities[2] = new Point2D(445.6471889264, -229.2074549041);
            Point2D eventPoint = new Point2D(119.6100397551, -122.6278394459);
            int expectFacilityCount = 2;
            bool fromEvent = false;
            double maxWeight = 0;
            TransportationAnalystParameter parameter = new TransportationAnalystParameter();
            parameter.WeightFieldName = "length";
            parameter.TurnWeightField = "TurnCost";
            parameter.ResultSetting = new TransportationAnalystResultSetting();
            parameter.ResultSetting.ReturnEdgeFeatures = false;
            parameter.ResultSetting.ReturnEdgeGeometry = true;
            parameter.ResultSetting.ReturnEdgeIDs = true;
            parameter.ResultSetting.ReturnNodeFeatures = false;
            parameter.ResultSetting.ReturnNodeGeometry = true;
            parameter.ResultSetting.ReturnNodeIDs = true;
            parameter.ResultSetting.ReturnPathGuides = true;
            parameter.ResultSetting.ReturnRoutes = true;

            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
            List<ClosestFacilityPath<Point2D>> pathResult = networkAnalyst.FindClosestFacility(networkDatasetName, facilities,
                eventPoint, expectFacilityCount, fromEvent, maxWeight, parameter);
            Assert.IsNotNull(pathResult);
            Assert.AreEqual(pathResult.Count, 2);
            Assert.AreEqual(pathResult[0].FacilityIndex, 0);
            Assert.AreEqual(pathResult[0].Facility.X, 70.1515638201);
            Assert.AreEqual(pathResult[0].Facility.Y, -54.7406354454);
            Assert.AreEqual(pathResult[1].FacilityIndex, 1);
            Assert.AreEqual(pathResult[1].Facility.X, 550.677059532);
            Assert.AreEqual(pathResult[1].Facility.Y, -56.1050211383);
            Assert.AreEqual(pathResult[0].Weight, 125);
            Assert.AreEqual(pathResult[1].Weight, 484);
            Assert.IsNotNull(pathResult[0].StopWeights);
            Assert.IsNotNull(pathResult[0].Route);
            Assert.IsNotNull(pathResult[0].PathGuideItems);
            Assert.IsNotNull(pathResult[0].NodeIDs);
            Assert.IsNotNull(pathResult[0].EdgeIDs);
        }
        #endregion

        #region TSPPath

        [TestMethod]
        public void TSPPathTest_ID()
        {
            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
            int[] nodeIDs = new int[2] { 2, 3 };
            TransportationAnalystParameter parameter = new TransportationAnalystParameter();
            parameter.WeightFieldName = "length";
            parameter.TurnWeightField = "TurnCost";
            parameter.ResultSetting = new TransportationAnalystResultSetting();
            parameter.ResultSetting.ReturnEdgeFeatures = true;
            parameter.ResultSetting.ReturnEdgeGeometry = true;
            parameter.ResultSetting.ReturnEdgeIDs = true;
            parameter.ResultSetting.ReturnNodeFeatures = true;
            parameter.ResultSetting.ReturnNodeGeometry = true;
            parameter.ResultSetting.ReturnNodeIDs = true;
            parameter.ResultSetting.ReturnPathGuides = true;
            parameter.ResultSetting.ReturnRoutes = true;

            List<TSPPath> paths = networkAnalyst.FindTSPPath("RoadNet@Changchun", nodeIDs, false, parameter);

            Assert.IsNotNull(paths);
            Assert.IsNotNull(paths[0]);
            Assert.IsNotNull(paths[0].EdgeFeatures[0]);
            Assert.IsNotNull(paths[0].EdgeIDs[0]);
            Assert.IsNotNull(paths[0].NodeFeatures[0]);
            Assert.IsNotNull(paths[0].NodeIDs[0]);
            Assert.IsNotNull(paths[0].PathGuideItems[0]);
            Assert.IsNotNull(paths[0].Route);
            Assert.IsNotNull(paths[0].Route.Length);
            Assert.IsNotNull(paths[0].Route.Points[0]);
            Assert.AreEqual(paths[0].Route.Points[1].Measure, 42.273803871316005);
            Assert.IsNotNull(paths[0].Route.Type);
            Assert.AreEqual(paths[0].Route.MaxM, 53);
            Assert.AreEqual(paths[0].Route.MinM, 0.0);
            Assert.AreEqual(paths[0].Route.Type, GeometryType.LINEM);
            Assert.AreEqual(paths[0].StopIndexes[0], 0);
            Assert.AreEqual(paths[0].StopIndexes[1], 1);
        }

        [TestMethod]
        public void TSPPathTest_IDNUll()
        {
            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
            int[] nodeIDs = new int[] { };
            TransportationAnalystParameter parameter = new TransportationAnalystParameter();
            parameter.WeightFieldName = "length";
            parameter.TurnWeightField = "TurnCost";
            try
            {
                List<TSPPath> path = networkAnalyst.FindTSPPath("RoadNet@Changchun", nodeIDs, false, parameter);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual(e.Message, "参数 nodeIDsToVisit 不合法，必须至少包含两个二维点。");
            }
        }

        [TestMethod]
        public void TSPPathTest_DatasetNameNUll()
        {
            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
            int[] nodeIDs = new int[] { 2, 3 };
            TransportationAnalystParameter parameter = new TransportationAnalystParameter();
            parameter.WeightFieldName = "length";
            parameter.TurnWeightField = "TurnCost";
            try
            {
                List<TSPPath> path = networkAnalyst.FindTSPPath(string.Empty, nodeIDs, false, parameter);
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual(e.Message, "参数不能为空。\r\n参数名: networkDatasetName");
            }
        }

        [TestMethod]
        public void TSPPathTest_ParameterNUll()
        {
            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
            int[] nodeIDs = new int[] { 2, 3 };
            TransportationAnalystParameter parameter = new TransportationAnalystParameter();
            parameter.WeightFieldName = "length";
            parameter.TurnWeightField = "TurnCost";
            List<TSPPath> paths = networkAnalyst.FindTSPPath("RoadNet@Changchun", nodeIDs, false, null);

            Assert.IsNotNull(paths);
            Assert.IsNotNull(paths[0]);
            Assert.IsNotNull(paths[0].EdgeIDs[0]);
            Assert.IsNotNull(paths[0].NodeIDs[0]);
            Assert.IsNotNull(paths[0].Route);
            Assert.IsNotNull(paths[0].Route.Length);
            Assert.IsNotNull(paths[0].Route.Points[0]);
            Assert.AreEqual(paths[0].Route.Points[1].Measure, 42.273803871316005);
            Assert.IsNotNull(paths[0].Route.Type);
            Assert.AreEqual(paths[0].Route.MaxM, 53);
            Assert.AreEqual(paths[0].Route.MinM, 0.0);
            Assert.AreEqual(paths[0].StopWeights[0], 53);
            Assert.AreEqual(paths[0].Weight, 53);
            Assert.AreEqual(paths[0].StopIndexes[0], 0);
            Assert.AreEqual(paths[0].StopIndexes[1], 1);
        }

        [TestMethod]
        public void TSPPathTest_Point()
        {
            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
            Point2D[] points = new Point2D[4];
            points[0] = new Point2D(119.6100397551, -122.6278394459);
            points[1] = new Point2D(171.9035599945, -113.2491141857);
            points[2] = new Point2D(181.9035599945, -123.2491141857);
            points[3] = new Point2D(161.9035599945, -123.2491141857);
            TransportationAnalystParameter parameter = new TransportationAnalystParameter();
            parameter.WeightFieldName = "length";
            parameter.TurnWeightField = "TurnCost";
            parameter.ResultSetting = new TransportationAnalystResultSetting();
            parameter.ResultSetting.ReturnEdgeFeatures = true;
            parameter.ResultSetting.ReturnEdgeGeometry = true;
            parameter.ResultSetting.ReturnEdgeIDs = true;
            parameter.ResultSetting.ReturnNodeFeatures = true;
            parameter.ResultSetting.ReturnNodeGeometry = true;
            parameter.ResultSetting.ReturnNodeIDs = true;
            parameter.ResultSetting.ReturnPathGuides = true;
            parameter.ResultSetting.ReturnRoutes = true;

            List<TSPPath> paths = networkAnalyst.FindTSPPath("RoadNet@Changchun", points, false, parameter);

            Assert.IsNotNull(paths);
            Assert.IsNotNull(paths[0]);
            Assert.IsNotNull(paths[0].EdgeFeatures[0]);
            Assert.IsNotNull(paths[0].EdgeIDs[0]);
            Assert.IsNotNull(paths[0].NodeFeatures[0]);
            Assert.IsNotNull(paths[0].NodeIDs[0]);
            Assert.IsNotNull(paths[0].PathGuideItems[0]);
            Assert.IsNotNull(paths[0].Route);
            Assert.IsNotNull(paths[0].Route.Length);
            Assert.IsNotNull(paths[0].Route.Points[0]);
            Assert.AreEqual(paths[0].Route.Points[1].Measure, 40.716434549740718);
            Assert.IsNotNull(paths[0].Route.Type);
            Assert.AreEqual(paths[0].Route.MaxM, 66);
            Assert.AreEqual(paths[0].Route.MinM, 0.0);
            Assert.AreEqual(paths[0].StopIndexes[0], 0);
            Assert.AreEqual(paths[0].StopIndexes[1], 3);
            Assert.AreEqual(paths[0].Route.Type, GeometryType.LINEM);
        }

        [TestMethod]
        public void TSPPathTest_PointDatasetNull()
        {
            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
            Point2D[] points = new Point2D[4];
            points[0] = new Point2D(119.6100397551, -122.6278394459);
            points[1] = new Point2D(171.9035599945, -113.2491141857);
            points[2] = new Point2D(181.9035599945, -123.2491141857);
            points[3] = new Point2D(161.9035599945, -123.2491141857);
            TransportationAnalystParameter parameter = new TransportationAnalystParameter();
            parameter.WeightFieldName = "length";
            parameter.TurnWeightField = "TurnCost";
            try
            {
                List<TSPPath> paths = networkAnalyst.FindTSPPath(string.Empty, points, false, parameter);
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual(e.Message, "参数不能为空。\r\n参数名: networkDatasetName");
            }

        }

        [TestMethod]
        public void TSPPathTest_PointPointNull()
        {
            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
            Point2D[] points = new Point2D[1];
            points[0] = new Point2D(119.6100397551, -122.6278394459);

            TransportationAnalystParameter parameter = new TransportationAnalystParameter();
            parameter.WeightFieldName = "length";
            parameter.TurnWeightField = "TurnCost";
            try
            {
                List<TSPPath> paths = networkAnalyst.FindTSPPath("RoadNet@Changchun", points, false, parameter);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual(e.Message, "参数 pointsToVisit 不合法，必须至少包含两个二维点。");
            }

        }

        [TestMethod]
        public void TSPPathTest_PointParameterNull()
        {
            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
            Point2D[] points = new Point2D[4];
            points[0] = new Point2D(119.6100397551, -122.6278394459);
            points[1] = new Point2D(171.9035599945, -113.2491141857);
            points[2] = new Point2D(181.9035599945, -123.2491141857);
            points[3] = new Point2D(161.9035599945, -123.2491141857);

            List<TSPPath> paths = networkAnalyst.FindTSPPath("RoadNet@Changchun", points, false, null);

            Assert.IsNotNull(paths);
            Assert.IsNotNull(paths[0]);
            Assert.IsNull(paths[0].EdgeFeatures);
            Assert.IsNotNull(paths[0].EdgeIDs[0]);
            Assert.IsNull(paths[0].NodeFeatures);
            Assert.IsNotNull(paths[0].NodeIDs[0]);
            Assert.IsNull(paths[0].PathGuideItems);
            Assert.IsNotNull(paths[0].Route);
            Assert.IsNotNull(paths[0].Route.Length);
            Assert.IsNotNull(paths[0].Route.Points[0]);
            Assert.AreEqual(paths[0].Route.Points[1].Measure, 40.7164345497407);
            Assert.IsNotNull(paths[0].Route.Type);
            Assert.AreEqual(paths[0].Route.MaxM, 66);
            Assert.AreEqual(paths[0].Route.MinM, 0.0);
            Assert.AreEqual(paths[0].StopIndexes[0], 0);
            Assert.AreEqual(paths[0].StopIndexes[1], 3);
            Assert.AreEqual(paths[0].Route.Type, GeometryType.LINEM);
        }

        #endregion

        #region MTSPPath
        [TestMethod]
        public void MTSPPathTest_Point()
        {
            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
            Point2D[] points = new Point2D[4];
            points[0] = new Point2D(119.6100397551, -122.6278394459);
            points[1] = new Point2D(171.9035599945, -113.2491141857);
            points[2] = new Point2D(181.9035599945, -123.2491141857);
            points[3] = new Point2D(161.9035599945, -123.2491141857);
            Point2D[] centerPoints = new Point2D[2];
            centerPoints[0] = new Point2D(111.6100397551, -111.6278394459);
            centerPoints[1] = new Point2D(171.9035599945, -133.2491141857);

            List<MTSPPath<Point2D>> paths = networkAnalyst.FindMTSPPath("RoadNet@Changchun", points, centerPoints, false, null);

            Assert.IsNotNull(paths);
            Assert.IsNotNull(paths[0]);
            Assert.AreEqual(paths[0].StopIndexes[0], 0);
            Assert.AreEqual(paths[1].StopIndexes.Length, 3);
            Assert.AreEqual(paths[0].Center.X, 111.6100397551);
            Assert.AreEqual(paths[1].Center.X, 171.9035599945);
            Assert.AreEqual(paths[0].NodesVisited.Length, 1);
            Assert.AreEqual(paths[1].NodesVisited.Length, 3);
            Assert.IsNotNull(paths[0].EdgeIDs[0]);
            Assert.IsNotNull(paths[0].NodeIDs[0]);
            Assert.IsNotNull(paths[0].Route);
            Assert.IsNotNull(paths[0].Route.Length);
            Assert.IsNotNull(paths[0].Route.Points[0]);
        }

        [TestMethod]
        public void MTSPPathTest()
        {
            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
            int[] nodeIDs = new int[5] { 2, 3, 9, 11, 30 };
            int[] centerIDs = new int[2] { 6, 10 };

            List<MTSPPath<int>> path = networkAnalyst.FindMTSPPath("RoadNet@Changchun", nodeIDs, centerIDs, false, null);

            Assert.IsNotNull(path);
            Assert.AreEqual(path[0].Center, 6);
            Assert.AreEqual(path[1].Center, 10);
            Assert.AreEqual(path[0].NodesVisited.Length, 4);
            Assert.AreEqual(path[1].NodesVisited.Length, 1);
            Assert.AreEqual(path[0].Weight, 1142);
            Assert.AreEqual(path[1].Weight, 17086);
            Assert.AreEqual(path[0].Route.Type, GeometryType.LINEM);
        }

        [TestMethod]
        public void MTSPPathTest_Patameter()
        {
            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
            int[] nodeIDs = new int[5] { 2, 3, 9, 11, 30 };
            int[] centerIDs = new int[2] { 6, 10 };
            TransportationAnalystParameter parameter = new TransportationAnalystParameter();
            parameter.WeightFieldName = "length";
            parameter.TurnWeightField = "TurnCost";
            parameter.ResultSetting = new TransportationAnalystResultSetting();
            parameter.ResultSetting.ReturnEdgeFeatures = true;
            parameter.ResultSetting.ReturnEdgeGeometry = true;
            parameter.ResultSetting.ReturnEdgeIDs = true;
            parameter.ResultSetting.ReturnNodeFeatures = true;
            parameter.ResultSetting.ReturnNodeGeometry = true;
            parameter.ResultSetting.ReturnNodeIDs = true;
            parameter.ResultSetting.ReturnPathGuides = true;
            parameter.ResultSetting.ReturnRoutes = true;


            List<MTSPPath<int>> path = networkAnalyst.FindMTSPPath("RoadNet@Changchun", nodeIDs, centerIDs, false, null);

            Assert.IsNotNull(path);
            Assert.AreEqual(path[0].Center, 6);
            Assert.AreEqual(path[1].Center, 10);
            Assert.AreEqual(path[0].NodesVisited.Length, 4);
            Assert.AreEqual(path[1].NodesVisited.Length, 1);
            Assert.AreEqual(path[0].Weight, 1142);
            Assert.AreEqual(path[1].Weight, 17086);
            Assert.AreEqual(path[0].Route.Type, GeometryType.LINEM);
            Assert.IsNotNull(path[0].NodeIDs);
            Assert.IsNotNull(path[0].EdgeIDs);
            Assert.IsNotNull(path[0].Route);
        }

        [TestMethod]
        public void MTSPPathTest_DatasetNameNull()
        {
            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
            int[] nodeIDs = new int[5] { 2, 3, 9, 11, 30 };
            int[] centerIDs = new int[2] { 6, 10 };
            try
            {
                List<MTSPPath<int>> path = networkAnalyst.FindMTSPPath("", nodeIDs, centerIDs, false, null);
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual(e.Message, "参数不能为空。\r\n参数名: networkDatasetName");
            }

        }

        /// <summary>
        /// 支持一个中心点，一个配送点的情况
        /// </summary>
        [TestMethod]
        public void MTSPPathTest_OneID()
        {
            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
            int[] nodeIDs = new int[1] { 2 };
            int[] centerIDs = new int[1] { 6 };

            List<MTSPPath<int>> path = networkAnalyst.FindMTSPPath("RoadNet@Changchun", nodeIDs, centerIDs, false, null);

            Assert.AreEqual(path.Count, 1);
            //Assert.AreEqual(path[0].Center);
        }

        #endregion

        #region GetNetworkDatasetNames
        [TestMethod]
        public void GetNetworkDatasetNames()
        {
            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
            List<string> networkDatasetNames = networkAnalyst.GetNetworkDatasetNames();
            Assert.IsNotNull(networkDatasetNames);
            Assert.IsTrue(networkDatasetNames.Count == 1);
            Assert.IsTrue(string.Equals("RoadNet@Changchun", networkDatasetNames[0]));
        }
        #endregion

        #region GetTurnWeightNames
        [TestMethod]
        public void GetTurnWeightNames()
        {
            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
            List<string> turnWeightNames = networkAnalyst.GetTurnWeightNames("RoadNet@Changchun");
            Assert.IsNotNull(turnWeightNames);
            Assert.IsTrue(turnWeightNames.Count == 1);
            Assert.IsTrue(turnWeightNames[0] == "TurnCost");
        }

        [TestMethod]
        public void GetTurnWeightNames_DatasetNameIsEmpty()
        {
            try
            {
                NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
                List<string> turnWeightNames = networkAnalyst.GetTurnWeightNames("");
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsTrue(exception.ParamName == "networkDatasetName");
            }
        }
        #endregion

        #region GetWeightNames
        [TestMethod]
        public void GetWeightNames()
        {
            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
            List<string> turnWeightNames = networkAnalyst.GetWeightNames("RoadNet@Changchun");
            Assert.IsNotNull(turnWeightNames);
            Assert.IsTrue(turnWeightNames.Count == 2);
            Assert.IsTrue(turnWeightNames[0] == "length");
            Assert.IsTrue(turnWeightNames[1] == "time");
        }

        [TestMethod]
        public void GetWeightNames_DatasetNameIsEmpty()
        {
            try
            {
                NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
                List<string> turnWeightNames = networkAnalyst.GetWeightNames("");
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsTrue(exception.ParamName == "networkDatasetName");
            }
        }
        #endregion

        #region GetNetworkdDatasetPrj
        [TestMethod]
        public void GetNetworkdDatasetPrj()
        {
            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
            PrjCoordSys prj = networkAnalyst.GetNetworkDatasetPrj("RoadNet@Changchun");
            Assert.IsNotNull(prj);
            Assert.IsTrue(prj.CoordUnit == Unit.METER);
            Assert.IsTrue(prj.DistanceUnit == Unit.METER);
            Assert.IsTrue(prj.EpsgCode == -1000);
            Assert.IsTrue(prj.Name == "Planar Coordinate System---m");
            Assert.IsTrue(prj.Type == PrjCoordSysType.PCS_NON_EARTH);
            Assert.IsNull(prj.CoordSystem);
        }

        [TestMethod]
        public void GetNetworkdDatasetPrj_DatasetNameIsEmpty()
        {
            try
            {
                NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
                PrjCoordSys prj = networkAnalyst.GetNetworkDatasetPrj("");
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsTrue(exception.ParamName == "networkDatasetName");
            }
        }
        #endregion

        #region ReloadModel
        [TestMethod]
        public void ReloadModel()
        {
            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
            bool succeed = networkAnalyst.ReloadModel("RoadNet@Changchun");
            Assert.IsTrue(succeed);
        }

        [TestMethod]
        public void ReloadModel_DatasetNameIsEmpty()
        {
            try
            {
                NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
                bool succeed = networkAnalyst.ReloadModel("");
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsTrue(exception.ParamName == "networkDatasetName");
            }
        }
        #endregion

        #region UpdateTurnNodeWeight
        [TestMethod]
        public void UpdateTurnNodeWeight()
        {
            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
            bool succeed = networkAnalyst.UpdateTurnNodeWeight("RoadNet@Changchun", 1, 2027, 2027, "TurnCost", 30);
            Assert.IsTrue(succeed);
        }

        [TestMethod]
        public void UpdateTurnNodeWeight_ToEdgeIDNotFound()
        {
            try
            {
                NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
                bool succeed = networkAnalyst.UpdateTurnNodeWeight("RoadNet@Changchun", 1, 2027, 2028, "TurnCost", 30);
            }
            catch (ServiceException exception)
            {
                Assert.IsTrue(exception.Code == 400);
            }
        }

        public void UpdateTurnNodeWeight_TurnWeightFieldIsEmpty()
        {
            try
            {
                NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
                bool succeed = networkAnalyst.UpdateTurnNodeWeight("RoadNet@Changchun", 1, 2027, 2028, "", 30);
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsTrue(exception.ParamName == "turnWeightField");
            }
        }

        [TestMethod]
        public void UpdateTurnNodeWeight_DatasetNameIsEmpty()
        {
            try
            {
                NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
                bool succeed = networkAnalyst.UpdateTurnNodeWeight("", 1, 2027, 2028, "", 30);
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsTrue(exception.ParamName == "networkDatasetName");
            }
        }
        #endregion

        #region UpdateEdgeWeight
        [TestMethod]
        public void UpdateEdgeWeight()
        {
            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
            bool succeed = networkAnalyst.UpdateEdgeWeight("RoadNet@Changchun", 1, 5683, 5684, "length", 100);
            Assert.IsTrue(succeed);
        }

        [TestMethod]
        public void UpdateEdgeWeight_ToEdgeIDNotFound()
        {
            try
            {
                NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
                bool succeed = networkAnalyst.UpdateEdgeWeight("RoadNet@Changchun", 1, 2, 2, "time", 100);
            }
            catch (ServiceException exception)
            {
                //Assert.IsTrue(false);
            }
        }

        public void UpdateEdgeWeight_TurnWeightFieldIsEmpty()
        {
            try
            {
                NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
                bool succeed = networkAnalyst.UpdateEdgeWeight("RoadNet@Changchun", 1, 2027, 2028, "", 30);
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsTrue(exception.ParamName == "weightField");
            }
        }

        [TestMethod]
        public void UpdateEdgeWeight_DatasetNameIsEmpty()
        {
            try
            {
                NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
                bool succeed = networkAnalyst.UpdateEdgeWeight("", 1, 2027, 2028, "", 30);
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsTrue(exception.ParamName == "networkDatasetName");
            }
        }
        #endregion

        #region ComputeWeightMatrix

        [TestMethod]
        public void ComputeWeightMatrix_NodeIDs()
        {
            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");

            TransportationAnalystParameter parameter = new TransportationAnalystParameter();
            parameter.WeightFieldName = "length";
            parameter.TurnWeightField = "TurnCost";
            List<int> nodes = new List<int>() { 2, 6, 9 };
            double[][] weightMatrix = networkAnalyst.ComputeWeightMatrix("RoadNet@Changchun", nodes.ToArray(), null);

            Assert.IsNotNull(weightMatrix);
            Assert.IsTrue(weightMatrix.Length == 3);
            Assert.IsTrue(weightMatrix[0].Length == 3);
            Assert.IsTrue(weightMatrix[0][1] == 454);
        }

        [TestMethod]
        public void ComputeWeightMatrix_NodeIDs_WeightFieldNameError()
        {
            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");

            TransportationAnalystParameter parameter = new TransportationAnalystParameter();
            parameter.WeightFieldName = "length1";
            parameter.TurnWeightField = "TurnCost";

            List<int> nodes = new List<int>() { 2, 6, 9 };
            try
            {
                double[][] weightMatrix = networkAnalyst.ComputeWeightMatrix("RoadNet@Changchun", nodes.ToArray(), parameter);
            }
            catch (ServiceException e)
            {
                Assert.IsTrue(e.Code == 400);
                Assert.IsTrue("执行 findWeightMatrix 操作时出错,原因是：权重字段length1不存在。 " == e.Message);
            }
        }

        [TestMethod]
        public void ComputeWeightMatrix_Points()
        {
            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
            Point2D[] points = new Point2D[2];
            points[0] = new Point2D() { X = 32.754, Y = 23.205 };
            points[1] = new Point2D() { X = 415.55, Y = 87.66 };

            double[][] weightMatrix = networkAnalyst.ComputeWeightMatrix("RoadNet@Changchun", points);

            Assert.IsNotNull(weightMatrix);
            Assert.IsTrue(weightMatrix.Length == 2);
            Assert.IsTrue(weightMatrix[0].Length == 2);
            Assert.IsTrue(weightMatrix[1][0] == 446.26723858569954);
        }

        [TestMethod]
        public void ComputeWeightMatrix_IDError()
        {
            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");

            TransportationAnalystParameter parameter = new TransportationAnalystParameter();
            parameter.WeightFieldName = "length";
            parameter.TurnWeightField = "TurnCost";
            List<int> nodes = new List<int>() { -2, 6, 9 };
            try
            {
                double[][] weightMatrix = networkAnalyst.ComputeWeightMatrix("RoadNet@Changchun", nodes.ToArray());
            }
            catch (ServiceException exception)
            {
                //Assert.IsTrue("执行 findWeightMatrix 操作时出错,原因是：网络数据集中节点ID数组错误" == exception.Message);
                Assert.IsTrue(exception.Code == 400);
            }
        }

        #endregion

        #region FindLocation
        [TestMethod]
        public void FindLocation()
        {
            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
            LocationAnalystParameter parameter = new LocationAnalystParameter();
            parameter.WeightName = "length";
            parameter.TurnWeightField = "TurnCost";
            parameter.ReturnEdgeFeatures = true;
            parameter.ReturnEdgeGeometry = true;
            parameter.ReturnNodeFeatures = true;
            parameter.IsFromCenter = true;
            parameter.SupplyCenters = new List<SupplyCenter>();
            parameter.SupplyCenters.Add(new SupplyCenter() { NodeID = 11, MaxWeight = 100, Type = SupplyCenterType.FIXEDCENTER });
            parameter.SupplyCenters.Add(new SupplyCenter() { NodeID = 12, MaxWeight = 100, Type = SupplyCenterType.OPTIONALCENTER });
            parameter.ExpectedSupplyCenterCount = 2;
            LocationAnalystResult result = networkAnalyst.FindLocation("RoadNet@Changchun", parameter);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.DemandResults != null);
            Assert.IsTrue(result.SupplyResults != null);
            Assert.IsTrue(result.DemandResults.Count == 13);
        }

        [TestMethod]
        public void FindLocation_NetworkDatasetNameNotFound()
        {
            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
            LocationAnalystParameter parameter = new LocationAnalystParameter();
            parameter.WeightName = "length";
            parameter.TurnWeightField = "TurnCost";
            parameter.ReturnEdgeFeatures = true;
            parameter.ReturnEdgeGeometry = true;
            parameter.ReturnNodeFeatures = true;
            parameter.IsFromCenter = true;
            parameter.SupplyCenters = new List<SupplyCenter>();
            parameter.SupplyCenters.Add(new SupplyCenter() { NodeID = 11, MaxWeight = 100, Type = SupplyCenterType.FIXEDCENTER });
            parameter.SupplyCenters.Add(new SupplyCenter() { NodeID = 12, MaxWeight = 100, Type = SupplyCenterType.OPTIONALCENTER });
            parameter.ExpectedSupplyCenterCount = 2;
            try
            {
                LocationAnalystResult result = networkAnalyst.FindLocation("RoadNet1@Changchun", parameter);
            }
            catch (ServiceException exception)
            {
                Assert.IsTrue("不存在RoadNet1@Changchun对应的网络数据集。" == exception.Message);
                Assert.IsTrue(exception.Code == 400);
            }
        }

        [TestMethod]
        public void FindLocation_NodeIDError()
        {
            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
            LocationAnalystParameter parameter = new LocationAnalystParameter();
            parameter.WeightName = "length";
            parameter.TurnWeightField = "TurnCost";
            parameter.ReturnEdgeFeatures = true;
            parameter.ReturnEdgeGeometry = true;
            parameter.ReturnNodeFeatures = true;
            parameter.IsFromCenter = true;
            parameter.SupplyCenters = new List<SupplyCenter>();
            parameter.SupplyCenters.Add(new SupplyCenter() { NodeID = -11, MaxWeight = 100, Type = SupplyCenterType.FIXEDCENTER });
            parameter.SupplyCenters.Add(new SupplyCenter() { NodeID = 12, MaxWeight = 100, Type = SupplyCenterType.OPTIONALCENTER });
            parameter.ExpectedSupplyCenterCount = 2;
            LocationAnalystResult result = networkAnalyst.FindLocation("RoadNet@Changchun", parameter);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.DemandResults != null);
            Assert.IsTrue(result.SupplyResults != null);
        }

        [TestMethod]
        public void FindLocation_CountSet()
        {
            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");
            LocationAnalystParameter parameter = new LocationAnalystParameter();
            parameter.WeightName = "length";
            parameter.TurnWeightField = "TurnCost";
            parameter.ReturnEdgeFeatures = true;
            parameter.ReturnEdgeGeometry = true;
            parameter.ReturnNodeFeatures = true;
            parameter.IsFromCenter = true;
            parameter.SupplyCenters = new List<SupplyCenter>();
            parameter.SupplyCenters.Add(new SupplyCenter() { NodeID = -11, MaxWeight = 100, Type = SupplyCenterType.FIXEDCENTER });
            parameter.SupplyCenters.Add(new SupplyCenter() { NodeID = 12, MaxWeight = 100, Type = SupplyCenterType.OPTIONALCENTER });
            parameter.ExpectedSupplyCenterCount = 1;
            LocationAnalystResult result = networkAnalyst.FindLocation("RoadNet@Changchun", parameter);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.DemandResults != null);
            Assert.IsTrue(result.DemandResults.Count == 0);
            Assert.IsTrue(result.SupplyResults.Count == 1);
            Assert.IsTrue(result.SupplyResults != null);
            Assert.IsTrue(result.SupplyResults[0].AverageWeight == -1.0);
        }
        #endregion

        #region FindServiceArea
        [TestMethod]
        public void FindServiceArea_NodeIDs()
        {
            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");

            int[] centerIDs = new int[] { 2, 4, 6 };
            double[] weights = new double[] { 500, 1000, 500 };
            TransportationAnalystParameter parameter = new TransportationAnalystParameter();
            parameter.WeightFieldName = "length";
            parameter.TurnWeightField = "TurnCost";
            List<ServiceAreaResult> result = networkAnalyst.FindServiceArea("RoadNet@Changchun", centerIDs, weights, true, false, parameter);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 3);
            Assert.IsNotNull(result[0]);
            Assert.IsTrue(result[0].NodeIDs.Count == 16);
            Assert.IsTrue(result[0].EdgeIDs.Count == 19);
            Assert.IsTrue(result[0].Routes.Count == 19);
        }

        [TestMethod]
        public void FindServiceArea_CenterPoints()
        {
            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");

            Point2D[] centerPoints = new Point2D[1];
            centerPoints[0] = new Point2D() { X = 4978.55537676716, Y = -2574.77869765731 };
            double[] weights = new double[] { 300 };
            TransportationAnalystParameter parameter = new TransportationAnalystParameter();
            parameter.WeightFieldName = "length";
            parameter.TurnWeightField = "TurnCost";
            List<ServiceAreaResult> result = networkAnalyst.FindServiceArea("RoadNet@Changchun", centerPoints, weights, true, false, parameter);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 1);
            Assert.IsNotNull(result[0]);
            Assert.IsTrue(result[0].NodeIDs.Count == 19);
            Assert.IsTrue(result[0].EdgeIDs.Count == 38);
            Assert.IsTrue(result[0].Routes.Count == 40);
        }

        [TestMethod]
        public void FindServiceArea_WeightFieldNameNotFound()
        {
            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");

            Point2D[] centerPoints = new Point2D[1];
            centerPoints[0] = new Point2D() { X = 4978.55537676716, Y = -2574.77869765731 };
            double[] weights = new double[] { 300 };
            TransportationAnalystParameter parameter = new TransportationAnalystParameter();
            parameter.WeightFieldName = "length1";
            parameter.TurnWeightField = "TurnCost";
            try
            {
                List<ServiceAreaResult> result = networkAnalyst.FindServiceArea("RoadNet@Changchun", centerPoints, weights, true, false, parameter);
            }
            catch (ServiceException e)
            {
                Assert.IsTrue(e.Code == 400);
            }
        }

        [TestMethod]
        public void FindServiceArea_ReturnAllFalse()
        {
            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");

            Point2D[] centerPoints = new Point2D[1];
            centerPoints[0] = new Point2D() { X = 4978.55537676716, Y = -2574.77869765731 };
            double[] weights = new double[] { 300 };
            TransportationAnalystParameter parameter = new TransportationAnalystParameter();
            parameter.ResultSetting = new TransportationAnalystResultSetting();
            parameter.ResultSetting.ReturnEdgeFeatures = false;
            parameter.ResultSetting.ReturnEdgeGeometry = false;
            parameter.ResultSetting.ReturnEdgeIDs = false;
            parameter.ResultSetting.ReturnNodeFeatures = false;
            parameter.ResultSetting.ReturnNodeGeometry = false;
            parameter.ResultSetting.ReturnNodeIDs = false;
            parameter.ResultSetting.ReturnPathGuides = false;
            parameter.ResultSetting.ReturnRoutes = false;

            parameter.WeightFieldName = "length";
            parameter.TurnWeightField = "TurnCost";
            try
            {
                List<ServiceAreaResult> result = networkAnalyst.FindServiceArea("RoadNet@Changchun", centerPoints, weights, true, false, parameter);
                Assert.IsNotNull(result);
                Assert.IsTrue(result.Count == 1);
                Assert.IsTrue(result[0] != null);
                Assert.IsTrue(result[0].NodeIDs.Count == 0);
            }
            catch (ServiceException e)
            {
                Assert.IsTrue(e.Code == 400);
            }
        }

        [TestMethod]
        public void FindServiceArea_IsFromCenterFalse()
        {
            NetworkAnalyst networkAnalyst = new NetworkAnalyst("http://" + ip + ":8090/iserver/services/transportationanalyst-sample/rest");

            Point2D[] centerPoints = new Point2D[1];
            centerPoints[0] = new Point2D() { X = 4978.55537676716, Y = -2574.77869765731 };
            double[] weights = new double[] { 300 };
            TransportationAnalystParameter parameter = new TransportationAnalystParameter();
            parameter.ResultSetting = new TransportationAnalystResultSetting();

            parameter.WeightFieldName = "length";
            parameter.TurnWeightField = "TurnCost";
            try
            {
                List<ServiceAreaResult> result = networkAnalyst.FindServiceArea("RoadNet@Changchun", centerPoints, weights, false, false, parameter);
                Assert.IsNotNull(result);
                Assert.IsTrue(result.Count == 1);
                Assert.IsTrue(result[0] != null);
                Assert.IsTrue(result[0].NodeIDs.Count == 19);
            }
            catch (ServiceException e)
            {
                Assert.IsTrue(e.Code == 400);
            }
        }
        #endregion
    }
}
