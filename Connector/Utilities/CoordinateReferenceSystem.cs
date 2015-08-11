using System;

namespace SuperMap.Connector.Utility
{
    public class CoordinateReferenceSystem
    {
        public CoordinateReferenceSystem()
            : this(0)
        {
        }

        public CoordinateReferenceSystem(int wkid)
            : this(wkid, Unit.UNDEFINED)
        {
        }
        

        public CoordinateReferenceSystem(int wkid, Unit unit)
        {
            WKID = wkid;
            Unit = unit;
        }

        public CoordinateReferenceSystem Clone()
        {
            CoordinateReferenceSystem reference = base.MemberwiseClone() as CoordinateReferenceSystem;
            reference.WKID = WKID;
            reference.Unit = Unit;
            return reference;
        }

        public static bool Equals(CoordinateReferenceSystem crs1, CoordinateReferenceSystem crs2, bool ignoreNull)
        {
            if (crs1 == null || crs2 == null)
            {
                return ignoreNull;
            }
            if (IsWebMercatorWKID(crs1.WKID) && IsWebMercatorWKID(crs1.WKID))
            {
                return true;
            }
            return (crs1.WKID == crs2.WKID);
        }


        private static bool IsWebMercatorWKID(int wkid)
        {
            return (wkid == 3857) || (wkid == 900913) || (wkid == 102113) || (wkid == 102100);
        }

        public bool Equals(CoordinateReferenceSystem other)
        {
            return Equals(this, other, false);
        }

        public int WKID { get; set; }
        public Unit Unit { get; set; }
    }
}
