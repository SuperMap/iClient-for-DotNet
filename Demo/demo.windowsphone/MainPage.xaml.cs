using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using SuperMap.Web.Mapping;
using Connector = SuperMap.Connector;
using Utility = SuperMap.Connector.Utility;
using Microsoft.Devices;
using SuperMap.Web.Core;
using System.Windows.Navigation;

namespace SuperMap.Demo.WindowsPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        FeaturesLayer _queryLayer;
        TiledDynamicRESTLayer _tileLayer;
        Connector.Map _queryMap;
        string mapName;
        // 构造函数
        public MainPage()
        {
            InitializeComponent();
            myMap.Hold += new EventHandler<GestureEventArgs>(Map_Hold);
            myMap.DoubleTap += new EventHandler<GestureEventArgs>(Map_DoubleTap);
            myMap.Tap += new EventHandler<GestureEventArgs>(Map_Tap);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string strMapUrl = this.NavigationContext.QueryString["url"];

            _tileLayer = new TiledDynamicRESTLayer();
            _tileLayer.Url = strMapUrl;
            this.myMap.Layers.Add(_tileLayer);
            _queryLayer = new FeaturesLayer();
            _queryLayer.ID = "QueryLayer";
            this.myMap.Layers.Add(_queryLayer);

            string[] splitItems = _tileLayer.Url.Split(new char[] { '/' });
            mapName = _tileLayer.Url.Substring(_tileLayer.Url.LastIndexOf('/') + 1);
            int restIndex = _tileLayer.Url.LastIndexOf("maps");
            string compomentUrl = _tileLayer.Url.Substring(0, restIndex);
            _queryMap = new Connector.Map(compomentUrl);
        }

        void Map_DoubleTap(object sender, GestureEventArgs e)
        {
            Point point = e.GetPosition(myMap);
            Point2D p = myMap.ScreenToMap(point);
            double resolution = myMap.Resolution / 2;
            Point2D leftBottom = new Point2D(p.X - point.X * resolution, p.Y - (myMap.RenderSize.Height - point.Y) * resolution);

            Rectangle2D rec = new Rectangle2D(leftBottom, myMap.RenderSize.Width * resolution, myMap.RenderSize.Height * resolution);
            myMap.ZoomTo(rec);

        }

        void Map_Tap(object sender, GestureEventArgs e)
        {
            ClearQuery();
        }

        private void ClearQuery()
        {
            foreach (Feature f in _queryLayer.Features)
            {
                f.Tap -= f_Tap;
            }
            _queryLayer.Features.Clear();
        }

        void Map_Hold(object sender, GestureEventArgs e)
        {
            ClearQuery();
            Point2D point = myMap.ScreenToMap(e.GetPosition(myMap));
            double radius = 100000;//Map.Resolution * 10;
            Utility.Point2D p = new Utility.Point2D(point.X, point.Y);
            Utility.Geometry geometry = new Utility.Geometry();
            geometry.Type = Utility.GeometryType.POINT;
            geometry.Parts = new int[] { 1 };
            geometry.Points = new Utility.Point2D[1] { p };

            Utility.QueryParameterSet query = new Utility.QueryParameterSet();
            query.ReturnContent = true;
            query.ExpectCount = 1;
            query.QueryOption = Utility.QueryOption.ATTRIBUTEANDGEOMETRY;
            query.QueryParams = new Utility.QueryParameter[] { new Utility.QueryParameter("China_PreCenCity_P_Label@China400") };

            _queryMap.FindNearest(mapName, geometry, radius, query,
                new EventHandler<Utility.QueryEventArgs>(Query_Completed), new EventHandler<Utility.FailedEventArgs>(Query_Failed));
        }

        void Query_Completed(object sender, Utility.QueryEventArgs e)
        {
            if (e.QueryResult == null || e.QueryResult.CurrentCount <= 0)
            {
                return;
            }
            else
            {
                VibrateController vc = VibrateController.Default;
                vc.Start(TimeSpan.FromMilliseconds(150));

                Utility.Recordset[] results = e.QueryResult.Recordsets;
                foreach (Utility.Recordset result in results)
                {
                    if (result.Features == null || result.Features.Length <= 0)
                    {
                        continue;
                    }
                    else
                    {
                        foreach (Utility.Feature feature in result.Features)
                        {
                            if (feature.Geometry.Type == Utility.GeometryType.POINT || feature.Geometry.Type == Utility.GeometryType.TEXT)
                            {
                                Point2D point = new Point2D(feature.Geometry.Points[0].X, feature.Geometry.Points[0].Y);
                                Feature f = new Feature();
                                f.Geometry = new GeoPoint(point);
                                f.Tap += f_Tap;
                                MyInfoWindow info = new MyInfoWindow(feature.FieldValues[4]);

                                f.Style = info;
                                this._queryLayer.Features.Add(f);
                            }
                        }
                    }
                }
            }
        }

        void f_Tap(object sender, GestureEventArgs e)
        {
            e.Handled = true;
        }

        void Query_Failed(object sender, Utility.FailedEventArgs e)
        {

        }

        private void zoomIn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.myMap.ZoomIn();
        }

        private void zoomOut_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.myMap.ZoomOut();
        }
    }
}