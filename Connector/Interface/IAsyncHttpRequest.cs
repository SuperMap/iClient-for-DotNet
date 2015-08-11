using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SuperMap.Connector.Interface
{
    public interface IAsyncHttpRequest : IHttpRequest
    {
        void GetRequestStream(string url);
        void GetRequestString(string url);
    }
}
