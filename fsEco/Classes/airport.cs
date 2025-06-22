using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fsEco.Classes
{
    public class airport
    {
        public string id { get; set; }
        public string ident { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public double latitude_deg { get; set; }
        public double longitude_deg { get; set; }
        public double? elevation_ft { get; set; }
        public string continent { get; set; }
        public string iso_country { get; set; }
        public string iso_region { get; set; }
        public string municipality { get; set; }
        public string keywords { get; set; }

    }
}
