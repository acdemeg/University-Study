using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceFleet.Model
{
    class SpacePort
    {
        private static FlightPlan flightPlan = new FlightPlan();
        private static List<NearRangeShip> nearRangeShips = new List<NearRangeShip>();
        private static List<MiddleRangeShip> middleRangeShips = new List<MiddleRangeShip>();
        private static List<LongRangeShip> longRangeShips = new List<LongRangeShip>();
        private const double LONG_RANGE = 0.001;
        private const double MIDDLE_RANGE = 0.0001;
        private const double NEAR_RANGE = 0.00003;
        private static int cargoByShip;

        //define matching for light ship
        public static void LaunchOfShips (List<Planet> planets, List<ASpaceship> ships)
        {
            ToDistributeOfShipsByType(ships);
            flightPlan.EvaluateDistanceToPlanets(planets);

            Dictionary<String, Double> distanceToPlanets = flightPlan.getDistanceToPlanets();
            double distance;

            //rotate planets 
            foreach (Planet planet in planets)
            {
                //get distance to planet
                distanceToPlanets.TryGetValue(planet.Name, out distance);

                while (planet.Need > 0)
                {
                    if (distance < NEAR_RANGE)
                    {
                        if(nearRangeShips.Count > 0)
                        {
                           NearRangeShip ship = nearRangeShips.ElementAt(0);
                           cargoByShip = CalculateCargo(ship.Capacity, planet.Need);
                           planet.Need -= cargoByShip;
                           nearRangeShips.Remove(ship);
                           continue;
                        }
                        else if (middleRangeShips.Count > 0)
                        {
                           MiddleRangeShip ship = middleRangeShips.ElementAt(0);
                           cargoByShip = CalculateCargo(ship.Capacity, planet.Need);
                           planet.Need -= cargoByShip;
                           middleRangeShips.Remove(ship);
                           continue;
                        }
                        else if (longRangeShips.Count > 0)
                        {
                           LongRangeShip ship = longRangeShips.ElementAt(0);
                           cargoByShip = CalculateCargo(ship.Capacity, planet.Need);
                           planet.Need -= cargoByShip;
                           longRangeShips.Remove(ship);
                           continue;
                        }
                        throw new Exception("pull of ships is empty");
                    }
//***************************************************************************************************************
                    else if (distance < MIDDLE_RANGE)
                    {
                        if (middleRangeShips.Count > 0)
                        {
                           MiddleRangeShip ship = middleRangeShips.ElementAt(0);
                           cargoByShip = CalculateCargo(ship.Capacity, planet.Need);
                           planet.Need -= cargoByShip;
                           middleRangeShips.Remove(ship);
                           continue;
                        }
                        else if (longRangeShips.Count > 0)
                        {
                           LongRangeShip ship = longRangeShips.ElementAt(0);
                           cargoByShip = CalculateCargo(ship.Capacity, planet.Need);
                           planet.Need -= cargoByShip;
                           longRangeShips.Remove(ship);
                           continue;
                        }
                        throw new Exception("pull of ships is empty");
                    }
//***************************************************************************************************************                    
                    else if (distance < LONG_RANGE)
                    {
                        if (longRangeShips.Count > 0)
                        {
                           LongRangeShip ship = longRangeShips.ElementAt(0);
                           cargoByShip = CalculateCargo(ship.Capacity, planet.Need);
                           planet.Need -= cargoByShip;
                           longRangeShips.Remove(ship);
                           continue;
                        }
                        throw new Exception("pull of ships is empty");
                    }

                }
            }
        }

        //difine count transported cargo
        private static int CalculateCargo(int capasity, int need)
        {
            if (capasity <= need)
                return capasity;
            else return need;
        }

        //distribution of ships by type
        private static void ToDistributeOfShipsByType (List<ASpaceship> ships)
        {
            foreach (ASpaceship ship in ships)
            {
                if (ship is NearRangeShip)
                {
                    nearRangeShips.Add(ship as NearRangeShip);
                    continue;
                }
                else if (ship is MiddleRangeShip)
                {
                    middleRangeShips.Add(ship as MiddleRangeShip);
                    continue;
                }
                else if (ship is LongRangeShip)
                {
                    longRangeShips.Add(ship as LongRangeShip);
                    continue;
                }
            }
            nearRangeShips.Sort((object1, object2) => object1.Capacity.CompareTo(object2.Capacity));
            middleRangeShips.Sort((object1, object2) => object1.Capacity.CompareTo(object2.Capacity));
            longRangeShips.Sort((object1, object2) => object1.Capacity.CompareTo(object2.Capacity));

        }
    }
}
