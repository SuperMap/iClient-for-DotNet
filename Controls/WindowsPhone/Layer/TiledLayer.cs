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
using SuperMap.Connector.Utility;
using System.Windows.Media.Imaging;

namespace SuperMap.Connector.Control.WindowsPhone
{
    public abstract class TiledLayer : Layer
    {
        public TiledLayer()
        {

        }

        public Point2D Origin { get; set; }
        public int TileSize { get; set; }

        public override void Draw()
        {
            this.LayerCanvas.Children.Clear();
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
                    //double left = ((this.Origin.X + ((TileSize * j) * Resolution)) - this.ViewBounds.LeftBottom.X) / Resolution;
                    //double top = (ViewBounds.RightTop.Y - (this.Origin.Y - ((TileSize * i) * Resolution))) / Resolution;
                    // double left = this.Origin.X + ((TileSize * tile.ColIndex) * this.Resolution);
                    //double top = this.Origin.Y - ((TileSize * tile.RowIndex) * resolution);
                    double left = this.Origin.X + Resolution * TileSize * tile.ColIndex;
                    double top = this.Origin.Y - Resolution * TileSize * tile.RowIndex;
                    double right = left + (this.TileSize * this.Resolution);
                    double bottom = top - (this.TileSize * this.Resolution);
                    LayerCanvas.SetExtent(tile.Image, new Rectangle2D(left, bottom, right, top));
                    //tile.Image.SetValue(Canvas.LeftProperty, left);
                    //tile.Image.SetValue(Canvas.TopProperty, top);
                    this.LayerCanvas.Children.Add(tile.Image);
                }
            }
        }

        private void AddTile(Tile tile)
        {
            if (!string.IsNullOrEmpty(tile.Url))
            {
                BitmapImage bitmapImage = new BitmapImage()
                {
                    UriSource = new Uri(tile.Url, UriKind.Absolute)
                };

                EventHandler<DownloadProgressEventArgs> onProgressEventHandler = null;
                onProgressEventHandler = delegate(object sender, DownloadProgressEventArgs e)
                {
                    //this.bmi_DownloadProgress(sender, e, tile, onProgressEventHandler);
                };
                bitmapImage.DownloadProgress += onProgressEventHandler;

                tile.Image = new Image
                {
                    Opacity = 0.0,
                    Tag = tile,
                    IsHitTestVisible = false,
                    // Name = uniqueLayerId + tile.TileKey,
                    Stretch = Stretch.Fill,
                    Source = bitmapImage
                };

                double resolution = tile.Resolution;
                //orginX originY
                double left = this.Origin.X + ((TileSize * tile.ColIndex) * resolution);
                double top = this.Origin.Y - ((TileSize * tile.RowIndex) * resolution);
                double right = left + (this.TileSize * resolution);
                double bottom = top - (this.TileSize * resolution);
                LayerCanvas.SetExtent(tile.Image, new Rectangle2D(left, bottom, right, top));//计算该image的范围

                tile.Image.ImageOpened += delegate(object o, RoutedEventArgs e)
                {
                    if (base.Dispatcher.CheckAccess())
                    {
                        Action a = delegate
                        {
                            //this.RaiseTileLoad(tile, new Rectangle2D(left, bottom, right, top));
                        };

                        this.Dispatcher.BeginInvoke(a);
                    }
                    else
                    {
                        //this.RaiseTileLoad(tile, new Rectangle2D(left, bottom, right, top));
                    }
                };
                //pendingTiles.Add(tile.Url, tile);
                base.LayerCanvas.Children.Add(tile.Image);
            }
        }

        public abstract string GetTileUrl(int x, int y, double resolution);

        private int[] GetTileSpanWithin(Rectangle2D bounds, double resolution)
        {
            double x = this.Origin.X;
            double y = this.Origin.Y;

            int startColumn1 = (int)Math.Floor((bounds.LeftBottom.X - x) / (resolution * this.TileSize));
            int startRow1 = (int)Math.Floor((y - bounds.RightTop.Y) / (resolution * this.TileSize));

            int startColumn = (int)Math.Floor((double)(((bounds.LeftBottom.X - x) + (resolution * 0.5)) / (resolution * this.TileSize)));
            int startRow = (int)Math.Floor((double)(((y - bounds.RightTop.Y) + (resolution * 0.5)) / (resolution * this.TileSize)));
            startColumn = (startColumn < 0) ? 0 : startColumn;
            startRow = (startColumn < 0) ? 0 : startRow;
            int endColumn = (int)Math.Floor((double)(((bounds.RightTop.X - x) - (resolution * 0.5)) / (resolution * this.TileSize)));
            int endRow = (int)Math.Floor((double)(((y - bounds.LeftBottom.Y) - (resolution * 0.5)) / (resolution * this.TileSize)));
            return new int[] { startColumn, startRow, endColumn, endRow };
        }
    }
}
