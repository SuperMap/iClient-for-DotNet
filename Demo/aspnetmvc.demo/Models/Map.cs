using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperMap.Connector.Utility;

namespace aspnetmvc.demo.Models
{
    public class MapModel
    {
        public MapImage MapImage { get; set; }

        public QueryResult QueryResult { get; set; }
    }
}