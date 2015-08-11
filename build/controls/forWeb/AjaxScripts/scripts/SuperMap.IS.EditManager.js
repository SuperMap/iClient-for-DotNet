//================================================================================ 
// SuperMap IS .NET 客户端程序，版权所有，北京超图软件股份有限公司，2000-2008。 
// 本程序只能在有效的授权许可下使用。未经许可，不得以任何手段擅自使用或传播。 
// 作 者:  SuperMap IS Web Team 
// 版 本:  $Id: SuperMap.IS.EditManager.js,v 1.21 2010/02/01 05:45:31 zhangyt Exp $
// 文 件:  SuperMap.IS.EditManager.js 
// 描 述:  AjaxScripts 编辑管理器 
// 更 新:  $Date: 2010/02/01 05:45:31 $ 
//================================================================================ 

SuperMap.IS.EditManager = function(mapHandler, mapName) {
    var queryUrl = mapHandler + "edit.ashx";
    var onComplete = null;
    var onError = null;
    // 用于注册事件处理函数。
    // onComplete, 原型参数: onComplete(resultSet); 
    // onError, 原型参数: onError(responseText); 
    function _RegisterHandler(onQueryComplete, onQueryError) {
        onComplete = onQueryComplete;
        onError = onQueryError;
    }
    this.RegisterHandler = _RegisterHandler;

    function _EditBase(mapName, methodName, paramNames, paramValues, onComplete, onError, userContext) {

        function onRequestComplete(responseText) {
            if (!responseText) { return; };
            var editResultJ = eval('(' + responseText + ')');
            if (editResultJ == null) { onComplete(null, userContext); return; }
            var editResult = new SuperMap.IS.EditResult();
            editResult.FromJSON(editResultJ);
            if (onComplete) { onComplete(editResult, userContext); }
            editResult.Destroy();
            editResult = null;
        };

        var reuqestManager = new SuperMap.IS.RequestManager(queryUrl, onRequestComplete, onError, userContext);
        reuqestManager.AddQueryString("map", mapName);
        reuqestManager.AddQueryString("method", methodName);
        reuqestManager.AddQueryStrings(paramNames, paramValues);
        reuqestManager.Send();
        reuqestManager.Destroy();
        reuqestManager = null;
        while (paramNames.length > 0) {
            paramNames.pop();
            paramValues.pop();
        }
        paramNames = null;
        paramValues = null;

    };

    this.AddEntity = function(mapName, layerName, entities, onComplete, onError, userContext) {
        _EditBase(mapName, "AddEntity", ["layerName", "entities"], [layerName, entities], onComplete, onError, userContext);
    };
    this.AddEntityByUserID = function(mapName, layerName, entities, userID, onComplete, onError, userContext) {
        _EditBase(mapName, "AddEntityByUserID", ["layerName", "entities", "userID"], [layerName, entities, userID], onComplete, onError, userContext);
    };
    this.DeleteEntity = function(mapName, layerName, ids, onComplete, onError, userContext) {
        _EditBase(mapName, "DeleteEntity", ["layerName", "ids"], [layerName, ids], onComplete, onError, userContext);
    };
    this.DeleteEntityByUserID = function(mapName, layerName, ids, userID, onComplete, onError, userContext) {
        _EditBase(mapName, "DeleteEntityByUserID", ["layerName", "ids", "userID"], [layerName, ids, userID], onComplete, onError, userContext);
    };
    this.UpdateEntity = function(mapName, layerName, entities, onComplete, onError, userContext) {
        _EditBase(mapName, "UpdateEntity", ["layerName", "entities"], [layerName, entities], onComplete, onError, userContext);
    };
    this.UpdateEntityByUserID = function(mapName, layerName, entities, userID, onComplete, onError, userContext) {
        _EditBase(mapName, "UpdateEntityByUserID", ["layerName", "entities", "userID"], [layerName, entities, userID], onComplete, onError, userContext);
    };
    this.AddPoint = function(mapName, layerName, point, fieldNames, fieldValues, onComplete, onError, userContext) {
        var entity = new SuperMap.IS.Entity();
        entity.shape = new SuperMap.IS.Geometry();
        entity.shape.parts = new Array();
        entity.shape.parts[0] = 1;
        entity.shape.feature = SuperMap.IS.LayerType.point;
        entity.shape.points = new Array(point);
        entity.fieldNames = fieldNames;
        entity.fieldValues = fieldValues;
        var entities = new Array(entity);
        _EditBase(mapName, "AddEntity", ["layerName", "entities"], [layerName, entities], onComplete, onError, userContext);
    };

    this.AddPointByUserID = function(mapName, layerName, point, fieldNames, fieldValues, userID, onComplete, onError, userContext) {
        var entity = new SuperMap.IS.Entity();
        entity.shape = new SuperMap.IS.Geometry();
        entity.shape.parts = new Array();
        entity.shape.parts[0] = 1;
        entity.shape.feature = SuperMap.IS.LayerType.point;
        entity.shape.points = new Array(point);
        entity.fieldNames = fieldNames;
        entity.fieldValues = fieldValues;
        var entities = new Array(entity);
        _EditBase(mapName, "AddEntityByUserID", ["layerName", "entities", "userID"], [layerName, entities, userID], onComplete, onError, userContext);
    };

    this.AddLine = function(mapName, layerName, points, fieldNames, fieldValues, onComplete, onError, userContext) {
        var entity = new SuperMap.IS.Entity();
        entity.shape = new SuperMap.IS.Geometry();
        entity.shape.parts = new Array();
        entity.shape.parts[0] = points.length;
        entity.shape.feature = SuperMap.IS.LayerType.line;
        entity.shape.points = points;
        entity.fieldNames = fieldNames;
        entity.fieldValues = fieldValues;
        var entities = new Array(entity);
        _EditBase(mapName, "AddEntity", ["layerName", "entities"], [layerName, entities], onComplete, onError, userContext);
    };

    this.AddLineByUserID = function(mapName, layerName, points, fieldNames, fieldValues, userID, onComplete, onError, userContext) {
        var entity = new SuperMap.IS.Entity();
        entity.shape = new SuperMap.IS.Geometry();
        entity.shape.parts = new Array();
        entity.shape.parts[0] = points.length;
        entity.shape.feature = SuperMap.IS.LayerType.line;
        entity.shape.points = points;
        entity.fieldNames = fieldNames;
        entity.fieldValues = fieldValues;
        var entities = new Array(entity);
        _EditBase(mapName, "AddEntityByUserID", ["layerName", "entities", "userID"], [layerName, entities, userID], onComplete, onError, userContext);
    };

    this.AddPolygon = function(mapName, layerName, points, fieldNames, fieldValues, onComplete, onError, userContext) {
        var entity = new SuperMap.IS.Entity();
        entity.shape = new SuperMap.IS.Geometry();
        entity.shape.parts = new Array();
        entity.shape.parts[0] = points.length;
        entity.shape.feature = SuperMap.IS.LayerType.polygon;
        entity.shape.points = points;
        entity.fieldNames = fieldNames;
        entity.fieldValues = fieldValues;
        var entities = new Array(entity);
        _EditBase(mapName, "AddEntity", ["layerName", "entities"], [layerName, entities], onComplete, onError, userContext);
    };

    this.AddPolygonByUserID = function(mapName, layerName, points, fieldNames, fieldValues, userID, onComplete, onError, userContext) {
        var entity = new SuperMap.IS.Entity();
        entity.shape = new SuperMap.IS.Geometry();
        entity.shape.parts = new Array();
        entity.shape.parts[0] = points.length;
        entity.shape.feature = SuperMap.IS.LayerType.polygon;
        entity.shape.points = points;
        entity.fieldNames = fieldNames;
        entity.fieldValues = fieldValues;
        var entities = new Array(entity);
        _EditBase(mapName, "AddEntityByUserID", ["layerName", "entities", "userID"], [layerName, entities, userID], onComplete, onError, userContext);
    };


    this.UpdatePoint = function(mapName, layerName, id, point, fieldNames, fieldValues, onComplete, onError, userContext) {
        var entity = new SuperMap.IS.Entity();
        entity.shape = new SuperMap.IS.Geometry();
        entity.shape.parts = new Array();
        entity.shape.parts[0] = 1;
        entity.id = id;
        entity.shape.feature = SuperMap.IS.LayerType.point;
        entity.shape.points = new Array(point);
        entity.fieldNames = fieldNames;
        entity.fieldValues = fieldValues;
        var entities = new Array(entity);
        _EditBase(mapName, "UpdateEntity", ["layerName", "entities"], [layerName, entities], onComplete, onError, userContext);
    };

    this.UpdatePointByUserID = function(mapName, layerName, id, point, fieldNames, fieldValues, userID, onComplete, onError, userContext) {
        var entity = new SuperMap.IS.Entity();
        entity.shape = new SuperMap.IS.Geometry();
        entity.shape.parts = new Array();
        entity.shape.parts[0] = 1;
        entity.id = id;
        entity.shape.feature = SuperMap.IS.LayerType.point;
        entity.shape.points = new Array(point);
        entity.fieldNames = fieldNames;
        entity.fieldValues = fieldValues;
        var entities = new Array(entity);
        _EditBase(mapName, "UpdateEntityByUserID", ["layerName", "entities", "userID"], [layerName, entities, userID], onComplete, onError, userContext);
    };

    this.UpdateLine = function(mapName, layerName, id, points, fieldNames, fieldValues, onComplete, onError, userContext) {
        var entity = new SuperMap.IS.Entity();
        entity.shape = new SuperMap.IS.Geometry();
        entity.shape.parts = new Array();
        entity.shape.parts[0] = points.length;
        entity.id = id;
        entity.shape.feature = SuperMap.IS.LayerType.line;
        entity.shape.points = points;
        entity.fieldNames = fieldNames;
        entity.fieldValues = fieldValues;
        var entities = new Array(entity);
        _EditBase(mapName, "UpdateEntity", ["layerName", "entities"], [layerName, entities], onComplete, onError, userContext);
    };

    this.UpdateLineByUserID = function(mapName, layerName, id, points, fieldNames, fieldValues, userID, onComplete, onError, userContext) {
        var entity = new SuperMap.IS.Entity();
        entity.shape = new SuperMap.IS.Geometry();
        entity.shape.parts = new Array();
        entity.shape.parts[0] = points.length;
        entity.id = id;
        entity.shape.feature = SuperMap.IS.LayerType.line;
        entity.shape.points = points;
        entity.fieldNames = fieldNames;
        entity.fieldValues = fieldValues;
        var entities = new Array(entity);
        _EditBase(mapName, "UpdateEntityByUserID", ["layerName", "entities", "userID"], [layerName, entities, userID], onComplete, onError, userContext);
    };

    this.UpdatePolygon = function(mapName, layerName, id, points, fieldNames, fieldValues, onComplete, onError, userContext) {
        var entity = new SuperMap.IS.Entity();
        entity.shape = new SuperMap.IS.Geometry();
        entity.shape.parts = new Array();
        entity.shape.parts[0] = points.length;
        entity.id = id;
        entity.shape.feature = SuperMap.IS.LayerType.polygon;
        entity.shape.points = points;
        entity.fieldNames = fieldNames;
        entity.fieldValues = fieldValues;
        var entities = new Array(entity);
        _EditBase(mapName, "UpdateEntity", ["layerName", "entities"], [layerName, entities], onComplete, onError, userContext);
    };

    this.UpdatePolygonByUserID = function(mapName, layerName, id, points, fieldNames, fieldValues, userID, onComplete, onError, userContext) {
        var entity = new SuperMap.IS.Entity();
        entity.shape = new SuperMap.IS.Geometry();
        entity.shape.parts = new Array();
        entity.shape.parts[0] = points.length;
        entity.id = id;
        entity.shape.feature = SuperMap.IS.LayerType.polygon;
        entity.shape.points = points;
        entity.fieldNames = fieldNames;
        entity.fieldValues = fieldValues;
        var entities = new Array(entity);
        _EditBase(mapName, "UpdateEntityByUserID", ["layerName", "entities", "userID"], [layerName, entities, userID], onComplete, onError, userContext);
    };

    function _DatasetOperateBase(methodName, paramNames, paramValues, onComplete, onError, userContext) {

        function onRequestComplete(responseText) {
            if (!responseText) { return; };
            var resultJ = eval('(' + responseText + ')');
            if (resultJ == null) { onComplete(null, userContext); return; }
            var result = new SuperMap.IS.DatasetOperateResult();
            result.FromJSON(resultJ);
            if (onComplete) { onComplete(result, userContext); }
            result.Destroy();
            result = null;
        };

        var reuqestManager = new SuperMap.IS.RequestManager(queryUrl, onRequestComplete, onError, userContext);
        reuqestManager.AddQueryString("map", mapName);
        reuqestManager.AddQueryString("method", methodName);
        reuqestManager.AddQueryStrings(paramNames, paramValues);
        reuqestManager.Send();
        reuqestManager.Destroy();
        reuqestManager = null;
        while (paramNames.length > 0) {
            paramNames.pop();
            paramValues.pop();
        }
        paramNames = null;
        paramValues = null;
    };

    this.CopyDataset = function(copyDatasetParam, resultDatasetCopyParam, onComplete, onError, userContext) {
        _DatasetOperateBase("CopyDataset", ["copyDatasetParam", "resultDatasetCopyParam"], [copyDatasetParam, resultDatasetCopyParam], onComplete, onError, userContext);
    };
    this.CopyDatasetByUserID = function(copyDatasetParam, resultDatasetCopyParam, userID, onComplete, onError, userContext) {
        _DatasetOperateBase("CopyDatasetByUserID", ["copyDatasetParam", "resultDatasetCopyParam", "userID"], [copyDatasetParam, resultDatasetCopyParam, userID], onComplete, onError, userContext);
    };
    this.CreateDataset = function(createDatasetParam, onComplete, onError, userContext) {
        _DatasetOperateBase("CreateDataset", ["createDatasetParam"], [createDatasetParam], onComplete, onError, userContext);
    };
    this.CreateDatasetByUserID = function(createDatasetParam, userID, onComplete, onError, userContext) {
        _DatasetOperateBase("CreateDatasetByUserID", ["createDatasetParam", "userID"], [createDatasetParam, userID], onComplete, onError, userContext);
    };
    this.DeleteDataset = function(dataset, onComplete, onError, userContext) {
        _DatasetOperateBase("DeleteDataset", ["dataset"], [dataset], onComplete, onError, userContext);
    };
    this.DeleteDatasetByUserID = function(dataset, userID, onComplete, onError, userContext) {
        _DatasetOperateBase("DeleteDatasetByUserID", ["dataset", "userID"], [dataset, userID], onComplete, onError, userContext);
    };

    function _GetExternalTableFieldInfos(methodName, paramNames, paramValues, onComplete, onError, userContext) {

        function onRequestComplete(responseText) {
            if (!responseText) { return; };
            var resultJ = eval('(' + responseText + ')');
            if (resultJ == null) { onComplete(null, userContext); return; }
            var result = new SuperMap.IS.GetFieldsResult();
            result.FromJSON(resultJ);
            if (onComplete) { onComplete(result, userContext); }
            result.Destroy();
            result = null;
        };

        var reuqestManager = new SuperMap.IS.RequestManager(queryUrl, onRequestComplete, onError, userContext);
        reuqestManager.AddQueryString("map", mapName);
        reuqestManager.AddQueryString("method", methodName);
        reuqestManager.AddQueryStrings(paramNames, paramValues);
        reuqestManager.Send();
        reuqestManager.Destroy();
        reuqestManager = null;
        while (paramNames.length > 0) {
            paramNames.pop();
            paramValues.pop();
        }
        paramNames = null;
        paramValues = null;
    };
    this.GetExternalTableFieldInfos = function(strTableName, datasourceName, onComplete, onError, userContext) {
        _GetExternalTableFieldInfos("GetExternalTableFieldInfos", ["strTableName", "datasourceName"], [strTableName, datasourceName], onComplete, onError, userContext);
    };

    function _GetExternalTableNames(methodName, paramNames, paramValues, onComplete, onError, userContext) {

        function onRequestComplete(responseText) {
            if (!responseText) { return; };
            var resultJ = eval('(' + responseText + ')');
            if (resultJ == null) { onComplete(null, userContext); return; }
            var result = new SuperMap.IS.GetExternalTableNamesResult();
            result.FromJSON(resultJ);
            if (onComplete) { onComplete(result, userContext); }
            result.Destroy();
            result = null;
        };

        var reuqestManager = new SuperMap.IS.RequestManager(queryUrl, onRequestComplete, onError, userContext);
        reuqestManager.AddQueryString("map", mapName);
        reuqestManager.AddQueryString("method", methodName);
        reuqestManager.AddQueryStrings(paramNames, paramValues);
        reuqestManager.Send();
        reuqestManager.Destroy();
        reuqestManager = null;
        while (paramNames.length > 0) {
            paramNames.pop();
            paramValues.pop();
        }
        paramNames = null;
        paramValues = null;
    };
    this.GetExternalTableNames = function(datasourceName, onComplete, onError, userContext) {
        _GetExternalTableNames("GetExternalTableNames", ["datasourceName"], [datasourceName], onComplete, onError, userContext);
    };

    function _ExternalTableOperator(methodName, paramNames, paramValues, onComplete, onError, userContext) {
        function onRequestComplete(responseText) {
            if (!responseText) { return; };
            var resultJ = eval('(' + responseText + ')');
            if (resultJ == null) { onComplete(null, userContext); return; }
            var result = new SuperMap.IS.ExternalTableOperatorResult();
            result.FromJSON(resultJ);
            if (onComplete) { onComplete(result, userContext); }
            result.Destroy();
            result = null;
        };

        var reuqestManager = new SuperMap.IS.RequestManager(queryUrl, onRequestComplete, onError, userContext);
        reuqestManager.AddQueryString("map", mapName);
        reuqestManager.AddQueryString("method", methodName);
        reuqestManager.AddQueryStrings(paramNames, paramValues);
        reuqestManager.Send();
        reuqestManager.Destroy();
        reuqestManager = null;
        while (paramNames.length > 0) {
            paramNames.pop();
            paramValues.pop();
        }
        paramNames = null;
        paramValues = null;
    };
    this.AddExternalTable = function(strTableName, strDTName, datasourceName, userID, onComplete, onError, userContext) {
        _ExternalTableOperator("AddExternalTable", ["strTableName", "strDTName", "datasourceName", "userID"], [strTableName, strDTName, datasourceName, userID], onComplete, onError, userContext);
    };
    this.RemoveExternalTable = function(strDTName, datasourceName, userID, onComplete, onError, userContext) {
        _ExternalTableOperator("RemoveExternalTable", ["strDTName", "datasourceName", "userID"], [strDTName, datasourceName, userID], onComplete, onError, userContext);
    };
    this.RegisterExternalTable = function(strDTName, datasourceName, bCreateSmID, userID, onComplete, onError, userContext) {
        _ExternalTableOperator("RegisterExternalTable", ["strDTName", "datasourceName", "bCreateSmID", "userID"], [strDTName, datasourceName, bCreateSmID, userID], onComplete, onError, userContext);
    };
    this.UnRegisterExternalTable = function(strDTName, datasourceName, userID, onComplete, onError, userContext) {
        _ExternalTableOperator("UnRegisterExternalTable", ["strDTName", "datasourceName", "userID"], [strDTName, datasourceName, userID], onComplete, onError, userContext);
    };


    function _FieldOperateBase(methodName, paramNames, paramValues, onComplete, onError, userContext) {

        function onRequestComplete(responseText) {
            if (!responseText) { return; };
            var resultJ = eval('(' + responseText + ')');
            if (resultJ == null) { onComplete(null, userContext); return; }
            var result = new SuperMap.IS.FieldOperateResult();
            result.FromJSON(resultJ);
            if (onComplete) { onComplete(result, userContext); }
            result.Destroy();
            result = null;
        };

        var reuqestManager = new SuperMap.IS.RequestManager(queryUrl, onRequestComplete, onError, userContext);
        reuqestManager.AddQueryString("map", mapName);
        reuqestManager.AddQueryString("method", methodName);
        reuqestManager.AddQueryStrings(paramNames, paramValues);
        reuqestManager.Send();
        reuqestManager.Destroy();
        reuqestManager = null;
        while (paramNames.length > 0) {
            paramNames.pop();
            paramValues.pop();
        }
        paramNames = null;
        paramValues = null;

    };

    this.CopyField = function(dataset, sourceFieldName, targetFieldName, onComplete, onError, userContext) {
        _FieldOperateBase("CopyField", ["dataset", "sourceFieldName", "targetFieldName"], [dataset, sourceFieldName, targetFieldName], onComplete, onError, userContext);
    };

    this.CopyFieldByUserID = function(dataset, sourceFieldName, targetFieldName, userID, onComplete, onError, userContext) {
        _FieldOperateBase("CopyFieldByUserID", ["dataset", "sourceFieldName", "targetFieldName", "userID"], [dataset, sourceFieldName, targetFieldName, userID], onComplete, onError, userContext);
    };

    this.CreateField = function(dataset, field, overwriteIfExists, onComplete, onError, userContext) {
        _FieldOperateBase("CreateField", ["dataset", "field", "overwriteIfExists"], [dataset, field, overwriteIfExists], onComplete, onError, userContext);
    };

    this.CreateFieldByUserID = function(dataset, field, overwriteIfExists, userID, onComplete, onError, userContext) {
        _FieldOperateBase("CreateFieldByUserID", ["dataset", "field", "overwriteIfExists", "userID"], [dataset, field, overwriteIfExists, userID], onComplete, onError, userContext);
    };

    this.DeleteField = function(dataset, fieldName, onComplete, onError, userContext) {
        _FieldOperateBase("DeleteField", ["dataset", "fieldName"], [dataset, fieldName], onComplete, onError, userContext);
    };

    this.DeleteFieldByUserID = function(dataset, fieldName, userID, onComplete, onError, userContext) {
        _FieldOperateBase("DeleteFieldByUserID", ["dataset", "fieldName", "userID"], [dataset, fieldName, userID], onComplete, onError, userContext);
    };

    this.SetField = function(dataset, fieldName, field, onComplete, onError, userContext) {
        _FieldOperateBase("SetField", ["dataset", "fieldName", "field"], [dataset, fieldName, field], onComplete, onError, userContext);
    };

    this.SetFieldByUserID = function(dataset, fieldName, field, userID, onComplete, onError, userContext) {
        _FieldOperateBase("SetFieldByUserID", ["dataset", "fieldName", "field", "userID"], [dataset, fieldName, field, userID], onComplete, onError, userContext);
    };

    this.UpdateFieldValues = function(dataset, fieldName, expression, filter, onComplete, onError, userContext) {
        _FieldOperateBase("UpdateFieldValues", ["dataset", "fieldName", "expression", "filter"], [dataset, fieldName, expression, filter], onComplete, onError, userContext);
    };

    this.UpdateFieldValuesByUserID = function(dataset, fieldName, expression, filter, userID, onComplete, onError, userContext) {
        _FieldOperateBase("UpdateFieldValuesByUserID", ["dataset", "fieldName", "expression", "filter", "userID"], [dataset, fieldName, expression, filter, userID], onComplete, onError, userContext);
    };



    function _LockLayerBase(mapName, methodName, paramNames, paramValues, onComplete, onError, userContext) {

        function onRequestComplete(responseText) {
            if (responseText == null) { return; };
            if (onComplete) { onComplete(responseText, userContext); }
        };

        var reuqestManager = new SuperMap.IS.RequestManager(queryUrl, onRequestComplete, onError, userContext);
        reuqestManager.AddQueryString("map", mapName);
        reuqestManager.AddQueryString("method", methodName);
        reuqestManager.AddQueryStrings(paramNames, paramValues);
        reuqestManager.Send();
        reuqestManager.Destroy();
        reuqestManager = null;
        while (paramNames.length > 0) {
            paramNames.pop();
            paramValues.pop();
        }
        paramNames = null;
        paramValues = null;

    };


    this.LockLayer = function(mapName, layerName, clientID, onComplete, onError, userContext) {
        _LockLayerBase(mapName, "LockLayer", ["layerName", "clientID"], [layerName, clientID], onComplete, onError, userContext);
    }

    function _UnlockLayerBase(mapName, methodName, paramNames, paramValues, onComplete, onError, userContext) {

        function onRequestComplete(responseText) {
            if (responseText == null) { return; };
            var result = eval('(' + responseText + ')');
            if (onComplete) { onComplete(result, userContext); }
        };

        var reuqestManager = new SuperMap.IS.RequestManager(queryUrl, onRequestComplete, onError, userContext);
        reuqestManager.AddQueryString("map", mapName);
        reuqestManager.AddQueryString("method", methodName);
        reuqestManager.AddQueryStrings(paramNames, paramValues);
        reuqestManager.Send();
        reuqestManager.Destroy();
        reuqestManager = null;
        while (paramNames.length > 0) {
            paramNames.pop();
            paramValues.pop();
        }
        paramNames = null;
        paramValues = null;
    };

    this.UnlockLayer = function(mapName, layerName, userID, onComplete, onError, userContext) {
        _UnlockLayerBase(mapName, "UnlockLayer", ["layerName", "userID"], [layerName, userID], onComplete, onError, userContext);
    }

};