﻿
namespace GMap.NET.WindowsForms
{
   using System;
   using System.Drawing;
   using System.Drawing.Drawing2D;
   using System.Runtime.Serialization;

   /// <summary>
   /// GMap.NET marker
   /// </summary>
   [Serializable]
#if !PocketPC
   public class GMapToolTip : ISerializable, IDisposable
#else
   public class GMapToolTip: IDisposable
#endif
   {
      GMapMarker marker;
      public GMapMarker Marker
      {
         get
         {
            return marker;
         }
         internal set
         {
            marker = value;
         }
      }

      public Point Offset;

      /// <summary>
      /// string format
      /// </summary>
      [NonSerialized]
      public readonly StringFormat Format = new StringFormat();

      /// <summary>
      /// font
      /// </summary>
      [NonSerialized]
#if !PocketPC
      public Font Font = new Font(FontFamily.GenericSansSerif, 14, FontStyle.Bold, GraphicsUnit.Pixel);
#else
      public Font Font = new Font(FontFamily.GenericSansSerif, 6, FontStyle.Bold);
#endif

      /// <summary>
      /// specifies how the outline is painted
      /// </summary>
      [NonSerialized]
#if !PocketPC
      public Pen Stroke = new Pen(Color.FromArgb(140, Color.MidnightBlue));
#else
      public Pen Stroke = new Pen(Color.MidnightBlue);
#endif

      /// <summary>
      /// background color
      /// </summary>
      [NonSerialized]
#if !PocketPC
      public Brush Fill = new SolidBrush(Color.FromArgb(222, Color.AliceBlue));
#else
      public Brush Fill = new System.Drawing.SolidBrush(Color.AliceBlue);
#endif

      /// <summary>
      /// text foreground
      /// </summary>
      [NonSerialized]
      public Brush Foreground = new SolidBrush(Color.Navy);

      /// <summary>
      /// text padding
      /// </summary>
      public Size TextPadding = new Size(10, 10);

      public GMapToolTip(GMapMarker marker)
      {
         this.Marker = marker;
         this.Offset = new Point(14, -44);

         this.Stroke.Width = 2;

#if !PocketPC
         this.Stroke.LineJoin = LineJoin.Round;
         this.Stroke.StartCap = LineCap.RoundAnchor;
         this.Format.LineAlignment = StringAlignment.Center;
#endif

         this.Format.Alignment = StringAlignment.Center;
      }

      public virtual void OnRender(Graphics g)
      {
         System.Drawing.Size st = g.MeasureString(Marker.ToolTipText, Font).ToSize();
         System.Drawing.Rectangle rect = new System.Drawing.Rectangle(Marker.ToolTipPosition.X, Marker.ToolTipPosition.Y - st.Height, st.Width + TextPadding.Width, st.Height + TextPadding.Height);
         rect.Offset(Offset.X, Offset.Y);

         g.DrawLine(Stroke, Marker.ToolTipPosition.X, Marker.ToolTipPosition.Y, rect.X, rect.Y + rect.Height / 2);

         g.FillRectangle(Fill, rect);
         g.DrawRectangle(Stroke, rect);

#if PocketPC
         rect.Offset(0, (rect.Height - st.Height) / 2);
#endif

         g.DrawString(Marker.ToolTipText, Font, Foreground, rect, Format);
      }

#if !PocketPC
      #region ISerializable Members

      /// <summary>
      /// Initializes a new instance of the <see cref="GMapToolTip"/> class.
      /// </summary>
      /// <param name="info">The info.</param>
      /// <param name="context">The context.</param>
      protected GMapToolTip(SerializationInfo info, StreamingContext context)
      {
         //this.Foreground = Extensions.GetValue(info, "Foreground", new SolidBrush(Color.Navy));
         //this.Fill = Extensions.GetValue(info, "Fill", new SolidBrush(Color.FromArgb(222, Color.AliceBlue)));
         //this.Font = Extensions.GetValue(info, "Font", new Font(FontFamily.GenericSansSerif, 14, FontStyle.Bold, GraphicsUnit.Pixel));
         //this.Format = Extensions.GetValue(info, "Format", new StringFormat());
         this.Offset = Extensions.GetStruct<Point>(info, "Offset", Point.Empty);
         //this.Stroke = Extensions.GetValue(info, "Stroke", new Pen(Color.FromArgb(140, Color.MidnightBlue)));
         this.TextPadding = Extensions.GetStruct<Size>(info, "TextPadding", new Size(10, 10));
      }

      /// <summary>
      /// Populates a <see cref="T:System.Runtime.Serialization.SerializationInfo"/> with the data needed to serialize the target object.
      /// </summary>
      /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> to populate with data.</param>
      /// <param name="context">The destination (see <see cref="T:System.Runtime.Serialization.StreamingContext"/>) for this serialization.</param>
      /// <exception cref="T:System.Security.SecurityException">
      /// The caller does not have the required permission.
      /// </exception>
      public void GetObjectData(SerializationInfo info, StreamingContext context)
      {
         //info.AddValue("Fill", this.Fill);
         //info.AddValue("Foreground", this.Foreground);
         //info.AddValue("Font", this.Font);
         //info.AddValue("Format", this.Format);
         info.AddValue("Offset", this.Offset);
         //info.AddValue("Stroke", this.Stroke);
         info.AddValue("TextPadding", this.TextPadding);
      }

      #endregion
#endif

      #region IDisposable Members

      bool disposed = false;

      public void Dispose()
      {
         if(!disposed)
         {
            disposed = true;

            Format.Dispose();

            Font.Dispose();
            Font = null;

            Stroke.Dispose();
            Stroke = null;

            Fill.Dispose();
            Fill = null;

            Foreground.Dispose();
            Foreground = null;
         }
      }

      #endregion
   }
}
