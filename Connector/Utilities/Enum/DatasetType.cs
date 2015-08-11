using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 	<para>数据集类型枚举。</para>
    /// 	<para>数据集一般为存储在一起的相关数据的集合；根据数据类型的不同，分为矢量数据集、栅格数据
    /// 	集(grid dataset)和影像数据集(image dataset)，以及为了处理特定问题而设计的数据集，如拓扑数据集，
    /// 	网络数据集等。</para>
    /// </summary>
      [JsonConverter(typeof(StringEnumConverter))]
    public enum DatasetType
    {
        /// <summary>
        /// 复合数据集。 
        /// </summary>
        
        CAD,

        /// <summary>
        /// 栅格数据集。 
        /// </summary>
        GRID,
        
  
        /// <summary>
        ///     <para>影像数据集。<para><img src="../../../../CHM/interfacesimges/datasettype/imge.png"></img></para></para>      
        /// </summary>     
      
 
        IMAGE,
           
        /// <summary>
        ///     <para>线数据集。<para><img src="../../../../CHM/interfacesimges/datasettype/line.png"></img></para></para>        
        /// </summary>
              
        LINE,
          
        /// <summary>
        /// 三维线数据集。
        /// </summary>
        LINE3D,
        
        /// <summary>
        ///     <para>路由数据集。<para><img src="../../../../CHM/interfacesimges/datasettype/linem.png"></img></para></para>
        /// </summary>
        LINEM,
           
        /// <summary>
        /// 数据库表。
        /// </summary>
        LINKTABLE,
          
        /// <summary>
        ///     <para>网络数据集。<para> <img src="../../../../CHM/interfacesimges/datasettype/Network.png"></img></para></para>
        /// </summary>
        NETWORK, 
         
        /// <summary>网络数据集的子数据集。 </summary>
        NETWORKPOINT,
        
        /// <summary>
        ///     <para>点数据集。<para><img src="../../../../CHM/interfacesimges/datasettype/point.png"></img></para></para>
        /// </summary>
        POINT,
          
        /// <summary>
        /// 三维点数据集。 
        /// </summary>
        POINT3D,
         
        /// <summary>
        ///     <para>多边形数据集。 <para><img src="../../../../CHM/interfacesimges/datasettype/REGION.png"></img></para>
        /// </summary>
        REGION,
          
        /// <summary>
        /// 三维面数据集。 
        /// </summary>
        REGION3D,
          
        /// <summary>
        ///     <para>纯属性数据集。<para><img src="../../../../CHM/interfacesimges/datasettype/TABULAR.png"></img></para></para>
        /// </summary>
        TABULAR,
        
        /// <summary>
        ///     <para>文本数据集。<para><img src="../../../../CHM/interfacesimges/datasettype/text.png"></img></para></para>
        /// </summary>
        TEXT,
          
        /// <summary> 未定义。</summary>
        UNDEFINED, 
  
        /// <summary>WCS 数据集，是影像数据集 的一种类型。 </summary>
        WCS,  
      
        /// <summary> WMS 数据集，是影像数据集的一种类型。</summary>
        WMS,        
    }
}
