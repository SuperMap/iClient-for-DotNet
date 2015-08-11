using System;
using System.Collections.Generic;
using System.Text;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.Projections;
using System.Globalization;
using GMap.NET.Internals;
using SuperMap.Connector.Utility;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace SuperMap.Connector.Control.Utility
{
    /// <summary>
    /// SuperMap iServer 6R(2012) provider 
    /// <remarks>
    /// 暂只支持SuperMap iServer 6R中发布的Mercator投影的地图。
    /// </remarks>
    /// </summary>
    internal class SuperMapProvider : GMapProvider
    {
        //public SuperMapProvider(string serviceUrl, string mapName, uint tileSize, string format, MapParameter mapParameter)
        //{
        //    Copyright = string.Format("© SuperMap iServer 6R(2012) - Map data ©{0} SuperMap iServer 6R(2012)", DateTime.Today.Year);

        //    this._serviceUrl = serviceUrl;
        //    this._tileSize = tileSize;
        //    this._mapName = mapName;
        //    this._mapParameter = mapParameter;
        //    this._map = new SuperMap.Connector.Map(serviceUrl);

        //    MapParameter defaultMapParameter = this._map.GetDefaultMapParameter(mapName);
        //}

        public SuperMapProvider(string serviceUrl, string mapName, double[] mapScales)
        {
            Copyright = string.Format("© SuperMap iServer 6R(2012) - Map data ©{0} SuperMap iServer 6R(2012)", DateTime.Today.Year);
            this._map = new SuperMap.Connector.Map(serviceUrl);
            this._serviceUrl = serviceUrl;
            this._mapName = mapName;
            MapParameter defaultMapParameter = this._map.GetDefaultMapParameter(mapName);
            this._defaultMapCenter = new Point2D(defaultMapParameter.Center);
            _mapScales = mapScales;
            _projection = new SuperMapProjection(mapScales, defaultMapParameter);
        }

        public SuperMapProvider(string serviceUrl, string mapName, int scaleCount, int defaultScaleIndex = 0)
        {
            if (scaleCount < 1 || defaultScaleIndex > scaleCount - 1 || defaultScaleIndex < 0)
                throw new ArgumentException();
            Copyright = string.Format("© SuperMap iServer 6R(2012) - Map data ©{0} SuperMap iServer 6R(2012)", DateTime.Today.Year);
            this._map = new SuperMap.Connector.Map(serviceUrl);
            this._serviceUrl = serviceUrl;
            this._mapName = mapName;
            MapParameter defaultMapParameter = this._map.GetDefaultMapParameter(mapName);
            this._defaultMapCenter = new Point2D(defaultMapParameter.Center);
            double[] mapScales = new double[scaleCount];
            mapScales[defaultScaleIndex] = defaultMapParameter.Scale;
            for (int i = defaultScaleIndex - 1; i >= 0; i--)
            {
                mapScales[i] = mapScales[i + 1] / 2;
            }
            for (int i = defaultScaleIndex + 1; i < scaleCount; i++)
            {
                mapScales[i] = mapScales[i - 1] * 2;
            }
            _mapScales = mapScales;
            _projection = new SuperMapProjection(mapScales, defaultMapParameter);
        }

        private double[] _mapScales = null;
        public double[] MapScales
        {
            get { return this._mapScales; }
        }
        private SuperMapProjection _projection = null;
        public override PureProjection Projection
        {
            get { return _projection; }
        }

        private Point2D _defaultMapCenter = null;
        public Point2D DefaultMapCenter
        {
            get { return _defaultMapCenter; }
        }
        ///// <summary>
        ///// SuperMap iServer 6R使用默认的dpi 76.2时，在mecartor投影下对应的比例尺倒数为
        /////比例尺=1: 地面分辨率(a)*屏幕分辨率(pixel/inch)/0.0254(m/inch)
        /////地面分辨率(a)是指一个像素(pixel)所代表的实际地面距离(m)
        /////屏幕分辨率(dpi)是指屏幕上每英寸长度内包含的像素数量，默认是96dpi（pixel/inch）
        /////0.0254(m/inch)是指米与英寸的单位转换
        /////最终，此公式可以简写为：比例尺=0.0254/(a*96)。
        /////Mercator投影下全幅地图的范围为20037508.3427892*2，
        /////第一级别下 分辨率resolution=20037508.3427892*2/512
        /////scale=0.0254/(resolution*76.2);
        ///// </summary>
        //    private double[] _scales = new double[] { 1/234814550.8920609375, 1/117407275.44603046875,
        //        1/58703637.723015234375, 1/29351818.8615076171875, 1/14675909.43075380859375,
        //       1/7337954.715376904296875,1/3668977.3576884521484375 ,1/1834488.67884422607421875,
        //      1/917244.339422113037109375,1/458622.1697110565185546875,1/229311.08485552825927734375,1/114655.542427764129638671875,
        //    1/57327.7712138820648193359375,1/28663.88560694103240966796875,1/14331.942803470516204833984375,1/7165.9714017352581024169921875,
        //1/3582.98570086762905120849609375,1/1791.492850433814525604248046875,1/895.7464252169072628021240234375,1/447.87321260845363140106201171875};
        //private double[] _scales
        //{
        //    get
        //    {
        //        double[] tempScales = new double[19];
        //        double baseScale = 0.0254 / (20037508.3427892 * 2 / 512 * 96);
        //        tempScales[0] = baseScale;
        //        for (int i = 1; i < 19; i++)
        //        {
        //            tempScales[i] = tempScales[i - 1] * 2;
        //        }
        //        return tempScales;
        //    }
        //}


        private string _serviceUrl = string.Empty;
        public string ServiceUrl
        {
            get
            {
                return this._serviceUrl;
            }
        }

        private string _mapName = string.Empty;
        public string MapName
        {
            get
            {
                return this._mapName;
            }
        }

        private SuperMap.Connector.Map _map;

        private uint _tileSize = 256;
        public uint TileSize
        {
            get
            {
                return this._tileSize;
            }
        }

        //private SuperMap.Connector.Utility.MapParameter _mapParameter = null;
        //public SuperMap.Connector.Utility.MapParameter MapParameter
        //{
        //    get
        //    {
        //        return this._mapParameter;
        //    }
        //}

        private string MakeTileImageUrl(GPoint pos, int zoom, string language)
        {
            double scale = _mapScales[zoom];
            SuperMap.Connector.Utility.ImageOutputOption option = new SuperMap.Connector.Utility.ImageOutputOption();
            option.ImageReturnType = SuperMap.Connector.Utility.ImageReturnType.URL;
            option.ImageOutputFormat = SuperMap.Connector.Utility.ImageOutputFormat.PNG;
            option.Transparent = false;
            SuperMap.Connector.Utility.TileInfo iserverTileInfo = new SuperMap.Connector.Utility.TileInfo();
            iserverTileInfo.Height = TileSize;
            iserverTileInfo.Width = TileSize;
            iserverTileInfo.TileIndex = new SuperMap.Connector.Utility.TileIndex();
            iserverTileInfo.TileIndex.ColIndex = (int)(pos.X);
            iserverTileInfo.TileIndex.RowIndex = (int)pos.Y;
            iserverTileInfo.Scale = scale;

            MapImage mapImage = _map.GetTile(this.MapName, iserverTileInfo, option);
            return mapImage.ImageUrl;
        }

        public override PureImage GetTileImage(GPoint pos, int zoom)
        {
            string url = MakeTileImageUrl(pos, zoom, string.Empty);
            PureImage image = GetTileImageUsingHttp(url);
            return image;
        }

        public static Dictionary<int, Guid> _guidHashTable = new Dictionary<int, Guid>();
        private static object _guidHashTableLock = new object();
        /// <summary>
        /// 内存和本地guid.dat文件中都保留一份。
        /// </summary>
        public override Guid Id
        {
            get
            {
                Guid guid = Guid.Empty;
                string key = this._serviceUrl + "_" + this._mapName;
                if (key == "_") return Guid.NewGuid();
                int hashKey = key.GetHashCode();
                if (_guidHashTable.ContainsKey(hashKey))
                {
                    guid = _guidHashTable[hashKey];
                }
                else
                {
                    lock (_guidHashTableLock)
                    {
                        if (_guidHashTable.ContainsKey(hashKey)) guid = _guidHashTable[hashKey];
                        else
                        {
                            bool bNew = false;
                            string path = Environment.CurrentDirectory + "\\guid.dat";
                            if (File.Exists(path))
                            {
                                using (StreamReader sr = File.OpenText(path))
                                {
                                    string s = "";
                                    while ((s = sr.ReadLine()) != null)
                                    {
                                        string[] keyValues = s.Split(new char[] { ':' });
                                        string itemKey = keyValues[0];
                                        Guid itemValue = new Guid(keyValues[1]);
                                        if (!_guidHashTable.ContainsKey(int.Parse(itemKey)))
                                        {
                                            _guidHashTable.Add(int.Parse(itemKey), itemValue);
                                        }
                                    }
                                    if (!_guidHashTable.ContainsKey(hashKey))
                                    {
                                        bNew = true;
                                    }
                                    else
                                        guid = _guidHashTable[hashKey];
                                }
                            }
                            else
                            {
                                try
                                {
                                    using (File.Create(path))
                                    { }
                                }
                                catch (UnauthorizedAccessException e)
                                {
                                    Debug.WriteLine(e.Message);
                                }
                                bNew = true;
                            }
                            if (bNew)
                            {
                                guid = Guid.NewGuid();
                                _guidHashTable.Add(hashKey, guid);
                                File.AppendAllLines(path, new string[] { hashKey + ":" + guid.ToString() });
                            }
                        }
                    }
                }
                return guid;
            }
        }

        public override string Name
        {
            get { return "SuperMap iServer 6R (2012)"; }
        }

        private GMapProvider[] _overlays;
        public override GMapProvider[] Overlays
        {
            get
            {
                if (_overlays == null)
                {
                    _overlays = new GMapProvider[] { this };
                }
                return _overlays;
            }
        }
    }

    internal class SuperMapCloudProvider : GMapProvider
    {
        public SuperMapCloudProvider()
        {
            Copyright = string.Format("SuperMapCloud");
        }

        private Guid _id = new Guid("8EEB48DA-6D2F-44BA-8BEF-31D0796CA5E7");
        public override Guid Id
        {
            get { return _id; }
        }

        public override string Name
        {
            get { return "SuperMapCloud"; }
        }

        public override PureProjection Projection
        {
            get { return MercatorProjection.Instance; }
        }

        private GMapProvider[] overlays = null;
        public override GMapProvider[] Overlays
        {
            get
            {
                if (overlays == null)
                {
                    overlays = new GMapProvider[] { this };
                }
                return overlays;
            }
        }

        private double[] _scales
        {
            get
            {
                double[] scales = new double[18];
                scales[0] = 470000000;
                for (int i = 1; i < 18; i++)
                {
                    scales[i] = scales[i - 1] / 2;
                }
                return scales;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="zoom"></param>
        /// <returns></returns>
        public override PureImage GetTileImage(GPoint pos, int zoom)
        {
            string url = string.Format("http://www.supermapcloud.com/output/cache/quanguo_256x256/{0}/{1}/{2}", _scales[zoom], pos.X, pos.Y);
            return GetTileImageUsingHttp(url);
        }
    }
}
