using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceFleet.Model
{
	class Planet
	{
		public string Name { get; private set; }
		public int Need { get; set; }
		public double X { get; private set; }
		public double Y { get; private set; }

		public Planet(string name, int need, double x, double y)
		{
			Name = name;
			Need = need;
			X = x;
			Y = y;
		}

		public static Planet Create(string input)
		{
			throw new NotImplementedException();
		}
	}
}
