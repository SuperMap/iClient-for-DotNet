//================================================================================ 
// SuperMap IS .NET 客户端程序，版权所有，北京超图软件股份有限公司，2000-2008。 
// 本程序只能在有效的授权许可下使用。未经许可，不得以任何手段擅自使用或传播。 
// 作 者:  SuperMap IS Web Team 
// 版 本:  $Id: SuperMap.IS.QueryManager.js,v 1.22 2009/12/18 02:22:11 zhangyt Exp $
// 文 件:  SuperMap.IS.QueryManager.js 
// 描 述:  AjaxScripts 查询功能 
// 更 新:  $Date: 2009/12/18 02:22:11 $ 
//================================================================================ 

SuperMap.IS.QueryManager=function(mapHandler,mapName,trackingLayerIndex,userID, keepHighlight){
    var queryUrl=mapHandler+"query.ashx";
    var onComplete=null;
    var onError=null;
    var _trackingLayerIndex=-1;
	var _userID="";
	var _eventsList = new Array();
	var _eventsNameList = new Array();
	var _keepHighlight = true;
	if (keepHighlight!=null){_keepHighlight=keepHighlight;}
    if(trackingLayerIndex!=null){_trackingLayerIndex=trackingLayerIndex;}
	if(userID!=null){_userID=userID;}
    // 用于注册事件处理函数。
    // onComplete, 原型参数: onComplete(resultSet); 
    // onError, 原型参数: onError(responseText); 
    function _RegisterHandler(onQueryComplete, onQueryError){
	    onComplete=onQueryComplete;
	    onError=onQueryError;
    }
    this.RegisterHandler=_RegisterHandler;

    function _QueryBase(methodName, paramNames, paramValues,onComplete,onError,userContext){
       
		function onRequestComplete(responseText) {
			var resultSetJ = eval('(' + responseText + ')');
		    if(resultSetJ==null){onComplete(null,userContext);return;}
			var resultSet=new SuperMap.IS.ResultSet();
			resultSet.FromJSON(resultSetJ);
			_ChangeTrackingLayerKeyInternal(resultSet.trackingLayerIndex,resultSet.userID,true);
		    if(onComplete){onComplete(resultSet,userContext);resultSet.Destroy();resultSet=null;}  
		};

        var reuqestManager = new SuperMap.IS.RequestManager(queryUrl,onRequestComplete,onError,userContext);
	    reuqestManager.AddQueryString("map",mapName);
	    reuqestManager.AddQueryString("method",methodName);
		reuqestManager.AddQueryString("keepHighlight",_keepHighlight);
	    reuqestManager.AddQueryStrings(paramNames,paramValues);
	    reuqestManager.Send();
	    reuqestManager.Destroy();
	    reuqestManager = null;
	    while(paramNames.length>0){
		    paramNames.pop();
		    paramValues.pop();
	    }
	    paramNames = null;
	    paramValues = null;
		
    };
    
    this.QueryByPoint=function(point, tolerance, queryParam,onComplete,onError,userContext){
    	_QueryBase("QueryByPoint", ["point","tolerance","queryParam","trackingLayerIndex","userID"], [point,tolerance,queryParam,_trackingLayerIndex,_userID],onComplete,onError,userContext);
    };
    
    this.QueryByLine=function(points, queryParam,onComplete,onError,userContext){
        _QueryBase("QueryByLine", ["points","queryParam","trackingLayerIndex","userID"], [points,queryParam,_trackingLayerIndex,_userID],onComplete,onError,userContext);
    };

    this.QueryBySql=function(queryParam,onComplete,onError,userContext){
    	_QueryBase("QueryBySql", ["queryParam","trackingLayerIndex","userID"], [queryParam,_trackingLayerIndex,_userID],onComplete,onError,userContext);
    };
	
	this.QueryByRect=function(mapRect,queryParam,onComplete,onError,userContext){
    	_QueryBase("QueryByRect", ["mapRect","queryParam","trackingLayerIndex","userID"],[mapRect,queryParam,_trackingLayerIndex,_userID],onComplete,onError,userContext);
    };
	
	this.QueryByPolygon=function(points,queryParam,onComplete,onError,userContext){
    	_QueryBase("QueryByPolygon", ["points","queryParam","trackingLayerIndex","userID"], [points,queryParam,_trackingLayerIndex,_userID],onComplete,onError,userContext);
    };
	
	this.QueryByCircle=function(center, radius, queryParam,onComplete,onError,userContext){
    	_QueryBase("QueryByCircle", ["center","radius","queryParam","trackingLayerIndex","userID"], [center,radius,queryParam,_trackingLayerIndex,_userID],onComplete,onError,userContext);
    };

    this.QueryByGeometry = function(geometry, queryParam, spatialQueryMode, onComplete, onError, userContext) {
    	_QueryBase("QueryByGeometry", ["geometry", "queryParam", "spatialQueryMode", "trackingLayerIndex", "userID"], [geometry, queryParam, spatialQueryMode, _trackingLayerIndex, _userID], onComplete, onError, userContext);
    };
    
    this.Find = function(queryParam,onComplete,onError,userContext){   
        _QueryBase("Find",["queryParam","trackingLayerIndex","userID"],[queryParam,_trackingLayerIndex,_userID],onComplete,onError,userContext); 
    };
    this.FindNearest = function(point,tolerance,queryParam,onComplete,onError,userContext){
        _QueryBase("FindNearest", ["point","tolerance","queryParam","trackingLayerIndex","userID"], [point,tolerance,queryParam,_trackingLayerIndex,_userID],onComplete,onError,userContext);
    };
    this.FindNearestWithBounds = function(point, tolerance, queryParam, onComplete, onError, userContext) {
        _QueryBase("FindNearestWithBounds", ["point", "tolerance", "queryParam", "trackingLayerIndex", "userID"], [point, tolerance, queryParam, _trackingLayerIndex, _userID], onComplete, onError, userContext);
    };
    this.ExecuteGSQL  = function (gsql,highlight,onComplete,onError,userContext){
        _QueryBase("ExecuteGSQL", ["gsql", "highlight", "trackingLayerIndex", "userID"], [gsql, highlight, _trackingLayerIndex, _userID], onComplete, onError, userContext);
    };
    this.StatisticsQuery = function(statisticsQueryParam,onComplete,onError,userContext){
        _QueryBase("StatisticsQuery",["statisticsQueryParam"],[statisticsQueryParam],onComplete,onError,userContext);
    };
    
    //对外,更新是由用户完成,不触发事件
    function _ChangeTrackingLayerKey(trackingLayerIndex,userID){
        _trackingLayerIndex=trackingLayerIndex;
        _userID=userID;
    };
    
    // 对内,更新是由服务器完成,触发事件
    function _ChangeTrackingLayerKeyInternal(trackingLayerIndex,userID,bSaveHistory){
        if(_trackingLayerIndex!=trackingLayerIndex||_userID!=userID){
            _trackingLayerIndex=trackingLayerIndex;
            _userID=userID;
            var param=new Object();
	        param.trackingLayerIndex = _trackingLayerIndex;
	        param.userID = _userID;
	        param.bSaveHistory = bSaveHistory;
            _TriggerEvent("onchangetrackinglayer", param);
        }
    };
    
    function _AttachEvent(event,listener){
        var events=_eventsList[event];
        if(!events){
            events=new Array();
            _eventsList[event]=events;
            _eventsNameList.push(event); 
        }
        for(var i=0;i<events.length;i++){
            if(events[i]==listener){return true;}
        }
        events.push(listener);
    };
    
   function _DetachEvent(event,listener){
        var events=_eventsList[event];
        if(!events){return;}
        for(var i=0;i<events.length;i++){
            if(events[i]==listener){
                events.splice(i,1);
            }
        }
    };
    
    function _TriggerEvent(event,arguments,userContext){
        var events=_eventsList[event];
        if(!events){return;}
        if(!arguments){ arguments=_GenerateEventArg(); }
        var eventsTemp=events.concat();
        for(var i=0; i<eventsTemp.length; i++){
            if(eventsTemp[i]){eventsTemp[i](arguments,userContext);}
        }
	    while(eventsTemp.length>0){eventsTemp.pop();}
    };
    
   function _GenerateEventArg(error,e){
	    var param=new Object();
	    param.trackingLayerIndex = _trackingLayerIndex;
	    param.userID = _userID;
	    if(!error){error="";}
	    return new EventArguments(param,error,e);
    };
    
    
    this.AttachEvent = _AttachEvent;
    this.DetachEvent = _DetachEvent;
    this.ChangeTrackingLayerKey = _ChangeTrackingLayerKey;
    
};
