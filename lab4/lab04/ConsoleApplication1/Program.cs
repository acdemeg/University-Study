using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using SpaceFleet.Model;

namespace SpaceFleet
{
	class Program
	{
		static void Main(string[] args)
		{
            List<ASpaceship> ships = new List<ASpaceship>();
            List<Planet> planets = new List<Planet>();
           
            //create list of ships and planets
            FillingLists(planets, ships);
            SpacePort.LaunchOfShips(planets, ships);
            Console.ReadKey();
        }

        static void FillingLists(List<Planet> planets, List<ASpaceship> ships)
        {
            var data = File.ReadAllLines("data.txt");
            var shipsRead = false;

            foreach (var line in data)
            {
                if (string.IsNullOrEmpty(line))
                {
                    shipsRead = true;

                    continue;
                }

                if (shipsRead)
                    planets.Add(Planet.Create(line));
                else
                    ships.Add(ASpaceship.Create(line));
            }
            //planets.Sort((object1, object2) => object1.Need.CompareTo(object2.Need));
        }
	}
}
