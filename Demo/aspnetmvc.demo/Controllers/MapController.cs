using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperMap.Connector;
using SuperMap.Connector.Utility;

namespace aspnetmvc.demo.Controllers
{
    public class MapController : Controller
    {
        Map map = new Map("http://localhost:8090/iserver/services/map-world/rest");
        string mapName = "世界地图";

        //public ActionResult Map()
        //{
        //    return View();
        //}

        public ActionResult Map(string actionName)
        {
            ImageOutputOption imageOutputOption = new ImageOutputOption();
            imageOutputOption.ImageOutputFormat = ImageOutputFormat.PNG;
            imageOutputOption.ImageReturnType = ImageReturnType.URL;

            MapParameter currentMapParameter = Session["MapParameter"] as MapParameter;
            string url = string.Empty;
            if (currentMapParameter == null)
            {
                MapParameter defaultMapParameter = map.GetDefaultMapParameter(mapName);
                currentMapParameter = new MapParameter();
                currentMapParameter.Scale = defaultMapParameter.Scale;
                currentMapParameter.Center = new Point2D(defaultMapParameter.Center);
                currentMapParameter.ViewBounds = new Rectangle2D(defaultMapParameter.ViewBounds);
                currentMapParameter.RectifyType = RectifyType.BYCENTERANDMAPSCALE;
                currentMapParameter.Name = defaultMapParameter.Name;
                currentMapParameter.Viewer = new Rectangle(0, 0, 800, 600);
            }
            if (string.IsNullOrWhiteSpace(actionName))
            {
                
            }
            else if ("ZoomIn" == actionName)
            {
                currentMapParameter.Scale = currentMapParameter.Scale * 2;
            }
            else if ("ZoomOut" == actionName)
            {
                currentMapParameter.Scale = currentMapParameter.Scale / 2;
            }
            else if ("LeftPan" == actionName)
            {
                currentMapParameter.Center.X = currentMapParameter.Center.X - ((currentMapParameter.ViewBounds.RightTop.X - currentMapParameter.ViewBounds.LeftBottom.X) / 4);
            }
            else if ("RightPan" == actionName)
            {
                currentMapParameter.Center.X = currentMapParameter.Center.X + ((currentMapParameter.ViewBounds.RightTop.X - currentMapParameter.ViewBounds.LeftBottom.X) / 4);
            }
            else if ("DownPan" == actionName)
            {
                currentMapParameter.Center.Y = currentMapParameter.Center.Y - ((currentMapParameter.ViewBounds.RightTop.Y - currentMapParameter.ViewBounds.LeftBottom.Y) / 4);
            }
            else if ("UpPan" == actionName)
            {
                currentMapParameter.Center.Y = currentMapParameter.Center.Y + ((currentMapParameter.ViewBounds.RightTop.Y - currentMapParameter.ViewBounds.LeftBottom.Y) / 4);
            }
            else if ("" == actionName)
            { 
                
            }
            MapImage image = map.GetMapImage(mapName, currentMapParameter, imageOutputOption);
            if (image != null && image.MapParameter != null && image.MapParameter.ViewBounds != null)
            {
                currentMapParameter.ViewBounds = new Rectangle2D(image.MapParameter.ViewBounds);
            }
            url = image.ImageUrl;
            Session["MapParameter"] = currentMapParameter;
            ViewBag.url = url;
            return View();
        }
    }
}
