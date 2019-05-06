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
            double xEarth;
            double distance;

            IEnumerator<Planet> enumerator = planets.GetEnumerator();
            enumerator.MoveNext();
            xEarth = enumerator.Current.X;

            while (enumerator.MoveNext())
            {
                //evaluate distance 
                distance = Math.Sqrt(Math.Pow(enumerator.Current.X - xEarth, 2) + Math.Pow(enumerator.Current.Y, 2));
                _distanceToPlanets.Add(enumerator.Current.Name, distance);
            }

        }
    }
}
