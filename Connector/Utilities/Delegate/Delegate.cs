using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMap.Connector.Utility
{
    internal delegate void AsyncHttpRequestHandler<T>(bool succeed, string response, EventHandler<T> onCompleted, EventHandler<ServiceErrorEventArgs> onError) where T : EventArgs;
    //internal delegate void AsyncHttpRequestCallBack(string response, EventHandler<EventArgs> onCompleted, EventHandler<EventArgs> onError);
}
