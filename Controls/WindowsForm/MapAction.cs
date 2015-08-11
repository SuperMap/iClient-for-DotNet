using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperMap.Connector.Control.Utility;

namespace SuperMap.Connector.Control.Forms
{
    /// <summary>
    /// 地图操作的抽象类，包含常用的鼠标及键盘事件的响应方法。
    /// </summary>
    public abstract class MapAction : IAction
    {
        private MapControl _map;
        /// <summary>
        /// 需要操作的地图控件。
        /// </summary>
        protected MapControl Map
        {
            get { return _map; }
            set { _map = value; }
        }

        #region IAction 成员

        private string _actionName;
        /// <summary>
        /// 操作名称。
        /// </summary>
        public string ActionName
        {
            get { return _actionName; }
            set { _actionName = value; }
        }

        private string _actionDescription;
        /// <summary>
        /// 操作描述。
        /// </summary>
        public string ActionDescription
        {
            get { return _actionDescription; }
            set { _actionDescription = value; }
        }

        /// <summary>
        /// 加载地图控件。
        /// </summary>
        /// <param name="mapControl">需要操作的地图控件</param>
        public virtual void OnLoad(MapControl mapControl)
        {
            Map = mapControl;
            Map.MouseClick += new System.Windows.Forms.MouseEventHandler(Map_MouseClick);
            Map.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(Map_MouseDoubleClick);
            Map.MouseDown += new System.Windows.Forms.MouseEventHandler(Map_MouseDown);
            Map.MouseEnter += new EventHandler(Map_MouseEnter);
            Map.MouseLeave += new EventHandler(Map_MouseLeave);
            Map.MouseMove += new System.Windows.Forms.MouseEventHandler(Map_MouseMove);
            Map.MouseUp += new System.Windows.Forms.MouseEventHandler(Map_MouseUp);
            Map.MouseWheel += new System.Windows.Forms.MouseEventHandler(Map_MouseWheel);
            Map.KeyDown += new System.Windows.Forms.KeyEventHandler(Map_KeyDown);
            Map.KeyUp += new System.Windows.Forms.KeyEventHandler(Map_KeyUp);
        }

        #endregion

        #region 响应鼠标事件的方法

        void Map_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            MouseWheel(e);
        }

        /// <summary>
        /// 每当鼠标滚轮滚动后，都将调用此方法。
        /// </summary>
        /// <param name="e">包含事件数据的MouseEventArgs</param>
        protected virtual void MouseWheel(System.Windows.Forms.MouseEventArgs e)
        {

        }

        void Map_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            MouseUp(e);
        }

        /// <summary>
        /// 每当鼠标按键放开后，都将调用此方法。
        /// </summary>
        /// <param name="e">包含事件数据的MouseEventArgs</param>
        protected virtual void MouseUp(System.Windows.Forms.MouseEventArgs e)
        {

        }
        
        void Map_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            MouseMove(e);
        }

        /// <summary>
        /// 每当鼠标移动后，都将调用此方法。
        /// </summary>
        /// <param name="e">包含事件数据的MouseEventArgs</param>
        protected virtual void MouseMove(System.Windows.Forms.MouseEventArgs e)
        {

        }

        void Map_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave(e);
        }

        /// <summary>
        /// 每当鼠标离开后，都将调用此方法。
        /// </summary>
        /// <param name="e">包含事件数据的EventArgs</param>
        protected virtual void MouseLeave(EventArgs e)
        {

        }

        void Map_MouseEnter(object sender, EventArgs e)
        {
            MouseEnter(e);
        }

        /// <summary>
        /// 每当鼠标进入控件后，都将调用此方法。
        /// </summary>
        /// <param name="e">包含事件数据的EventArgs</param>
        protected virtual void MouseEnter(EventArgs e)
        {

        }

        void Map_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            MouseDown(e);
        }

        /// <summary>
        /// 每当鼠标键按下后，都将调用此方法。
        /// </summary>
        /// <param name="e">包含事件数据的MouseEventArgs</param>
        protected virtual void MouseDown(System.Windows.Forms.MouseEventArgs e)
        {

        }

        void Map_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            MouseDoubleClick(e);
        }

        /// <summary>
        /// 每当鼠标双击后，都将调用此方法。
        /// </summary>
        /// <param name="e">包含事件数据的MouseEventArgs</param>
        protected virtual void MouseDoubleClick(System.Windows.Forms.MouseEventArgs e)
        {

        }

        void Map_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            MouseClick(e);
        }

        /// <summary>
        /// 每当鼠标单击后，都将调用此方法。
        /// </summary>
        /// <param name="e">包含事件数据的MouseEventArgs</param>
        protected virtual void MouseClick(System.Windows.Forms.MouseEventArgs e)
        {

        }

        void Map_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            KeyUp(e);
        }

        /// <summary>
        /// 每当键盘按键放开后，都将调用此方法。
        /// </summary>
        /// <param name="e">包含事件数据的KeyEventArgs</param>
        protected virtual void KeyUp(System.Windows.Forms.KeyEventArgs e)
        {

        }

        void Map_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            KeyDown(e);
        }

        /// <summary>
        /// 每当鼠标按键按下后，都将调用此方法。
        /// </summary>
        /// <param name="e">包含事件数据的KeyEventArgs</param>
        protected virtual void KeyDown(System.Windows.Forms.KeyEventArgs e)
        {

        }

        #endregion

        #region IDisposable 成员

        /// <summary>
        /// 释放此功能所占据的资源。
        /// </summary>
        public virtual void Dispose()
        {
            if (Map != null)
            {
                Map.MouseClick -= Map_MouseClick;
                Map.MouseDoubleClick -= Map_MouseDoubleClick;
                Map.MouseDown -= Map_MouseDown;
                Map.MouseEnter -= Map_MouseEnter;
                Map.MouseLeave -= Map_MouseLeave;
                Map.MouseMove -= Map_MouseMove;
                Map.MouseUp -= Map_MouseUp;
                Map.MouseWheel -= Map_MouseWheel;
                Map.KeyDown -= Map_KeyDown;
                Map.KeyUp -= Map_KeyUp;
            }
        }

        #endregion

    }
}
