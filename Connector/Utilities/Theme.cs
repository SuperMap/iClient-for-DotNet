using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 专题图类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    [JsonConverter(typeof(ThemeConverter))]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public class Theme
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public Theme()
        { }

        /// <summary>
        ///  专题图内存数据。
        /// </summary>
        [JsonProperty("memoryData")]
        public Dictionary<string, string> MemoryData { get; set; }

        /// <summary>
        /// 专题图类型。
        /// </summary>
        [JsonProperty("type")]
        public ThemeType Type { get; set; }
    }

    /// <summary>
    /// 单值专题图类。
    /// </summary>
    /// <example>
    /// 以下是单值专题图的示范程序。
    /// <code>
    /// UGCThemeLayer uGCThemeLayer = new UGCThemeLayer();
    /// uGCThemeLayer.UgcLayerType = UGCLayerType.THEME;
    /// uGCThemeLayer.Caption = "单值专题图";
    /// uGCThemeLayer.Type = LayerType.UGC;
    /// uGCThemeLayer.DatasetInfo = new DatasetInfo();
    /// uGCThemeLayer.DatasetInfo.DataSourceName = "World";
    /// uGCThemeLayer.DatasetInfo.Name = "Countries";
    /// uGCThemeLayer.DatasetInfo.Type = DatasetType.REGION;
    /// ThemeUnique theme = new ThemeUnique();
    /// theme.Type = ThemeType.UNIQUE;
    /// theme.UniqueExpression = "COLOR_MAP";
    /// uGCThemeLayer.Theme = theme;
    /// uGCThemeLayer.Visible = true;
    /// </code>
    /// </example>
    [JsonObject(MemberSerialization.OptIn)]
    [JsonConverter(typeof(ThemeConverter))]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public class ThemeUnique : Theme
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public ThemeUnique()
            : base()
        {
            this.Type = ThemeType.UNIQUE;
        }

        /// <summary>
        /// 单值专题图的颜色渐变风格。
        /// </summary>
        [JsonProperty("colorGradientType")]
        public ColorGradientType ColorGradientType { get; set; }

        /// <summary>
        /// 单值专题图的默认风格。
        /// </summary>
        [JsonProperty("defaultStyle")]
        public Style DefaultStyle { get; set; }

        /// <summary>
        /// 单值专题图子项数组。
        /// </summary>
        [JsonProperty("items")]
        public ThemeUniqueItem[] Items { get; set; }

        /// <summary>
        /// 单值专题图字段表达式。
        /// </summary>
        [JsonProperty("uniqueExpression")]
        public string UniqueExpression { set; get; }
    }

    /// <summary>
    /// 单值专题图子项类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public class ThemeUniqueItem
    {
        /// <summary>
        /// 单值专题图子项的名称
        /// </summary>
        [JsonProperty("caption")]
        public string Caption { get; set; }

        /// <summary>
        /// 单值专题图子项的显示风格。
        /// </summary>
        [JsonProperty("style")]
        public Style Style { get; set; }

        /// <summary>
        /// 单值专题图子项的单值。
        /// </summary>
        [JsonProperty("unique")]
        public string Unique { get; set; }

        /// <summary>
        /// 单值专题图子项是否可见。
        /// </summary>
        [JsonProperty("visible")]
        public bool Visible { get; set; }
    }

    /// <summary>
    /// 标签专题图。
    /// </summary>
    /// <example>
    /// 以下是标签专题图的示范程序。
    /// <code>
    /// UGCThemeLayer uGCThemeLayer = new UGCThemeLayer();
    /// uGCThemeLayer.UgcLayerType = UGCLayerType.THEME;
    /// uGCThemeLayer.Caption = "标签专题图";
    /// uGCThemeLayer.Type = LayerType.UGC;
    /// uGCThemeLayer.DatasetInfo = new DatasetInfo();
    /// uGCThemeLayer.DatasetInfo.DataSourceName = "World";
    /// uGCThemeLayer.DatasetInfo.Name = "Countries";
    /// uGCThemeLayer.DatasetInfo.Type = DatasetType.REGION;
    /// ThemeLabel theme = new ThemeLabel();
    /// theme.LabelExpression = "Country";
    /// theme.Type = ThemeType.LABEL;
    /// theme.OverlapAvoided = true;
    /// theme.SmallGeometryLabeled = true;
    /// theme.UniformStyle = new TextStyle();
    /// theme.UniformStyle.FontName = "宋体";
    /// theme.UniformStyle.FontWidth = 5;
    /// theme.UniformStyle.FontHeight = 6;
    /// theme.UniformStyle.FontWeight = 2;
    /// theme.UniformStyle.ForeColor = new SuperMap.Connector.Utility.Color(255, 0, 255);
    /// uGCThemeLayer.Theme = theme;
    /// uGCThemeLayer.Visible = true;
    /// </code>
    /// </example>
    [JsonObject(MemberSerialization.OptIn)]
    [JsonConverter(typeof(ThemeLabelConverter))]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public class ThemeLabel : Theme
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public ThemeLabel()
            : base()
        {
            this.Type = ThemeType.LABEL;
        }

        /// <summary>
        /// 是否沿线显示文本。
        /// </summary>
        [JsonProperty("alongLine")]
        public bool AlongLine { get; set; }

        /// <summary>
        /// 标签沿线标注方向。
        /// </summary>
        [JsonProperty("alongLineDirection")]
        public AlongLineDirection AlongLineDirection { get; set; }

        /// <summary>
        /// 当沿线显示文本时，是否将文本角度固定。
        /// </summary>
        [JsonProperty("angleFixed")]
        public bool AngleFixed { get; set; }

        /// <summary>
        /// 标签专题图中的标签背景风格。
        /// </summary>
        [JsonProperty("backStyle")]
        public Style BackStyle { get; set; }

        /// <summary>
        /// 是否流动显示标签。
        /// </summary>
        [JsonProperty("flowEnabled")]
        public bool FlowEnabled { get; set; }

        /// <summary>
        /// 标签专题图中标签专题图子项数组。
        /// </summary>
        [JsonProperty("items")]
        public ThemeLabelItem[] Items { get; set; }

        /// <summary>
        /// 标签专题图中的标签背景的形状类型。
        /// </summary>
        [JsonProperty("labelBackShape")]
        public LabelBackShape LabelBackShape { get; set; }

        /// <summary>
        /// 标注字段表达式。
        /// </summary>
        [JsonProperty("labelExpression")]
        public string LabelExpression { get; set; }

        /// <summary>
        /// 超长标签处理模式。
        /// </summary>
        [JsonProperty("labelOverLengthMode")]
        public LabelOverLengthMode LabelOverLengthMode { get; set; }

        /// <summary>
        /// 在沿线标注时循环标注的间隔。
        /// </summary>
        [JsonProperty("labelRepeatInterval")]
        public double LabelRepeatInterval { get; set; }

        /// <summary>
        /// 是否显示标签和它标注的对象之间的牵引线。
        /// </summary>
        [JsonProperty("leaderLineDisplayed")]
        public bool LeaderLineDisplayed { get; set; }

        /// <summary>
        /// 标签与其标注对象之间牵引线的风格。
        /// </summary>
        [JsonProperty("leaderLineStyle")]
        public Style LeaderLineStyle { get; set; }

        /// <summary>
        /// 矩阵标签元素数组，包括符号类型的矩阵标签元素和图片类型的矩阵标签元素。
        /// </summary>
        [JsonProperty("matrixCells")]
        public LabelMatrixCell[][] MatrixCells { get; set; }

        /// <summary>
        /// 标签在每一行显示的最大长度。
        /// </summary>
        [JsonProperty("maxLabelLength")]
        public int MaxLabelLength { get; set; }

        /// <summary>
        /// 标签中文本的最大高度。
        /// </summary>
        [JsonProperty("maxTextHeight")]
        public int MaxTextHeight { get; set; }

        /// <summary>
        /// 标签中文本的最大宽度。
        /// </summary>
        [JsonProperty("maxTextWidth")]
        public int MaxTextWidth { get; set; }

        /// <summary>
        /// 标签中文本的最小高度。
        /// </summary>
        [JsonProperty("minTextHeight")]
        public int MinTextHeight { get; set; }

        /// <summary>
        /// 标签中文本的最小宽度。
        /// </summary>
        [JsonProperty("minTextWidth")]
        public int MinTextWidth { get; set; }

        /// <summary>
        /// 标签中数字的精度。
        /// </summary>
        [JsonProperty("numericPrecision")]
        public int NumericPrecision { get; set; }

        /// <summary>
        /// 当前标签专题图是否固定标记文本的偏移量。
        /// </summary>
        [JsonProperty("offsetFixed")]
        public bool OffsetFixed { get; set; }

        /// <summary>
        /// 标签专题图中标记文本相对于要素内点的水平偏移量。
        /// </summary>
        [JsonProperty("offsetX")]
        public string OffsetX { get; set; }

        /// <summary>
        /// 返回标签专题图中标记文本相对于要素内点的垂直偏移量。
        /// </summary>
        [JsonProperty("offsetY")]
        public string OffsetY { get; set; }

        /// <summary>
        /// 是否允许以文本避让方式显示文本。
        /// </summary>
        [JsonProperty("overlapAvoided")]
        public bool OverlapAvoided { get; set; }

        /// <summary>
        /// 分段字段表达式。
        /// </summary>
        [JsonProperty("rangeExpression")]
        public string RangeExpression { get; set; }

        /// <summary>
        ///  返回是否避免地图重复标注。
        /// </summary>
        [JsonProperty("repeatedLabelAvoided")]
        public bool RepeatedLabelAvoided { get; set; }

        /// <summary>
        /// 循环标注间隔是否固定。
        /// </summary>
        [JsonProperty("repeatIntervalFixed")]
        public bool RepeatIntervalFixed { get; set; }

        /// <summary>
        ///  是否显示长度大于被标注对象本身长度的标签。
        /// </summary>
        [JsonProperty("smallGeometryLabeled")]
        public bool SmallGeometryLabeled { get; set; }

        /// <summary>
        /// 标签专题图统一的文本复合风格。
        /// </summary>
        [JsonProperty("uniformMixedStyle")]
        public LabelMixedTextStyle UniformMixedStyle { get; set; }

        /// <summary>
        ///  统一文本风格。
        /// </summary>
        [JsonProperty("uniformStyle")]
        public TextStyle UniformStyle { get; set; }
    }

    /// <summary>
    /// 标签专题图子项。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public class ThemeLabelItem
    {
        /// <summary>
        /// 标签专题子项的标题。
        /// </summary>
        [JsonProperty("caption")]
        public string Caption { get; set; }

        /// <summary>
        /// 标签专题图子项的终止值。
        /// </summary>
        [JsonProperty("end")]
        public double End { get; set; }

        /// <summary>
        /// 标签专题图子项的分段起始值。
        /// </summary>
        [JsonProperty("start")]
        public double Start { get; set; }

        /// <summary>
        /// 标签专题图子项所对应的显示风格。
        /// </summary>
        [JsonProperty("style")]
        public TextStyle Style { get; set; }

        /// <summary>
        ///  标签专题图子项是否可见。
        /// </summary>
        [JsonProperty("visible")]
        public bool Visible { get; set; }
    }

    /// <summary>
    /// 统计专题图。
    /// </summary>
    /// <example>
    /// 以下是统计专题图的示范程序。
    /// <code>
    /// UGCThemeLayer uGCThemeLayer = new UGCThemeLayer();
    /// uGCThemeLayer.UgcLayerType = UGCLayerType.THEME;
    /// uGCThemeLayer.Caption = "统计专题图";
    /// uGCThemeLayer.Type = LayerType.UGC;
    /// uGCThemeLayer.DatasetInfo = new DatasetInfo();
    /// uGCThemeLayer.DatasetInfo.DataSourceName = "World";
    /// uGCThemeLayer.DatasetInfo.Name = "Countries";
    /// uGCThemeLayer.DatasetInfo.Type = DatasetType.REGION;
    /// ThemeGraph theme = new ThemeGraph();
    /// theme.Type = ThemeType.GRAPH;
    /// theme.GraphType = ThemeGraphType.BAR3D;
    /// theme.BarWidth = 100;
    /// theme.GraphSizeFixed = true;
    /// theme.GraduatedMode = GraduatedMode.CONSTANT;
    /// theme.Items = new ThemeGraphItem[2];
    /// theme.Items[0] = new ThemeGraphItem();
    /// theme.Items[0].GraphExpression = "SQKM";
    /// theme.Items[0].Caption = "item1";
    /// theme.Items[0].UniformStyle = new Style();
    /// theme.Items[0].UniformStyle.FillForeColor = new SuperMap.Connector.Utility.Color(0, 255, 0);
    /// theme.Items[1] = new ThemeGraphItem();
    /// theme.Items[1].GraphExpression = "SQMI";
    /// theme.Items[1].Caption = "item2";
    /// theme.Items[1].UniformStyle = new Style();
    /// theme.Items[1].UniformStyle.FillForeColor = new SuperMap.Connector.Utility.Color(0, 0, 255);
    /// uGCThemeLayer.Theme = theme;
    /// uGCThemeLayer.Visible = true;
    /// </code>
    /// </example>
    [JsonObject(MemberSerialization.OptIn)]
    [JsonConverter(typeof(ThemeConverter))]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public class ThemeGraph : Theme
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public ThemeGraph()
            : base()
        {
            this.Type = ThemeType.GRAPH;
        }

        /// <summary>
        /// 坐标轴颜色，axesDisplayed=true 时有效。
        /// </summary>
        [JsonProperty("axesColor")]
        public Color AxesColor { get; set; }

        /// <summary>
        /// 是否显示坐标轴。
        /// </summary>
        [JsonProperty("axesDisplayed")]
        public bool AxesDisplayed { get; set; }

        /// <summary>
        /// 是否在统计图坐标轴上显示网格。
        /// </summary>
        [JsonProperty("axesGridDisplayed")]
        public bool AxesGridDisplayed { get; set; }

        /// <summary>
        /// 是否显示坐标轴的文本标注。
        /// </summary>
        [JsonProperty("axesTextDisplayed")]
        public bool AxesTextDisplayed { get; set; }

        /// <summary>
        /// 坐标轴文本风格。
        /// </summary>
        [JsonProperty("axesTextStyle")]
        public TextStyle AxesTextStyle { get; set; }

        /// <summary>
        /// 柱状专题图中每一个柱的宽度。
        /// </summary>
        [JsonProperty("barWidth")]
        public double BarWidth { get; set; }

        /// <summary>
        /// 专题图的渲染风格是否流动显示。
        /// </summary>
        [JsonProperty("flowEnabled")]
        public bool FlowEnabled { get; set; }

        /// <summary>
        ///  统计图中地理要素的值与图表尺寸间的映射关系（常数、对数、平方根），即分级方式。
        /// </summary>
        [JsonProperty("graduatedMode")]
        public GraduatedMode GraduatedMode { get; set; }

        /// <summary>
        /// 统计专题图坐标轴文本显示模式
        /// </summary>
        [JsonProperty("graphAxesTextDisplayMode")]
        public GraphAxesTextDisplayMode GraphAxesTextDisplayMode { get; set; }

        /// <summary>
        /// 是否固定统计图大小。
        /// </summary>
        [JsonProperty("graphSizeFixed")]
        public bool GraphSizeFixed { get; set; }

        /// <summary>
        /// 是否显示统计图上的文字标注。
        /// </summary>
        [JsonProperty("graphTextDisplayed")]
        public bool GraphTextDisplayed { get; set; }

        /// <summary>
        /// 统计专题图文本显示格式，如百分数、真实数值、标题、标题+百分数、标题+真实数值。
        /// </summary>
        [JsonProperty("graphTextFormat")]
        public GraphTextFormat GraphTextFormat { get; set; }

        /// <summary>
        /// 统计图上的文字标注风格，graphTextDisplayed=true 时有效。
        /// </summary>
        [JsonProperty("graphTextStyle")]
        public TextStyle GraphTextStyle { get; set; }

        /// <summary>
        /// 统计专题图类型。
        /// </summary>
        [JsonProperty("graphType")]
        public ThemeGraphType GraphType { get; set; }

        /// <summary>
        ///   统计专题图的子项集合。
        /// </summary>
        [JsonProperty("items")]
        public ThemeGraphItem[] Items { get; set; }

        /// <summary>
        /// 是否显示统计图和它所表示的对象之间的牵引线。
        /// </summary>
        [JsonProperty("leaderLineDisplayed")]
        public bool LeaderLineDisplayed { get; set; }

        /// <summary>
        /// 统计图与其表示对象之间牵引线的风格。
        /// </summary>
        [JsonProperty("leaderLineStyle")]
        public Style LeaderLineStyle { get; set; }

        /// <summary>
        /// 统计图中显示的最大图表尺寸。
        /// </summary>
        [JsonProperty("maxGraphSize")]
        public double MaxGraphSize { get; set; }

        /// <summary>
        ///  以内存数组方式制作专题图时的键数组。
        /// </summary>
        [JsonProperty("memoryKeys")]
        public int[] MemoryKeys { get; set; }

        /// <summary>
        /// 统计图中显示的最小图表尺寸。
        /// </summary>
        [JsonProperty("minGraphSize")]
        public double MinGraphSize { get; set; }

        /// <summary>
        /// 专题图中是否显示属性为负值的数据。
        /// </summary>
        [JsonProperty("negativeDisplayed")]
        public bool NegativeDisplayed { get; set; }

        /// <summary>
        /// 统计图是否固定偏移量。
        /// </summary>
        [JsonProperty("offsetFixed")]
        public bool OffsetFixed { get; set; }

        /// <summary>
        /// 统计图的水平偏移量。
        /// </summary>
        [JsonProperty("offsetX")]
        public string OffsetX { get; set; }

        /// <summary>
        ///  统计图的垂直偏移量。
        /// </summary>
        [JsonProperty("offsetY")]
        public string OffsetY { get; set; }

        /// <summary>
        /// 统计图是否采用避让方式显示。
        /// </summary>
        [JsonProperty("overlapAvoided")]
        public bool OverlapAvoided { get; set; }

        /// <summary>
        /// 统计图中玫瑰图或三维玫瑰图分片的角度。
        /// </summary>
        [JsonProperty("roseAngle")]
        public double RoseAngle { get; set; }

        /// <summary>
        /// 饼状统计图的起始角度。
        /// </summary>
        [JsonProperty("startAngle")]
        public double StartAngle { get; set; }
    }

    /// <summary>
    /// 统计专题图子项类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public class ThemeGraphItem
    {
        /// <summary>
        /// 专题图子项的名称。
        /// </summary>
        [JsonProperty("caption")]
        public string Caption { get; set; }

        /// <summary>
        /// 统计专题图的专题变量。
        /// </summary>
        [JsonProperty("graphExpression")]
        public string GraphExpression { get; set; }

        /// <summary>
        /// 内存数组方式制作专题图时的值数组。
        /// </summary>
        [JsonProperty("memoryDoubleValues")]
        public double[] MemoryDoubleValues { get; set; }

        /// <summary>
        /// 统计专题图子项的显示风格。
        /// </summary>
        [JsonProperty("uniformStyle")]
        public Style UniformStyle { get; set; }
    }

    /// <summary>
    /// 点密度专题图。
    /// </summary>
    /// <example>
    /// 以下是点密度专题图的示范程序。
    /// <code>
    /// UGCThemeLayer uGCThemeLayer = new UGCThemeLayer();
    /// uGCThemeLayer.UgcLayerType = UGCLayerType.THEME;
    /// uGCThemeLayer.Caption = "标签专题图";
    /// uGCThemeLayer.Type = LayerType.UGC;
    /// uGCThemeLayer.DatasetInfo = new DatasetInfo();
    /// uGCThemeLayer.DatasetInfo.DataSourceName = "World";
    /// uGCThemeLayer.DatasetInfo.Name = "Countries";
    /// uGCThemeLayer.DatasetInfo.Type = DatasetType.REGION;
    /// ThemeDotDensity theme = new ThemeDotDensity();
    /// theme.DotExpression = "Pop_1994";
    /// theme.Style = new Style();
    /// theme.Style.MarkerSize = 5;
    /// theme.Style.MarkerSymbolID = 11;
    /// theme.Type = ThemeType.DOTDENSITY;
    /// theme.Value = 20000000;
    /// uGCThemeLayer.Theme = theme;
    /// uGCThemeLayer.Visible = true;
    /// </code>
    /// </example>
    [JsonObject(MemberSerialization.OptIn)]
    [JsonConverter(typeof(ThemeConverter))]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public class ThemeDotDensity : Theme
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public ThemeDotDensity()
            : base()
        {
            this.Type = ThemeType.DOTDENSITY;
        }

        /// <summary>
        /// 创建点密度专题图的字段或字段表达式。
        /// </summary>
        [JsonProperty("dotExpression")]
        public string DotExpression { get; set; }

        /// <summary>
        /// 点密度专题图中点的风格。
        /// </summary>
        [JsonProperty("style")]
        public Style Style { get; set; }

        /// <summary>
        /// 专题图中每一个点所代表的数值。
        /// </summary>
        [JsonProperty("value")]
        public double Value { get; set; }
    }

    /// <summary>
    /// 分段专题图类。
    /// </summary>
    /// <example>
    /// 以下是分段专题图的示范程序。
    /// <code>
    /// UGCThemeLayer uGCThemeLayer = new UGCThemeLayer();
    /// uGCThemeLayer.UgcLayerType = UGCLayerType.THEME;
    /// uGCThemeLayer.Caption = "分段专题图";
    /// uGCThemeLayer.Type = LayerType.UGC;
    /// uGCThemeLayer.DatasetInfo = new DatasetInfo();
    /// uGCThemeLayer.DatasetInfo.DataSourceName = "World";
    /// uGCThemeLayer.DatasetInfo.Name = "Countries";
    /// uGCThemeLayer.DatasetInfo.Type = DatasetType.REGION;
    /// ThemeRange theme = new ThemeRange();
    /// theme.Type = ThemeType.RANGE;
    /// theme.RangeExpression = "SmID";
    /// theme.RangeMode = RangeMode.EQUALINTERVAL;
    /// theme.RangeParameter = 5;
    /// theme.ColorGradientType = ColorGradientType.SPECTRUM;
    /// uGCThemeLayer.Theme = theme;
    /// uGCThemeLayer.Visible = true;
    /// </code>
    /// </example>
    [JsonObject(MemberSerialization.OptIn)]
    [JsonConverter(typeof(ThemeConverter))]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public class ThemeRange : Theme
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public ThemeRange()
            : base()
        {
            this.Type = ThemeType.RANGE;
        }

        /// <summary>
        /// 分段专题图的颜色渐变风格。
        /// </summary>
        [JsonProperty("colorGradientType")]
        public ColorGradientType ColorGradientType { get; set; }

        /// <summary>
        /// 分段专题图中分段专题图子项数组。
        /// </summary>
        [JsonProperty("items")]
        public ThemeRangeItem[] Items { get; set; }

        /// <summary>
        /// 分段字段表达式。
        /// </summary>
        [JsonProperty("rangeExpression")]
        public string RangeExpression { get; set; }

        /// <summary>
        /// 分段专题图的分段模式。
        /// </summary>
        [JsonProperty("rangeMode")]
        public RangeMode RangeMode { get; set; }

        /// <summary>
        ///  分段参数。
        /// </summary>
        [JsonProperty("rangeParameter")]
        public double RangeParameter { get; set; }
    }

    /// <summary>
    /// 分段专题图子项类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public class ThemeRangeItem
    {
        /// <summary>
        /// 分段专题图子项的标题。
        /// </summary>
        [JsonProperty("caption")]
        public string Caption { get; set; }

        /// <summary>
        /// 分段专题图子项的终止值，即该段专题值范围的最大值。
        /// </summary>
        [JsonProperty("end")]
        public double End { get; set; }

        /// <summary>
        /// 分段专题图子项的起始值，即该段专题值范围的最小值。
        /// </summary>
        [JsonProperty("start")]
        public double Start { get; set; }

        /// <summary>
        /// 分段专题图子项的风格。
        /// </summary>
        [JsonProperty("style")]
        public Style Style { get; set; }

        /// <summary>
        ///  分段专题图子项是否可见。
        /// </summary>
        [JsonProperty("visible")]
        public bool Visible { get; set; }
    }

    /// <summary>
    /// 栅格分段专题图类。
    /// </summary>
    /// <example>
    /// 以下是栅格分段专题图的示范程序
    /// <code>
    /// UGCThemeLayer uGCThemeLayer = new UGCThemeLayer();
    /// uGCThemeLayer.UgcLayerType = UGCLayerType.THEME;
    /// uGCThemeLayer.Caption = "栅格分段专题图";
    /// uGCThemeLayer.Type = LayerType.UGC;
    /// uGCThemeLayer.DatasetInfo = new DatasetInfo();
    /// uGCThemeLayer.DatasetInfo.DataSourceName = "Jingjin";
    /// uGCThemeLayer.DatasetInfo.Name = "ClipJingjin";
    /// uGCThemeLayer.DatasetInfo.Type = DatasetType.GRID;
    /// ThemeGridRange theme = new ThemeGridRange();
    /// theme.Type = ThemeType.GRIDRANGE;
    /// theme.RangeMode = RangeMode.EQUALINTERVAL;
    /// theme.RangeParameter = 4;
    /// theme.ColorGradientType = ColorGradientType.GREENORANGEVIOLET;
    /// uGCThemeLayer.Theme = theme;
    /// uGCThemeLayer.Visible = true;
    /// </code>
    /// </example>
    [JsonObject(MemberSerialization.OptIn)]
    [JsonConverter(typeof(ThemeConverter))]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public class ThemeGridRange : Theme
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public ThemeGridRange()
            : base()
        {
            this.Type = ThemeType.GRIDRANGE;
        }

        /// <summary>
        /// 栅格分段专题图的颜色渐变风格，
        /// </summary>
        [JsonProperty("colorGradientType")]
        public ColorGradientType ColorGradientType { get; set; }

        /// <summary>
        ///  栅格分段专题图子项数组。
        /// </summary>
        [JsonProperty("items")]
        public ThemeGridRangeItem[] Items { get; set; }

        /// <summary>
        /// 分段专题图的分段方式。
        /// </summary>
        /// <remarks>
        /// 标准差分段模式和等计数分段模式不支持栅格数据。
        /// </remarks>
        [JsonProperty("rangeMode")]
        public RangeMode RangeMode { get; set; }

        /// <summary>
        /// 分段参数。
        /// </summary>
        [JsonProperty("rangeParameter")]
        public double RangeParameter { get; set; }

        /// <summary>
        /// 是否对分段专题图中分段的颜色风格进行反序显示。
        /// </summary>
        [JsonProperty("reverseColor")]
        public bool ReverseColor { get; set; }
    }

    /// <summary>
    /// 栅格分段专题图子项类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public class ThemeGridRangeItem
    {
        /// <summary>
        /// 栅格分段专题图中子项的名称。
        /// </summary>
        [JsonProperty("caption")]
        public string Caption { get; set; }

        /// <summary>
        /// 栅格分段专题图中每一个分段专题图子项的对应的颜色。
        /// </summary>
        [JsonProperty("color")]
        public Color Color { get; set; }

        /// <summary>
        /// 栅格分段专题图子项的终止值。
        /// </summary>
        [JsonProperty("end")]
        public double End { get; set; }

        /// <summary>
        ///  栅格分段专题图子项的起始值。
        /// </summary>
        [JsonProperty("start")]
        public double Start { get; set; }

        /// <summary>
        /// 栅格分段专题图中的子项是否可见。
        /// </summary>
        [JsonProperty("visible")]
        public bool Visible { get; set; }
    }

    /// <summary>
    /// 等级符号专题图。
    /// </summary>
    /// <example>
    /// <code>
    /// UGCThemeLayer uGCThemeLayer = new UGCThemeLayer();
    /// uGCThemeLayer.UgcLayerType = UGCLayerType.THEME;
    /// uGCThemeLayer.Caption = "等级符号专题图";
    /// uGCThemeLayer.Type = LayerType.UGC;
    /// uGCThemeLayer.DatasetInfo = new DatasetInfo();
    /// uGCThemeLayer.DatasetInfo.DataSourceName = "World";
    /// uGCThemeLayer.DatasetInfo.Name = "Countries";
    /// uGCThemeLayer.DatasetInfo.Type = DatasetType.REGION;
    /// ThemeGraduatedSymbol theme = new ThemeGraduatedSymbol();
    /// theme.Type = ThemeType.GRADUATEDSYMBOL;
    /// theme.GraduatedMode = GraduatedMode.CONSTANT;
    /// theme.Expression = "Pop_1994";
    /// theme.BaseValue = 100000000;
    /// theme.PositiveStyle = new Style();
    /// theme.PositiveStyle.MarkerSize = 5;
    /// theme.PositiveStyle.MarkerSymbolID = 13;
    /// uGCThemeLayer.Theme = theme;
    /// uGCThemeLayer.Visible = true;
    /// </code>
    /// </example>
    [JsonObject(MemberSerialization.OptIn)]
    [JsonConverter(typeof(ThemeConverter))]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public class ThemeGraduatedSymbol : Theme
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public ThemeGraduatedSymbol()
            : base()
        {
            this.Type = ThemeType.GRADUATEDSYMBOL;
        }

        /// <summary>
        ///  等级符号专题图的基准值，单位同专题变量的单位。
        /// </summary>
        [JsonProperty("baseValue")]
        public double BaseValue { get; set; }

        /// <summary>
        ///  用于创建等级符号专题图的字段或字段表达式。
        /// </summary>
        [JsonProperty("expression")]
        public string Expression { get; set; }

        /// <summary>
        /// 是否允许等级符号图追随其对应的对象流动显示。
        /// </summary>
        [JsonProperty("flowEnabled")]
        public bool FlowEnabled { get; set; }

        /// <summary>
        ///  等级符号专题图分级模式。
        /// </summary>
        [JsonProperty("graduatedMode")]
        public GraduatedMode GraduatedMode { get; set; }

        /// <summary>
        /// 是否显示等级符号图与其相应对象之间的牵引线。
        /// </summary>
        [JsonProperty("leaderLineDisplayed")]
        public bool LeaderLineDisplayed { get; set; }

        /// <summary>
        /// 等级符号图与其相应对象之间的牵引线的风格。
        /// </summary>
        [JsonProperty("leaderLineStyle")]
        public Style LeaderLineStyle { get; set; }

        /// <summary>
        /// 是否显示负值的等级符号风格，true 表示显示。
        /// </summary>
        [JsonProperty("negativeDisplayed")]
        public bool NegativeDisplayed { get; set; }

        /// <summary>
        /// 负值的等级符号风格。
        /// </summary>
        [JsonProperty("negativeStyle")]
        public Style NegativeStyle { get; set; }

        /// <summary>
        /// 等级符号图的偏移量是否固定。
        /// </summary>
        [JsonProperty("offsetFixed")]
        public bool OffsetFixed { get; set; }

        /// <summary>
        /// 等级符号图 X 坐标方向（横向）偏移量。
        /// </summary>
        [JsonProperty("offsetX")]
        public string OffsetX { get; set; }

        /// <summary>
        /// 等级符号图 Y 坐标方向（纵向）的偏移量。
        /// </summary>
        [JsonProperty("offsetY")]
        public string OffsetY { get; set; }

        /// <summary>
        /// 正值的等级符号风格。
        /// </summary>
        [JsonProperty("positiveStyle")]
        public Style PositiveStyle { get; set; }

        /// <summary>
        /// 是否显示0值的等级符号风格，true 表示显示。
        /// </summary>
        [JsonProperty("zeroDisplayed")]
        public bool ZeroDisplayed { get; set; }

        /// <summary>
        /// 0值的等级符号风格。
        /// </summary>
        [JsonProperty("zeroStyle")]
        public Style ZeroStyle { get; set; }
    }

    /// <summary>
    /// 栅格单值专题图类。
    /// </summary>
    /// <example>
    /// <code>
    /// UGCThemeLayer uGCThemeLayer = new UGCThemeLayer();
    /// uGCThemeLayer.UgcLayerType = UGCLayerType.THEME;
    /// uGCThemeLayer.Caption = "栅格单值专题图";
    /// uGCThemeLayer.Type = LayerType.UGC;
    /// uGCThemeLayer.DatasetInfo = new DatasetInfo();
    /// uGCThemeLayer.DatasetInfo.DataSourceName = "Jingjin";
    /// uGCThemeLayer.DatasetInfo.Name = "ClipJingjin";
    /// uGCThemeLayer.DatasetInfo.Type = DatasetType.GRID;
    /// ThemeGridUnique theme = new ThemeGridUnique();
    /// theme.Defaultcolor = new SuperMap.Connector.Utility.Color(0, 0, 0);
    /// theme.Type = ThemeType.GRIDUNIQUE;
    /// theme.Items = new ThemeGridUniqueItem[5];
    /// theme.Items[0] = new ThemeGridUniqueItem() { Caption = "item1", Visible = true, Unique = 500 };
    /// theme.Items[0].Color = new SuperMap.Connector.Utility.Color(255, 0, 0);
    /// theme.Items[1] = new ThemeGridUniqueItem() { Caption = "item1", Visible = true, Unique = 1000 };
    /// theme.Items[1].Color = new SuperMap.Connector.Utility.Color(0, 255, 0);
    /// theme.Items[2] = new ThemeGridUniqueItem() { Caption = "item1", Visible = true, Unique = 1500 };
    /// theme.Items[2].Color = new SuperMap.Connector.Utility.Color(0, 0, 255);
    /// theme.Items[3] = new ThemeGridUniqueItem() { Caption = "item1", Visible = true, Unique = 100 };
    /// theme.Items[3].Color = new SuperMap.Connector.Utility.Color(255, 255, 0);
    /// theme.Items[4] = new ThemeGridUniqueItem() { Caption = "item1", Visible = true, Unique = 1100 };
    /// theme.Items[4].Color = new SuperMap.Connector.Utility.Color(255, 0, 255);
    /// uGCThemeLayer.Theme = theme;
    /// uGCThemeLayer.Visible = true;
    /// </code>
    /// </example>
    [JsonObject(MemberSerialization.OptIn)]
    [JsonConverter(typeof(ThemeConverter))]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public class ThemeGridUnique : Theme
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public ThemeGridUnique()
            : base()
        {
            this.Type = ThemeType.GRIDUNIQUE;
        }

        /// <summary>
        /// 栅格单值专题图的默认颜色。
        /// </summary>
        [JsonProperty("defaultcolor")]
        public Color Defaultcolor { get; set; }
        /// <summary>
        /// 栅格单值专题图子项数组。
        /// </summary>
        [JsonProperty("items")]
        public ThemeGridUniqueItem[] Items { get; set; }
    }

    /// <summary>
    /// 栅格单值专题图子项类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public class ThemeGridUniqueItem
    {
        /// <summary>
        /// 栅格单值专题图子项的名称。
        /// </summary>
        [JsonProperty("caption")]
        public string Caption { get; set; }

        /// <summary>
        /// 栅格单值专题图子项的显示颜色。
        /// </summary>
        [JsonProperty("color")]
        public Color Color { get; set; }

        /// <summary>
        /// 栅格单值专题图子项的专题值，即单元格的值，值相同的单元格位于一个子项内。
        /// </summary>
        [JsonProperty("unique")]
        public double Unique { get; set; }

        /// <summary>
        /// 栅格单值专题图子项是否可见。
        /// </summary>
        [JsonProperty("visible")]
        public bool Visible { get; set; }
    }
}
