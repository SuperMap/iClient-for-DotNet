using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperMap.Connector;
using SuperMap.Connector.Utility;
using System.Drawing;
using System.IO;
using System.Net;

namespace SuperMap.Connector.UTests
{
    [TestClass]
    public class MapTest
    {
        string ip = "192.168.116.114";
        [TestMethod]
        public void MapConstructTest()
        {
            string paramName = string.Empty;
            try
            {
                Map map = new Map(null);
            }
            catch (ArgumentNullException e)
            {
                paramName = e.ParamName;
            }
            finally
            {
                Assert.IsTrue(string.Equals(paramName, "serviceUrl", StringComparison.InvariantCulture));
            }
        }

        [TestMethod]
        public void GetMapNamesTest_Normal()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            List<string> mapNames = map.GetMapNames();

            Assert.IsTrue(mapNames.Count == 5);
            Assert.IsTrue(mapNames[0] == "World");
            Assert.IsTrue(mapNames[1] == "世界地图_Day");
        }

        [TestMethod]
        public void GetDefaultMapParameterTest_Normal()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            MapParameter mapParameter = map.GetDefaultMapParameter("世界地图");

            Assert.IsTrue(mapParameter.Name == "世界地图");
            Assert.IsTrue(mapParameter.Layers.Count == 14);
        }

        [TestMethod]
        public void GetDefaultMapParameterTest_NoMapName()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            string paramName = string.Empty;
            try
            {
                MapParameter mapParameter = map.GetDefaultMapParameter("");
            }
            catch (ArgumentNullException e)
            {
                paramName = e.ParamName;
            }
            finally
            {
                Assert.IsTrue(string.Equals(paramName, "mapName", StringComparison.CurrentCulture));
            }
        }

        [TestMethod]
        public void GetTileTest_Normal()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");

            TileInfo tileInfo = new TileInfo();
            tileInfo.TileIndex = new TileIndex() { ColIndex = 2, RowIndex = 1 };
            tileInfo.Height = 256;
            tileInfo.Width = 256;
            tileInfo.Scale = 0.0000002;

            MapImage mapImage = map.GetTile("世界地图", tileInfo, null);

            using (MemoryStream memoryStream = new MemoryStream(mapImage.ImageData))
            {
                Bitmap bmp = new Bitmap(memoryStream);
                System.Drawing.Color systemColor = bmp.GetPixel(136, 48);
                Assert.IsTrue(systemColor.R == 153);
                Assert.IsTrue(systemColor.G == 179);
                Assert.IsTrue(systemColor.B == 204);
            }
        }

        [TestMethod]
        public void GetTileTest_ByTempLayer()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");

            TileInfo tileInfo = new TileInfo();
            tileInfo.Scale = 0.00000002;
            tileInfo.Height = 512;
            tileInfo.Width = 512;
            TileIndex tileIndex = new TileIndex() { RowIndex = 2, ColIndex = 1 };
            tileInfo.TileIndex = tileIndex;

            MapParameter mapParameter = map.GetDefaultMapParameter("世界地图");

            List<Layer> tempLayer = new List<Layer>();
            tempLayer.Add(mapParameter.Layers[12]);
            mapParameter.Layers = tempLayer;

            ImageOutputOption imageOutputOption = new ImageOutputOption();
            imageOutputOption.ImageReturnType = ImageReturnType.BINARY;
            imageOutputOption.Transparent = false;
            imageOutputOption.ImageOutputFormat = ImageOutputFormat.PNG;

            MapImage mapImage = map.GetTile("世界地图", tileInfo, imageOutputOption, mapParameter);
            using (MemoryStream memoryStream = new MemoryStream(mapImage.ImageData))
            {
                Bitmap bmp = new Bitmap(memoryStream);
                Assert.IsTrue(bmp.Width == 512);
                Assert.IsTrue(bmp.Height == 512);
                System.Drawing.Color color = bmp.GetPixel(240, 389);
                Assert.IsTrue(color.R == 242);
                Assert.IsTrue(color.G == 239);
                Assert.IsTrue(color.B == 233);
            }

            Assert.IsNull(null);
        }

        [TestMethod]
        public void GetMapImage()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            MapParameter mapParameter = map.GetDefaultMapParameter("世界地图");
            List<Layer> tempLayer = new List<Layer>();
            tempLayer.Add(mapParameter.Layers[12]);
            tempLayer.Add(mapParameter.Layers[13]);
            mapParameter.Layers = tempLayer;

            SuperMap.Connector.Utility.Rectangle rect = new SuperMap.Connector.Utility.Rectangle();
            rect.LeftTop = new SuperMap.Connector.Utility.Point();
            rect.RightBottom = new SuperMap.Connector.Utility.Point();
            rect.LeftTop.X = 0;
            rect.LeftTop.Y = 0;
            rect.RightBottom.X = 600;
            rect.RightBottom.Y = 480;
            mapParameter.Viewer = rect;

            mapParameter.Center = new Point2D();
            mapParameter.Center.X = 0;
            mapParameter.Center.Y = 0;

            MapImage mapImage = map.GetMapImage("世界地图", mapParameter, null);
            using (MemoryStream memoryStream = new MemoryStream(mapImage.ImageData))
            {
                Bitmap bmp = new Bitmap(memoryStream);
                Assert.IsTrue(bmp.Width == 600);
                Assert.IsTrue(bmp.Height == 480);
            }
        }

        [TestMethod]
        public void GetMapImage_ReturnUrl()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            MapParameter mapParameter = new MapParameter()
            {
                Center = new Point2D(0, 0),
                Scale = 0.0000000013138464,
                Viewer = new Utility.Rectangle(0, 0, 256, 256)
            };
            ImageOutputOption option = new ImageOutputOption()
            {
                ImageOutputFormat = ImageOutputFormat.GIF,
                ImageReturnType = ImageReturnType.URL
            };
            MapImage mapImage = map.GetMapImage("世界地图", mapParameter, option);
            Assert.IsNotNull(mapImage);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(mapImage.ImageUrl));
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(mapImage.ImageUrl);
            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
            Stream stream = response.GetResponseStream();
            Assert.IsNotNull(stream);
        }

        #region 动态专题图
        [TestMethod]
        public void GetMapImage_CreateThemeGraph()
        {
            ThemeGraph themeGraph = new ThemeGraph();
            themeGraph.Type = ThemeType.GRAPH;
            themeGraph.GraphType = ThemeGraphType.BAR3D;
            themeGraph.GraduatedMode = GraduatedMode.SQUAREROOT;
            themeGraph.AxesDisplayed = true;
            themeGraph.MaxGraphSize = 1;
            themeGraph.MinGraphSize = 0.35;
            themeGraph.GraphTextDisplayed = true;
            themeGraph.GraphTextFormat = GraphTextFormat.VALUE;
            themeGraph.BarWidth = 0.03;

            var item1 = new ThemeGraphItem();
            item1.Caption = "1";
            item1.GraphExpression = "Pop_Rate95";
            var style1 = new SuperMap.Connector.Utility.Style();
            style1.FillForeColor = new SuperMap.Connector.Utility.Color(211, 111, 240);
            item1.UniformStyle = style1;

            var item2 = new ThemeGraphItem();
            item2.Caption = "人口";
            item2.GraphExpression = "Pop_Rate99";
            var style2 = new SuperMap.Connector.Utility.Style();
            style2.FillForeColor = new SuperMap.Connector.Utility.Color(92, 73, 234);
            item2.UniformStyle = style2;

            themeGraph.Items = new ThemeGraphItem[] { item1, item2 };

            UGCThemeLayer themeLayer = new UGCThemeLayer();
            themeLayer.DatasetInfo = new DatasetInfo();
            themeLayer.DatasetInfo.DataSourceName = "Jingjin";
            themeLayer.DatasetInfo.Name = "BaseMap_R";
            themeLayer.DatasetInfo.Type = DatasetType.REGION;
            themeLayer.Description = "动态统计专题图";

            themeLayer.UgcLayerType = UGCLayerType.THEME;
            themeLayer.Type = LayerType.UGC;
            themeLayer.Visible = true;
            themeLayer.Theme = themeGraph;

            MapParameter mapParameter = new MapParameter();
            mapParameter.CacheEnabled = false;
            mapParameter.Center = new Point2D(116.755063, 39.803942);
            mapParameter.Scale = 1.0 / 1589406.44119042;
            mapParameter.RectifyType = RectifyType.BYCENTERANDMAPSCALE;
            mapParameter.Name = "动态统计专题图";
            mapParameter.ColorMode = MapColorMode.DEFAULT;

            mapParameter.Layers = new List<Layer>();
            mapParameter.Layers.Add(themeLayer);
            mapParameter.Viewer = new SuperMap.Connector.Utility.Rectangle(0, 0, 500, 400);

            Map map = new Map("http://" + ip + ":8090/iserver/services/map-jingjin/rest");
            ImageOutputOption imgageOutputOption = new ImageOutputOption();

            MapImage imageResult = map.GetMapImage("京津地区人口分布图_专题图", mapParameter, imgageOutputOption);
            using (MemoryStream memoryStream = new MemoryStream(imageResult.ImageData))
            {
                Bitmap bmp = new Bitmap(memoryStream);
                Assert.IsTrue(bmp.Width == 500);
                Assert.IsTrue(bmp.Height == 400);
                Assert.IsTrue(bmp.GetPixel(309, 293).R == 211);
                Assert.IsTrue(bmp.GetPixel(309, 293).G == 111);
                Assert.IsTrue(bmp.GetPixel(309, 293).B == 240);
            }
        }
        #endregion

        #region Query
        [TestMethod]
        public void QueryBySQLTest_ReturnRecordset()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            QueryParameterSet queryParameterSet = new QueryParameterSet();
            queryParameterSet.ExpectCount = 10;
            queryParameterSet.QueryOption = QueryOption.ATTRIBUTE;
            queryParameterSet.QueryParams = new QueryParameter[1];
            queryParameterSet.QueryParams[0] = new QueryParameter();
            queryParameterSet.QueryParams[0].AttributeFilter = "smid>1";
            queryParameterSet.QueryParams[0].Name = "Countries@World";
            queryParameterSet.ReturnContent = true;
            queryParameterSet.ReturnCustomResult = true;
            QueryResult qr = map.QueryBySQL("世界地图", queryParameterSet);
            Assert.AreEqual(qr.CurrentCount, 10);
            Assert.IsNotNull(qr.Recordsets);
            Assert.IsNull(qr.ResourceInfo);
            Assert.AreEqual(qr.TotalCount, 246);
        }

        [TestMethod]
        public void QueryBySQLTest_ReturnResourceInfo()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            QueryParameterSet queryParameterSet = new QueryParameterSet();
            queryParameterSet.ExpectCount = 10;
            queryParameterSet.QueryOption = QueryOption.ATTRIBUTE;
            queryParameterSet.QueryParams = new QueryParameter[1];
            queryParameterSet.QueryParams[0] = new QueryParameter();
            queryParameterSet.QueryParams[0].AttributeFilter = "smid>1";
            queryParameterSet.QueryParams[0].Name = "Countries@World";
            queryParameterSet.ReturnContent = false;
            queryParameterSet.ReturnCustomResult = true;
            QueryResult qr = map.QueryBySQL("世界地图", queryParameterSet);
            Assert.AreEqual(qr.CurrentCount, 0);
            Assert.IsNull(qr.Recordsets);
            Assert.IsNotNull(qr.ResourceInfo);
            Assert.AreEqual(qr.TotalCount, 0);
            Assert.AreEqual(qr.ResourceInfo.Bounds.LeftBottom.X, 0);
            Assert.IsNotNull(qr.ResourceInfo.NewResourceID);
            Assert.IsNotNull(qr.ResourceInfo.NewResourceLocation);
            Assert.IsTrue(qr.ResourceInfo.Succeed);
        }

        [TestMethod]
        public void QueryBySQLTest_QueryParams()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            QueryParameterSet queryParameterSet = new QueryParameterSet();
            queryParameterSet.ExpectCount = 20;
            queryParameterSet.QueryOption = QueryOption.ATTRIBUTE;
            queryParameterSet.QueryParams = new QueryParameter[2];
            queryParameterSet.QueryParams[0] = new QueryParameter();
            queryParameterSet.QueryParams[0].AttributeFilter = "smid<10";
            queryParameterSet.QueryParams[0].Name = "Countries@World";
            queryParameterSet.QueryParams[1] = new QueryParameter();
            queryParameterSet.QueryParams[1].AttributeFilter = "smid>1";
            queryParameterSet.QueryParams[1].Name = "ContinentLabel@World";
            queryParameterSet.ReturnContent = true;
            QueryResult qr = map.QueryBySQL("世界地图", queryParameterSet);

            Assert.AreEqual(qr.Recordsets.Length, 2);
            Assert.AreEqual(qr.Recordsets[0].Features.Length, 9);
            Assert.AreEqual(qr.Recordsets[1].Features.Length, 11);
            Assert.AreEqual(qr.Recordsets[0].Features[5].FieldNames[6], "COLOR_MAP");
            Assert.AreEqual(qr.Recordsets[0].Features[5].FieldValues[6], "4");
            Assert.IsNull(qr.Recordsets[1].Features[5].Geometry);
            Assert.AreEqual(qr.Recordsets[0].FieldCaptions.Length, 11);
            Assert.AreEqual(qr.Recordsets[0].FieldCaptions[4], "SQKM");
            Assert.AreEqual(qr.Recordsets[0].Fields.Length, 11);
            Assert.AreEqual(qr.Recordsets[0].Fields[6], "COLOR_MAP");
            Assert.AreEqual(qr.Recordsets[0].DatasetName, "Countries@World");
            Assert.AreEqual(qr.Recordsets[0].FieldTypes[5].ToString(), "DOUBLE");
        }

        [TestMethod]
        public void QueryBySQLTest_QueryParams1()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            QueryParameterSet queryParameterSet = new QueryParameterSet();
            queryParameterSet.ExpectCount = 20;
            queryParameterSet.QueryOption = QueryOption.ATTRIBUTE;
            queryParameterSet.QueryParams = new QueryParameter[2];
            queryParameterSet.QueryParams[0] = new QueryParameter();
            queryParameterSet.QueryParams[0].AttributeFilter = "smid>1";
            queryParameterSet.QueryParams[0].Name = "ContinentLabel@World";
            queryParameterSet.QueryParams[1] = new QueryParameter();
            queryParameterSet.QueryParams[1].AttributeFilter = "smid<10";
            queryParameterSet.QueryParams[1].Name = "Countries@World";
            queryParameterSet.ReturnContent = true;
            QueryResult qr = map.QueryBySQL("世界地图", queryParameterSet);
            Assert.AreEqual(qr.Recordsets.Length, 2);
            Assert.AreEqual(qr.Recordsets[0].Features.Length, 13);
            Assert.AreEqual(qr.Recordsets[1].Features.Length, 7);
        }

        [TestMethod]
        public void QueryBySQLTest_Error()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            QueryParameterSet queryParameterSet = new QueryParameterSet();
            queryParameterSet.ExpectCount = 10;
            queryParameterSet.QueryOption = QueryOption.ATTRIBUTE;
            queryParameterSet.QueryParams = new QueryParameter[1];
            queryParameterSet.QueryParams[0] = new QueryParameter();
            queryParameterSet.QueryParams[0].AttributeFilter = "smid>1";
            //queryParameterSet.QueryParams[0].Name = "Countries@World";
            queryParameterSet.ReturnContent = true;
            queryParameterSet.ReturnCustomResult = true;
            QueryResult qr = null;
            try
            {
                qr = map.QueryBySQL("世界地图", queryParameterSet);
            }
            catch (ServiceException e)
            {
                Assert.AreEqual(e.Message, "查询目标图层不存在。(null)");
            }
        }

        [TestMethod]
        public void QueryByBoundsTest_Default()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            QueryParameterSet queryParameterSet = new QueryParameterSet();
            queryParameterSet.QueryOption = QueryOption.ATTRIBUTE;
            Rectangle2D bounds = new Rectangle2D();
            bounds.LeftBottom = new Point2D(0, 0);
            bounds.RightTop = new Point2D(100, 100);
            queryParameterSet.QueryParams = new QueryParameter[1];
            queryParameterSet.QueryParams[0] = new QueryParameter("ContinentLabel@World");
            QueryResult qr = map.QueryByBounds("世界地图", bounds, queryParameterSet);
            Assert.IsNull(qr.Recordsets);
            Assert.IsTrue(qr.ResourceInfo.Succeed);
            Assert.IsNotNull(qr.ResourceInfo.NewResourceID);
            Assert.IsNull(qr.ResourceInfo.Bounds);
            Assert.IsNotNull(qr.ResourceInfo.NewResourceLocation);
            Assert.AreEqual(qr.TotalCount, 0);
        }

        [TestMethod]
        public void QueryByBoundsTest()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            QueryParameterSet queryParameterSet = new QueryParameterSet();
            queryParameterSet.ExpectCount = 20;
            queryParameterSet.QueryOption = QueryOption.ATTRIBUTE;
            Rectangle2D bounds = new Rectangle2D();
            bounds.LeftBottom = new Point2D(0, 0);
            bounds.RightTop = new Point2D(100, 100);
            queryParameterSet.QueryParams = new QueryParameter[1];
            queryParameterSet.QueryParams[0] = new QueryParameter("ContinentLabel@World");
            queryParameterSet.ReturnContent = true;
            QueryResult qr = map.QueryByBounds("世界地图", bounds, queryParameterSet);
            Assert.AreEqual(qr.CurrentCount, 6);
            Assert.AreEqual(qr.Recordsets[0].Features[3].FieldValues[0], "9");
            Assert.IsNull(qr.Recordsets[0].Features[1].Geometry);
            Assert.AreEqual(qr.Recordsets[0].DatasetName, "ContinentLabel@World");
        }


        [TestMethod]
        public void QueryByBoundsTest_ErrorBoundsIsNull()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            QueryParameterSet queryParameterSet = new QueryParameterSet();
            queryParameterSet.ExpectCount = 20;
            queryParameterSet.QueryOption = QueryOption.ATTRIBUTE;
            queryParameterSet.QueryParams = new QueryParameter[1];
            queryParameterSet.QueryParams[0] = new QueryParameter("ContinentLabel@World");
            queryParameterSet.ReturnContent = true;
            QueryResult qr = null;
            try
            {
                qr = map.QueryByBounds("世界地图", null, queryParameterSet);
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual(e.Message, "参数不能为空。\r\n参数名: bounds");
            }
        }

        [TestMethod]
        public void QueryByBoundsTest_ErrorMapnameIsNull()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            QueryParameterSet queryParameterSet = new QueryParameterSet();
            queryParameterSet.ExpectCount = 20;
            queryParameterSet.QueryOption = QueryOption.ATTRIBUTE;
            queryParameterSet.QueryParams = new QueryParameter[1];
            queryParameterSet.QueryParams[0] = new QueryParameter("ContinentLabel@World");
            queryParameterSet.ReturnContent = true;
            Rectangle2D bounds = new Rectangle2D();
            bounds.LeftBottom = new Point2D(0, 0);
            bounds.RightTop = new Point2D(100, 100);
            QueryResult qr = null;
            try
            {
                qr = map.QueryByBounds("", bounds, queryParameterSet);
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual(e.Message, "参数不能为空。\r\n参数名: mapName");
            }
        }

        [TestMethod]
        public void QueryByBoundsTest_Error()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            QueryParameterSet queryParameterSet = new QueryParameterSet();
            queryParameterSet.ExpectCount = 20;
            queryParameterSet.QueryOption = QueryOption.ATTRIBUTE;
            queryParameterSet.QueryParams = new QueryParameter[1];
            queryParameterSet.QueryParams[0] = new QueryParameter("ContinentLabelError@World");
            queryParameterSet.ReturnContent = true;
            Rectangle2D bounds = new Rectangle2D();
            bounds.LeftBottom = new Point2D(0, 0);
            bounds.RightTop = new Point2D(100, 100);
            QueryResult qr = null;
            try
            {
                qr = map.QueryByBounds("世界地图", bounds, queryParameterSet);
            }
            catch (ServiceException e)
            {
                Assert.AreEqual(e.Message, "查询目标图层不存在。(ContinentLabelError@World)");
            }
        }


        [TestMethod]
        public void QueryByDistanceTest_Default()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            QueryParameterSet queryParameterSet = new QueryParameterSet();
            queryParameterSet.QueryOption = QueryOption.ATTRIBUTE;
            Geometry geometry = new Geometry();
            geometry.Parts = new int[1] { 5 };
            geometry.Points = new Point2D[5];
            geometry.Points[0] = new Point2D(-45, -90);
            geometry.Points[1] = new Point2D(-45, 90);
            geometry.Points[2] = new Point2D(45, 90);
            geometry.Points[3] = new Point2D(45, -90);
            geometry.Points[4] = new Point2D(-45, -90);
            geometry.Type = GeometryType.REGION;
            queryParameterSet.QueryParams = new QueryParameter[1];
            queryParameterSet.QueryParams[0] = new QueryParameter("ContinentLabel@World");
            QueryResult qr = map.QueryByDistance("世界地图", geometry, 1.0, queryParameterSet);
            Assert.IsNull(qr.Recordsets);
            Assert.IsTrue(qr.ResourceInfo.Succeed);
            Assert.IsNotNull(qr.ResourceInfo.NewResourceID);
            Assert.IsNull(qr.ResourceInfo.Bounds);
            Assert.IsNotNull(qr.ResourceInfo.NewResourceLocation);
            Assert.AreEqual(qr.TotalCount, 0);
        }

        [TestMethod]
        public void QueryByDistanceTest()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            QueryParameterSet queryParameterSet = new QueryParameterSet();
            queryParameterSet.QueryOption = QueryOption.ATTRIBUTE;
            Geometry geometry = new Geometry();
            geometry.Parts = new int[1] { 5 };
            geometry.Points = new Point2D[5];
            geometry.Points[0] = new Point2D(-90, -45);
            geometry.Points[1] = new Point2D(90, -45);
            geometry.Points[2] = new Point2D(90, 45);
            geometry.Points[3] = new Point2D(-90, 45);
            geometry.Points[4] = new Point2D(-90, -45);
            geometry.Type = GeometryType.REGION;
            queryParameterSet.QueryParams = new QueryParameter[1];
            queryParameterSet.QueryParams[0] = new QueryParameter("CountryLabel@World");
            queryParameterSet.ReturnContent = true;
            queryParameterSet.StartRecord = 0;
            queryParameterSet.ExpectCount = 200;
            QueryResult qr = map.QueryByDistance("世界地图", geometry, 1.0, queryParameterSet);
            Assert.AreEqual(qr.CurrentCount, 122);
            Assert.AreEqual(qr.TotalCount, 122);
            Assert.AreEqual(qr.Recordsets[0].Features[3].FieldValues[0], "10");
            Assert.IsNull(qr.Recordsets[0].Features[1].Geometry);
            Assert.AreEqual(qr.Recordsets[0].DatasetName, "CountryLabel@World");
        }

        /// <summary>
        /// Distance小于0
        /// </summary>
        [TestMethod]
        public void QueryByDistanceTest_ErrorDistance()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            QueryParameterSet queryParameterSet = new QueryParameterSet();
            queryParameterSet.QueryOption = QueryOption.ATTRIBUTE;
            Geometry geometry = new Geometry();
            geometry.Parts = new int[1] { 5 };
            geometry.Points = new Point2D[5];
            geometry.Points[0] = new Point2D(-90, -45);
            geometry.Points[1] = new Point2D(90, -45);
            geometry.Points[2] = new Point2D(90, 45);
            geometry.Points[3] = new Point2D(-90, 45);
            geometry.Points[4] = new Point2D(-90, -45);
            geometry.Type = GeometryType.REGION;
            queryParameterSet.QueryParams = new QueryParameter[1];
            queryParameterSet.QueryParams[0] = new QueryParameter("CountryLabel@World");
            queryParameterSet.ReturnContent = true;
            queryParameterSet.StartRecord = 0;
            queryParameterSet.ExpectCount = 200;
            QueryResult qr = null;
            try
            {
                qr = map.QueryByDistance("世界地图", geometry, -1.0, queryParameterSet);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Assert.AreEqual(e.Message, "必须为大于零的数值。\r\n参数名: distance");
            }
        }

        /// <summary>
        /// Distance小于0
        /// </summary>
        [TestMethod]
        public void QueryByDistanceTest_ErrorgeometryIsNull()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            QueryParameterSet queryParameterSet = new QueryParameterSet();
            queryParameterSet.QueryOption = QueryOption.ATTRIBUTE;
            queryParameterSet.QueryParams = new QueryParameter[1];
            queryParameterSet.QueryParams[0] = new QueryParameter("CountryLabel@World");
            queryParameterSet.ReturnContent = true;
            queryParameterSet.StartRecord = 0;
            queryParameterSet.ExpectCount = 200;
            QueryResult qr = null;
            try
            {
                qr = map.QueryByDistance("世界地图", null, 1.0, queryParameterSet);
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual(e.Message, "参数不能为空。\r\n参数名: geometry");
            }
        }

        [TestMethod]
        public void QueryByGeometryTest_Default()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            QueryParameterSet queryParameterSet = new QueryParameterSet();
            queryParameterSet.QueryOption = QueryOption.ATTRIBUTE;
            Geometry geometry = new Geometry();
            geometry.Parts = new int[1] { 5 };
            geometry.Points = new Point2D[5];
            geometry.Points[0] = new Point2D(-45, -90);
            geometry.Points[1] = new Point2D(-45, 90);
            geometry.Points[2] = new Point2D(45, 90);
            geometry.Points[3] = new Point2D(45, -90);
            geometry.Points[4] = new Point2D(-45, -90);
            geometry.Type = GeometryType.REGION;
            queryParameterSet.QueryParams = new QueryParameter[1];
            queryParameterSet.QueryParams[0] = new QueryParameter("CountryLabel@World");
            QueryResult qr = map.QueryByGeometry("世界地图", geometry, SpatialQueryMode.CONTAIN, queryParameterSet);
            Assert.IsNull(qr.Recordsets);
            Assert.IsTrue(qr.ResourceInfo.Succeed);
            Assert.IsNotNull(qr.ResourceInfo.NewResourceID);
            Assert.IsNull(qr.ResourceInfo.Bounds);
            Assert.IsNotNull(qr.ResourceInfo.NewResourceLocation);
            Assert.AreEqual(qr.TotalCount, 0);
        }
        [TestMethod]
        public void QueryTextLayerTest()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            QueryParameterSet queryParameterSet = new QueryParameterSet();
            queryParameterSet.QueryOption = QueryOption.ATTRIBUTEANDGEOMETRY;
            queryParameterSet.QueryParams = new QueryParameter[1];
            queryParameterSet.QueryParams[0] = new QueryParameter("ContinentLabel@World");
            queryParameterSet.QueryParams[0].AttributeFilter = "SmID<20";
            queryParameterSet.ReturnContent = true;
            QueryResult qr = map.QueryBySQL("世界地图", queryParameterSet);

            Assert.IsTrue(qr != null);
        }

        [TestMethod]
        public void QueryByGeometryTest()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            QueryParameterSet queryParameterSet = new QueryParameterSet();
            queryParameterSet.QueryOption = QueryOption.ATTRIBUTE;
            Geometry geometry = new Geometry();
            geometry.Parts = new int[1] { 5 };
            geometry.Points = new Point2D[5];
            geometry.Points[0] = new Point2D(-90, -45);
            geometry.Points[1] = new Point2D(90, -45);
            geometry.Points[2] = new Point2D(90, 45);
            geometry.Points[3] = new Point2D(-90, 45);
            geometry.Points[4] = new Point2D(-90, -45);
            geometry.Type = GeometryType.REGION;
            queryParameterSet.QueryParams = new QueryParameter[1];
            queryParameterSet.QueryParams[0] = new QueryParameter("CountryLabel@World");
            queryParameterSet.ReturnContent = true;
            queryParameterSet.StartRecord = 0;
            queryParameterSet.ExpectCount = 20;
            QueryResult qr = map.QueryByGeometry("世界地图", geometry, SpatialQueryMode.INTERSECT, queryParameterSet);
            Assert.AreEqual(qr.CurrentCount, 20);
            Assert.AreEqual(qr.TotalCount, 119);
            Assert.AreEqual(qr.Recordsets[0].Features[3].FieldValues[0], "10");
            Assert.IsNull(qr.Recordsets[0].Features[1].Geometry);
            Assert.AreEqual(qr.Recordsets[0].DatasetName, "CountryLabel@World");
        }

        [TestMethod]
        public void QueryByGeometryTest_ErrorGeometryIsNull()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            QueryParameterSet queryParameterSet = new QueryParameterSet();
            queryParameterSet.QueryOption = QueryOption.ATTRIBUTE;
            queryParameterSet.QueryParams = new QueryParameter[1];
            queryParameterSet.QueryParams[0] = new QueryParameter("CountryLabel@World");
            queryParameterSet.ReturnContent = true;
            queryParameterSet.StartRecord = 0;
            queryParameterSet.ExpectCount = 20;
            QueryResult qr = null;
            try
            {
                qr = map.QueryByGeometry("世界地图", null, SpatialQueryMode.INTERSECT, queryParameterSet);
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual(e.Message, "参数不能为空。\r\n参数名: geometry");
            }
        }
        #endregion

        #region MeasureArea

        /// <summary>
        /// 面积量算
        /// </summary>
        [TestMethod]
        public void MeasureAreaResultTest()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            string mapName = "World Map";
            List<Point2D> point2Ds = new List<Point2D>();
            Point2D point1 = new Point2D(23.00, 34.00);
            Point2D point2 = new Point2D(53.55, 12.66);
            Point2D point3 = new Point2D(73.88, 12.6);
            point2Ds.Add(point1);
            point2Ds.Add(point2);
            point2Ds.Add(point3);
            MeasureAreaResult areaResult = map.MeasureArea(mapName, point2Ds, Unit.METER);
            Assert.AreEqual(areaResult.Area, 3157590930239.1533);
            Assert.AreEqual(areaResult.Unit.ToString(), "METER");
        }

        /// <summary>
        /// 面积量算
        /// </summary>
        [TestMethod]
        public void MeasureAreaResultTest_KILOMETER()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            string mapName = "World Map";
            List<Point2D> point2Ds = new List<Point2D>();
            Point2D point1 = new Point2D(23.00, 34.00);
            Point2D point2 = new Point2D(53.55, 12.66);
            Point2D point3 = new Point2D(73.88, 12.6);
            point2Ds.Add(point1);
            point2Ds.Add(point2);
            point2Ds.Add(point3);
            MeasureAreaResult areaResult = map.MeasureArea(mapName, point2Ds, Unit.KILOMETER);
            Assert.AreEqual(areaResult.Area, 3157590.9302391531);
            Assert.AreEqual(areaResult.Unit.ToString(), "KILOMETER");
        }

        /// <summary>
        /// 面积量算 mapName为空
        /// </summary>
        [TestMethod]
        public void MeasureAreaResultTest_mapNameISNULL()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");

            List<Point2D> point2Ds = new List<Point2D>();
            Point2D point1 = new Point2D(23.00, 34.00);
            Point2D point2 = new Point2D(53.55, 12.66);
            Point2D point3 = new Point2D(73.88, 12.6);
            point2Ds.Add(point1);
            point2Ds.Add(point2);
            point2Ds.Add(point3);
            MeasureAreaResult areaResult = null;
            try
            {
                areaResult = map.MeasureArea(string.Empty, point2Ds, Unit.KILOMETER);
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual(e.Message, "参数不能为空。\r\n参数名: mapName");
            }
        }

        /// <summary>
        /// 面积量算 point2Ds参数不合法
        /// </summary>
        [TestMethod]
        public void MeasureAreaResultTest_point2DsISEmply()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            List<Point2D> point2Ds = new List<Point2D>();
            MeasureAreaResult areaResult = null;
            try
            {
                areaResult = map.MeasureArea("世界地图", point2Ds, Unit.KILOMETER);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual(e.Message, "参数 point2Ds 不合法，必须至少包含三个二维点。");
            }
        }

        /// <summary>
        /// 面积量算 point2Ds为空
        /// </summary>
        [TestMethod]
        public void MeasureAreaResultTest_point2DsISNULL()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");

            MeasureAreaResult areaResult = null;
            try
            {
                areaResult = map.MeasureArea("世界地图", null, Unit.KILOMETER);
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual(e.Message, "参数不能为空。\r\n参数名: point2Ds");
            }
        }

        #endregion

        #region MeasureDistance

        /// <summary>
        /// 距离量算
        /// </summary>
        [TestMethod]
        public void MeasureDistanceTest()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            string mapName = "World Map";
            List<Point2D> point2Ds = new List<Point2D>();
            Point2D point1 = new Point2D(23.00, 34.00);
            Point2D point2 = new Point2D(53.55, 12.66);
            Point2D point3 = new Point2D(73.88, 12.6);
            point2Ds.Add(point1);
            point2Ds.Add(point2);
            point2Ds.Add(point3);
            MeasureDistanceResult result = map.MeasureDistance(mapName, point2Ds, Unit.METER);
            Assert.AreEqual(result.Distance, 6098355.576613714);
            Assert.AreEqual(result.Unit.ToString(), "METER");
        }

        /// <summary>
        /// 距离量算
        /// </summary>
        [TestMethod]
        public void MeasureDistanceTest_KILOMETER()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            string mapName = "World Map";
            List<Point2D> point2Ds = new List<Point2D>();
            Point2D point1 = new Point2D(23.00, 34.00);
            Point2D point2 = new Point2D(53.55, 12.66);
            Point2D point3 = new Point2D(73.88, 12.6);
            point2Ds.Add(point1);
            point2Ds.Add(point2);
            point2Ds.Add(point3);
            MeasureDistanceResult result = map.MeasureDistance(mapName, point2Ds, Unit.KILOMETER);
            Assert.AreEqual(result.Distance, 6098.3555766137142);
            Assert.AreEqual(result.Unit.ToString(), "KILOMETER");
        }

        /// <summary>
        /// 距离量算 mapName为空
        /// </summary>
        [TestMethod]
        public void MeasureDistanceTest_mapNameISNULL()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");

            List<Point2D> point2Ds = new List<Point2D>();
            Point2D point1 = new Point2D(23.00, 34.00);
            Point2D point2 = new Point2D(53.55, 12.66);
            Point2D point3 = new Point2D(73.88, 12.6);
            point2Ds.Add(point1);
            point2Ds.Add(point2);
            point2Ds.Add(point3);
            MeasureDistanceResult result = null;
            try
            {
                result = map.MeasureDistance(string.Empty, point2Ds, Unit.KILOMETER);
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual(e.Message, "参数不能为空。\r\n参数名: mapName");
            }
        }

        /// <summary>
        /// 距离量算 point2Ds参数不合法
        /// </summary>
        [TestMethod]
        public void MeasureDistanceTest_point2DsISEmply()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            List<Point2D> point2Ds = new List<Point2D>();
            MeasureDistanceResult result = null;
            try
            {
                result = map.MeasureDistance("世界地图", point2Ds, Unit.KILOMETER);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual(e.Message, "参数 point2Ds 不合法，必须至少包含两个二维点。");
            }
        }

        /// <summary>
        /// 距离量算 point2Ds为空
        /// </summary>
        [TestMethod]
        public void MeasureDistanceTest_point2DsISNULL()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");

            MeasureDistanceResult result = null;
            try
            {
                result = map.MeasureDistance("世界地图", null, Unit.KILOMETER);
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual(e.Message, "参数不能为空。\r\n参数名: point2Ds");
            }
        }
        #endregion

        #region GetResource
        [TestMethod]
        public void GetResourceTest_Marker()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            string mapName = "世界地图";
            ResourceParameter parameter = new ResourceParameter();
            parameter.Type = ResourceType.SYMBOLMARKER;
            ImageOutputOption option = new ImageOutputOption();
            option.ImageOutputFormat = ImageOutputFormat.PNG;
            option.ImageReturnType = ImageReturnType.URL;
            ResourceImage image = map.GetResource(mapName, parameter, option);
            Assert.AreEqual(image.ImageUrl, "http://192.168.116.114:8090/iserver/output/resources/%E4%B8%96%E7%95%8C%E5%9C%B0%E5%9B%BE/SYMBOLMARKER/0_1160020228.png");
        }

        [TestMethod]
        public void GetResourceTest_MarkerID()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            string mapName = "世界地图";
            ResourceParameter parameter = new ResourceParameter();
            parameter.Style = new Style();
            parameter.Style.MarkerSymbolID = 2;
            parameter.Type = ResourceType.SYMBOLMARKER;
            ImageOutputOption option = new ImageOutputOption();
            option.ImageOutputFormat = ImageOutputFormat.BMP;
            option.ImageReturnType = ImageReturnType.URL;
            ResourceImage image = map.GetResource(mapName, parameter, option);
            Assert.AreEqual(image.ImageUrl, "http://192.168.116.114:8090/iserver/output/resources/%E4%B8%96%E7%95%8C%E5%9C%B0%E5%9B%BE/SYMBOLMARKER/2_1160020446.png");
        }

        /// <summary>
        /// MarkerID超出范围
        /// </summary>
        [TestMethod]
        public void GetResourceTest_MarkerIDError()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            string mapName = "世界地图";
            ResourceParameter parameter = new ResourceParameter();
            parameter.Style = new Style();
            parameter.Style.MarkerSymbolID = 200;
            parameter.Type = ResourceType.SYMBOLMARKER;
            ImageOutputOption option = new ImageOutputOption();
            option.ImageOutputFormat = ImageOutputFormat.BMP;
            option.ImageReturnType = ImageReturnType.URL;
            ResourceImage image = null;
            try
            {
                image = map.GetResource(mapName, parameter, option);
            }
            catch (ServiceException e)
            {
                Assert.AreEqual(e.Message, "获取资源图片的符号 ID 超出范围。");
            }
        }

        [TestMethod]
        public void GetResourceTest_Line()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            string mapName = "世界地图";
            ResourceParameter parameter = new ResourceParameter();
            parameter.Type = ResourceType.SYMBOLLINE;
            ImageOutputOption option = new ImageOutputOption();
            option.ImageOutputFormat = ImageOutputFormat.PNG;
            option.ImageReturnType = ImageReturnType.URL;
            ResourceImage image = map.GetResource(mapName, parameter, option);
            Assert.AreEqual(image.ImageUrl, "http://192.168.116.114:8090/iserver/output/resources/%E4%B8%96%E7%95%8C%E5%9C%B0%E5%9B%BE/SYMBOLLINE/0_1160020228.png");
        }

        [TestMethod]
        public void GetResourceTest_LineID()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            string mapName = "世界地图";
            ResourceParameter parameter = new ResourceParameter();
            parameter.Style = new Style();
            parameter.Style.LineSymbolID = 5;
            parameter.Type = ResourceType.SYMBOLLINE;
            ImageOutputOption option = new ImageOutputOption();
            option.ImageOutputFormat = ImageOutputFormat.PNG;
            option.ImageReturnType = ImageReturnType.URL;
            ResourceImage image = map.GetResource(mapName, parameter, option);
            Assert.AreEqual(image.ImageUrl, "http://192.168.116.114:8090/iserver/output/resources/%E4%B8%96%E7%95%8C%E5%9C%B0%E5%9B%BE/SYMBOLLINE/5_781806645.png");
        }

        [TestMethod]
        public void GetResourceTest_Fill()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            string mapName = "世界地图";
            ResourceParameter parameter = new ResourceParameter();
            parameter.Type = ResourceType.SYMBOLFILL;
            ImageOutputOption option = new ImageOutputOption();
            option.ImageOutputFormat = ImageOutputFormat.PNG;
            option.ImageReturnType = ImageReturnType.URL;
            ResourceImage image = map.GetResource(mapName, parameter, option);
            Assert.AreEqual(image.ImageUrl, "http://192.168.116.114:8090/iserver/output/resources/%E4%B8%96%E7%95%8C%E5%9C%B0%E5%9B%BE/SYMBOLFILL/0_1160020228.png");
        }

        [TestMethod]
        public void GetResourceTest_BitMap()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            string mapName = "世界地图";
            ResourceParameter parameter = new ResourceParameter();
            parameter.Type = ResourceType.SYMBOLFILL;
            ImageOutputOption option = new ImageOutputOption();
            option.ImageOutputFormat = ImageOutputFormat.PNG;
            option.ImageReturnType = ImageReturnType.BINARY;
            ResourceImage image = map.GetResource(mapName, parameter, option);
            Assert.AreEqual(image.ImageData[1], 80);
            Assert.AreEqual(image.ImageData[30], 105);
        }
        #endregion

        #region GetEntire
        [TestMethod]
        public void GetEntireImageTest()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            string mapName = "世界地图";

            ImageOutputOption option = new ImageOutputOption();
            option.ImageOutputFormat = ImageOutputFormat.PNG;
            option.ImageReturnType = ImageReturnType.URL;
            MapImage image = map.GetEntireImage(mapName, string.Empty, new MapParameter(), option);
            //Assert.AreEqual(image.MapParameter.Viewer.Height, 256);
            //Assert.AreEqual(image.MapParameter.Viewer.Width, 256);
            Assert.IsNotNull(image.ImageUrl);
            Assert.IsNull(image.ImageData);
        }

        [TestMethod]
        public void GetEntireImageTest_MapParamerterISNULL()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            string mapName = "世界地图";

            ImageOutputOption option = new ImageOutputOption();
            option.ImageOutputFormat = ImageOutputFormat.PNG;
            option.ImageReturnType = ImageReturnType.URL;
            MapImage image = map.GetEntireImage(mapName, string.Empty, null, option);
            Assert.IsTrue(image.ImageUrl.Contains("http://192.168.116.114:8090/iserver/services/map-world/rest/maps/%e4%b8%96%e7%95%8c%e5%9c%b0%e5%9b%be/entireimage.png?layerName=&redirect=true&transparent=False&"));
        }

        [TestMethod]
        public void GetEntireImageTest_BMP()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            string mapName = "世界地图";

            ImageOutputOption option = new ImageOutputOption();
            option.ImageOutputFormat = ImageOutputFormat.BMP;
            option.ImageReturnType = ImageReturnType.BINARY;
            MapImage image = map.GetEntireImage(mapName, null, option);
            Assert.IsNull(image.ImageUrl);
            Assert.IsNotNull(image.ImageData);
            using (MemoryStream memoryStream = new MemoryStream(image.ImageData))
            {
                Bitmap bmp = new Bitmap(memoryStream);
                Assert.IsTrue(bmp.Width == 256);
                Assert.IsTrue(bmp.Height == 256);
                System.Drawing.Color color = bmp.GetPixel(200, 163);
                Assert.AreEqual(color.ToString(), "Color [A=255, R=153, G=179, B=204]");
            }
        }

        [TestMethod]
        public void GetEntireImageTest_Error()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            string mapName = "";

            ImageOutputOption option = new ImageOutputOption();
            option.ImageOutputFormat = ImageOutputFormat.PNG;
            option.ImageReturnType = ImageReturnType.URL;
            MapImage image = null;
            try
            {
                image = map.GetEntireImage(mapName, string.Empty, new MapParameter(), option);
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual(e.Message, "参数不能为空。\r\n参数名: mapName");
            }
        }

        #endregion

        #region ClearCache单元测试
        [TestMethod]
        public void ClearCache_FullExtend()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            string mapName = "世界地图1";
            Rectangle2D clearCacheBounds = new Rectangle2D(-180, -90, 180, 90);
            try
            {
                bool succeed = map.ClearCache(mapName, clearCacheBounds);
            }
            catch (ServiceException exception)
            {
                string message = exception.Message;
                Assert.IsTrue("地图 世界地图1 不存在，获取相应的地图业务组件失败" == exception.Message);
                Assert.IsTrue(404 == exception.Code);
            }
        }

        [TestMethod]
        public void ClearCache_CustomExtend()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            string mapName = "世界地图";
            Rectangle2D clearCacheBounds = new Rectangle2D(0, 0, 180, 90);
            bool succeed = map.ClearCache(mapName, clearCacheBounds);
            Assert.IsTrue(succeed);
        }

        [TestMethod]
        public void ClearCache_NoMapName()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            Rectangle2D clearCacheBounds = new Rectangle2D(0, 0, 180, 90);
            try
            {
                bool succeed = map.ClearCache(null, clearCacheBounds);
            }
            catch (ArgumentNullException e)
            {
                Assert.IsTrue(string.Equals("mapName", e.ParamName));
            }
        }

        [TestMethod]
        public void ClearCache_NoBounds()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            try
            {
                bool succeed = map.ClearCache("世界地图", null);
            }
            catch (ArgumentNullException e)
            {
                Assert.IsTrue(string.Equals("bounds", e.ParamName));
            }
        }
        #endregion

        #region GetOverview

        [TestMethod]
        public void GetOverviewTest()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            string mapName = "世界地图";

            ImageOutputOption option = new ImageOutputOption();
            option.ImageOutputFormat = ImageOutputFormat.PNG;
            option.ImageReturnType = ImageReturnType.URL;
            Overview image = map.GetOverview(mapName, new MapParameter(), option);
            Assert.IsNotNull(image.ImageUrl);
            Assert.IsNull(image.ImageData);
            Assert.AreEqual(image.Viewer.Height, 256);
            Assert.AreEqual(image.Viewer.Width, 256);
            Assert.IsNotNull(image.LastModified);
            Assert.IsNotNull(image.ViewBounds);
            Assert.AreEqual(image.ViewBounds.LeftBottom.X, 84.30460372171433);
            Assert.AreEqual(image.ViewBounds.LeftBottom.Y, 15.704362017314319);
            Assert.AreEqual(image.MapName, mapName);
        }

        [TestMethod]
        public void GetOverviewTest_View()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            string mapName = "世界地图";
            MapParameter param = new MapParameter();
            param.Viewer = new SuperMap.Connector.Utility.Rectangle();
            param.Viewer.LeftTop = new SuperMap.Connector.Utility.Point(0, 0);
            param.Viewer.RightBottom = new SuperMap.Connector.Utility.Point(512, 512);
            ImageOutputOption option = new ImageOutputOption();
            option.ImageOutputFormat = ImageOutputFormat.PNG;
            option.ImageReturnType = ImageReturnType.URL;
            Overview image = map.GetOverview(mapName, param, option);
            Assert.IsNotNull(image.ImageUrl);
            Assert.IsNull(image.ImageData);
            Assert.AreEqual(image.Viewer.Height, 512);
            Assert.AreEqual(image.Viewer.Width, 512);
            Assert.IsNotNull(image.LastModified);
            Assert.IsNotNull(image.ViewBounds);
        }

        [TestMethod]
        public void GetOverviewTest_png()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            string mapName = "世界地图";

            ImageOutputOption option = new ImageOutputOption();
            option.ImageOutputFormat = ImageOutputFormat.PNG;
            option.ImageReturnType = ImageReturnType.BINARY;
            Overview image = map.GetOverview(mapName, new MapParameter(), option);
            Assert.IsNull(image.ImageUrl);
            Assert.IsNotNull(image.ImageData);
            using (MemoryStream memoryStream = new MemoryStream(image.ImageData))
            {
                Bitmap bmp = new Bitmap(memoryStream);
                Assert.IsTrue(bmp.Width == 256);
                Assert.IsTrue(bmp.Height == 256);
                System.Drawing.Color color = bmp.GetPixel(26, 163);
                Assert.AreEqual(color.ToString(), "Color [A=255, R=196, G=193, B=225]");
                System.Drawing.Color color1 = bmp.GetPixel(130, 164);
                Assert.AreEqual(color1.ToString(), "Color [A=255, R=252, G=204, B=182]");
            }
        }

        /// <summary>
        /// 验证地图透明
        /// </summary>
        [TestMethod]
        public void GetOverviewTest_Transparent()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-jingjin/rest");
            string mapName = "京津地区土地利用现状图";

            ImageOutputOption option = new ImageOutputOption();
            option.ImageOutputFormat = ImageOutputFormat.PNG;
            option.ImageReturnType = ImageReturnType.BINARY;
            option.Transparent = true;
            Overview image = map.GetOverview(mapName, new MapParameter(), option);
            Assert.IsNull(image.ImageUrl);
            Assert.IsNotNull(image.ImageData);
            using (MemoryStream memoryStream = new MemoryStream(image.ImageData))
            {
                Bitmap bmp = new Bitmap(memoryStream);
                Assert.IsTrue(bmp.Width == 256);
                Assert.IsTrue(bmp.Height == 256);
                System.Drawing.Color color = bmp.GetPixel(26, 163);
                Assert.AreEqual(color.ToString(), "Color [A=0, R=255, G=254, B=253]");
                System.Drawing.Color color1 = bmp.GetPixel(200, 120);
                Assert.AreEqual(color1.ToString(), "Color [A=255, R=247, G=254, B=180]");
            }
        }

        /// <summary>
        /// 相对地图透明案例，比较不透明情况
        /// </summary>
        [TestMethod]
        public void GetOverviewTest_NotTransparent()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-jingjin/rest");
            string mapName = "京津地区土地利用现状图";

            ImageOutputOption option = new ImageOutputOption();
            option.ImageOutputFormat = ImageOutputFormat.PNG;
            option.ImageReturnType = ImageReturnType.BINARY;
            option.Transparent = false;
            Overview image = map.GetOverview(mapName, new MapParameter(), option);
            Assert.IsNull(image.ImageUrl);
            Assert.IsNotNull(image.ImageData);
            using (MemoryStream memoryStream = new MemoryStream(image.ImageData))
            {
                Bitmap bmp = new Bitmap(memoryStream);
                Assert.IsTrue(bmp.Width == 256);
                Assert.IsTrue(bmp.Height == 256);
                System.Drawing.Color color = bmp.GetPixel(26, 163);
                Assert.AreEqual(color.ToString(), "Color [A=255, R=255, G=255, B=255]");
                System.Drawing.Color color1 = bmp.GetPixel(200, 120);
                Assert.AreEqual(color1.ToString(), "Color [A=255, R=247, G=254, B=180]");
            }
        }

        [TestMethod]
        public void GetOverviewTest_MapNameISNULL()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");

            ImageOutputOption option = new ImageOutputOption();
            option.ImageOutputFormat = ImageOutputFormat.PNG;
            option.ImageReturnType = ImageReturnType.BINARY;
            Overview image = null;
            try
            {
                image = map.GetOverview(string.Empty, new MapParameter(), option);
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual(e.Message, "参数不能为空。\r\n参数名: mapName");
            }
        }

        /// <summary>
        /// 验证mapPatameter参数为空时，案例正常通过
        /// </summary>
        [TestMethod]
        public void GetOverviewTest_MapParameterISNull()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            string mapName = "世界地图";

            ImageOutputOption option = new ImageOutputOption();
            option.ImageOutputFormat = ImageOutputFormat.PNG;
            option.ImageReturnType = ImageReturnType.URL;
            Overview image = map.GetOverview(mapName, null, option);
            Assert.IsNotNull(image.ImageUrl);
            Assert.IsNull(image.ImageData);
            Assert.AreEqual(image.Viewer.Height, 256);
            Assert.AreEqual(image.Viewer.Width, 256);
            Assert.IsNotNull(image.LastModified);
            Assert.IsNotNull(image.ViewBounds);
            Assert.AreEqual(image.ViewBounds.LeftBottom.X, 84.30460372171433);
            Assert.AreEqual(image.ViewBounds.LeftBottom.Y, 15.704362017314319);
            Assert.AreEqual(image.MapName, mapName);
        }

        #endregion

        #region 动态投影
        [TestMethod]
        public void DynicProject()
        {
            Map map = new Map("http://" + ip + ":8090/iserver/services/map-world/rest");
            MapParameter mapParameter = new MapParameter();
            mapParameter.PrjCoordSys = new PrjCoordSys();
            mapParameter.PrjCoordSys.EpsgCode = 3857;
            mapParameter.Center = new Point2D(0, 0);
            mapParameter.Scale = 0.0000000013138464;
            mapParameter.Viewer = new Utility.Rectangle(0, 0, 256, 256);
            mapParameter.RectifyType = RectifyType.BYCENTERANDMAPSCALE;
            mapParameter.CacheEnabled = false;
            ImageOutputOption option = new ImageOutputOption();
            option.ImageOutputFormat = ImageOutputFormat.PNG;
            option.ImageReturnType = ImageReturnType.BINARY;
            MapImage image = map.GetMapImage("世界地图", mapParameter, option);
            Assert.IsTrue(image != null);
            using (MemoryStream stream = new MemoryStream(image.ImageData))
            {
                Bitmap bmp = (Bitmap)Image.FromStream(stream);
                System.Drawing.Color t = bmp.GetPixel(200, 230);
                Assert.IsTrue(t.A == 255);
                Assert.IsTrue(t.R == 196);
                Assert.IsTrue(t.G == 193);
                Assert.IsTrue(t.B == 225);
            }
        }
        #endregion
    }

}
