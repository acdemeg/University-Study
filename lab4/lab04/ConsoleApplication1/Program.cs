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
			var data = File.ReadAllLines("data.txt");
			var ships = new List<ASpaceship>();
			var planets = new List<Planet>();
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
	}
}
