using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Globalization;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 二维矩形类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if WINDOWS_PHONE
    public sealed class Rectangle2D
#else
    [Serializable]
    public sealed class Rectangle2D : ISerializable
#endif
    {
        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public Rectangle2D()
        {
            this.RightTop = new Point2D();
            this.LeftBottom = new Point2D();
        }
        /// <summary>
        /// 拷贝构造函数。
        /// </summary>
        /// <param name="rect2D">二维矩形几何对象。</param>
        /// <exception cref="ArgumentNullException">当二维矩形几何对象为 Null 或当二维矩形几何对象的参数不合法时抛出异常。</exception>
        public Rectangle2D(Rectangle2D rect2D)
        {
            if (rect2D == null) throw new ArgumentNullException();
            this.LeftBottom = new Point2D(rect2D.LeftBottom);
            this.RightTop = new Point2D(rect2D.RightTop);
        }
        /// <summary>
        /// 带参构造函数。
        /// 用指定的坐标初始化 Rectangle2D 类的新实例。
        /// </summary>
        /// <param name="leftBottom">左下角坐标。</param>
        /// <param name="rightTop">右上角坐标。</param>
        /// <exception cref="ArgumentNullException">当左下角坐标或右上角坐标为 Null 时抛出异常。</exception>
        public Rectangle2D(Point2D leftBottom, Point2D rightTop)
        {
            if (leftBottom == null || rightTop == null) throw new ArgumentNullException();
            this.LeftBottom = new Point2D(leftBottom);
            this.RightTop = new Point2D(rightTop);
        }

        /// <summary>
        /// 带参构造函数。
        /// 用指定的坐标初始化 Rectangle2D 类的新实例。
        /// </summary>
        /// <param name="left">左下角 x 坐标。</param>
        /// <param name="bottom">左下角 y 坐标。</param>
        /// <param name="right">右上角 x 坐标。</param>
        /// <param name="top">右上角 y 坐标。</param>
        public Rectangle2D(double left, double bottom, double right, double top)
        {
            this.LeftBottom = new Point2D(left, bottom);
            this.RightTop = new Point2D(right, top);
        }

        /// <summary>
        /// 左下角坐标。
        /// </summary>
        [JsonProperty("leftBottom")]
        public Point2D LeftBottom { get; set; }

        /// <summary>
        /// 右上角坐标。
        /// </summary>
        [JsonProperty("rightTop")]
        public Point2D RightTop { get; set; }

        /// <summary>
        /// 二维矩形框的宽度。
        /// </summary>
        /// <exception cref="NullReferenceException">当LeftBottom或者RightTop为空时抛出异常。</exception>
        public double Width
        {
            get
            {
                if (this.LeftBottom == null || this.RightTop == null)
                    throw new NullReferenceException();
                return Math.Abs(this.RightTop.X - this.LeftBottom.X);
            }
        }

        /// <summary>
        /// 二维矩形框的高度。
        /// </summary>
        /// <exception cref="NullReferenceException">当LeftBottom或者RightTop为空时抛出异常。</exception>
        public double Height
        {
            get
            {
                if (this.LeftBottom == null || this.RightTop == null)
                    throw new NullReferenceException();
                return Math.Abs(this.RightTop.Y - this.LeftBottom.Y);
            }
        }

        /// <summary>
        /// 获取二维矩形框的中心点。
        /// </summary>
        public Point2D Center
        {
            get
            {
                if (this.LeftBottom == null || this.RightTop == null)
                    throw new NullReferenceException();
                Point2D point2D = new Point2D();
                point2D.X = this.LeftBottom.X + (this.RightTop.X - this.LeftBottom.X) / 2;
                point2D.Y = this.LeftBottom.Y + (this.RightTop.Y - this.LeftBottom.Y) / 2;
                return point2D;
            }
        }

        /// <summary>
        /// 获取当前二维矩形框是否为空。
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                if (this.LeftBottom == null || this.RightTop == null) return true;
                if (this.Width < 0.0 || this.Width == double.NaN) return true;
                return false;
            }
        }

        //private static readonly Rectangle2D s_empty = new Rectangle2D(double.PositiveInfinity, double.PositiveInfinity, double.NegativeInfinity, double.NegativeInfinity);
        ///// <summary>
        ///// 获取 Rectangle2D 对象的空值，即该对象的左下角坐标值为正无穷，右上角坐标值为负无穷。用该属性对 Rectangle2D 对象完成初始化。
        ///// </summary>
        //public static Rectangle2D Empty
        //{
        //    get
        //    {
        //        return s_empty;
        //    }
        //}

        #region 重载方法。
        /// <summary>
        /// 指示指定的对象是否是 Rectangle2D 对象以及是否与此 Rectangle2D 对象相等（在一定的精度范围内）。
        /// </summary>
        /// <param name="obj">要比较的Rectangle2D对象。</param>
        /// <returns>如果 obj 参数是 Rectangle2D 对象，并与此 Rectangle2D 对象相等（在一定的精度范围内），则该方法返回 true；否则返回 false。</returns>
        /// <remarks>
        /// 比较的精度为 10 的 -10 次方，如果两者的四个顶点坐标位置之差均小于这一值，则认为它们相等。
        /// </remarks>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is Rectangle2D)) return false;

            Rectangle2D rectangle2D = obj as Rectangle2D;
            if (rectangle2D == null) { return false; }

            // 比较两者的左上角与右下角。精度为：
            double MINI_DOUBLE = 1.0e-10;
            double diffValue;

            diffValue = Math.Abs(this.LeftBottom.X - rectangle2D.LeftBottom.X);
            if (diffValue > MINI_DOUBLE) { return false; }

            diffValue = Math.Abs(this.LeftBottom.Y - rectangle2D.LeftBottom.Y);
            if (diffValue > MINI_DOUBLE) { return false; }

            diffValue = Math.Abs(this.RightTop.X - rectangle2D.RightTop.X);
            if (diffValue > MINI_DOUBLE) { return false; }

            diffValue = Math.Abs(this.RightTop.Y - rectangle2D.RightTop.Y);
            if (diffValue > MINI_DOUBLE) { return false; }

            return true;
        }

        /// <summary>
        /// 返回该实例的哈希代码。
        /// </summary>
        /// <returns>哈希代码值。</returns>
        public override int GetHashCode()
        {
            string hashText = this.LeftBottom.X + "," + this.LeftBottom.Y + "," + this.RightTop.X + "," + this.RightTop.Y;
            return hashText.GetHashCode();
        }

        /// <summary>
        /// 获取此实例的 String 表示形式。
        /// </summary>
        /// <returns>此对象的字符串表示形式。</returns>
        public override string ToString()
        {
            return this.LeftBottom.X.ToString("R", NumberFormatInfo.InvariantInfo) + "," + this.LeftBottom.Y.ToString("R", NumberFormatInfo.InvariantInfo) + "," + this.RightTop.X.ToString("R", NumberFormatInfo.InvariantInfo) + "," + this.RightTop.Y.ToString("R", NumberFormatInfo.InvariantInfo);
        }
        #endregion

        #region 矩形框几何运算
        /// <summary>
        /// 确定 rect 表示的矩形区域是否完全包含在此矩形对象内。
        /// </summary>
        /// <param name="rect">地图坐标矩形信息</param>
        /// <returns>包含指定矩形返回true，否则返回false</returns>
        public bool Contains(Rectangle2D rect)
        {
            if (rect == null)
            {
                throw new ArgumentNullException("rect");
            }

            return this.LeftBottom.X <= rect.LeftBottom.X && this.LeftBottom.Y <= rect.LeftBottom.Y && this.RightTop.X >= rect.RightTop.X && this.RightTop.Y >= rect.RightTop.Y;
        }

        /// <summary>
        /// 确定 point2D 表示的点是否包含在此矩形对象内。
        /// </summary>
        /// <param name="point2D">point2D 信息</param>
        /// <returns>包含指定点信息返回true，否则返回false</returns>
        public bool Contains(Point2D point2D)
        {
            if (point2D == null)
            {
                throw new ArgumentNullException("point");
            }

            return this.Contains(point2D.X, point2D.Y);
        }

        /// <summary>
        /// 确定指定的点是否包含在此矩形对象内。
        /// </summary>
        /// <param name="x">测试点的 X 坐标。</param>
        /// <param name="y">测试点的 Y 坐标。</param>
        /// <returns>包含指定点信息返回true，否则返回false</returns>
        public bool Contains(double x, double y)
        {
            return this.LeftBottom.X <= x && this.LeftBottom.Y <= y && this.RightTop.X >= x && this.RightTop.Y >= y;
        }

        /// <summary>
        /// 将两个矩形框求并集。
        /// </summary>
        /// <param name="rect">求并的二维矩形框。</param>
        public void Union(Rectangle2D rect)
        {
            if (rect == null || (rect != null && rect.IsEmpty))
            {
                return;
            }
            if (this.IsEmpty)
            {
                this.LeftBottom = new Point2D(rect.LeftBottom);
                this.RightTop = new Point2D(rect.RightTop);
                return;
            }
            double minX = Math.Min(this.LeftBottom.X, rect.LeftBottom.X);
            double minY = Math.Min(this.LeftBottom.Y, rect.LeftBottom.Y);
            double maxX = Math.Max(this.RightTop.X, rect.RightTop.X);
            double maxY = Math.Max(this.RightTop.Y, rect.RightTop.Y);
            this.LeftBottom = new Point2D(minX, minY);
            this.RightTop = new Point2D(maxX, maxY);
        }
        #endregion

#if !WINDOWS_PHONE
        #region 序列化/反序列化
        private Rectangle2D(SerializationInfo info, StreamingContext context)
        {
            this.LeftBottom = (Point2D)info.GetValue("LeftBottom", typeof(Point2D));
            this.RightTop = (Point2D)info.GetValue("RightTop", typeof(Point2D));
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("LeftBottom", this.LeftBottom);
            info.AddValue("RightTop", this.RightTop);
        }
        #endregion
#endif
    }
}
