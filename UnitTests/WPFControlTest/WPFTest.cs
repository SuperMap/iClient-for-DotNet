using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GMap.NET;
using SuperMap.Connector.Utility;
using SuperMap.Connector.Control.Utility;
using SuperMap.Connector.Control.WPF;

namespace MapControlTest
{
    [TestClass]
    public class WPFTest
    {
        string _url = "http://192.168.116.114:8090/iserver/services/map-world/rest";
        string _name = "世界地图";

        [TestMethod]
        public void NewMapTest1()
        {
            MapControl control = new MapControl();
            Assert.IsNotNull(control, "初始化控件失败");
            control.MapLayer = new MapByScalesLayer("1", "a", _url, _name, new double[] {1.0/40000000,1.0/20000000,1.0/10000000,1.0/5000000,1.0/2500000 });
            Assert.IsNotNull(control.Scales, "初始化比例尺失败");
            Assert.IsTrue(control.Zoom == 0, "初始缩放级别不为0");
            Assert.IsTrue(control.Center != null, "初始化中心点失败");
            Assert.IsTrue(control.Center.X == 96.1736997712 && control.Center.Y == 27.5734580668, "初始化中心点坐标不为地图默认中心点");
            Assert.IsTrue(control.Bounds != null, "地图初始化范围为空");
            Assert.IsTrue(control.Bounds.LeftBottom.X == -180 && control.Bounds.LeftBottom.Y == -90 && control.Bounds.RightTop.X == 180 && control.Bounds.RightTop.Y == 90, "初始化地图范围不正确");

            control.PropertyChanged += new MapPropertyChangedHandler(control_PropertyChanged);
            control.Zoom += 1;
        }

        void control_PropertyChanged(object sender, MapPropertyChangedEventArgs e)
        {
            Assert.IsInstanceOfType(sender, typeof(MapControl), "事件源不是MapControl");
            MapControl control = (MapControl)sender;
            Assert.IsTrue(e.NewValue != null && e.OldValue != null,"变更属性的旧值或者新值为空");

        }
    }
}
