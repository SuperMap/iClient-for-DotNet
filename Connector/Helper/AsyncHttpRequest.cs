using System;
using System.Collections.Generic;
using System.Text;
using SuperMap.Connector.Utility;
using System.Net;
using System.IO;
using System.Threading;
using Newtonsoft.Json;

namespace SuperMap.Connector
{
    internal class AsyncEventArgs<T> : EventArgs
    {
        public AsyncEventArgs(T result)
            : base()
        {
            this._result = result;
        }

        private T _result;
        public T Result
        {
            get
            {
                return _result;
            }
        }
    }

    internal class AsyncHttpRequest
    {
        /// <summary>
        /// 使用WebClinet进行对url请求的访问，请求完成后将Invoke到UI线程上。
        /// </summary>
        /// <param name="url"></param>
        /// <param name="userToken"></param>
        /// <param name="OnCompleted"></param>
        /// <param name="OnFailed"></param>
        public static void DownloadStringAsync(string url, object userToken, EventHandler<AsyncEventArgs<string>> completed, EventHandler<FailedEventArgs> failed)
        {
            WebClient webClient = new WebClient();
#if !WINDOWS_PHONE
            webClient.Headers["Content-Type"] = "application/x-www-form-urlencoded; charset=UTF-8";
#endif
            webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler((sender, e) =>
            {
                if (e.Error == null)
                {
                    if (completed != null)
                    {
                        completed(sender, new AsyncEventArgs<string>(e.Result));
                    }
                }
                else
                {
                    if (failed != null)
                    {
                        failed(sender, new FailedEventArgs(e.Error));
                    }
                }
            });
            webClient.DownloadStringAsync(new Uri(url), userToken);
        }

        public static void UpLoadStringAsync(string url, HttpRequestMethod method, string data, object userToken, EventHandler<AsyncEventArgs<string>> completed, EventHandler<FailedEventArgs> failed)
        {
            WebClient wc = new WebClient();
            wc.Headers["Content-Type"] = "application/x-www-form-urlencoded; charset=UTF-8";
            wc.UploadStringCompleted += new UploadStringCompletedEventHandler((sender, e) =>
            {
                if (e.Error == null)
                {
                    if (completed != null)
                    {
                        completed(sender, new AsyncEventArgs<string>(e.Result));
                    }
                }
                else
                {
                    if (failed != null)
                    {
                        failed(sender, new FailedEventArgs(e.Error));
                    }
                }
            });
            wc.UploadStringAsync(new Uri(url), method.ToString().ToUpper(), data, userToken);
        }

        public static void GetStringAsync(string url, HttpRequestMethod requestMethod, string requestData, EventHandler<AsyncEventArgs<string>> OnCompleted, EventHandler<FailedEventArgs> OnFailed)
        {
            EventHandler<AsyncEventArgs<Stream>> callback = (sender, e) =>
            {
                if (e != null && e.Result != null)
                {
                    StreamReader streamReader = new StreamReader(e.Result);
                    string requestResult = streamReader.ReadToEnd();
                    streamReader.Close();
                    e.Result.Close();
                    if (OnCompleted != null)
                    {
                        OnCompleted(null, new AsyncEventArgs<string>(requestResult));
                    }
                }
            };
            AsyncHttpRequest.GetStreamAsync(url, requestMethod, requestData, callback, OnFailed);
        }

        public static void GetDataAsync(string url, HttpRequestMethod requestMethod, string requestData, EventHandler<AsyncEventArgs<byte[]>> OnCompleted, EventHandler<FailedEventArgs> OnFailed)
        {
            HttpWebRequest httpWebRequest = WebRequest.Create(url) as HttpWebRequest;
            httpWebRequest.Method = requestMethod.ToString();
            switch (requestMethod)
            {
                case HttpRequestMethod.GET:
                    break;
                case HttpRequestMethod.POST:
                case HttpRequestMethod.PUT:
                    UTF8Encoding encoding = new UTF8Encoding();
                    httpWebRequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                    byte[] data = encoding.GetBytes(requestData);
                    AutoResetEvent requestWaitHandler = new AutoResetEvent(false);
                    AsyncCallback requestCallback = ar =>
                    {
                        Stream stream = httpWebRequest.EndGetRequestStream(ar);
                        stream.Write(data, 0, data.Length);
                        stream.Close();
                        requestWaitHandler.Set();
                    };
                    IAsyncResult asyncRequestResult = httpWebRequest.BeginGetRequestStream(requestCallback, null);
                    requestWaitHandler.WaitOne();
                    break;
                default:
                    break;
            }

            Exception exception = null;
            Stream resultStream = null;
            AsyncCallback responseCallback = ar =>
            {
                try
                {
                    HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.EndGetResponse(ar);
                    resultStream = httpWebResponse.GetResponseStream();
                    long length = resultStream.Length;
                    byte[] buffer = new byte[length];
                    resultStream.Read(buffer, 0, (int)(length));

                    resultStream.Close();
                    httpWebResponse.Close();

                    if (OnCompleted != null)
                    {
                        OnCompleted(null, new AsyncEventArgs<byte[]>(buffer));
                    }
                }
                catch (WebException webException)
                {
                    HttpWebResponse errorResponse = webException.Response as HttpWebResponse;
                    if (errorResponse == null)
                    {
                        exception = new ServiceException(webException.Message, (int)(webException.Status), webException);
                    }
                    //当资源不存在时，tomcat返回404错误，错误流为html类型，故处理
                    if (errorResponse.ContentType.IndexOf("text/html") >= 0)
                    {
                        exception = new ServiceException(webException.Message, (int)errorResponse.StatusCode, webException);
                    }
                    else
                    {
                        Stream errorStream = errorResponse.GetResponseStream();
                        StreamReader reader = new StreamReader(errorStream);
                        string errorMessage = reader.ReadToEnd();
                        ErrorResource errorResource = JsonConvert.DeserializeObject<ErrorResource>(errorMessage);

                        errorResponse.Close();
                        errorStream.Close();
                        reader.Close();
                        exception = new SuperMap.Connector.Utility.ServiceException(errorResource.Error.ErrorMsg, errorResource.Error.Code, webException);
                    }
                    if (OnFailed != null)
                    {
                        OnFailed(null, new FailedEventArgs(exception as ServiceException));
                    }
                }
                finally
                {

                }
            };
            IAsyncResult asyncResponseResult = httpWebRequest.BeginGetResponse(responseCallback, null);
        }

        public static void GetStreamAsync(string url, HttpRequestMethod requestMethod, string requestData, EventHandler<AsyncEventArgs<Stream>> OnCompleted, EventHandler<FailedEventArgs> OnFailed)
        {
            #region
            //HttpWebRequest httpWebRequest = WebRequest.Create(url) as HttpWebRequest;
            //httpWebRequest.Method = requestMethod.ToString();
            //switch (requestMethod)
            //{
            //    case HttpRequestMethod.GET:
            //        break;
            //    case HttpRequestMethod.POST:
            //    case HttpRequestMethod.PUT:
            //        UTF8Encoding encoding = new UTF8Encoding();
            //        httpWebRequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            //        byte[] data = encoding.GetBytes(requestData);
            //        AutoResetEvent requestWaitHandler = new AutoResetEvent(false);
            //        AsyncCallback requestCallback = ar =>
            //        {
            //            Stream stream = httpWebRequest.EndGetRequestStream(ar);
            //            stream.Write(data, 0, data.Length);
            //            stream.Close();
            //            requestWaitHandler.Set();
            //        };
            //        IAsyncResult asyncRequestResult = httpWebRequest.BeginGetRequestStream(requestCallback, null);
            //        requestWaitHandler.WaitOne();
            //        break;
            //    default:
            //        break;
            //}

            //Exception exception = null;
            //Stream resultStream = null;
            //AsyncCallback responseCallback = ar =>
            //{
            //    try
            //    {
            //        HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.EndGetResponse(ar);
            //        resultStream = httpWebResponse.GetResponseStream();
            //        long length = resultStream.Length;
            //        byte[] buffer = new byte[length];
            //        resultStream.Read(buffer, 0, (int)(length - 1));
            //        MemoryStream memoryStream = new MemoryStream(buffer);
            //        resultStream.Close();
            //        httpWebResponse.Close();

            //        if (OnCompleted != null)
            //        {
            //            OnCompleted(null, new AsyncEventArgs<Stream>(memoryStream));
            //        }
            //    }
            //    catch (WebException webException)
            //    {
            //        HttpWebResponse errorResponse = webException.Response as HttpWebResponse;
            //        if (errorResponse == null)
            //        {
            //            exception = new ServiceException(webException.Message, (int)(webException.Status), webException);
            //        }
            //        //当资源不存在时，tomcat返回404错误，错误流为html类型，故处理
            //        if (errorResponse.ContentType.IndexOf("text/html") >= 0)
            //        {
            //            exception = new ServiceException(webException.Message, (int)errorResponse.StatusCode, webException);
            //        }
            //        else
            //        {
            //            Stream errorStream = errorResponse.GetResponseStream();
            //            StreamReader reader = new StreamReader(errorStream);
            //            string errorMessage = reader.ReadToEnd();
            //            ErrorResource errorResource = JsonConvert.DeserializeObject<ErrorResource>(errorMessage);

            //            errorResponse.Close();
            //            errorStream.Close();
            //            reader.Close();
            //            exception = new SuperMap.Connector.Utility.ServiceException(errorResource.Error.ErrorMsg, errorResource.Error.Code, webException);
            //        }
            //        if (OnFailed != null)
            //        {
            //            OnFailed(null, new FailedEventArgs(exception as ServiceException));
            //        }
            //    }
            //    finally
            //    {

            //    }
            //};
            //IAsyncResult asyncResponseResult = httpWebRequest.BeginGetResponse(responseCallback, null);
            #endregion
            EventHandler<AsyncEventArgs<byte[]>> callback = (sender, e) =>
            {
                if (e != null)
                {
                    MemoryStream ms = new MemoryStream(e.Result);
                    if (OnCompleted != null)
                    {
                        OnCompleted(null, new AsyncEventArgs<Stream>(ms));
                    }
                }
            };
            AsyncHttpRequest.GetDataAsync(url, requestMethod, requestData, callback, OnFailed);
        }

        //public void GetRequestString(string url, HttpRequestMethod requestMethod, string requestData,            AsyncHttpRequestCallBack callback, EventHandler<EventArgs> onCompleted,            EventHandler<EventArgs> onError)
        //{
        //    HttpWebRequest httpWebRequest = WebRequest.Create(url) as HttpWebRequest;
        //    switch (requestMethod)
        //    {
        //        case HttpRequestMethod.GET:
        //            httpWebRequest.KeepAlive = true;
        //            break;
        //        case HttpRequestMethod.POST:
        //            UTF8Encoding encoding = new UTF8Encoding();
        //            httpWebRequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
        //            byte[] data = encoding.GetBytes(requestData);
        //            Stream stream = httpWebRequest.GetRequestStream();
        //            stream.Write(data, 0, data.Length);
        //            stream.Close();
        //            break;
        //        default:
        //            break;
        //    }

        //    RequestState state = new RequestState();
        //    state.onCompleted = onCompleted;
        //    state.request = httpWebRequest;
        //    state.onError = onError;
        //    state.callBack = callback;
        //    state.requestData = requestData;
        //    state.response = null;
        //    httpWebRequest.BeginGetResponse(new AsyncCallback(RespCallback), state);
        //}

        //private void RespCallback(IAsyncResult asynchronousResult)
        //{
        //    RequestState myRequestState = (RequestState)asynchronousResult.AsyncState;
        //    string strResponse = string.Empty;
        //    try
        //    {
        //        HttpWebRequest myHttpWebRequest = myRequestState.request;
        //        myRequestState.response = (HttpWebResponse)myHttpWebRequest.EndGetResponse(asynchronousResult);
        //        using (Stream responseStream = myRequestState.response.GetResponseStream())
        //        {
        //            if (responseStream != null)
        //            {
        //                using (StreamReader reader = new StreamReader(responseStream))
        //                {
        //                    strResponse = reader.ReadToEnd();
        //                }
        //            }
        //        }
        //        myRequestState.response.Close();
        //    }
        //    catch (WebException e)
        //    {
        //        HttpWebResponse errorResponse = e.Response as HttpWebResponse;
        //        if (errorResponse != null)
        //        {
        //            using (Stream errorStream = errorResponse.GetResponseStream())
        //            {
        //                StreamReader reader = new StreamReader(errorStream);
        //                strResponse = reader.ReadToEnd();
        //            }
        //            errorResponse.Close();
        //        }
        //    }
        //    finally
        //    {
        //        if (myRequestState != null && myRequestState.callBack != null)
        //        {
        //            myRequestState.callBack(strResponse, myRequestState.onCompleted, myRequestState.onError);
        //        }
        //    }
        //}

        //internal class RequestState
        //{
        //    public string requestData { get; set; }
        //    public HttpWebRequest request { get; set; }
        //    public HttpWebResponse response { get; set; }
        //    public EventHandler<EventArgs> onCompleted { get; set; }
        //    public EventHandler<EventArgs> onError { get; set; }
        //    public AsyncHttpRequestCallBack callBack { get; set; }

        //    public RequestState()
        //    {
        //        request = null;
        //    }
        //}

        //public void GetRequestString<T>(string url, HttpRequestMethod requestMethod, string requestData, AsyncHttpRequestHandler<T> callback, EventHandler<T> onCompleted, EventHandler<ServiceErrorEventArgs> onError) where T : EventArgs
        //{
        //    HttpWebRequest httpWebRequest = WebRequest.Create(url) as HttpWebRequest;
        //    switch (requestMethod)
        //    {
        //        case HttpRequestMethod.GET:
        //            httpWebRequest.KeepAlive = true;
        //            break;
        //        case HttpRequestMethod.POST:
        //            UTF8Encoding encoding = new UTF8Encoding();
        //            httpWebRequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
        //            byte[] data = encoding.GetBytes(requestData);
        //            Stream stream = httpWebRequest.GetRequestStream();
        //            stream.Write(data, 0, data.Length);
        //            stream.Close();
        //            break;
        //        default:
        //            break;
        //    }

        //    RequestState<T> state = new RequestState<T>();
        //    state.onCompleted = onCompleted;
        //    state.request = httpWebRequest;
        //    state.onError = onError;
        //    state.callBack = callback;
        //    state.requestData = requestData;
        //    state.response = null;
        //    httpWebRequest.BeginGetResponse(new AsyncCallback(RespCallback<T>), state);
        //}

        //private void RespCallback<T>(IAsyncResult asynchronousResult) where T : EventArgs
        //{
        //    RequestState<T> myRequestState = (RequestState<T>)asynchronousResult.AsyncState;
        //    string strResponse = string.Empty;
        //    bool succeed = false;
        //    try
        //    {
        //        HttpWebRequest myHttpWebRequest = myRequestState.request;
        //        myRequestState.response = (HttpWebResponse)myHttpWebRequest.EndGetResponse(asynchronousResult);
        //        using (Stream responseStream = myRequestState.response.GetResponseStream())
        //        {
        //            if (responseStream != null)
        //            {
        //                using (StreamReader reader = new StreamReader(responseStream))
        //                {
        //                    strResponse = reader.ReadToEnd();
        //                }
        //            }
        //        }
        //        myRequestState.response.Close();
        //        succeed = true;
        //    }
        //    catch (WebException e)
        //    {
        //        HttpWebResponse errorResponse = e.Response as HttpWebResponse;
        //        if (errorResponse != null)
        //        {
        //            using (Stream errorStream = errorResponse.GetResponseStream())
        //            {
        //                StreamReader reader = new StreamReader(errorStream);
        //                strResponse = reader.ReadToEnd();
        //            }
        //            errorResponse.Close();
        //        }
        //    }
        //    finally
        //    {
        //        if (myRequestState != null && myRequestState.callBack != null)
        //        {
        //            myRequestState.callBack(succeed, strResponse, myRequestState.onCompleted, myRequestState.onError);
        //        }
        //    }
        //}
    }

    //internal class RequestState<T> where T : EventArgs
    //{
    //    public string requestData { get; set; }
    //    public HttpWebRequest request { get; set; }
    //    public HttpWebResponse response { get; set; }
    //    public EventHandler<T> onCompleted { get; set; }
    //    public EventHandler<ServiceErrorEventArgs> onError { get; set; }
    //    public AsyncHttpRequestHandler<T> callBack { get; set; }

    //    public RequestState()
    //    {
    //        request = null;
    //    }
    //}
}
