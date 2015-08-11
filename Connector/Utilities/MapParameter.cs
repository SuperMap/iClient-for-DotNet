using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 地图参数。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    [JsonConverter(typeof(MapParameterConverter))]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public class MapParameter
    {
        ///<summary>
        ///目标地图名称。
        ///</summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 地图二维中心点坐标。
        /// </summary>
        [JsonProperty("center")]
        public Point2D Center { get; set; }

        /// <summary>
        /// 地图的显示比例尺。
        /// </summary>
        [JsonProperty("scale")]
        public double Scale { get; set; }

        /// <summary>
        /// 地图的最大显示比例尺。
        /// </summary>
        [JsonProperty("maxScale")]
        public double MaxScale { get; set; }

        /// <summary>
        /// 地图的最小显示比例尺。
        /// </summary>
        [JsonProperty("minScale")]
        public double MinScale { get; set; }

        /// <summary>
        /// 当前地图的旋转角度。
        /// </summary>
        [JsonProperty("angle")]
        public double Angle { get; set; }

        /// <summary>
        /// 是否反走样地图。
        /// </summary>
        [JsonProperty("antialias")]
        public bool Antialias { get; set; }

        /// <summary>
        /// 地图的背景风格。
        /// </summary>
        [JsonProperty("backgroundStyle")]
        public Style BackgroundStyle { get; set; }

        /// <summary>
        /// 地图的全幅范围。
        /// </summary>
        [JsonProperty("bounds")]
        public Rectangle2D Bounds { get; set; }

        /// <summary>
        /// 地图显示裁剪的区域。
        /// </summary>
        [JsonProperty("clipRegion")]
        public Geometry ClipRegion { get; set; }

        private MapColorMode _colorMode = MapColorMode.DEFAULT;
        /// <summary>
        /// 地图的颜色模式。
        /// </summary>
        [JsonProperty("colorMode")]
        public MapColorMode ColorMode
        {
            get { return this._colorMode; }
            set { this._colorMode = value; }
        }

        /// <summary>
        /// 地图显示裁剪区域是否有效。
        /// </summary>
        [JsonProperty("clipRegionEnabled")]
        public bool ClipRegionEnabled { get; set; }

        private int _maxVisibleVertex = 3600000;
        /// <summary>
        ///  最大几何对象可见节点数，如果几何对象的节点数超过指定的个数，则超过的那部分节点不显示。默认为3600000。
        /// </summary>
        [JsonProperty("maxVisibleVertex")]
        public int MaxVisibleVertex
        {
            get { return this._maxVisibleVertex; }
            set { this._maxVisibleVertex = value; }
        }

        private Unit _coordUnit = Unit.METER;
        /// <summary>
        /// 地图的坐标单位。默认为米。
        /// </summary>
        [JsonProperty("coordUnit")]
        public Unit CoordUnit
        {
            get { return this._coordUnit; }
            set { this._coordUnit = value; }
        }
        /// <summary>
        /// 校验方式。
        /// </summary>
        [JsonProperty("rectifyType")]
        public RectifyType RectifyType { get; set; }

        /// <summary>
        /// 自定义的地图全幅显示范围。
        /// </summary>
        [JsonProperty("customEntireBounds")]
        public Rectangle2D CustomEntireBounds { get; set; }

        /// <summary>
        ///  自定义的地图全幅显示范围是否有效。
        /// </summary>
        [JsonProperty("customEntireBoundsEnabled")]
        public bool CustomEntireBoundsEnabled { get; set; }

        /// <summary>
        /// 用户自定义参数。
        /// </summary>
        [JsonProperty("customParams")]
        public string CustomParams { get; set; }

        /// <summary>
        ///  当前地图的描述信息。
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// 地图的距离量度单位。
        /// </summary>
        [JsonProperty("distanceUnit")]
        public Unit DistanceUnit { get; set; }

        private bool _dynamicProjection = true;
        /// <summary>
        /// 是否允许地图动态投影显示。默认为true。
        /// </summary>
        [JsonProperty("dynamicProjection")]
        public bool DynamicProjection
        {
            get { return _dynamicProjection; }
            set { _dynamicProjection = value; }
        }

        /// <summary>
        /// 指定点状符号的角度是否固定。
        /// </summary>
        [JsonProperty("markerAngleFixed")]
        public bool MarkerAngleFixed { get; set; }

        private double _maxVisibleTextSize = 1000;
        /// <summary>
        ///  文本的最大可见尺寸，单位为毫米。
        /// </summary>
        [JsonProperty("maxVisibleTextSize")]
        public double MaxVisibleTextSize
        {
            get { return _maxVisibleTextSize; }
            set { _maxVisibleTextSize = value; }
        }

        private double _minVisibleTextSize = 0.1;
        /// <summary>
        /// 文本的最小可见尺寸，单位为毫米。
        /// </summary>
        [JsonProperty("minVisibleTextSize")]
        public double MinVisibleTextSize
        {
            get { return _minVisibleTextSize; }
            set { _minVisibleTextSize = value; }
        }

        /// <summary>       
        /// 重叠时是否显示对象。
        /// </summary>
        [JsonProperty("overlapDisplayed")]
        public bool OverlapDisplayed { get; set; }

        /// <summary>
        /// 是否绘制地图背景。
        /// </summary>
        [JsonProperty("paintBackground")]
        public bool PaintBackground { set; get; }

        /// <summary>
        /// 文本角度是否固定。
        /// </summary>
        [JsonProperty("textAngleFixed")]
        public bool TextAngleFixed { get; set; }

        /// <summary>
        /// 文本朝向是否固定。
        /// </summary>
        [JsonProperty("textOrientationFixed")]
        public bool TextOrientationFixed { get; set; }

        /// <summary>
        /// 地图坐标系统（投影系统）。
        /// </summary>
        /// <remarks>设置投影坐标系时，需按照PrjCoordSys中的字段结构来构建，同时也支持通过只设置EpsgCode属性值的方式传入坐标参考系，用来对请求地图。</remarks>
        /// <example>请参见<see cref="SuperMap.Connector.Utility.PrjCoordSys"/></example>
        [JsonProperty("prjCoordSys")]
        public PrjCoordSys PrjCoordSys { get; set; }

        /// <summary>
        /// 视窗（viewer，地图图片范围）对应的地图范围。
        /// </summary>
        [JsonProperty("viewBounds")]
        public Rectangle2D ViewBounds { get; set; }

        /// <summary>
        /// 视窗。
        /// </summary>
        [JsonProperty("viewer")]
        public Rectangle Viewer { get; set; }

        /// <summary>
        /// 是否使用缓存。
        /// </summary>
        [JsonProperty("cacheEnabled")]
        public bool CacheEnabled { get; set; }

        /// <summary>
        /// 用户信息。
        /// </summary>
        [JsonProperty("userToken")]
        public UserInfo UserToken { get; set; }

        /// <summary>
        /// 地图中所有图层列表。
        /// </summary>
        [JsonProperty("layers")]
        public List<Layer> Layers { get; set; }
    }
}
