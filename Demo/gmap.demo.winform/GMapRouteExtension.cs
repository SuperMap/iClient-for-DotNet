using System;
using System.Collections.Generic;
using System.Text;
using GMap.NET.WindowsForms;
using GMap.NET;
using System.Drawing;
using System.Drawing.Drawing2D;
using GMap.NET.WindowsForms.Markers;

namespace gmap.demo.winform
{
    public class GMapRouteExtension : GMapRoute
    {
        private bool _showNode = false;
        public bool ShowNode
        {
            get { return _showNode; }
        }

        public List<PointLatLng> GPoints
        {
            get { return this.Points; }
            set
            {
                this.Points.Clear();
                if (value != null)
                {
                    this.Points.AddRange(value);
                }
            }
        }

        public GMapRouteExtension(List<PointLatLng> points, string name)
            : base(points, name)
        {

        }

        public GMapRouteExtension(string name, List<PointLatLng> points, Color strokeColor, float strokeWidth, bool showNode)
            : base(points, name)
        {
            this.Stroke = new Pen(strokeColor);
            this.Stroke.LineJoin = LineJoin.Bevel;
            this.Stroke.Width = strokeWidth;
            this._showNode = showNode;
        }

        public override void OnRender(System.Drawing.Graphics g)
        {
            if (IsVisible)
            {
                List<Point> points = new List<Point>();
                using (GraphicsPath rp = new GraphicsPath())
                {
                    for (int i = 0; i < LocalPoints.Count; i++)
                    {
                        GPoint p2 = LocalPoints[i];

                        points.Add(new Point(LocalPoints[i].X, LocalPoints[i].Y));
                        if (i == 0)
                        {
                            rp.AddLine(p2.X, p2.Y, p2.X, p2.Y);
                        }
                        else
                        {
                            System.Drawing.PointF p = rp.GetLastPoint();
                            rp.AddLine(p.X, p.Y, p2.X, p2.Y);
                        }
                        Pen pen = new Pen(Color.FromArgb(100, 255, 0, 0));
                        pen.Width = 1.5F;
                        if (_showNode)
                            g.DrawArc(pen, (float)LocalPoints[i].X - 3, (float)LocalPoints[i].Y - 3, 6, 6, (float)360, (float)360);
                    }

                    if (rp.PointCount > 0)
                    {
                        g.DrawPath(Stroke, rp);
                    }
                }
            }
        }
    }

    public class GMapPolygonExtension : GMapPolygon
    {
        private new SolidBrush Fill
        {
            get;
            set;
        }

        private new Pen Stroke
        {
            get;
            set;
        }

        private float _strokeWidth = 1;
        public float StrokeWidth
        {
            get { return _strokeWidth; }
            set
            {
                if (this.Stroke == null) this.Stroke = new Pen(Color.FromArgb(125, 255, 0, 0));
                this._strokeWidth = value;
                this.Stroke.Width = value;
            }
        }

        private Color _strokeColor = Color.FromArgb(124, 255, 0, 0);
        public Color StrokeColor
        {
            get { return _strokeColor; }
            set
            {
                if (this.Stroke == null) this.Stroke = new Pen(Color.FromArgb(125, 255, 0, 0));
                this._strokeColor = value;
                this.Stroke.Color = value;
            }
        }

        private Color _fillColor = Color.FromArgb(124, 255, 0, 0);
        public Color FillColor
        {
            get { return this._fillColor; }
            set
            {
                if (this.Fill == null) this.Fill = new SolidBrush(Color.FromArgb(125, 255, 0, 0));
                this._fillColor = value;
                this.Fill.Color = FillColor;
            }
        }

        public GMapPolygonExtension(string name, List<PointLatLng> points, float strokeWidth, Color strokeColor, Color fillColor)
            : base(points, name)
        {
            this.Fill = new SolidBrush(fillColor);
            this.Stroke = new Pen(strokeColor);
            this.Stroke.Width = strokeWidth;

            this.Stroke.LineJoin = LineJoin.Bevel;

            this.StrokeColor = strokeColor;
            this.FillColor = fillColor;
            this.StrokeWidth = strokeWidth;
        }

        public override void OnRender(Graphics g)
        {
            if (IsVisible)
            {
                using (GraphicsPath rp = new GraphicsPath())
                {
                    for (int i = 0; i < LocalPoints.Count; i++)
                    {
                        GPoint p2 = LocalPoints[i];

                        if (i == 0)
                        {
                            rp.AddLine(p2.X, p2.Y, p2.X, p2.Y);
                        }
                        else
                        {
                            System.Drawing.PointF p = rp.GetLastPoint();
                            rp.AddLine(p.X, p.Y, p2.X, p2.Y);
                        }
                    }

                    if (rp.PointCount > 0)
                    {
                        rp.CloseFigure();
                        g.FillPath(Fill, rp);
                        g.DrawPath(Stroke, rp);
                    }
                }
            }
        }
    }

    public class GMapMarkerExtension : GMapMarker
    {
        public GMapMarkerExtension(PointLatLng p)
            : base(p)
        { 
            
        }

        public override void OnRender(Graphics g)
        {
            base.OnRender(g);
        }
    }

    public class GMapToolTipExtension : GMapToolTip
    {
        public GMapToolTipExtension(GMapMarker marker)
            : base(marker)
        { 
            
        }

        public override void Draw(Graphics g)
        {
            base.Draw(g);
        }
    }
}
