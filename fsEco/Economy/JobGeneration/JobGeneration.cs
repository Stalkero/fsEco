using fsEco.Classes;
using fsEco.PublicData;
using fsEco.Utils.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static fsEco.Utils.Windows.ErrorWindow;

namespace fsEco.Economy.JobGeneration
{
    public class JobGeneration
    {
        public void generateOneJob(string depICAO, double minDistance, double maxDistance, double minPay, double minCargoWeight, double maxCargoWeight)
        {

            int attempts = 2000;

            var from = AirportsDatabase.Airports.FirstOrDefault(a => a.ident == depICAO);
            if (from == null) return;

            var rng = new Random();


            for (int i = 0; i < attempts; i++)
            {
                var to = AirportsDatabase.Airports[rng.Next(AirportsDatabase.Airports.Count)];

                if (to.ident == depICAO) continue;

                double dist = Haversine(from.latitude_deg, from.longitude_deg, to.latitude_deg, to.longitude_deg);

                if (dist >= minDistance && dist <= maxDistance)
                {
                    JobsDatabase.Jobs.Add(new Job
                    {
                        FromIcao = from.ident,
                        ToIcao = to.ident,
                        Distance = dist,
                        Pay = rng.Next((int)minPay, (int)(minPay * 1.5)),
                        CargoWeight = rng.Next((int)minCargoWeight, (int)maxCargoWeight),
                    });
                }
            }

        }

        private double Haversine(double lat1, double lon1, double lat2, double lon2)
        {
            double R = 6371; // km
            var dLat = DegreesToRadians(lat2 - lat1);
            var dLon = DegreesToRadians(lon2 - lon1);

            var a = Math.Pow(Math.Sin(dLat / 2), 2) +
                    Math.Cos(DegreesToRadians(lat1)) * Math.Cos(DegreesToRadians(lat2)) *
                    Math.Pow(Math.Sin(dLon / 2), 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return R * c / 1.852; // to nautical miles
        }

        private double DegreesToRadians(double deg) => deg * Math.PI / 180;
    }
}
