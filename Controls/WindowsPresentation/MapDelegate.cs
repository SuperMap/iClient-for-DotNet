using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using SuperMap.Connector.Utility;

namespace SuperMap.Connector.Control.WPF
{
    
    /// <summary>
    /// 表示将处理属性变化事件。
    /// </summary>
    /// <param name="sender">事件源。</param>
    /// <param name="e">包含事件数据的<see cref="MapPropertyChangedEventArgs"/></param>
    public delegate void MapPropertyChangedHandler(object sender,MapPropertyChangedEventArgs e);
    /// <summary>
    /// 表示加载地图的异常事件
    /// </summary>
    /// <param name="sender">事件源</param>
    /// <param name="e">包含事件数据的<see cref="MapErrorEventArgs"/></param>
    public delegate void MapErrorEventHandler(object sender,MapErrorEventArgs e);

    
    /// <summary>
    /// 为地图的PropertyChanged事件提供数据
    /// </summary>
    public class MapPropertyChangedEventArgs : EventArgs
    {
        /// <summary>
        /// 初始化MapPropertyChangedEventArgs的新实例
        /// </summary>
        /// <param name="name">属性名字</param>
        /// <param name="oldValue">发生改变前的属性的值。</param>
        /// <param name="newValue">发生改变后的属性的值。</param>
        public MapPropertyChangedEventArgs(string name,object oldValue,object newValue)
        {
            this.PropertyName = name;
            this.OldValue = oldValue;
            this.NewValue = newValue;
        }

        /// <summary>
        /// 属性名字。
        /// </summary>
        public string PropertyName
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取发生改变前的属性的值。
        /// </summary>
        public object OldValue
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取发生改变后的属性的值。
        /// </summary>
        public object NewValue
        {
            get;
            private set;
        }
    }

    /// <summary>
    /// 为地图出现的异常事件提供数据。
    /// </summary>
    public class MapErrorEventArgs : EventArgs
    {
        /// <summary>
        /// 初始化MapErrorEventArgs类的新实例。
        /// </summary>
        public MapErrorEventArgs()
            :this(string.Empty)
        {

        }

        /// <summary>
        /// 根据异常信息初始化MapErrorEventArgs类的新实例。
        /// </summary>
        /// <param name="message">异常信息</param>
        public MapErrorEventArgs(string message)
            :this(message,null)
        {

        }

        /// <summary>
        /// 根据异常信息和导致异常的Exception初始化MapErrorEventArgs类的新实例。
        /// </summary>
        /// <param name="message">异常信息</param>
        /// <param name="ex">导致当前异常的Exception</param>
        public MapErrorEventArgs(string message, Exception ex)
        {
            this._message = message;
            this._innerException = ex;
        }

        private string _message;

        /// <summary>
        /// 异常信息
        /// </summary>
        public string Message
        {
            get { return _message; }
        }

        private Exception _innerException;
        /// <summary>
        /// 获取导致当前异常的Exception
        /// </summary>
        public Exception InnerException
        {
            get { return _innerException; }
        }
    }
}
