using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMap.Connector.Utility
{
    /// <summary>
    /// 提供访问服务返回失败时的数据。
    /// </summary>
    class ServiceErrorEventArgs : EventArgs
    {
        private ServiceException _exception = null;
        /// <summary>
        /// 访问服务失败时的异常信息。
        /// </summary>
        public ServiceException Exception
        {
            get
            {
                return _exception;
            }
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="exception">异常信息。</param>
        public ServiceErrorEventArgs(ServiceException exception)
        {
            this._exception = exception;
        }
    }

    #region Map

    /// <summary>
    /// 为GetMapNames方法的回调函数提供数据。
    /// </summary>
    public class GetMapNamesEventArgs : EventArgs
    {
        /// <summary>
        /// 地图名列表。
        /// </summary>
        public List<string> MapNames { get; private set; }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="mapNames">地图名列表。</param>
        public GetMapNamesEventArgs(List<string> mapNames)
        {
            if (mapNames != null)
            {
                this.MapNames = new List<string>();

                for (int i = 0; i < mapNames.Count; i++)
                {
                    this.MapNames.Add(mapNames[i]);
                }
            }
            
        }
    }
    #endregion

    #region TransferAnalyst

    /// <summary>
    /// 为GetNames方法的回调函数提供数据。
    /// </summary>
    public class GetTraferNetNamesEventArgs : EventArgs
    {
        /// <summary>
        /// 公交网络名称列表。
        /// </summary>
        public List<string> Names { get; private set; }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="mapNames">公交网络名称列表。</param>
        public GetTraferNetNamesEventArgs(List<string> names)
        {
            if (names != null)
            {
                Names = new List<string>();

                for (int i = 0; i < names.Count; i++)
                {
                    this.Names.Add(names[i]);
                }
            }
            
        }
    }

    /// <summary>
    /// 为FindStopsByKeyWord方法的回调函数提供数据。
    /// </summary>
    public class TransferStopsEventArgs : EventArgs
    {
        /// <summary>
        /// 匹配的公交站点列表。
        /// </summary>
        public List<TransferStopInfo> Stops { get; private set; }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="stops">匹配的公交站点列表。</param>
        public TransferStopsEventArgs(List<TransferStopInfo> stops)
        {
            if (stops != null)
            {
                Stops = new List<TransferStopInfo>();
                for (int i = 0; i < stops.Count; i++)
                {
                    Stops.Add(new TransferStopInfo(stops[i]));
                }
            }
        }
    }

    /// <summary>
    /// 为FindTransferPath方法的回调函数提供数据。
    /// </summary>
    public class TransferAnalystResultEventArgs : EventArgs
    {
        /// <summary>
        /// 公交分析的结果。
        /// </summary>
        public TransferGuide Result { get; private set; }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="result">公交分析的结果。</param>
        public TransferAnalystResultEventArgs(TransferGuide result)
        {
            if (result != null)
            {
                Result = new TransferGuide(result);
            }
        }
    }

    /// <summary>
    /// 为FindTransferSolutions方法的回调函数提供数据。
    /// </summary>
    public class TransferAnalystSolutionEventArgs : EventArgs
    {
        private TransferSolutions _solutions;

        /// <summary>
        /// 初始化TransferAnalystSolutionEventArgs类的新实例。
        /// </summary>
        /// <param name="solutions">FindTransferSolutions方法的返回结果。</param>
        public TransferAnalystSolutionEventArgs(TransferSolutions solutions)
        {
            this._solutions = solutions;
        }

        /// <summary>
        /// 交通换乘方案集合类。
        /// </summary>
        public TransferSolutions Solutions
        {
            get { return _solutions; }
        }
    }
    #endregion
    //public class GetMapParameterEventArgs : EventArgs
    //{
    //    public MapParameter MapParameter { get; private set; }

    //    public GetMapParameterEventArgs(MapParameter mapParameter)
    //    {
    //        this.MapParameter = mapParameter;
    //    }
    //}

    //public class MeasureAreaEventArgs : EventArgs
    //{
    //    public MeasureAreaResult MearsureAreaResult { get; private set; }

    //    public MeasureAreaEventArgs(MeasureAreaResult measureAreaResult)
    //    {
    //        this.MearsureAreaResult = measureAreaResult;
    //    }
    //}

    //public class MeasureDistanceEventArgs : EventArgs
    //{
    //    public MeasureDistanceResult MeasureDistanceResult { get; set; }

    //    public MeasureDistanceEventArgs(MeasureDistanceResult measureDistanceResult)
    //    {
    //        this.MeasureDistanceResult = measureDistanceResult;
    //    }
    //}

    /// <summary>
    /// 请求失败时的事件数据。
    /// </summary>
    public class FailedEventArgs : EventArgs
    {
        private Exception _exception = null;

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="exception">异常对象。</param>
        public FailedEventArgs(Exception exception)
        {
            _exception = exception;
        }

        /// <summary>
        /// 获取异常信息。
        /// </summary>
        public Exception Exception
        {
            get
            {
                return _exception;
            }
        }
    }

    /// <summary>
    /// 地图参数事件数据。
    /// </summary>
    public class MapParameterEventArgs : EventArgs
    {
        private MapParameter _mapParameter = null;

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="mapParameter">地图参数对象。</param>
        public MapParameterEventArgs(MapParameter mapParameter)
        {
            _mapParameter = mapParameter;
        }

        /// <summary>
        /// 获取地图参数对象。
        /// </summary>
        public MapParameter MapParameter
        {
            get { return this._mapParameter; }
        }
    }

    /// <summary>
    /// 为查询相关的请求提供数据。
    /// </summary>
    public class QueryEventArgs : EventArgs
    {
        private QueryResult _queryResult = null;

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="queryResult">查询结果对象。</param>
        public QueryEventArgs(QueryResult queryResult)
        {
            _queryResult = queryResult;
        }

        /// <summary>
        /// 获取查询结果。
        /// </summary>
        public QueryResult QueryResult
        {
            get
            {
                return _queryResult;
            }
        }
    }

    /// <summary>
    /// 为最短路径分析完成后事件提供数据。
    /// </summary>
    public class FindPathEventArgs : EventArgs
    {
        private List<Path> _paths = null;

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="paths">最短路径分析结果集合。</param>
        public FindPathEventArgs(List<Path> paths)
        {
            this._paths = paths;
        }

        /// <summary>
        /// 获取最短路径分析结果。
        /// </summary>
        public List<Path> Paths
        {
            get
            {
                return _paths;
            }
        }
    }

}
