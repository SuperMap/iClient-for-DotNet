using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperMap.Connector.Control.Utility;

namespace demo.winform
{

    /// <summary>
    /// 图层比较器，通过比较两个图层的ID来确定两个图层是否为同一个图层。
    /// </summary>
    internal class LayerComparer : IEqualityComparer<Layer>
    {

        #region IEqualityComparer<Layer> 成员

        /// <summary>
        /// 确定图层x是否与图层y相同。
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Equals(Layer x, Layer y)
        {
            if (x == null && y == null)
            {
                return true;
            }
            else if (x == null || y == null)
            {
                return false;
            }
            else
            {
                return x.ID.Equals(y.ID);
            }
        }

        /// <summary>
        /// 获取图层的哈希值。
        /// </summary>
        /// <param name="obj">传入的图层</param>
        /// <returns>哈希值</returns>
        public int GetHashCode(Layer obj)
        {
            return obj.ID.GetHashCode();
        }

        #endregion
    }
}
