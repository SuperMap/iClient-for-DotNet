//================================================================================ 
// SuperMap IS .NET 客户端程序，版权所有，北京超图软件股份有限公司，2000-2008。 
// 本程序只能在有效的授权许可下使用。未经许可，不得以任何手段擅自使用或传播。 
// 作 者:  SuperMap IS Web Team 
// 版 本:  $Id: SuperMap.IS.Utility.js,v 1.88 2011/03/16 09:53:07 zhanghui2 Exp $
// 文 件:  SuperMap.IS.Utility.js 
// 描 述:  AjaxScripts 辅助方法 
// 更 新:  $Date: 2011/03/16 09:53:07 $ 
//================================================================================ 

function _RegisterNamespaces() {
    for (var i = 0; i < arguments.length; i++) {
        var gv = arguments[i].split(".");
        var gX = window;
        for (var j = 0; j < gv.length; j++) {
            if (!gX[gv[j]]) {
                gX[gv[j]] = new Object();
            }
            gX = gX[gv[j]];
        }
    }
}
_RegisterNamespaces("SuperMap.IS");

//from prototype.js
if (typeof $ != 'function') {
    $ = function() {
        var elements = new Array();
        for (var i = 0; i < arguments.length; i++) {
            var element = arguments[i];
            if (typeof element == 'string') {
                element = document.getElementById(element);
            }
            if (arguments.length == 1) { return element; }
            elements.push(element);
        }
        return elements;
    };
}

//from Yahoo! dragdrop_1.0.2.js
function _GetScroll() {
    var t, l;
    if (document.documentElement && document.documentElement.scrollTop) {
        t = document.documentElement.scrollTop;
        l = document.documentElement.scrollLeft;
    } else {
        if (document.body) {
            t = document.body.scrollTop;
            l = document.body.scrollLeft;
        }
    }
    return {
        top: t,
        left: l
    };
};
function _GetStyle(el, _95) {
    if (el.style.styleProp) {
        return el.style.styleProp;
    } else {
        if (el.currentStyle) {
            return el.currentStyle[_95];
        } else {
            if (document.defaultView) { return document.defaultView.getComputedStyle(el, null).getPropertyValue(_95); }
        }
    }
};
function _GetScrollTop() {
    return _GetScroll().top;
};
function _GetScrollLeft() {
    return _GetScroll().left;
};
//_AddEvent(element,"mousedown",handleMouseDown)
function _AddEvent(el, eventType, fn, useCapture) {
    if (eventType.indexOf("on") == 0) {
        eventType = eventType.substring(2);
    }
    useCapture = (useCapture) ? true : false;
    if (el.addEventListener) {
        el.addEventListener(eventType, fn, useCapture);
    } else {
        if (el.attachEvent) {
            el.attachEvent("on" + eventType, fn);
        } else {
            el["on" + eventType] = fn;
        }
    }
};
function _RemoveEvent(el, eventType, fn, useCapture) {
    if (eventType.indexOf("on") == 0) {
        eventType = eventType.substring(2);
    }
    useCapture = (useCapture) ? true : false;
    if (el.removeEventListener) {
        el.removeEventListener(eventType, fn, useCapture);
    } else {
        if (el.detachEvent) {
            el.detachEvent("on" + eventType, fn);
        } else {
            el["on" + eventType] = null;
        }
    }
};
function _FixIEEvent(ev) {
    if (typeof ev.charCode == "undefined") {
        ev.charCode = (ev.type == "keypress") ? ev.keyCode : 0;
        ev.isChar = (ev.charCode > 0);
    }
    if (ev.srcElement && !ev.target) {
        ev.eventPhase = 2;
        ev.pageX = ev.clientX + _GetScrollLeft();
        ev.pageY = ev.clientY + _GetScrollTop();
        if (!ev.preventDefault) {
            ev.preventDefault = function() {
                this.returnValue = false;
            };
        }
        if (ev.type == "mouseout") {
            ev.relatedTarget = ev.toElement;
        } else {
            if (ev.type == "mouseover") {
                ev.relatedTarget = ev.fromElement;
            }
        }
        if (!ev.stopPropagation) {
            ev.stopPropagation = function() {
                this.cancelBubble = true;
            };
        }
        ev.target = ev.srcElement;
        ev.time = (new Date).getTime();
    }
    return ev;
};
function _FixDOMEvent(ev) {
    if (!ev.srcElement) {
        ev.srcElement = ev.originalTarget;
    }
    if (!ev.pageX && ev.clientX && ev.clientY) {
        ev.pageX = ev.clientX;
        ev.pageY = ev.clientY;
    }
    return ev;
};
// 下面这个方法有内存泄漏，暂时弃用。 
//function _GetEvent(e){if(_ygPos.browser=="ie"){ev=_FixIEEvent(window.event);}else{ev=_GetEvent.caller.arguments[0];ev=_FixDOMEvent(_GetEvent.caller.arguments[0]);}return ev;};
//function _GetEvent(e){if(window.event){ev=_FixIEEvent(window.event);}else{ev=_GetEvent.caller.arguments[0];ev=_FixDOMEvent(_GetEvent.caller.arguments[0]);}return ev;};

function _GetEvent(e) {
    return e ? e : window.event;
}
function _CancelBubble(e) {
    e.cancelBubble = true;
}
function _G(e) {
    e = _GetEvent(e);
    _CancelBubble(e);
    return false;
}
function _GetMouseX(e) {
    var posX = 0;
    if (e.clientX) {
        if (document.documentElement && document.documentElement.scrollLeft) {
            posX = e.clientX + document.documentElement.scrollLeft;
        } else if (document.body) {
            posX = e.clientX + document.body.scrollLeft;
        }
    }
    return posX;
}
function _GetMouseY(e) {
    var posY = 0;
    if (e.clientY) {
        if (document.documentElement && document.documentElement.scrollTop) {
            posY = e.clientY + document.documentElement.scrollTop;
        } else if (document.body) {
            posY = e.clientY + document.body.scrollTop;
        }
    }
    return posY;
}
function _GetMouseScrollDelta(e) {
    if (e.wheelDelta) {
        return e.wheelDelta;
    } else if (e.detail) { return -e.detail; }
    return 0;
}
function _GetTarget(e) {
    if (!e) {
        e = window.event;
    }
    var t = null;
    if (e.srcElement) {
        t = e.srcElement;
    } else if (e.target) {
        t = e.target;
    }
    if (t && t.nodeType) {
        if (t.nodeType == 3) {
            t = targ.parentNode;
        }
    }
    return t;
}
function _GetElementX(el) {
    return _GetOffset(el).left;
}
function _GetElementY(el) {
    return _GetOffset(el).top;
}
//function _GetElementX(el){return _ygPos.getX(el);}
//function _GetElementY(el){return _ygPos.getY(el);}
function _Floor(d) {
    return Math.floor(d);
}
function _Ceil(d) {
    return Math.ceil(d);
}
function _Max(d, f) {
    return Math.max(d, f);
}
function _Min(d, f) {
    return Math.min(d, f);
}
function _Abs(d) {
    return Math.abs(d);
}
function _Round(d) {
    return Math.round(d);
}
function _AngleToRadian(angle) {
    return angle * Math.PI / 180.0;
}
function _RadianToAngle(radian) {
    return radian * 180.0 / Math.PI;
}

// from Yahoo! position_1.0.2.js
var _ygPos = new function() {

    this.getPos = function(oEl) {
        var pos = [oEl.offsetLeft, oEl.offsetTop];
        var parent = oEl.offsetParent;
        var tmp = {
            x: null,
            y: null
        };
        if (parent != oEl) {
            while (parent) {
                switch (browser) {
                    case 'ie':
                        if (_getStyle(parent, 'position') == 'relative' && _getStyle(oEl, 'width') == 'auto' && !(_getStyle(oEl, 'position') != 'static')) {
                            return [oEl.offsetLeft, oEl.offsetTop];
                        } else if (_getStyle(parent, 'width') != 'auto' || _getStyle(oEl.parentNode, 'position') != 'static') {
                            tmp.x = parseInt(_getStyle(parent, 'borderLeftWidth'));
                            tmp.y = parseInt(_getStyle(parent, 'borderTopWidth'));
                            if (!isNaN(tmp.x)) pos[0] += tmp.x;
                            if (!isNaN(tmp.y)) pos[1] += tmp.y;
                        }
                        break;
                    case 'gecko':
                        if (_getStyle(parent, 'position') == 'relative') {
                            tmp.x = parseInt(_getStyle(parent, 'border-left-width'));
                            tmp.y = parseInt(_getStyle(parent, 'border-top-width'));
                            if (!isNaN(tmp.x)) pos[0] += tmp.x;
                            if (!isNaN(tmp.y)) pos[1] += tmp.y;
                        }
                        break;
                }
                pos[0] += parent.offsetLeft;
                pos[1] += parent.offsetTop;
                parent = parent.offsetParent;
            }
        }
        if (browser == 'ie' && _getStyle(oEl, 'width') != 'auto' && _getStyle(oEl.offsetParent, 'width') == 'auto'
                && _getStyle(oEl.offsetParent, 'position') == 'relative') {
            parent = oEl.parentNode;
            while (parent.tagName != 'HTML') {
                tmp.x = parseInt(_getStyle(parent, 'marginLeft'));
                tmp.y = parseInt(_getStyle(parent, 'paddingLeft'));
                if (!isNaN(tmp.x)) pos[0] -= tmp.x;
                if (!isNaN(tmp.y)) pos[0] -= tmp.y;
                parent = parent.parentNode;
            }
        }
        return pos;
    }, this.getX = function(oEl) {
        return this.getPos(oEl)[0];
    }

    this.getY = function(oEl) {
        return this.getPos(oEl)[1];
    }

    this.setPos = function(oEl, endPos) {
        var offset = [0, 0];
        var delta = {
            x: 0,
            y: 0
        };
        var curStylePos = _getStyle(oEl, 'position');
        if (curStylePos == 'static') {
            oEl.style.position = 'relative';
            curStylePos = 'relative';
        }
        if (oEl.offsetWidth) {
            if (curStylePos == 'relative') {
                offset = this.getPos(oEl);
                var tmp = {
                    x: _getStyle(oEl, 'left'),
                    y: _getStyle(oEl, 'top')
                };
                delta.x = (tmp.x && tmp.x.indexOf('px') != -1) ? parseInt(tmp.x) : 0;
                delta.y = (tmp.y && tmp.y.indexOf('px') != -1) ? parseInt(tmp.y) : 0;
            } else {
                offset = this.getPos(oEl.offsetParent);
                var tmp = {
                    x: _getStyle(oEl, 'margin-left'),
                    y: _getStyle(oEl, 'margin-top')
                };
                delta.x = (tmp.x && tmp.x.indexOf('px') != -1) ? 0 - parseInt(tmp.x) : 0;
                delta.y = (tmp.y && tmp.y.indexOf('px') != -1) ? 0 - parseInt(tmp.y) : 0;
            }
        }
        if (browser == 'safari') {
            if (oEl.offsetParent && oEl.offsetParent.tagName == 'BODY') {
                if (_getStyle(oEl, 'position') == 'relative') {
                    delta.x -= document.body.offsetLeft;
                    delta.y -= document.body.offsetTop;
                } else if (_getStyle(oEl, 'position') == 'absolute' || _getStyle(oEl, 'position') == 'fixed') {
                    delta.x += document.body.offsetLeft;
                    delta.y += document.body.offsetTop;
                }
            }
        }
        if (endPos[0] !== null) oEl.style.left = endPos[0] - offset[0] + delta.x + 'px';
        if (endPos[1] !== null) oEl.style.top = endPos[1] - offset[1] + delta.y + 'px';
    }

    this.setX = function(oEl, x) {
        this.setPos(oEl, [x, null]);
    }

    this.setY = function(oEl, y) {
        this.setPos(oEl, [null, y]);
    }

    var _getStyle = function(oEl, property) {
        var dv = document.defaultView;
        if (oEl.style[property]) return oEl.style[property];
        else if (oEl.currentStyle) {
            if (property.indexOf('-') != -1) {
                property = property.split('-');
                property[1] = property[1].toUpperCase().charAt(0) + property[1].substr(1);
                property = property.join('');
            }
            if (oEl.currentStyle[property]) return oEl.currentStyle[property];
        } else if (dv && dv.getComputedStyle(oEl, '') && dv.getComputedStyle(oEl, '').getPropertyValue(property))
            return dv.getComputedStyle(oEl, '').getPropertyValue(property);
        return null;
    }

    var _getBrowser = function() {
        var ua = navigator.userAgent.toLowerCase();
        var m = ua.match(/trident\/([^;]*)/);
        if (ua.indexOf('opera') != -1) return 'opera';
        else if (ua.indexOf('msie') != -1 && m != null && m[1] == 4.0) return 'ie8';
        else if (ua.indexOf('msie') != -1) return 'ie';
        else if (ua.indexOf('safari') != -1) return 'safari';
        else if (ua.indexOf('gecko') != -1) return 'gecko';
        else return false;
    }

    var _getIEVersion = function() {
        var Sys = {};
        var ua = navigator.userAgent.toLowerCase();
        var s;
        (s = ua.match(/msie ([\d.]+)/)) ? Sys.ie = s[1] : 0;
        return Sys.ie;
    }

    var ieVersion = _getIEVersion();
    var browser = _getBrowser();
    this.browser = browser;
    this.ieVersion = ieVersion;
};

//Enable VML support
function _EnableVML() {
    //IE6，IE7,IE8都使用VML,IE9不在使用VML
    if (_ygPos.browser.indexOf('ie') == -1 || (_ygPos.browser.indexOf('ie') >=0 && _ygPos.ieVersion=="9.0")) { return false; }
    // todo: support ie5.0, ie5.5
    var returnValue = true;
    if (typeof (document.namespaces) == "undefined" || typeof (document.namespaces) == "unknown") {
        return;
    }
    if (document.namespaces && !document.namespaces["v"]) {
        document.namespaces.add("v", "urn:schemas-microsoft-com:vml");
    }
    if (document.styleSheets.length < 1) {
        var _oStyle = document.createElement("style");
        document.body.appendChild(_oStyle);
    }
    if (document.styleSheets.item(0).addRule) {
        // ie8 根据使用的dtd类型的不同，使用VML需要对于样式表明确名称
        if (_ygPos.ieVersion && _ygPos.ieVersion < "8.0" ) { 
            document.styleSheets.item(0).addRule("v\\:*", "behavior:url(#default#VML); display:inline-block");
        }else{
            try {
                document.styleSheets.item(0).addRule("v\\:shape,v\\:fill,v\\:stroke,v\\:arc", "behavior:url(#default#VML); display:inline-block");
                
             } catch (ex) { 
                document.styleSheets.item(0).addRule("v\\:*", "behavior:url(#default#VML); display:inline-block");
                returnValue = true;               
             }
        }
    }
    _EnableVML = function() { /*nothing but just return true.*/return returnValue; };
    return returnValue;
}

function _ShowProps(obj, objName) {
    var result = "";
    for (var i in obj) {
        result += objName + "." + i + " = " + obj[i] + "\n";
    }
    return result;
}

function _GetXmlHttpRequest() {
    var xh = null;
    var ie = (navigator.userAgent.toLowerCase().indexOf("msie") != -1);
    if (ie) {
        try {
            xh = new ActiveXObject("Msxml2.XMLHTTP");
        } catch (ex) {
            try {
                xh = new ActiveXObject("Microsoft.XMLHTTP");
            } catch (ex) {
                xh = null;
            }
        }
    }
    if (!xh && typeof XMLHttpRequest != "undefined") {
        xh = new XMLHttpRequest();
    }
    return xh;
}

function _ToJSON(o, isEncode) {
    if (o == null) return "null";

    switch (o.constructor) {
        case String:
            var s = o; // .encodeURI();
            s = '"' + s.replace(/(["\\])/g, '\\$1') + '"';
            s = s.replace(/\n/g, "\\n");
            s = s.replace(/\r/g, "\\r");
            if (isEncode == true) {
                return encodeURIComponent(s);
            }
            return s;
        case Array:
            var v = [];
            for (var i = 0; i < o.length; i++)
                v.push(_ToJSON(o[i], isEncode));
            return "[" + v.join(", ") + "]";
        case Number:
            return isFinite(o) ? o.toString() : _ToJSON(null);
        case Boolean:
            return o.toString();
        case Date:
            var d = new Object();
            d.__type = "System.DateTime";
            d.Year = o.getUTCFullYear();
            d.Month = o.getUTCMonth() + 1;
            d.Day = o.getUTCDate();
            d.Hour = o.getUTCHours();
            d.Minute = o.getUTCMinutes();
            d.Second = o.getUTCSeconds();
            d.Millisecond = o.getUTCMilliseconds();
            d.TimezoneOffset = o.getTimezoneOffset();
            return _ToJSON(d, isEncode);
        default:
            if (o["toJSON"] != null && typeof o["toJSON"] == "function") return o.toJSON();
            if (typeof o == "object") {
                var v = [];
                for (attr in o) {
                    if (typeof o[attr] != "function") v.push('"' + attr + '": ' + _ToJSON(o[attr], isEncode));
                }

                if (v.length > 0) return "{" + v.join(", ") + "}";
                else
                    return "{}";
            }
            return o.toString();
    }
};

function _FromJSON(o, j) {
    if (!j) { return; }
    for (var m in j) {
        if (typeof (o[m]) == "object") {
            _FromJSON(o[m], j[m]);
        } else if (typeof (o[m]) != "function" && typeof (o[m]) != "undefined") {
            o[m] = j[m];
        }
    }
};

function _SplitX(points, offsetX) {
    if (typeof (offsetX) == "undefined") {
        offsetX = 0;
    }
    var pxs = new Array();
    for (var i = 0; i < points.length / 2; i++) {
        pxs.push(parseInt(points[2 * i]) + parseInt(offsetX));
    }
    return pxs;
}

function _SplitY(points, offsetY) {
    if (typeof (offsetY) == "undefined") {
        offsetY = 0;
    }
    var pys = new Array();
    for (var i = 0; i < points.length / 2; i++) {
        pys.push(parseInt(points[2 * i + 1]) + parseInt(offsetY));
    }
    return pys;
}

function _ActionToJSON(type, params) {
    var json = "";
    if (!type) { return; }
    var o = new Object();
    o.type = type;

    if (params) {
        o.params = params;
        if (o.params.length > 0) {
            for (var i = 0; i < o.params.length; i++) {
                if (typeof (o.params[i]) == "function") {
                    //并加一个标识
                    o.params[i] = "*function*:" + _GetFunctionName(o.params[i]);
                }
            }
        }
    }
    json = _ToJSON(o);
    return json;
}

function _JSONToAction(json) {
    var o = eval('(' + json + ')');
    var strParams = "";
    if (o.params) {
        for (var i = 0; i < o.params.length; i++) {
            if (i != 0) {
                strParams += ",";
            }
            if (typeof (o.params[i]) == "string") {
                //是否是function转换来的?
                var index = o.params[i].indexOf("*function*:");
                if (index == 0) {
                    o.params[i] = o.params[i].substring(11);
                    strParams += "eval(o.params[" + i + "])";
                    continue;
                }
            }
            strParams += "o.params[" + i + "]";
        }
    }
    var str = "new " + o.type + "(" + strParams + ")";
    return eval(str);
}

function _GetFunctionName(fun) {
    //只要名称,不要内容
    var funContent = fun.toString();
    var startIndex = funContent.indexOf(" ");
    var endIndex = funContent.indexOf("(");
    return funContent.substring(startIndex + 1, endIndex);
}

function _BackupLayers(_layersBackup, layers) {
    if (_layersBackup) {
        while (_layersBackup.length > 0) {
            _layersBackup.pop();
        }
    }
    if (layers) {
        var count = layers.length;
        for (var i = 0; i < count; i++) {
            if (layers[i]) {
                _layersBackup[i] = new SuperMap.IS.Layer();
                _layersBackup[i].FromJSON(layers[i]);
            } else {
                _layersBackup[i] = null;
            }
        }
    }
}

function _FindDifference(_layersBackup, layers) {
    var changedLayersJSON = "";
    var changedLayers = new Array();
    if (!layers) { return changedLayersJSON; }
    var count = layers.length;
    for (var i = 0; i < count; i++) {
        if (layers[i]) {
            if (!_layersBackup[i]) {
                if (changedLayers.length > 0) {
                    changedLayersJSON = changedLayersJSON + ",";
                }
                //changedLayers.push(_layers[i]);
                changedLayers[i] = layers[i];
                changedLayersJSON += i.toString();
                continue;
            }
            var o = SMISCompare(_layersBackup[i], layers[i]);
            //          var o=_layersBackup[i].SMISCompare(layers[i]);
            if (o) {
                /*
                if(changedLayers.length>0){changedLayersJSON =changedLayersJSON+",";}
                changedLayersJSON+=i.toString();
                changedLayersJSON+="|";
                if(o.themeRange&&o.themeRange.breakValueIndex)
                {
                changedLayersJSON+=o.themeRange.breakValueIndex;  
                }
                changedLayersJSON+="|";
                if(o.themeRange&&o.themeRange.displaysIndex)
                {
                changedLayersJSON+=o.themeRange.displaysIndex;
                }
                changedLayersJSON+="|";
                if(o.themeGraph&&o.themeGraph.graphStyleIndex)
                {
                changedLayersJSON+=o.themeGraph.graphStyleIndex;
                }
                */
                changedLayers[i] = o;
            } else {
                changedLayers[i] = "!@";
            }
        } else {
            //layer已被修改为null
            changedLayers[i] = null;
            if (i != 0) {
                changedLayersJSON = changedLayersJSON + ",";
            }
            changedLayersJSON += i.toString();
        }
    }
    changedLayersJSON = _ToJSON(changedLayers);
    return changedLayersJSON;
}

//以后如果有了打印控件的脚本,就把这个方法转移过去
function SMISPrintMap(param, mapControlPage, printControlPage, imageHandlerEnabled, map) {
    if (!param || !mapControlPage || !printControlPage) { return false; }
    var mapParam = eval('(' + param.mapParam + ')');
    var queryUrl = param.mapHandler + "common.ashx";
    var mapName = mapParam.mapName;
    var methodName = "GetUrl";

    function onRequestComplete(responseText) {
        if (!responseText) { return; }
        var url = responseText;
        printUrl = printControlPage + "?&Url=" + url + "&MapName=" + mapName + "&MapScale=" + mapParam.mapScale + "&MapControlPage=" + mapControlPage
                + "&ImageHandlerEnabled=" + imageHandlerEnabled + "&trackingLayerHistoryIndex=" + mapParam.trackingLayerIndex + "&userId=" + mapParam.userID;
        var printWin = window.open(printUrl, "", "resizable,toolbar,menubar,scrollbars,status");
        var hiddenLayers = document.getElementById("hiddenLayersForPrint");
        hiddenLayers.value = _ToJSON(map.layers);
        var hiddenMapParam = document.getElementById("hiddenMapParamForPrint");
        hiddenMapParam.value = _ToJSON(map.GetMapParam())
    };

    var reuqestManager = new SuperMap.IS.RequestManager(queryUrl, onRequestComplete, null);
    reuqestManager.AddQueryString("map", mapName);
    reuqestManager.AddQueryString("method", methodName);
    reuqestManager.AddQueryString("layersKey", param.layersKey);
    reuqestManager.AddQueryString("viewer", param.viewer);
    reuqestManager.AddQueryString("mapCenter", _ToJSON(mapParam.center));
    reuqestManager.AddQueryString("mapScale", mapParam.mapScale);
    reuqestManager.AddQueryString("viewBounds", _ToJSON(mapParam.viewBounds));
    reuqestManager.Send();
    reuqestManager.Destroy();
    reuqestManager = null;

}

function SMISGetMapParam() {
    var hiddenLayers = window.opener.document.getElementById("hiddenLayersForPrint");
    if (hiddenLayers) {
        var hiddenPrintLayers = document.getElementById("hiddenLayersInfo");
        hiddenPrintLayers.value = hiddenLayers.value;
    }

    var hiddenMapParam = window.opener.document.getElementById("hiddenMapParamForPrint");
    if (hiddenMapParam) {
        var hiddenPrintMapParam = document.getElementById("hiddenMapParamInfo");
        hiddenPrintMapParam.value = hiddenMapParam.value;
    }
}

function SMISCompare(object1, object2) {
    //    if(!object1||!object2||typeof(object1)!="object"||typeof(object2)!="object"){return;}
    //    if(object1.constructor!=object2.constructor){return;}
    var newObject = null;
    if (typeof (object1) != "object" && typeof (object1) != "function" && typeof (object2) != "object" && typeof (object2) != "function") {
        if (object1 != object2) {
            newObject = object2;
        }
    } else {
        if (object1 == null || object2 == null) {
            newObject = object2;
            return newObject;
        }
        for (var property in object1) {
            if (object2[property] == null) {
                if (object1[property] == null) {
                    continue;
                } else {
                    if (!newObject) {
                        newObject = new Object();
                    }
                    newObject[property] = null;
                    continue;
                }
            }
            //还要考虑object1[property] == null的情况
            if (object1[property] == null) {
                //由于上面已经考虑了两者都为null的情况，此处object2[property]必不为null
                if (!newObject) {
                    newObject = new Object();
                }
                newObject[property] = object2[property];
                continue;
            }
            if (object2[property] == object1[property]) {
                continue;
            } else {
                if (object2[property].constructor == Array) {
                    var length = object1[property].length > object2[property].length ? object1[property].length : object2[property].length;
                    for (var i = 0; i < length; i++) {
                        var result = SMISCompare(object1[property][i], object2[property][i]);
                        if (result != null) {
                            if (!newObject) {
                                newObject = new Object();
                            }
                            if (!newObject[property]) {
                                newObject[property] = new Array();
                            }
                            newObject[property][i] = result;
                        } else {
                            if (typeof (result) != "undefined") {
                                if (!newObject) {
                                    newObject = new Object();
                                }
                                if (!newObject[property]) {
                                    newObject[property] = new Array();
                                }
                                newObject[property][i] = "!@";
                            }
                        }
                    }
                } else if (object2[property].constructor == Function) {
                    continue;
                } else {
                    var result = SMISCompare(object1[property], object2[property]);
                    if (result != null) {
                        if (!newObject) {
                            newObject = new Object();
                        }
                        newObject[property] = result;
                    }
                }
            }
        }
    }
    return newObject;
}

function _AdjustCustomMarkPosition(customMarkID, alignStyle) {
    var customMark = document.getElementById(customMarkID);
    var offsetX, offsetY;
    if (customMark) {
        switch (alignStyle) {
            case 0:
                offsetX = 0;
                offsetY = 0;
                break;
            case 1:
                offsetX = 0;
                offsetY = customMark.offsetHeight / 2;
                break;
            case 2:
                offsetX = 0;
                offsetY = customMark.offsetHeight;
                break;
            case 3:
                offsetX = customMark.offsetWidth / 2;
                offsetY = 0;
                break;
            case 4:
                offsetX = customMark.offsetWidth / 2;
                offsetY = customMark.offsetHeight / 2;
                break;
            case 5:
                offsetX = customMark.offsetWidth / 2;
                offsetY = customMark.offsetHeight;
                break;
            case 6:
                offsetX = customMark.offsetWidth;
                offsetY = 0;
                break;
            case 7:
                offsetX = customMark.offsetWidth;
                offsetY = customMark.offsetHeight / 2;
                break;
            case 8:
                offsetX = customMark.offsetWidth;
                offsetY = customMark.offsetHeight;
                break;
            default:
                offsetX = 0;
                offsetY = 0;
                break;
        }
        // 没有必要设置zIndex 
        //customMark.style.zIndex = 1000;
        customMark.style.left = (parseFloat(customMark.style.left) - offsetX) + "px";
        customMark.style.top = (parseFloat(customMark.style.top) - offsetY) + "px";
    }
}

function _CreateMapControl(clientID, centerX, centerY, mapScale, bModifiedByServer, mapHandler, mapName, imageFormat, fixedView, buffer, trackingLayerIndex,
        userID, writeScalesInfoToScript, antiAlias, disableLogo, tileSize, useImageBuffer, customQueryString, wheelZoomByMouse, tileCheckTime, redirect, writeAntiAliasesToScript) {
    var doc = document;
    //    为了兼容Jquery等插件的使用
    //    var container = $(clientID);
    var container = doc.getElementById(clientID);
    var params = new Object();
    //    var hiddenLayers = $(clientID + "_hiddenLayers");
    var hiddenLayers = doc.getElementById(clientID + "_hiddenLayers");
    if (hiddenLayers && hiddenLayers.value) {
        var layers = eval(hiddenLayers.value);
        if (layers) {
            params.layers = new Array();
            for (var i = 0; i < layers.length; i++) {
                if (layers[i]) {
                    params.layers[i] = new SuperMap.IS.Layer();
                    params.layers[i].FromJSON(layers[i]);
                }
            }
        }
    }

    //    var hiddenMapParam = $(clientID + "_hiddenMapParam");
    var hiddenMapParam = doc.getElementById(clientID + "_hiddenMapParam");
    if (hiddenMapParam && hiddenMapParam.value) {
        var paramInfo = hiddenMapParam.value;
        var mapParam = eval('(' + paramInfo + ')');
        params.x = mapParam.center.x;
        params.y = mapParam.center.y;
        params.mapScale = mapParam.mapScale;
        params.mapBounds = mapParam.mapBounds;
    } else {
        params.x = centerX;
        params.y = centerY;
        params.mapScale = mapScale;
    }
    //    var hiddenWmsLayer = $(clientID + "_hiddenWmsLayers");
    //    var hiddenWmsLayer = doc.getElementById(clientID + "_hiddenWmsLayers");
    //    if (hiddenWmsLayer && hiddenWmsLayer.value) {
    //        var wmsLayersInfo = hiddenWmsLayer.value;
    //        var wmsLayers = eval('(' + wmsLayersInfo + ')');
    //    }

    //client custom params
    var hiddenMapStatusValues = doc.getElementById(clientID + "_hiddenMapStatuses");
    if (hiddenMapStatusValues && hiddenMapStatusValues.value) {
        var mapStatus_values = eval('(' + hiddenMapStatusValues.value + ')');
        params.mapStatuses = new Array();
        for (var index = 0; index < mapStatus_values.length; index++) {
            var mapStatusMapName = mapStatus_values[index].mapName;
            if (mapStatusMapName) {
                params.mapStatuses[mapStatusMapName] = mapStatus_values[index];
            }
        }
    }

    params.bModifiedByServer = bModifiedByServer; //是否进行了编辑
    params.mapHandler = mapHandler;
    params.mapName = mapName;
    params.imageFormat = imageFormat;
    params.fixedView = fixedView;
    params.buffer = buffer;
    params.trackingLayerIndex = trackingLayerIndex;
    params.userID = userID;
    eval(writeScalesInfoToScript);

    params.antiAlias = antiAlias;
    params.disableLogo = disableLogo;
    params.tileSize = tileSize;
    params.useImageBuffer = useImageBuffer;
    params.customQueryString = customQueryString;
    params.wheelZoomByMouse = wheelZoomByMouse;
    params.tileCheckTime = tileCheckTime;
    params.redirect = redirect;
    params.storeClientInfo = true;

    eval(writeAntiAliasesToScript);
        
    eval(clientID + "=new SuperMap.IS.MapControl(container,params);");

};

function _InitMapControl(clientID) {
    var init = function() {
        eval(clientID + ".Init();");
    }
    return init;
};

function _InitMapControlInternal(clientID) {
    eval(clientID + ".Init()");
}

function _DisposeMapControl(clientID) {
    var destroy = function() {
        eval("if(" + clientID + "){" + clientID + ".Destroy();" + clientID + "=null;}");
    }
    return destroy;
};

function _DisposeMapControlInternal(clientID) {
    eval("if(" + clientID + "){" + clientID + ".Destroy();" + clientID + "=null;}");
};

function _IsInCurrentDomain(url) {
    if (!url) { return true; }
    // 本地文件页面地址，直接返回 true。
    if (document.location.protocol.toLowerCase() == "file:") { return true; }

    var index = url.indexOf("//");
    // 相对路径
    if (index == -1) { return true; }

    var protocol = url.substring(0, index);
    if (document.location.protocol.toLowerCase() != protocol.toLowerCase()) { return false; }

    var subText = url.substring(index + 2); // "//"之后的部分
    var domainWithPortIndex = subText.indexOf("/");
    var domainWithPort = subText.substring(0, domainWithPortIndex);
    var portIndex = domainWithPort.indexOf(":");
    var domain = domainWithPort;
    if (portIndex != -1) {
        domain = domainWithPort.substring(0, portIndex);
    }
    if (domain != document.location.hostname) { return false; }

    var currentPort = document.location.port;
    if (!currentPort || currentPort == "") {
        var currentProtocolLower = document.location.protocol.toLowerCase();
        switch (currentProtocolLower) {
            case "http:": currentPort = 80; break;
            case "https:": currentPort = 443; break;
            case "ftp:": currentPort = 21; break;
            case "file:": currentPort = ""; break;
            default: currentPort = 80; break;
        }
    }

    var port = 80;
    if (portIndex != -1) {
        port = domainWithPort.substring(portIndex + 1);
    } else {
        var protocolLower = protocol.toLowerCase();
        switch (protocolLower) {
            case "http:": port = 80; break;
            case "https:": port = 443; break;
            case "ftp:": port = 21; break;
            case "file:": port = ""; break;
            default: port = 80; break;
        }
    }

    if (port != currentPort) { return false; }
    return true;
}

// 支持 Firebug 形式的控制台调试。 
if (!console) {
    var console = {
        log: function() {
        }
    };
    var cn = ["assert", "count", "debug", "dir", "dirxml", "error", "group", "groupEnd", "info", "profile", "profileEnd", "time", "timeEnd", "trace", "warn",
            "log"];
    var i = 0, tn;
    while ((tn = cn[i++])) {
        if (!console[tn]) {
            (function() {
                var _c = tn + "";
                console[_c] = function() {
                    var a = Array.apply({}, arguments);
                    a.unshift(_c + ":");
                    console.log(a.join(" "));
                };
            })();
        }
    }
};

function isPointInGeometry(position, geometry, tolerance) {
    if (!position || !geometry) { return; }
    if (!tolerance || tolerance < 0) { tolerance = 0; }
    switch (geometry.feature) {
        case SuperMap.IS.FeatureType.point:
            var distance = Math.sqrt(Math.pow(geometry.points[0].x - position.x, 2) + Math.pow(geometry.points[0].y - position.y, 2));
            if (distance <= tolerance) {
                return true;
            }
            break;
        case SuperMap.IS.FeatureType.line:
            for (var i = 0; i < geometry.points.length - 1; i++) {
                var distance = DistPtToLine(geometry.points[i], geometry.points[i + 1], position);
                if (distance > 0 && distance <= tolerance) {
                    return true;
                }
            }
            break;
        case SuperMap.IS.FeatureType.polygon:
            if (IsPointInPolygon(position, geometry)) {
                return true;
            }
            else {
                for (var i = 0; i < geometry.points.length - 1; i++) {
                    var distance = DistPtToLine(geometry.points[i], geometry.points[i + 1], position);
                    if (distance > 0 && distance <= tolerance) {
                        return true;
                    }
                }
                //需要考虑闭合的情况，可能多边形的点最后一个点和第一个点不相等
                {
                    var distance = DistPtToLine(geometry.points[geometry.points.length - 1], geometry.points[0], position);
                    if (distance > 0 && distance <= tolerance) {
                        return true;
                    }
                }
            }
            break;
        default:
            return false;
    }
    return false;
};

function DistPtToLine(pntStart, pntEnd, pntHitTest) {
    var dist = -1;
    if (pntStart.x == pntEnd.x && pntStart.y == pntEnd.y) {
        return -1;
    }

    //判断交点是否在延长线上
    var distanceA = Math.sqrt(Math.pow(pntHitTest.x - pntStart.x, 2) + Math.pow(pntHitTest.y - pntStart.y, 2));
    var distanceB = Math.sqrt(Math.pow(pntHitTest.x - pntEnd.x, 2) + Math.pow(pntHitTest.y - pntEnd.y, 2));
    var distanceC = Math.sqrt(Math.pow(pntStart.x - pntEnd.x, 2) + Math.pow(pntStart.y - pntEnd.y, 2));
    var angleA = Math.acos((distanceB * distanceB + distanceC * distanceC - distanceA * distanceA) / (2 * distanceB * distanceC)) / Math.PI * 180;
    var angleB = Math.acos((distanceA * distanceA + distanceC * distanceC - distanceB * distanceB) / (2 * distanceA * distanceC)) / Math.PI * 180;
    if (angleA >= 90 || angleB >= 90) {
        return distanceA < distanceB ? distanceA : distanceB;
    }
    var pntMiddle = new SuperMap.IS.MapCoord();

    var dDaltaX = pntEnd.x - pntStart.x;
    var dDaltaY = pntStart.y - pntEnd.y;

    var dDaltaX2 = dDaltaX * dDaltaX;
    var dDaltaY2 = dDaltaY * dDaltaY;
    var dDeltaXY = dDaltaX * dDaltaY;

    var dLineSectDist = dDaltaX * dDaltaX + dDaltaY * dDaltaY;

    pntMiddle.x = (dDeltaXY * (pntStart.y - pntHitTest.y) +
                    pntStart.x * dDaltaY2 + pntHitTest.x * dDaltaX2) / dLineSectDist;

    pntMiddle.y = (dDeltaXY * (pntStart.x - pntHitTest.x) +
                    pntStart.y * dDaltaX2 + pntHitTest.y * dDaltaY2) / dLineSectDist;

    dDaltaX = pntHitTest.x - pntMiddle.x;
    dDaltaY = pntHitTest.y - pntMiddle.y;
    dist = Math.pow((dDaltaX * dDaltaX + dDaltaY * dDaltaY), 0.5);
    return dist;
}

function IsPointInPolygon(point, polygon) {
    if (polygon.feature != SuperMap.IS.FeatureType.polygon) {
        return false;
    }

    // 判断是否在bounds内部。
    var bounds = CalcBounds(polygon.points);
    if (point.x < bounds.leftBottom.x || point.x > bounds.rightTop.x || point.y < bounds.leftBottom.y || point.y > bounds.rightTop.y) {
        return false;
    }

    // 判断是否在边线上。
    // 设点为Q，线段为P1P2 ，判断点Q在该线段上的依据是：( Q - P1 ) × ( P2 - P1 ) = 0 且 Q 在以 P1，P2为对角顶点的矩形内。前者保证Q点在直线P1P2上，后者是保证Q点不在线段P1P2的延长线或反向延长线上
    var start = 0;
    var p1;
    var p2;
    var isInLine = false;
    for (var i = 0; i < polygon.parts.length; i++) {
        for (var j = 0; j < polygon.parts[i]; j++) {
            p1 = polygon.points[start + j];
            if (j == polygon.parts[i] - 1) {
                p2 = polygon.points[start];
            }
            else {
                p2 = polygon.points[start + j + 1];
            }

            if (p1.x == p2.x && p1.y == p2.y) {
                continue;
            }

            var cross = (point.x - p1.x) * (p2.y - p1.y) - (point.y - p1.y) * (p2.x - p1.x);
            if (cross == 0) {
                if (point.x <= Math.max(p1.x, p2.x) && point.x >= Math.min(p1.x, p2.x)
                    && point.y <= Math.max(p1.y, p2.y) && point.y >= Math.min(p1.y, p2.y)) {
                    isInLine = true;
                    break;
                }
            }
        }

        if (isInLine) {
            break;
        }

        start += polygon.parts[i];
    }

    if (isInLine) {
        return true;
    }

    start = 0;
    var oddNODES = false;
    for (var p = 0; p < polygon.parts.length; p++) {
        var polySides = polygon.parts[p];
        var polyX = new Array(polySides);
        var polyY = new Array(polySides);
        var x = point.x;
        var y = point.y;
        var j = 0;

        for (var i = 0; i < polySides; i++) {
            polyX[i] = polygon.points[start + i].x;
            polyY[i] = polygon.points[start + i].y;
        }

        for (var i = 0; i < polySides; i++) {
            j++;
            if (j == polySides) {
                j = 0;
            }
            if ((polyY[i] < y && polyY[j] >= y) || (polyY[j] < y && polyY[i] >= y)) {
                if (polyX[i] + (y - polyY[i]) / (polyY[j] - polyY[i]) * (polyX[j] - polyX[i]) < x) {
                    oddNODES = !oddNODES;
                }
            }
        }

        // 已经在某一部分的内部，所以不需要继续判断。
        if (oddNODES) {
            return oddNODES;
        }
        start += polySides;
    }
    return oddNODES;
};

function CalcBounds(points) {
    if (points == null) {
        return null;
    }

    var maxX, minX, maxY, minY;
    maxX = minX = maxY = minY = 0;

    var bounds = new SuperMap.IS.MapRect();

    for (var i = 1; i < points.length; i++) {
        if (points[i] == null) {
            continue;
        }
        if (points[i].x < points[minX].x) {
            minX = i;
        }
        else if (points[i].x > points[maxX].x) {
            maxX = i;
        }
        if (points[i].y < points[minY].y) {
            minY = i;
        }
        else if (points[i].y > points[maxY].y) {
            maxY = i;
        }
    }
    bounds.leftBottom.x = points[minX].x;
    bounds.leftBottom.y = points[minY].y;
    bounds.rightTop.x = points[maxX].x;
    bounds.rightTop.y = points[maxY].y;
    return bounds;
};

SuperMap.IS.RequestManager = function(url, onComplete, onError, userContext) {
    var sender = null;
    url = _GetCurrentHandler(url);
    if (_IsInCurrentDomain(url)) {
        sender = new SuperMap.IS.XHRSender(url, onComplete, onError, userContext);
    } else {
        sender = new SuperMap.IS.JSONPSender(url, onComplete, onError, userContext);
    }

    function _AddQueryString(key, value) {
        sender.AddQueryString(key, value);
    };

    function _AddQueryStrings(keys, values) {
        sender.AddQueryStrings(keys, values);
    };
    function _Send() {
        //发送请求前判断，若用户需要发送自定义参数，则调用用户自定义函数
        if (this.AddHandlerSecurityQueryString) {
            var handlerSecurityInfo = this.AddHandlerSecurityQueryString();
            sender.AddQueryString("handlerSecurity", handlerSecurityInfo);
        }
        sender.Send();
    };
    function _SetTimeout(timeout) {
        sender.SetTimeout(timeout);
    };
    function _Destroy() {
        sender.Destroy();
    };
    this.Send = _Send;
    this.AddQueryString = _AddQueryString;
    this.AddQueryStrings = _AddQueryStrings;
    this.SetTimeout = _SetTimeout;
    this.Destroy = _Destroy;
};

SuperMap.IS.XHRSender = function(url, onComplete, onError, userContext) {
    var _url = url;
    var _queryKeys = null;
    var _queryValues = null;
    var _timeout = 0;
    var _timeoutTimer = null;
    var _requestDone = 0;

    function _AddQueryString(key, value) {
        if (_queryKeys == null) {
            _queryKeys = new Array();
        }
        if (_queryValues == null) {
            _queryValues = new Array();
        }
        _queryKeys.push(key);
        _queryValues.push(encodeURIComponent(value));
    };

    function _AddQueryStrings(keys, values) {
        if (!keys || keys.length <= 0) { return; }
        if (!values || values.length <= 0) { return; }
        if (keys.length != values.length) { return; }
        if (_queryKeys == null) {
            _queryKeys = new Array();
        }
        if (_queryValues == null) {
            _queryValues = new Array();
        }
        for (var i = 0; i < keys.length; i++) {
            _queryKeys.push(keys[i]);
            _queryValues.push(_ToJSON(values[i], true));
        }
    };

    function _Send() {
        var url = _url;
        if (url.indexOf("?") > -1) {
            url += "&";
        } else {
            url += "?";
        }
        url += "t=" + new Date().getTime(); //防止caching
        var xhr = _GetXmlHttpRequest();
        function _TimeoutHandler() {
            if (!_requestDone) {
                _requestDone = 1;
                clearTimeout(_timeoutTimer);
                xhr.onreadystatechange = function() { };
                xhr.abort();
                if (onError) {
                    var timeoutMessage = "Request timed out";
                    //var timeoutMessage = "XMLHttpRequest:Request timed out.(" + _timeout + "s)";
                    onError(timeoutMessage, userContext);
                }
            }
        }
        xhr.open("post", url, true);
        xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        xhr.onreadystatechange = function() {
            var readyState = xhr.readyState;
            if (readyState == 4) {
                _requestDone = 1;
                var status = xhr.status;
                if (status == 200) {
                    var tempObject = null;
                    if (xhr.responseText != "") {
                        try {
                            tempObject = eval('(' + xhr.responseText + ')');
                        } catch (ex) {
                            tempObject = xhr.responseText;
                        }
                    } else {
                        tempObject = eval(xhr.responseText);
                    }
                    if (tempObject && tempObject.error != null) {
                        if (onError) {
                            onError(tempObject.error, userContext);
                        }
                        xhr.onreadystatechange = function() { };
                        xhr = null;
                        return;
                    }
                    if (onComplete) {
                        onComplete(xhr.responseText, userContext);
                    }
                } else {
                    if (onError) {
                        onError(xhr.responseText, userContext);
                    }
                }
                xhr.onreadystatechange = function() { };
                xhr = null;
            }
        }
        var paramString = null;
        if (_queryKeys && _queryKeys.length > 0) {
            for (var i = 0; i < _queryKeys.length; i++) {
                if (i == 0) {
                    paramString = _queryKeys[i] + "=" + _queryValues[i];
                } else {
                    paramString += "&" + _queryKeys[i] + "=" + _queryValues[i];
                }
            }
        }
        if (_timeout > 0) {
            _timeoutTimer = setTimeout(function() { !_requestDone && _TimeoutHandler(); }, _timeout);
        }
        xhr.send(paramString);
    };

    function _SetTimeout(timeout) {
        _timeout = timeout;
    }

    function _Destroy() {
        if (_queryKeys != null) {
            while (_queryKeys.length > 0) {
                _queryKeys.pop();
            }
            _queryKeys = null;
        }
        if (_queryValues != null) {
            while (_queryValues.length > 0) {
                _queryValues.pop();
            }
            _queryValues = null;
        }
    };
    this.Send = _Send;
    this.AddQueryString = _AddQueryString;
    this.AddQueryStrings = _AddQueryStrings;
    this.SetTimeout = _SetTimeout;
    this.Destroy = _Destroy;
};

var supermap_callbacks = {};
SuperMap.IS.JSONPSender = function(url, onComplete, onError, userContext) {
    var _url = url;
    var _queryKeys = null;
    var _queryValues = null;
    var _splitQuestUrl = null;
    var _uid = null;
    var _limitLength = 1720; //ie:2048,firefox:16000,opera:16000
    var _timeout = 0;
    var _timeoutTimer = null;
    var _requestDone = 0;
    if (navigator.userAgent.indexOf("IE") < 0) {
        //_limitLength = 15900;//iis6
        _limitLength = 1500; //iis7
    }

    function _AddQueryString(key, value) {
        if (_queryKeys == null) {
            _queryKeys = new Array();
        }
        if (_queryValues == null) {
            _queryValues = new Array();
        }
        _queryKeys.push(key);
        //_queryValues.push(escape(value)); //escape时对汉字的处理与encodeURIComponent不一致,方便分割时对‘%’的判断
        _queryValues.push(encodeURIComponent(value)); //使用encodeURIComponent对 “+” 进行处理
    };
    function _AddQueryStrings(keys, values) {
        if (!keys || keys.length <= 0) { return; }
        if (!values || values.length <= 0) { return; }
        if (keys.length != values.length) { return; }
        if (_queryKeys == null) {
            _queryKeys = new Array();
        }
        if (_queryValues == null) {
            _queryValues = new Array();
        }
        for (var i = 0; i < keys.length; i++) {
            _queryKeys.push(keys[i]);
            _queryValues.push(_ToJSON(values[i], true));
        }
    };
    function errorFunction(errorMessage) {
        clearTimeout(_timeoutTimer);
        _requestDone = 1;
        delete supermap_callbacks[_uid];
        for (var i = 0; ; i++) {
            var scriptNode = document.getElementById("_ss_" + _uid + "_" + i);
            if (!scriptNode) { break; }
            _RemoveElement(scriptNode);
            delete scriptNode;
            scriptNode = null;
        }
        if (onError) {
            onError(errorMessage, userContext);
        }
    }
    function _Send() {
        if (_url.length > _limitLength) { return false; }
        var curTime = new Date().getTime();
        //只用时间还不保险,Demo切换地图时就有可能_uid相同,再加上一个4位数的随机码
        var randomNum = Math.floor(Math.random() * 10000);
        _uid = curTime * 10000 + randomNum;
        supermap_callbacks[_uid] = function(json) {
            _requestDone = 1;
            delete supermap_callbacks[_uid];
            for (var i = 0; ; i++) {
                var scriptNode = document.getElementById("_ss_" + _uid + "_" + i);
                if (!scriptNode) { break; }
                _RemoveElement(scriptNode);
                delete scriptNode;
                scriptNode = null;
            }
            var tempObject = null;
            if (json != "") {
                try {
                    tempObject = eval('(' + json + ')');
                } catch (ex) {
                    tempObject = json;
                }
            } else {
                tempObject = eval(json);
            }
            if (tempObject && tempObject.error != null) {
                if (onError) {
                    onError(tempObject.error, userContext);
                }
                return;
            }
            if (onComplete) {
                onComplete(json, userContext);
            }
        };
        _AddQueryString("jsonp", "supermap_callbacks[" + _uid + "]");
        var url = _url;
        //此次url中有多少个key
        var keysCount = 0;
        if (_queryKeys && _queryKeys.length > 0) {
            for (var i = 0; i < _queryKeys.length; i++) {
                if (url.length + _queryKeys[i].length + 2 >= _limitLength)//+2 for ("&"or"?")and"="
                {
                    if (keysCount == 0) { return false; }
                    if (_splitQuestUrl == null) {
                        _splitQuestUrl = new Array();
                    }
                    _splitQuestUrl.push(url);
                    url = _url;
                    keysCount = 0;
                    i--;
                } else {
                    if (url.length + _queryKeys[i].length + 2 + _queryValues[i].length > _limitLength) {
                        var leftValue = _queryValues[i];
                        while (leftValue.length > 0) {
                            var leftLength = _limitLength - url.length - _queryKeys[i].length - 2; //+2 for ("&"or"?")and"="
                            if (url.indexOf("?") > -1) {
                                url += "&";
                            } else {
                                url += "?";
                            }
                            //对leftLength进行微调，不要把编码后的东东分开，e.g：%5D不能被分为%5 和 D
                            var temp = leftValue.substring(0, leftLength);
                            var lastIndex = temp.lastIndexOf('%');
                            if (leftLength >= 5 && leftLength - lastIndex <= 5) {
                                leftLength = lastIndex;
                            }
                            url += _queryKeys[i] + "=" + leftValue.substring(0, leftLength);
                            leftValue = leftValue.substring(leftLength);
                            if (leftValue.length > 0) {
                                if (_splitQuestUrl == null) {
                                    _splitQuestUrl = new Array();
                                }
                                _splitQuestUrl.push(url);
                                url = _url;
                                keysCount = 0;
                            }
                        }
                    } else {
                        keysCount++;
                        if (url.indexOf("?") > -1) {
                            url += "&";
                        } else {
                            url += "?";
                        }
                        url += _queryKeys[i] + "=" + _queryValues[i];
                    }
                }
            }
            if (_splitQuestUrl == null) {
                _splitQuestUrl = new Array();
            }
            _splitQuestUrl.push(url);
        }
        return _SendInternal();
    };
    function _SendInternal() {
        if (!_splitQuestUrl || _splitQuestUrl.length <= 0) { return false; }
        for (var i = 0; i < _splitQuestUrl.length; i++) {
            var url = _splitQuestUrl[i];
            if (url.indexOf("?") > -1) {
                url += "&";
            } else {
                url += "?";
            }
            url += "sectionCount=" + _splitQuestUrl.length;
            url += "&sectionIndex=" + i;
            url += "&jsonpUserID=" + _uid;
            url += "&t=" + new Date().getTime(); //防止caching
            var script = document.createElement("script");
            script.setAttribute("src", url);
            script.setAttribute("type", "text/javascript");
            script.setAttribute("id", "_ss_" + _uid + "_" + i);
            document.body.appendChild(script);
        }
        if (_timeout > 0) {
            var timeoutMessage = "Request timed out";
            //var timeoutMessage = "JSONP:Request timed out.(" + _timeout + "s)";
            _timeoutTimer = setTimeout(function() { !_requestDone && errorFunction(timeoutMessage); }, _timeout);
        }
        return true;
    };

    function _SetTimeout(timeout) {
        _timeout = timeout;
    }

    function _Destroy() {
        if (_queryKeys != null) {
            while (_queryKeys.length > 0) {
                _queryKeys.pop();
            }
            _queryKeys = null;
        }
        if (_queryValues != null) {
            while (_queryValues.length > 0) {
                _queryValues.pop();
            }
            _queryValues = null;
        }
        if (_splitQuestUrl != null) {
            while (_splitQuestUrl.length > 0) {
                _splitQuestUrl.pop();
            }
            _splitQuestUrl = null;
        }
    };
    this.Send = _Send;
    this.AddQueryString = _AddQueryString;
    this.AddQueryStrings = _AddQueryStrings;
    this.SetTimeout = _SetTimeout;
    this.Destroy = _Destroy;
};

//多域名时，当前域名索引
var domainIndex = 0;
//获取当前Handler
function _GetCurrentHandler(handler) {
    var domains = new Array();
    var count = 1;
    if (handler.indexOf('{') != -1) {
        var temp = handler.split('{');
        var parts = new Array();
        parts[0] = temp[0];
        temp = temp[1].split('}');
        parts[1] = temp[0];
        parts[2] = temp[1];
        domains = parts[1].split(',');
        count = domains.length;
        if (domainIndex >= count) { domainIndex = 0; }
        var currentHandler = handler.toString().replace("{" + parts[1] + "}", domains[domainIndex]);
        domainIndex++;
        return currentHandler;
    } else {
        return handler;
    }
}

function _RemoveElement(element) {
    if (!element || !element.parentNode) { return false; }
    element.parentNode.removeChild(element);
    return true;
}

//Jquery confict handing
function _GetDomElement(domElement) {
    if (domElement.jquery != null) {
        if (domElement[0] != null) {
            domElement = domElement[0];
        }
        else {
            domElement = document.getElementById(domElement.selector);
        }
    }
    return domElement;
}

function _ApplyTransform(div,transform) {
	var style = div.style;
	style['-webkit-transform'] = transform;
	style['-moz-transform'] = transform;
}

function _isMobile() {
	var ua = navigator.userAgent.toLowerCase();
	if (ua.indexOf('midp') != -1 || ua.indexOf('mobile') != -1 || ua.indexOf('android') != -1) return true;
	else return false;
}

//from yui_2.6.0 dom.js, Gets the current position of an element based on page coordinates
function _GetOffset(el) {
    var propertyCache = {};
    // regex cache
    var patterns = {
        ROOT_TAG: /^body|html$/i // body for quirks mode, html for standards,
    };
    function getDocumentScrollLeft(doc) {
        doc = doc || document;
        return Math.max(doc.documentElement.scrollLeft, doc.body.scrollLeft);
    }
    function getDocumentScrollTop(doc) {
        doc = doc || document;
        return Math.max(doc.documentElement.scrollTop, doc.body.scrollTop);
    }

    if (document.documentElement.getBoundingClientRect) { // IE
        var box = el.getBoundingClientRect(), round = Math.round;
        var rootNode = el.ownerDocument;
        return pos = { left: round(box.left + getDocumentScrollLeft(rootNode)), top: round(box.top +
                        getDocumentScrollTop(rootNode))
        };
    } else {
        var pos = { left: el.offsetLeft, top: el.offsetTop };
        var parentNode = el.offsetParent;
        // safari: subtract body offsets if el is abs (or any offsetParent), unless body is offsetParent
        var accountForBody = (_ygPos.browser == "safari" && el.offsetParent && el.style.position == "absolute" &&
                        el.offsetParent == el.ownerDocument.body);

        while (parentNode && parentNode != el) {
            if (parentNode.style.position != "static") {
                pos.left += parentNode.clientLeft;
                pos.top += parentNode.clientTop;
            }
            pos.left += parentNode.offsetLeft;
            pos.top += parentNode.offsetTop;
            if (!accountForBody && _ygPos.browser == "safari" && (parentNode.style.position == "absolute" || parentNode.style.position == "relative")) {
                accountForBody = true;
            }
            parentNode = parentNode.offsetParent;
        }

        if (accountForBody) { //safari doubles in this case
            pos.left -= el.ownerDocument.body.offsetLeft;
            pos.top -= el.ownerDocument.body.offsetTop;
        }
        parentNode = el.parentNode;

        // account for any scrolled ancestors
        while (parentNode && parentNode.tagName && !patterns.ROOT_TAG.test(parentNode.tagName)) {
            if (parentNode.scrollTop || parentNode.scrollLeft) {
                pos.left -= parentNode.scrollLeft;
                pos.top -= parentNode.scrollTop;
            }

            parentNode = parentNode.parentNode;
        }

        return pos;
    };
}