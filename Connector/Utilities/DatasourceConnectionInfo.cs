using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 数据源连接信息类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
#if !WINDOWS_PHONE
    [Serializable]
#endif
    public sealed class DatasourceConnectionInfo
    {
        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public DatasourceConnectionInfo()
        {
        }

        /// <summary>
        /// 拷贝构造函数。
        /// </summary>
        /// <param name="datasourceConnectionInfo">数据源连接信息对象。</param>
        /// <exception cref="ArgumentNullException">当数据源连接信息对象为 Null 时抛出异常。</exception>
        public DatasourceConnectionInfo(DatasourceConnectionInfo datasourceConnectionInfo)
        {
            if (datasourceConnectionInfo == null) throw new ArgumentNullException();
            this.Alias = datasourceConnectionInfo.Alias;
            this.Connect = datasourceConnectionInfo.Connect;
            this.DataBase = datasourceConnectionInfo.DataBase;
            this.Driver = datasourceConnectionInfo.Driver;
            this.EngineType = datasourceConnectionInfo.EngineType;
            this.Exclusive = datasourceConnectionInfo.Exclusive;
            this.OpenLinkTable = datasourceConnectionInfo.OpenLinkTable;
            this.Password = datasourceConnectionInfo.Password;
            this.ReadOnly = datasourceConnectionInfo.ReadOnly;
            this.Server = datasourceConnectionInfo.Server;
            this.User = datasourceConnectionInfo.User;
        }

        /// <summary>
        /// 数据源别名。
        /// </summary>
        [JsonProperty("alias")]
        public string Alias { get; set; }

        /// <summary>
        /// 数据源是否自动连接数据。
        /// </summary>
        [JsonProperty("connect")]
        public bool Connect { get; set; }

        /// <summary>
        /// 数据源连接的数据库名。
        /// </summary>
        [JsonProperty("dataBase")]
        public string DataBase { get; set; }

        /// <summary>
        /// 使用 ODBC 连接的数据库的驱动程序名。
        /// </summary>
        [JsonProperty("driver")]
        public string Driver { get; set; }

        /// <summary>
        /// 数据源连接的引擎类型。
        /// </summary>
        [JsonProperty("engineType")]
        public EngineType EngineType { get; set; }

        /// <summary>
        /// 是否以独占方式打开数据源。
        /// </summary>
        [JsonProperty("exclusive")]
        public bool Exclusive { get; set; }

        /// <summary>
        /// 是否把数据库中的其他非 SuperMap 数据表作为 LinkTable 打开。
        /// </summary>
        [JsonProperty("openLinkTable")]
        public bool OpenLinkTable { get; set; }

        /// <summary>
        /// 登录数据源连接的数据库或文件的密码。
        /// </summary>
        [JsonProperty("password")]
        public string Password { get; set; }

        /// <summary>
        /// 是否以只读方式打开数据源。
        /// </summary>
        [JsonProperty("readOnly")]
        public bool ReadOnly { get; set; }

        /// <summary>
        /// 数据库服务器名或 SDB 文件名。
        /// </summary>
        [JsonProperty("server")]
        public string Server { get; set; }

        /// <summary>
        /// 登录数据库的用户名。
        /// </summary>
        [JsonProperty("user")]
        public string User { get; set; }

    }
}
