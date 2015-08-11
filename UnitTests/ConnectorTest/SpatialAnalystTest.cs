using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperMap.Connector.Utility;

namespace SuperMap.Connector.UTests
{
    [TestClass]
    public class SpatialAnalystTest
    {
        string ip = "192.168.116.114";
        public SpatialAnalystTest()
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

        #region GetDatasourceNames

        [TestMethod]
        public void GetDatasourceNames_Normal1()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-sample/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
            List<string> datasourceNames = spatialAnalyst.GetDatasourceNames();
            Assert.IsNotNull(datasourceNames);
            Assert.IsTrue(datasourceNames.Count == 2);
            Assert.IsTrue(datasourceNames[0] == "Interpolation");
            Assert.IsTrue(datasourceNames[1] == "Jingjin");
        }

        [TestMethod]
        public void GetDatasourceNames_Normal2()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-changchun/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
            List<string> datasourceNames = spatialAnalyst.GetDatasourceNames();
            Assert.IsNotNull(datasourceNames);
            Assert.IsTrue(datasourceNames.Count == 1);
            Assert.IsTrue(datasourceNames[0] == "Changchun");
        }

        [TestMethod]
        public void GetDatasourceNames_ServiceUrlError1()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-sample1/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
            try
            {
                List<string> datasourceNames = spatialAnalyst.GetDatasourceNames();
            }
            catch (ServiceException e)
            {
                Assert.IsTrue(e.Code == 404);
            }
        }

        [TestMethod]
        public void GetDatasourceNames_ServiceUrlError2()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver1/services/spatialanalyst-sample/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
            try
            {
                List<string> datasourceNames = spatialAnalyst.GetDatasourceNames();
            }
            catch (ServiceException e)
            {
                Assert.IsTrue(e.Code == 404);
            }
        }

        #endregion

        #region GetDatasetInfos
        [TestMethod]
        public void GetdatasetInfos_Normal1()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-sample/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
            string datasourceName = "Jingjin";
            List<DatasetInfo> datasetInfos = spatialAnalyst.GetDatasetInfos(datasourceName);
            Assert.IsNotNull(datasetInfos);
            //Assert.IsTrue(datasetInfos.Count == 25);
            for (int i = 0; i < datasetInfos.Count; i++)
            {
                Assert.IsTrue(datasetInfos[i].DataSourceName == "Jingjin");
            }
            Assert.IsTrue(datasetInfos[0].Name == "BaseMap_L");
        }

        [TestMethod]
        public void GetdatasetInfos_Normal2()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-sample/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
            string datasourceName = "Interpolation";
            List<DatasetInfo> datasetInfos = spatialAnalyst.GetDatasetInfos(datasourceName);
            Assert.IsNotNull(datasetInfos);
            //Assert.IsTrue(datasetInfos.Count == 5);
            for (int i = 0; i < datasetInfos.Count; i++)
            {
                Assert.IsTrue(datasetInfos[i].DataSourceName == "Interpolation");
            }
            Assert.IsTrue(datasetInfos[0].Name == "SamplesP");
        }

        [TestMethod]
        public void GetdatasetInfos_DatasourceNameError()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-sample/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
            string datasourceName = "";
            try
            {
                List<DatasetInfo> datasetInfos = spatialAnalyst.GetDatasetInfos(datasourceName);
            }
            catch (ArgumentNullException e)
            {
                Assert.IsTrue(e.ParamName == "datasourceName");
            }
        }

        [TestMethod]
        public void GetdatasetInfos_DatasourceNameError1()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-sample/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
            string datasourceName = "Interpolation1";

            List<DatasetInfo> datasetInfos = spatialAnalyst.GetDatasetInfos(datasourceName);
            Assert.IsTrue(datasetInfos != null);
            Assert.IsTrue(datasetInfos.Count == 0);
        }
        #endregion

        #region GetDatasetInfo
        [TestMethod]
        public void GetDatasetInfo_Normal1()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-sample/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
            string datasourceName = "Jingjin";
            string datasetName = "BaseMap_L";
            DatasetInfo datasetInfo = spatialAnalyst.GetDatasetInfo(datasourceName, datasetName);
            Assert.IsNotNull(datasetInfo);
            Assert.IsTrue(datasetInfo is DatasetVectorInfo);
            DatasetVectorInfo datasetVectorInfo = datasetInfo as DatasetVectorInfo;
            Assert.IsNotNull(datasetVectorInfo);
            Assert.IsTrue(datasetInfo.DataSourceName == "Jingjin");
            Assert.IsTrue(datasetInfo.Name == "BaseMap_L");
            Assert.IsTrue(datasetVectorInfo.RecordCount == 47);
            Assert.IsTrue(datasetVectorInfo.Type == DatasetType.LINE);
        }

        [TestMethod]
        public void GetDatasetInfo_Normal2()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-sample/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
            string datasourceName = "Interpolation";
            string datasetName = "Temp5000";
            DatasetInfo datasetInfo = spatialAnalyst.GetDatasetInfo(datasourceName, datasetName);
            Assert.IsNotNull(datasetInfo);
            Assert.IsTrue(datasetInfo is DatasetGridInfo);
            DatasetGridInfo datasetGridInfo = datasetInfo as DatasetGridInfo;
            Assert.IsNotNull(datasetGridInfo);
            Assert.IsTrue(datasetGridInfo.DataSourceName == datasourceName);
            Assert.IsTrue(datasetGridInfo.Name == datasetName);
            Assert.IsTrue(datasetGridInfo.BlockSize == 128);
            Assert.IsTrue(datasetGridInfo.PixelFormat == PixelFormat.SINGLE);
        }

        [TestMethod]
        public void GetDatasetInfo_Normal3()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-sample/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
        }

        [TestMethod]
        public void GetDatasetInfo_DatasourceNameError()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-sample/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
            string datasourceName = "";
            string datasetName = "Temp5000";
            try
            {
                spatialAnalyst.GetDatasetInfo(datasourceName, datasetName);
            }
            catch (ArgumentNullException e)
            {
                Assert.IsTrue(e.ParamName == "datasourceName");
            }
        }

        [TestMethod]
        public void GetDatasetInfo_DatasourceNameError1()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-sample/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
            string datasourceName = "Interpolation1";
            string datasetName = "Temp5000";

            DatasetInfo datasetInfo = spatialAnalyst.GetDatasetInfo(datasourceName, datasetName);
            Assert.IsNull(datasetInfo);
        }

        [TestMethod]
        public void GetDatasetInfo_DatasetNameError()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-sample/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
            string datasourceName = "Interpolation";
            string datasetName = "";
            try
            {
                spatialAnalyst.GetDatasetInfo(datasourceName, datasetName);
            }
            catch (ArgumentNullException e)
            {
                Assert.IsTrue(e.ParamName == "datasetName");
            }
        }

        [TestMethod]
        public void GetDatasetInfo_DatasetNameError1()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-sample/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
            string datasourceName = "Interpolation";
            string datasetName = "Temp50001";

            DatasetInfo datasetInfo = spatialAnalyst.GetDatasetInfo(datasourceName, datasetName);
            Assert.IsNull(datasetInfo);
        }
        #endregion

        #region Dataset Buffer
        [TestMethod]
        public void Buffer_ByPointDataset()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-changchun/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);

            BufferAnalystParameter bufferAnalystParameter = new BufferAnalystParameter();
            bufferAnalystParameter.EndType = BufferEndType.ROUND;
            bufferAnalystParameter.SemicircleLineSegment = 4;
            bufferAnalystParameter.LeftDistance = new BufferDistance() { Value = 105.2 };
            bufferAnalystParameter.RightDistance = new BufferDistance() { Value = 105.2 };

            //QueryParameter filterQueryParameter = new QueryParameter();
            //filterQueryParameter.Ids = new int[] { 1 };

            BufferResultSetting bufferResultSetting = new BufferResultSetting();
            bufferResultSetting.DataReturnOption = new DataReturnOption()
            {
                Dataset = "result",
                DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET,
                DeleteExistResultDataset = true
            };
            bufferResultSetting.IsAttributeRetained = true;

            DatasetSpatialAnalystResult result = spatialAnalyst.Buffer("Park@Changchun", bufferAnalystParameter, null, bufferResultSetting);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Succeed);
            Assert.IsTrue(result.Dataset == "result@Changchun");
            Assert.IsTrue(result.Recordset != null);
            Assert.IsTrue(result.Recordset.Features != null);
            Assert.IsTrue(result.Recordset.Features.Length == 7);
        }

        [TestMethod]
        public void Buffer_ByPointDatasetHasFilter()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-changchun/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);

            BufferAnalystParameter bufferAnalystParameter = new BufferAnalystParameter();
            bufferAnalystParameter.EndType = BufferEndType.ROUND;
            bufferAnalystParameter.SemicircleLineSegment = 4;
            bufferAnalystParameter.LeftDistance = new BufferDistance() { Value = 105.2 };
            bufferAnalystParameter.RightDistance = new BufferDistance() { Value = 105.2 };

            QueryParameter filterQueryParameter = new QueryParameter();
            filterQueryParameter.Ids = new int[] { 1 };

            BufferResultSetting bufferResultSetting = new BufferResultSetting();
            bufferResultSetting.DataReturnOption = new DataReturnOption()
            {
                Dataset = "result",
                DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET,
                DeleteExistResultDataset = true
            };
            bufferResultSetting.IsAttributeRetained = true;

            DatasetSpatialAnalystResult result = spatialAnalyst.Buffer("Park@Changchun", bufferAnalystParameter, filterQueryParameter, bufferResultSetting);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Succeed);
            Assert.IsTrue(result.Dataset == "result@Changchun");
            Assert.IsTrue(result.Recordset != null);
            Assert.IsTrue(result.Recordset.Features != null);
            Assert.IsTrue(result.Recordset.Features.Length == 1);
            Assert.IsTrue(result.Recordset.Features[0].FieldNames[9] == "NAME");
        }

        [TestMethod]
        public void Buffer_ByPointDatasetIsNotAttributeRetained()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-changchun/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);

            BufferAnalystParameter bufferAnalystParameter = new BufferAnalystParameter();
            bufferAnalystParameter.EndType = BufferEndType.ROUND;
            bufferAnalystParameter.SemicircleLineSegment = 4;
            bufferAnalystParameter.LeftDistance = new BufferDistance() { Value = 105.2 };
            bufferAnalystParameter.RightDistance = new BufferDistance() { Value = 105.2 };

            QueryParameter filterQueryParameter = new QueryParameter();
            filterQueryParameter.Ids = new int[] { 1 };

            BufferResultSetting bufferResultSetting = new BufferResultSetting();
            bufferResultSetting.DataReturnOption = new DataReturnOption()
            {
                Dataset = "result",
                DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET,
                DeleteExistResultDataset = true
            };
            bufferResultSetting.IsAttributeRetained = false;

            DatasetSpatialAnalystResult result = spatialAnalyst.Buffer("Park@Changchun", bufferAnalystParameter, filterQueryParameter, bufferResultSetting);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Succeed);
            Assert.IsTrue(result.Dataset == "result@Changchun");
            Assert.IsTrue(result.Recordset != null);
            Assert.IsTrue(result.Recordset.Features != null);
            Assert.IsTrue(result.Recordset.Features.Length == 1);
            Assert.IsTrue(result.Recordset.Features[0].FieldNames[9] != "Name");
        }

        [TestMethod]
        public void Buffer_ByPointDatasetIsUnion()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-changchun/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);

            BufferAnalystParameter bufferAnalystParameter = new BufferAnalystParameter();
            bufferAnalystParameter.EndType = BufferEndType.ROUND;
            bufferAnalystParameter.SemicircleLineSegment = 4;
            bufferAnalystParameter.LeftDistance = new BufferDistance() { Value = 105.2 };
            bufferAnalystParameter.RightDistance = new BufferDistance() { Value = 105.2 };

            BufferResultSetting bufferResultSetting = new BufferResultSetting();
            bufferResultSetting.DataReturnOption = new DataReturnOption()
            {
                Dataset = "result",
                DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET,
                DeleteExistResultDataset = true
            };
            bufferResultSetting.IsAttributeRetained = false;
            bufferResultSetting.IsUnion = true;

            DatasetSpatialAnalystResult result = spatialAnalyst.Buffer("Park@Changchun", bufferAnalystParameter, null, bufferResultSetting);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Succeed);
            Assert.IsTrue(result.Dataset == "result@Changchun");
            Assert.IsTrue(result.Recordset != null);
            Assert.IsTrue(result.Recordset.Features != null);
            Assert.IsTrue(result.Recordset.Features.Length == 1);
        }

        [TestMethod]
        public void Buffer_ByPointDatasetHasAttributeFilter()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-changchun/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);

            BufferAnalystParameter bufferAnalystParameter = new BufferAnalystParameter();
            bufferAnalystParameter.EndType = BufferEndType.ROUND;
            bufferAnalystParameter.SemicircleLineSegment = 4;
            bufferAnalystParameter.LeftDistance = new BufferDistance() { Value = 105.2 };
            bufferAnalystParameter.RightDistance = new BufferDistance() { Value = 105.2 };

            QueryParameter filterQueryParameter = new QueryParameter();
            filterQueryParameter.AttributeFilter = "smid>0 and smid<3";

            BufferResultSetting bufferResultSetting = new BufferResultSetting();
            bufferResultSetting.DataReturnOption = new DataReturnOption()
            {
                Dataset = "result",
                DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET,
                DeleteExistResultDataset = true
            };
            bufferResultSetting.IsAttributeRetained = false;
            bufferResultSetting.IsUnion = true;

            DatasetSpatialAnalystResult result = spatialAnalyst.Buffer("Park@Changchun", bufferAnalystParameter, filterQueryParameter, bufferResultSetting);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Succeed);
            Assert.IsTrue(result.Dataset == "result@Changchun");
            Assert.IsTrue(result.Recordset != null);
            Assert.IsTrue(result.Recordset.Features != null);
            Assert.IsTrue(result.Recordset.Features.Length == 1);
        }

        [TestMethod]
        public void Buffer_ByLineDataset()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-changchun/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);

            BufferAnalystParameter bufferAnalystParameter = new BufferAnalystParameter();
            bufferAnalystParameter.EndType = BufferEndType.ROUND;
            bufferAnalystParameter.SemicircleLineSegment = 4;
            bufferAnalystParameter.LeftDistance = new BufferDistance() { Value = 105.2 };
            bufferAnalystParameter.RightDistance = new BufferDistance() { Value = 105.2 };

            //QueryParameter filterQueryParameter = new QueryParameter();
            //filterQueryParameter.Ids = new int[] { 1 };

            BufferResultSetting bufferResultSetting = new BufferResultSetting();
            bufferResultSetting.DataReturnOption = new DataReturnOption()
            {
                Dataset = "resultLine",
                DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET,
                DeleteExistResultDataset = true
            };
            bufferResultSetting.IsAttributeRetained = true;

            DatasetSpatialAnalystResult result = spatialAnalyst.Buffer("Edit_Line@Changchun", bufferAnalystParameter, null, bufferResultSetting);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Succeed);
            Assert.IsTrue(result.Dataset == "resultLine@Changchun");
            Assert.IsTrue(result.Recordset != null);
            Assert.IsTrue(result.Recordset.Features != null);
            Assert.IsTrue(result.Recordset.Features.Length == 3);
        }

        [TestMethod]
        public void Buffer_ByLineDatasetRightDistanceNotEqualLeftDistance()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-changchun/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);

            BufferAnalystParameter bufferAnalystParameter = new BufferAnalystParameter();
            bufferAnalystParameter.EndType = BufferEndType.ROUND;
            bufferAnalystParameter.SemicircleLineSegment = 4;
            bufferAnalystParameter.LeftDistance = new BufferDistance() { Value = 105.2 };
            bufferAnalystParameter.RightDistance = new BufferDistance() { Value = 2 };

            BufferResultSetting bufferResultSetting = new BufferResultSetting();
            bufferResultSetting.DataReturnOption = new DataReturnOption()
            {
                Dataset = "resultLine",
                DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET,
                DeleteExistResultDataset = true
            };
            bufferResultSetting.IsAttributeRetained = true;

            try
            {
                DatasetSpatialAnalystResult result = spatialAnalyst.Buffer("Edit_Line@Changchun", bufferAnalystParameter, null, bufferResultSetting);
            }
            catch (ServiceException e)
            {
                Assert.IsTrue(true);
                Assert.IsTrue(e.Code == 400);
            }
        }

        [TestMethod]
        public void Buffer_ByLineDatasetHasAttributerFilter()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-changchun/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);

            BufferAnalystParameter bufferAnalystParameter = new BufferAnalystParameter();
            bufferAnalystParameter.EndType = BufferEndType.ROUND;
            bufferAnalystParameter.SemicircleLineSegment = 4;
            bufferAnalystParameter.LeftDistance = new BufferDistance() { Value = 105.2 };
            bufferAnalystParameter.RightDistance = new BufferDistance() { Value = 105.2 };

            QueryParameter filterQueryParameter = new QueryParameter();
            filterQueryParameter.AttributeFilter = "smid=5 or smid =1";

            BufferResultSetting bufferResultSetting = new BufferResultSetting();
            bufferResultSetting.DataReturnOption = new DataReturnOption()
            {
                Dataset = "resultLine",
                DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET,
                DeleteExistResultDataset = true
            };
            bufferResultSetting.IsAttributeRetained = true;

            DatasetSpatialAnalystResult result = spatialAnalyst.Buffer("Edit_Line@Changchun", bufferAnalystParameter, filterQueryParameter, bufferResultSetting);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Succeed);
            Assert.IsTrue(result.Dataset == "resultLine@Changchun");
            Assert.IsTrue(result.Recordset != null);
            Assert.IsTrue(result.Recordset.Features != null);
            Assert.IsTrue(result.Recordset.Features.Length == 1);
        }

        [TestMethod]
        public void Buffer_ByLineDatasetFlatBuffer()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-changchun/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);

            BufferAnalystParameter bufferAnalystParameter = new BufferAnalystParameter();
            bufferAnalystParameter.EndType = BufferEndType.FLAT;
            bufferAnalystParameter.SemicircleLineSegment = 4;
            bufferAnalystParameter.LeftDistance = new BufferDistance() { Value = 105.2 };
            bufferAnalystParameter.RightDistance = new BufferDistance() { Value = 105.2 };

            QueryParameter filterQueryParameter = new QueryParameter();
            filterQueryParameter.AttributeFilter = "smid=5 or smid =1";

            BufferResultSetting bufferResultSetting = new BufferResultSetting();
            bufferResultSetting.DataReturnOption = new DataReturnOption()
            {
                Dataset = "resultLine",
                DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET,
                DeleteExistResultDataset = true
            };
            bufferResultSetting.IsAttributeRetained = true;

            try
            {
                DatasetSpatialAnalystResult result = spatialAnalyst.Buffer("Edit_Line@Changchun", bufferAnalystParameter, filterQueryParameter, bufferResultSetting);
            }
            catch (ServiceException e)
            {
                Assert.IsTrue(true);
                Assert.IsTrue(e.Code == 400);
            }
        }

        [TestMethod]
        public void Buffer_ByPolygonDataset()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-changchun/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);

            BufferAnalystParameter bufferAnalystParameter = new BufferAnalystParameter();
            bufferAnalystParameter.EndType = BufferEndType.ROUND;
            bufferAnalystParameter.SemicircleLineSegment = 4;
            bufferAnalystParameter.LeftDistance = new BufferDistance() { Value = 1000.2 };
            bufferAnalystParameter.RightDistance = new BufferDistance() { Value = 105.2 };

            BufferResultSetting bufferResultSetting = new BufferResultSetting();
            bufferResultSetting.DataReturnOption = new DataReturnOption()
            {
                Dataset = "resultPolygon",
                DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET,
                DeleteExistResultDataset = true
            };
            bufferResultSetting.IsAttributeRetained = true;

            try
            {
                DatasetSpatialAnalystResult result = spatialAnalyst.Buffer("WaterPoly@Changchun", bufferAnalystParameter, null, bufferResultSetting);

                Assert.IsTrue(result != null);
                Assert.IsTrue(result.Succeed);
                Assert.IsTrue(result.Dataset == "resultPolygon@Changchun");
                Assert.IsTrue(result.Recordset != null);
                Assert.IsTrue(result.Recordset.Features != null);
                Assert.IsTrue(result.Recordset.Features.Length == 216);
            }
            catch (ServiceException e)
            {
                Assert.IsTrue(true);
                Assert.IsTrue(e.Code == 400);
            }
            finally
            {

            }
        }

        [TestMethod]
        public void Buffer_ByPolygonDatasetUnion()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-changchun/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);

            BufferAnalystParameter bufferAnalystParameter = new BufferAnalystParameter();
            bufferAnalystParameter.EndType = BufferEndType.ROUND;
            bufferAnalystParameter.SemicircleLineSegment = 4;
            bufferAnalystParameter.LeftDistance = new BufferDistance() { Value = 105.2 };
            bufferAnalystParameter.RightDistance = new BufferDistance() { Value = 105.2 };

            BufferResultSetting bufferResultSetting = new BufferResultSetting();
            bufferResultSetting.DataReturnOption = new DataReturnOption()
            {
                Dataset = "resultPolygon",
                DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET,
                DeleteExistResultDataset = true
            };
            bufferResultSetting.IsAttributeRetained = true;
            bufferResultSetting.IsUnion = true;
            try
            {
                DatasetSpatialAnalystResult result = spatialAnalyst.Buffer("WaterPoly@Changchun", bufferAnalystParameter, null, bufferResultSetting);

                Assert.IsTrue(result != null);
                Assert.IsTrue(result.Succeed);
                Assert.IsTrue(result.Dataset == "resultPolygon@Changchun");
                Assert.IsTrue(result.Recordset != null);
                Assert.IsTrue(result.Recordset.Features != null);
                Assert.IsTrue(result.Recordset.Features.Length == 1);
            }
            catch (ServiceException e)
            {
                Assert.IsTrue(true);
                Assert.IsTrue(e.Code == 400);
            }
            finally
            {

            }
        }
        #endregion

        #region Geometry Buffer
        [TestMethod]
        public void Buffer_ByLine()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-changchun/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);

            BufferAnalystParameter bufferAnalystParameter = new BufferAnalystParameter();
            bufferAnalystParameter.EndType = BufferEndType.ROUND;
            bufferAnalystParameter.SemicircleLineSegment = 4;
            bufferAnalystParameter.LeftDistance = new BufferDistance() { Value = 105.2 };
            bufferAnalystParameter.RightDistance = new BufferDistance() { Value = 105.2 };

            Geometry geometry = new Geometry();
            geometry.Type = GeometryType.LINE;
            Point2D point1 = new Point2D(23, 23);
            Point2D point2 = new Point2D(33, 37);
            geometry.Points = new Point2D[] { point1, point2 };
            geometry.Parts = new int[] { 2 };

            GeometrySpatialAnalystResult result = spatialAnalyst.Buffer(geometry, bufferAnalystParameter);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Succeed);
            Assert.IsTrue(result.ResultGeometry != null);
            Assert.IsTrue(result.ResultGeometry.Type == GeometryType.REGION);
            Assert.IsTrue(result.ResultGeometry.Parts != null);
            Assert.IsTrue(result.ResultGeometry.Parts[0] == 11);
        }

        [TestMethod]
        public void Buffer_ByPoint()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-changchun/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);

            BufferAnalystParameter bufferAnalystParameter = new BufferAnalystParameter();
            bufferAnalystParameter.EndType = BufferEndType.ROUND;
            bufferAnalystParameter.SemicircleLineSegment = 4;
            bufferAnalystParameter.LeftDistance = new BufferDistance() { Value = 105.2 };
            bufferAnalystParameter.RightDistance = new BufferDistance() { Value = 105.2 };

            Geometry geometry = new Geometry();
            geometry.Type = GeometryType.POINT;
            Point2D point1 = new Point2D(23, 23);
            Point2D point2 = new Point2D(33, 37);
            geometry.Points = new Point2D[] { point1 };
            geometry.Parts = new int[] { 1 };

            GeometrySpatialAnalystResult result = spatialAnalyst.Buffer(geometry, bufferAnalystParameter);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Buffer_ByRegion()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-changchun/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);

            BufferAnalystParameter bufferAnalystParameter = new BufferAnalystParameter();
            bufferAnalystParameter.EndType = BufferEndType.ROUND;
            bufferAnalystParameter.SemicircleLineSegment = 4;
            bufferAnalystParameter.LeftDistance = new BufferDistance() { Value = 2 };
            bufferAnalystParameter.RightDistance = new BufferDistance() { Value = 55557 };

            Geometry geometry = new Geometry();
            geometry.Type = GeometryType.REGION;
            Point2D point1 = new Point2D(23, 23);
            Point2D point2 = new Point2D(33, 37);
            Point2D point3 = new Point2D(33, 38);
            geometry.Points = new Point2D[] { point1, point2, point3 };
            geometry.Parts = new int[] { 3 };

            GeometrySpatialAnalystResult result = spatialAnalyst.Buffer(geometry, bufferAnalystParameter);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Succeed);
            Assert.IsTrue(result.ResultGeometry != null);
            Assert.IsTrue(result.ResultGeometry.Type == GeometryType.REGION);
            Assert.IsTrue(result.ResultGeometry.Points[0].X == 33.5380698980625);
        }

        [TestMethod]
        public void Buffer_ByRegionSegment()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-changchun/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);

            BufferAnalystParameter bufferAnalystParameter = new BufferAnalystParameter();
            bufferAnalystParameter.EndType = BufferEndType.ROUND;
            bufferAnalystParameter.SemicircleLineSegment = 12;
            bufferAnalystParameter.LeftDistance = new BufferDistance() { Value = 2 };
            bufferAnalystParameter.RightDistance = new BufferDistance() { Value = 55557 };

            Geometry geometry = new Geometry();
            geometry.Type = GeometryType.REGION;
            Point2D point1 = new Point2D(23, 23);
            Point2D point2 = new Point2D(33, 37);
            Point2D point3 = new Point2D(33, 38);
            geometry.Points = new Point2D[] { point1, point2, point3 };
            geometry.Parts = new int[] { 3 };

            GeometrySpatialAnalystResult result = spatialAnalyst.Buffer(geometry, bufferAnalystParameter);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Succeed);
            Assert.IsTrue(result.ResultGeometry != null);
            Assert.IsTrue(result.ResultGeometry.Type == GeometryType.REGION);
            Assert.IsTrue(result.ResultGeometry.Points.Length == 98);
        }
        #endregion

        #region Overlay Intersect
        [TestMethod]
        public void DatasetOverlay_Intersect()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-overlay/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);

            string sourceDataset = "Lake_R@overlay";
            string operateDataset = "Provices_Part@overlay";

            DatasetSpatialAnalystResult result = spatialAnalyst.Overlay(sourceDataset, operateDataset, OverlayOperationType.INTERSECT);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Succeed);
        }

        [TestMethod]
        public void DatasetOverlay_IntersectByCustomName()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-overlay/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);

            string sourceDataset = "Lake_R@overlay";
            string operateDataset = "Provices_Part@overlay";
            string returnDatasetName = "polygonOverlay";

            DatasetOverlayResultSetting resultSetting = new DatasetOverlayResultSetting()
            {
                DataReturnOption = new DataReturnOption()
                {
                    Dataset = returnDatasetName,
                    DeleteExistResultDataset = true,
                    DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET
                },
                Tolerance = 5,
            };

            DatasetSpatialAnalystResult result = spatialAnalyst.Overlay(sourceDataset, null, operateDataset, null, OverlayOperationType.INTERSECT, resultSetting);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Succeed);
            Assert.IsTrue(result.Dataset == returnDatasetName + "@overlay");
            Assert.IsNotNull(result.Recordset);
            Assert.IsTrue(result.Recordset.Features.Length == 61);
        }

        [TestMethod]
        public void DatasetOverlay_IntersectSourceDatasetHasFilter()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-overlay/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
            string sourceDataset = "Lake_R@overlay";
            string operateDataset = "Provices_Part@overlay";
            string returnDatasetName = "polygonOverlay";

            DatasetOverlayResultSetting resultSetting = new DatasetOverlayResultSetting()
            {
                DataReturnOption = new DataReturnOption()
                {
                    Dataset = returnDatasetName,
                    DeleteExistResultDataset = true,
                    DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET
                },
                Tolerance = 5,
            };

            QueryParameter sourceDatasetFilter = new QueryParameter()
            {
                AttributeFilter = "smid=79",
            };

            DatasetSpatialAnalystResult result = spatialAnalyst.Overlay(sourceDataset, sourceDatasetFilter, operateDataset, null, OverlayOperationType.INTERSECT, resultSetting);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Recordset.Features.Length == 1);
        }

        [TestMethod]
        public void DatasetOverlay_IntersectOperateDatasetHasFilter()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-overlay/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
            string sourceDataset = "Lake_R@overlay";
            string operateDataset = "Provices_Part@overlay";
            string returnDatasetName = "polygonOverlay";

            DatasetOverlayResultSetting resultSetting = new DatasetOverlayResultSetting()
            {
                DataReturnOption = new DataReturnOption()
                {
                    Dataset = returnDatasetName,
                    DeleteExistResultDataset = true,
                    DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET
                },
                Tolerance = 5,
            };

            QueryParameter sourceDatasetFilter = new QueryParameter()
            {
                AttributeFilter = "smid=79",
            };

            QueryParameter operateDatasetFilter = new QueryParameter()
            {
                AttributeFilter = "smid=1",
            };

            DatasetSpatialAnalystResult result = spatialAnalyst.Overlay(sourceDataset, sourceDatasetFilter, operateDataset, operateDatasetFilter, OverlayOperationType.INTERSECT, resultSetting);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Recordset.Features.Length == 0);
        }

        [TestMethod]
        public void DatasetOverlay_IntersectRegionAndPoint()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-overlay/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
            string sourceDataset = "Sdzzd_P@overlay";
            string operateDataset = "Provices_Part@overlay";
            string returnDatasetName = "RegionAndPointOverlay";

            DatasetOverlayResultSetting resultSetting = new DatasetOverlayResultSetting()
            {
                DataReturnOption = new DataReturnOption()
                {
                    Dataset = returnDatasetName,
                    DeleteExistResultDataset = true,
                    DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET
                },
                Tolerance = 5,
            };

            DatasetSpatialAnalystResult result = spatialAnalyst.Overlay(sourceDataset, null, operateDataset, null, OverlayOperationType.INTERSECT, resultSetting);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Recordset.Features.Length == 59);
        }

        [TestMethod]
        public void DatasetOverlay_IntersectRegionAndLine()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-overlay/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
            string sourceDataset = "Road_L@overlay";
            string operateDataset = "Provices_Part@overlay";
            string returnDatasetName = "RegionAndLineOverlay";

            DatasetOverlayResultSetting resultSetting = new DatasetOverlayResultSetting()
            {
                DataReturnOption = new DataReturnOption()
                {
                    Dataset = returnDatasetName,
                    DeleteExistResultDataset = true,
                    DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET
                },
                Tolerance = 5,
            };

            DatasetSpatialAnalystResult result = spatialAnalyst.Overlay(sourceDataset, null, operateDataset, null, OverlayOperationType.INTERSECT, resultSetting);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Succeed);
            Assert.IsTrue(result.Recordset.Features[0].Geometry.Type == GeometryType.LINE);
        }

        [TestMethod]
        public void DatasetOverlay_IntersectLineAndPoint()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-overlay/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
            string sourceDataset = "Sdzzd_P@overlay";
            string operateDataset = "Road_L@overlay";
            string returnDatasetName = "LineAndPointOverlay";

            DatasetOverlayResultSetting resultSetting = new DatasetOverlayResultSetting()
            {
                DataReturnOption = new DataReturnOption()
                {
                    Dataset = returnDatasetName,
                    DeleteExistResultDataset = true,
                    DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET
                },
                Tolerance = 5,
            };

            try
            {
                DatasetSpatialAnalystResult result = spatialAnalyst.Overlay(sourceDataset, null, operateDataset, null, OverlayOperationType.INTERSECT, resultSetting);

            }
            catch (ServiceException e)
            {
                Assert.IsTrue(e.Code == 400);
                Assert.IsTrue(e.Message == "错误的叠加数据集类型。");
            }
        }

        [TestMethod]
        public void DatasetAndGeometryOverlay_Intersect()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-overlay/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
            string sourceDataset = "Sdzzd_P@overlay";
            string returnDatasetName = "LineAndPointOverlay";

            Point2D point1 = new Point2D(-119275.149508913, 2797273.49481734);
            Point2D point2 = new Point2D(2205422.68158318, 2797273.49481734);
            Point2D point3 = new Point2D(2205422.68158318, 3750228.67190104);
            Point2D point4 = new Point2D(-119275.149508913, 3750228.67190104);
            Geometry region = new Geometry()
            {
                Type = GeometryType.RECTANGLE,
                Parts = new int[] { 4 },
                Points = new Point2D[] { point1, point2, point3, point4 }
            };

            Geometry[] operateRegions = new Geometry[] { region };
            DatasetSpatialAnalystResult result = spatialAnalyst.Overlay(sourceDataset, operateRegions, OverlayOperationType.INTERSECT);
            Assert.IsNotNull(result);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(result.Dataset));
        }

        [TestMethod]
        public void DatasetAndGeometryOverlay_IntersectHasSourceFilter()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-overlay/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
            string sourceDataset = "Sdzzd_P@overlay";
            string returnDatasetName = "PointAndCustomRegionOverlay";

            Point2D point1 = new Point2D(-119275.149508913, 2797273.49481734);
            Point2D point2 = new Point2D(2205422.68158318, 2797273.49481734);
            Point2D point3 = new Point2D(2205422.68158318, 3750228.67190104);
            Point2D point4 = new Point2D(-119275.149508913, 3750228.67190104);
            Geometry region = new Geometry()
            {
                Type = GeometryType.RECTANGLE,
                Parts = new int[] { 4 },
                Points = new Point2D[] { point1, point2, point3, point4 }
            };

            DatasetOverlayResultSetting resultSetting = new DatasetOverlayResultSetting()
            {
                DataReturnOption = new DataReturnOption()
                {
                    Dataset = returnDatasetName,
                    DeleteExistResultDataset = true,
                    DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET
                },
                Tolerance = 5,
            };

            QueryParameter sourceDatasetFilter = new QueryParameter()
            {
                Ids = new int[] { 159, 1272 },
            };

            Geometry[] operateRegions = new Geometry[] { region };
            DatasetSpatialAnalystResult result = spatialAnalyst.Overlay(sourceDataset, sourceDatasetFilter, operateRegions, OverlayOperationType.INTERSECT, resultSetting);
            Assert.IsNotNull(result);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(result.Dataset));
            Assert.IsTrue(result.Recordset.Features[0].Geometry.Type == GeometryType.POINT);
        }

        [TestMethod]
        public void DatasetAndGeometryOverlay_IntersectCustomRegionAndPolygon()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-overlay/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
            string sourceDataset = "Provices_Part@overlay";
            string returnDatasetName = "PolygonAndCustomRegionOverlay";

            Point2D point1 = new Point2D(-119275.149508913, 2797273.49481734);
            Point2D point2 = new Point2D(2205422.68158318, 2797273.49481734);
            Point2D point3 = new Point2D(2205422.68158318, 3750228.67190104);
            Point2D point4 = new Point2D(-119275.149508913, 3750228.67190104);
            Geometry region = new Geometry()
            {
                Type = GeometryType.RECTANGLE,
                Parts = new int[] { 4 },
                Points = new Point2D[] { point1, point2, point3, point4 }
            };

            DatasetOverlayResultSetting resultSetting = new DatasetOverlayResultSetting()
            {
                DataReturnOption = new DataReturnOption()
                {
                    Dataset = returnDatasetName,
                    DeleteExistResultDataset = true,
                    DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET
                },
                Tolerance = 5,
            };

            Geometry[] operateRegions = new Geometry[] { region };
            DatasetSpatialAnalystResult result = spatialAnalyst.Overlay(sourceDataset, null, operateRegions, OverlayOperationType.INTERSECT, resultSetting);
            Assert.IsNotNull(result);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(result.Dataset));
            Assert.IsTrue(result.Recordset.Features.Length == 4);
            Assert.IsTrue(result.Recordset.Features[0].Geometry.Type == GeometryType.REGION);
        }

        [TestMethod]
        public void DatasetAndGeometryOverlay_IntersectCustomRegionAndLine()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-overlay/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
            string sourceDataset = "Road_L@overlay";
            string returnDatasetName = "PolygonAndCustomLineOverlay";

            Point2D point1 = new Point2D(-119275.149508913, 2797273.49481734);
            Point2D point2 = new Point2D(2205422.68158318, 2797273.49481734);
            Point2D point3 = new Point2D(2205422.68158318, 3750228.67190104);
            Point2D point4 = new Point2D(-119275.149508913, 3750228.67190104);
            Geometry region = new Geometry()
            {
                Type = GeometryType.RECTANGLE,
                Parts = new int[] { 4 },
                Points = new Point2D[] { point1, point2, point3, point4 }
            };

            DatasetOverlayResultSetting resultSetting = new DatasetOverlayResultSetting()
            {
                DataReturnOption = new DataReturnOption()
                {
                    Dataset = returnDatasetName,
                    DeleteExistResultDataset = true,
                    DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET
                },
                Tolerance = 5,
            };

            Geometry[] operateRegions = new Geometry[] { region };
            DatasetSpatialAnalystResult result = spatialAnalyst.Overlay(sourceDataset, null, operateRegions, OverlayOperationType.INTERSECT, resultSetting);
            Assert.IsNotNull(result);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(result.Dataset));
            Assert.IsTrue(result.Recordset.Features.Length == 601);
            Assert.IsTrue(result.Recordset.Features[0].Geometry.Type == GeometryType.LINE);
        }

        [TestMethod]
        public void GeometryOverlay_Intersect()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-overlay/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);

            Point2D point1 = new Point2D(-119275.149508913, 2797273.49481734);
            Point2D point2 = new Point2D(2205422.68158318, 2797273.49481734);
            Point2D point3 = new Point2D(2205422.68158318, 3750228.67190104);
            Point2D point4 = new Point2D(-119275.149508913, 3750228.67190104);
            Geometry sourceGeometry = new Geometry()
            {
                Type = GeometryType.REGION,
                Parts = new int[] { 5 },
                Points = new Point2D[] { point1, point2, point3, point4, point1 }
            };


            Point2D point11 = new Point2D(106354.179627901, 3346414.71476035);
            Point2D point21 = new Point2D(2218343.65146419, 3346414.71476035);
            Point2D point31 = new Point2D(2218343.65146419, 4299369.89184406);
            Point2D point41 = new Point2D(106354.179627901, 4299369.89184406);
            Geometry operateGeometry = new Geometry()
            {
                Type = GeometryType.REGION,
                Parts = new int[] { 5 },
                Points = new Point2D[] { point11, point21, point31, point41, point11 }
            };

            GeometrySpatialAnalystResult result = spatialAnalyst.Overlay(sourceGeometry, operateGeometry, OverlayOperationType.INTERSECT);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Succeed);
            Assert.IsTrue(result.ResultGeometry != null);
            Assert.IsTrue(result.ResultGeometry.Type == GeometryType.REGION);
        }
        #endregion

        #region Overlay Clip
        [TestMethod]
        public void DatasetOverlay_ClipByCustomReturnName()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-overlay/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);

            string sourceDataset = "Lake_R@overlay";
            string operateDataset = "Provices_Part@overlay";
            string returnDatasetName = "polygonOverlay_Clip";

            DatasetOverlayResultSetting resultSetting = new DatasetOverlayResultSetting()
            {
                DataReturnOption = new DataReturnOption()
                {
                    Dataset = returnDatasetName,
                    DeleteExistResultDataset = true,
                    DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET
                },
                Tolerance = 5,
            };

            DatasetSpatialAnalystResult result = spatialAnalyst.Overlay(sourceDataset, null, operateDataset, null, OverlayOperationType.CLIP, resultSetting);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Succeed);
            Assert.IsTrue(result.Dataset == returnDatasetName + "@overlay");
            Assert.IsNotNull(result.Recordset);
            Assert.IsTrue(result.Recordset.Features.Length == 61);
        }

        [TestMethod]
        public void DatasetOverlay_ClipHasSourceFields()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-overlay/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);

            string sourceDataset = "Lake_R@overlay";
            string operateDataset = "Provices_Part@overlay";
            string returnDatasetName = "polygonOverlay_Clip";

            DatasetOverlayResultSetting resultSetting = new DatasetOverlayResultSetting()
            {
                DataReturnOption = new DataReturnOption()
                {
                    Dataset = returnDatasetName,
                    DeleteExistResultDataset = true,
                    DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET
                },
                Tolerance = 5,
                SourceDatasetFields = new string[] { "Code" }
            };

            DatasetSpatialAnalystResult result = spatialAnalyst.Overlay(sourceDataset, null, operateDataset, null, OverlayOperationType.CLIP, resultSetting);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Succeed);
            Assert.IsTrue(result.Dataset == returnDatasetName + "@overlay");
            Assert.IsNotNull(result.Recordset);
            Assert.IsTrue(result.Recordset.Features.Length == 61);
            Assert.IsTrue(result.Recordset.Fields[result.Recordset.Fields.Length - 1] == "CODE");
        }
        #endregion

        #region Overlay UNION
        [TestMethod]
        public void DatasetOverlay_Union()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-overlay/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);

            string sourceDataset = "Lake_R@overlay";
            string operateDataset = "Provices_Part@overlay";
            string returnDatasetName = "polygonOverlay_Union";

            DatasetOverlayResultSetting resultSetting = new DatasetOverlayResultSetting()
            {
                DataReturnOption = new DataReturnOption()
                {
                    Dataset = returnDatasetName,
                    DeleteExistResultDataset = true,
                    DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET
                },
                Tolerance = 5,
            };

            DatasetSpatialAnalystResult result = spatialAnalyst.Overlay(sourceDataset, null, operateDataset, null, OverlayOperationType.UNION, resultSetting);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Succeed);
            Assert.IsTrue(result.Dataset == returnDatasetName + "@overlay");
            Assert.IsNotNull(result.Recordset);
            Assert.IsTrue(result.Recordset.Features.Length == 275);
        }
        #endregion

        #region Overlay ERASE
        [TestMethod]
        public void DatasetOverlay_ERASE()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-overlay/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);

            string sourceDataset = "Lake_R@overlay";
            string operateDataset = "Provices_Part@overlay";
            string returnDatasetName = "polygonOverlay_ERASE";

            DatasetOverlayResultSetting resultSetting = new DatasetOverlayResultSetting()
            {
                DataReturnOption = new DataReturnOption()
                {
                    Dataset = returnDatasetName,
                    DeleteExistResultDataset = true,
                    DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET
                },
                Tolerance = 5,
            };

            DatasetSpatialAnalystResult result = spatialAnalyst.Overlay(sourceDataset, null, operateDataset, null, OverlayOperationType.ERASE, resultSetting);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Succeed);
            Assert.IsTrue(result.Dataset == returnDatasetName + "@overlay");
            Assert.IsNotNull(result.Recordset);
            Assert.IsTrue(result.Recordset.Features.Length == 209);
        }
        #endregion

        #region IDENTITY
        [TestMethod]
        public void DatasetOverlay_IDENTITY()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-overlay/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);

            string sourceDataset = "Provices_Part@overlay";
            string operateDataset = "Lake_R@overlay";
            string returnDatasetName = "polygonOverlay_IDENTITY";

            DatasetOverlayResultSetting resultSetting = new DatasetOverlayResultSetting()
            {
                DataReturnOption = new DataReturnOption()
                {
                    Dataset = returnDatasetName,
                    DeleteExistResultDataset = true,
                    DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET
                },
                Tolerance = 5,
            };

            DatasetSpatialAnalystResult result = spatialAnalyst.Overlay(sourceDataset, null, operateDataset, null, OverlayOperationType.IDENTITY, resultSetting);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Succeed);
            Assert.IsTrue(result.Dataset == returnDatasetName + "@overlay");
            Assert.IsNotNull(result.Recordset);
            Assert.IsTrue(result.Recordset.Features.Length == 66);
        }
        #endregion

        #region IDENTITY
        [TestMethod]
        public void DatasetOverlay_UPDATE()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-overlay/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);

            string sourceDataset = "Provices_Part@overlay";
            string operateDataset = "Lake_R@overlay";
            string returnDatasetName = "polygonOverlay_UPDATE";

            DatasetOverlayResultSetting resultSetting = new DatasetOverlayResultSetting()
            {
                DataReturnOption = new DataReturnOption()
                {
                    Dataset = returnDatasetName,
                    DeleteExistResultDataset = true,
                    DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET
                },
                Tolerance = 5,
            };

            DatasetSpatialAnalystResult result = spatialAnalyst.Overlay(sourceDataset, null, operateDataset, null, OverlayOperationType.UPDATE, resultSetting);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Succeed);
            Assert.IsTrue(result.Dataset == returnDatasetName + "@overlay");
            Assert.IsNotNull(result.Recordset);
            Assert.IsTrue(result.Recordset.Features.Length == 268);
        }
        #endregion

        #region XOR
        [TestMethod]
        public void DatasetOverlay_XOR()
        {
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-overlay/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);

            string sourceDataset = "Provices_Part@overlay";
            string operateDataset = "Lake_R@overlay";
            string returnDatasetName = "polygonOverlay_XOR";

            DatasetOverlayResultSetting resultSetting = new DatasetOverlayResultSetting()
            {
                DataReturnOption = new DataReturnOption()
                {
                    Dataset = returnDatasetName,
                    DeleteExistResultDataset = true,
                    DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET
                },
                Tolerance = 5,
            };

            DatasetSpatialAnalystResult result = spatialAnalyst.Overlay(sourceDataset, null, operateDataset, null, OverlayOperationType.XOR, resultSetting);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Succeed);
            Assert.IsTrue(result.Dataset == returnDatasetName + "@overlay");
            Assert.IsNotNull(result.Recordset);
            Assert.IsTrue(result.Recordset.Features.Length == 214);
        }
        #endregion

        #region isoregion
        ///<summary>
        /// 根据点数据集提取等值面
        ///</summary>
        [TestMethod]
        public void IsoRegion_PointDataset()
        {
            string pointDataset = "SamplesP@Interpolation";
            QueryParameter filterQueryParameter = new QueryParameter() { AttributeFilter = "SmID>0" };
            string zValueField = "AVG_WTR";
            double resolution = 3000;
            ExtractParameter parameter = new ExtractParameter() { DatumValue = 0, Interval = 500, Smoothness = 3 };
            DataReturnOption resultSetting = new DataReturnOption();
            resultSetting.DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET;
            resultSetting.DeleteExistResultDataset = true;
            resultSetting.Dataset = "isoregion@Interpolation";
            resultSetting.ExpectCount = 0;

            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-sample/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
            DatasetSpatialAnalystResult actualResult = spatialAnalyst.IsoRegion(pointDataset, filterQueryParameter, zValueField, resolution, parameter, resultSetting);
            Assert.IsTrue(actualResult.Succeed);
            Assert.AreEqual(46, actualResult.Recordset.Features.Length);
            Assert.AreEqual(11, actualResult.Recordset.Fields.Length);
            Assert.AreEqual("DMAXVALUE", actualResult.Recordset.Features[6].FieldNames[10]);
            Assert.AreEqual("1000.0", actualResult.Recordset.Features[6].FieldValues[9]);
            Assert.AreEqual("1500.0", actualResult.Recordset.Features[6].FieldValues[10]);
            Assert.AreEqual(resultSetting.Dataset, actualResult.Dataset);
        }

        ///<summary>
        /// 根据点数据集提取等值面，点数据集名称为null
        ///</summary>
        [TestMethod]
        public void IsoRegion_PointDatasetIsNull()
        {
            try
            {
                //string pointDataset = "SamplesP@Interpolation";
                QueryParameter filterQueryParameter = new QueryParameter() { AttributeFilter = "SmID>0" };
                string zValueField = "AVG_WTR";
                double resolution = 3000;
                ExtractParameter parameter = new ExtractParameter() { DatumValue = 0, Interval = 500, Smoothness = 3 };
                DataReturnOption resultSetting = new DataReturnOption();
                resultSetting.DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET;
                resultSetting.DeleteExistResultDataset = true;
                resultSetting.Dataset = "isoregion@Interpolation";
                resultSetting.ExpectCount = 0;

                string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-sample/restjsr", ip);
                SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
                DatasetSpatialAnalystResult actualResult = spatialAnalyst.IsoRegion(null, filterQueryParameter, zValueField, resolution, parameter, resultSetting);
                Assert.IsNull(actualResult);
            }
            catch (Exception e)
            {
                Assert.AreEqual("参数不能为空。\r\n参数名: pointDataset", e.Message);
            }
        }

        ///<summary>
        /// 根据点数据集提取等值面，提取等值面的参数为null
        ///</summary>
        [TestMethod]
        public void IsoRegion_PointDataset_ExtractParamtIsNull()
        {
            try
            {
                string pointDataset = "SamplesP@Interpolation";
                QueryParameter filterQueryParameter = new QueryParameter() { AttributeFilter = "SmID>0" };
                string zValueField = "AVG_WTR";
                double resolution = 3000;
                //ExtractParameter parameter = new ExtractParameter() { DatumValue = 0, Interval = 500, Smoothness = 3 };
                DataReturnOption resultSetting = new DataReturnOption();
                resultSetting.DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET;
                resultSetting.DeleteExistResultDataset = true;
                resultSetting.Dataset = "isoregion@Interpolation";
                resultSetting.ExpectCount = 0;

                string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-sample/restjsr", ip);
                SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
                DatasetSpatialAnalystResult actualResult = spatialAnalyst.IsoRegion(pointDataset, filterQueryParameter, zValueField, resolution, null, resultSetting);
                Assert.IsNull(actualResult);
            }
            catch (Exception e)
            {
                Assert.AreEqual("参数不能为空。\r\n参数名: parameter", e.Message);
            }
        }

        ///<summary>
        /// 根据点数据集提取等值面
        ///</summary>
        [TestMethod]
        public void IsoRegion_gridDataset()
        {
            string gridDataset = "JingjinTerrain@Jingjin";
            ExtractParameter parameter = new ExtractParameter() { DatumValue = 0, Interval = 1000, Smoothness = 3 };
            DataReturnOption resultSetting = new DataReturnOption();
            resultSetting.DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET;
            resultSetting.DeleteExistResultDataset = true;
            resultSetting.Dataset = "isoregion@Jingjin";
            resultSetting.ExpectCount = 0;

            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-sample/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
            DatasetSpatialAnalystResult actualResult = spatialAnalyst.IsoRegion(gridDataset, parameter, resultSetting);
            Assert.IsTrue(actualResult.Succeed);
            Assert.AreEqual(241, actualResult.Recordset.Features.Length);
            Assert.AreEqual(11, actualResult.Recordset.Fields.Length);
            Assert.AreEqual(resultSetting.Dataset, actualResult.Dataset);
        }

        ///<summary>
        /// 根据点数据集提取等值面，栅格数据集名称为null
        ///</summary>
        [TestMethod]
        public void IsoRegion_gridDatasetIsNull()
        {
            try
            {
                //string gridDataset = "JingjinTerrain@Jingjin";
                ExtractParameter parameter = new ExtractParameter() { DatumValue = 0, Interval = 1000, Smoothness = 3 };
                DataReturnOption resultSetting = new DataReturnOption();
                resultSetting.DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET;
                resultSetting.DeleteExistResultDataset = true;
                resultSetting.Dataset = "isoregion@Jingjin";
                resultSetting.ExpectCount = 0;

                string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-sample/restjsr", ip);
                SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
                DatasetSpatialAnalystResult actualResult = spatialAnalyst.IsoRegion(null, parameter, resultSetting);
                Assert.IsNull(actualResult);
            }
            catch (Exception e)
            {
                Assert.AreEqual("参数不能为空。\r\n参数名: gridDataset", e.Message);
            }
        }

        ///<summary>
        /// 根据点数据集提取等值面，ExtractParameter为null
        ///</summary>
        [TestMethod]
        public void IsoRegion_GridDataset_ExtractParamIsNull()
        {
            try
            {
                string gridDataset = "JingjinTerrain@Jingjin";
                //ExtractParameter parameter = new ExtractParameter() { DatumValue = 0, Interval = 1000, Smoothness = 3 };
                DataReturnOption resultSetting = new DataReturnOption();
                resultSetting.DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET;
                resultSetting.DeleteExistResultDataset = true;
                resultSetting.Dataset = "isoregion@Jingjin";
                resultSetting.ExpectCount = 0;

                string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-sample/restjsr", ip);
                SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
                DatasetSpatialAnalystResult actualResult = spatialAnalyst.IsoRegion(gridDataset, null, resultSetting);
                Assert.IsNull(actualResult);
            }
            catch (Exception e)
            {
                Assert.AreEqual("参数不能为空。\r\n参数名: parameter", e.Message);
            }
        }

        /// <summary>
        /// 根据点数组提取等值面
        /// </summary>
        [TestMethod]
        public void IsoRegion_Points()
        {
            #region points,zValues定义
            Point2D[] points = new Point2D[37];
            double[] zValues = new double[37];
            points[0] = new Point2D() { X = 603598.5523083061, Y = 4479242.9705482665 };
            points[1] = new Point2D() { X = 604604.99079498206, Y = 4475916.8166897586 };
            points[2] = new Point2D() { X = 605069.2609360615, Y = 4473869.0317084016 };
            points[3] = new Point2D() { X = 597849.28197854816, Y = 4473651.4819765529 };
            points[4] = new Point2D() { X = 603468.453516089, Y = 4470350.5931883259 };
            points[5] = new Point2D() { X = 602541.93949575315, Y = 4469362.1116667259 };
            points[6] = new Point2D() { X = 596899.866483911, Y = 4468956.9705482665 };
            points[7] = new Point2D() { X = 611758.72419415938, Y = 4476101.0380845685 };
            points[8] = new Point2D() { X = 617993.01585132082, Y = 4476567.4355759053 };
            points[9] = new Point2D() { X = 613072.97264934448, Y = 4472425.6988057708 };
            points[10] = new Point2D() { X = 627141.18584939465, Y = 4457193.8117718957 };
            points[11] = new Point2D() { X = 625007.69450436556, Y = 4475141.6919775512 };
            points[12] = new Point2D() { X = 614985.55448035314, Y = 4470280.1570427939 };
            points[13] = new Point2D() { X = 623901.71600422217, Y = 4466666.2160042226 };
            points[14] = new Point2D() { X = 629656.95681366918, Y = 4463716.8953833878 };
            points[15] = new Point2D() { X = 630173.95911998034, Y = 4457012.0457131462 };
            points[16] = new Point2D() { X = 633914.753754354, Y = 4455004.6871154737 };
            points[17] = new Point2D() { X = 621395.54110947042, Y = 4453979.7040218329 };
            points[18] = new Point2D() { X = 611692.43432728737, Y = 4436168.7267506663 };
            points[19] = new Point2D() { X = 616883.140989274, Y = 4429417.4819765529 };
            points[20] = new Point2D() { X = 622919.669528409, Y = 4462913.665593328 };
            points[21] = new Point2D() { X = 601313.33628629846, Y = 4455293.7974051712 };
            points[22] = new Point2D() { X = 612859.7380792771, Y = 4469688.8599254563 };
            points[23] = new Point2D() { X = 619859.663734605, Y = 4437419.6528260121 };
            points[24] = new Point2D() { X = 619986.40953671513, Y = 4446273.7524305694 };
            points[25] = new Point2D() { X = 602602.790723978, Y = 4467207.2437627846 };
            points[26] = new Point2D() { X = 601017.54226018267, Y = 4466159.2634545071 };
            points[27] = new Point2D() { X = 624837.92738216463, Y = 4470922.0728896968 };
            points[28] = new Point2D() { X = 627808.4361812321, Y = 4462623.96090279 };
            points[29] = new Point2D() { X = 601553.40045858407, Y = 4460450.558360938 };
            points[30] = new Point2D() { X = 604564.45904654567, Y = 4462898.198077416 };
            points[31] = new Point2D() { X = 617863.82231001207, Y = 4457545.3749187626 };
            points[32] = new Point2D() { X = 614289.80053016217, Y = 4449796.8294377672 };
            points[33] = new Point2D() { X = 604825.97279867844, Y = 4462217.1334855324 };
            points[34] = new Point2D() { X = 629571.82174916321, Y = 4472069.90070569 };
            points[35] = new Point2D() { X = 612746.39144627, Y = 4443343.5426283237 };
            points[36] = new Point2D() { X = 626928.06164879026, Y = 4469283.120878025 };

            zValues[0] = 52.98;
            zValues[1] = 25.74;
            zValues[2] = 62.94;
            zValues[3] = 50.82;
            zValues[4] = 41.36;
            zValues[5] = 41.66;
            zValues[6] = 64.66;
            zValues[7] = 23.7;
            zValues[8] = 40.74;
            zValues[9] = 3.12;
            zValues[10] = 139.32;
            zValues[11] = 41.48;
            zValues[12] = 28.48;
            zValues[13] = 61.92;
            zValues[14] = 52.22;
            zValues[15] = 44.54;
            zValues[16] = 56.54;
            zValues[17] = 85.22;
            zValues[18] = 48.94;
            zValues[19] = 55.2;
            zValues[20] = 52.8;
            zValues[21] = 27.5;
            zValues[22] = 39.34;
            zValues[23] = 56.22;
            zValues[24] = 39.12;
            zValues[25] = 27.72;
            zValues[26] = 34.84;
            zValues[27] = 49.26;
            zValues[28] = 55.14;
            zValues[29] = 333.26;
            zValues[30] = 42.76;
            zValues[31] = 26.42;
            zValues[32] = 54.32;
            zValues[33] = 50.88;
            zValues[34] = 56.96;
            zValues[35] = 35.2;
            zValues[36] = 49.14;
            #endregion

            double resolution = 3000;
            ExtractParameter parameter = new ExtractParameter() { DatumValue = 0, Interval = 5, Smoothness = 3 };
            DataReturnOption resultSetting = new DataReturnOption();
            resultSetting.DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET;
            resultSetting.DeleteExistResultDataset = true;
            resultSetting.Dataset = "isoregion@Interpolation";
            resultSetting.ExpectCount = 0;
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-sample/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
            DatasetSpatialAnalystResult actualResult = spatialAnalyst.IsoRegion(points, zValues, resolution, parameter, resultSetting);
            Assert.IsTrue(actualResult.Succeed);
            Assert.AreEqual(72, actualResult.Recordset.Features.Length);
            Assert.AreEqual("105.0", actualResult.Recordset.Features[25].FieldValues[9]);
            Assert.AreEqual("110.0", actualResult.Recordset.Features[25].FieldValues[10]);
        }

        /// <summary>
        /// 根据点数组提取等值面，点坐标数组为null
        /// </summary>
        [TestMethod]
        public void IsoRegion_PointsIsNull()
        {
            #region zValues定义
            double[] zValues = new double[37];
            zValues[0] = 52.98;
            zValues[1] = 25.74;
            zValues[2] = 62.94;
            zValues[3] = 50.82;
            zValues[4] = 41.36;
            zValues[5] = 41.66;
            zValues[6] = 64.66;
            zValues[7] = 23.7;
            zValues[8] = 40.74;
            zValues[9] = 3.12;
            zValues[10] = 139.32;
            zValues[11] = 41.48;
            zValues[12] = 28.48;
            zValues[13] = 61.92;
            zValues[14] = 52.22;
            zValues[15] = 44.54;
            zValues[16] = 56.54;
            zValues[17] = 85.22;
            zValues[18] = 48.94;
            zValues[19] = 55.2;
            zValues[20] = 52.8;
            zValues[21] = 27.5;
            zValues[22] = 39.34;
            zValues[23] = 56.22;
            zValues[24] = 39.12;
            zValues[25] = 27.72;
            zValues[26] = 34.84;
            zValues[27] = 49.26;
            zValues[28] = 55.14;
            zValues[29] = 333.26;
            zValues[30] = 42.76;
            zValues[31] = 26.42;
            zValues[32] = 54.32;
            zValues[33] = 50.88;
            zValues[34] = 56.96;
            zValues[35] = 35.2;
            zValues[36] = 49.14;
            #endregion

            try
            {
                double resolution = 3000;
                ExtractParameter parameter = new ExtractParameter() { DatumValue = 0, Interval = 5, Smoothness = 3 };
                DataReturnOption resultSetting = new DataReturnOption();
                resultSetting.DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET;
                resultSetting.DeleteExistResultDataset = true;
                resultSetting.Dataset = "isoregion@Interpolation";
                resultSetting.ExpectCount = 0;
                string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-sample/restjsr", ip);
                SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
                DatasetSpatialAnalystResult actualResult = spatialAnalyst.IsoRegion(null, zValues, resolution, parameter, resultSetting);
                Assert.IsTrue(actualResult.Succeed);
            }
            catch (Exception e)
            {
                Assert.AreEqual("点数组为null。", e.Message);
            }
        }

        /// <summary>
        /// 根据点数组提取等值面，zValues为null
        /// </summary>
        [TestMethod]
        public void IsoRegion_ZValuesIsNull()
        {
            #region points定义
            Point2D[] points = new Point2D[37];
            points[0] = new Point2D() { X = 603598.5523083061, Y = 4479242.9705482665 };
            points[1] = new Point2D() { X = 604604.99079498206, Y = 4475916.8166897586 };
            points[2] = new Point2D() { X = 605069.2609360615, Y = 4473869.0317084016 };
            points[3] = new Point2D() { X = 597849.28197854816, Y = 4473651.4819765529 };
            points[4] = new Point2D() { X = 603468.453516089, Y = 4470350.5931883259 };
            points[5] = new Point2D() { X = 602541.93949575315, Y = 4469362.1116667259 };
            points[6] = new Point2D() { X = 596899.866483911, Y = 4468956.9705482665 };
            points[7] = new Point2D() { X = 611758.72419415938, Y = 4476101.0380845685 };
            points[8] = new Point2D() { X = 617993.01585132082, Y = 4476567.4355759053 };
            points[9] = new Point2D() { X = 613072.97264934448, Y = 4472425.6988057708 };
            points[10] = new Point2D() { X = 627141.18584939465, Y = 4457193.8117718957 };
            points[11] = new Point2D() { X = 625007.69450436556, Y = 4475141.6919775512 };
            points[12] = new Point2D() { X = 614985.55448035314, Y = 4470280.1570427939 };
            points[13] = new Point2D() { X = 623901.71600422217, Y = 4466666.2160042226 };
            points[14] = new Point2D() { X = 629656.95681366918, Y = 4463716.8953833878 };
            points[15] = new Point2D() { X = 630173.95911998034, Y = 4457012.0457131462 };
            points[16] = new Point2D() { X = 633914.753754354, Y = 4455004.6871154737 };
            points[17] = new Point2D() { X = 621395.54110947042, Y = 4453979.7040218329 };
            points[18] = new Point2D() { X = 611692.43432728737, Y = 4436168.7267506663 };
            points[19] = new Point2D() { X = 616883.140989274, Y = 4429417.4819765529 };
            points[20] = new Point2D() { X = 622919.669528409, Y = 4462913.665593328 };
            points[21] = new Point2D() { X = 601313.33628629846, Y = 4455293.7974051712 };
            points[22] = new Point2D() { X = 612859.7380792771, Y = 4469688.8599254563 };
            points[23] = new Point2D() { X = 619859.663734605, Y = 4437419.6528260121 };
            points[24] = new Point2D() { X = 619986.40953671513, Y = 4446273.7524305694 };
            points[25] = new Point2D() { X = 602602.790723978, Y = 4467207.2437627846 };
            points[26] = new Point2D() { X = 601017.54226018267, Y = 4466159.2634545071 };
            points[27] = new Point2D() { X = 624837.92738216463, Y = 4470922.0728896968 };
            points[28] = new Point2D() { X = 627808.4361812321, Y = 4462623.96090279 };
            points[29] = new Point2D() { X = 601553.40045858407, Y = 4460450.558360938 };
            points[30] = new Point2D() { X = 604564.45904654567, Y = 4462898.198077416 };
            points[31] = new Point2D() { X = 617863.82231001207, Y = 4457545.3749187626 };
            points[32] = new Point2D() { X = 614289.80053016217, Y = 4449796.8294377672 };
            points[33] = new Point2D() { X = 604825.97279867844, Y = 4462217.1334855324 };
            points[34] = new Point2D() { X = 629571.82174916321, Y = 4472069.90070569 };
            points[35] = new Point2D() { X = 612746.39144627, Y = 4443343.5426283237 };
            points[36] = new Point2D() { X = 626928.06164879026, Y = 4469283.120878025 };

            #endregion

            try
            {
                double resolution = 3000;
                ExtractParameter parameter = new ExtractParameter() { DatumValue = 0, Interval = 5, Smoothness = 3 };
                DataReturnOption resultSetting = new DataReturnOption();
                resultSetting.DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET;
                resultSetting.DeleteExistResultDataset = true;
                resultSetting.Dataset = "isoregion@Interpolation";
                resultSetting.ExpectCount = 0;
                string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-sample/restjsr", ip);
                SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
                DatasetSpatialAnalystResult actualResult = spatialAnalyst.IsoRegion(points, null, resolution, parameter, resultSetting);
                Assert.IsTrue(actualResult.Succeed);
            }
            catch (Exception e)
            {
                Assert.AreEqual("第三维值数组为null。", e.Message);
            }
        }

        /// <summary>
        /// 根据点数组提取等值面，ExtractParameter为null
        /// </summary>
        [TestMethod]
        public void IsoRegion_Points_ExtractParamIsNull()
        {
            #region points,zValues定义
            Point2D[] points = new Point2D[37];
            double[] zValues = new double[37];
            points[0] = new Point2D() { X = 603598.5523083061, Y = 4479242.9705482665 };
            points[1] = new Point2D() { X = 604604.99079498206, Y = 4475916.8166897586 };
            points[2] = new Point2D() { X = 605069.2609360615, Y = 4473869.0317084016 };
            points[3] = new Point2D() { X = 597849.28197854816, Y = 4473651.4819765529 };
            points[4] = new Point2D() { X = 603468.453516089, Y = 4470350.5931883259 };
            points[5] = new Point2D() { X = 602541.93949575315, Y = 4469362.1116667259 };
            points[6] = new Point2D() { X = 596899.866483911, Y = 4468956.9705482665 };
            points[7] = new Point2D() { X = 611758.72419415938, Y = 4476101.0380845685 };
            points[8] = new Point2D() { X = 617993.01585132082, Y = 4476567.4355759053 };
            points[9] = new Point2D() { X = 613072.97264934448, Y = 4472425.6988057708 };
            points[10] = new Point2D() { X = 627141.18584939465, Y = 4457193.8117718957 };
            points[11] = new Point2D() { X = 625007.69450436556, Y = 4475141.6919775512 };
            points[12] = new Point2D() { X = 614985.55448035314, Y = 4470280.1570427939 };
            points[13] = new Point2D() { X = 623901.71600422217, Y = 4466666.2160042226 };
            points[14] = new Point2D() { X = 629656.95681366918, Y = 4463716.8953833878 };
            points[15] = new Point2D() { X = 630173.95911998034, Y = 4457012.0457131462 };
            points[16] = new Point2D() { X = 633914.753754354, Y = 4455004.6871154737 };
            points[17] = new Point2D() { X = 621395.54110947042, Y = 4453979.7040218329 };
            points[18] = new Point2D() { X = 611692.43432728737, Y = 4436168.7267506663 };
            points[19] = new Point2D() { X = 616883.140989274, Y = 4429417.4819765529 };
            points[20] = new Point2D() { X = 622919.669528409, Y = 4462913.665593328 };
            points[21] = new Point2D() { X = 601313.33628629846, Y = 4455293.7974051712 };
            points[22] = new Point2D() { X = 612859.7380792771, Y = 4469688.8599254563 };
            points[23] = new Point2D() { X = 619859.663734605, Y = 4437419.6528260121 };
            points[24] = new Point2D() { X = 619986.40953671513, Y = 4446273.7524305694 };
            points[25] = new Point2D() { X = 602602.790723978, Y = 4467207.2437627846 };
            points[26] = new Point2D() { X = 601017.54226018267, Y = 4466159.2634545071 };
            points[27] = new Point2D() { X = 624837.92738216463, Y = 4470922.0728896968 };
            points[28] = new Point2D() { X = 627808.4361812321, Y = 4462623.96090279 };
            points[29] = new Point2D() { X = 601553.40045858407, Y = 4460450.558360938 };
            points[30] = new Point2D() { X = 604564.45904654567, Y = 4462898.198077416 };
            points[31] = new Point2D() { X = 617863.82231001207, Y = 4457545.3749187626 };
            points[32] = new Point2D() { X = 614289.80053016217, Y = 4449796.8294377672 };
            points[33] = new Point2D() { X = 604825.97279867844, Y = 4462217.1334855324 };
            points[34] = new Point2D() { X = 629571.82174916321, Y = 4472069.90070569 };
            points[35] = new Point2D() { X = 612746.39144627, Y = 4443343.5426283237 };
            points[36] = new Point2D() { X = 626928.06164879026, Y = 4469283.120878025 };

            zValues[0] = 52.98;
            zValues[1] = 25.74;
            zValues[2] = 62.94;
            zValues[3] = 50.82;
            zValues[4] = 41.36;
            zValues[5] = 41.66;
            zValues[6] = 64.66;
            zValues[7] = 23.7;
            zValues[8] = 40.74;
            zValues[9] = 3.12;
            zValues[10] = 139.32;
            zValues[11] = 41.48;
            zValues[12] = 28.48;
            zValues[13] = 61.92;
            zValues[14] = 52.22;
            zValues[15] = 44.54;
            zValues[16] = 56.54;
            zValues[17] = 85.22;
            zValues[18] = 48.94;
            zValues[19] = 55.2;
            zValues[20] = 52.8;
            zValues[21] = 27.5;
            zValues[22] = 39.34;
            zValues[23] = 56.22;
            zValues[24] = 39.12;
            zValues[25] = 27.72;
            zValues[26] = 34.84;
            zValues[27] = 49.26;
            zValues[28] = 55.14;
            zValues[29] = 333.26;
            zValues[30] = 42.76;
            zValues[31] = 26.42;
            zValues[32] = 54.32;
            zValues[33] = 50.88;
            zValues[34] = 56.96;
            zValues[35] = 35.2;
            zValues[36] = 49.14;
            #endregion

            try
            {
                double resolution = 3000;
                //ExtractParameter parameter = new ExtractParameter() { DatumValue = 0, Interval = 5, Smoothness = 3 };
                DataReturnOption resultSetting = new DataReturnOption();
                resultSetting.DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET;
                resultSetting.DeleteExistResultDataset = true;
                resultSetting.Dataset = "isoregion@Interpolation";
                resultSetting.ExpectCount = 0;
                string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-sample/restjsr", ip);
                SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
                DatasetSpatialAnalystResult actualResult = spatialAnalyst.IsoRegion(points, zValues, resolution, null, resultSetting);
                Assert.IsTrue(actualResult.Succeed);
            }
            catch (Exception e)
            {
                Assert.AreEqual("参数不能为空。\r\n参数名: parameter", e.Message);
            }
        }
        #endregion

        #region interpolate
        ///<summary>
        /// 反距离加权插值（Inverse Distance Weighted ，IDW）
        ///</summary>
        [TestMethod]
        public void Interpolate_IDW()
        {
            string pointDataset = "SamplesP@Interpolation";
            InterpolationIDWParameter param = new InterpolationIDWParameter();
            param.Power = 2;
            param.SearchMode = SearchMode.KDTREE_FIXED_RADIUS;
            param.PixelFormat = PixelFormat.BIT16;
            param.ZValueFieldName = "AVG_TMP";
            param.ZValueScale = 1;
            param.Resolution = 3000;
            param.OutputDatasetName = "interpolateIDW";
            param.OutputDatasourceName = "Interpolation";
            param.SearchRadius = 0;

            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-sample/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
            DatasetSpatialAnalystResult actualResult = spatialAnalyst.Interpolate(pointDataset, param);
            Assert.IsTrue(actualResult.Succeed);

            //查询生成的栅格数据集信息
            string[] names = actualResult.Dataset.Split(new char[1] { '@' }, 3);
            string[] datasetNames = new string[1] { names[1] + ":" + names[0] };
            DatasetGridInfo datainfo = (DatasetGridInfo)spatialAnalyst.GetDatasetInfo(names[1], names[0]);
            Assert.AreEqual(DatasetType.GRID, datainfo.Type);
            Assert.AreEqual(PixelFormat.BIT16, datainfo.PixelFormat);
            //删除生成的栅格数据集
            string dataUrl = string.Format("http://{0}:8090/iserver/services/data-sample/rest", ip);
            Data data = new Data(dataUrl);
            bool deleteResult = data.DeleteDataset(names[1], names[0]);
            Assert.IsTrue(deleteResult);
        }

        ///<summary>
        /// 点密度插值分析
        ///</summary>
        [TestMethod]
        public void Interpolate_Density()
        {
            string pointDataset = "SamplesP@Interpolation";
            InterpolationDensityParameter param = new InterpolationDensityParameter();
            param.PixelFormat = PixelFormat.BIT16;
            param.ZValueFieldName = "AVG_TMP";
            param.ZValueScale = 1;
            param.Resolution = 3000;
            param.OutputDatasetName = "interpolateDensity";
            param.OutputDatasourceName = "Interpolation";
            param.SearchRadius = 0;

            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-sample/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
            DatasetSpatialAnalystResult actualResult = spatialAnalyst.Interpolate(pointDataset, param);
            Assert.IsTrue(actualResult.Succeed);

            //查询生成的栅格数据集信息
            string[] names = actualResult.Dataset.Split(new char[1] { '@' }, 3);
            string[] datasetNames = new string[1] { names[1] + ":" + names[0] };
            DatasetGridInfo datainfo = (DatasetGridInfo)spatialAnalyst.GetDatasetInfo(names[1], names[0]);
            Assert.AreEqual(DatasetType.GRID, datainfo.Type);
            Assert.AreEqual(PixelFormat.BIT16, datainfo.PixelFormat);
            //删除生成的栅格数据集
            string dataUrl = string.Format("http://{0}:8090/iserver/services/data-sample/rest", ip);
            Data data = new Data(dataUrl);
            bool deleteResult = data.DeleteDataset(names[1], names[0]);
            Assert.IsTrue(deleteResult);
        }

        ///<summary>
        /// 径向基函数插值法
        ///</summary>
        [TestMethod]
        public void Interpolate_RBF()
        {
            string pointDataset = "SamplesP@Interpolation";
            InterpolationRBFParameter param = new InterpolationRBFParameter();
            param.PixelFormat = PixelFormat.BIT16;
            param.ZValueFieldName = "AVG_TMP";
            param.ZValueScale = 1;
            param.Resolution = 3000;
            param.OutputDatasetName = "interpolateRbf";
            param.OutputDatasourceName = "Interpolation";
            param.SearchRadius = 0;
            param.Smooth = 0.1;
            param.Tension = 40;
            param.SearchMode = SearchMode.QUADTREE;
            param.MaxPointCountForInterpolation = 20;
            param.MaxPointCountInNode = 5;

            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-sample/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
            DatasetSpatialAnalystResult actualResult = spatialAnalyst.Interpolate(pointDataset, param);
            Assert.IsTrue(actualResult.Succeed);

            //查询生成的栅格数据集信息
            string[] names = actualResult.Dataset.Split(new char[1] { '@' }, 3);
            string[] datasetNames = new string[1] { names[1] + ":" + names[0] };
            DatasetGridInfo datainfo = (DatasetGridInfo)spatialAnalyst.GetDatasetInfo(names[1], names[0]);
            Assert.AreEqual(DatasetType.GRID, datainfo.Type);
            Assert.AreEqual(PixelFormat.BIT16, datainfo.PixelFormat);
            //删除生成的栅格数据集
            string dataUrl = string.Format("http://{0}:8090/iserver/services/data-sample/rest", ip);
            Data data = new Data(dataUrl);
            bool deleteResult = data.DeleteDataset(names[1], names[0]);
            Assert.IsTrue(deleteResult);
        }

        ///<summary>
        /// 克吕金插值分析
        ///</summary>
        [TestMethod]
        public void Interpolate_Kriging()
        {
            string pointDataset = "SamplesP@Interpolation";
            InterpolationKrigingParameter param = new InterpolationKrigingParameter();
            param.PixelFormat = PixelFormat.BIT16;
            param.ZValueFieldName = "AVG_TMP";
            param.ZValueScale = 1;
            param.Resolution = 3000;
            param.OutputDatasetName = "interpolateKriging";
            param.OutputDatasourceName = "Interpolation";
            param.SearchRadius = 0;
            param.Angle = 0;
            param.Nugget = 0;
            param.Range = 0;
            param.Sill = 0;
            param.VariogramMode = VariogramMode.SPHERICAL;
            param.SearchMode = SearchMode.KDTREE_FIXED_RADIUS;
            param.SearchRadius = 0;
            param.Type = KrigingAlgorithmType.KRIGING;

            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-sample/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
            DatasetSpatialAnalystResult actualResult = spatialAnalyst.Interpolate(pointDataset, param);
            Assert.IsTrue(actualResult.Succeed);

            //查询生成的栅格数据集信息
            string[] names = actualResult.Dataset.Split(new char[1] { '@' }, 3);
            string[] datasetNames = new string[1] { names[1] + ":" + names[0] };
            DatasetGridInfo datainfo = (DatasetGridInfo)spatialAnalyst.GetDatasetInfo(names[1], names[0]);
            Assert.AreEqual(DatasetType.GRID, datainfo.Type);
            Assert.AreEqual(PixelFormat.BIT16, datainfo.PixelFormat);
            //删除生成的栅格数据集
            string dataUrl = string.Format("http://{0}:8090/iserver/services/data-sample/rest", ip);
            Data data = new Data(dataUrl);
            bool deleteResult = data.DeleteDataset(names[1], names[0]);
            Assert.IsTrue(deleteResult);
        }

        ///<summary>
        /// 简单克吕金插值法
        ///</summary>
        [TestMethod]
        public void Interpolate_SimpleKriging()
        {
            string pointDataset = "SamplesP@Interpolation";
            InterpolationKrigingParameter param = new InterpolationKrigingParameter();
            param.PixelFormat = PixelFormat.BIT16;
            param.ZValueFieldName = "AVG_TMP";
            param.ZValueScale = 1;
            param.Resolution = 3000;
            param.OutputDatasetName = "interpolateSimpleKriging";
            param.OutputDatasourceName = "Interpolation";
            param.SearchRadius = 0;
            param.Angle = 0;
            param.Nugget = 0;
            param.Range = 0;
            param.Sill = 0;
            param.VariogramMode = VariogramMode.SPHERICAL;
            param.SearchMode = SearchMode.KDTREE_FIXED_RADIUS;
            param.SearchRadius = 0;
            param.Mean = 11.6005;//简单克吕金插值法参数
            param.Type = KrigingAlgorithmType.SimpleKriging;

            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-sample/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
            DatasetSpatialAnalystResult actualResult = spatialAnalyst.Interpolate(pointDataset, param);
            Assert.IsTrue(actualResult.Succeed);

            //查询生成的栅格数据集信息
            string[] names = actualResult.Dataset.Split(new char[1] { '@' }, 3);
            string[] datasetNames = new string[1] { names[1] + ":" + names[0] };
            DatasetGridInfo datainfo = (DatasetGridInfo)spatialAnalyst.GetDatasetInfo(names[1], names[0]);
            Assert.AreEqual(DatasetType.GRID, datainfo.Type);
            Assert.AreEqual(PixelFormat.BIT16, datainfo.PixelFormat);
            //删除生成的栅格数据集
            string dataUrl = string.Format("http://{0}:8090/iserver/services/data-sample/rest", ip);
            Data data = new Data(dataUrl);
            bool deleteResult = data.DeleteDataset(names[1], names[0]);
            Assert.IsTrue(deleteResult);
        }

        ///<summary>
        /// 泛克吕金插值法
        ///</summary>
        [TestMethod]
        public void Interpolate_UniversalKriging()
        {
            string pointDataset = "SamplesP@Interpolation";
            InterpolationKrigingParameter param = new InterpolationKrigingParameter();
            param.PixelFormat = PixelFormat.BIT16;
            param.ZValueFieldName = "AVG_TMP";
            param.ZValueScale = 1;
            param.Resolution = 3000;
            param.OutputDatasetName = "interpolateUniversalKriging";
            param.OutputDatasourceName = "Interpolation";
            param.SearchRadius = 0;
            param.Angle = 0;
            param.Nugget = 0;
            param.Range = 0;
            param.Sill = 0;
            param.VariogramMode = VariogramMode.SPHERICAL;
            param.SearchMode = SearchMode.KDTREE_FIXED_RADIUS;
            param.SearchRadius = 0;
            param.Exponent = Exponent.EXP1;//泛克吕金插值法参数
            param.Type = KrigingAlgorithmType.UniversalKriging;

            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-sample/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
            DatasetSpatialAnalystResult actualResult = spatialAnalyst.Interpolate(pointDataset, param);
            Assert.IsTrue(actualResult.Succeed);

            //查询生成的栅格数据集信息
            string[] names = actualResult.Dataset.Split(new char[1] { '@' }, 3);
            string[] datasetNames = new string[1] { names[1] + ":" + names[0] };
            DatasetGridInfo datainfo = (DatasetGridInfo)spatialAnalyst.GetDatasetInfo(names[1], names[0]);
            Assert.AreEqual(DatasetType.GRID, datainfo.Type);
            Assert.AreEqual(PixelFormat.BIT16, datainfo.PixelFormat);
            //删除生成的栅格数据集
            string dataUrl = string.Format("http://{0}:8090/iserver/services/data-sample/rest", ip);
            Data data = new Data(dataUrl);
            bool deleteResult = data.DeleteDataset(names[1], names[0]);
            Assert.IsTrue(deleteResult);
        }

        ///<summary>
        /// 插值参数为null
        ///</summary>
        [TestMethod]
        public void Interpolate_InterpoParamIsNull()
        {
            try
            {
                string pointDataset = "SamplesP@Interpolation";
                string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-sample/restjsr", ip);
                SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
                DatasetSpatialAnalystResult actualResult = spatialAnalyst.Interpolate(pointDataset, null);
                Assert.IsTrue(actualResult.Succeed);
            }
            catch (Exception e)
            {
                Assert.AreEqual("参数不能为空。\r\n参数名: parameter", e.Message);
            }
        }

        ///<summary>
        /// 点数据集名为null
        ///</summary>
        [TestMethod]
        public void Interpolate_PointDatasetIsNull()
        {
            try
            {
                InterpolationKrigingParameter param = new InterpolationKrigingParameter();
                param.PixelFormat = PixelFormat.BIT16;
                param.ZValueFieldName = "AVG_TMP";
                param.ZValueScale = 1;
                param.Resolution = 3000;
                param.OutputDatasetName = "interpolateUniversalKriging";
                param.OutputDatasourceName = "Interpolation";
                param.SearchRadius = 0;
                param.Angle = 0;
                param.Nugget = 0;
                param.Range = 0;
                param.Sill = 0;
                param.VariogramMode = VariogramMode.SPHERICAL;
                param.SearchMode = SearchMode.KDTREE_FIXED_RADIUS;
                param.SearchRadius = 0;
                param.Exponent = Exponent.EXP1;//泛克吕金插值法参数
                param.Type = KrigingAlgorithmType.UniversalKriging;

                string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-sample/restjsr", ip);
                SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
                DatasetSpatialAnalystResult actualResult = spatialAnalyst.Interpolate(null, param);
                Assert.IsTrue(actualResult.Succeed);
            }
            catch (Exception e)
            {
                Assert.AreEqual("参数不能为空。\r\n参数名: pointDataset", e.Message);
            }
        }

        ///<summary>
        /// 泛克吕金插值法
        ///</summary>
        [TestMethod]
        public void Interpolate_PointDatasetError()
        {
            try
            {
                string pointDataset = "SamplesP99@Interpolation";
                InterpolationKrigingParameter param = new InterpolationKrigingParameter();
                param.PixelFormat = PixelFormat.BIT16;
                param.ZValueFieldName = "AVG_TMP";
                param.ZValueScale = 1;
                param.Resolution = 3000;
                param.OutputDatasetName = "interpolateUniversalKriging";
                param.OutputDatasourceName = "Interpolation";
                param.SearchRadius = 0;
                param.Angle = 0;
                param.Nugget = 0;
                param.Range = 0;
                param.Sill = 0;
                param.VariogramMode = VariogramMode.SPHERICAL;
                param.SearchMode = SearchMode.KDTREE_FIXED_RADIUS;
                param.SearchRadius = 0;
                param.Exponent = Exponent.EXP1;//泛克吕金插值法参数
                param.Type = KrigingAlgorithmType.UniversalKriging;

                string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-sample/restjsr", ip);
                SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
                DatasetSpatialAnalystResult actualResult = spatialAnalyst.Interpolate(pointDataset, param);
                Assert.IsTrue(actualResult.Succeed);
            }
            catch (Exception e)
            {
                Assert.AreEqual("数据集SamplesP99@Interpolation不存在", e.Message);
            }
        }

        #endregion


        #region isoline
        ///<summary>
        /// 根据点数据集提取等值线
        ///</summary>
        [TestMethod]
        public void IsoLine_PointDataset()
        {
            string pointDataset = "SamplesP@Interpolation";
            QueryParameter filterQueryParameter = new QueryParameter() { AttributeFilter = "SmID>0" };
            string zValueField = "AVG_WTR";
            double resolution = 3000;
            ExtractParameter parameter = new ExtractParameter() { DatumValue = 0, Interval = 500, Smoothness = 3 };
            DataReturnOption resultSetting = new DataReturnOption();
            resultSetting.DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET;
            resultSetting.DeleteExistResultDataset = true;
            resultSetting.Dataset = "isoLine@Interpolation";
            resultSetting.ExpectCount = 0;

            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-sample/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
            DatasetSpatialAnalystResult actualResult = spatialAnalyst.IsoLine(pointDataset, filterQueryParameter, zValueField, resolution, parameter, resultSetting);
            Assert.IsTrue(actualResult.Succeed);
            Assert.AreEqual(45, actualResult.Recordset.Features.Length);
            Assert.AreEqual(10, actualResult.Recordset.Fields.Length);
            Assert.AreEqual("DZVALUE", actualResult.Recordset.Features[6].FieldNames[9]);
            Assert.AreEqual("1000.0", actualResult.Recordset.Features[6].FieldValues[9]);
            Assert.AreEqual(resultSetting.Dataset, actualResult.Dataset);
        }

        ///<summary>
        /// 根据点数据集提取等值线，点数据集名称为null
        ///</summary>
        [TestMethod]
        public void IsoLine_PointDatasetIsNull()
        {
            try
            {
                //string pointDataset = "SamplesP@Interpolation";
                QueryParameter filterQueryParameter = new QueryParameter() { AttributeFilter = "SmID>0" };
                string zValueField = "AVG_WTR";
                double resolution = 3000;
                ExtractParameter parameter = new ExtractParameter() { DatumValue = 0, Interval = 500, Smoothness = 3 };
                DataReturnOption resultSetting = new DataReturnOption();
                resultSetting.DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET;
                resultSetting.DeleteExistResultDataset = true;
                resultSetting.Dataset = "isoLine@Interpolation";
                resultSetting.ExpectCount = 0;

                string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-sample/restjsr", ip);
                SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
                DatasetSpatialAnalystResult actualResult = spatialAnalyst.IsoLine(null, filterQueryParameter, zValueField, resolution, parameter, resultSetting);
                Assert.IsNull(actualResult);
            }
            catch (Exception e)
            {
                Assert.AreEqual("参数不能为空。\r\n参数名: pointDataset", e.Message);
            }
        }

        ///<summary>
        /// 根据点数据集提取等值线，提取等值面的参数为null
        ///</summary>
        [TestMethod]
        public void IsoLine_PointDataset_ExtractParamtIsNull()
        {
            try
            {
                string pointDataset = "SamplesP@Interpolation";
                QueryParameter filterQueryParameter = new QueryParameter() { AttributeFilter = "SmID>0" };
                string zValueField = "AVG_WTR";
                double resolution = 3000;
                //ExtractParameter parameter = new ExtractParameter() { DatumValue = 0, Interval = 500, Smoothness = 3 };
                DataReturnOption resultSetting = new DataReturnOption();
                resultSetting.DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET;
                resultSetting.DeleteExistResultDataset = true;
                resultSetting.Dataset = "isoLine@Interpolation";
                resultSetting.ExpectCount = 0;

                string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-sample/restjsr", ip);
                SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
                DatasetSpatialAnalystResult actualResult = spatialAnalyst.IsoLine(pointDataset, filterQueryParameter, zValueField, resolution, null, resultSetting);
                Assert.IsNull(actualResult);
            }
            catch (Exception e)
            {
                Assert.AreEqual("参数不能为空。\r\n参数名: parameter", e.Message);
            }
        }

        ///<summary>
        /// 根据点数据集提取等值线
        ///</summary>
        [TestMethod]
        public void IsoLine_gridDataset()
        {
            string gridDataset = "JingjinTerrain@Jingjin";
            ExtractParameter parameter = new ExtractParameter() { DatumValue = 0, Interval = 1000, Smoothness = 3 };
            DataReturnOption resultSetting = new DataReturnOption();
            resultSetting.DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET;
            resultSetting.DeleteExistResultDataset = true;
            resultSetting.Dataset = "isoLine@Jingjin";
            resultSetting.ExpectCount = 0;

            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-sample/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
            DatasetSpatialAnalystResult actualResult = spatialAnalyst.IsoLine(gridDataset, parameter, resultSetting);
            Assert.IsTrue(actualResult.Succeed);
            Assert.AreEqual(229, actualResult.Recordset.Features.Length);
            Assert.AreEqual(10, actualResult.Recordset.Fields.Length);
            Assert.AreEqual(resultSetting.Dataset, actualResult.Dataset);
        }

        ///<summary>
        /// 根据点数据集提取等值线，栅格数据集名称为null
        ///</summary>
        [TestMethod]
        public void IsoLine_gridDatasetIsNull()
        {
            try
            {
                //string gridDataset = "JingjinTerrain@Jingjin";
                ExtractParameter parameter = new ExtractParameter() { DatumValue = 0, Interval = 1000, Smoothness = 3 };
                DataReturnOption resultSetting = new DataReturnOption();
                resultSetting.DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET;
                resultSetting.DeleteExistResultDataset = true;
                resultSetting.Dataset = "isoLine@Jingjin";
                resultSetting.ExpectCount = 0;

                string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-sample/restjsr", ip);
                SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
                DatasetSpatialAnalystResult actualResult = spatialAnalyst.IsoLine(null, parameter, resultSetting);
                Assert.IsNull(actualResult);
            }
            catch (Exception e)
            {
                Assert.AreEqual("参数不能为空。\r\n参数名: gridDataset", e.Message);
            }
        }

        ///<summary>
        /// 根据点数据集提取等值线，ExtractParameter为null
        ///</summary>
        [TestMethod]
        public void IsoLine_GridDataset_ExtractParamIsNull()
        {
            try
            {
                string gridDataset = "JingjinTerrain@Jingjin";
                //ExtractParameter parameter = new ExtractParameter() { DatumValue = 0, Interval = 1000, Smoothness = 3 };
                DataReturnOption resultSetting = new DataReturnOption();
                resultSetting.DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET;
                resultSetting.DeleteExistResultDataset = true;
                resultSetting.Dataset = "isoLine@Jingjin";
                resultSetting.ExpectCount = 0;

                string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-sample/restjsr", ip);
                SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
                DatasetSpatialAnalystResult actualResult = spatialAnalyst.IsoLine(gridDataset, null, resultSetting);
                Assert.IsNull(actualResult);
            }
            catch (Exception e)
            {
                Assert.AreEqual("参数不能为空。\r\n参数名: parameter", e.Message);
            }
        }

        /// <summary>
        /// 根据点数组提取等值线
        /// </summary>
        [TestMethod]
        public void IsoLine_Points()
        {
            #region points,zValues定义
            Point2D[] points = new Point2D[37];
            double[] zValues = new double[37];
            points[0] = new Point2D() { X = 603598.5523083061, Y = 4479242.9705482665 };
            points[1] = new Point2D() { X = 604604.99079498206, Y = 4475916.8166897586 };
            points[2] = new Point2D() { X = 605069.2609360615, Y = 4473869.0317084016 };
            points[3] = new Point2D() { X = 597849.28197854816, Y = 4473651.4819765529 };
            points[4] = new Point2D() { X = 603468.453516089, Y = 4470350.5931883259 };
            points[5] = new Point2D() { X = 602541.93949575315, Y = 4469362.1116667259 };
            points[6] = new Point2D() { X = 596899.866483911, Y = 4468956.9705482665 };
            points[7] = new Point2D() { X = 611758.72419415938, Y = 4476101.0380845685 };
            points[8] = new Point2D() { X = 617993.01585132082, Y = 4476567.4355759053 };
            points[9] = new Point2D() { X = 613072.97264934448, Y = 4472425.6988057708 };
            points[10] = new Point2D() { X = 627141.18584939465, Y = 4457193.8117718957 };
            points[11] = new Point2D() { X = 625007.69450436556, Y = 4475141.6919775512 };
            points[12] = new Point2D() { X = 614985.55448035314, Y = 4470280.1570427939 };
            points[13] = new Point2D() { X = 623901.71600422217, Y = 4466666.2160042226 };
            points[14] = new Point2D() { X = 629656.95681366918, Y = 4463716.8953833878 };
            points[15] = new Point2D() { X = 630173.95911998034, Y = 4457012.0457131462 };
            points[16] = new Point2D() { X = 633914.753754354, Y = 4455004.6871154737 };
            points[17] = new Point2D() { X = 621395.54110947042, Y = 4453979.7040218329 };
            points[18] = new Point2D() { X = 611692.43432728737, Y = 4436168.7267506663 };
            points[19] = new Point2D() { X = 616883.140989274, Y = 4429417.4819765529 };
            points[20] = new Point2D() { X = 622919.669528409, Y = 4462913.665593328 };
            points[21] = new Point2D() { X = 601313.33628629846, Y = 4455293.7974051712 };
            points[22] = new Point2D() { X = 612859.7380792771, Y = 4469688.8599254563 };
            points[23] = new Point2D() { X = 619859.663734605, Y = 4437419.6528260121 };
            points[24] = new Point2D() { X = 619986.40953671513, Y = 4446273.7524305694 };
            points[25] = new Point2D() { X = 602602.790723978, Y = 4467207.2437627846 };
            points[26] = new Point2D() { X = 601017.54226018267, Y = 4466159.2634545071 };
            points[27] = new Point2D() { X = 624837.92738216463, Y = 4470922.0728896968 };
            points[28] = new Point2D() { X = 627808.4361812321, Y = 4462623.96090279 };
            points[29] = new Point2D() { X = 601553.40045858407, Y = 4460450.558360938 };
            points[30] = new Point2D() { X = 604564.45904654567, Y = 4462898.198077416 };
            points[31] = new Point2D() { X = 617863.82231001207, Y = 4457545.3749187626 };
            points[32] = new Point2D() { X = 614289.80053016217, Y = 4449796.8294377672 };
            points[33] = new Point2D() { X = 604825.97279867844, Y = 4462217.1334855324 };
            points[34] = new Point2D() { X = 629571.82174916321, Y = 4472069.90070569 };
            points[35] = new Point2D() { X = 612746.39144627, Y = 4443343.5426283237 };
            points[36] = new Point2D() { X = 626928.06164879026, Y = 4469283.120878025 };

            zValues[0] = 52.98;
            zValues[1] = 25.74;
            zValues[2] = 62.94;
            zValues[3] = 50.82;
            zValues[4] = 41.36;
            zValues[5] = 41.66;
            zValues[6] = 64.66;
            zValues[7] = 23.7;
            zValues[8] = 40.74;
            zValues[9] = 3.12;
            zValues[10] = 139.32;
            zValues[11] = 41.48;
            zValues[12] = 28.48;
            zValues[13] = 61.92;
            zValues[14] = 52.22;
            zValues[15] = 44.54;
            zValues[16] = 56.54;
            zValues[17] = 85.22;
            zValues[18] = 48.94;
            zValues[19] = 55.2;
            zValues[20] = 52.8;
            zValues[21] = 27.5;
            zValues[22] = 39.34;
            zValues[23] = 56.22;
            zValues[24] = 39.12;
            zValues[25] = 27.72;
            zValues[26] = 34.84;
            zValues[27] = 49.26;
            zValues[28] = 55.14;
            zValues[29] = 333.26;
            zValues[30] = 42.76;
            zValues[31] = 26.42;
            zValues[32] = 54.32;
            zValues[33] = 50.88;
            zValues[34] = 56.96;
            zValues[35] = 35.2;
            zValues[36] = 49.14;
            #endregion

            double resolution = 3000;
            ExtractParameter parameter = new ExtractParameter() { DatumValue = 0, Interval = 5, Smoothness = 3 };
            DataReturnOption resultSetting = new DataReturnOption();
            resultSetting.DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET;
            resultSetting.DeleteExistResultDataset = true;
            resultSetting.Dataset = "isoLine@Interpolation";
            resultSetting.ExpectCount = 0;
            string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-sample/restjsr", ip);
            SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
            DatasetSpatialAnalystResult actualResult = spatialAnalyst.IsoLine(points, zValues, resolution, parameter, resultSetting);
            Assert.IsTrue(actualResult.Succeed);
            Assert.AreEqual(71, actualResult.Recordset.Features.Length);
            Assert.AreEqual("60.0", actualResult.Recordset.Features[25].FieldValues[9]);
        }

        /// <summary>
        /// 根据点数组提取等值线，点坐标数组为null
        /// </summary>
        [TestMethod]
        public void IsoLine_PointsIsNull()
        {
            #region zValues定义
            double[] zValues = new double[37];
            zValues[0] = 52.98;
            zValues[1] = 25.74;
            zValues[2] = 62.94;
            zValues[3] = 50.82;
            zValues[4] = 41.36;
            zValues[5] = 41.66;
            zValues[6] = 64.66;
            zValues[7] = 23.7;
            zValues[8] = 40.74;
            zValues[9] = 3.12;
            zValues[10] = 139.32;
            zValues[11] = 41.48;
            zValues[12] = 28.48;
            zValues[13] = 61.92;
            zValues[14] = 52.22;
            zValues[15] = 44.54;
            zValues[16] = 56.54;
            zValues[17] = 85.22;
            zValues[18] = 48.94;
            zValues[19] = 55.2;
            zValues[20] = 52.8;
            zValues[21] = 27.5;
            zValues[22] = 39.34;
            zValues[23] = 56.22;
            zValues[24] = 39.12;
            zValues[25] = 27.72;
            zValues[26] = 34.84;
            zValues[27] = 49.26;
            zValues[28] = 55.14;
            zValues[29] = 333.26;
            zValues[30] = 42.76;
            zValues[31] = 26.42;
            zValues[32] = 54.32;
            zValues[33] = 50.88;
            zValues[34] = 56.96;
            zValues[35] = 35.2;
            zValues[36] = 49.14;
            #endregion

            try
            {
                double resolution = 3000;
                ExtractParameter parameter = new ExtractParameter() { DatumValue = 0, Interval = 5, Smoothness = 3 };
                DataReturnOption resultSetting = new DataReturnOption();
                resultSetting.DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET;
                resultSetting.DeleteExistResultDataset = true;
                resultSetting.Dataset = "isoLine@Interpolation";
                resultSetting.ExpectCount = 0;
                string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-sample/restjsr", ip);
                SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
                DatasetSpatialAnalystResult actualResult = spatialAnalyst.IsoLine(null, zValues, resolution, parameter, resultSetting);
                Assert.IsTrue(actualResult.Succeed);
            }
            catch (Exception e)
            {
                Assert.AreEqual("点数组为null。", e.Message);
            }
        }

        /// <summary>
        /// 根据点数组提取等值线，zValues为null
        /// </summary>
        [TestMethod]
        public void IsoLine_ZValuesIsNull()
        {
            #region points定义
            Point2D[] points = new Point2D[37];
            points[0] = new Point2D() { X = 603598.5523083061, Y = 4479242.9705482665 };
            points[1] = new Point2D() { X = 604604.99079498206, Y = 4475916.8166897586 };
            points[2] = new Point2D() { X = 605069.2609360615, Y = 4473869.0317084016 };
            points[3] = new Point2D() { X = 597849.28197854816, Y = 4473651.4819765529 };
            points[4] = new Point2D() { X = 603468.453516089, Y = 4470350.5931883259 };
            points[5] = new Point2D() { X = 602541.93949575315, Y = 4469362.1116667259 };
            points[6] = new Point2D() { X = 596899.866483911, Y = 4468956.9705482665 };
            points[7] = new Point2D() { X = 611758.72419415938, Y = 4476101.0380845685 };
            points[8] = new Point2D() { X = 617993.01585132082, Y = 4476567.4355759053 };
            points[9] = new Point2D() { X = 613072.97264934448, Y = 4472425.6988057708 };
            points[10] = new Point2D() { X = 627141.18584939465, Y = 4457193.8117718957 };
            points[11] = new Point2D() { X = 625007.69450436556, Y = 4475141.6919775512 };
            points[12] = new Point2D() { X = 614985.55448035314, Y = 4470280.1570427939 };
            points[13] = new Point2D() { X = 623901.71600422217, Y = 4466666.2160042226 };
            points[14] = new Point2D() { X = 629656.95681366918, Y = 4463716.8953833878 };
            points[15] = new Point2D() { X = 630173.95911998034, Y = 4457012.0457131462 };
            points[16] = new Point2D() { X = 633914.753754354, Y = 4455004.6871154737 };
            points[17] = new Point2D() { X = 621395.54110947042, Y = 4453979.7040218329 };
            points[18] = new Point2D() { X = 611692.43432728737, Y = 4436168.7267506663 };
            points[19] = new Point2D() { X = 616883.140989274, Y = 4429417.4819765529 };
            points[20] = new Point2D() { X = 622919.669528409, Y = 4462913.665593328 };
            points[21] = new Point2D() { X = 601313.33628629846, Y = 4455293.7974051712 };
            points[22] = new Point2D() { X = 612859.7380792771, Y = 4469688.8599254563 };
            points[23] = new Point2D() { X = 619859.663734605, Y = 4437419.6528260121 };
            points[24] = new Point2D() { X = 619986.40953671513, Y = 4446273.7524305694 };
            points[25] = new Point2D() { X = 602602.790723978, Y = 4467207.2437627846 };
            points[26] = new Point2D() { X = 601017.54226018267, Y = 4466159.2634545071 };
            points[27] = new Point2D() { X = 624837.92738216463, Y = 4470922.0728896968 };
            points[28] = new Point2D() { X = 627808.4361812321, Y = 4462623.96090279 };
            points[29] = new Point2D() { X = 601553.40045858407, Y = 4460450.558360938 };
            points[30] = new Point2D() { X = 604564.45904654567, Y = 4462898.198077416 };
            points[31] = new Point2D() { X = 617863.82231001207, Y = 4457545.3749187626 };
            points[32] = new Point2D() { X = 614289.80053016217, Y = 4449796.8294377672 };
            points[33] = new Point2D() { X = 604825.97279867844, Y = 4462217.1334855324 };
            points[34] = new Point2D() { X = 629571.82174916321, Y = 4472069.90070569 };
            points[35] = new Point2D() { X = 612746.39144627, Y = 4443343.5426283237 };
            points[36] = new Point2D() { X = 626928.06164879026, Y = 4469283.120878025 };

            #endregion

            try
            {
                double resolution = 3000;
                ExtractParameter parameter = new ExtractParameter() { DatumValue = 0, Interval = 5, Smoothness = 3 };
                DataReturnOption resultSetting = new DataReturnOption();
                resultSetting.DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET;
                resultSetting.DeleteExistResultDataset = true;
                resultSetting.Dataset = "isoLine@Interpolation";
                resultSetting.ExpectCount = 0;
                string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-sample/restjsr", ip);
                SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
                DatasetSpatialAnalystResult actualResult = spatialAnalyst.IsoLine(points, null, resolution, parameter, resultSetting);
                Assert.IsTrue(actualResult.Succeed);
            }
            catch (Exception e)
            {
                Assert.AreEqual("第三维值数组为null。", e.Message);
            }
        }

        /// <summary>
        /// 根据点数组提取等值线，ExtractParameter为null
        /// </summary>
        [TestMethod]
        public void IsoLine_Points_ExtractParamIsNull()
        {
            #region points,zValues定义
            Point2D[] points = new Point2D[37];
            double[] zValues = new double[37];
            points[0] = new Point2D() { X = 603598.5523083061, Y = 4479242.9705482665 };
            points[1] = new Point2D() { X = 604604.99079498206, Y = 4475916.8166897586 };
            points[2] = new Point2D() { X = 605069.2609360615, Y = 4473869.0317084016 };
            points[3] = new Point2D() { X = 597849.28197854816, Y = 4473651.4819765529 };
            points[4] = new Point2D() { X = 603468.453516089, Y = 4470350.5931883259 };
            points[5] = new Point2D() { X = 602541.93949575315, Y = 4469362.1116667259 };
            points[6] = new Point2D() { X = 596899.866483911, Y = 4468956.9705482665 };
            points[7] = new Point2D() { X = 611758.72419415938, Y = 4476101.0380845685 };
            points[8] = new Point2D() { X = 617993.01585132082, Y = 4476567.4355759053 };
            points[9] = new Point2D() { X = 613072.97264934448, Y = 4472425.6988057708 };
            points[10] = new Point2D() { X = 627141.18584939465, Y = 4457193.8117718957 };
            points[11] = new Point2D() { X = 625007.69450436556, Y = 4475141.6919775512 };
            points[12] = new Point2D() { X = 614985.55448035314, Y = 4470280.1570427939 };
            points[13] = new Point2D() { X = 623901.71600422217, Y = 4466666.2160042226 };
            points[14] = new Point2D() { X = 629656.95681366918, Y = 4463716.8953833878 };
            points[15] = new Point2D() { X = 630173.95911998034, Y = 4457012.0457131462 };
            points[16] = new Point2D() { X = 633914.753754354, Y = 4455004.6871154737 };
            points[17] = new Point2D() { X = 621395.54110947042, Y = 4453979.7040218329 };
            points[18] = new Point2D() { X = 611692.43432728737, Y = 4436168.7267506663 };
            points[19] = new Point2D() { X = 616883.140989274, Y = 4429417.4819765529 };
            points[20] = new Point2D() { X = 622919.669528409, Y = 4462913.665593328 };
            points[21] = new Point2D() { X = 601313.33628629846, Y = 4455293.7974051712 };
            points[22] = new Point2D() { X = 612859.7380792771, Y = 4469688.8599254563 };
            points[23] = new Point2D() { X = 619859.663734605, Y = 4437419.6528260121 };
            points[24] = new Point2D() { X = 619986.40953671513, Y = 4446273.7524305694 };
            points[25] = new Point2D() { X = 602602.790723978, Y = 4467207.2437627846 };
            points[26] = new Point2D() { X = 601017.54226018267, Y = 4466159.2634545071 };
            points[27] = new Point2D() { X = 624837.92738216463, Y = 4470922.0728896968 };
            points[28] = new Point2D() { X = 627808.4361812321, Y = 4462623.96090279 };
            points[29] = new Point2D() { X = 601553.40045858407, Y = 4460450.558360938 };
            points[30] = new Point2D() { X = 604564.45904654567, Y = 4462898.198077416 };
            points[31] = new Point2D() { X = 617863.82231001207, Y = 4457545.3749187626 };
            points[32] = new Point2D() { X = 614289.80053016217, Y = 4449796.8294377672 };
            points[33] = new Point2D() { X = 604825.97279867844, Y = 4462217.1334855324 };
            points[34] = new Point2D() { X = 629571.82174916321, Y = 4472069.90070569 };
            points[35] = new Point2D() { X = 612746.39144627, Y = 4443343.5426283237 };
            points[36] = new Point2D() { X = 626928.06164879026, Y = 4469283.120878025 };

            zValues[0] = 52.98;
            zValues[1] = 25.74;
            zValues[2] = 62.94;
            zValues[3] = 50.82;
            zValues[4] = 41.36;
            zValues[5] = 41.66;
            zValues[6] = 64.66;
            zValues[7] = 23.7;
            zValues[8] = 40.74;
            zValues[9] = 3.12;
            zValues[10] = 139.32;
            zValues[11] = 41.48;
            zValues[12] = 28.48;
            zValues[13] = 61.92;
            zValues[14] = 52.22;
            zValues[15] = 44.54;
            zValues[16] = 56.54;
            zValues[17] = 85.22;
            zValues[18] = 48.94;
            zValues[19] = 55.2;
            zValues[20] = 52.8;
            zValues[21] = 27.5;
            zValues[22] = 39.34;
            zValues[23] = 56.22;
            zValues[24] = 39.12;
            zValues[25] = 27.72;
            zValues[26] = 34.84;
            zValues[27] = 49.26;
            zValues[28] = 55.14;
            zValues[29] = 333.26;
            zValues[30] = 42.76;
            zValues[31] = 26.42;
            zValues[32] = 54.32;
            zValues[33] = 50.88;
            zValues[34] = 56.96;
            zValues[35] = 35.2;
            zValues[36] = 49.14;
            #endregion

            try
            {
                double resolution = 3000;
                //ExtractParameter parameter = new ExtractParameter() { DatumValue = 0, Interval = 5, Smoothness = 3 };
                DataReturnOption resultSetting = new DataReturnOption();
                resultSetting.DataReturnMode = DataReturnMode.DATASET_AND_RECORDSET;
                resultSetting.DeleteExistResultDataset = true;
                resultSetting.Dataset = "isoLine@Interpolation";
                resultSetting.ExpectCount = 0;
                string serviceUrl = string.Format("http://{0}:8090/iserver/services/spatialanalyst-sample/restjsr", ip);
                SpatialAnalyst spatialAnalyst = new SpatialAnalyst(serviceUrl);
                DatasetSpatialAnalystResult actualResult = spatialAnalyst.IsoLine(points, zValues, resolution, null, resultSetting);
                Assert.IsTrue(actualResult.Succeed);
            }
            catch (Exception e)
            {
                Assert.AreEqual("参数不能为空。\r\n参数名: parameter", e.Message);
            }
        }
        #endregion

    }
}
