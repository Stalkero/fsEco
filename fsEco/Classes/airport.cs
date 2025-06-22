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
        public double elevation_ft { get; set; }
        public string continent { get; set; }
        public string iso_country { get; set; }
        public string iso_region { get; set; }
        public string municipality { get; set; }
        public bool scheduled_service { get; set; }
        public string icao_code { get; set; }
        public string iata_code { get; set; }
        public string gps_code { get; set; }
        public string local_code { get; set; }
        public string home_link { get; set; }
        public string wikipedia_link { get; set; }
        public string keywords { get; set; }
        public string frequency { get; set; }

    }
}
