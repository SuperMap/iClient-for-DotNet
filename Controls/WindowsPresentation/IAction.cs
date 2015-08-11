using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMap.Connector.Control.WPF
{
    /// <summary>
    /// 地图功能接口
    /// </summary>
    public interface IAction : IDisposable
    {
        /// <summary>
        /// 功能名称
        /// </summary>
        string ActionName { get; set; }
        /// <summary>
        /// 功能描述
        /// </summary>
        string ActionDescription { get; set; }

        /// <summary>
        /// 加载地图控件
        /// </summary>
        /// <param name="mapControl"></param>
        void OnLoad(MapControl mapControl);
    }
}
