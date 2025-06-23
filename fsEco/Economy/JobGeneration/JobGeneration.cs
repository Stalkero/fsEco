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
            int randomCargoTypeCount;
            string randomCargoType;
            int minJobTypeCargoWeight;
            int maxJobTypeCargoWeight;
            int finalcargoWeight;

            var from = AirportsDatabase.Airports.FirstOrDefault(a => a.ident == depICAO);
            if (from == null) return;

            var rng = new Random();
            int JobTypesCount = fsEco.PublicData.JobGeneration.JobTypes.JobTypesList.JobList.Length;

            for (int i = 0; i < attempts; i++)
            {
                var to = AirportsDatabase.Airports[rng.Next(AirportsDatabase.Airports.Count)];

                if (to.ident == depICAO) continue;

                double dist = Haversine(from.latitude_deg, from.longitude_deg, to.latitude_deg, to.longitude_deg);

                if (dist >= minDistance && dist <= maxDistance)
                {
                    
                    string randomJobType = fsEco.PublicData.JobGeneration.JobTypes.JobTypesList.JobList[rng.Next(JobTypesCount)];

                    switch (randomJobType)
                    {
                        case "CargoTransport":
                            randomCargoTypeCount = fsEco.PublicData.JobGeneration.JobTypes.CargoTransport.CargoTypes.Types.Length;
                            randomCargoType = fsEco.PublicData.JobGeneration.JobTypes.CargoTransport.CargoTypes.Types[rng.Next(randomCargoTypeCount)];

                            int randomJobDescriptionCount = fsEco.PublicData.JobGeneration.JobTypes.CargoTransport.JobDesciption.Descriptions.Length;
                            string randomJobDescription = fsEco.PublicData.JobGeneration.JobTypes.CargoTransport.JobDesciption.Descriptions[rng.Next(randomJobDescriptionCount)];

                            minPay = 1000;
                            minJobTypeCargoWeight = 200;
                            maxJobTypeCargoWeight = 50000;


                            finalcargoWeight = rng.Next((int)minJobTypeCargoWeight, (int)maxJobTypeCargoWeight);

                            if (finalcargoWeight <= maxCargoWeight || finalcargoWeight >= minCargoWeight)
                            {
                                JobsDatabase.Jobs.Add(new JobListing
                                {
                                    FromIcao = from.ident,
                                    ToIcao = to.ident,
                                    Distance = dist,
                                    JobType = randomJobType,
                                    cargoType = randomCargoType,
                                    Description = randomJobDescription,
                                    Pay = rng.Next((int)minPay, (int)(minPay * 1.5)),
                                    CargoWeight = rng.Next((int)minCargoWeight, (int)maxCargoWeight),
                                });
                            }


                            break;





                        case "Civilian":
                            randomJobDescriptionCount = fsEco.PublicData.JobGeneration.JobTypes.Civilian.JobDescription.Descriptions.Length;
                            randomJobDescription = fsEco.PublicData.JobGeneration.JobTypes.Civilian.JobDescription.Descriptions[rng.Next(randomJobDescriptionCount)];

                            minPay = 500;
                            minJobTypeCargoWeight = 50;
                            maxJobTypeCargoWeight = 500;

                            finalcargoWeight = rng.Next((int)minJobTypeCargoWeight, (int)maxJobTypeCargoWeight);

                            if (finalcargoWeight <= maxCargoWeight || finalcargoWeight >= minCargoWeight)
                            {
                                JobsDatabase.Jobs.Add(new JobListing
                                {
                                    FromIcao = from.ident,
                                    ToIcao = to.ident,
                                    Distance = dist,
                                    JobType = randomJobType,
                                    cargoType = "PAX",
                                    Description = randomJobDescription,
                                    Pay = rng.Next((int)minPay, (int)(minPay * 1.5)),
                                    CargoWeight = rng.Next((int)minCargoWeight, (int)maxCargoWeight),
                                });
                            }



                            break;




                        case "Medical":
                            randomJobDescriptionCount = fsEco.PublicData.JobGeneration.JobTypes.Medical.JobDescription.Descriptions.Length;
                            randomJobDescription = fsEco.PublicData.JobGeneration.JobTypes.Medical.JobDescription.Descriptions[rng.Next(randomJobDescriptionCount)];

                            minPay = 1000;
                            minJobTypeCargoWeight = 100;
                            maxJobTypeCargoWeight = 10000;

                            finalcargoWeight = rng.Next((int)minJobTypeCargoWeight, (int)maxJobTypeCargoWeight);

                            if (finalcargoWeight <= maxCargoWeight || finalcargoWeight >= minCargoWeight)
                            {
                                JobsDatabase.Jobs.Add(new JobListing
                                {
                                    FromIcao = from.ident,
                                    ToIcao = to.ident,
                                    Distance = dist,
                                    JobType = randomJobType,
                                    cargoType = "PAX",
                                    Description = randomJobDescription,
                                    Pay = rng.Next((int)minPay, (int)(minPay * 1.5)),
                                    CargoWeight = rng.Next((int)minCargoWeight, (int)maxCargoWeight),
                                });
                            }


                            break;


                        case "Military":
                            randomJobDescriptionCount = fsEco.PublicData.JobGeneration.JobTypes.Military.JobDescription.Descriptions.Length;
                            randomJobDescription = fsEco.PublicData.JobGeneration.JobTypes.Military.JobDescription.Descriptions[rng.Next(randomJobDescriptionCount)];

                            minPay = 1500;
                            minJobTypeCargoWeight = 200;
                            maxJobTypeCargoWeight = 20000;

                            finalcargoWeight = rng.Next((int)minJobTypeCargoWeight, (int)maxJobTypeCargoWeight);

                            if (finalcargoWeight <= maxCargoWeight || finalcargoWeight >= minCargoWeight)
                            {
                                JobsDatabase.Jobs.Add(new JobListing
                                {
                                    FromIcao = from.ident,
                                    ToIcao = to.ident,
                                    Distance = dist,
                                    JobType = randomJobType,
                                    cargoType = "PAX",
                                    Description = randomJobDescription,
                                    Pay = rng.Next((int)minPay, (int)(minPay * 1.5)),
                                    CargoWeight = rng.Next((int)minCargoWeight, (int)maxCargoWeight),
                                });
                            }
                            break;
                        default:
                            continue; // Skip if job type is not recognized
                    }





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
