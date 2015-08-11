using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 矩形类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public class Rectangle
#else
    [Serializable]
    public class Rectangle : ISerializable
#endif
    {
        /// <summary>
        /// 构造函数。
        /// </summary>
        public Rectangle()
        {

        }

        /// <summary>
        /// 拷贝的构造函数。
        /// </summary>
        /// <param name="rect">矩形类对象。</param>
        public Rectangle(Rectangle rect)
        {
            if (rect == null) throw new ArgumentNullException();
            this.LeftTop = new Point(rect.LeftTop);
            this.RightBottom = new Point(rect.RightBottom);
        }

        /// <summary>
        /// 带参的构造函数。
        /// </summary>
        /// <param name="left">左上角X坐标。</param>
        /// <param name="top">左上角Y坐标。</param>
        /// <param name="right">右下角X坐标。</param>
        /// <param name="bottom">右下角Y坐标。</param>
        public Rectangle(int left, int top, int right, int bottom)
        {
            this.LeftTop = new Point(left, top);
            this.RightBottom = new Point(right, bottom);
        }

        /// <summary>
        /// 带参的构造函数。
        /// </summary>
        /// <param name="leftTop">左上角点对象。</param>
        /// <param name="rightBottom">右下角点对象。</param>
        public Rectangle(Point leftTop, Point rightBottom)
        {
            if (leftTop == null || rightBottom == null) throw new ArgumentNullException();
            this.LeftTop = new Point(leftTop);
            this.RightBottom = new Point(rightBottom);
        }

        /// <summary>
        /// 左上角坐标。
        /// </summary>
        [JsonProperty("leftTop")]
        public Point LeftTop { get; set; }

        /// <summary>
        /// 右下角坐标。
        /// </summary>
        [JsonProperty("rightBottom")]
        public Point RightBottom { get; set; }

        /// <summary>
        /// 矩形的宽度。
        /// </summary>
        public int Width
        {
            get
            {
                if (this.LeftTop == null || this.RightBottom == null) throw new ArgumentNullException();
                return Math.Abs(this.LeftTop.X - this.RightBottom.X);
            }
        }

        /// <summary>
        /// 矩形的高度。
        /// </summary>
        public int Height
        {
            get
            {
                if (this.LeftTop == null || this.RightBottom == null) throw new ArgumentNullException();
                return Math.Abs(this.RightBottom.Y - this.LeftTop.Y);
            }
        }

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        private Rectangle(SerializationInfo info, StreamingContext context)
        {
            this.LeftTop = (Point)info.GetValue("LeftTop", typeof(Point));
            this.RightBottom = (Point)info.GetValue("RightBottom", typeof(Point));
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("LeftTop", this.LeftTop);
            info.AddValue("RightBottom", this.RightBottom);
        }

        #endregion
#endif
    }
}
