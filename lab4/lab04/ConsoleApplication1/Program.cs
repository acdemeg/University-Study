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
            int cargoNeed = planets.Sum(obj => obj.Need);

            SpacePort.consoleOutputPlanetName = InformationViewAboutPlanet;
            SpacePort.consoleOutputShipInfo = InformationViewAboutShips;
            SpacePort.ToRegisterFlight(planets, ships);
            Console.WriteLine("--------------------------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine(" Total spaceShips = " + ships.Count + "\t\t" + "Total planets = " + planets.Count + "\t\t" + "All delivered cargo = " + cargoNeed);
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
        }

        static void InformationViewAboutPlanet (string planetName)
        {
            Console.WriteLine("--------------------------------------------------------------------------------------");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" " + planetName);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--------------------------------------------------------------------------------------");
        }

        static void InformationViewAboutShips(ASpaceship ship, double distance)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" " + ship.Name.PadRight(15 ,' '));
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\t" + ship.GetType().Name);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\t\t" + distance.ToString().PadRight(20, ' '));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\t" + ship.CurrentCargo);
            Console.ForegroundColor = ConsoleColor.White;
        }
	}
}
