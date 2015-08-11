using System;
using System.Collections.Generic;
using System.Text;
using SuperMap.Connector.Utility;
using Newtonsoft.Json;
#if !WINDOWS_PHONE
using System.Web;
#else 
using System.Net;
#endif

namespace SuperMap.Connector
{
    /// <summary>
    /// TrafficTransfer服务提供者。
    /// </summary>
    internal class TrafficTransferAnalystProvider
    {
        private string _serviceUrl = string.Empty;

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="serviceUrl">服务地址。</param>
        public TrafficTransferAnalystProvider(string serviceUrl)
        {
            this._serviceUrl = serviceUrl;
        }

        /// <summary>
        /// 获取指定服务中的所有的公交网络名称。
        /// </summary>
        /// <returns>公交网络名称列表。</returns>
        public List<string> GetNames()
        {
            string uri = string.Format("{0}/traffictransferanalyst.json?", this._serviceUrl);
            string requestResultJson = SynchHttpRequest.GetRequestString(uri);
            List<TransferResourceResult> resourceResults = JsonConvert.DeserializeObject<List<TransferResourceResult>>(requestResultJson);
            List<string> names = new List<string>();
            if (resourceResults != null && resourceResults.Count > 0)
            {
                foreach (TransferResourceResult result in resourceResults)
                {
                    names.Add(result.Name);
                }
            }
            return names;
        }

        public void GetNamesAsync(EventHandler<GetTraferNetNamesEventArgs> completed, EventHandler<FailedEventArgs> failed)
        {
            string uri = string.Format("{0}/traffictransferanalyst.json?", this._serviceUrl);
            EventHandler<AsyncEventArgs<string>> callback = (sender, e) =>
            {
                if (e != null)
                {
                    List<TransferResourceResult> resourceResults = JsonConvert.DeserializeObject<List<TransferResourceResult>>(e.Result);
                    List<string> names = new List<string>();
                    if (resourceResults != null && resourceResults.Count > 0)
                    {
                        for (int i = 0; i < resourceResults.Count; i++)
                        {
                            names.Add(resourceResults[i].Name);
                        }
                    }
                    if (completed != null)
                    {
                        completed(this, new GetTraferNetNamesEventArgs(names));
                    }
                }
            };
            AsyncHttpRequest.DownloadStringAsync(uri, null, callback, failed);
        }

        /// <summary>
        /// 在指定的公交网络中查找公交站。
        /// </summary>
        /// <param name="transferNetName">公交网络的名称。</param>
        /// <param name="keyWord">站点名称关键字。</param>
        /// <param name="returnPosition">是否获取公交站的坐标。</param>
        /// <returns>根据站点名称查找当前公交网络中匹配的公交站点。</returns>
        public List<TransferStopInfo> FindStopsByKeyWord(string transferNetName, string keyWord, bool returnPosition)
        {
            string uri = string.Format("{0}/traffictransferanalyst/{1}/stops/keyword/{2}.json?returnPosition={3}",
                this._serviceUrl, HttpUtility.UrlEncode(transferNetName), HttpUtility.UrlEncode(keyWord), returnPosition?"true":"false");
            string requestResultJson = SynchHttpRequest.GetRequestString(uri);

            TransferStopInfo[] resultArray= JsonConvert.DeserializeObject<TransferStopInfo[]>(requestResultJson);
            List<TransferStopInfo> result = null;
            if (resultArray != null && resultArray.Length > 0)
            {
                result = new List<TransferStopInfo>();
                for (int i = 0; i < resultArray.Length; i++)
                {
                    result.Add(resultArray[i]);
                }
            }
            return result;
        }

        public void FindStopsByKeyWordAsync(string transferNetName, string keyWord, bool returnPosition,EventHandler<TransferStopsEventArgs> completed,EventHandler<FailedEventArgs> failed)
        {
            string uri = string.Format("{0}/traffictransferanalyst/{1}/stops/keyword/{2}.json?returnPosition={3}",
                this._serviceUrl, HttpUtility.UrlEncode(transferNetName), HttpUtility.UrlEncode(keyWord), returnPosition?"true":"false");

            EventHandler<AsyncEventArgs<string>> callback = (sender, e) =>
            {
                if (e != null)
                {
                    TransferStopInfo[] resultArray = JsonConvert.DeserializeObject<TransferStopInfo[]>(e.Result);
                    List<TransferStopInfo> result = null;
                    if (resultArray != null && resultArray.Length > 0)
                    {
                        result = new List<TransferStopInfo>();
                        for (int i = 0; i < resultArray.Length; i++)
                        {
                            result.Add(resultArray[i]);
                        }
                    }
                    if (completed != null)
                    {
                        completed(this, new TransferStopsEventArgs(result));
                    }
                }
            };
            AsyncHttpRequest.DownloadStringAsync(uri, null, callback, failed);
        }

        public TransferGuide FindTransferPath(string transferNetName, long startStopID, long endStopID, TransferLine[] transferLines)
        {
            TransferLine[] lines=new TransferLine[transferLines.Length];
            for (int i = 0; i < transferLines.Length; i++)
            {
                lines[i] = new TransferLine();
                lines[i].EndStopIndex = transferLines[i].EndStopIndex;
                lines[i].StartStopIndex = transferLines[i].StartStopIndex;
                lines[i].LineID = transferLines[i].LineID;
            }
            string uri = string.Format("{0}/traffictransferanalyst/{1}/path.rjson?points=[{2},{3}]&transferLines={4}",
               this._serviceUrl, transferNetName, startStopID, endStopID, JsonConvert.SerializeObject(lines));

            string result = SynchHttpRequest.GetRequestString(uri);
            return JsonConvert.DeserializeObject<TransferGuide>(result, new DateTimeConverter());
        }

        public void FindTransferPathAsync(string transferNetName, long startStopID, long endStopID, TransferLine[] transferLines, EventHandler<TransferAnalystResultEventArgs> completed, EventHandler<FailedEventArgs> failed)
        {
            TransferLine[] lines = new TransferLine[transferLines.Length];
            for (int i = 0; i < transferLines.Length; i++)
            {
                lines[i] = new TransferLine();
                lines[i].EndStopIndex = transferLines[i].EndStopIndex;
                lines[i].StartStopIndex = transferLines[i].StartStopIndex;
                lines[i].LineID = transferLines[i].LineID;
            }
            string uri = string.Format("{0}/traffictransferanalyst/{1}/path.rjson?points=[{2},{3}]&transferLines={4}",
               this._serviceUrl, transferNetName, startStopID, endStopID, JsonConvert.SerializeObject(lines));

            EventHandler<AsyncEventArgs<string>> callback = (sender, e) =>
            {
                if (e != null)
                {
                    TransferGuide result = JsonConvert.DeserializeObject<TransferGuide>(e.Result, new DateTimeConverter());

                    if (completed != null)
                    {
                        completed(this, new TransferAnalystResultEventArgs(result));
                    }
                }
            };
            AsyncHttpRequest.DownloadStringAsync(uri, null, callback, failed);
        }

        /// <summary>
        /// 根据指定的起止点坐标及交通换乘分析参数进行交通换乘分析。
        /// </summary>
        /// <param name="transferNetName">公交网络名字。</param>
        /// <param name="startPosition">起始点坐标。</param>
        /// <param name="endPosition">终止点坐标。</param>
        /// <param name="trafficTransferAnalystParameter">交通换乘分析参数。</param>
        /// <returns>交通换乘分析结果。</returns>
        public TransferGuide FindTransferPath(string transferNetName, Point2D startPosition, Point2D endPosition, TransferLine[] transferLines)
        {
            TransferLine[] lines = new TransferLine[transferLines.Length];
            for (int i = 0; i < transferLines.Length; i++)
            {
                lines[i] = new TransferLine();
                lines[i].EndStopIndex = transferLines[i].EndStopIndex;
                lines[i].StartStopIndex = transferLines[i].StartStopIndex;
                lines[i].LineID = transferLines[i].LineID;
            }
            string uri = string.Format("{0}/traffictransferanalyst/{1}/path.rjson?points={2}&transferLines={3}",
               this._serviceUrl, transferNetName,JsonConvert.SerializeObject(new Point2D[] { startPosition, endPosition }), JsonConvert.SerializeObject(lines));

            string result = SynchHttpRequest.GetRequestString(uri);

            return JsonConvert.DeserializeObject<TransferGuide>(result);
        }

        public void FindTransferPathAsync(string transferNetName, Point2D startPosition, Point2D endPosition, TransferLine[] transferLines, EventHandler<TransferAnalystResultEventArgs> completed, EventHandler<FailedEventArgs> failed)
        {
            TransferLine[] lines = new TransferLine[transferLines.Length];
            for (int i = 0; i < transferLines.Length; i++)
            {
                lines[i] = new TransferLine();
                lines[i].EndStopIndex = transferLines[i].EndStopIndex;
                lines[i].StartStopIndex = transferLines[i].StartStopIndex;
                lines[i].LineID = transferLines[i].LineID;
            }
            string uri = string.Format("{0}/traffictransferanalyst/{1}/path.rjson?points={2}&transferLines={3}",
               this._serviceUrl, transferNetName, JsonConvert.SerializeObject(new Point2D[] { startPosition, endPosition }), JsonConvert.SerializeObject(lines));

            EventHandler<AsyncEventArgs<string>> callback = (sender, e) =>
            {
                if (e != null)
                {
                    TransferGuide result = JsonConvert.DeserializeObject<TransferGuide>(e.Result, new DateTimeConverter());

                    if (completed != null)
                    {
                        completed(this, new TransferAnalystResultEventArgs(result));
                    }
                }
            };
            AsyncHttpRequest.DownloadStringAsync(uri, null, callback, failed);
        }

        public TransferSolutions FindTransferSolutions(string transferNetName, long startStopID, long endStopID, TrafficTransferAnalystParameter trafficTransferAnalystParameter)
        {
            string uri = string.Format("{0}/traffictransferanalyst/{1}/solutions.rjson?points=[{2},{3}]&solutionCount={4}&transferTactic={5}&transferPreference={6}&walkingRatio={7}",
               this._serviceUrl, transferNetName, startStopID, endStopID, trafficTransferAnalystParameter.SolutionCount, trafficTransferAnalystParameter.TransferTactic, trafficTransferAnalystParameter.TransferPreference, trafficTransferAnalystParameter.WalkingRatio);
            string result = SynchHttpRequest.GetRequestString(uri);
            return JsonConvert.DeserializeObject<TransferSolutions>(result);
        }

        public void FindTransferSolutionsAsync(string transferNetName, long startStopID, long endStopID, TrafficTransferAnalystParameter trafficTransferAnalystParameter, EventHandler<TransferAnalystSolutionEventArgs> completed, EventHandler<FailedEventArgs> failed)
        {
            string uri = string.Format("{0}/traffictransferanalyst/{1}/solutions.rjson?points=[{2},{3}]&solutionCount={4}&transferTactic={5}&transferPreference={6}&walkingRatio={7}",
               this._serviceUrl, transferNetName, startStopID, endStopID, trafficTransferAnalystParameter.SolutionCount, trafficTransferAnalystParameter.TransferTactic, trafficTransferAnalystParameter.TransferPreference, trafficTransferAnalystParameter.WalkingRatio);
            
            EventHandler<AsyncEventArgs<string>> callback = (sender, e) =>
            {
                if (e != null)
                {
                    TransferSolutions result = JsonConvert.DeserializeObject<TransferSolutions>(e.Result);

                    if (completed != null)
                    {
                        completed(this, new TransferAnalystSolutionEventArgs(result));
                    }
                }
            };
            AsyncHttpRequest.DownloadStringAsync(uri, null, callback, failed);
        }

        public TransferSolutions FindTransferSolutions(string transferNetName, Point2D startPosition, Point2D endPosition, TrafficTransferAnalystParameter trafficTransferAnalystParameter)
        {
            string uri = string.Format("{0}/traffictransferanalyst/{1}/solutions.rjson?points={2}&solutionCount={3}&transferTactic={4}&transferPreference={5}&walkingRatio={6}",
               this._serviceUrl, transferNetName, JsonConvert.SerializeObject(new Point2D[] { startPosition, endPosition }), trafficTransferAnalystParameter.SolutionCount, trafficTransferAnalystParameter.TransferTactic, trafficTransferAnalystParameter.TransferPreference, trafficTransferAnalystParameter.WalkingRatio);
            string result = SynchHttpRequest.GetRequestString(uri);
            return JsonConvert.DeserializeObject<TransferSolutions>(result);
        }

        public void FindTransferSolutionsAsync(string transferNetName, Point2D startPosition, Point2D endPosition, TrafficTransferAnalystParameter trafficTransferAnalystParameter, EventHandler<TransferAnalystSolutionEventArgs> completed, EventHandler<FailedEventArgs> failed)
        {
            string uri = string.Format("{0}/traffictransferanalyst/{1}/solutions.rjson?points={2}&solutionCount={3}&transferTactic={4}&transferPreference={5}&walkingRatio={6}",
               this._serviceUrl, transferNetName, JsonConvert.SerializeObject(new Point2D[] { startPosition, endPosition }), trafficTransferAnalystParameter.SolutionCount, trafficTransferAnalystParameter.TransferTactic, trafficTransferAnalystParameter.TransferPreference, trafficTransferAnalystParameter.WalkingRatio);
            
            EventHandler<AsyncEventArgs<string>> callback = (sender, e) =>
            {
                if (e != null)
                {
                    TransferSolutions result = JsonConvert.DeserializeObject<TransferSolutions>(e.Result);

                    if (completed != null)
                    {
                        completed(this, new TransferAnalystSolutionEventArgs(result));
                    }
                }
            };
            AsyncHttpRequest.DownloadStringAsync(uri, null, callback, failed);
        }
    }
}
