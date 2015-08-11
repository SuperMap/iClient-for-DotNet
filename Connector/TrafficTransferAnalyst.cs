using System;
using System.Collections.Generic;
using System.Text;
using SuperMap.Connector.Utility;

namespace SuperMap.Connector
{
    public class TrafficTransferAnalyst
    {
        /// <summary>
        /// 交通换乘分析服务组件接口，用以访问 SuperMap iServer 地图服务组件中的REST服务，封装了与交通换乘相关的一系列功能。
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item><description>只能对 SuperMap REST 接口类型服务的访问。</description></item>
        /// <item><description>实例化Map对象时需要使用明确的地图服务组件地址(例如：http://localhost:8090/iserver/services/traffictransferanalyst-sample/restjsr/") </description></item>
        /// </list>
        /// </remarks>
        /// <example>
        /// <code>
        /// using System;
        /// using SuperMap.Connector;
        /// using System.Collections.Generic;
        ///
        /// class Program
        /// {
        ///     static void Main(string[] args)
        ///     {
        ///         //根据服务地址获取一个TrafficTransferAnalyst对象。
        ///         TrafficTransferAnalyst transfer = new TrafficTransferAnalyst("http://localhost:8090/iserver/services/traffictransferanalyst-sample/restjsr/");
        /// 
        ///         //获取所有的公交网络。
        ///         List&lt;string&gt; names = transfer.GetNames();
        /// 
        ///     }
        /// }
        /// 
        /// //公交网络名称：Traffic-BeiJing
        /// </code>
        /// </example>
        #region 成员变量

        private string _serviceUrl;
        private TrafficTransferAnalystProvider _trafficTransferAnalystProvider= null;

        /// <summary>
        /// SuperMap iServer 公交换乘服务组件地址。
        /// </summary>
        public string ServiceUrl
        {
            get { return this._serviceUrl; }
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="serviceUrl">SuperMap iServer 地图服务组件的URL地址。</param>
        /// <exception cref="ArgumentNullException">参数 serviceUrl 为空时抛出异常。</exception>
        public TrafficTransferAnalyst(string serviceUrl)
        {
            if (string.IsNullOrEmpty(serviceUrl))
            {
                throw new ArgumentNullException("serviceUrl", "serivceUrl is null");
            }
            if (serviceUrl.Trim().EndsWith("/"))
            {
                int lastLocation = serviceUrl.LastIndexOf("/");
                if (lastLocation >= 0)
                {
                    serviceUrl = serviceUrl.Substring(0, lastLocation);
                }
            }
            this._serviceUrl = serviceUrl;
            this._trafficTransferAnalystProvider = new TrafficTransferAnalystProvider(this._serviceUrl);
        }

        /// <summary>
        /// 获取指定服务中的所有的公交网络名称。
        /// </summary>
        /// <returns>公交网络名称列表。</returns>
        public List<string> GetNames()
        {
            return _trafficTransferAnalystProvider.GetNames();
        }

        /// <summary>
        /// 异步方式获取指定服务中的所有的公交网络名称。
        /// </summary>
        /// <param name="completed">完成后执行的方法。</param>
        /// <param name="failed">发生异常后执行的方法。</param>
        public void GetNames(EventHandler<GetTraferNetNamesEventArgs> completed, EventHandler<FailedEventArgs> failed)
        {
            EventHandler<GetTraferNetNamesEventArgs> callback = (sender, e) =>
            {
                if (completed != null)
                {
                    completed(this, e);
                }
            };
            _trafficTransferAnalystProvider.GetNamesAsync(callback, failed);
        }

        /// <summary>
        /// 在指定的公交网络中查找公交站。
        /// </summary>
        /// <param name="transferNetName">公交网络的名称。</param>
        /// <param name="keyWord">站点名称关键字。</param>
        /// <param name="returnPosition">是否获取公交站的坐标。</param>
        /// <returns>根据站点名称查找当前公交网络中匹配的公交站点。</returns>
        /// <exception cref="ArgumentNullException">参数transferNetName或者keyWord为空时抛出异常。</exception>
        public List<TransferStopInfo> FindStopsByKeyWord(string transferNetName, string keyWord, bool returnPosition)
        {
            if (string.IsNullOrEmpty(transferNetName))
            {
                throw new ArgumentNullException("transferNetName");
            }
            if (string.IsNullOrEmpty(keyWord))
            {
                throw new ArgumentNullException("keyWord");
            }
            return _trafficTransferAnalystProvider.FindStopsByKeyWord(transferNetName, keyWord, returnPosition);
        }

        /// <summary>
        /// 通过异步方式在指定的公交网络中查找公交站。
        /// </summary>
        /// <param name="transferNetName">公交网络的名称。</param>
        /// <param name="keyWord">站点名称关键字。</param>
        /// <param name="returnPosition">是否获取公交站的坐标。</param>
        /// <param name="completed">完成后执行的方法。</param>
        /// <param name="failed">发生异常后执行的方法。</param>
        /// <exception cref="ArgumentNullException">参数transferNetName或者keyWord为空时抛出异常。</exception>
        public void FindStopsByKeyWord(string transferNetName, string keyWord, bool returnPosition, EventHandler<TransferStopsEventArgs> completed, EventHandler<FailedEventArgs> failed)
        {
            if (string.IsNullOrEmpty(transferNetName))
            {
                throw new ArgumentNullException("transferNetName");
            }
            if (string.IsNullOrEmpty(keyWord))
            {
                throw new ArgumentNullException("keyWord");
            }
            EventHandler<TransferStopsEventArgs> callback = (sender, e) =>
            {
                if (completed != null)
                {
                    completed(this, e);
                }
            };
            _trafficTransferAnalystProvider.FindStopsByKeyWordAsync(transferNetName, keyWord, returnPosition, callback, failed);
        }

        /// <summary>
        /// 根据指定的起止站点 ID 及换乘信息获取详细的路线信息。
        /// </summary>
        /// <param name="transferNetName">公交网络的名称。</param>
        /// <param name="startStopID">起始站点 ID。</param>
        /// <param name="endStopID">终止站点 ID。</param>
        /// <param name="transferLines">换乘信息。 </param>
        /// <returns>完整的路线信息。</returns>
        /// <exception cref="ArgumentNullException">参数transferNetName或者transferLines为空时抛出异常。</exception>
        public TransferGuide FindTransferPath(string transferNetName, long startStopID, long endStopID, TransferLine[] transferLines)
        {
            if (string.IsNullOrEmpty(transferNetName))
            {
                throw new ArgumentNullException("transferNetName");
            }
            if (transferLines == null)
            {
                throw new ArgumentNullException("trafficTransferAnalystParameter");
            }
            return _trafficTransferAnalystProvider.FindTransferPath(transferNetName, startStopID, endStopID, transferLines);
        }

        /// <summary>
        /// 通过异步方式根据指定的起止站点 ID 及换乘信息获取详细的路线信息。
        /// </summary>
        /// <param name="transferNetName">公交网络的名称。</param>
        /// <param name="startStopID">起始站点 ID。</param>
        /// <param name="endStopID">终止站点 ID。</param>
        /// <param name="transferLines">换乘信息。</param>
        /// <param name="completed">完成后执行的方法。</param>
        /// <param name="failed">发生异常后执行的方法。</param>
        /// <exception cref="ArgumentNullException">参数transferNetName或者transferLines为空时抛出异常。</exception>
        public void FindTransferPath(string transferNetName, long startStopID, long endStopID, TransferLine[] transferLines, EventHandler<TransferAnalystResultEventArgs> completed, EventHandler<FailedEventArgs> failed)
        {
            if (string.IsNullOrEmpty(transferNetName))
            {
                throw new ArgumentNullException("transferNetName");
            }
            if (transferLines == null)
            {
                throw new ArgumentNullException("transferLines");
            }

            EventHandler<TransferAnalystResultEventArgs> callback = (sender, e) =>
            {
                if (completed != null)
                {
                    completed(this, e);
                }
            };

            _trafficTransferAnalystProvider.FindTransferPathAsync(transferNetName, startStopID, endStopID, transferLines, callback, failed);
        }

        /// <summary>
        /// 根据指定的起止点坐标及换乘信息获取详细的路线信息。
        /// </summary>
        /// <param name="transferNetName">公交网络名字。</param>
        /// <param name="startPosition">起始点坐标。</param>
        /// <param name="endPosition">终止点坐标。</param>
        /// <param name="transferLines">换乘信息。</param>
        /// <returns>完整的路线信息。</returns>
        /// <exception cref="ArgumentNullException">参数transferNetName、transferLines、startPosition或者endPosition为空时抛出异常。</exception>
        public TransferGuide FindTransferPath(string transferNetName, Point2D startPosition, Point2D endPosition, TransferLine[] transferLines)
        {
            if (string.IsNullOrEmpty(transferNetName))
            {
                throw new ArgumentNullException("transferNetName");
            }
            if (transferLines == null)
            {
                throw new ArgumentNullException("transferLines");
            }
            if (startPosition == null)
            {
                throw new ArgumentNullException("startPosition");
            }
            if (endPosition == null)
            {
                throw new ArgumentNullException("endPosition");
            }
            return _trafficTransferAnalystProvider.FindTransferPath(transferNetName, startPosition, endPosition, transferLines);
        }

        /// <summary>
        /// 通过异步方式根据指定的起止点坐标及换乘信息获取详细的路线信息。
        /// </summary>
        /// <param name="transferNetName">公交网络名字。</param>
        /// <param name="startPosition">起始点坐标。</param>
        /// <param name="endPosition">终止点坐标。</param>
        /// <param name="transferLines">需要换乘的公交线路信息。</param>
        /// <param name="completed">完成后执行的方法。</param>
        /// <param name="failed">发生异常后执行的方法。</param>
        /// <exception cref="ArgumentNullException">参数transferNetName、transferLines、startPosition或者endPosition为空时抛出异常。</exception>
        public void FindTransferPath(string transferNetName, Point2D startPosition, Point2D endPosition, TransferLine[] transferLines, EventHandler<TransferAnalystResultEventArgs> completed, EventHandler<FailedEventArgs> failed)
        {
            if (string.IsNullOrEmpty(transferNetName))
            {
                throw new ArgumentNullException("transferNetName");
            }
            if (transferLines == null)
            {
                throw new ArgumentNullException("transferLines");
            }
            if (startPosition == null)
            {
                throw new ArgumentNullException("startPosition");
            }
            if (endPosition == null)
            {
                throw new ArgumentNullException("endPosition");
            }

            EventHandler<TransferAnalystResultEventArgs> callback = (sender, e) =>
            {
                if (completed != null)
                {
                    completed(this, e);
                }
            };

            _trafficTransferAnalystProvider.FindTransferPathAsync(transferNetName, startPosition, endPosition, transferLines, callback, failed);
        }

        /// <summary>
        /// 根据指定的起止站点 ID 及交通换乘分析参数进行交通换乘分析。
        /// </summary>
        /// <param name="transferNetName">公交网络名字。</param>
        /// <param name="startStopID">起始站点 ID。</param>
        /// <param name="endStopID">终止站点 ID。</param>
        /// <param name="trafficTransferAnalystParameter">交通换乘分析参数。</param>
        /// <returns>交通换乘方案集合。</returns>
        /// <exception cref="ArgumentNullException">参数transferNetName或者trafficTransferAnalystParameter为空时抛出异常。</exception>
        public TransferSolutions FindTransferSolutions(string transferNetName, long startStopID, long endStopID, TrafficTransferAnalystParameter trafficTransferAnalystParameter)
        {
            if (string.IsNullOrEmpty(transferNetName))
            {
                throw new ArgumentNullException("transferNetName");
            }
            if (trafficTransferAnalystParameter == null)
            {
                throw new ArgumentNullException("trafficTransferAnalystParameter");
            }

            return _trafficTransferAnalystProvider.FindTransferSolutions(transferNetName, startStopID, endStopID, trafficTransferAnalystParameter);
        }

        /// <summary>
        /// 通过异步方式根据指定的起止站点 ID 及交通换乘分析参数进行交通换乘分析。
        /// </summary>
        /// <param name="transferNetName">公交网络名字。</param>
        /// <param name="startStopID">起始站点 ID。</param>
        /// <param name="endStopID">终止站点 ID。</param>
        /// <param name="trafficTransferAnalystParameter">交通换乘分析参数。</param>
        /// <param name="completed">完成后执行的方法。</param>
        /// <param name="failed">发生异常后执行的方法。</param>
        /// <exception cref="ArgumentNullException">参数transferNetName或者trafficTransferAnalystParameter为空时抛出异常。</exception>
        public void FindTransferSolutions(string transferNetName, long startStopID, long endStopID, TrafficTransferAnalystParameter trafficTransferAnalystParameter, EventHandler<TransferAnalystSolutionEventArgs> completed, EventHandler<FailedEventArgs> failed)
        {
            if (string.IsNullOrEmpty(transferNetName))
            {
                throw new ArgumentNullException("transferNetName");
            }
            if (trafficTransferAnalystParameter == null)
            {
                throw new ArgumentNullException("trafficTransferAnalystParameter");
            }

            EventHandler<TransferAnalystSolutionEventArgs> callback = (sender, e) =>
            {
                if (completed != null)
                {
                    completed(this, e);
                }
            };

            _trafficTransferAnalystProvider.FindTransferSolutionsAsync(transferNetName, startStopID, endStopID, trafficTransferAnalystParameter, callback, failed);
        }

        /// <summary>
        /// 根据指定的起止点坐标及交通换乘分析参数进行交通换乘分析。
        /// </summary>
        /// <param name="transferNetName">公交网络名字。</param>
        /// <param name="startPosition">起始点坐标。</param>
        /// <param name="endPosition">终止点坐标。</param>
        /// <param name="trafficTransferAnalystParameter">交通换乘分析参数。</param>
        /// <returns>交通换乘方案集合。</returns>
        /// <exception cref="ArgumentNullException">参数transferNetName、trafficTransferAnalystParameter、startPosition或者endPosition为空时抛出异常。</exception>
        public TransferSolutions FindTransferSolutions(string transferNetName, Point2D startPosition, Point2D endPosition, TrafficTransferAnalystParameter trafficTransferAnalystParameter)
        {
            if (string.IsNullOrEmpty(transferNetName))
            {
                throw new ArgumentNullException("transferNetName");
            }
            if (trafficTransferAnalystParameter == null)
            {
                throw new ArgumentNullException("trafficTransferAnalystParameter");
            }
            if (startPosition == null)
            {
                throw new ArgumentNullException("startPosition");
            }
            if (endPosition == null)
            {
                throw new ArgumentNullException("endPosition");
            }

            return _trafficTransferAnalystProvider.FindTransferSolutions(transferNetName, startPosition, endPosition, trafficTransferAnalystParameter);
        }


        /// <summary>
        /// 通过异步方式根据指定的起止点坐标及交通换乘分析参数进行交通换乘分析。
        /// </summary>
        /// <param name="transferNetName">公交网络名字。</param>
        /// <param name="startPosition">起始点坐标。</param>
        /// <param name="endPosition">终止点坐标。</param>
        /// <param name="trafficTransferAnalystParameter">交通换乘分析参数。</param>
        /// <param name="completed">完成后执行的方法。</param>
        /// <param name="failed">发生异常后执行的方法。</param>
        /// <exception cref="ArgumentNullException">参数transferNetName、trafficTransferAnalystParameter、startPosition或者endPosition为空时抛出异常。</exception>
        public void FindTransferSolutions(string transferNetName, Point2D startPosition, Point2D endPosition, TrafficTransferAnalystParameter trafficTransferAnalystParameter, EventHandler<TransferAnalystSolutionEventArgs> completed, EventHandler<FailedEventArgs> failed)
        {
            if (string.IsNullOrEmpty(transferNetName))
            {
                throw new ArgumentNullException("transferNetName");
            }
            if (trafficTransferAnalystParameter == null)
            {
                throw new ArgumentNullException("trafficTransferAnalystParameter");
            }
            if (startPosition == null)
            {
                throw new ArgumentNullException("startPosition");
            }
            if (endPosition == null)
            {
                throw new ArgumentNullException("endPosition");
            }

            EventHandler<TransferAnalystSolutionEventArgs> callback = (sender, e) =>
            {
                if (completed != null)
                {
                    completed(this, e);
                }
            };

            _trafficTransferAnalystProvider.FindTransferSolutionsAsync(transferNetName, startPosition, endPosition, trafficTransferAnalystParameter, callback, failed);
        }
        #endregion
    }
}
