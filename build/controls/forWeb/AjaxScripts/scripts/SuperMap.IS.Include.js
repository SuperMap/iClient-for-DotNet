// ================================================================================
// SuperMap IS .NET 客户端程序，版权所有，北京超图软件股份有限公司，2000-2008。
// 本程序只能在有效的授权许可下使用。未经许可，不得以任何手段擅自使用或传播。 
// 作 者:  SuperMap IS Web Team
// 版 本:  $Id: SuperMap.IS.Include.js,v 1.10 2008/09/04 07:33:33 huzhn Exp $
// 文 件:  SuperMap.IS.Include.js
// 描 述:  AjaxScripts 用于自动包含其它脚本文件
// 更 新:  $Date: 2008/09/04 07:33:33 $
// ================================================================================

function _GetScriptLocation() {
	var scriptLocation = "";
	var scriptName = "SuperMap.IS.Include.js";
	var scripts = document.getElementsByTagName('script');
	for (var i = 0; i < scripts.length; i++) {
		var src = scripts[i].getAttribute('src');
		if (src) {
			var index = src.lastIndexOf(scriptName);
			// is it found, at the end of the URL?
			if ((index > -1) && (index + scriptName.length == src.length)) {
				scriptLocation = src.slice(0, -scriptName.length);
				break;
			}
		}
	}
	return scriptLocation;
}

var _scriptLocation = _GetScriptLocation();

function _IncludeScript(inc, baseLocation) {
	if (!baseLocation) {
		baseLocation = _scriptLocation;
	}
	var script = '<' + 'script type="text/javascript" src="' + baseLocation + inc + '"' + '><' + '/script>';
	document.writeln(script);
}

function _IncludeStyle(inc, baseLocation) {
	if (!baseLocation) {
		baseLocation = _scriptLocation+"../styles/";
	}
	var style = '<' + 'link type="text/css" rel="stylesheet" href="' + baseLocation + inc + '"' + ' />';
	document.writeln(style);
}

function _GetBrowser() {
	var ua = navigator.userAgent.toLowerCase();
	if (ua.indexOf('opera') != -1)
		return 'opera';
	else if (ua.indexOf('msie') != -1)
		return 'ie';
	else if (ua.indexOf('safari') != -1)
		return 'safari';
	else if (ua.indexOf('gecko') != -1)
		return 'gecko';
	else
		return false;
}

function _GetBrowserLanguage() {
	var ul = navigator.userLanguage ? navigator.userLanguage : navigator.language;
	return ul ? ul.toLowerCase() : "";
}
var _browserLanguage = _GetBrowserLanguage();

_IncludeStyle('SuperMap.IS.MapControl.css');

if (_GetBrowser() != "ie") {
	_IncludeScript('AtlasCompat_0.08.js');
	_IncludeScript('wz_jsgraphics.js');
}
else if (navigator.userAgent.toLowerCase().indexOf('msie 8.0') != -1) {
    _IncludeScript('wz_jsgraphics.js');
}

_IncludeScript('SuperMap.IS.Utility.js');
_IncludeScript('SuperMap.IS.Resources.js');
if(_browserLanguage && _browserLanguage != ""){
    _IncludeScript('SuperMap.IS.Resources.' + _browserLanguage + '.js');
}    

var _debug = false;
if(_debug){
_IncludeScript('SuperMap.IS.Type.js');
_IncludeScript('SuperMap.IS.Map.js');
_IncludeScript('SuperMap.IS.QueryManager.js');
_IncludeScript('SuperMap.IS.SpatialAnalystManager.js');
_IncludeScript('SuperMap.IS.EditManager.js');

_IncludeScript('SuperMap.IS.Action.js');
_IncludeScript('SuperMap.IS.MapControl.js');

_IncludeScript('SuperMap.IS.OverviewControl.js');
_IncludeScript('SuperMap.IS.LegendControl.js');
_IncludeScript('SuperMap.IS.LayerControl.js');
_IncludeScript('SuperMap.IS.NavigationControl.js');
_IncludeScript('SuperMap.IS.ScaleBarControl.js');
_IncludeScript('SuperMap.IS.MagnifierControl.js');
}else{
_IncludeScript('SuperMap.IS.Compact.Core.js');
_IncludeScript('SuperMap.IS.Action.js');
_IncludeScript('SuperMap.IS.Compact.Controls.js');
}