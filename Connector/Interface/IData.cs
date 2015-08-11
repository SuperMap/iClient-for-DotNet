using System;
using System.Collections.Generic;
using System.Text;
using SuperMap.Connector.Utility;

namespace SuperMap.Connector.Interface
{
    /// <summary>
    /// SuperMap Connector for .NET Data组件接口，用以访问SuperMap iServer REST中Data资源。
    /// </summary>
    public interface IData : IComponent
    {
        /// <summary>
        /// 在指定数据集中增加一组同类型的要素。
        /// </summary>
        /// <param name="datasourceName">数据源名称。</param>
        /// <param name="datasetName">数据集名称。</param>
        /// <param name="targetFeatures">待添加的要素列表，列表中的要素必须是同一种类型。</param>
        /// <returns></returns>
        EditResult AddFeatures(string datasourceName, String datasetName, List<Feature> targetFeatures);

        /// <summary>
        /// 在指定的数据集中删除一组要素。
        /// </summary>
        /// <param name="datasourceName">数据源名称。</param>
        /// <param name="datasetName">数据集名称。</param>
        /// <param name="ids">待删除要素的 ID 数组。</param>
        /// <returns>编辑结果。</returns>
        EditResult DeleteFeatures(string datasourceName, string datasetName, int[] ids);

        /// <summary>
        /// 在指定的数据集中，更新一组要素。
        /// 参数 targetFeatures 是新要素列表，其要素 ID 与数据集中待更新的要素 ID 相同，根据 ID 查找到待更新的要素， 然后将原要素更新到新的要素。
        /// </summary>
        /// <param name="datasourceName">数据源名称。</param>
        /// <param name="datasetName">数据源名称。</param>
        /// <param name="targetFeatures">新要素列表。其 ID 与要更新的要素 ID 相同。</param>
        /// <returns></returns>
        EditResult UpdateFeatures(string datasourceName, string datasetName, List<Feature> targetFeatures);
    }
}
