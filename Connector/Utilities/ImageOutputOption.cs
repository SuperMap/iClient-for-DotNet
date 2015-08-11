using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// <para>图片输出设置。</para>
    /// <para>包括图片的背景颜色、背景是否透明、图片输出的格式等设置。</para>
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public sealed class ImageOutputOption
    {
        //[JsonProperty("backColor")]
        //public Color BackColor { get; set; }

        //[JsonProperty("foreColor")]
        //public Color ForeColor { get; set; }
        /// <summary>
        /// 初始化 ImageOutputOption类的新实例。
        /// </summary>
        public ImageOutputOption()
        { }

        /// <summary>
        /// 使用指定的ImageOutputOption对象初始化ImageOutputOption类的新实例。
        /// </summary>
        /// <param name="imageOutputOption">ImageOutputOption对象。</param>
        public ImageOutputOption(ImageOutputOption imageOutputOption)
        {
            if (imageOutputOption == null) return;
            this.ImageOutputFormat = imageOutputOption.ImageOutputFormat;
            this.Transparent = imageOutputOption.Transparent;
            this.ImageReturnType = imageOutputOption.ImageReturnType;
        }

        private ImageOutputFormat _imageOutputFormat = ImageOutputFormat.PNG;
        /// <summary>
        /// 图片返回格式，默认返回PNG格式图片。
        /// </summary>
        public ImageOutputFormat ImageOutputFormat
        {
            get { return this._imageOutputFormat; }
            set { this._imageOutputFormat = value; }
        }

        //[JsonProperty("pdfOption")]
        //public PDFOption PdfOption { get; set; }

        /// <summary>
        /// 图片是否透明。
        /// </summary>
        [JsonProperty("transparent")]
        public bool Transparent { get; set; }

        private ImageReturnType _imageReturnType = ImageReturnType.BINARY;
        /// <summary>
        /// 图片返回的类型，默认返回二进制流；若返回url地址，图片格式为PNG。
        /// </summary>
        public ImageReturnType ImageReturnType
        {
            get { return this._imageReturnType; }
            set { this._imageReturnType = value; }
        }
    }
}
