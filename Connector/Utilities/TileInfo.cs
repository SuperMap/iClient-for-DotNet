using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 格网图片信息
    /// </summary>
    public class TileInfo
    {
        /// <summary>
        /// 初始化TileInfo类的新实例。
        /// </summary>
        public TileInfo()
        { 
            
        }

        /// <summary>
        /// 初始化TileInfo类的新实例，通过指定的对象初始化新对象的值。
        /// </summary>
        /// <param name="tileInfo">格网图片信息。</param>
        public TileInfo(TileInfo tileInfo)
        {
            if (tileInfo == null) return;
            this.TileIndex = new TileIndex(tileInfo.TileIndex);
            this.Height = tileInfo.Height;
            this.Width = tileInfo.Width;
            this.Scale = tileInfo.Scale;
        }

        /// <summary>
        /// 格网索引
        /// </summary>
        public TileIndex TileIndex { get; set; }

        private uint _width = 256;
        /// <summary>
        /// 格网的宽度，单位是像素，默认为 256 像素。
        /// </summary>
        public uint Width
        {
            get { return _width; }
            set
            {
                this._width = value;
            }
        }

        private uint _height = 512;
        /// <summary>
        /// 格网的高度，单位是像素，默认为 256 像素。
        /// </summary>
        public uint Height
        {
            get { return _height; }
            set { this._height = value; }
        }

        private double _scale = 0.0;
        /// <summary>
        /// 地图的比例尺。如0.0001表示比例尺为1：10000。
        /// </summary>
        public double Scale
        {
            get { return _scale; }
            set
            {
                if (value < 0.0)
                {
                    throw new ArgumentException();
                }
                _scale = value;
            }
        }
    }

    /// <summary>
    /// 格网图片行列索引。
    /// </summary>
    public class TileIndex
    {
        /// <summary>
        /// 初始化TileIndex类的新实例。
        /// </summary>
        public TileIndex()
        {
        }

        /// <summary>
        /// 初始化TileIndex类的新实例，通过指定的对象初始化新对象的值。
        /// </summary>
        /// <param name="tileIndex">地图格网行列索引</param>
        public TileIndex(TileIndex tileIndex)
        {
            if (tileIndex == null)
            {
                return;
            }
            this.ColIndex = tileIndex.ColIndex;
            this.RowIndex = tileIndex.RowIndex;
        }

        /// <summary>
        ///【必选参数】 
        ///格网在地图中列号，从0开始计数，地图最左上角的格网列号为0。
        /// </summary>
        public int ColIndex { get; set; }

        /// <summary>
        ///【必选参数】 
        ///格网在地图中行号，从0开始计数，地图最左上角的格网行号为0
        /// </summary>
        public int RowIndex { get; set; }
    }
}
