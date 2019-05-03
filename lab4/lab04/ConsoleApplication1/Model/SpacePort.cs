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
        private static List<NearRangeShip> _nearRangeShips = new List<NearRangeShip>();
        private static List<MiddleRangeShip> _middleRangeShips = new List<MiddleRangeShip>();
        private static List<LongRangeShip> _longRangeShips = new List<LongRangeShip>();
        private const double LONG_RANGE = 0.001;
        private const double MIDDLE_RANGE = 0.0001;
        private const double NEAR_RANGE = 0.00003;
        private static int _cargoByShip;

        //define matching for light ship
        public static void ToRegisterFlight(List<Planet> planets, List<ASpaceship> ships)
        {
            ToDistributeOfShipsByType(ships);
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
                    ASpaceship ship = LaunchOfShips(planet, distance);
                    consoleOutputShipInfo.Invoke(ship, distance);
                }
            }
        }

        //preparing to launch of ship
        private static ASpaceship LaunchOfShips(Planet planet, double distance)
        {
            if (distance < NEAR_RANGE)
                {
                    if (_nearRangeShips.Count > 0)
                    {
                        NearRangeShip ship = _nearRangeShips.ElementAt(0);
                        _cargoByShip = CalculateCargo(ship.Capacity, planet.Need);
                        ship.CurrentCargo = _cargoByShip;
                        planet.Need -= _cargoByShip;
                        _nearRangeShips.Remove(ship);
                        return ship;
                    }
                    else if (_middleRangeShips.Count > 0)
                    {
                        MiddleRangeShip ship = _middleRangeShips.ElementAt(0);
                        _cargoByShip = CalculateCargo(ship.Capacity, planet.Need);
                        ship.CurrentCargo = _cargoByShip;
                        planet.Need -= _cargoByShip;
                        _middleRangeShips.Remove(ship);
                        return ship;
                    }
                    else if (_longRangeShips.Count > 0)
                    {
                        LongRangeShip ship = _longRangeShips.ElementAt(0);
                        _cargoByShip = CalculateCargo(ship.Capacity, planet.Need);
                        ship.CurrentCargo = _cargoByShip;
                        planet.Need -= _cargoByShip;
                        _longRangeShips.Remove(ship);
                        return ship;
                    }
                    throw new Exception("pull of ships is empty");
                }
                //***************************************************************************************************************
                else if (distance < MIDDLE_RANGE)
                {
                    if (_middleRangeShips.Count > 0)
                    {
                        MiddleRangeShip ship = _middleRangeShips.ElementAt(0);
                        _cargoByShip = CalculateCargo(ship.Capacity, planet.Need);
                        ship.CurrentCargo = _cargoByShip;
                        planet.Need -= _cargoByShip;
                        _middleRangeShips.Remove(ship);
                        return ship;
                    }
                    else if (_longRangeShips.Count > 0)
                    {
                        LongRangeShip ship = _longRangeShips.ElementAt(0);
                        _cargoByShip = CalculateCargo(ship.Capacity, planet.Need);
                        ship.CurrentCargo = _cargoByShip;
                        planet.Need -= _cargoByShip;
                        _longRangeShips.Remove(ship);
                        return ship;
                    }
                    throw new Exception("pull of ships is empty");
                }
                //***************************************************************************************************************                    
                else 
                {
                    if (_longRangeShips.Count > 0)
                    {
                        LongRangeShip ship = _longRangeShips.ElementAt(0);
                        _cargoByShip = CalculateCargo(ship.Capacity, planet.Need);
                        ship.CurrentCargo = _cargoByShip;
                        planet.Need -= _cargoByShip;
                        _longRangeShips.Remove(ship);
                        return ship;
                    }
                    throw new Exception("pull of ships is empty");
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
                    _nearRangeShips.Add(ship as NearRangeShip);
                    continue;
                }
                else if (ship is MiddleRangeShip)
                {
                    _middleRangeShips.Add(ship as MiddleRangeShip);
                    continue;
                }
                else if (ship is LongRangeShip)
                {
                    _longRangeShips.Add(ship as LongRangeShip);
                    continue;
                }
            }
            _nearRangeShips.Sort((object1, object2) => object1.Capacity.CompareTo(object2.Capacity));
            _middleRangeShips.Sort((object1, object2) => object1.Capacity.CompareTo(object2.Capacity));
            _longRangeShips.Sort((object1, object2) => object1.Capacity.CompareTo(object2.Capacity));

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
