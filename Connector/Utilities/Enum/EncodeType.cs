using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{   
    /// <summary>
    /// <para>定义数据集存储时的压缩编码方式枚举。</para>
    /// <para>对矢量数据集，支持四种压缩编码方式，即单字节，双字节，三字节和四字节编码方式，
    /// 这四种压缩编码方式采用相同的压缩编码机制，但是压缩的比率不同。其均为有损压缩。
    /// 需要注意的是点数据集和纯属性数据集不可压缩编码。对光栅数据，可以采用 DCT 压缩
    /// 编码方式，该方法是一种有损压缩。ZIP 压缩编码适用于矢量数据和光栅数据，属于无损
    /// 压缩。</para>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EncodeType
    {
        /// <summary> 
        /// 不使用编码方式。   
        /// </summary>
        NONE,

        /// <summary> 
        /// 单字节编码方式。 
        /// </summary>
        BYTE,

        /// <summary> 
        /// DCT（Discrete Cosine Transform），离散余弦编码。   
        /// </summary>
        DCT,

        /// <summary> 
        /// 双字节编码方式。     
        /// </summary>
        INT16,

        /// <summary>
        /// 三字节编码方式。     
        /// </summary>
        INT24,

        /// <summary> 
        /// 三字节编码方式。    
        /// </summary>
        INT32,

        /// <summary> 
        /// LZW 是一种广泛采用的字典压缩方法，其最早是用在文字数据的压缩方面。  
        /// </summary>
        LZW,

        /// <summary>  
        /// PNG支持高级别无损耗压缩，WEB 应用中最受欢迎的文件格式。
        ///</summary>
        PNG,

        /// <summary>
        /// SGL（SuperMap Grid LZW），SuperMap 自定义的一种压缩存储格式。     
        /// </summary>
        SGL
    }
}
