//================================================================================ 
// SuperMap IS .NET 客户端程序，版权所有，北京超图软件股份有限公司，2000-2008。 
// 本程序只能在有效的授权许可下使用。未经许可，不得以任何手段擅自使用或传播。 
// 作 者:  SuperMap IS Web Team 
// 版 本:  $Id: SuperMap.IS.Action.js,v 1.63 2011/04/01 09:13:51 zhanghui2 Exp $
// 文 件:  SuperMap.IS.Action.js 
// 描 述:  AjaxScripts Action 相关类型 
// 更 新:  $Date: 2011/04/01 09:13:51 $ 
//================================================================================

SuperMap.IS.Action = function() {
    this.type = "SuperMap.IS.Action";
    this.Init = function(mapControl) { this.mapControl = mapControl; };
    this.Destroy = function() { this.mapControl = null; };
    this.OnClick = function(e) { };
    this.OnDblClick = function(e) { };
    this.OnMouseMove = function(e) { };
    this.OnMouseDown = function(e) { };
    this.OnMouseUp = function(e) { };
    this.OnContextMenu = function(e) { };
    this.OnKeyDown = function(e) { };
    this.OnKeyUp = function(e) { };
	this.OnTouchStart = function(e) { };
	this.OnTouchMove = function(e) { };
	this.OnTouchEnd = function(e) { };
    this.GetJSON = function() { return _ActionToJSON(this.type, []); }
};

SuperMap.IS.ZoomInAction = function() {
    this.type = "SuperMap.IS.ZoomInAction";
    var mapDiv = null;
    var zoomRect = null;
    var _cx = 0, _cy = 0, _nx = 0, _ny = 0;
    var originX = 0; originY = 0;
    var _cxRect = 0, _cyRect = 0, _nxRect = 0, _nyRect = 0;
    var originXRect = 0, originYRect = 0;
    var actionStarted = false;
    this.Init = function(mapControl) {
        this.mapControl = mapControl;
        mapDiv = mapControl.mapDiv;
        if (_ygPos.browser == "ie") { mapControl.container.style.cursor = _scriptLocation + "../images/cur_ZoomIn.cur"; } else { mapControl.workLayer.style.cursor = "url(images/cur_ZoomIn.cur),auto"; };
        zoomRect = document.getElementById("zoomRect");
        if (!zoomRect) {
            zoomRect = document.createElement("div");
            zoomRect.className = "zoomRect";
            _Hide();
            //_AddEvent(zoomRect,"onmouseup",_OnMouseUp);
            if (mapDiv != null) {
                mapDiv.parentNode.appendChild(zoomRect);
            }
        }
    };
    this.Destroy = function() { /*_RemoveEvent(zoomRect,"onmouseup",_OnMouseUp);*/mapDiv.parentNode.removeChild(zoomRect); mapDiv = null; this.mapControl = null; };
    function _OnMouseDown(e) {
        actionStarted = true;
        originX = e.pixelCoord.x - e.offsetCoord.x; originY = e.pixelCoord.y - e.offsetCoord.y;
        _cx = _nx = e.offsetCoord.x; _cy = _ny = e.offsetCoord.y;
        originXRect = e.pixelCoord.x - e.offsetCoord.x - e.panOffset.x; originYRect = e.pixelCoord.y - e.offsetCoord.y - e.panOffset.y;
        _cxRect = _nxRect = e.offsetCoord.x - e.panOffset.x; _cyRect = _nyRect = e.offsetCoord.y - e.panOffset.y;
        //		_Draw(_cx,_cy,1,1);_Show();
    }
    function _OnMouseMove(e) {
        if (!actionStarted) { return; }
        _nx = e.offsetCoord.x; _ny = e.offsetCoord.y;
        _nxRect = e.offsetCoord.x - e.panOffset.x; _nyRect = e.offsetCoord.y - e.panOffset.y;
        _Draw(_Min(_cxRect, _nxRect), _Min(_cyRect, _nyRect), _Max(1, _Abs(_nxRect - _cxRect)), _Max(1, _Abs(_nyRect - _cyRect))); _Show();
    }
    function _OnMouseUp(e) {
        actionStarted = false;
        if (this.mapControl == null) {
            return;
        }
        if (_Abs(_cx - _nx) > 1 && _Abs(_cy - _ny) > 1) {
            var param = this.mapControl.GetMapParam();
            param.SetPixelRect(new SuperMap.IS.PixelRect(originX + _cx, originY + _cy, originX + _nx, originY + _ny));
            this.mapControl.SetMapParam(param);
        }
        else {
            this.mapControl.SetCenterAndZoom(e.mapCoord.x, e.mapCoord.y, this.mapControl.GetMapScale() * 2);
        }
        _Hide();
    }
    function _Draw(x, y, width, height) { _SetPosAndSize(zoomRect, x, y, width, height); }
    function _SetPosAndSize(el, x, y, width, height) { el.style.left = x + "px"; el.style.top = y + "px"; el.style.width = width + "px"; el.style.height = height + "px"; }
    function _Show() { zoomRect.style.display = "block"; }
    function _Hide() { zoomRect.style.display = "none"; }
    function _GetJSON() { return _ActionToJSON(this.type, []); }
    this.OnMouseDown = _OnMouseDown; this.OnMouseMove = _OnMouseMove; this.OnMouseUp = _OnMouseUp; this.GetJSON = _GetJSON;
};

SuperMap.IS.ZoomOutAction = function() {
    this.type = "SuperMap.IS.ZoomOutAction";
    var mapDiv = null;
    var zoomRect = null;
    var _cx = 0, _cy = 0, _nx = 0, _ny = 0;
    var originX = 0; originY = 0;
    var _cxRect = 0, _cyRect = 0, _nxRect = 0, _nyRect = 0;
    var originXRect = 0; originYRect = 0;
    var actionStarted = false;
    this.Init = function(mapControl) {
        this.mapControl = mapControl;
        mapDiv = mapControl.mapDiv;
        if (_ygPos.browser == "ie") { mapControl.container.style.cursor = _scriptLocation + "../images/cur_ZoomOut.cur"; } else { mapControl.workLayer.style.cursor = "url(images/cur_ZoomOut.cur),auto"; };
        zoomRect = document.getElementById("zoomRect");
        if (!zoomRect) {
            zoomRect = document.createElement("div");
            zoomRect.className = "zoomRect";
            _Hide();
            //    		_AddEvent(zoomRect,"onmouseup",_OnMouseUp);
            if (mapDiv != null) {
                mapDiv.parentNode.appendChild(zoomRect);
            }
        }
    };
    this.Destroy = function() { /*_RemoveEvent(zoomRect,"onmouseup",_OnMouseUp);*/mapDiv.parentNode.removeChild(zoomRect); mapDiv = null; this.mapControl = null; };
    function _OnMouseDown(e) {
        actionStarted = true;
        originX = e.pixelCoord.x - e.offsetCoord.x; originY = e.pixelCoord.y - e.offsetCoord.y;
        _cx = _nx = e.offsetCoord.x; _cy = _ny = e.offsetCoord.y;
        originXRect = e.pixelCoord.x - e.offsetCoord.x - e.panOffset.x; originYRect = e.pixelCoord.y - e.offsetCoord.y - e.panOffset.y;
        _cxRect = _nxRect = e.offsetCoord.x - e.panOffset.x; _cyRect = _nyRect = e.offsetCoord.y - e.panOffset.y;
        //		_Draw(_cx,_cy,1,1);_Show();
    }
    function _OnMouseMove(e) {
        if (!actionStarted) { return; }
        _nx = e.offsetCoord.x; _ny = e.offsetCoord.y;
        _nxRect = e.offsetCoord.x - e.panOffset.x; _nyRect = e.offsetCoord.y - e.panOffset.y;
        _Draw(_Min(_cxRect, _nxRect) + 2, _Min(_cyRect, _nyRect) + 2, _Max(5, _Abs(_nxRect - _cxRect)) - 4, _Max(5, _Abs(_nyRect - _cyRect)) - 4); _Show();
    }
    function _OnMouseUp(e) {
        actionStarted = false;
        if (this.mapControl != null) {
            if (_Abs(_cx - _nx) > 1 && _Abs(_cy - _ny) > 1) {
                var param = this.mapControl.GetMapParam();
                // width=curWidth*curWidth/rectWidth; height...
                // center=rectCenter;
                var tpr = new SuperMap.IS.PixelRect(originX + _cx, originY + _cy, originX + _nx, originY + _ny);
                var pr = new SuperMap.IS.PixelRect(); pr.Copy(tpr);
                var mapSize = this.mapControl.GetSize();
                var width = mapSize.Width() * mapSize.Width() / tpr.Width();
                var height = mapSize.Height() * mapSize.Height() / tpr.Height();
                pr.leftTop.x = tpr.leftTop.x - (width - tpr.Width()) / 2; pr.rightBottom.x = tpr.rightBottom.x + (width - tpr.Width()) / 2;
                pr.leftTop.y = tpr.leftTop.y - (height - tpr.Height()) / 2; pr.rightBottom.y = tpr.rightBottom.y + (height - tpr.Height()) / 2;
                param.SetPixelRect(pr);
                this.mapControl.SetMapParam(param);
            }
            else {
                this.mapControl.SetCenterAndZoom(e.mapCoord.x, e.mapCoord.y, this.mapControl.GetMapScale() / 2);
            }
        }
        _Hide();
    }
    function _Draw(x, y, width, height) { _SetPosAndSize(zoomRect, x, y, width, height); }
    function _SetPosAndSize(el, x, y, width, height) { el.style.left = x + "px"; el.style.top = y + "px"; el.style.width = width + "px"; el.style.height = height + "px"; }
    function _Show() { zoomRect.style.display = "block"; }
    function _Hide() { zoomRect.style.display = "none"; }
    function _GetJSON() { return _ActionToJSON(this.type, []); }
    this.OnMouseDown = _OnMouseDown; this.OnMouseMove = _OnMouseMove; this.OnMouseUp = _OnMouseUp; this.GetJSON = _GetJSON;
};

SuperMap.IS.PanAction = function() {
    this.type = "SuperMap.IS.PanAction";
    var actionStarted = false;
    var lastMouseX, lastMouseY;
	var mapDiv = null;
	var _mapControl = null;
	var pinchOriginX = pinchOriginY = currentCenterX = currentCenterY = 0;
	var scale = 1;
	var isSingleTouch = isMultiTouch = false;
	var size = null;
    this.Init = function(mapControl) {
		mapDiv = mapControl.mapDiv;
        this.mapControl = mapControl;
        _mapControl = mapControl;
        size = mapControl.GetSize();
        if (_ygPos.browser == "ie") { mapControl.container.style.cursor = _scriptLocation + "../images/cur_Pan.cur"; } else { mapControl.workLayer.style.cursor = "url(images/cur_Pan.cur),auto"; };
    };
    this.Destroy = function() { this.mapControl = null; };
    function _OnMouseDown(e) {
        actionStarted = true;
        lastMouseX = _GetMouseX(e); lastMouseY = _GetMouseY(e);
        if (this.mapControl.container.setCapture && _GetBrowser() != "opera") { this.mapControl.container.setCapture(); }
    }
    function _OnMouseMove(e) {
        if (!actionStarted) { return; }
        var mouseX = _GetMouseX(e); var mouseY = _GetMouseY(e);
        this.mapControl.Pan(lastMouseX - mouseX, lastMouseY - mouseY, true);
        lastMouseX = mouseX; lastMouseY = mouseY;
        e.cancelTriggerGeometryEvent = true;
    }
    function _OnMouseUp(e) {
        actionStarted = false;
        this.mapControl.StopDynamicPan();
        if (this.mapControl.container.releaseCapture && _GetBrowser() != "opera") { this.mapControl.container.releaseCapture(); }
    }
	function _OnTouchStart(e){
	    var touches = e.touches;
		if(e.touches && e.touches.length>1){
			isMultiTouch = true;
		    if(touches && touches[0]){
				var x =y = 0;
				var num = touches.length;
				var touch ;
				for(var i = 0;i<num;i++){
					touch = touches[i];
					x += touch.clientX;
					y += touch.clientY;
				}
				pinchOriginX = currentCenterX = x /num ;
				pinchOriginY = currentCenterY = y /num ;
		    }
		}else if(e.touches && e.touches.length == 1){
			pinchOriginX = currentCenterX = touches[0].clientX  ;
			pinchOriginY = currentCenterY = touches[0].clientY  ;
			isSingleTouch = true;
			lastMouseX = pinchOriginX;
			lastMouseY = pinchOriginY;
		}
	}
	function _OnTouchMove(e){
		e.preventDefault();
		if(e.scale){
			scale = e.scale;
		}else{
			scale = 1;
		}
		var touches = e.touches;
		if(e.touches && e.touches.length>1){
		    if(touches && touches[0]){
				var x =y = 0;
				var num = touches.length;
				var touch ;
				for(var i = 0;i<num;i++){
					touch = touches[i];
					x += touch.clientX;
					y += touch.clientY;
				}
				currentCenterX = x /num ;
				currentCenterY = y /num ;
		    }  
		}else if(e.touches && e.touches.length == 1){
			currentCenterX = touches[0].clientX  ;
		    currentCenterY = touches[0].clientY  ;
			var mouseX = currentCenterX; var mouseY = currentCenterY;
			_mapControl.Pan(lastMouseX - mouseX, lastMouseY - mouseY, true);
			lastMouseX = mouseX; lastMouseY = mouseY;
			e.cancelTriggerGeometryEvent = true;
			return ;
		}else{
			return ;
		}
		var dx = Math.round((currentCenterX - pinchOriginX) + (scale - 1) * (_mapControl.GetContainerX() - e.panOffset.x - pinchOriginX));
		var dy = Math.round((currentCenterY - pinchOriginY) + (scale - 1) * (_mapControl.GetContainerY() - e.panOffset.y - pinchOriginY));
		_ApplyTransform(mapDiv,"translate(" + dx + "px, " + dy + "px) scale(" + scale + ")" );
	}
	
	function _OnTouchEnd(e){
	    _ApplyTransform(mapDiv,"");
	    if(scale == 1 && isSingleTouch){
	        this.mapControl.StopDynamicPan();
	        isSingleTouch = isMultiTouch = false;
	    }
	    else{
	        var x = ((size.Width()/2) + _mapControl.GetContainerX()-currentCenterX)/scale + currentCenterX ;
            var y = ((size.Height()/2) + _mapControl.GetContainerY()-currentCenterY)/scale + currentCenterY  ;
            var pixelCoord = new SuperMap.IS.PixelCoord(x,y);
            var mapCoord = _mapControl.PixelToMapCoord(pixelCoord);
            _mapControl.SetCenterAndZoom( mapCoord.x, mapCoord.y,(_mapControl.GetMapScale())*(scale));  
            isSingleTouch = isMultiTouch = false;
	    }
	}

    function _GetJSON() { return _ActionToJSON(this.type, []); }
    this.OnMouseDown = _OnMouseDown; this.OnMouseMove = _OnMouseMove; this.OnMouseUp = _OnMouseUp; this.GetJSON = _GetJSON;
    this.OnTouchStart = _OnTouchStart; this.OnTouchMove = _OnTouchMove; this.OnTouchEnd = _OnTouchEnd;
};

SuperMap.IS.DrawLineAction = function() {
    this.type = "SuperMap.IS.DrawLineAction";
    var actionStarted = false;
    var line = null;
    var xs = new Array();
    var ys = new Array();
    this.Init = function(mapControl) {
        this.mapControl = mapControl;
        if (_ygPos.browser == "ie") { mapControl.container.style.cursor = _scriptLocation + "../images/cur_PolygonQuery.cur"; } else { mapControl.workLayer.style.cursor = "url(images/cur_PolygonQuery.cur),auto"; };
    };
    this.Destroy = function() { if (line) { this.mapControl.CustomLayer.RemoveLine(line.id); line = null; } xs = null; ys = null; this.mapControl = null; };
    function _OnClick(e) {
        xs.push(e.mapCoord.x); ys.push(e.mapCoord.y);
        if (this.mapControl != null && this.mapControl.CustomLayer != null) {
            this.mapControl.CustomLayer.InsertLine("drawLine", xs, ys, 3, "red");
        }
    }

    function _OnContextMenu(e) {
    }
    function _GetJSON() { return _ActionToJSON(this.type, []); }
    //    this.OnMouseDown=_OnMouseDown;this.OnMouseMove=_OnMouseMove;this.OnMouseUp=_OnMouseUp;
    this.OnClick = _OnClick; this.OnContextMenu = _OnContextMenu; this.GetJSON = _GetJSON;
};

SuperMap.IS.PointQueryAction = function(layerNames, returnFields, tolerance, whereClause, onComplete, onError, onStart, userContext) {
    this.type = "SuperMap.IS.PointQueryAction";
    var _queryParam = null;
    var _layerNames = layerNames;
    var _returnFields = returnFields;
    var _tolerance = tolerance;
    var _self = this;
    this.Init = function(mapControl) {
        this.mapControl = mapControl;
        if (_ygPos.browser == "ie") { mapControl.container.style.cursor = _scriptLocation + "../images/cur_PointQuery.cur"; } else { mapControl.workLayer.style.cursor = "url(images/cur_PointQuery.cur),auto"; };

        if (!_tolerance) { _tolerance = 100; }
        if (!_queryParam) {
            _queryParam = new SuperMap.IS.QueryParam();
            if (!_returnFields) { _returnFields = null; }
            if (!_layerNames) {
                _queryParam.queryAllLayer = true;
                _queryParam.returnFields = _returnFields;
            } else {
                _queryParam.queryLayers = new Array();
                var tempLayerNames = _layerNames.concat();
                while (tempLayerNames.length > 0) {
                    var ql = new SuperMap.IS.QueryLayer();
                    ql.layerName = tempLayerNames.pop();
                    ql.returnFields = _returnFields;
                    if (whereClause) {
                        ql.whereClause = whereClause;
                    }
                    _queryParam.queryLayers.push(ql);
                }
                tempLayerNames = null;
            }
            _queryParam.expectCount = 20;
            _queryParam.highlight = new SuperMap.IS.Highlight();
            _queryParam.highlight.queryAreaStyle = new SuperMap.IS.Style(); //设置查询区域样式 
            _queryParam.highlight.queryAreaStyle.brushColor = 0XFF0000;  //设置填充的颜色为蓝色 
            _queryParam.highlight.queryAreaStyle.brushBackTransparent = true; //设置背景为透明 
            _queryParam.highlight.queryAreaStyle.brushStyle = 2; //设置填充的样式 
            _queryParam.highlight.highlightQueryArea = true;
            _queryParam.highlight.highlightResult = true;
        }
    };
    this.Destroy = function() {
        this.mapControl = null;
        //		if(_queryParam){_queryParam.Destroy();}_queryParam=_returnFields=null;
    };

    this.OnClick = function(e) {
        //客户端查询前事件
        var qe = new SuperMap.IS.QueryingEventArgs();
        qe.queryParams = _queryParam; //point
        qe.clientActionArgs = new SuperMap.IS.ActionEventArgs();
        qe.clientActionArgs.mapCoords = new Array();
        qe.clientActionArgs.mapCoords[0] = e.mapCoord;
        if (onStart) { onStart(qe, userContext); }
        //服务器查询前事件
        this.mapControl.TriggerServerStartingEvent("Querying", qe, QueryByPoint);


    };
    function QueryByPoint(eJSON) {
        var eJ = eval("(" + eJSON + ")");
        var qe = new SuperMap.IS.QueryingEventArgs();
        qe.FromJSON(eJ);
        if (_self.mapControl != null) {
            _self.mapControl.GetQueryManager().QueryByPoint(qe.clientActionArgs.mapCoords[0], _tolerance, qe.queryParams, onComplete, onError, userContext);
        }
    }
    this.OnDblClick = function(e) { };
    this.OnMouseMove = function(e) { };
    this.OnMouseDown = function(e) { };
    this.OnMouseUp = function(e) { };
    this.OnContextMenu = function(e) { };
    this.GetJSON = function() { return _ActionToJSON(this.type, [layerNames, returnFields, tolerance, whereClause, onComplete, onError, onStart, userContext]); }
};

SuperMap.IS.LineQueryAction = function(layerNames, returnFields, whereClause, onComplete, onError, onStart, userContext) {
    this.type = "SuperMap.IS.LineQueryAction";
    var _queryParam = null;
    var _layerNames = layerNames;
    var _returnFields = returnFields;
    var actionStarted = false;
    //    var line=null;
    var keyPoints = new Array();
    var xs = new Array();
    var ys = new Array();
    var _self = this;
    this.Init = function(mapControl) {
        this.mapControl = mapControl;
        if (_ygPos.browser == "ie") { mapControl.container.style.cursor = _scriptLocation + "../images/cur_PointQuery.cur"; } else { mapControl.workLayer.style.cursor = "url(images/cur_PointQuery.cur),auto"; };
        if (!_queryParam) {
            _queryParam = new SuperMap.IS.QueryParam();
            if (!_returnFields) { _returnFields = null; }
            if (!_layerNames) {
                _queryParam.queryAllLayer = true;
                _queryParam.returnFields = _returnFields;
            } else {
                _queryParam.queryLayers = new Array();
                var tempLayerNames = _layerNames.concat();
                while (tempLayerNames.length > 0) {
                    var ql = new SuperMap.IS.QueryLayer();
                    ql.layerName = tempLayerNames.pop();
                    ql.returnFields = _returnFields;
                    if (whereClause) {
                        ql.whereClause = whereClause;
                    }
                    _queryParam.queryLayers.push(ql);
                }
                tempLayerNames = null;
            }
            _queryParam.expectCount = 20;
            _queryParam.highlight = new SuperMap.IS.Highlight();
            _queryParam.highlight.queryAreaStyle = new SuperMap.IS.Style(); //设置查询区域样式 
            _queryParam.highlight.queryAreaStyle.brushColor = 0XFF0000;  //设置填充的颜色为蓝色 
            _queryParam.highlight.queryAreaStyle.brushBackTransparent = true; //设置背景为透明 
            _queryParam.highlight.queryAreaStyle.brushStyle = 2; //设置填充的样式 
            _queryParam.highlight.highlightQueryArea = true;
            _queryParam.highlight.highlightResult = true;
        }
    };
    this.Destroy = function() {
        this.mapControl = null;
        //		if(_queryParam){_queryParam.Destroy();}_queryParam=_returnFields=null;
    };

    this.OnClick = function(e) {
        //客户端查询前事件
        if (!actionStarted) {
            keyPoints.push(e.mapCoord);
            xs.push(e.mapCoord.x); ys.push(e.mapCoord.y);
        }
        actionStarted = true;
        keyPoints.push(e.mapCoord);
        xs.push(e.mapCoord.x); ys.push(e.mapCoord.y);
    };

    this.OnDblClick = function(e) {
        if (!actionStarted) { return false; }
        keyPoints.push(e.mapCoord);
        xs.push(e.mapCoord.x); ys.push(e.mapCoord.y);
        this.mapControl.CustomLayer.RemoveLine("QueryByLine");
        var qe = new SuperMap.IS.QueryingEventArgs();
        qe.queryParams = _queryParam;
        qe.clientActionArgs = new SuperMap.IS.ActionEventArgs();
        qe.clientActionArgs.mapCoords = new Array();
        for (var i = 0; i < keyPoints.length; i++) {
            qe.clientActionArgs.mapCoords[i] = keyPoints[i];
        }
        if (onStart) { onStart(qe, userContext); }
        //服务器查询前事件
        this.mapControl.TriggerServerStartingEvent("Querying", qe, QueryByLine);
    };
    function QueryByLine(eJSON) {
        var eJ = eval("(" + eJSON + ")");
        var qe = new SuperMap.IS.QueryingEventArgs();
        qe.FromJSON(eJ);
        while (keyPoints.length > 0) {
            keyPoints.pop();
            xs.pop(); ys.pop();
        }
        if (_self.mapControl != null) {
            _self.mapControl.GetQueryManager().QueryByLine(qe.clientActionArgs.mapCoords, qe.queryParams, onComplete, onError, userContext);
        }
        actionStarted = false;
    }
    this.OnMouseMove = function(e) {
        if (!actionStarted) { return false; }
        keyPoints.pop();
        xs.pop(); ys.pop();
        keyPoints.push(e.mapCoord);
        xs.push(e.mapCoord.x); ys.push(e.mapCoord.y);
        this.mapControl.CustomLayer.InsertLine("QueryByLine", xs, ys, 2, "blue");
        e.cancelTriggerGeometryEvent = true;
    };
    this.OnMouseDown = function(e) { };
    this.OnMouseUp = function(e) { };
    this.OnContextMenu = function(e) { };
    this.GetJSON = function() { return _ActionToJSON(this.type, [layerNames, returnFields, whereClause, onComplete, onError, onStart, userContext]); }
};

SuperMap.IS.FindPathAction = function(layerName, tolerance, onComplete, onError, onStart, userContext) {
    this.type = "SuperMap.IS.FindPathAction";
    var keyPoints = new Array();
    var _routeParam = null;
    var _tolerance = tolerance;
    var _layerName = layerName;
    var actionStarted = false;
    var xs = new Array();
    var ys = new Array();
    var _self = this;
    this.Init = function(mapControl) {
        this.mapControl = mapControl;
        if (_ygPos.browser == "ie") { mapControl.container.style.cursor = _scriptLocation + "../images/cur_PointQuery.cur"; } else { mapControl.workLayer.style.cursor = "url(images/cur_PointQuery.cur),auto"; };
        if (!_routeParam) {
            _routeParam = new SuperMap.IS.RouteParam();
            if (!_tolerance) { _tolerance = 0; }
            if (!_layerName) { _layerName = ""; }
            _routeParam.networkParams = new SuperMap.IS.NetworkParams();
            _routeParam.networkParams.networkSetting = new SuperMap.IS.NetworkSetting();
            //_routeParam.networkParams.networkSetting.edgeIDField = "";
            //_routeParam.networkParams.networkSetting.nodeIDField = "";
            _routeParam.networkParams.networkSetting.networkLayerName = _layerName;
            //_routeParam.networkParams.networkSetting.FTWeightField="SmLength";
            //_routeParam.networkParams.networkSetting.TFWeightField="SmLength";
            _routeParam.networkParams.tolerance = _tolerance;
            _routeParam.returnEdgeIDsAndNodeIDs = true;
            _routeParam.returnNodePositions = true;
            _routeParam.highlight = new SuperMap.IS.Highlight();
        }
    };
    this.Destroy = function() {
        this.mapControl.CustomLayer.RemoveLine("pathLine");
        this.mapControl = null;
        while (keyPoints.length > 0) {
            keyPoints.pop();
            xs.pop(); ys.pop();
        }
        if (_routeParam) { _routeParam.Destroy(); } _routeParam = null;
    };

    this.OnClick = function(e) {
        actionStarted = true;
        keyPoints.push(e.mapCoord);
        xs.push(e.mapCoord.x); ys.push(e.mapCoord.y);
    };
    this.OnDblClick = function(e) {
        //OnDblClick 之前会伴随一次 OnClick，faint。
        if (!actionStarted || keyPoints.length < 2) { return false; }
        this.mapControl.CustomLayer.RemoveLine("pathLine");

        //客户端路径分析前事件
        var pe = new SuperMap.IS.PathFindingEventArgs();
        pe.routeParams = _routeParam;
        pe.clientActionArgs = new SuperMap.IS.ActionEventArgs();
        pe.clientActionArgs.mapCoords = keyPoints;
        if (onStart) { onStart(pe, userContext); }

        //服务器路径分析前事件
        this.mapControl.TriggerServerStartingEvent("PathFinding", pe, FindPath);
    };

    function FindPath(eJSON) {
        var eJ = eval("(" + eJSON + ")");
        var pe = new SuperMap.IS.PathFindingEventArgs();
        pe.FromJSON(eJ);
        if (_self.mapControl != null) {
            _self.mapControl.GetSpatialAnalystManager().FindPathByPoints(pe.clientActionArgs.mapCoords, pe.routeParams, onComplete, onError, userContext);
        }
        while (keyPoints.length > 0) {
            keyPoints.pop();
            xs.pop(); ys.pop();
        }
        actionStarted = false;
    };

    this.OnMouseMove = function(e) {
        if (!actionStarted) { return false; }
        xs.push(e.mapCoord.x); ys.push(e.mapCoord.y);
        this.mapControl.CustomLayer.InsertLine("pathLine", xs, ys, 2, "blue");
        xs.pop(); ys.pop();
        e.cancelTriggerGeometryEvent = true;
    };
    this.OnMouseDown = function(e) { };
    this.OnMouseUp = function(e) { };
    this.OnContextMenu = function(e) { };
    this.GetJSON = function() { return _ActionToJSON(this.type, [layerName, tolerance, onComplete, onError, onStart, userContext]); }
};

SuperMap.IS.MeasureDistanceAction = function(onComplete, onError, onStart, userContext) {
    this.type = "SuperMap.IS.MeasureDistanceAction";
    var actionStarted = false;
    var line = null;
    var keyPoints = new Array();
    var xs = new Array();
    var ys = new Array();
    var _self = this;
    this.Init = function(mapControl) {
        this.mapControl = mapControl;
        if (_ygPos.browser == "ie") { mapControl.container.style.cursor = _scriptLocation + "../images/cur_MeasureDistance.cur"; } else { mapControl.workLayer.style.cursor = "url(images/cur_MeasureDistance.cur),auto"; };
    };
    this.Destroy = function() { actionStarted = false; this.mapControl.CustomLayer.RemoveLine("MeasureDistance"); line = null; ; this.mapControl = null; };

    this.OnClick = function(e) {
        if (!actionStarted) {
            keyPoints.push(e.mapCoord);
            xs.push(e.mapCoord.x); ys.push(e.mapCoord.y);
        }
        actionStarted = true;
        keyPoints.push(e.mapCoord);
        xs.push(e.mapCoord.x); ys.push(e.mapCoord.y);
    };
    this.OnDblClick = function(e) {
        if (!actionStarted) { return false; }
        keyPoints.push(e.mapCoord);
        xs.push(e.mapCoord.x); ys.push(e.mapCoord.y);
        //客户端量算前事件
        var me = new SuperMap.IS.MeasuringEventArgs();
        me.clientActionArgs = new SuperMap.IS.ActionEventArgs();
        me.clientActionArgs.mapCoords = new Array();
        for (var i = 0; i < keyPoints.length; i++) {
            me.clientActionArgs.mapCoords[i] = keyPoints[i];
        }
        if (onStart) { onStart(me, userContext); }

        //服务器量算前事件
        this.mapControl.TriggerServerStartingEvent("DistanceMeasuring", me, MeasureDistance);


    };

    function MeasureDistance(eJSON) {
        var eJ = eval("(" + eJSON + ")");
        var me = new SuperMap.IS.MeasuringEventArgs();
        me.FromJSON(eJ);
        if (_self.mapControl != null) {
            _self.mapControl.CustomLayer.RemoveLine("MeasureDistance")
            if (me.isHighlight) {
                if (me.highlightStyle != null) {
                    var _highlight = new SuperMap.IS.Highlight();
                    _highlight.lineStyle = me.highlightStyle;
                    _self.mapControl.MeasureDistance(me.clientActionArgs.mapCoords, _highlight, onComplete, onError, userContext);
                } else {
                _self.mapControl.MeasureDistance(me.clientActionArgs.mapCoords, true, onComplete, onError, userContext);
                }
            } else {
                _self.mapControl.MeasureDistance(me.clientActionArgs.mapCoords, false, onComplete, onError, userContext);
            }
        }
        while (keyPoints.length > 0) {
            keyPoints.pop();
            xs.pop(); ys.pop();
        }
        actionStarted = false;
    }


    this.OnMouseMove = function(e) {
        if (!actionStarted) { return false; }
        keyPoints.pop();
        xs.pop(); ys.pop();
        keyPoints.push(e.mapCoord);
        xs.push(e.mapCoord.x); ys.push(e.mapCoord.y);
        this.mapControl.CustomLayer.InsertLine("MeasureDistance", xs, ys, 2, "blue");
        e.cancelTriggerGeometryEvent = true;
    };
    this.OnMouseDown = function(e) { };
    this.OnMouseUp = function(e) { };
    this.OnContextMenu = function(e) { };
    this.GetJSON = function() { return _ActionToJSON(this.type, [onComplete, onError, onStart, userContext]); }

};

SuperMap.IS.MeasureAreaAction = function(onComplete, onError, onStart, userContext) {
    this.type = "SuperMap.IS.MeasureAreaAction";
    var actionStarted = false;
    var line = null;
    var keyPoints = new Array();
    var xs = new Array();
    var ys = new Array();
    var _self = this;
    var firstMapCoord = null;
    this.Init = function(mapControl) {
        this.mapControl = mapControl;
        if (_ygPos.browser == "ie") { mapControl.container.style.cursor = _scriptLocation + "../images/cur_MeasureArea.cur"; } else { mapControl.workLayer.style.cursor = "url(images/cur_MeasureArea.cur),auto"; };
    };
    this.Destroy = function() { this.mapControl.CustomLayer.RemovePolygon("MeasureArea"); line = null; this.mapControl = null; };

    this.OnClick = function(e) {
        if (!actionStarted) {
            firstMapCoord = e.mapCoord;
            xs.push(e.mapCoord.x); ys.push(e.mapCoord.y);

        } else {
            xs.pop(); ys.pop();
            xs.push(e.mapCoord.x); ys.push(e.mapCoord.y);
        }
        actionStarted = true;
        keyPoints.push(e.mapCoord);
        xs.push(firstMapCoord.x); ys.push(firstMapCoord.y);
    };
    this.OnDblClick = function(e) {
        keyPoints.push(e.mapCoord);
        keyPoints.push(firstMapCoord);
        xs.pop(); ys.pop();
        xs.push(e.mapCoord.x); ys.push(e.mapCoord.y);
        xs.push(firstMapCoord.x); ys.push(firstMapCoord.y);

        //客户端量算前事件
        var me = new SuperMap.IS.MeasuringEventArgs();
        me.clientActionArgs = new SuperMap.IS.ActionEventArgs();
        me.clientActionArgs.mapCoords = new Array();
        for (var i = 0; i < keyPoints.length; i++) {
            me.clientActionArgs.mapCoords[i] = keyPoints[i];
        }
        if (onStart) { onStart(me, userContext); }

        //服务器量算前事件
        this.mapControl.TriggerServerStartingEvent("AreaMeasuring", me, MeasureArea);



    };

    function MeasureArea(eJSON) {
        var eJ = eval("(" + eJSON + ")");
        var me = new SuperMap.IS.MeasuringEventArgs();
        me.FromJSON(eJ);
        if (_self.mapControl != null && _self.mapControl.CustomLayer != null) {
            _self.mapControl.CustomLayer.RemovePolygon("MeasureArea");
        }
        if (_self.mapControl != null) {
            if (me.isHighlight) {
                if (me.highlightStyle != null) {
                    var _highlight = new SuperMap.IS.Highlight();
                    _highlight.regionStyle = me.highlightStyle;
                    _self.mapControl.MeasureArea(keyPoints, _highlight, onComplete, onError, userContext);
                } else {
                    _self.mapControl.MeasureArea(keyPoints, true, onComplete, onError, userContext);
                }
            } else {
                _self.mapControl.MeasureArea(keyPoints, false, onComplete, onError, userContext);
            }
        }
        while (keyPoints.length > 0) {
            keyPoints.pop();
            xs.pop(); ys.pop();
        }
        firstMapCoord = null;
        actionStarted = false;
    }

    this.OnMouseMove = function(e) {
        if (!actionStarted) { return false; }
        keyPoints.pop();
        xs.pop(); ys.pop();
        keyPoints.push(e.mapCoord);
        xs.push(e.mapCoord.x); ys.push(e.mapCoord.y);
        this.mapControl.CustomLayer.InsertPolygon("MeasureArea", xs, ys, 2, "blue", "white", 0.6, 1);
        //this.mapControl.CustomLayer.InsertLine("MeasureArea",xs,ys,2,"blue");
        e.cancelTriggerGeometryEvent = true;
    };
    this.OnMouseDown = function(e) { };
    this.OnMouseUp = function(e) { };
    this.OnContextMenu = function(e) { };
    this.GetJSON = function() { return _ActionToJSON(this.type, [onComplete, onError, onStart, userContext]); }
};

SuperMap.IS.OpenInfoWindowAction = function(id, width, height, title, content, opacity) {
    this.type = "SuperMap.IS.OpenInfoWindowAction";
    var line = null;
    this.Init = function(mapControl) {
        this.mapControl = mapControl;
        if (_ygPos.browser == "ie") { mapControl.container.style.cursor = _scriptLocation + "../images/cur_PointQuery.cur"; } else { mapControl.workLayer.style.cursor = "url(images/cur_PointQuery.cur),auto"; };
    };
    this.Destroy = function() { if (line) { this.mapControl.CustomLayer.RemoveMark(line.id); line = null; } this.mapControl = null; };

    this.OnClick = function(e) {
        map.CustomLayer.OpenInfoWindow(id, e.mapCoord.x, e.mapCoord.y, width, height, title, content, opacity);
    };
    this.OnDblClick = function(e) { };
    this.OnMouseMove = function(e) { };
    this.OnMouseDown = function(e) { };
    this.OnMouseUp = function(e) { };
    this.OnContextMenu = function(e) { };
    this.GetJSON = function() { return _ActionToJSON(this.type, [id, width, height, title, content, opacity]); }
};


SuperMap.IS.RectQueryAction = function(layerNames, returnFields, whereClause, onComplete, onError, onStart, userContext) {
    this.type = "SuperMap.IS.RectQueryAction";
    var _queryParam = null;
    var _layerNames = layerNames;
    var _returnFields = returnFields;
    var actionStarted = false;
    var line = null;
    var xs = new Array();
    var ys = new Array();
    var _self = this;
    var firstMapCoord = null;
    this.Init = function(mapControl) {
        this.mapControl = mapControl;
        if (_ygPos.browser == "ie") { mapControl.container.style.cursor = _scriptLocation + "../images/cur_RectQuery.cur"; } else { mapControl.workLayer.style.cursor = "url(images/cur_RectQuery.cur),auto"; };
        if (!_queryParam) {
            _queryParam = new SuperMap.IS.QueryParam();
            if (!_returnFields) { _returnFields = null; }
            if (!_layerNames) {
                _queryParam.queryAllLayer = true;
                _queryParam.returnFields = _returnFields;
            } else {
                _queryParam.queryLayers = new Array();
                var tempLayerNames = _layerNames.concat();
                while (tempLayerNames.length > 0) {
                    var ql = new SuperMap.IS.QueryLayer();
                    ql.layerName = tempLayerNames.pop();
                    ql.returnFields = _returnFields;
                    if (whereClause) {
                        ql.whereClause = whereClause;
                    }
                    _queryParam.queryLayers.push(ql);
                }
                tempLayerNames = null;
            }
            _queryParam.expectCount = 20;
            _queryParam.highlight = new SuperMap.IS.Highlight();
            _queryParam.highlight.queryAreaStyle = new SuperMap.IS.Style(); //设置查询区域样式 
            _queryParam.highlight.queryAreaStyle.brushColor = 0XFF0000;  //设置填充的颜色为蓝色 
            _queryParam.highlight.queryAreaStyle.brushBackTransparent = true; //设置背景为透明 
            _queryParam.highlight.queryAreaStyle.brushStyle = 2; //设置填充的样式 
            _queryParam.highlight.highlightQueryArea = true;
            _queryParam.highlight.highlightResult = true;
        }
    };
    this.Destroy = function() { this.mapControl.CustomLayer.RemovePolygon("RectQuery"); line = null; this.mapControl = null; };
    this.OnClick = function(e) { };
    this.OnDblClick = function(e) { };
    this.OnMouseMove = function(e) {
        if (!actionStarted) { return false; }
        while (xs.length > 0) {
            xs.pop();
            ys.pop();
        }
        xs.push(lastMapCoord.x);
        xs.push(e.mapCoord.x);
        xs.push(e.mapCoord.x);
        xs.push(lastMapCoord.x);
        ys.push(lastMapCoord.y);
        ys.push(lastMapCoord.y);
        ys.push(e.mapCoord.y);
        ys.push(e.mapCoord.y);
        this.mapControl.CustomLayer.InsertPolygon("RectQuery", xs, ys, 2, "blue", "white", 0.6, 1);
        e.cancelTriggerGeometryEvent = true;
    };
    this.OnMouseDown = function(e) {
        actionStarted = true;
        lastMapCoord = e.mapCoord;
        while (xs.length > 0) {
            xs.pop();
            ys.pop();
        }
    };
    this.OnMouseUp = function(e) {
        actionStarted = false;
        //客户端查询前事件
        var qe = new SuperMap.IS.QueryingEventArgs();
        qe.queryParams = _queryParam; //point
        qe.clientActionArgs = new SuperMap.IS.ActionEventArgs();
        qe.clientActionArgs.mapCoords = new Array();
        qe.clientActionArgs.mapCoords[0] = lastMapCoord;
        qe.clientActionArgs.mapCoords[1] = e.mapCoord;
        if (onStart) { onStart(qe, userContext); }
        //服务器查询前事件
        this.mapControl.TriggerServerStartingEvent("Querying", qe, QueryByRect);

    };
    function QueryByRect(eJSON) {
        var eJ = eval("(" + eJSON + ")");
        var qe = new SuperMap.IS.QueryingEventArgs();
        qe.FromJSON(eJ);

        var left;
        var bottom;
        var right;
        var top;
        var startPoint = qe.clientActionArgs.mapCoords[0];
        var endPoint = qe.clientActionArgs.mapCoords[1];
        if (startPoint.x == endPoint.x) { return; }
        else if (startPoint.x < endPoint.x) { left = startPoint.x; right = endPoint.x; }
        else { left = endPoint.x; right = startPoint.x; }
        if (startPoint.y == endPoint.y) { return; }
        else if (startPoint.y < endPoint.y) { bottom = startPoint.y; top = endPoint.y; }
        else { bottom = endPoint.y; top = startPoint.y; }

        _mapRect = new SuperMap.IS.MapRect(left, bottom, right, top);
        if (_self.mapControl != null) {
            _self.mapControl.GetQueryManager().QueryByRect(_mapRect, qe.queryParams, onComplete, onError, userContext);
        }
        _mapRect = null;
        if (_self.mapControl != null && _self.mapControl.CustomLayer != null) {
            _self.mapControl.CustomLayer.RemovePolygon("RectQuery");
        }

    };
    this.OnContextMenu = function(e) { };
    this.GetJSON = function() { return _ActionToJSON(this.type, [layerNames, returnFields, whereClause, onComplete, onError, onStart, userContext]); };
};

SuperMap.IS.PolygonQueryAction = function(layerNames, returnFields, whereClause, onComplete, onError, onStart, userContext) {
    this.type = "SuperMap.IS.PolygonQueryAction";
    var actionStarted = false;
    var _queryParam = null;
    var _layerNames = layerNames;
    var _returnFields = returnFields;
    var line = null;
    var keyPoints = new Array();
    var xs = new Array();
    var ys = new Array();
    var _self = this;
    var firstMapCoord = null;
    this.Init = function(mapControl) {
        this.mapControl = mapControl;
        if (_ygPos.browser == "ie") { mapControl.container.style.cursor = _scriptLocation + "../images/cur_PolygonQuery.cur"; } else { mapControl.workLayer.style.cursor = "url(images/cur_PolygonQuery.cur),auto"; };
        if (!_queryParam) {
            _queryParam = new SuperMap.IS.QueryParam();
            if (!_returnFields) { _returnFields = null; }
            if (!_layerNames) {
                _queryParam.queryAllLayer = true;
                _queryParam.returnFields = _returnFields;
            } else {
                _queryParam.queryLayers = new Array();
                var tempLayerNames = _layerNames.concat();
                while (tempLayerNames.length > 0) {
                    var ql = new SuperMap.IS.QueryLayer();
                    ql.layerName = tempLayerNames.pop();
                    ql.returnFields = _returnFields;
                    if (whereClause) {
                        ql.whereClause = whereClause;
                    }
                    _queryParam.queryLayers.push(ql);
                }
                tempLayerNames = null;
            }
            _queryParam.expectCount = 20;
            _queryParam.highlight = new SuperMap.IS.Highlight();
            _queryParam.highlight.queryAreaStyle = new SuperMap.IS.Style(); //设置查询区域样式 
            _queryParam.highlight.queryAreaStyle.brushColor = 0XFF0000;  //设置填充的颜色为蓝色 
            _queryParam.highlight.queryAreaStyle.brushBackTransparent = true; //设置背景为透明 
            _queryParam.highlight.queryAreaStyle.brushStyle = 2; //设置填充的样式 
            _queryParam.highlight.highlightQueryArea = true;
            _queryParam.highlight.highlightResult = true;
        }
    };
    this.Destroy = function() { this.mapControl.CustomLayer.RemovePolygon("PolygonQuery"); line = null; this.mapControl = null; };
    this.OnClick = function(e) {
        if (!actionStarted) {
            firstMapCoord = e.mapCoord;
            xs.push(e.mapCoord.x); ys.push(e.mapCoord.y);
        } else {
            xs.pop(); ys.pop();
            xs.push(e.mapCoord.x); ys.push(e.mapCoord.y);
        }
        actionStarted = true;
        keyPoints.push(e.mapCoord);
        xs.push(firstMapCoord.x); ys.push(firstMapCoord.y);
    };
    this.OnDblClick = function(e) {
        keyPoints.push(e.mapCoord);
        keyPoints.push(firstMapCoord);
        xs.pop(); ys.pop();
        xs.push(e.mapCoord.x); ys.push(e.mapCoord.y);
        xs.push(firstMapCoord.x); ys.push(firstMapCoord.y);
        this.mapControl.CustomLayer.InsertPolygon("PolygonQuery", xs, ys, 2, "blue", "white", 0.6, 1);

        //客户端查询前事件
        var qe = new SuperMap.IS.QueryingEventArgs();
        qe.queryParams = _queryParam; //point
        qe.clientActionArgs = new SuperMap.IS.ActionEventArgs();
        qe.clientActionArgs.mapCoords = keyPoints;
        if (onStart) { onStart(qe, userContext); }
        //服务器查询前事件
        this.mapControl.TriggerServerStartingEvent("Querying", qe, QueryByPolygon);

        //this.mapControl.CustomLayer.InsertLine("MeasureArea",xs,ys,2,"blue");

    };

    function QueryByPolygon(eJSON) {
        var eJ = eval("(" + eJSON + ")");
        var qe = new SuperMap.IS.QueryingEventArgs();
        qe.FromJSON(eJ);
        if (_self.mapControl != null) {
            _self.mapControl.GetQueryManager().QueryByPolygon(qe.clientActionArgs.mapCoords, qe.queryParams, onComplete, onError, userContext);
        }
        while (keyPoints.length > 0) {
            keyPoints.pop();
            xs.pop(); ys.pop();
            firstMapCoord = null;
        }
        actionStarted = false;
        if (_self.mapControl != null && _self.mapControl.CustomLayer != null) {
            _self.mapControl.CustomLayer.RemovePolygon("PolygonQuery");
        }

    }

    this.OnMouseMove = function(e) {
        if (!actionStarted) { return false; }
        keyPoints.pop();
        xs.pop(); ys.pop();
        keyPoints.push(e.mapCoord);
        xs.push(e.mapCoord.x); ys.push(e.mapCoord.y);
        this.mapControl.CustomLayer.InsertPolygon("PolygonQuery", xs, ys, 2, "blue", "white", 0.6, 1);
        //this.mapControl.CustomLayer.InsertLine("MeasureArea",xs,ys,2,"blue");
        e.cancelTriggerGeometryEvent = true;
    };
    this.OnMouseDown = function(e) { };
    this.OnMouseUp = function(e) { };
    this.OnContextMenu = function(e) { };
    this.GetJSON = function() { return _ActionToJSON(this.type, [layerNames, returnFields, whereClause, onComplete, onError, onStart, userContext]); };
};

SuperMap.IS.CircleQueryAction = function(layerNames, returnFields, whereClause, onComplete, onError, onStart, userContext) {
    this.type = "SuperMap.IS.CircleQueryAction";
    var _queryParam = null;
    var _layerNames = layerNames;
    var _returnFields = returnFields;
    var actionStarted = false;
    var line = null;
    var firstMapCoord = null;
    var curMapCoord = null;
    var firstPoint_x;
    var firstPoint_y;
    var curPoint_x;
    var curPoint_y;
    var mapNode; //地图所在的结点
    var mapLeft = 0; //得到地图所在的绝对位置
    var mapTop = 0;
    var _self = this;
    this.Init = function(mapControl) {
        this.mapControl = mapControl;
        map = this.mapControl;
        if (_ygPos.browser == "ie") { mapControl.container.style.cursor = _scriptLocation + "../images/cur_CircleQuery.cur"; } else { mapControl.workLayer.style.cursor = "url(images/cur_CircleQuery.cur),auto"; };
        if (!_queryParam) {
            _queryParam = new SuperMap.IS.QueryParam();
            if (!_returnFields) { _returnFields = null; }
            if (!_layerNames) {
                _queryParam.queryAllLayer = true;
                _queryParam.returnFields = _returnFields;
            } else {
                _queryParam.queryLayers = new Array();
                var tempLayerNames = _layerNames.concat();
                while (tempLayerNames.length > 0) {
                    var ql = new SuperMap.IS.QueryLayer();
                    ql.layerName = tempLayerNames.pop();
                    ql.returnFields = _returnFields;
                    if (whereClause) {
                        ql.whereClause = whereClause;
                    }
                    _queryParam.queryLayers.push(ql);
                }
                tempLayerNames = null;
            }
            _queryParam.expectCount = 20;
            _queryParam.highlight = new SuperMap.IS.Highlight();
            _queryParam.highlight.queryAreaStyle = new SuperMap.IS.Style(); //设置查询区域样式 
            _queryParam.highlight.queryAreaStyle.brushColor = 0XFF0000;  //设置填充的颜色为蓝色 
            _queryParam.highlight.queryAreaStyle.brushBackTransparent = true; //设置背景为透明 
            _queryParam.highlight.queryAreaStyle.brushStyle = 2; //设置填充的样式 
            _queryParam.highlight.highlightQueryArea = true;
            _queryParam.highlight.highlightResult = true;
        }
        mapNode = this.mapControl.container;
        while (mapNode != null) {
            mapLeft += mapNode.offsetLeft;
            mapTop += mapNode.offsetTop;
            mapNode = mapNode.offsetParent;
        }
    };

    this.Destroy = function() { SMISRemoveCircle(); this.mapControl.CustomLayer.RemoveEllipse("CircleQuery"); line = null; this.mapControl = null; };
    this.OnClick = function(e) { };
    this.OnDblClick = function(e) { };
    this.OnMouseMove = function(e) {
        if (!actionStarted) { return false; }
        curPoint_x = e.clientX - mapLeft;
        curPoint_y = e.clientY - mapTop;
        if (document.documentElement) {
            curPoint_x = e.clientX - mapLeft + document.documentElement.scrollLeft;
            curPoint_y = e.clientY - mapTop + document.documentElement.scrollTop;
        }
        else if (document.body) {
            curPoint_x = e.clientX - mapLeft + document.body.scrollLeft;
            curPoint_y = e.clientY - mapTop + document.body.scrollTop;
        }
        curMapCoord = e.mapCoord;
        //SMISDrawingCircle(firstPoint_x, firstPoint_y, curPoint_x, curPoint_y);
        var radius = Math.sqrt(Math.pow((curMapCoord.x - firstMapCoord.x), 2) + Math.pow((curMapCoord.y - firstMapCoord.y), 2));
        this.mapControl.CustomLayer.InsertEllipse("CircleQuery", firstMapCoord, radius, radius, 2, "blue", "white", 0.6, 1);
        e.cancelTriggerGeometryEvent = true;
    };
    this.OnMouseDown = function(e) {
        actionStarted = true;
        lastMapCoord = e.mapCoord;
        firstPoint_x = e.clientX - mapLeft;
        firstPoint_y = e.clientY - mapTop;
        if (document.documentElement) {
            firstPoint_x = e.clientX - mapLeft + document.documentElement.scrollLeft;
            firstPoint_y = e.clientY - mapTop + document.documentElement.scrollTop;
        }
        else if (document.body) {
            firstPoint_x = e.clientX - mapLeft + document.body.scrollLeft;
            firstPoint_y = e.clientY - mapTop + document.body.scrollTop;
        }
        firstMapCoord = e.mapCoord;
    };
    this.OnMouseUp = function(e) {
        curMapCoord = e.mapCoord;
        this.mapControl.CustomLayer.RemoveEllipse("CircleQuery");
        SMISOnMouseUp(this.mapControl);
    };
    this.OnContextMenu = function(e) { };
    function SMISDrawingCircle(startPoint_x, startPoint_y, curPoint_x, curPoint_y) {
        var circle = document.getElementById("SMISCircle");
        var m_drawLayer;
        if (/*_ygPos.browser != "ie" || */!_EnableVML()) {
            if (!circle) {
                circle = document.createElement("div");
                circle.id = "SMISCircle";
                circle.style.position = "absolute";
                circle.style.left = "0px";
                circle.style.top = "0px";
                circle.unselectable = "on";
                circle.onmouseup = SMISOnMouseUp;
                _self.mapControl.container.appendChild(circle); //将圆画在地图所在的控件
                var m_jg = new jsGraphics("SMISCircle");
                circle.jg = m_jg;
            }
            else {
                circle.jg.clear();
            }
            circle.jg.setColor("blue"); circle.jg.setStroke(2);
            circle.style.zIndex = 2000;
            circle.style.opacity = 0.5;
            var radius = Math.sqrt(Math.pow((curPoint_x - startPoint_x), 2) + Math.pow((curPoint_y - startPoint_y), 2))
            circle.jg.drawEllipse(startPoint_x - radius, startPoint_y - radius, radius * 2, radius * 2);
            circle.jg.paint();
            return;
        }
        if (!circle) {
            _EnableVML();
            circle = document.createElement("<v:arc startangle='0' endangle='360'/>");
            circle.style.position = "absolute";
            circle.style.visibility = 'visible';
            circle.id = "SMISCircle";
            circle.style.zIndex = 1000;
            //circle.style.zIndex = map.parentElement.style.zIndex + 200;
            var fill = document.createElement("<v:fill opacity=0.3></v:fill>");
            var stroke = document.createElement("<v:stroke dashstyle='solid' Color='blue'></v:stroke>");
            _self.mapControl.container.appendChild(circle);
            circle.appendChild(fill);
            circle.appendChild(stroke);
        }
        var radius = Math.sqrt(Math.pow((curPoint_x - startPoint_x), 2) + Math.pow((curPoint_y - startPoint_y), 2))
        circle.style.left = (startPoint_x - radius) + "px";
        circle.style.top = (startPoint_y - radius) + "px";
        circle.style.width = 2 * radius + "px";
        circle.style.height = circle.style.width;
    }
    function SMISOnMouseUp() {
        actionStarted = false;
        //SMISRemoveCircle();
        //客户端查询前事件
        var qe = new SuperMap.IS.QueryingEventArgs();
        qe.queryParams = new SuperMap.IS.QueryParam();
        qe.queryParams = _queryParam; //point
        qe.clientActionArgs = new SuperMap.IS.ActionEventArgs();
        qe.clientActionArgs.mapCoords = new Array();
        qe.clientActionArgs.mapCoords[0] = lastMapCoord;
        qe.clientActionArgs.mapCoords[1] = curMapCoord;
        if (onStart) { onStart(qe, userContext); }
        //服务器查询前事件
        _self.mapControl.TriggerServerStartingEvent("Querying", qe, QueryByCircle);

    };

    function QueryByCircle(eJSON) {
        var eJ = eval("(" + eJSON + ")");
        var qe = new SuperMap.IS.QueryingEventArgs();
        qe.FromJSON(eJ);
        var startPoint = qe.clientActionArgs.mapCoords[0];
        var endPoint = qe.clientActionArgs.mapCoords[1];
        var left;
        var bottom;
        var right;
        var top;
        radius = Math.sqrt(Math.pow((endPoint.x - startPoint.x), 2) + Math.pow((endPoint.y - startPoint.y), 2));
        if (_self.mapControl != null) {
            _self.mapControl.GetQueryManager().QueryByCircle(startPoint, radius, qe.queryParams, onComplete, onError, userContext);
        }
    }
    function SMISRemoveCircle() {
        var circle = document.getElementById("SMISCircle");
        if (circle) { _self.mapControl.container.removeChild(circle); }
        circle = null;
    };
    this.GetJSON = function() { return _ActionToJSON(this.type, [layerNames, returnFields, whereClause, onComplete, onError, onStart, userContext]); };

};

SuperMap.IS.ClosestFacilityAction = function(facilityLayer, maxRadius, layerName, tolerance, onComplete, onError, onStart, userContext) {
    this.type = "SuperMap.IS.ClosestFacilityAction";
    this.json = _ActionToJSON(this.type, [layerName, tolerance, onComplete, onError, onStart]);
    var _facilityLayer = facilityLayer;
    var _maxRadius = maxRadius;
    var _layerName = layerName;
    var _tolerance = tolerance;
    var _proximityParam;
    var _self = this;
    this.Init = function(mapControl) {
        this.mapControl = mapControl;
        if (_ygPos.browser == "ie") { mapControl.container.style.cursor = _scriptLocation + "../images/cur_PointQuery.cur"; } else { mapControl.workLayer.style.cursor = "url(images/cur_PointQuery.cur),auto"; };
        if (!_tolerance) { _tolerance = 100; }
        if (!_proximityParam) {
            _proximityParam = new SuperMap.IS.ProximityParam();
            if (!_facilityLayer) {
                _facilityLayer = "Park@changchun";
            }
            if (!maxRadius) {
                _maxRaius = 500;
            }
            _proximityParam.facilityLayer = _facilityLayer;
            _proximityParam.maxRadius = _maxRadius;
            _proximityParam.networkParams = new SuperMap.IS.NetworkParams();
            if (!_layerName) {
                _layerName = "RoadNet@changchun"//默认为长春下的网络数据
            }

            _proximityParam.networkParams = new SuperMap.IS.NetworkParams();
            _proximityParam.networkParams.networkSetting = new SuperMap.IS.NetworkSetting();
            _proximityParam.networkParams.networkSetting.edgeIDField = "SmID";
            _proximityParam.networkParams.networkSetting.nodeIDField = "SmID";
            _proximityParam.networkParams.networkSetting.networkLayerName = _layerName;
            //_routeParam.networkParams.networkSetting.FTWeightField="SmLength";
            //_routeParam.networkParams.networkSetting.TFWeightField="SmLength";
            _proximityParam.networkParams.tolerance = _tolerance;
            _proximityParam.returnEdgeIDsAndNodeIDs = true;
            _proximityParam.returnNodePositions = true;
            _proximityParam.highlight = new SuperMap.IS.Highlight();
        }
    };
    this.Destroy = function() {
        this.mapControl = null;
        //		if(_queryParam){_queryParam.Destroy();}_queryParam=_returnFields=null;
    };

    this.OnClick = function(e) {
        //客户端查询前事件
        var cffe = new SuperMap.IS.ClosestFacilityFindingEventArgs();
        cffe.proximityParams = _proximityParam;
        cffe.clientActionArgs = new SuperMap.IS.ActionEventArgs();
        cffe.clientActionArgs.mapCoords = new Array();
        cffe.clientActionArgs.mapCoords[0] = e.mapCoord;
        if (onStart) { onStart(cffe, userContext); }
        //服务器查询前事件
        this.mapControl.TriggerServerStartingEvent("ClosestFacilityFinding", cffe, ClosestFacility);


    };
    function ClosestFacility(eJSON) {
        var eJ = eval("(" + eJSON + ")");
        var cffe = new SuperMap.IS.ClosestFacilityFindingEventArgs();
        cffe.FromJSON(eJ);
        if (_self.mapControl != null) {
            _self.mapControl.GetSpatialAnalystManager().ClosestFacility(cffe.clientActionArgs.mapCoords[0], cffe.proximityParams, onComplete, onError, userContext);
        }
    }
    this.OnDblClick = function(e) { };
    this.OnMouseMove = function(e) { };
    this.OnMouseDown = function(e) { };
    this.OnMouseUp = function(e) { };
    this.OnContextMenu = function(e) { };
    this.GetJSON = function() { return _ActionToJSON(this.type, [layerName, tolerance, onComplete, onError, onStart]); };
};

//左键选中,左键更新,右键取消添加
SuperMap.IS.AddEntityAction = function(layerName, layerType, onComplete, onError, userContext, lockID) {
    this.type = "SuperMap.IS.AddEntityAction";
    var keyPoints = new Array();
    var firstMapCoord = null;
    var xs = new Array();
    var ys = new Array();
    var actionStarted = false;
    var _self = this;
    var _type = layerType;
    var _layerName = layerName;
    var _curLayerName = _layerName;
    var _curLayerType = _type;

    this.Init = function(mapControl) {
        this.mapControl = mapControl;
        if (_ygPos.browser == "ie") { mapControl.container.style.cursor = _scriptLocation + "../images/cur_PointQuery.cur"; } else { mapControl.workLayer.style.cursor = "url(images/cur_PointQuery.cur),auto"; };
        if (!layerName) {
            layerName = "park@Changchun";
        }
        if (!layerType) {
            layerType = SuperMap.IS.LayerType.point;
        }
    };

    this.Destroy = function() {
        this.mapControl.CustomLayer.RemoveLine("LineAdding");
        this.mapControl.CustomLayer.RemovePolygon("PolygonAdding");
        this.mapControl = null;
    }

    this.SetEditLayer = function(editLayerName, editLayerType) {
        _layerName = editLayerName;
        _type = editLayerType;
    }
    function onAddEntityComplete(editResult, userContext) {
        function onMapControlUpdateComplete(editResult, userContext) {
            if (onComplete) {
                onComplete(editResult, userContext);
            }
        }
        if (_self.mapControl != null && editResult != null && editResult.succeed) {
            var bContains = _self.mapControl.GetMapBounds().ContainsRect(editResult.bounds);
            if (bContains) {
                _self.mapControl.Update(onMapControlUpdateComplete(editResult, userContext));
            }
            else {
                _self.mapControl.UpdateByServerMapStatus(onMapControlUpdateComplete(editResult, userContext));
            }
        }
    }

    this.OnClick = function(e) {
        if (_curLayerName != _layerName) {
            _selected = false;
            actionStarted = false;
            while (keyPoints.length > 0) {
                keyPoints.pop();
            }
            while (xs.length > 0) {
                xs.pop(); ys.pop();
            }
            firstMapCoord = null;
            _self.mapControl.CustomLayer.RemoveLine("LineAdding");
            _self.mapControl.CustomLayer.RemovePolygon("PolygonAdding");
        }
        _curLayerName = _layerName;
        _curLayerType = _type;

        if (_type == SuperMap.IS.LayerType.point) {
            //添加点
            var entity = new SuperMap.IS.Entity();
            entity.shape = new SuperMap.IS.Geometry();
            //entity.shape.id="1000";
            entity.shape.parts = new Array();
            entity.shape.feature = layerType;
            var mapCoord = e.mapCoord;
            entity.shape.points = new Array(mapCoord);
            var entities = new Array(entity);
            if (_self.mapControl != null) {
                if (lockID) {
                    _self.mapControl.GetEditManager().AddEntityByUserID(_self.mapControl.mapName, _layerName, entities, lockID, onAddEntityComplete, onError, userContext);
                } else {
                    _self.mapControl.GetEditManager().AddEntity(_self.mapControl.mapName, _layerName, entities, onAddEntityComplete, onError, userContext);
                }
            }
        }
        if (_type == SuperMap.IS.LayerType.line) {

            if (!actionStarted) {
                keyPoints.push(e.mapCoord);
                xs.push(e.mapCoord.x); ys.push(e.mapCoord.y);
            }
            actionStarted = true;
            keyPoints.push(e.mapCoord);
            xs.push(e.mapCoord.x); ys.push(e.mapCoord.y);
        }
        if (_type == SuperMap.IS.LayerType.polygon) {
            if (!actionStarted) {
                firstMapCoord = e.mapCoord;
                xs.push(e.mapCoord.x); ys.push(e.mapCoord.y);

            }
            else {
                xs.pop(); ys.pop();
                xs.push(e.mapCoord.x); ys.push(e.mapCoord.y);
            }
            actionStarted = true;
            keyPoints.push(e.mapCoord);
            xs.push(firstMapCoord.x); ys.push(firstMapCoord.y);
        }
    };
    this.OnDblClick = function(e) {
        //更新
        if (!actionStarted) { return false; }
        if (_type == SuperMap.IS.LayerType.line) {
            keyPoints.push(e.mapCoord);
            xs.push(e.mapCoord.x); ys.push(e.mapCoord.y);
            if (_self.mapControl != null && _self.mapControl.CustomLayer != null) {
                _self.mapControl.CustomLayer.RemoveLine("LineAdding");
            }
            var entity = new SuperMap.IS.Entity();
            entity.shape = new SuperMap.IS.Geometry();
            entity.shape.parts = new Array();
            entity.shape.feature = layerType;
            entity.shape.points = keyPoints;
            var entities = new Array(entity);
            if (_self.mapControl != null) {
                if (lockID) {
                    _self.mapControl.GetEditManager().AddEntityByUserID(_self.mapControl.mapName, _layerName, entities, lockID, onAddEntityComplete, onError, userContext);
                } else {
                    _self.mapControl.GetEditManager().AddEntity(_self.mapControl.mapName, _layerName, entities, onAddEntityComplete, onError, userContext);
                }
            }
            while (keyPoints.length > 0) {
                keyPoints.pop();
            }
            while (xs.length > 0) {
                xs.pop(); ys.pop();
            }
            actionStarted = false;
        }
        if (_type == SuperMap.IS.LayerType.polygon) {
            keyPoints.push(e.mapCoord);
            keyPoints.push(firstMapCoord);
            xs.pop(); ys.pop();
            xs.push(e.mapCoord.x); ys.push(e.mapCoord.y);
            xs.push(firstMapCoord.x); ys.push(firstMapCoord.y);
            if (_self.mapControl != null && _self.mapControl.CustomLayer != null) {
                _self.mapControl.CustomLayer.RemovePolygon("PolygonAdding");
            }
            var entity = new SuperMap.IS.Entity();
            entity.shape = new SuperMap.IS.Geometry();
            entity.shape.parts = new Array();
            entity.shape.feature = layerType;
            entity.shape.points = keyPoints;
            var entities = new Array(entity);
            if (_self.mapControl != null) {
                if (lockID) {
                    _self.mapControl.GetEditManager().AddEntityByUserID(_self.mapControl.mapName, _layerName, entities, lockID, onAddEntityComplete, onError, userContext);
                } else {
                    _self.mapControl.GetEditManager().AddEntity(_self.mapControl.mapName, _layerName, entities, onAddEntityComplete, onError, userContext);
                }
            }
            while (keyPoints.length > 0) {
                keyPoints.pop();
            }
            while (xs.length > 0) {
                xs.pop(); ys.pop();
            }
            firstMapCoord = null;
            actionStarted = false;
        }
    };
    this.OnMouseMove = function(e) {
        if (!actionStarted) { return false; }
        if (_curLayerType == SuperMap.IS.LayerType.line) {
            keyPoints.pop();
            xs.pop(); ys.pop();
            keyPoints.push(e.mapCoord);
            xs.push(e.mapCoord.x); ys.push(e.mapCoord.y);
            if (_self.mapControl != null && _self.mapControl.CustomLayer != null) {
                _self.mapControl.CustomLayer.InsertLine("LineAdding", xs, ys, 2, "blue");
            }
        }
        if (_curLayerType == SuperMap.IS.LayerType.polygon) {
            keyPoints.pop();
            xs.pop(); ys.pop();
            keyPoints.push(e.mapCoord);
            xs.push(e.mapCoord.x); ys.push(e.mapCoord.y);
            if (_self.mapControl != null && _self.mapControl.CustomLayer != null) {
                _self.mapControl.CustomLayer.InsertPolygon("PolygonAdding", xs, ys, 2, "blue", "white", 0.6, 1);
            }
        }
        e.cancelTriggerGeometryEvent = true;
    };
    this.OnMouseDown = function(e) { };
    this.OnMouseUp = function(e) { };
    this.OnContextMenu = function(e) {
        _selected = false;
        actionStarted = false;
        while (keyPoints.length > 0) {
            keyPoints.pop();
        }
        while (xs.length > 0) {
            xs.pop(); ys.pop();
        }
        firstMapCoord = null;
        if (_self.mapControl != null && _self.mapControl.CustomLayer != null) {
            _self.mapControl.CustomLayer.RemoveLine("LineAdding");
            _self.mapControl.CustomLayer.RemovePolygon("PolygonAdding");
        }
    };
    this.GetJSON = function() { return _ActionToJSON(this.type, [layerName, layerType, onComplete, onError, userContext, lockID]); };
};

//左键选中,左键更新,右键取消更新
SuperMap.IS.UpdateEntityAction = function(layerName, layerType, onComplete, onError, userContext, lockID) {
    this.type = "SuperMap.IS.UpdateEntityAction";
    var _queryParam = null;
    var _self = this;
    var _type = layerType;
    var _selected = false;
    var _id = -1; //目标实体ID
    var actionStarted = false;
    var keyPoints = new Array();
    var xs = new Array();
    var ys = new Array();
    var _self = this;
    var _layerName = layerName;
    var firstMapCoord;
    var _curLayerName = _layerName;
    var _curLayerType = _type;

    this.Init = function(mapControl) {
        this.mapControl = mapControl;
        if (_ygPos.browser == "ie") { mapControl.container.style.cursor = _scriptLocation + "../images/cur_PointQuery.cur"; } else { mapControl.workLayer.style.cursor = "url(images/cur_PointQuery.cur),auto"; };
        if (!layerName) {
            layerName = "park@Changchun";
        }
        if (!layerType) {
            layerType = SuperMap.IS.LayerType.point;
        }
        _queryParam = new SuperMap.IS.QueryParam();
        _queryParam.queryLayers = new Array();
        var ql = new SuperMap.IS.QueryLayer();
        ql.layerName = layerName;
        _queryParam.queryLayers.push(ql);
        _queryParam.expectCount = 1;
        _queryParam.highlight = new SuperMap.IS.Highlight();
        _queryParam.highlight.highlightQueryArea = false;
        _queryParam.highlight.highlightResult = false;
    };

    this.Destroy = function() {
        if (_self.mapControl != null) {
            _self.mapControl.CustomLayer.RemoveMark("PointUpdating");
            _self.mapControl.CustomLayer.RemoveLine("LineUpdating");
            _self.mapControl.CustomLayer.RemoveLine("LineDrawing");
            _self.mapControl.CustomLayer.RemovePolygon("PolygonUpdating");
            _self.mapControl.CustomLayer.RemovePolygon("PolygonDrawing");
            _self.mapControl = null;
        }
    }

    this.SetEditLayer = function(editLayerName, editLayerType) {
        _type = editLayerType;
        _layerName = editLayerName;
        _queryParam.queryLayers.pop();
        var ql = new SuperMap.IS.QueryLayer();
        ql.layerName = editLayerName;
        _queryParam.queryLayers.push(ql);
    }

    function onUpdateEntityComplete(editResult, userContext) {
        function onMapControlUpdateComplete(editResult, userContext) {
            if (onComplete) {
                onComplete(editResult, userContext);
            }
        }
        if (_self.mapControl != null && editResult != null && editResult.succeed) {
            var bContains = _self.mapControl.GetMapBounds().ContainsRect(editResult.bounds);
            if (bContains) {
                _self.mapControl.Update(onMapControlUpdateComplete(editResult, userContext));
            }
            else {
                _self.mapControl.UpdateByServerMapStatus(onMapControlUpdateComplete(editResult, userContext));
            }
            _self.mapControl.CustomLayer.RemoveMark("PointUpdating");
            _self.mapControl.CustomLayer.RemoveLine("LineUpdating");
            _self.mapControl.CustomLayer.RemovePolygon("PolygonUpdating");
            _self.mapControl.CustomLayer.RemovePolygon("PolygonDrawing");
        }
        _selected = false;
    }

    function onQueryComplete(resultSet, userContext) {

        if (resultSet != null && resultSet.currentCount == 1) {
            //高亮出来
            if (_type == SuperMap.IS.LayerType.point) {
                var x = resultSet.recordsets[0].records[0].center.x;
                var y = resultSet.recordsets[0].records[0].center.y;
                var innerHtml = "<div style='font-size:16px; color:blue; font-weight:bold'><img src='images/marker.gif' style='cursor:hand' /></div>";
                if (_self.mapControl != null) {
                    _self.mapControl.CustomLayer.InsertMark("PointUpdating", x, y, 10, 10, innerHtml);
                }
                _id = resultSet.recordsets[0].records[0].fieldValues[0];
                _selected = true;
            }
            if (_self.mapControl == null) {
                return;
            }
            if (_type == SuperMap.IS.LayerType.line) {
                //没有点串信息,只好再GetEntity
                _self.mapControl.GetEntity(_self.mapControl.mapName, _layerName, eval(resultSet.recordsets[0].records[0].fieldValues[0]), onGetEntityComplete, userContext);
            }
            if (_type == SuperMap.IS.LayerType.polygon) {
                //没有点串信息,只好再GetEntity
                _self.mapControl.GetEntity(_self.mapControl.mapName, _layerName, eval(resultSet.recordsets[0].records[0].fieldValues[0]), onGetEntityComplete, userContext);
            }
        }
    }

    function onGetEntityComplete(entity, userContext) {
        if (entity != null && entity.shape != null) {
            _id = entity.id;
            var pointsX = new Array();
            var pointsY = new Array();
            for (var i = 0; i < entity.shape.points.length; i++) {
                pointsX.push(entity.shape.points[i].x);
                pointsY.push(entity.shape.points[i].y);
            }
            if (_self.mapControl != null) {
                if (_type == SuperMap.IS.LayerType.line) {
                    _self.mapControl.CustomLayer.InsertLine("LineUpdating", pointsX, pointsY, 2, "blue", null, null, null, entity.shape.parts);
                }
                else if (_type == SuperMap.IS.LayerType.polygon) {
                    _self.mapControl.CustomLayer.InsertPolygon("PolygonUpdating", pointsX, pointsY, 2, "blue", "white", 0.6, 1, null, entity.shape.parts);
                }
            }
            //清空一下
            while (pointsX.length > 0) {
                pointsX.pop(); pointsY.pop();
            }
            pointsX = null;
            pointsY = null;
            _selected = true;

        }
    }

    this.OnClick = function(e) {
        if (_curLayerName != _layerName) {
            _selected = false;
            actionStarted = false;
            while (keyPoints.length > 0) {
                keyPoints.pop();
            }
            while (xs.length > 0) {
                xs.pop(); ys.pop();
            }
            firstMapCoord = null;
            _self.mapControl.CustomLayer.RemoveMark("PointUpdating");
            _self.mapControl.CustomLayer.RemoveLine("LineUpdating");
            _self.mapControl.CustomLayer.RemoveLine("LineDrawing");
            _self.mapControl.CustomLayer.RemovePolygon("PolygonUpdating");
            _self.mapControl.CustomLayer.RemovePolygon("PolygonDrawing");
        }
        _curLayerName = _layerName;
        _curLayerType = _type;
        if (_type == SuperMap.IS.LayerType.point) {
            if (!_selected) {
                //还没有选中点对象先进行一次查询
                if (_self.mapControl != null) {
                    _self.mapControl.GetQueryManager().FindNearest(e.mapCoord, 100, _queryParam, onQueryComplete, onError, userContext);
                }
            }
            else {
                //进行更新
                var entity = new SuperMap.IS.Entity();
                entity.shape = new SuperMap.IS.Geometry();
                entity.id = _id;
                entity.shape.parts = new Array();
                entity.shape.feature = layerType;
                var mapCoord = e.mapCoord;
                entity.shape.points = new Array(e.mapCoord);
                var entities = new Array(entity);
                if (_self.mapControl != null) {
                    if (lockID) {
                        _self.mapControl.GetEditManager().UpdateEntityByUserID(_self.mapControl.mapName, _layerName, entities, lockID, onUpdateEntityComplete, onError, userContext);
                    } else {
                        _self.mapControl.GetEditManager().UpdateEntity(_self.mapControl.mapName, _layerName, entities, onUpdateEntityComplete, onError, userContext);
                    }
                }
            }
        }
        if (_type == SuperMap.IS.LayerType.line) {
            if (!_selected) {
                // 还没有选中点对象先进行一次查询
                if (_self.mapControl != null) {
                    _self.mapControl.GetQueryManager().FindNearest(e.mapCoord, 100, _queryParam, onQueryComplete, onError, userContext);
                }
            }
            else {
                // 已选中对象,可以开始更新
                if (!actionStarted) {
                    keyPoints.push(e.mapCoord);
                    xs.push(e.mapCoord.x); ys.push(e.mapCoord.y);
                }
                actionStarted = true;
                keyPoints.push(e.mapCoord);
                xs.push(e.mapCoord.x); ys.push(e.mapCoord.y);
            }
        }
        if (_type == SuperMap.IS.LayerType.polygon) {
            if (!_selected) {
                //还没有选中点对象先进行一次查询
                if (_self.mapControl != null) {
                    _self.mapControl.GetQueryManager().FindNearest(e.mapCoord, 100, _queryParam, onQueryComplete, onError, userContext);
                }
            }
            else {
                if (!actionStarted) {
                    firstMapCoord = e.mapCoord;
                    xs.push(e.mapCoord.x); ys.push(e.mapCoord.y);

                } else {
                    xs.pop(); ys.pop();
                    xs.push(e.mapCoord.x); ys.push(e.mapCoord.y);
                }
                actionStarted = true;
                keyPoints.push(e.mapCoord);
                xs.push(firstMapCoord.x); ys.push(firstMapCoord.y);

            }
        }

    };
    this.OnDblClick = function(e) {
        if (!actionStarted) { return false; }
        if (_selected) {
            if (_type == SuperMap.IS.LayerType.line) {
                keyPoints.push(e.mapCoord);
                xs.push(e.mapCoord.x); ys.push(e.mapCoord.y);
                _self.mapControl.CustomLayer.RemoveLine("LineDrawing");
                var entity = new SuperMap.IS.Entity();
                entity.shape = new SuperMap.IS.Geometry();
                entity.id = _id;
                entity.shape.parts = new Array();
                entity.shape.feature = layerType;
                entity.shape.points = keyPoints;
                var entities = new Array(entity);
                if (_self.mapControl != null) {
                    if (lockID) {
                        _self.mapControl.GetEditManager().UpdateEntityByUserID(_self.mapControl.mapName, _layerName, entities, lockID, onUpdateEntityComplete, onError, userContext);
                    } else {
                        _self.mapControl.GetEditManager().UpdateEntity(_self.mapControl.mapName, _layerName, entities, onUpdateEntityComplete, onError, userContext);
                    }
                }
                while (keyPoints.length > 0) {
                    keyPoints.pop();
                }
                while (xs.length > 0) {
                    xs.pop(); ys.pop();
                }
                firstMapCoord = null;
                actionStarted = false;

            }
            if (_type == SuperMap.IS.LayerType.polygon) {
                keyPoints.push(e.mapCoord);
                keyPoints.push(firstMapCoord);
                xs.pop(); ys.pop();
                xs.push(e.mapCoord.x); ys.push(e.mapCoord.y);
                xs.push(firstMapCoord.x); ys.push(firstMapCoord.y);
                var entity = new SuperMap.IS.Entity();
                entity.shape = new SuperMap.IS.Geometry();
                entity.id = _id;
                entity.shape.parts = new Array();
                entity.shape.feature = layerType;
                entity.shape.points = keyPoints;
                var entities = new Array(entity);
                if (_self.mapControl != null) {
                    _self.mapControl.CustomLayer.RemoveLine("PolygonDrawing");
                    if (lockID) {
                        _self.mapControl.GetEditManager().UpdateEntityByUserID(_self.mapControl.mapName, _layerName, entities, lockID, onUpdateEntityComplete, onError, userContext);
                    } else {
                        _self.mapControl.GetEditManager().UpdateEntity(_self.mapControl.mapName, _layerName, entities, onUpdateEntityComplete, onError, userContext);
                    }
                }
                while (keyPoints.length > 0) {
                    keyPoints.pop();
                }
                while (xs.length > 0) {
                    xs.pop(); ys.pop();
                }
                firstMapCoord = null;
                actionStarted = false;
            }
        }
    };
    this.OnMouseMove = function(e) {
        if (!actionStarted) { return false; }
        if (_curLayerType == SuperMap.IS.LayerType.line) {
            keyPoints.pop();
            xs.pop(); ys.pop();
            keyPoints.push(e.mapCoord);
            xs.push(e.mapCoord.x); ys.push(e.mapCoord.y);
            if (_self.mapControl != null) {
                _self.mapControl.CustomLayer.InsertLine("LineDrawing", xs, ys, 2, "blue", null, null, null, null);
            }
        }
        if (_curLayerType == SuperMap.IS.LayerType.polygon) {
            keyPoints.pop();
            xs.pop(); ys.pop();
            keyPoints.push(e.mapCoord);
            xs.push(e.mapCoord.x); ys.push(e.mapCoord.y);
            this.mapControl.CustomLayer.InsertPolygon("PolygonDrawing", xs, ys, 2, "blue", "white", 0.6, 1, null, null);
        }
        e.cancelTriggerGeometryEvent = true;
    };
    this.OnMouseDown = function(e) { };
    this.OnMouseUp = function(e) { };
    this.OnContextMenu = function(e) {
        _selected = false;
        actionStarted = false;
        while (keyPoints.length > 0) {
            keyPoints.pop();
        }
        while (xs.length > 0) {
            xs.pop(); ys.pop();
        }
        firstMapCoord = null;
        if (_self.mapControl != null) {
            _self.mapControl.CustomLayer.RemoveMark("PointUpdating");
            _self.mapControl.CustomLayer.RemoveLine("LineUpdating");
            _self.mapControl.CustomLayer.RemoveLine("LineDrawing");
            _self.mapControl.CustomLayer.RemovePolygon("PolygonUpdating");
            _self.mapControl.CustomLayer.RemovePolygon("PolygonDrawing");
        }
    };
    this.GetJSON = function() { return _ActionToJSON(this.type, [layerName, layerType, onComplete, onError, userContext, lockID]); };
};

//左键选中,右键删除
SuperMap.IS.DeleteEntityAction = function(layerName, layerType, onComplete, onError, userContext, lockID) {
    this.type = "SuperMap.IS.DeleteEntityAction";
    this.json = _ActionToJSON(this.type, [layerName, layerType, onComplete, onError, userContext, lockID]);
    var _queryParam = null;
    var _self = this;
    var _type = layerType;
    var _layerName = layerName;
    var _selected = false;
    var _id = -1; //目标实体ID
    var _curLayerName = _layerName;
    var _curLayerType = _type;
    this.Init = function(mapControl) {
        this.mapControl = mapControl;
        if (_ygPos.browser == "ie") { mapControl.container.style.cursor = _scriptLocation + "../images/cur_PointQuery.cur"; } else { mapControl.workLayer.style.cursor = "url(images/cur_PointQuery.cur),auto"; };
        if (!layerName) {
            layerName = "park@Changchun";
        }
        if (!layerType) {
            layerType = SuperMap.IS.LayerType.point;
        }
        _queryParam = new SuperMap.IS.QueryParam();
        _queryParam.queryLayers = new Array();
        var ql = new SuperMap.IS.QueryLayer();
        ql.layerName = layerName;
        _queryParam.queryLayers.push(ql);
        _queryParam.expectCount = 1;
        _queryParam.highlight = new SuperMap.IS.Highlight();
        _queryParam.highlight.highlightQueryArea = false;
        _queryParam.highlight.highlightResult = false;
    };

    this.Destroy = function() {
        if (_self.mapControl != null && _self.mapControl.CustomLayer != null) {
            _self.mapControl.CustomLayer.RemoveMark("PointDeleting");
            _self.mapControl.CustomLayer.RemoveLine("LineDeleting");
            _self.mapControl.CustomLayer.RemovePolygon("PolygonDeleting");
        }
        this.mapControl = null;

    }

    this.SetEditLayer = function(editLayerName, editLayerType) {
        _type = editLayerType;
        _layerName = editLayerName;
        _queryParam.queryLayers.pop();
        var ql = new SuperMap.IS.QueryLayer();
        ql.layerName = editLayerName;
        _queryParam.queryLayers.push(ql);
    }
    function onDeleteEntityComplete(editResult, userContext) {
        if (_self.mapControl != null) {
            _self.mapControl.Update();
        }
        _selected = false;
        if (_self.mapControl != null && _self.mapControl.CustomLayer != null) {
            _self.mapControl.CustomLayer.RemoveMark("PointDeleting");
            _self.mapControl.CustomLayer.RemoveLine("LineDeleting");
            _self.mapControl.CustomLayer.RemovePolygon("PolygonDeleting");
        }
        if (onComplete) {
            onComplete(editResult, userContext);
        }
    }

    function onQueryComplete(resultSet, userContext) {

        if (resultSet != null && resultSet.currentCount == 1) {
            //高亮出来
            if (_type == SuperMap.IS.LayerType.point) {
                var x = resultSet.recordsets[0].records[0].center.x;
                var y = resultSet.recordsets[0].records[0].center.y;
                var innerHtml = "<div style='font-size:16px; color:blue; font-weight:bold'><img src='images/marker.gif' style='cursor:hand' /></div>";
                _self.mapControl.CustomLayer.InsertMark("PointDeleting", x, y, 10, 10, innerHtml);
                _id = resultSet.recordsets[0].records[0].fieldValues[0];
                _selected = true;
            }
            if (_self.mapControl == null) {
                return;
            }
            if (_type == SuperMap.IS.LayerType.line) {
                //没有点串信息,只好再GetEntity
                _self.mapControl.GetEntity(_self.mapControl.mapName, _layerName, eval(resultSet.recordsets[0].records[0].fieldValues[0]), onGetEntityComplete, userContext);
            }
            if (_type == SuperMap.IS.LayerType.polygon) {
                //没有点串信息,只好再GetEntity
                _self.mapControl.GetEntity(_self.mapControl.mapName, _layerName, eval(resultSet.recordsets[0].records[0].fieldValues[0]), onGetEntityComplete, userContext);
            }
        }
        else {
            if (self.mapControl != null && _self.mapControl.CustomLayer != null) {
                _self.mapControl.CustomLayer.RemoveMark("PointDeleting");
                _self.mapControl.CustomLayer.RemoveLine("LineDeleting");
                _self.mapControl.CustomLayer.RemovePolygon("PolygonDeleting");
            }
            _id = -1;
            _selected = false;
        }
    }

    function onGetEntityComplete(entity, userContext) {
        if (entity != null && entity.shape != null) {
            _id = entity.id;
            var pointsX = new Array();
            var pointsY = new Array();
            for (var i = 0; i < entity.shape.points.length; i++) {
                pointsX.push(entity.shape.points[i].x);
                pointsY.push(entity.shape.points[i].y);
            }
            if (_type == SuperMap.IS.LayerType.line) {
                _self.mapControl.CustomLayer.InsertLine("LineDeleting", pointsX, pointsY, 2, "blue", null, null, null, entity.shape.parts);
            }
            if (_type == SuperMap.IS.LayerType.polygon) {
                _self.mapControl.CustomLayer.InsertPolygon("PolygonDeleting", pointsX, pointsY, 2, "blue", "white", 0.6, 1, null, entity.shape.parts);
            }
            //清空一下
            while (pointsX.length > 0) {
                pointsX.pop(); pointsY.pop();
            }
            pointsX = null;
            pointsY = null;
            _selected = true;
        }
    }

    this.OnClick = function(e) {
        if (_curLayerName != _layerName) {
            _self.mapControl.CustomLayer.RemoveMark("PointDeleting");
            _self.mapControl.CustomLayer.RemoveLine("LineDeleting");
            _self.mapControl.CustomLayer.RemovePolygon("PolygonDeleting");
        }
        _curLayerName = _layerName;
        _curLayerType = _type;
        if (_self.mapControl != null) {
            _self.mapControl.GetQueryManager().FindNearest(e.mapCoord, 100, _queryParam, onQueryComplete, onError, userContext);
        }
    };
    this.OnDblClick = function(e) { };
    this.OnMouseMove = function(e) { };
    this.OnMouseDown = function(e) { };
    this.OnMouseUp = function(e) { };
    this.OnContextMenu = function(e) {
        if (_selected) {
            var entity = new SuperMap.IS.Entity();
            var ids = new Array();
            ids.push(_id);
            if (_self.mapControl != null) {
                if (lockID) {
                    _self.mapControl.GetEditManager().DeleteEntityByUserID(_self.mapControl.mapName, layerName, ids, lockID, onDeleteEntityComplete, onError, userContext);
                } else {
                    _self.mapControl.GetEditManager().DeleteEntity(_self.mapControl.mapName, layerName, ids, onDeleteEntityComplete, onError, userContext);
                }
            }
        }
    };
    this.GetJSON = function() { return _ActionToJSON(this.type, [layerName, layerType, onComplete, onError, userContext, lockID]); };
};


//左键选中,左键按下开始平移,松开左键提交
SuperMap.IS.MoveEntityAction = function(layerName, layerType, onComplete, onError, userContext, lockID) {
    this.type = "SuperMap.IS.MoveEntityAction";
    var _queryParam = null;
    var _self = this;
    var _type = layerType;
    var _layerName = layerName;
    var _selected = false;
    var _id = -1; //目标实体ID
    var _startToMove = false;
    var _pointsX = new Array();
    var _pointsY = new Array();
    var _startPoint = null;
    var _curPoint = null;
    var _parts = null; //复杂对象的子对象个数
    var _curLayerName = _layerName;
    var _curLayerType = _type;
    var _innerHtml = "<div style='font-size:16px; color:blue; font-weight:bold'><img src='images/marker.gif' style='cursor:hand' /></div>";
    this.Init = function(mapControl) {
        this.mapControl = mapControl;
        if (_ygPos.browser == "ie") { mapControl.container.style.cursor = _scriptLocation + "../images/cur_PointQuery.cur"; } else { mapControl.workLayer.style.cursor = "url(images/cur_PointQuery.cur)"; };
        if (!layerName) {
            layerName = "park@Changchun";
        }
        if (!layerType) {
            layerType = SuperMap.IS.LayerType.point;
        }
        _queryParam = new SuperMap.IS.QueryParam();
        _queryParam.queryLayers = new Array();
        var ql = new SuperMap.IS.QueryLayer();
        ql.layerName = layerName;
        _queryParam.queryLayers.push(ql);
        _queryParam.expectCount = 1;
        _queryParam.highlight = new SuperMap.IS.Highlight();
        _queryParam.highlight.highlightQueryArea = false;
        _queryParam.highlight.highlightResult = false;
    };

    this.Destroy = function() {
        if (_self.mapControl != null && _self.mapControl.CustomLayer != null) {
            _self.mapControl.CustomLayer.RemoveMark("PointMoving");
            _self.mapControl.CustomLayer.RemoveLine("LineMoving");
            _self.mapControl.CustomLayer.RemovePolygon("PolygonMoving");
        }
        this.mapControl = null;
        while (_pointsX != null && _pointsX.length > 0) {
            _pointsX.pop();
            _pointsX = null;
        }
        while (_pointsY != null && _pointsY.length > 0) {
            _pointsY.pop();
            _pointsY = null;
        }

    }
    this.SetEditLayer = function(editLayerName, editLayerType) {
        _type = editLayerType;
        _layerName = editLayerName;
        _queryParam.queryLayers.pop();
        var ql = new SuperMap.IS.QueryLayer();
        ql.layerName = editLayerName;
        _queryParam.queryLayers.push(ql);
    }
    function onQueryComplete(resultSet, userContext) {

        if (resultSet != null && resultSet.currentCount == 1) {
            //高亮出来
            if (_type == SuperMap.IS.LayerType.point) {
                var x = resultSet.recordsets[0].records[0].center.x;
                var y = resultSet.recordsets[0].records[0].center.y;
                if (_self.mapControl != null && _self.mapControl.CustomLayer != null) {
                    _self.mapControl.CustomLayer.InsertMark("PointMoving", x, y, 10, 10, _innerHtml);
                }
                while (_pointsX != null && _pointsX.length > 0) {
                    _pointsX.pop();
                }
                while (_pointsY != null && _pointsY.length > 0) {
                    _pointsY.pop();
                }
                _pointsX = new Array();
                _pointsY = new Array();
                _pointsX.push(x);
                _pointsY.push(y);
                _id = resultSet.recordsets[0].records[0].fieldValues[0];
                _selected = true;
                if (_self.mapControl != null) {
                    if (_ygPos.browser == "ie") { _self.mapControl.container.style.cursor = _scriptLocation + "../images/cur_Pan.cur"; } else { _self.mapControl.container.style.cursor = "url(images/cur_Pan.cur),auto"; };
                }
            }
            if (_self.mapControl == null) {
                return;
            }
            if (_type == SuperMap.IS.LayerType.line) {
                //没有点串信息,只好再GetEntity
                _self.mapControl.GetEntity(_self.mapControl.mapName, _layerName, eval(resultSet.recordsets[0].records[0].fieldValues[0]), onGetEntityComplete, userContext);
            }
            if (_type == SuperMap.IS.LayerType.polygon) {
                //没有点串信息,只好再GetEntity
                _self.mapControl.GetEntity(_self.mapControl.mapName, _layerName, eval(resultSet.recordsets[0].records[0].fieldValues[0]), onGetEntityComplete, userContext);
            }
        }
        else {
            if (_self.mapControl != null && _self.mapControl.CustomLayer != null) {
                _self.mapControl.CustomLayer.RemoveMark("PointMoving");
                _self.mapControl.CustomLayer.RemoveLine("LineMoving");
                _self.mapControl.CustomLayer.RemovePolygon("PolygonMoving");
            }
            _id = -1;
            _selected = false;
        }
    }

    function onGetEntityComplete(entity, userContext) {
        if (entity != null && entity.shape != null) {
            _id = entity.id;
            _parts = new Array();
            for (var i = 0; i < entity.shape.parts.length; i++) {
                _parts[i] = entity.shape.parts[i];
            }
            while (_pointsX != null && _pointsX.length > 0) {
                _pointsX.pop();
            }
            while (_pointsY != null && _pointsY.length > 0) {
                _pointsY.pop();
            }
            for (var i = 0; i < entity.shape.points.length; i++) {
                _pointsX.push(entity.shape.points[i].x);
                _pointsY.push(entity.shape.points[i].y);
            }
            _selected = true;
            if (_self.mapControl == null) {
                return;
            }
            if (_type == SuperMap.IS.LayerType.line) {
                if (_self.mapControl.CustomLayer != null) {
                    _self.mapControl.CustomLayer.InsertLine("LineMoving", _pointsX, _pointsY, 2, "blue", null, null, null, entity.shape.parts);
                }
            }
            if (_type == SuperMap.IS.LayerType.polygon) {
                if (_self.mapControl.CustomLayer != null) {
                    _self.mapControl.CustomLayer.InsertPolygon("PolygonMoving", _pointsX, _pointsY, 2, "blue", "white", 0.6, 1, null, entity.shape.parts);
                }
            }

            if (_ygPos.browser == "ie") { _self.mapControl.container.style.cursor = _scriptLocation + "../images/cur_Pan.cur"; } else { _self.mapControl.container.style.cursor = "url(images/cur_Pan.cur),auto"; };
        }
    }

    this.OnClick = function(e) {
        if (_curLayerName != _layerName) {
            _selected = false;
            _startToMove = false;
            _self.mapControl.CustomLayer.RemoveMark("PointMoving");
            _self.mapControl.CustomLayer.RemoveLine("LineMoving");
            _self.mapControl.CustomLayer.RemovePolygon("PolygonMoving");
            if (_ygPos.browser == "ie") { _self.mapControl.container.style.cursor = _scriptLocation + "../images/cursors/PointQuery.cur"; } else { _self.mapControl.container.style.cursor = "url(mages/cursors/PointQuery.cur),auto"; };
        }
        _curLayerName = _layerName;
        _curLayerType = _type;
        if (!_selected) {
            if (_self.mapControl != null) {
                _self.mapControl.GetQueryManager().FindNearest(e.mapCoord, 100, _queryParam, onQueryComplete, onError, userContext);
            }
        }
    };
    this.OnDblClick = function(e) { };
    this.OnMouseMove = function(e) {
        if (_startToMove) {
            //开始平移
            var deltaX = e.mapCoord.x - _endPoint.x;
            var deltaY = e.mapCoord.y - _endPoint.y;
            _endPoint = e.mapCoord;
            if (_pointsX != null && _pointsX.length > 0) {
                for (var i = 0; i < _pointsX.length; i++) {
                    _pointsX[i] += deltaX;
                    _pointsY[i] += deltaY;
                }
            }
            if (_self.mapControl == null || _self.mapControl.CustomLayer == null) {
                return;
            }
            if (_type == SuperMap.IS.LayerType.point) {
                _self.mapControl.CustomLayer.InsertMark("PointMoving", _pointsX[0], _pointsY[0], 10, 10, _innerHtml);
            }
            if (_type == SuperMap.IS.LayerType.line) {
                _self.mapControl.CustomLayer.InsertLine("LineMoving", _pointsX, _pointsY, 2, "blue", null, null, null, _parts);
            }
            if (_type == SuperMap.IS.LayerType.polygon) {
                _self.mapControl.CustomLayer.InsertPolygon("PolygonMoving", _pointsX, _pointsY, 2, "blue", "white", 0.6, 1, null, _parts);
            }
            e.cancelTriggerGeometryEvent = true;
        }
    };
    this.OnMouseDown = function(e) {
        if (_selected) {
            _startToMove = true;
            _startPoint = e.mapCoord;
            _endPoint = e.mapCoord;
        }
    };
    this.OnMouseUp = function(e) {
        if (_startToMove) {
            _startToMove = false;
            _selected = false;
            if (_self.mapControl == null) {
                return;
            }
            if (_self.mapControl.CustomLayer != null) {
                _self.mapControl.CustomLayer.RemoveMark("PointMoving");
                _self.mapControl.CustomLayer.RemoveLine("LineMoving");
                _self.mapControl.CustomLayer.RemovePolygon("PolygonMoving");
            }
            var entity = new SuperMap.IS.Entity();
            entity.shape = new SuperMap.IS.Geometry();
            entity.id = _id;
            entity.shape.parts = _parts;
            entity.shape.feature = layerType;
            if (_pointsX && _pointsX.length > 0) {
                entity.shape.points = new Array();
                for (var i = 0; i < _pointsX.length; i++) {
                    entity.shape.points[i] = new SuperMap.IS.MapCoord(_pointsX[i], _pointsY[i]);
                }
                var entities = new Array(entity);
                if (lockID) {
                    _self.mapControl.GetEditManager().UpdateEntityByUserID(_self.mapControl.mapName, _layerName, entities, lockID, onUpdateEntityComplete, onError, userContext);
                } else {
                    _self.mapControl.GetEditManager().UpdateEntity(_self.mapControl.mapName, _layerName, entities, onUpdateEntityComplete, onError, userContext);
                }
            }
            if (_ygPos.browser == "ie") { _self.mapControl.container.style.cursor = _scriptLocation + "../images/cur_PointQuery.cur"; } else { _self.mapControl.container.style.cursor = "url(images/cur_PointQuery.cur),auto"; };
        }
    };
    this.OnContextMenu = function(e) {
        _selected = false;
        if (_self.mapControl == null) {
            return;
        }
        if (_self.mapControl.CustomLayer != null) {
            _self.mapControl.CustomLayer.RemoveMark("PointMoving");
            _self.mapControl.CustomLayer.RemoveLine("LineMoving");
            _self.mapControl.CustomLayer.RemovePolygon("PolygonMoving");
        }
        if (_ygPos.browser == "ie") { _self.mapControl.container.style.cursor = _scriptLocation + "../images/cur_PointQuery.cur"; } else { _self.mapControl.container.style.cursor = "url(images/cur_PointQuery.cur),auto"; };
    };

    function onUpdateEntityComplete(editResult, userContext) {
        function onMapControlUpdateComplete(editResult, userContext) {
            if (onComplete) {
                onComplete(editResult, userContext);
            }
        }
        if (_self.mapControl != null && editResult != null && editResult.succeed) {
            var bContains = _self.mapControl.GetMapBounds().ContainsRect(editResult.bounds);
            if (bContains) {
                _self.mapControl.Update(onMapControlUpdateComplete(editResult, userContext));
            }
            else {
                _self.mapControl.UpdateByServerMapStatus(onMapControlUpdateComplete(editResult, userContext));
            }
        }
    }

    this.GetJSON = function() { return _ActionToJSON(this.type, [layerName, layerType, onComplete, onError, userContext, lockID]); };
};