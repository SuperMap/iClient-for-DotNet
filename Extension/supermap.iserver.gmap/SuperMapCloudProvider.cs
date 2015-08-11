using System;
using System.Collections.Generic;
using System.Text;
using GMap.NET.Projections;

namespace GMap.NET.MapProviders
{
    public class SuperMapCloudProvider : GMapProvider
    {
        public static readonly SuperMapCloudProvider Instance;

        SuperMapCloudProvider()
        {
            Copyright = string.Format("© SuperMapCloud - Map data ©{0} SuperMapCloud", DateTime.Today.Year);
        }

        static SuperMapCloudProvider()
        {
            Instance = new SuperMapCloudProvider();
        }

        private Guid _id = new Guid("0D1533B9-10B3-4685-9A4F-01D6B6309847");
        public override Guid Id
        {
            get { return _id; }
        }

        public override string Name
        {
            get { return "SuperMapCloud"; }
        }

        public override PureProjection Projection
        {
            get { return MercatorProjection.Instance; }
        }

        GMapProvider[] overlays;
        public override GMapProvider[] Overlays
        {
            get
            {
                if (overlays == null)
                {
                    overlays = new GMapProvider[] { this };
                }
                return overlays;
            }
        }

        private int[] _scales
        {
            get
            {
                int[] scales = new int[18];
                scales[0] = 470000000;
                for (int i = 1; i < 18; i++)
                {
                    scales[i] = scales[i - 1] / 2;
                }
                return scales;
            }
        }
        //http://t0.supermapcloud.com/output/cache/quanguo_256x256/114746/3370/1551.png
        //http://t0.supermapcloud.com/output/cache/quanguo_256x256/470000000/0/0.png
        //http://t0.supermapcloud.com/output/cache/quanguo_256x256/235000000/0/1.png
        public override PureImage GetTileImage(GPoint pos, int zoom)
        {
            string url = string.Format("http://www.supermapcloud.com/output/cache/quanguo_256x256/{0}/{1}/{2}.png",
                _scales[zoom], pos.X, pos.Y);
            return GetTileImageUsingHttp(url);
        }
    }
}
