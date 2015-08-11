using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMap.Connector.Control.WPF
{
    /// <summary>
    /// 向地图发出某一属性已更改的通知。
    /// </summary>
    public interface IMapNotifyPropertyChanged
    {
        /// <summary>
        /// 地图属性发生变化的事件。
        /// </summary>
        event MapPropertyChangedHandler PropertyChanged;
    }
}
