using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMap.Connector.Interface
{
    /// <summary>
    /// SuperMap Connector For DotNet 组件接口。
    /// </summary>
    public interface IComponent
    {
        /// <summary>
        /// SuperMap iServer REST 服务地址。
        /// </summary>
        /// <example>
        /// map组件：http://localhost:8090/iserver/services/map-world
        /// data组件:http://localhost:8090/iserver/services/data-world
        /// </example>
        string ServiceUrl { get; }
    }
}
