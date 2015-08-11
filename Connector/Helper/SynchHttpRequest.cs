using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using SuperMap.Connector;
using Newtonsoft.Json;
using SuperMap.Connector.Utility;
using System.Threading;

namespace SuperMap.Connector
{
    internal class SynchHttpRequest
    {
        public static Stream GetRequestStream(string url)
        {
            return GetRequestStream(url, HttpRequestMethod.GET, null);
        }

        public static string GetRequestString(string url, string postData)
        {
            using (Stream stream = GetRequestStream(url, postData))
            {
                if (stream == null) return null;
                StreamReader streamReader = new StreamReader(stream);
                string requestResult = streamReader.ReadToEnd();
                streamReader.Close();
                stream.Close();
                return requestResult;
            }
        }

        public static string GetRequestString(string url)
        {
            using (Stream stream = GetRequestStream(url))
            {
                if (stream != null)
                {
                    StreamReader streamReader = new StreamReader(stream);
                    string requestResult = streamReader.ReadToEnd();
                    streamReader.Close();
                    stream.Close();
                    return requestResult;
                }
                return null;
            }
        }

        public static byte[] GetRequestBytes(string url)
        {
            byte[] buffer = null;
            using (MemoryStream ms = CopyStream(GetRequestStream(url), true))
            {
                if (ms != null)
                {
                    buffer = ms.ToArray();
                }
            }

            return buffer;
        }

        private static MemoryStream CopyStream(Stream inputStream, bool seekOriginBegin)
        {
            if (inputStream == null) return null;
            const int readSize = 32 * 1024;
            byte[] buffer = new byte[readSize];
            MemoryStream ms = new MemoryStream();
            int count = 0;
            while ((count = inputStream.Read(buffer, 0, readSize)) > 0)
            {
                ms.Write(buffer, 0, count);
            }
            buffer = null;
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }

        public static byte[] GetRequestBytes(string url, string postData)
        {
            byte[] buffer = null;
            using (MemoryStream ms = CopyStream(GetRequestStream(url, postData), true))
            {
                if (ms != null)
                {
                    buffer = ms.ToArray();
                }
            }

            return buffer;
        }

        public static Stream GetRequestStream(string url, string postData)
        {
            return GetRequestStream(url, HttpRequestMethod.POST, postData);
        }

        public static string GetRequestString(string url, HttpRequestMethod method, string postData)
        {
            using (Stream stream = GetRequestStream(url, method, postData))
            {
                if (stream != null)
                {
                    StreamReader streamReader = new StreamReader(stream);
                    string requestResult = streamReader.ReadToEnd();
                    streamReader.Close();
                    stream.Close();
                    return requestResult;
                }
                return null;
            }
        }

#if WINDOWS_PHONE
        private static Stream GetRequestStream(string url, HttpRequestMethod method, string postData)
        {
            if (System.Windows.Deployment.Current.Dispatcher.CheckAccess())
            {
                throw new InvalidOperationException("不能在UI线程上执行此方法。");
            }
            HttpWebRequest httpWebRequest = WebRequest.Create(url) as HttpWebRequest;
            httpWebRequest.Method = method.ToString();
            switch (method)
            {
                case HttpRequestMethod.GET:
                    break;
                case HttpRequestMethod.POST:
                case HttpRequestMethod.PUT:
                    UTF8Encoding encoding = new UTF8Encoding();
                    httpWebRequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                    byte[] data = encoding.GetBytes(postData);
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
            AutoResetEvent responseWaitHandler = new AutoResetEvent(false);
            Exception exception = null;
            Stream resultStream = null;
            AsyncCallback responseCallback = ar =>
            {
                try
                {
                    HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.EndGetResponse(ar);
                    resultStream = httpWebResponse.GetResponseStream();
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
                    Stream errorStream = errorResponse.GetResponseStream();
                    StreamReader reader = new StreamReader(errorStream);
                    string errorMessage = reader.ReadToEnd();
                    ErrorResource errorResource = JsonConvert.DeserializeObject<ErrorResource>(errorMessage);

                    errorResponse.Close();
                    errorStream.Close();
                    reader.Close();
                    exception = new SuperMap.Connector.Utility.ServiceException(errorResource.Error.ErrorMsg, errorResource.Error.Code, webException);
                }
                finally
                {
                    responseWaitHandler.Set();
                }
            };
            IAsyncResult asyncResponseResult = httpWebRequest.BeginGetResponse(responseCallback, null);
            responseWaitHandler.WaitOne();
            if (exception != null) throw exception;
            return resultStream;
        }
#endif
#if !WINDOWS_PHONE
        private static Stream GetRequestStream(string url, HttpRequestMethod method, string postData)
        {
            HttpWebRequest httpWebRequest = WebRequest.Create(url) as HttpWebRequest;
            httpWebRequest.Method = method.ToString();
            switch (method)
            {
                case HttpRequestMethod.GET:
                    httpWebRequest.KeepAlive = true;
                    break;
                case HttpRequestMethod.POST:
                case HttpRequestMethod.PUT:
                    UTF8Encoding encoding = new UTF8Encoding();
                    httpWebRequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                    byte[] data = encoding.GetBytes(postData);
                    Stream stream = httpWebRequest.GetRequestStream();
                    stream.Write(data, 0, data.Length);
                    stream.Close();
                    break;
                default:
                    break;
            }
            try
            {
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                Stream resultStream = httpWebResponse.GetResponseStream();
                return resultStream;
            }
            catch (WebException webException)
            {
                HttpWebResponse errorResponse = webException.Response as HttpWebResponse;
                if (errorResponse == null)
                {
                    throw new ServiceException(webException.Message, (int)(webException.Status), webException);
                }
                //当资源不存在时，tomcat返回404错误，错误流为html类型，故处理
                if (errorResponse.ContentType.IndexOf("text/html") >= 0)
                {
                    throw new ServiceException(webException.Message, (int)errorResponse.StatusCode, webException);
                }
                Stream errorStream = errorResponse.GetResponseStream();
                StreamReader reader = new StreamReader(errorStream);
                string errorMessage = reader.ReadToEnd();
                ErrorResource errorResource = JsonConvert.DeserializeObject<ErrorResource>(errorMessage);

                errorResponse.Close();
                errorStream.Close();
                reader.Close();
                throw new SuperMap.Connector.Utility.ServiceException(errorResource.Error.ErrorMsg, errorResource.Error.Code, webException);
            }
        }
#endif
#if !WINDOWS_PHONE
        public static string GetMapImageUrl(string url)
        {
            HttpWebRequest httpWebRequest = WebRequest.Create(url) as HttpWebRequest;
            httpWebRequest.Method = "GET";
            httpWebRequest.KeepAlive = true;
            try
            {
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                return httpWebResponse.ResponseUri.AbsoluteUri;
            }
            catch (WebException webException)
            {
                HttpWebResponse errorResponse = webException.Response as HttpWebResponse;
                if (errorResponse == null)
                {
                    throw new ServiceException(webException.Message, (int)(webException.Status), webException);
                }
                //当资源不存在时，tomcat返回404错误，错误流为html类型，故处理
                if (errorResponse.ContentType.IndexOf("text/html") >= 0)
                {
                    throw new ServiceException(webException.Message, (int)errorResponse.StatusCode, webException);
                }
                Stream errorStream = errorResponse.GetResponseStream();
                StreamReader reader = new StreamReader(errorStream);
                string errorMessage = reader.ReadToEnd();
                ErrorResource errorResource = JsonConvert.DeserializeObject<ErrorResource>(errorMessage);

                errorResponse.Close();
                errorStream.Close();
                reader.Close();
                throw new SuperMap.Connector.Utility.ServiceException(errorResource.Error.ErrorMsg, errorResource.Error.Code, webException);
            }
        }
#endif
    }

    internal enum HttpRequestMethod
    {
        CONNECT,
        GET,
        HEAD,
        MKCOL,
        POST,
        PUT
    }
}
