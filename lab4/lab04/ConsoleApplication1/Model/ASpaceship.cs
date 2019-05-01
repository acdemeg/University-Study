using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceFleet.Model
{
	abstract class ASpaceship
	{
		public string Name { get; private set; }
		public int Capacity { get; private set; }

		public ASpaceship(string name, int capacity)
		{
			Name = name;
			Capacity = capacity;
		}

        public abstract double GetRange();

		public static ASpaceship Create(string input)
		{
			var buf = input.Split('\t');
			var name = buf[2];
			var capacity = Convert.ToInt32(buf[1]);

			if (buf[0] == "LongRange")
				return new LongRangeShip(name, capacity);
			if (buf[0] == "MiddleRange")
				return new MiddleRangeShip(name, capacity);
			if (buf[0] == "NearRange")
				return new NearRangeShip(name, capacity);

            throw new Exception("unknown type ship");
		}
	}
}
