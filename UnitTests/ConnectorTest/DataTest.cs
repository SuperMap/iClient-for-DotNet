using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperMap.Connector;
using SuperMap.Connector.Utility;

namespace SuperMap.Connector.UTests
{
    /// <summary>
    /// DataTest 的摘要说明
    /// </summary>
    [TestClass]
    public class DataTest
    {
        string ip = "192.168.116.114";

        public DataTest()
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

        [TestMethod]
        public void AddFeaturesTest()
        {
            Data data = new Data("http://" + ip + ":8090/iserver/services/data-world/rest");
            List<Feature> list = new List<Feature>();
            Feature feature1 = new Feature();
            //World  Capitals
            feature1.FieldNames = new string[3] { "CAPITAL", "COUNTRY", "CAP_POP" };
            feature1.FieldValues = new string[3] { "古代", "现代", "30000" };
            feature1.Geometry = new Geometry();
            feature1.Geometry.Type = GeometryType.POINT;
            feature1.Geometry.Parts = new int[1] { 1 };
            feature1.Geometry.Points = new Point2D[1];
            feature1.Geometry.Points[0] = new Point2D(50, 50);
            list.Add(feature1);

            Feature feature2 = new Feature();
            //World  Capitals
            feature2.FieldNames = new string[3] { "CAPITAL", "COUNTRY", "CAP_POP" };
            feature2.FieldValues = new string[3] { "测试", "测试", "300" };
            feature2.Geometry = new Geometry();
            feature2.Geometry.Type = GeometryType.POINT;
            feature2.Geometry.Parts = new int[1] { 1 };
            feature2.Geometry.Points = new Point2D[1];
            feature2.Geometry.Points[0] = new Point2D(50, 50);
            list.Add(feature2);

            EditResult result = data.AddFeatures("World", "Capitals", list);
            Assert.IsTrue(result.Succeed);
            Assert.AreEqual(result.Ids.Count(), 2);


            List<Feature> listUpdate = new List<Feature>();
            Feature featureUpdate = new Feature();
            //World  Capitals
            featureUpdate.Id = result.Ids[0];
            featureUpdate.FieldNames = new string[4] { "SMID", "CAPITAL", "COUNTRY", "CAP_POP" };
            featureUpdate.FieldValues = new string[4] { "166", "古代", "update现代", "300001" };
            featureUpdate.Geometry = new Geometry();
            featureUpdate.Geometry.Id = result.Ids[0];
            featureUpdate.Geometry.Type = GeometryType.POINT;
            featureUpdate.Geometry.Parts = new int[1] { 1 };
            featureUpdate.Geometry.Points = new Point2D[1];
            featureUpdate.Geometry.Points[0] = new Point2D(50, 50);
            featureUpdate.Geometry.Style = new Style();
            listUpdate.Add(featureUpdate);
            EditResult resultUpdate = data.UpdateFeatures("World", "Capitals", listUpdate);
            Assert.IsTrue(resultUpdate.Succeed);


            EditResult resultDelete = data.DeleteFeatures("World", "Capitals", result.Ids);
            Assert.IsTrue(resultDelete.Succeed);

        }

        /// <summary>
        /// datasourceName为空
        /// </summary>
        [TestMethod]
        public void AddFeaturesTest_NUllDatasource()
        {
            Data data = new Data("http://" + ip + ":8090/iserver/services/data-world/rest");
            List<Feature> list = new List<Feature>();
            Feature feature = new Feature();
            //World  Capitals
            feature.FieldNames = new string[4] { "SMID", "CAPITAL", "COUNTRY", "CAP_POP" };
            feature.FieldValues = new string[4] { "166", "古代", "update现代", "300001" };
            feature.Geometry = new Geometry();
            feature.Geometry.Id = 166;
            feature.Geometry.Type = GeometryType.POINT;
            feature.Geometry.Parts = new int[1] { 1 };
            feature.Geometry.Points = new Point2D[1];
            feature.Geometry.Points[0] = new Point2D(50, 50);
            feature.Geometry.Style = new Style();
            list.Add(feature);
            EditResult result = data.AddFeatures("", "Capitals", list);
            Assert.IsFalse(result.Succeed);
            Assert.AreEqual(result.Message, "参数 datasourceName 不能为空。");
        }

        /// <summary>
        /// datasetName为空
        /// </summary>
        [TestMethod]
        public void AddFeaturesTest_NUllDataSet()
        {
            Data data = new Data("http://" + ip + ":8090/iserver/services/data-world/rest");
            List<Feature> list = new List<Feature>();
            Feature feature = new Feature();
            //World  Capitals
            feature.FieldNames = new string[4] { "SMID", "CAPITAL", "COUNTRY", "CAP_POP" };
            feature.FieldValues = new string[4] { "166", "古代", "update现代", "300001" };
            feature.Geometry = new Geometry();
            feature.Geometry.Id = 166;
            feature.Geometry.Type = GeometryType.POINT;
            feature.Geometry.Parts = new int[1] { 1 };
            feature.Geometry.Points = new Point2D[1];
            feature.Geometry.Points[0] = new Point2D(50, 50);
            feature.Geometry.Style = new Style();
            list.Add(feature);
            EditResult result = data.AddFeatures("World", "", list);
            Assert.IsFalse(result.Succeed);
            Assert.AreEqual(result.Message, "参数 datasetName 不能为空。");
        }

        /// <summary>
        /// Features为空
        /// </summary>
        [TestMethod]
        public void AddFeaturesTest_NUllFeatures()
        {
            Data data = new Data("http://" + ip + ":8090/iserver/services/data-world/rest");
            List<Feature> list = new List<Feature>();
            Feature feature = new Feature();
            //World  Capitals
            feature.FieldNames = new string[4] { "SMID", "CAPITAL", "COUNTRY", "CAP_POP" };
            feature.FieldValues = new string[4] { "166", "古代", "update现代", "300001" };
            feature.Geometry = new Geometry();
            feature.Geometry.Id = 166;
            feature.Geometry.Type = GeometryType.POINT;
            feature.Geometry.Parts = new int[1] { 1 };
            feature.Geometry.Points = new Point2D[1];
            feature.Geometry.Points[0] = new Point2D(50, 50);
            feature.Geometry.Style = new Style();
            list.Add(feature);
            EditResult result = data.AddFeatures("World", "Capitals", null);
            Assert.IsFalse(result.Succeed);
            Assert.AreEqual(result.Message, "参数 targetFeatures 不能为空。");
        }

        /// <summary>
        /// Features为空
        /// </summary>
        [TestMethod]
        public void AddFeaturesTest_NUllFeatures2()
        {
            Data data = new Data("http://" + ip + ":8090/iserver/services/data-world/rest");
            List<Feature> list = new List<Feature>();
            EditResult result = data.AddFeatures("World", "Capitals", list);
            Assert.IsFalse(result.Succeed);
            Assert.AreEqual(result.Message, "参数 targetFeatures 不能为空。");
        }

        /// <summary>
        /// datasourceName为空
        /// </summary>
        [TestMethod]
        public void UpdateFeaturesTest_NUllDatasource()
        {
            Data data = new Data("http://" + ip + ":8090/iserver/services/data-world/rest");
            List<Feature> list = new List<Feature>();
            Feature feature = new Feature();
            //World  Capitals
            feature.FieldNames = new string[4] { "SMID", "CAPITAL", "COUNTRY", "CAP_POP" };
            feature.FieldValues = new string[4] { "166", "古代", "update现代", "300001" };
            feature.Geometry = new Geometry();
            feature.Geometry.Id = 166;
            feature.Geometry.Type = GeometryType.POINT;
            feature.Geometry.Parts = new int[1] { 1 };
            feature.Geometry.Points = new Point2D[1];
            feature.Geometry.Points[0] = new Point2D(50, 50);
            feature.Geometry.Style = new Style();
            list.Add(feature);
            EditResult result = data.UpdateFeatures("", "Capitals", list);
            Assert.IsFalse(result.Succeed);
            Assert.AreEqual(result.Message, "参数 datasourceName 不能为空。");
        }

        /// <summary>
        /// datasetName为空
        /// </summary>
        [TestMethod]
        public void UpdateFeaturesTest_NUllDataSet()
        {
            Data data = new Data("http://" + ip + ":8090/iserver/services/data-world/rest");
            List<Feature> list = new List<Feature>();
            Feature feature = new Feature();
            //World  Capitals
            feature.FieldNames = new string[4] { "SMID", "CAPITAL", "COUNTRY", "CAP_POP" };
            feature.FieldValues = new string[4] { "166", "古代", "update现代", "300001" };
            feature.Geometry = new Geometry();
            feature.Geometry.Id = 166;
            feature.Geometry.Type = GeometryType.POINT;
            feature.Geometry.Parts = new int[1] { 1 };
            feature.Geometry.Points = new Point2D[1];
            feature.Geometry.Points[0] = new Point2D(50, 50);
            feature.Geometry.Style = new Style();
            list.Add(feature);
            EditResult result = data.UpdateFeatures("World", "", list);
            Assert.IsFalse(result.Succeed);
            Assert.AreEqual(result.Message, "参数 datasetName 不能为空。");
        }

        /// <summary>
        /// Features为空
        /// </summary>
        [TestMethod]
        public void UpdateFeaturesTest_NUllFeatures()
        {
            Data data = new Data("http://" + ip + ":8090/iserver/services/data-world/rest");
            List<Feature> list = new List<Feature>();
            Feature feature = new Feature();
            //World  Capitals
            feature.FieldNames = new string[4] { "SMID", "CAPITAL", "COUNTRY", "CAP_POP" };
            feature.FieldValues = new string[4] { "166", "古代", "update现代", "300001" };
            feature.Geometry = new Geometry();
            feature.Geometry.Id = 166;
            feature.Geometry.Type = GeometryType.POINT;
            feature.Geometry.Parts = new int[1] { 1 };
            feature.Geometry.Points = new Point2D[1];
            feature.Geometry.Points[0] = new Point2D(50, 50);
            feature.Geometry.Style = new Style();
            list.Add(feature);
            EditResult result = data.UpdateFeatures("World", "Capitals", null);
            Assert.IsFalse(result.Succeed);
            Assert.AreEqual(result.Message, "参数 targetFeatures 不能为空。");
        }

        /// <summary>
        /// Features为空
        /// </summary>
        [TestMethod]
        public void UpdateFeaturesTest_NUllFeatures2()
        {
            Data data = new Data("http://" + ip + ":8090/iserver/services/data-world/rest");
            List<Feature> list = new List<Feature>();
            EditResult result = data.UpdateFeatures("World", "Capitals", list);
            Assert.IsFalse(result.Succeed);
            Assert.AreEqual(result.Message, "参数 targetFeatures 不能为空。");
        }

        /// <summary>
        /// Feature.ID为空
        /// </summary>
        [TestMethod]
        public void UpdateFeaturesTest_NUllID()
        {
            Data data = new Data("http://" + ip + ":8090/iserver/services/data-world/rest");
            List<Feature> list = new List<Feature>();
            Feature feature = new Feature();
            //World  Capitals
            feature.FieldNames = new string[4] { "SMID", "CAPITAL", "COUNTRY", "CAP_POP" };
            feature.FieldValues = new string[4] { "166", "古代", "update现代", "300001" };
            feature.Geometry = new Geometry();
            feature.Geometry.Id = 166;
            feature.Geometry.Type = GeometryType.POINT;
            feature.Geometry.Parts = new int[1] { 1 };
            feature.Geometry.Points = new Point2D[1];
            feature.Geometry.Points[0] = new Point2D(50, 50);
            feature.Geometry.Style = new Style();
            list.Add(feature);
            EditResult result = data.UpdateFeatures("World", "Capitals", list);
            Assert.IsFalse(result.Succeed);
            Assert.AreEqual(result.Message, "参数 Feature.Id 不合法。");
        }

        /// <summary>
        /// datasourceName为空
        /// </summary>
        [TestMethod]
        public void DeleteFeaturesTest_NUllDatasource()
        {
            Data data = new Data("http://" + ip + ":8090/iserver/services/data-world/rest");
            int[] ids = new int[] { 2, 3 };
            EditResult result = data.DeleteFeatures("", "Capitals", ids);
            Assert.IsFalse(result.Succeed);
            Assert.AreEqual(result.Message, "参数 datasourceName 不能为空。");
        }

        /// <summary>
        /// datasetName为空
        /// </summary>
        [TestMethod]
        public void DeleteFeaturesTest_NUllDataset()
        {
            Data data = new Data("http://" + ip + ":8090/iserver/services/data-world/rest");
            int[] ids = new int[] { 2, 3 };
            EditResult result = data.DeleteFeatures("World", "", ids);
            Assert.IsFalse(result.Succeed);
            Assert.AreEqual(result.Message, "参数 datasetName 不能为空。");
        }

        /// <summary>
        /// GetFeature by sql
        /// </summary>
        [TestMethod]
        public void GetFeatureTestSQL()
        {
            Data data = new Data("http://" + ip + ":8090/iserver/services/data-world/rest");
            string[] datasetNames = { "World:Capitals", "World:Ocean" };
            List<Feature> result = data.GetFeature(datasetNames, new QueryParameter());
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count, 235);
            Assert.AreEqual(result[0].FieldNames.Length, 9);
            Assert.AreEqual(result[0].FieldValues[6], "维尔纽斯");
            Assert.AreEqual(result[234].FieldNames.Length, 10);
            Assert.AreEqual(result[234].FieldValues[8], "1944");
            Assert.AreEqual(result[234].Id, 72);
            Assert.AreEqual(result[234].Geometry.Id, 72);
        }

        /// <summary>
        /// GetFeature by sql maxFeatures
        /// </summary>
        [TestMethod]
        public void GetFeatureTest_SqlByMaxFeatures()
        {
            Data data = new Data("http://" + ip + ":8090/iserver/services/data-world/rest");
            string[] datasetNames = { "World:Capitals", "World:Ocean" };
            List<Feature> result = data.GetFeature(datasetNames, null, 1);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[0].FieldValues.Length, 9);
            Assert.AreEqual(result[0].FieldValues[6], "维尔纽斯");
            Assert.AreEqual(result[1].FieldValues.Length, 10);
            Assert.AreEqual(result[1].FieldValues[7], "120.0");
        }

        /// <summary>
        /// GetFeature by Buffer and attributeFilter
        /// </summary>
        [TestMethod]
        public void GetFeatureTest_BufferAndAttributeFilter()
        {
            Data data = new Data("http://" + ip + ":8090/iserver/services/data-world/rest");
            string[] datasetNames = { "World:Capitals", "World:Ocean" };

            Geometry geometry = new Geometry();
            geometry.Parts = new int[1] { 5 };
            geometry.Points = new Point2D[5];
            geometry.Points[0] = new Point2D(-45, -90);
            geometry.Points[1] = new Point2D(-45, 90);
            geometry.Points[2] = new Point2D(45, 90);
            geometry.Points[3] = new Point2D(45, -90);
            geometry.Points[4] = new Point2D(-45, -90);

            double bufferDistance = 0.1;
            string[] fields = { "smid", "CAP_POP" };
            List<Feature> result = data.GetFeature(datasetNames, geometry, bufferDistance, "smid=1", fields);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0].FieldNames.Length, 2);
            Assert.AreEqual(result[0].FieldNames[0], "smid");
            Assert.AreEqual(result[0].FieldNames[1], "CAP_POP");
            Assert.AreEqual(result[0].FieldValues[0], "1");
            Assert.AreEqual(result[0].FieldValues[1], "582000.0");
            Assert.AreEqual(result[0].Geometry.Id, 1);
            Assert.AreEqual(result[0].Id, 1);
        }

        /// <summary>
        /// GetFeature by Buffer
        /// </summary>
        [TestMethod]
        public void GetFeatureTest_Buffer()
        {
            Data data = new Data("http://" + ip + ":8090/iserver/services/data-world/rest");
            string[] datasetNames = { "World:Capitals", "World:Ocean" };

            Geometry geometry = new Geometry();
            geometry.Parts = new int[1] { 5 };
            geometry.Points = new Point2D[5];
            geometry.Points[0] = new Point2D(-45, -90);
            geometry.Points[1] = new Point2D(-45, 90);
            geometry.Points[2] = new Point2D(45, 90);
            geometry.Points[3] = new Point2D(45, -90);
            geometry.Points[4] = new Point2D(-45, -90);

            double bufferDistance = 0.1;
            string[] fields = { "smid", "CAP_POP" };
            List<Feature> result = data.GetFeature(datasetNames, geometry, bufferDistance, fields);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count, 118);
            Assert.AreEqual(result[0].FieldNames.Length, 2);
            Assert.AreEqual(result[0].FieldNames[0], "smid");
            Assert.AreEqual(result[0].FieldNames[1], "CAP_POP");
            Assert.AreEqual(result[0].FieldValues[0], "1");
            Assert.AreEqual(result[0].FieldValues[1], "582000.0");
            Assert.AreEqual(result[0].Geometry.Id, 1);
            Assert.AreEqual(result[0].Id, 1);
            Assert.AreEqual(result[117].FieldNames.Length, 1);
            Assert.AreEqual(result[117].FieldNames[0], "smid");
            //Assert.AreEqual(result[117].FieldNames[1], null);
            //Assert.AreEqual(result[117].FieldValues[0], "68");
            //Assert.AreEqual(result[117].FieldValues[1], null);
        }

        /// <summary>
        /// Getfeature By ID
        /// </summary>
        [TestMethod]
        public void GetFeatureTest_ID()
        {
            Data data = new Data("http://" + ip + ":8090/iserver/services/data-world/rest");
            string[] datasetNames = { "World:Capitals", "World:Ocean" };
            int[] ids = { 1, 2, 3, 5, 7 };
            string[] fields = { "smid", "CAP_POP" };
            List<Feature> result = data.GetFeature(datasetNames, ids, fields);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count, 10);
            Assert.AreEqual(result[0].FieldNames.Length, 2);
            Assert.AreEqual(result[0].FieldNames[0], "smid");
            Assert.AreEqual(result[0].FieldNames[1], "CAP_POP");
            Assert.AreEqual(result[0].FieldValues[0], "1");
            Assert.AreEqual(result[0].FieldValues[1], "582000.0");
            Assert.AreEqual(result[9].FieldNames.Length, 1);
            Assert.AreEqual(result[9].FieldNames[0], "smid");
            //Assert.AreEqual(result[9].FieldNames[1], null);
            //Assert.AreEqual(result[9].FieldValues[0], "7");
            //Assert.AreEqual(result[9].FieldValues[1], null);
            //Assert.AreEqual(result[9].Id, 7);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void GetFeatureTest_SPATIAL()
        {
            Data data = new Data("http://" + ip + ":8090/iserver/services/data-world/rest");
            string[] datasetNames = { "World:Capitals", "World:Ocean" };

            Geometry geometry = new Geometry();
            geometry.Parts = new int[1] { 5 };
            geometry.Points = new Point2D[5];
            geometry.Points[0] = new Point2D(-45, -90);
            geometry.Points[1] = new Point2D(-45, 90);
            geometry.Points[2] = new Point2D(45, 90);
            geometry.Points[3] = new Point2D(45, -90);
            geometry.Points[4] = new Point2D(-45, -90);
            string[] fields = { "smid", "CAP_POP" };
            List<Feature> result = data.GetFeature(datasetNames, geometry, SpatialQueryMode.CONTAIN, fields);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count, 106);
            Assert.AreEqual(result[0].FieldValues.Length, 2);
            Assert.AreEqual(result[0].FieldNames.Length, 2);
            Assert.AreEqual(result[105].FieldNames.Length, 1);
            Assert.AreEqual(result[105].Id, 67);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void GetFeatureTest_SPATIAL_ATTRIBUTEFILTER()
        {
            Data data = new Data("http://" + ip + ":8090/iserver/services/data-world/rest");
            string[] datasetNames = { "World:Capitals", "World:Ocean" };

            Geometry geometry = new Geometry();
            geometry.Parts = new int[1] { 5 };
            geometry.Points = new Point2D[5];
            geometry.Points[0] = new Point2D(-45, -90);
            geometry.Points[1] = new Point2D(-45, 90);
            geometry.Points[2] = new Point2D(45, 90);
            geometry.Points[3] = new Point2D(45, -90);
            geometry.Points[4] = new Point2D(-45, -90);
            string[] fields = { "smid", "CAP_POP" };
            List<Feature> result = data.GetFeature(datasetNames, geometry, SpatialQueryMode.CONTAIN, "smid<10", fields);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count, 11);
            Assert.AreEqual(result[0].FieldValues.Length, 2);
            Assert.AreEqual(result[0].FieldNames.Length, 2);
            Assert.AreEqual(result[10].FieldNames.Length, 1);
            Assert.AreEqual(result[10].Id, 7);
        }

        [TestMethod]
        public void GetFeatureTest_BOUNDS()
        {
            Data data = new Data("http://" + ip + ":8090/iserver/services/data-world/rest");
            string[] datasetNames = { "World:Capitals", "World:Ocean" };
            Rectangle2D bound = new Rectangle2D(new Point2D(-45, -45), new Point2D(45, 45));
            string[] fields = { "smid", "CAP_POP" };
            List<Feature> result = data.GetFeature(datasetNames, bound, fields);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count, 83);
            Assert.AreEqual(result[0].FieldValues.Length, 2);
            Assert.AreEqual(result[0].FieldNames.Length, 2);
            Assert.AreEqual(result[10].FieldNames.Length, 2);
            Assert.AreEqual(result[82].Id, 56);

        }

        [TestMethod]
        public void GetFeatureTest_BOUNDS_ATTRIBUTEFILTER()
        {
            Data data = new Data("http://" + ip + ":8090/iserver/services/data-world/rest");
            string[] datasetNames = { "World:Capitals", "World:Ocean" };
            Rectangle2D bound = new Rectangle2D(new Point2D(-45, -45), new Point2D(45, 45));
            string[] fields = { "smid", "CAP_POP" };
            List<Feature> result = data.GetFeature(datasetNames, bound, "smid<60", fields);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count, 32);
            Assert.AreEqual(result[0].FieldValues.Length, 2);
            Assert.AreEqual(result[0].FieldNames.Length, 2);
            Assert.AreEqual(result[10].FieldNames.Length, 2);
            Assert.AreEqual(result[31].Id, 56);

        }

        /// <summary>
        /// 新增
        /// </summary>
        [TestMethod]
        public void CreateDatasetTest()
        {
            Data data = new Data("http://" + ip + ":8090/iserver/services/data-world/rest");
            DatasetInfo datasetInfo = new DatasetInfo();
            datasetInfo.Name = "World4";
            datasetInfo.Type = DatasetType.POINT;
            bool result = data.CreateDataset("World", datasetInfo.Name, datasetInfo.Type);
            Assert.IsTrue(result);
            bool deleteResult = data.DeleteDataset("World", "World4");
            Assert.IsTrue(deleteResult);
        }

        /// <summary>
        /// copy
        /// </summary>
        [TestMethod]
        public void CopyDatasetTest()
        {
            Data data = new Data("http://" + ip + ":8090/iserver/services/data-world/rest");

            bool result = data.CopyDataset("World", "Countries", "CountriesCopy");
            Assert.IsTrue(result);

            DatasetInfo getResult = data.GetDatasetInfo("World", "CountriesCopy");
            Assert.IsNotNull(getResult);

            bool deleteResult = data.DeleteDataset("World", "CountriesCopy");
            Assert.IsTrue(deleteResult);
        }

        /// <summary>
        /// get
        /// </summary>
        [TestMethod]
        public void GetDatasetInfoTest()
        {
            Data data = new Data("http://" + ip + ":8090/iserver/services/data-world/rest");
            DatasetInfo result = data.GetDatasetInfo("World", "Countries");
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// 修改
        /// </summary>
        [TestMethod]
        public void UpdateDatasetInfo()
        {
            DatasetInfo datasetInfo = new DatasetInfo();
            datasetInfo.Name = "Countries";
            datasetInfo.Type = DatasetType.POINT;
            datasetInfo.Description = "11111";
            Data data = new Data("http://" + ip + ":8090/iserver/services/data-world/rest");
            bool result = data.UpdateDatasetInfo("World", "Countries", datasetInfo);
            Assert.IsNotNull(result);
        }

        #region DataSource
        [TestMethod]
        public void GetDatasourceInfos()
        {
            Data data = new Data("http://" + ip + ":8090/iserver/services/data-world/rest");
            List<DatasourceInfo> datasourceInfo = data.GetDatasourceInfos();

            Assert.IsNotNull(datasourceInfo);
            Assert.IsTrue(datasourceInfo.Count == 1);
            Assert.IsTrue(datasourceInfo[0] != null);
            Assert.IsTrue(datasourceInfo[0].Name == "World");
        }

        [TestMethod]
        public void GetDatasourceInfo()
        {
            Data data = new Data("http://" + ip + ":8090/iserver/services/data-world/rest");
            DatasourceInfo datasourceInfo = data.GetDatasourceInfo("World");
            Assert.IsNotNull(datasourceInfo != null);
            Assert.IsTrue(datasourceInfo.Name == "World");
        }

        [TestMethod]
        public void GetDatasourceInfo_SourceNameError()
        {
            Data data = new Data("http://" + ip + ":8090/iserver/services/data-world/rest");
            try
            {
                DatasourceInfo datasourceInfo = data.GetDatasourceInfo("World1");
            }
            catch (ServiceException exception)
            {
                Assert.IsTrue(exception.Code == 404);
            }
        }

        [TestMethod]
        public void UpdateDatasourceInfo()
        {
            Data data = new Data("http://" + ip + ":8090/iserver/services/data-world/rest");

            bool succeed = data.UpdateDatasourceInfo("World", new DatasourceInfo() { Description = "世界地图1" });
            Assert.IsTrue(succeed);
        }

        [TestMethod]
        public void UpdateDatasourceInfo_Valid()
        {
            Data data = new Data("http://" + ip + ":8090/iserver/services/data-world/rest");

            bool succeed = data.UpdateDatasourceInfo("World", new DatasourceInfo() { Description = "世界地图1" });
            DatasourceInfo info = data.GetDatasourceInfo("World");
            Assert.IsTrue(succeed);
            Assert.IsNotNull(info);
            Assert.IsTrue(info.Description == "世界地图1");
        }

        [TestMethod]
        public void UpdateDatasourceInof_ErrorDatasourceName()
        {
            Data data = new Data("http://" + ip + ":8090/iserver/services/data-world/rest");
            try
            {
                bool succeed = data.UpdateDatasourceInfo("World", new DatasourceInfo() { Description = "世界地图1" });
            }
            catch (ServiceException exception)
            {
                Assert.IsTrue(exception.Code == 404);
            }
        }
        #endregion

        #region GetFieldInfo
        [TestMethod]
        public void GetFieldInfos()
        {
            Data data = new Data("http://" + ip + ":8090/iserver/services/data-world/rest");
            List<FieldInfo> fieldInfos = data.GetFieldInfos("World", "Capitals");
            Assert.IsNotNull(fieldInfos);
        }

        [TestMethod]
        public void CreateField()
        {
            Data data = new Data("http://" + ip + ":8090/iserver/services/data-world/rest");
            bool createDatasetResult = data.CreateDataset("World", "testUpdate", DatasetType.LINE);

            bool createFieldResult = data.CreateField("World", "testUpdate", new FieldInfo() { Caption = "name", Name = "name", Type = FieldType.CHAR });

            data.DeleteDataset("World", "testUpdate");

            Assert.IsTrue(createFieldResult);
        }

        [TestMethod]
        public void DeleteField()
        {
            Data data = new Data("http://" + ip + ":8090/iserver/services/data-world/rest");
            bool createDatasetResult = data.CreateDataset("World", "testUpdate1", DatasetType.LINE);

            bool createFieldResult = data.CreateField("World", "testUpdate1", new FieldInfo() { Caption = "name", Name = "name", Type = FieldType.CHAR });
            bool deleteFieldResult = data.DeleteField("World", "testUpdate1", "name");
            data.DeleteDataset("World", "testUpdate1");

            Assert.IsTrue(deleteFieldResult);
        }

        [TestMethod]
        public void UpdateField()
        {
            Data data = new Data("http://" + ip + ":8090/iserver/services/data-world/rest");
            try
            {
                data.DeleteDataset("World", "testUpdate2");
            }
            catch { }
            bool createDatasetResult = data.CreateDataset("World", "testUpdate2", DatasetType.LINE);
            bool createFieldResult = data.CreateField("World", "testUpdate2", new FieldInfo() { Caption = "name", Name = "name", Type = FieldType.CHAR });
            bool upateFieldResult = data.UpdateField("World", "testUpdate2", "name", new FieldInfo() { Caption = "Name1" });
            FieldInfo filedInfo = data.GetFieldInfo("World", "testUpdate2", "name");
            Assert.IsTrue(filedInfo.Name == "name");
            Assert.IsTrue(filedInfo.Caption == "Name1");
        }
        #endregion

        [TestMethod]
        public void Statistic_MIN()
        {
            Data data = new Data("http://" + ip + ":8090/iserver/services/data-world/rest");
            double result = data.Statistic("World", "Countries", "COLOR_MAP", StatisticMode.MIN);
            Assert.IsTrue(result == 1.0);
        }

        [TestMethod]
        public void Statistic_AVERAGE()
        {
            Data data = new Data("http://" + ip + ":8090/iserver/services/data-world/rest");
            double result = data.Statistic("World", "Countries", "COLOR_MAP", StatisticMode.AVERAGE);
            Assert.IsTrue(result == 2.58704453441296);
        }

        [TestMethod]
        public void Statistic_MAX()
        {
            Data data = new Data("http://" + ip + ":8090/iserver/services/data-world/rest");
            double result = data.Statistic("World", "Countries", "COLOR_MAP", StatisticMode.MAX);
            Assert.IsTrue(result == 4.0);
        }

        [TestMethod]
        public void Statistic_STDDEVIATION()
        {
            Data data = new Data("http://" + ip + ":8090/iserver/services/data-world/rest");
            double result = data.Statistic("World", "Countries", "COLOR_MAP", StatisticMode.STDDEVIATION);
            Assert.IsTrue(result == 1.09448108072884);
        }

        [TestMethod]
        public void Statistic_SUM()
        {
            Data data = new Data("http://" + ip + ":8090/iserver/services/data-world/rest");
            double result = data.Statistic("World", "Countries", "COLOR_MAP", StatisticMode.SUM);
            Assert.IsTrue(result == 639);
        }

        [TestMethod]
        public void Statistic_VARIANCE()
        {
            Data data = new Data("http://" + ip + ":8090/iserver/services/data-world/rest");
            double result = data.Statistic("World", "Countries", "COLOR_MAP", StatisticMode.VARIANCE);
            Assert.IsTrue(result == 1.19788883607337);
        }

        [TestMethod]
        public void GetDatasourceInfosTest_Error()
        {
            Data data = new Data("http://" + ip + ":8090/iserver/services/data-world1/rest");
            try
            {
                List<DatasourceInfo> datasourceInfos = data.GetDatasourceInfos();
            }
            catch (ServiceException e)
            {
                Assert.IsNotNull(e.Message, "远程服务器返回错误: (404) 未找到。");
                Assert.AreEqual(e.Code,404);
            }
        }

        [TestMethod]
        public void GetDatasourceInfoTest_Error()
        {
            Data data = new Data("http://" + ip + ":8090/iserver/services/data-world/rest");
            try
            {
                DatasourceInfo dataosurceInfo = data.GetDatasourceInfo("worl");
            }
            catch (ServiceException e)
            {
                Assert.AreEqual(e.Message, "数据源worl不存在，获取相应的数据服务组件失败");
            }
        }

    }
}
