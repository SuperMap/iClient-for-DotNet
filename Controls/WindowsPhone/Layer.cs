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
using SuperMap.Connector;
using SuperMap.Connector.Utility;
using System.ComponentModel;
using System.Threading;
using System.Windows.Media.Imaging;

namespace SuperMap.Connector.Control.WindowsPhone
{
    public sealed class LayerCollection : System.Collections.ObjectModel.ObservableCollection<Layer>
    {
        public LayerCollection()
            : base()
        {

        }
    }

    public abstract class Layer : DependencyObject, INotifyPropertyChanged
    {
        public Layer()
        {
            LayerCanvas = new Canvas();
        }

        internal Canvas LayerCanvas = null;
        public static readonly DependencyProperty IDProperty = DependencyProperty.Register("ID", typeof(string), typeof(Layer), null);
        public string ID
        {
            get { return (string)this.GetValue(IDProperty); }
            set { this.SetValue(IDProperty, value); }
        }
        public string Name { get; set; }
        public bool Visiable { get; set; }
        public Rectangle2D ViewBounds { get; set; }
        public System.Windows.Shapes.Rectangle MapSize { get; internal set; }
        public Rectangle2D Bounds { get; set; }
        public bool IsInitialized = false;
        public bool IsInitializing = false;
        public double Scale { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<EventArgs> Initialized;

        public abstract void Draw();
        public virtual void Initialize()
        {

        }

        protected void OnInitialized()
        {
            if (this.Initialized != null)
            {
                Initialized(this, null);
            }
        }
    }

    public abstract class TileLayer : Layer
    {
        public TileLayer()
        {

        }

        public Point2D Origin { get; set; }
        public int TileSize { get; set; }
        public double Resolution { get; set; }

        public override void Draw()
        {
            int[] tiles = GetTileSpanWithin(this.ViewBounds, this.Resolution);
            for (int i = tiles[1]; i <= tiles[3]; i++)
            {
                for (int j = tiles[0]; j <= tiles[2]; j++)
                {
                    string url = GetTileUrl(j, i, this.Resolution);
                    Tile tile = new Tile();
                    tile.ColIndex = j;
                    tile.Resolution = this.Resolution;
                    tile.RowIndex = i;
                    tile.Image = new Image() { Source = new BitmapImage(new Uri(url)) };
                    double left = ((this.Origin.X + ((TileSize * j) * Resolution)) - this.ViewBounds.LeftBottom.X) / Resolution;
                    double top = (ViewBounds.RightTop.Y - (this.Origin.Y - ((TileSize * i) * Resolution))) / Resolution;
                    tile.Image.SetValue(Canvas.LeftProperty, left);
                    tile.Image.SetValue(Canvas.TopProperty, top);
                    this.LayerCanvas.Children.Add(tile.Image);

                }
            }
        }

        public abstract string GetTileUrl(int x, int y, double resolution);

        private int[] GetTileSpanWithin(Rectangle2D bounds, double resolution)
        {
            double x = this.Origin.X;
            double y = this.Origin.Y;

            int startColumn = (int)Math.Floor((double)(((bounds.LeftBottom.X - x) + (resolution * 0.5)) / (resolution * this.TileSize)));
            int startRow = (int)Math.Floor((double)(((y - bounds.RightTop.Y) + (resolution * 0.5)) / (resolution * this.TileSize)));
            startColumn = (startColumn < 0) ? 0 : startColumn;
            startRow = (startColumn < 0) ? 0 : startRow;
            int endColumn = (int)Math.Floor((double)(((bounds.RightTop.X - x) - (resolution * 0.5)) / (resolution * this.TileSize)));
            int endRow = (int)Math.Floor((double)(((y - bounds.LeftBottom.Y) - (resolution * 0.5)) / (resolution * this.TileSize)));
            return new int[] { startColumn, startRow, endColumn, endRow };
        }
    }

    public class TileCachediServerLayer : TileLayer
    {
        public TileCachediServerLayer()
        {

        }

        public string Url { get; set; }
        public string MapName { get; set; }
        public double[] Resolutions { get; set; }

        public override void Initialize()
        {
            if (string.IsNullOrWhiteSpace(Url) || string.IsNullOrWhiteSpace(MapName))
            {
                return;
            }
            if (System.Windows.Deployment.Current.Dispatcher.CheckAccess())
            {
                ThreadStart threadStart = () =>
                {
                    Map map = new Map(Url);
                    MapParameter defaultMapParameter = map.GetDefaultMapParameter(MapName);
                    this.Bounds = new Rectangle2D(defaultMapParameter.Bounds);
                    this.MapName = defaultMapParameter.Name;
                    this.ViewBounds = new Rectangle2D(defaultMapParameter.ViewBounds);
                    this.Origin = new Point2D(Bounds.LeftBottom.X, Bounds.RightTop.Y);
                    this.Scale = defaultMapParameter.Scale;
                    this.TileSize = 256;
                    this.Resolution = (defaultMapParameter.ViewBounds.RightTop.X - defaultMapParameter.ViewBounds.LeftBottom.X) / defaultMapParameter.Viewer.Width;
                    this.IsInitialized = true;
                    this.IsInitializing = false;
                    this.OnInitialized();
                };

                Thread thread = new Thread(threadStart);
                thread.Start();
            }
            this.IsInitializing = true;
            base.Initialize();
        }

        public override string GetTileUrl(int x, int y, double resolution)
        {
            //throw new NotImplementedException();
            Map map = new Map(Url);
            TileInfo iserverTileInfo = new TileInfo();
            iserverTileInfo.Height = Convert.ToUInt32(this.TileSize);
            iserverTileInfo.Width = Convert.ToUInt32(this.TileSize);;
            iserverTileInfo.TileIndex = new SuperMap.Connector.Utility.TileIndex();
            iserverTileInfo.TileIndex.ColIndex = x;
            iserverTileInfo.TileIndex.RowIndex = y;
            iserverTileInfo.Scale = this.Scale;

            SuperMap.Connector.Utility.ImageOutputOption option = new SuperMap.Connector.Utility.ImageOutputOption();
            option.ImageReturnType = SuperMap.Connector.Utility.ImageReturnType.URL;
            option.ImageOutputFormat = SuperMap.Connector.Utility.ImageOutputFormat.PNG;
            option.Transparent = false;

            MapImage img = map.GetTile(MapName, iserverTileInfo, option);
            return img.ImageUrl;
        }
    }
}
