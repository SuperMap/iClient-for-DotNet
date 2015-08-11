using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace SuperMap.Connector.Control.WPF
{
    public abstract class MapAction:IAction
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
        /// <param name="mapControl">需要操作的地图控件。</param>
        public virtual void OnLoad(MapControl mapControl)
        {
            Map = mapControl;
            Map.MouseDoubleClick += new MouseButtonEventHandler(Map_MouseDoubleClick);
            Map.MouseDown += new MouseButtonEventHandler(Map_MouseDown);
            Map.MouseEnter += new System.Windows.Input.MouseEventHandler(Map_MouseEnter);
            Map.MouseLeave += new System.Windows.Input.MouseEventHandler(Map_MouseLeave);
            Map.MouseLeftButtonDown += new MouseButtonEventHandler(Map_MouseLeftButtonDown);
            Map.MouseLeftButtonUp += new MouseButtonEventHandler(Map_MouseLeftButtonUp);
            Map.MouseMove += new MouseEventHandler(Map_MouseMove);
            Map.MouseRightButtonDown += new MouseButtonEventHandler(Map_MouseRightButtonDown);
            Map.MouseRightButtonUp += new MouseButtonEventHandler(Map_MouseRightButtonUp);
            Map.MouseUp += new MouseButtonEventHandler(Map_MouseUp);
            Map.MouseWheel += new MouseWheelEventHandler(Map_MouseWheel);
            Map.KeyDown += new System.Windows.Input.KeyEventHandler(Map_KeyDown);
            Map.KeyUp += new System.Windows.Input.KeyEventHandler(Map_KeyUp);
        }

        void Map_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            KeyUp(e);
        }

        /// <summary>
        /// 在焦点位于此元素上并且用户释放键时，都将调用此方法。
        /// </summary>
        /// <param name="e">包含事件数据的KeyEventArgs。</param>
        protected virtual void KeyUp(System.Windows.Input.KeyEventArgs e)
        {

        }

        void Map_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            KeyDown(e);
        }
        
        /// <summary>
        /// 在焦点位于此元素上并且用户按下键时，都将调用此方法。
        /// </summary>
        /// <param name="e">包含事件数据的KeyEventArgs。</param>
        protected virtual void KeyDown(System.Windows.Input.KeyEventArgs e)
        {

        }

        void Map_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            MouseWheel(e);
        }

        /// <summary>
        /// 在鼠标指针悬停于此元素上并且用户滚动鼠标滚轮时，都将调用此方法。
        /// </summary>
        /// <param name="e">包含事件数据的MapMouseWheelEventArgs。</param>
        protected virtual void MouseWheel(MouseWheelEventArgs e)
        {

        }

        void Map_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MouseUp(e);
        }

        /// <summary>
        /// 在用户在此元素上释放任意鼠标按钮时，都将调用此方法。
        /// </summary>
        /// <param name="e">包含事件数据的MapMouseButtonEventArgs。</param>
        protected virtual void MouseUp(MouseButtonEventArgs e)
        {

        }

        void Map_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            MouseRightButtonUp(e);
        }

        /// <summary>
        /// 在鼠标指针悬停于此元素上并且用户释放鼠标右键时，都将调用此方法。
        /// </summary>
        /// <param name="e">包含事件数据的MapMouseButtonEventArgs。</param>
        protected virtual void MouseRightButtonUp(MouseButtonEventArgs e)
        {

        }

        void Map_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            MouseRightButtonDown(e);
        }

        /// <summary>
        /// 在鼠标指针悬停于此元素上并且用户按下鼠标右键时，都将调用此方法。
        /// </summary>
        /// <param name="e">包含事件数据的MapMouseButtonEventArgs。</param>
        protected virtual void MouseRightButtonDown(MouseButtonEventArgs e)
        {

        }

        void Map_MouseMove(object sender, MouseEventArgs e)
        {
            MouseMove(e);
        }

        /// <summary>
        /// 在鼠标指针悬停于此元素上并且用户移动该鼠标指针时，都将调用此方法。
        /// </summary>
        /// <param name="e">包含事件数据的MapMouseEventArgs。</param>
        protected virtual void MouseMove(MouseEventArgs e)
        {

        }

        void Map_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MouseLeftButtonUp(e);
        }

        /// <summary>
        /// 在鼠标指针悬停于此元素上并且用户释放鼠标左键时，都将调用此方法。
        /// </summary>
        /// <param name="e">包含事件数据的MapMouseButtonEventArgs。</param>
        protected virtual void MouseLeftButtonUp(MouseButtonEventArgs e)
        {

        }

        void Map_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MouseLeftButtonDown(e);
        }

        /// <summary>
        /// 在鼠标指针悬停于此元素上并且用户按下鼠标左键时，都将调用此方法。
        /// </summary>
        /// <param name="e">包含事件数据的MapMouseButtonEventArgs。</param>
        protected virtual void MouseLeftButtonDown(MouseButtonEventArgs e)
        {

        }

        void Map_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            MouseLeave(e);
        }

        /// <summary>
        /// 在鼠标指针离开此元素的边界时，都将调用此方法。
        /// </summary>
        /// <param name="e">包含事件数据的MouseEventArgs。</param>
        protected virtual void MouseLeave(System.Windows.Input.MouseEventArgs e)
        {

        }

        void Map_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            MouseEnter(e);
        }

        /// <summary>
        /// 在鼠标指针离开此元素的边界时，都将调用此方法。
        /// </summary>
        /// <param name="e">包含事件数据的MouseEventArgs。</param>
        protected virtual void MouseEnter(System.Windows.Input.MouseEventArgs e)
        {

        }

        void Map_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MouseDown(e);
        }

        /// <summary>
        /// 在指针悬停于此元素上并且用户按下任意鼠标按钮时，都将调用此方法。
        /// </summary>
        /// <param name="e">包含事件数据的MapMouseButtonEventArgs。</param>
        protected virtual void MouseDown(MouseButtonEventArgs e)
        {

        }

        void Map_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MouseDoubleClick(e);
        }

        /// <summary>
        /// 当单击鼠标按钮两次或更多次时，都将调用此方法。
        /// </summary>
        /// <param name="e">包含事件数据的MapMouseButtonEventArgs。</param>
        protected virtual void MouseDoubleClick(MouseButtonEventArgs e)
        {

        }

        #endregion

        #region IDisposable 成员
        /// <summary>
        /// 释放此操作占用的资源。
        /// </summary>
        public void Dispose()
        {
            if (Map != null)
            {
                Map.MouseDoubleClick -= Map_MouseDoubleClick;
                Map.MouseDown -= Map_MouseDown;
                Map.MouseEnter -= Map_MouseEnter;
                Map.MouseLeave -= Map_MouseLeave;
                Map.MouseLeftButtonDown -= Map_MouseLeftButtonDown;
                Map.MouseLeftButtonUp -= Map_MouseLeftButtonUp;
                Map.MouseMove -= Map_MouseMove;
                Map.MouseRightButtonDown -= Map_MouseRightButtonDown;
                Map.MouseRightButtonUp -= Map_MouseRightButtonUp;
                Map.MouseUp -= Map_MouseUp;
                Map.MouseWheel -= Map_MouseWheel;
                Map.KeyDown -= Map_KeyDown;
                Map.KeyUp -= Map_KeyUp;
            }
        }

        #endregion
    }
}
