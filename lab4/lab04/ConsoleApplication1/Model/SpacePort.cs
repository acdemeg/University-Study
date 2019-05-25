using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceFleet.Model
{
    class SpacePort
    {
        //Declare delegates
        public delegate void ConsoleOutputPlanetName(string planetName);
        public delegate void ConsoleOutputShipInfo(ASpaceship ship, double distance);
        public static ConsoleOutputPlanetName consoleOutputPlanetName;
        public static ConsoleOutputShipInfo consoleOutputShipInfo;

        private static Dictionary<String, Double> _distanceToPlanets = new Dictionary<String, Double>();
        private const double LONG_RANGE = 0.001;
        private const double MIDDLE_RANGE = 0.0001;
        private const double NEAR_RANGE = 0.00003;
        private static int _cargoByShip;

        //define matching for light ship
        public static void ToRegisterFlight(List<Planet> planets, List<ASpaceship> ships)
        {
            EvaluateDistanceToPlanets(planets);
            ships.Sort((obj1, obj2) => obj1.Capacity.CompareTo(obj2.Capacity));
            planets.Sort((obj1, obj2) => obj1.Need.CompareTo(obj2.Need));

            //rotate planets 
            foreach (Planet planet in planets)
            {
                //get distance to planet
                double distance;
                _distanceToPlanets.TryGetValue(planet.Name, out distance);

                consoleOutputPlanetName.Invoke(planet.Name);

                while (planet.Need > 0)
                {
                    ASpaceship ship = LaunchOfShips(planet, distance, ships);
                    consoleOutputShipInfo.Invoke(ship, distance);
                }
            }
        }

        //preparing to launch of ship
        private static ASpaceship LaunchOfShips(Planet planet, double distance, List<ASpaceship> ships)
        {
            ASpaceship shipForFlight;
            foreach (ASpaceship ship in ships)
            {
                if (ship.GetRange() >= distance)
                {
                    shipForFlight = ship;
                    _cargoByShip = CalculateCargo(shipForFlight.Capacity, planet.Need);
                    shipForFlight.CurrentCargo = _cargoByShip;
                    planet.Need -= _cargoByShip;
                    ships.Remove(ship);
                    return shipForFlight;
                }
            }
            throw new Exception("pull of ships is empty");
        }

        //difine count transported cargo
        private static int CalculateCargo(int capasity, int need)
        {
            if (capasity <= need)
                return capasity;
            else return need;
        }

        //to calculate of distance to all planets
        private static void EvaluateDistanceToPlanets(List<Planet> planets)
        {
            Planet Earth;
            double distance;

            Earth = planets.Find(obj => obj.Name.Equals("Earth"));

            foreach (Planet planet in planets)
            {
               if (!planet.Name.Equals("Earth"))
               {
                 //evaluate distance 
                   distance = Math.Sqrt(Math.Pow(planet.X - Earth.X, 2) + Math.Pow(planet.Y - Earth.Y, 2));
                _distanceToPlanets.Add(planet.Name, distance);

               }
                
            }

        }
    }
}
