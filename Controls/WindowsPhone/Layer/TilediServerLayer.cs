using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Threading;
using SuperMap.Connector.Utility;
using System.ComponentModel;
using System.Diagnostics;

namespace SuperMap.Connector.Control.WindowsPhone
{
    public class TilediServerLayer : TiledLayer
    {
        public TilediServerLayer()
        {
            this.TileSize = 256;
        }

        public string Url { get; set; }
        public string MapName { get; set; }
        private double _dpi;
        private Rectangle2D _referViewBounds = null;
        private double _referScale = double.NaN;
        private SuperMap.Connector.Utility.Rectangle _referViewer = null;
        private double _referResolution = double.NaN;

        public override void Initialize()
        {
            if (string.IsNullOrWhiteSpace(Url) || string.IsNullOrWhiteSpace(MapName))
            {
                return;
            }
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
            backgroundWorker.RunWorkerAsync();
            IsInitializing = true;
            //if (System.Windows.Deployment.Current.Dispatcher.CheckAccess())
            //{
            //    ThreadStart threadStart = () =>
            //    {
            //        Map map = new Map(Url);
            //        MapParameter defaultMapParameter = map.GetDefaultMapParameter(MapName);
            //        this.Bounds = new Rectangle2D(defaultMapParameter.Bounds);
            //        this.MapName = defaultMapParameter.Name;
            //        this.ViewBounds = new Rectangle2D(defaultMapParameter.ViewBounds);
            //        this.Origin = new Point2D(Bounds.LeftBottom.X, Bounds.RightTop.Y);
            //        this.Scale = defaultMapParameter.Scale;
            //        this.TileSize = 256;
            //        //this.Resolution = (defaultMapParameter.ViewBounds.RightTop.X - defaultMapParameter.ViewBounds.LeftBottom.X) / defaultMapParameter.Viewer.Width;
            //        this._referScale = defaultMapParameter.Scale;
            //        this._referViewBounds = new Rectangle2D(defaultMapParameter.ViewBounds);
            //        this._referViewer = new Utility.Rectangle(defaultMapParameter.Viewer);
            //        this._referResolution = (defaultMapParameter.ViewBounds.RightTop.X - defaultMapParameter.ViewBounds.LeftBottom.X) / defaultMapParameter.Viewer.Width;
            //        this.IsInitialized = true;
            //        this.IsInitializing = false;
            //        this.OnInitialized();
            //    };

            //    Thread thread = new Thread(threadStart);
            //    thread.Start();
            //}
        }

        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Debug.WriteLine("");
            Map map = new Map(Url);
            MapParameter defaultMapParameter = map.GetDefaultMapParameter(MapName);
            e.Result = defaultMapParameter;
        }

        void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //System.Windows.Deployment.Current.Dispatcher.BeginInvoke(() =>
            //{
            MapParameter defaultMapParameter = e.Result as MapParameter;
            this.Bounds = new Rectangle2D(defaultMapParameter.Bounds);
            this.MapName = defaultMapParameter.Name;
            this.ViewBounds = new Rectangle2D(defaultMapParameter.ViewBounds);
            this.Origin = new Point2D(Bounds.LeftBottom.X, Bounds.RightTop.Y);
            this.Scale = defaultMapParameter.Scale;
            this.TileSize = 256;
            this._referScale = defaultMapParameter.Scale;
            this._referViewBounds = new Rectangle2D(defaultMapParameter.ViewBounds);
            this._referViewer = new Utility.Rectangle(defaultMapParameter.Viewer);
            this._referResolution = (defaultMapParameter.ViewBounds.RightTop.X - defaultMapParameter.ViewBounds.LeftBottom.X) / defaultMapParameter.Viewer.Width;
            this.IsInitialized = true;
            this.IsInitializing = false;
            this.OnInitialized();
            //});
        }

        public override string GetTileUrl(int x, int y, double resolution)
        {
            Map map = new Map(Url);
            TileInfo iserverTileInfo = new TileInfo();
            iserverTileInfo.Height = Convert.ToUInt32(this.TileSize);
            iserverTileInfo.Width = Convert.ToUInt32(this.TileSize); ;
            iserverTileInfo.TileIndex = new SuperMap.Connector.Utility.TileIndex();
            iserverTileInfo.TileIndex.ColIndex = x;
            iserverTileInfo.TileIndex.RowIndex = y;

            double scale = this._referScale * _referResolution / resolution;
            iserverTileInfo.Scale = scale;
            SuperMap.Connector.Utility.ImageOutputOption option = new SuperMap.Connector.Utility.ImageOutputOption();
            option.ImageReturnType = SuperMap.Connector.Utility.ImageReturnType.URL;
            option.ImageOutputFormat = SuperMap.Connector.Utility.ImageOutputFormat.PNG;
            option.Transparent = false;

            MapImage img = map.GetTile(MapName, iserverTileInfo, option);
            System.Diagnostics.Debug.WriteLine(img.ImageUrl);
            return img.ImageUrl;
        }
    }
}
