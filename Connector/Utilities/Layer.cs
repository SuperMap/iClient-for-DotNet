using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Collections;
using System.Runtime.Serialization;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 图层类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    [JsonConverter(typeof(LayerConverter))]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public class Layer //: ISerializable
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public Layer()
        {

        }

        /// <summary>
        /// 拷贝的构造函数。
        /// </summary>
        /// <param name="layer"></param>
        public Layer(Layer layer)
        {
            if (layer == null) throw new ArgumentNullException();
            this.Bounds = new Rectangle2D(layer.Bounds);
            this.Caption = layer.Caption;
            this.Description = layer.Description;
            this.Name = layer.Name;
            this.Queryable = layer.Queryable;
            this.SubLayers = new LayerCollection();
        }

        ///<summary>
        /// 图层范围。
        ///</summary>
        [JsonProperty("bounds")]
        public Rectangle2D Bounds { get; set; }

        /// <summary>
        /// 图层的标题。 
        /// </summary>
        [JsonProperty("caption")]
        public string Caption { get; set; }

        /// <summary>
        /// 图层的描述信息。
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// 图层的名称。
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 图层中的对象是否可以查询。
        /// </summary>
        [JsonProperty("queryable")]
        public bool Queryable { get; set; }

        /// <summary>
        /// 子图层集。
        /// </summary>
        [JsonProperty("subLayers")]
        public LayerCollection SubLayers { get; set; }

        /// <summary>
        /// 图层类型。
        /// </summary>
        [JsonProperty("type")]
        public LayerType Type { get; set; }

        /// <summary>
        /// 图层是否可视。
        /// </summary>
        [JsonProperty("visible")]
        public bool Visible { get; set; }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected Layer(SerializationInfo info, StreamingContext context)
        {
            this.Bounds = (Rectangle2D)info.GetValue("Bounds", typeof(Rectangle2D));
            this.Caption = info.GetString("Caption");
            this.Description = info.GetString("Description");
            this.Name = info.GetString("Name");
            this.Queryable = info.GetBoolean("Queryable");
            this.SubLayers = (LayerCollection)info.GetValue("SubLayers", typeof(LayerCollection));
            this.Type = (LayerType)info.GetValue("Type", typeof(LayerType));
            this.Visible = info.GetBoolean("Visible");
        }

        /// <summary>
        /// 实现自 <see cref="System.Runtime.Serialization.ISerializable"/> 接口。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Bounds", this.Bounds);
            info.AddValue("Caption", this.Caption);
            info.AddValue("Description", this.Description);
            info.AddValue("Name", this.Name);
            info.AddValue("Queryable", this.Queryable);
            info.AddValue("SubLayers", this.SubLayers);
            info.AddValue("Type", this.Type);
            info.AddValue("Visible", this.Visible);
        }
        #endregion
#endif
    }

    /// <summary>
    /// SuperMap 地图图层类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    [JsonConverter(typeof(UGCMapLayerConverter))]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public class UGCMapLayer : Layer
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public UGCMapLayer()
            : base()
        {
            this.Type = LayerType.UGC;
        }

        /// <summary>
        /// 是否显示完整线型。
        /// </summary>
        [JsonProperty("completeLineSymbolDisplayed")]
        public bool CompleteLineSymbolDisplayed { get; set; }

        /// <summary>
        /// 地图最大比例尺。
        /// </summary>
        [JsonProperty("maxScale")]
        public double MaxScale { get; set; }

        /// <summary>
        /// 地图最小比例尺。
        /// </summary>
        [JsonProperty("minScale")]
        public double MinScale { get; set; }

        /// <summary>
        /// 几何对象的最小可见大小，以像素为单位。
        /// </summary>
        [JsonProperty("minVisibleGeometrySize")]
        public double MinVisibleGeometrySize { get; set; }

        private int _opaqueRate = 100;
        /// <summary>
        /// 图层的不透明度。
        /// </summary>
        [JsonProperty("opaqueRate")]
        public int OpaqueRate
        {
            get { return this._opaqueRate; }
            set { this._opaqueRate = value; }
        }

        /// <summary>
        /// 是否允许图层的符号大小随图缩放。
        /// </summary>
        [JsonProperty("symbolScalable")]
        public bool SymbolScalable { get; set; }

        /// <summary>
        /// 图层的符号缩放基准比例尺。
        /// </summary>
        [JsonProperty("symbolScale")]
        public double SymbolScale { get; set; }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected UGCMapLayer(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.CompleteLineSymbolDisplayed = info.GetBoolean("CompleteLineSymbolDisplayed");
            this.MaxScale = info.GetDouble("MaxScale");
            this.MinScale = info.GetDouble("MinScale");
            this.MinVisibleGeometrySize = info.GetDouble("MinVisibleGeometrySize");
            this.OpaqueRate = info.GetInt32("OpaqueRate");
            this.SymbolScalable = info.GetBoolean("SymbolScalable");
            this.SymbolScale = info.GetDouble("SymbolScale");
        }

        /// <summary>
        /// 实现自 <see cref="System.Runtime.Serialization.ISerializable"/> 接口。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("CompleteLineSymbolDisplayed", this.CompleteLineSymbolDisplayed);
            info.AddValue("MaxScale", this.MaxScale);
            info.AddValue("MinScale", this.MinScale);
            info.AddValue("MinVisibleGeometrySize", this.MinVisibleGeometrySize);
            info.AddValue("OpaqueRate", this.OpaqueRate);
            info.AddValue("SymbolScalable", this.SymbolScalable);
            info.AddValue("SymbolScale", this.SymbolScale);
            base.GetObjectData(info, context);
        }

        #endregion
#endif
    }

    /// <summary>
    /// UGC 图层类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    [JsonConverter(typeof(LayerConverter))]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public class UGCLayer : UGCMapLayer
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public UGCLayer()
            : base()
        { }

        /// <summary>
        ///数据集信息。
        /// </summary>
        [JsonProperty("datasetInfo")]
        public DatasetInfo DatasetInfo { get; set; }

        /// <summary>
        /// 图层显示过滤条件。
        /// </summary>
        [JsonProperty("displayFilter")]
        public string DisplayFilter { get; set; }

        /// <summary>
        /// 连接信息类。
        /// </summary>
        [JsonProperty("joinItems")]
        public JoinItem[] JoinItems { get; set; }

        /// <summary>
        /// 存储制图表达信息的字段。
        /// </summary>
        [JsonProperty("representationField")]
        public string RepresentationField { get; set; }

        /// <summary>
        /// 图层类型。
        /// </summary>
        [JsonProperty("ugcLayerType")]
        public Utility.UGCLayerType UgcLayerType { get; set; }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected UGCLayer(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.DatasetInfo = (DatasetInfo)info.GetValue("DatasetInfo", typeof(DatasetInfo));
            this.DisplayFilter = info.GetString("DisplayFilter");
            this.JoinItems = (JoinItem[])info.GetValue("JoinItems", typeof(JoinItem[]));
            this.RepresentationField = info.GetString("RepresentationField");
            this.UgcLayerType = (UGCLayerType)info.GetValue("UgcLayerType", typeof(UGCLayerType));
        }

        /// <summary>
        /// 实现自 <see cref="System.Runtime.Serialization.ISerializable"/> 接口。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("DatasetInfo", this.DatasetInfo);
            info.AddValue("DisplayFilter", this.DisplayFilter);
            info.AddValue("JoinItems", this.JoinItems);
            info.AddValue("RepresentationField", this.RepresentationField);
            info.AddValue("UgcLayerType", this.UgcLayerType);
            base.GetObjectData(info, context);
        }
        #endregion
#endif
    }


    /// <summary>
    /// UGC 专题图图层类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    [JsonConverter(typeof(UGCThemeLayerConverter))]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public class UGCThemeLayer : UGCLayer
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public UGCThemeLayer()
            : base()
        {
            this.UgcLayerType = UGCLayerType.THEME;
        }

        /// <summary>
        /// 专题图对象。
        /// </summary>
        [JsonProperty("theme")]
        public Theme Theme { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("themeElementPosition")]
        public Dictionary<int, Point2D> ThemeElementPosition { get; set; }
    }

    /// <summary>
    /// UGC 影像图层类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    [JsonConverter(typeof(LayerConverter))]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public class UGCImageLayer : UGCLayer
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public UGCImageLayer()
            : base()
        {
            this.UgcLayerType = UGCLayerType.IMAGE;
        }

        /// <summary>
        /// 影像图层的亮度。
        /// </summary>
        [JsonProperty("brightness")]
        public int Brightness { get; set; }

        /// <summary>
        /// 返回影像图层的色彩显示模式。
        /// </summary>
        [JsonProperty("colorSpaceType")]
        public ColorSpaceType ColorSpaceType { get; set; }

        /// <summary>
        /// 影像图层的对比度。
        /// </summary>
        [JsonProperty("contrast")]
        public int Contrast { get; set; }

        /// <summary>
        /// 返回当前影像图层显示的波段索引。
        /// </summary>
        [JsonProperty("displayBandIndexes")]
        public int[] DisplayBandIndexes { get; set; }

        /// <summary>
        /// 是否背景透明。
        /// </summary>
        [JsonProperty("transparent")]
        public bool Transparent { get; set; }

        /// <summary>
        /// 返回背景透明色。
        /// </summary>
        [JsonProperty("transparentColor")]
        public Color TransparentColor { get; set; }
    }

    /// <summary>
    /// UGC 矢量图层类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    [JsonConverter(typeof(LayerConverter))]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public class UGCVectorLayer : UGCLayer
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public UGCVectorLayer()
            : base()
        {
            this.UgcLayerType = UGCLayerType.VECTOR;
        }

        /// <summary>
        /// 矢量图层的风格。
        /// </summary>
        [JsonProperty("style")]
        public Style Style { get; set; }
    }

    /// <summary>
    /// UGC 栅格图层类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    [JsonConverter(typeof(LayerConverter))]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public class UGCGridLayer : UGCLayer
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public UGCGridLayer()
            : base()
        {
            this.UgcLayerType = UGCLayerType.GRID;
        }

        /// <summary>
        /// UGC 栅格图层的颜色渐变类型。
        /// </summary>
        [JsonProperty("colorGradientType")]
        public ColorGradientType ColorGradientType { get; set; }

        /// <summary>
        /// 颜色表对象。
        /// </summary>
        [JsonProperty("colors")]
        public Color[] Colors { get; set; }

        /// <summary>
        /// 格网虚线的样式。
        /// </summary>
        [JsonProperty("dashStyle")]
        public Style DashStyle { get; set; }

        /// <summary>
        /// 格网类型。
        /// </summary>
        [JsonProperty("gridType")]
        public GridType GridType { get; set; }

        /// <summary>
        /// 格网水平间隔大小。
        /// </summary>
        [JsonProperty("horizontalSpacing")]
        public double HorizontalSpacing { get; set; }

        /// <summary>
        /// 格网是否固定大小，如果不固定大小，则格网随着地图缩放。
        /// </summary>
        [JsonProperty("sizeFixed")]
        public bool SizeFixed { get; set; }

        /// <summary>
        ///  格网实线的样式。
        /// </summary>
        [JsonProperty("solidStyle")]
        public Style SolidStyle { get; set; }

        /// <summary>
        /// 栅格数据集无值数据的颜色。
        /// </summary>
        [JsonProperty("specialColor")]
        public Color SpecialColor { get; set; }

        /// <summary>
        /// 图层的特殊值。
        /// </summary>
        [JsonProperty("specialValue")]
        public double SpecialValue { get; set; }

        /// <summary>
        /// 格网垂直间隔大小。
        /// </summary>
        [JsonProperty("verticalSpacing")]
        public double VerticalSpacing { get; set; }
    }

    /// <summary>
    /// WMS 图层的设置类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    [JsonConverter(typeof(LayerConverter))]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public class WMSLayer : Layer
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public WMSLayer()
        {
            this.Type = LayerType.WMS;
        }

        /// <summary>
        /// 拷贝的构造函数。
        /// </summary>
        /// <param name="wmsLayer">WMSLayer实例。</param>
        public WMSLayer(WMSLayer wmsLayer)
            : base(wmsLayer)
        {
            if (wmsLayer == null) throw new ArgumentNullException();
            this.Exceptions = wmsLayer.Exceptions;
            this.Format = wmsLayer.Format;
            this.Request = wmsLayer.Request;
            this.Service = wmsLayer.Service;
            this.Styles = wmsLayer.Styles;
            this.Title = wmsLayer.Title;
            this.Url = wmsLayer.Url;
            this.Version = wmsLayer.Version;
        }

        /// <summary>
        ///   返回的异常信息的格式。 
        /// </summary>
        [JsonProperty("exceptions")]
        public string Exceptions { get; set; }

        /// <summary>
        /// 输出图像格式。
        /// </summary>
        [JsonProperty("format")]
        public string Format { get; set; }

        /// <summary>
        /// 请求 WMS 服务的操作名称。 
        /// </summary>
        [JsonProperty("request")]
        public string Request { get; set; }

        /// <summary>
        /// WMS 服务名称。 
        /// </summary>
        [JsonProperty("service")]
        public string Service { get; set; }

        /// <summary>
        /// 地图样式。 
        /// </summary>
        [JsonProperty("styles")]
        public string Styles { get; set; }

        /// <summary>
        ///  WMS 服务的主题。 
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        ///    WMS 服务的 URL 地址。
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// WMS 的版本号。 
        /// </summary>
        [JsonProperty("version")]
        public string Version { get; set; }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        private WMSLayer(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.Exceptions = info.GetString("Exceptions");
            this.Format = info.GetString("Format");
            this.Request = info.GetString("Request");
            this.Service = info.GetString("Service");
            this.Styles = info.GetString("Styles");
            this.Title = info.GetString("Title");
            this.Url = info.GetString("Url");
            this.Version = info.GetString("Version");
        }

        /// <summary>
        /// 实现自 <see cref="System.Runtime.Serialization.ISerializable"/> 接口。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Exceptions", this.Exceptions);
            info.AddValue("Format", this.Format);
            info.AddValue("Request", this.Request);
            info.AddValue("Service", this.Service);
            info.AddValue("Styles", this.Styles);
            info.AddValue("Title", this.Title);
            info.AddValue("Url", this.Url);
            info.AddValue("Version", this.Version);
            base.GetObjectData(info, context);
        }
        #endregion
#endif
    }

    /// <summary>
    /// WFS 图层的设置类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    [JsonConverter(typeof(LayerConverter))]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public class WFSLayer : Layer
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public WFSLayer()
        {
            this.Type = LayerType.WFS;
        }

        /// <summary>
        /// 拷贝的构造函数。
        /// </summary>
        /// <param name="wfsLayer">WFSLayer实例。</param>
        public WFSLayer(WFSLayer wfsLayer)
            : base(wfsLayer)
        {
            if (wfsLayer == null) throw new ArgumentNullException();
            this.Request = wfsLayer.Request;
            this.Service = wfsLayer.Request;
            this.TypeName = wfsLayer.TypeName;
            this.Url = wfsLayer.Url;
            this.Version = wfsLayer.Version;
        }

        /// <summary>
        /// 请求 WFS 服务的操作名称。 
        /// </summary>
        [JsonProperty("request")]
        public string Request { get; set; }

        /// <summary>
        /// WFS 服务名称。 
        /// </summary>
        [JsonProperty("service")]
        public string Service { get; set; }

        /// <summary>
        /// 查询的要素类型名称。 
        /// </summary>
        [JsonProperty("typeName")]
        public string TypeName { get; set; }

        /// <summary>
        /// WFS 服务的 URL 地址。 
        /// </summary>
        [JsonProperty("url")]
        public string Url { set; get; }

        /// <summary>
        ///WFS 的版本号。  
        /// </summary>
        [JsonProperty("version")]
        public string Version { get; set; }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        private WFSLayer(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.Request = info.GetString("Request");
            this.Service = info.GetString("Service");
            this.TypeName = info.GetString("TypeName");
            this.Url = info.GetString("Url");
            this.Version = info.GetString("Version");
        }

        /// <summary>
        /// 实现自 <see cref="System.Runtime.Serialization.ISerializable"/> 接口。
        /// </summary>
        /// <param name="info">要填充数据的SerializationInfo。</param>
        /// <param name="context">此序列化的目标。</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Request", this.Request);
            info.AddValue("Service", this.Service);
            info.AddValue("TypeName", this.TypeName);
            info.AddValue("Url", this.Url);
            info.AddValue("Version", this.Version);
            base.GetObjectData(info, context);
        }
        #endregion
#endif
    }

    /// <summary>
    /// 图层集合类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public sealed class LayerCollection : IEnumerable
#else
    [Serializable]
    public sealed class LayerCollection : IEnumerable, ISerializable
#endif
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public LayerCollection()
        {
            Layers = new List<Layer>();
        }

        ///// <summary>
        ///// 拷贝的构造函数。
        ///// </summary>
        ///// <param name="layers">图层集合类对象。</param>
        //public LayerCollection(LayerCollection layers)
        //{
        //    if (layers == null)
        //    {
        //        throw new ArgumentNullException();
        //    }
        //    this.Layers = new List<Layer>();
        //    for (int i = 0; i < layers.Count; i++)
        //    {
        //        if (layers[i] != null)
        //        {
        //            if (layers[i].Type == LayerType.UGC)
        //            {

        //            }
        //            else if (layers[i].Type == LayerType.WFS)
        //            {
        //                this.Layers.Add(new WFSLayer(layers[i] as WFSLayer));
        //            }
        //            else if (layers[i].Type == LayerType.WMS)
        //            {
        //                this.Layers.Add(new WMSLayer(layers[i] as WMSLayer));
        //            }
        //        }
        //        else
        //        {
        //            this.Layers.Add(null);
        //        }
        //    }
        //}

        /// <summary>
        /// 设置、获取图层集合。
        /// </summary>
        [JsonProperty("layers")]
        public List<Layer> Layers { get; set; }

        /// <summary>
        /// 获取图层的个数。
        /// </summary>
        [JsonIgnore()]
        public int Count
        {
            get
            {
                if (Layers != null)
                    return Layers.Count;
                else
                    throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// 往图层集中增加一个图层对象。
        /// </summary>
        /// <param name="item">图层对象。</param>
        public void Add(Layer item)
        {
            if (this.Layers != null)
                Layers.Add(item);
            else
                throw new ArgumentNullException();
        }

        /// <summary>
        /// 根据指定的索引将图层对象插入到指定的位置。
        /// </summary>
        /// <param name="index">图层索引。</param>
        /// <param name="item">图层对象。</param>
        public void Insert(int index, Layer item)
        {
            if (this.Layers != null)
                Layers.Insert(index, item);
            else
                throw new ArgumentNullException();
        }

        /// <summary>
        /// 根据索引获取对象。
        /// </summary>
        /// <param name="index">索引。</param>
        /// <returns>图层对象。</returns>
        public Layer this[int index]
        {
            get
            {
                if (this.Layers != null)
                    return Layers[index];
                else
                    throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// 移除指定位置的图层。
        /// </summary>
        /// <param name="index">移除索引号。</param>
        public void RemoveAt(int index)
        {
            if (this.Layers != null)
                Layers.RemoveAt(index);
            else
                throw new ArgumentNullException();
        }

        /// <summary>
        /// 清除集合中所有项。
        /// </summary>
        public void Clear()
        {
            if (this.Layers != null)
                Layers.Clear();
            else
                throw new ArgumentNullException();
        }

        /// <summary>
        /// 图层集合中是否包含指定的图层。
        /// </summary>
        /// <param name="item">指定的图层对象。</param>
        /// <returns>是否存在包含的图层。</returns>
        public bool Contains(Layer item)
        {
            if (this.Layers != null)
                return Layers.Contains(item);
            else
                throw new ArgumentNullException();
        }

        /// <summary>
        /// 搜索指定的对象，并返回整个 LayerCollection中第一个匹配项的从零开始的索引。
        /// </summary>
        /// <param name="item">查找的对象。</param>
        /// <returns>查找对象的索引。</returns>
        public int IndexOf(Layer item)
        {
            if (this.Layers != null)
                return Layers.IndexOf(item);
            else
                throw new ArgumentNullException();
        }

        /// <summary>
        /// 返回一个循环访问集合的枚举器。
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            if (Layers != null)
                return Layers.GetEnumerator();
            else
                throw new ArgumentNullException();
        }

#if !WINDOWS_PHONE
        #region 序列化/反序列化

        private LayerCollection(SerializationInfo info, StreamingContext context)
        {
            this.Layers = (List<Layer>)info.GetValue("Layers", typeof(List<Layer>));
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Layers", this.Layers);
        }
        #endregion
#endif
    }
}
