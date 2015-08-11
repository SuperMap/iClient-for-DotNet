using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SuperMap.Connector.Interface
{
    public interface ISynchHttpRequest : IHttpRequest
    {
        Stream GetRequestStream(string url);
        string GetRequestString(string url);
        string GetRequestString(string url, string postData);
        byte[] GetRequestBytes(string url);
        Stream GetRequestStream(string url, string postData);
        byte[] GetRequestBytes(string url, string postData);
    }
}
