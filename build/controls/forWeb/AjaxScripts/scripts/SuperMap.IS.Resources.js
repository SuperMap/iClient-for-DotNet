//================================================================================ 
// SuperMap IS .NET 客户端程序，版权所有，北京超图软件股份有限公司，2000-2008。 
// 本程序只能在有效的授权许可下使用。未经许可，不得以任何手段擅自使用或传播。 
// 作 者:  SuperMap IS Web Team 
// 版 本:  $Id: SuperMap.IS.Resources.js,v 1.9 2011/03/16 08:16:13 dongxj Exp $
// 文 件:  SuperMap.IS.Resources.js 
// 描 述:  AjaxScripts 资源 
// 更 新:  $Date: 2011/03/16 08:16:13 $ 
//================================================================================ 

// RegisterNamespaces("SuperMap.IS");
switch (_browserLanguage) {
    case "zh-cn":
        SuperMap.IS.MapControlResource = {
            'mapInitError': '地图初始化失败，请检查地图名是否正确，MapHandler 是否已正确配置，远程服务是否已启动。'
        };

        SuperMap.IS.OverivewControlResource = {
            'getOverivewError': '获取鹰眼图出错',
            'overivewInitError': '鹰眼初始化失败，请检查参数是否正确。'
        };
        SuperMap.IS.LegendControlResource = {
            'negative': '负值',
            'positive': '正值',
            'title': '图例'
        };
        SuperMap.IS.LayerControlResource = {
            'negative': '负值',
            'positive': '正值',
            'title': '图层列表'
        };
        SuperMap.IS.ThemeResource = {
            'themeDotDensity': '点密度专题图',
            'themeGraduatedSymbol': '等级符号专题图',
            'themeGraph': '统计专题图',
            'themeLabel': '标签专题图',
            'themeRange': '分段专题图',
            'themeUnique': '单值专题图',
            'themeGridRange': "栅格分段专题图",
			'themeCustom' : '自定义专题图'
        };
        break;
	case "zh-tw": 
		SuperMap.IS.MapControlResource = {
            'mapInitError': '地圖初始化失敗，請檢查地圖名是否正確，MapHandler 是否已正確配置，遠端服務是否已啟動。'
        };

        SuperMap.IS.OverivewControlResource = {
            'getOverivewError': '獲取鷹眼圖出錯',
            'overivewInitError': '鷹眼初始化失敗，請檢查參數是否正確。'
        };
        SuperMap.IS.LegendControlResource = {
            'negative': '負值',
            'positive': '正值',
            'title': '圖例'
        };
        SuperMap.IS.LayerControlResource = {
            'negative': '負值',
            'positive': '正值',
            'title': '圖層列表'
        };
        SuperMap.IS.ThemeResource = {
            'themeDotDensity': '點密度專題圖',
            'themeGraduatedSymbol': '等級符號專題圖',
            'themeGraph': '統計專題圖',
            'themeLabel': '標籤專題圖',
            'themeRange': '分段專題圖',
            'themeUnique': '單值專題圖',
            'themeGridRange': "柵格分段專題圖",
			'themeCustom' : '自訂專題圖'
        };
        break;
    default:
        // 默认资源。
        SuperMap.IS.MapControlResource = {
            'mapInitError': 'Error occurred when initializing the MapControl, please check the mapName, mapHandler settings and check whether the gis server is started.'
        };

        SuperMap.IS.OverivewControlResource = {
            'getOverivewError': 'Error occurred when getting the overview.',
            'overivewInitError': 'Error occurred when initializing the OverviewControl, please check the params.'
        };
        SuperMap.IS.LegendControlResource = {
            'negative': 'Negative',
            'positive': 'positive',
            'title': 'Legend'
        };
        SuperMap.IS.LayerControlResource = {
            'negative': 'Negative',
            'positive': 'Positive',
            'title': 'Layers List'
        };
        SuperMap.IS.ThemeResource = {
            'themeDotDensity': 'DotDensityTheme',
            'themeGraduatedSymbol': 'GraduatedSymbolTheme',
            'themeGraph': 'GraphTheme',
            'themeLabel': 'LabelTheme',
            'themeRange': 'RangeTheme',
            'themeUnique': 'UniqueTheme',
            'themeGridRange': 'GridRangeTheme',
			'themeCustom' : 'CustomTheme'

        };
        break;
}
