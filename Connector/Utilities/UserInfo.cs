using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 用户信息类。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class UserInfo
    {   
        /// <summary>
        /// 用户唯一标识。
        /// </summary>
        [JsonProperty("userID")]
        public string UserID { get; set; }
    }
}
