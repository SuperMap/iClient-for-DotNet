using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 访问服务时出错引发的异常。
    /// </summary>
    public class ServiceException : Exception
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public ServiceException()
        { }

        /// <summary>
        /// 使用指定的错误消息和错误的响应状态码初始化 ServiceException 类的新实例。
        /// </summary>
        /// <param name="message">错误消息。</param>
        /// <param name="code">响应状态码。</param>
        /// <param name="innerException">嵌套异常。</param>
        public ServiceException(string message, int code, Exception innerException)
            : base(message, innerException)
        {
            this._code = code;
        }

        private int _code = 404;
        /// <summary>
        /// 获取响应的状态。
        /// </summary>
        public int Code
        {
            get
            {
                return _code;
            }
        }
    }
}
