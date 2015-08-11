using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 定义矢量数据集的字符集枚举 。
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Charset
    {
        /// <summary>
        /// ASCII 字符集。 
        /// </summary>
        ANSI,

        /// <summary>
        /// 阿拉伯字符集。 
        /// </summary>
        ARABIC,

        /// <summary>
        /// 波罗的海字符集。 
        /// </summary>
        BALTIC,

        /// <summary>
        /// 在中国香港特别行政区和台湾最常用的中文字符集。 
        /// </summary>
        CHINESEBIG5,

        /// <summary>
        /// Cyrillic (Windows)。 
        /// </summary>
        CYRILLIC,

        /// <summary>
        /// 扩展的 ASCII 字符集。 
        /// </summary>
        DEFAULT,

        /// <summary>
        /// 东欧字符集。 
        /// </summary>
        EASTEUROPE,

        /// <summary>
        /// 在中国大陆使用的中文字符集。 
        /// </summary>
        GB18030,

        /// <summary>
        /// 希腊字符集。 
        /// </summary>
        GREEK,

        /// <summary>
        /// 朝鲜字符集的其它常用拼写。 
        /// </summary>
        HANGEUL,

        /// <summary>
        /// 希伯来字符集。 
        /// </summary>
        HEBREW,

        /// <summary>
        /// 朝鲜字符集。 
        /// </summary>
        JOHAB,

        /// <summary>
        /// 韩语字符集。 
        /// </summary>
        KOREAN,

        /// <summary>
        /// Macintosh 使用的字符。 
        /// </summary>
        MAC,

        /// <summary>
        /// 扩展的 ASCII 字符集。 
        /// </summary>
        OEM,

        /// <summary>
        /// 俄语字符集。 
        /// </summary>
        RUSSIAN,

        /// <summary>
        /// 日语字符集。 
        /// </summary>
        SHIFTJIS,

        /// <summary>
        /// 符号字符集。 
        /// </summary>
        SYMBOL,

        /// <summary>
        /// 泰语字符集。 
        /// </summary>
        THAI,

        /// <summary>
        /// 土耳其语字符集。 
        /// </summary>
        TURKISH,

        /// <summary>
        /// 在计算机科学领域中，Unicode（统一码、万国码、单一码、标准万国码）是业界的一种标准。 
        /// </summary>
        UNICODE,

        /// <summary>
        /// UTF-32 (or UCS-4)是一种将Unicode字符编码的协定， 对每一个Unicode码位使用恰好32位元。 
        /// </summary>
        UTF32,

        /// <summary>
        /// UTF-7 (7-位元 Unicode 转换格式（Unicode Transformation Format，简写成 UTF）) 是一种可变长度字符编码方式，用以将 Unicode 字符以 ASCII 编码的字符串来呈现。 
        /// </summary>
        UTF7,

        /// <summary>
        /// UTF-8（8 位元 Universal Character Set/Unicode Transformation Format）是针对Unicode 的一种可变长度字符编码。 
        /// </summary>
        UTF8,

        /// <summary>
        /// 越南语字符集。 
        /// </summary>
        VIETNAMESE,

        /// <summary>
        /// 英文常用的编码。 
        /// </summary>
        WINDOWS1252,

        /// <summary>
        /// IA5。 
        /// </summary>
        XIA5,
        /// <summary>
        /// IA5 (German)。 
        /// </summary>
        XIA5GERMAN,

        /// <summary>
        /// IA5 (Norwegian)。 
        /// </summary>
        XIA5NORWEGIAN,

        /// <summary>
        /// IA5 (Swedish)。 
        /// </summary>
        XIA5SWEDISH
    }
}
