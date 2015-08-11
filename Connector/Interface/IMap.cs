using System;
using System.Collections.Generic;
using System.Text;
using SuperMap.Connector.Utility;

namespace SuperMap.Connector.Interface
{
    /// <summary>
    /// SuperMap Connector for .NET Map组件接口，用以访问SuperMap iServer REST中Map资源。
    /// </summary>
    public interface IMap : IComponent
    {
        /// <summary>
        /// 获取指定服务中的所有的地图名称。
        /// </summary>
        /// <returns>地图名称列表。</returns>
        List<string> GetMapNames();

        /// <summary>
        /// 获取指定地图名称的默认的地图参数。
        /// </summary>
        /// <param name="mapName">地图名称。</param>
        /// <returns>返回的地图参数对象。</returns>
        MapParameter GetDefaultMapParameter(string mapName);

        /// <summary>
        /// 根据地图分块信息，获取格网图片。
        /// </summary>
        /// <param name="mapName">地图名称。</param>
        /// <param name="tileInfo">地图分块信息。</param>
        /// <param name="imageOutputOption">图片输出设置。</param>
        /// <returns>所获取的格网图片信息。</returns>
        MapImage GetTile(string mapName, TileInfo tileInfo, ImageOutputOption imageOutputOption);

        /// <summary>
        /// 根据地图分块信息和地图参数设置，获取格网图片。
        /// </summary>
        /// <param name="mapName">地图名称。</param>
        /// <param name="tileInfo">地图分块信息。</param>
        /// <param name="imageOutputOption">图片输出设置。</param>
        /// <param name="mapParameter">地图参数。</param>
        /// <returns>所获取的格网图片信息。</returns>
        MapImage GetTile(string mapName, TileInfo tileInfo, ImageOutputOption imageOutputOption, MapParameter mapParameter);

        /// <summary>
        /// 根据地图参数、图片输出设置获取地图图片。
        /// </summary>
        /// <param name="mapName">地图名称。</param>
        /// <param name="mapParameter">地图参数。</param>
        /// <param name="imageOutputOption">图片输出设置。</param>
        /// <returns>所获取的地图图片对象。</returns>
        MapImage GetMapImage(string mapName, MapParameter mapParameter, ImageOutputOption imageOutputOption);

        /// <summary>
        /// 根据资源图片参数获取资源图片。
        /// </summary>
        /// <param name="mapName">地图名称。</param>
        /// <param name="resourceParameter">资源图片参数，如生成的图片的高度、宽度、类型，资源的类型、风格等。</param>
        /// <param name="imageOutputOption">资源图片输出设置。</param>
        /// <returns>资源图片对象。</returns>
        ResourceImage GetResource(string mapName, ResourceParameter resourceParameter, ImageOutputOption imageOutputOption);


        /// <summary>
        /// 获取地图的鹰眼图片。
        /// </summary>
        /// <param name="mapName">地图名称。</param>
        /// <param name="mapParameter">地图参数。</param>
        /// <param name="imageOutputOption">图片输出设置。</param>
        /// <returns>鹰眼对象。</returns>
        Overview GetOverview(string mapName, MapParameter mapParameter, ImageOutputOption imageOutputOption);


        /// <summary>
        /// 获取地图的全幅显示图片。
        /// </summary>
        /// <param name="mapName">地图名称。</param>
        /// <param name="mapParameter">地图参数。</param>
        /// <param name="imageOutputOption">图片输出设置。</param>
        /// <returns>全幅显示图片对象。</returns>
        MapImage GetEntireImage(string mapName, MapParameter mapParameter, ImageOutputOption imageOutputOption);


        /// <summary>
        /// 根据指定的图层的范围获取地图的全幅显示图片。
        /// </summary>
        /// <param name="mapName">地图名称。</param>
        /// <param name="layerName">指定图层，以该图层内容的最小外接矩形作为全幅显示的地理范围。</param>
        /// <param name="mapParameter">地图参数。</param>
        /// <param name="imageOutputOption">图片输出设置。</param>
        /// <returns>全幅显示图片对象。</returns>
        MapImage GetEntireImage(string mapName, string layerName, MapParameter mapParameter, ImageOutputOption imageOutputOption);

        /// <summary>
        /// 根据查询结果资源ID，获取查询结果高亮图片，图片只支持PNG格式。
        /// </summary>
        /// <param name="mapName">地图名称。</param>
        /// <param name="queryResultID">查询结果资源ID。</param>
        /// <param name="style">高亮风格设置。</param>
        /// <param name="mapParameter">地图参数。</param>
        /// <param name="imageOutputOption">图片输出设置。</param>
        /// <returns>高亮图片对象。</returns>
        MapImage GetHighlightImage(string mapName, string queryResultID, Style style, MapParameter mapParameter, ImageOutputOption imageOutputOption);


        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="mapName"></param>
        ///// <param name="highlightTargetSetID"></param>
        ///// <param name="mapParameter"></param>
        ///// <param name="imageOutputOption"></param>
        ///// <returns></returns>
        //MapImage GetHighlightImage(string mapName, string highlightTargetSetID, MapParameter mapParameter, ImageOutputOption imageOutputOption);

        /// <summary>
        /// 在指定的地图上，查询与指定的矩形范围以及符合某种空间关系和查询条件的几何对象。
        /// </summary>
        /// <param name="mapName">地图名称。</param>
        /// <param name="bounds">矩形范围。</param>
        /// <param name="queryParameterSet">查询参数集。可对某个地图的多个图层进行查询，单个图层的查询参数在 queryParameters.queryParams[i] 中进行设置。 </param>
        /// <returns>查询结果集。</returns>
        QueryResult QueryByBounds(string mapName, Rectangle2D bounds, QueryParameterSet queryParameterSet);

        /// <summary>
        /// 在指定的地图上，查询距离指定几何对象一定范围内的几何对象。
        /// </summary>
        /// <param name="mapName">地图名称。</param>
        /// <param name="geometry">几何对象。</param>
        /// <param name="distance">查询的距离范围。</param>
        /// <param name="queryParameterSet">查询参数集。可对某个地图的多个图层进行查询，单个图层的查询参数在 queryParameters.queryParams[i] 中进行设置。 
        /// </param>
        /// <returns>查询结果集。</returns>
        /// <remarks>到指定几何对象的一定距离范围，实际是以指定几何对象为中心的一个圆，在这个圆内以及与圆相交的几何对象都能够被查询出来。
        /// </remarks>
        QueryResult QueryByDistance(string mapName, Geometry geometry, double distance, QueryParameterSet queryParameterSet);

        /// <summary>
        /// 在指定的地图上，查询与指定的几何对象符合某种空间关系和查询条件的几何对象。
        /// </summary>
        /// <param name="mapName">地图名称。</param>
        /// <param name="geometry">几何对象。</param>
        /// <param name="spatialQueryMode">空间几何对象间的查询模式
        /// <para>空间几何对象间的查询模式定义了一些几何对象之间的空间位置关系，根据这些空间关系来构建过滤条件执行查询。</para>
        /// <example>查询可被包含在面对象中的空间对象，与面有相离或者相邻关系的空间对象等。</example>
        /// </param>
        /// <param name="queryParameterSet">查询参数集。可对某个地图的多个图层进行查询，单个图层的查询参数在queryParameters.queryParams[i]中进行设置。 </param>
        /// <returns>查询结果集。</returns>
        QueryResult QueryByGeometry(string mapName, Geometry geometry, SpatialQueryMode spatialQueryMode, QueryParameterSet queryParameterSet);

        /// <summary>
        ///  在指定的地图上，执行 SQL 查询。
        /// </summary>
        /// <param name="mapName">地图名称。</param>
        /// <param name="queryParameterSet">查询参数集。可对某个地图的多个图层进行查询，单个图层的查询参数在queryParameters.queryParams[i]中进行设置。 </param>
        /// <returns>查询结果集。</returns>
        QueryResult QueryBySQL(string mapName, QueryParameterSet queryParameterSet);

        /// <summary>
        /// 在指定的地图上，查找距离指定几何对象一定距离容限内最近的对象。
        /// </summary>
        /// <param name="mapName">地图名称。</param>
        /// <param name="geometry">几何对象。</param>
        /// <param name="maxDistance">容限距离。</param>
        /// <param name="queryParameterSet">查询参数集。可对某个地图的多个图层进行查询，单个图层的查询参数在queryParameters.queryParams[i]中进行设置。 </param>
        /// <returns>查询结果对象。</returns>
        QueryResult FindNearest(string mapName, Geometry geometry, double maxDistance, QueryParameterSet queryParameterSet);

        /// <summary>
        /// 根据地图名称、二维地理坐标点、量算单位进行面积量算。
        /// </summary>
        /// <param name="mapName">地图名称。</param>
        /// <param name="point2Ds">二维地理坐标点数组。 </param>
        /// <param name="unit">返回结果的单位。</param>
        /// <returns>量算结果对象。</returns>
        MeasureAreaResult MeasureArea(string mapName, List<Point2D> point2Ds, Unit unit);

        /// <summary>
        /// 根据地图名称、二维地理坐标点、量算单位进行距离量算。
        /// </summary>
        /// <param name="mapName">地图名称。</param>
        /// <param name="point2Ds">二维地理坐标点数组。</param>
        /// <param name="unit">返回结果的单位。</param>
        /// <returns>量算结果对象。</returns>
        MeasureDistanceResult MeasureDistance(string mapName, List<Point2D> point2Ds, Unit unit);

        /// <summary>
        /// 清除指定地图范围的缓存。
        /// </summary>
        /// <param name="mapName">地图名称。</param>
        /// <param name="bounds">地图范围。</param>
        /// <returns>清除缓存是否成功。</returns>
        bool ClearCache(string mapName, Rectangle2D bounds);
    }
}
