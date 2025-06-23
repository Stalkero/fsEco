using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fsEco.Classes
{
    public class JobListing
    {
        public string FromIcao { get; set; } = string.Empty;
        public string ToIcao { get; set; } = string.Empty;

        public double Distance { get; set; }  // In nautical miles or km
        public int Pay { get; set; }          // In-game currency (e.g., dollars)
        public int CargoWeight { get; set; }  // In kilograms


        public string JobType { get; set; } = string.Empty; // e.g., "Passenger", "Cargo", "Military"
        public string cargoType { get; set; } // 0 = Generic, 1 = Passengers, 2 = Mail, 3 = Cargo

        public string? Description { get; set; }  // Optional, e.g., "Medical Supplies"
        public string? AircraftType { get; set; } // Optional aircraft requirement

        public DateTime? ExpirationTime { get; set; } // Optional
    }

}
