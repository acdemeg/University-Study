using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceFleet.Model
{
	class NearRangeShip : ASpaceship
	{
        private const double NEAR_RANGE = 0.00003;

		public NearRangeShip(string name, int capacity)
			: base(name, capacity){}

        public override double GetRange()
        {
            return NEAR_RANGE;
        

	}
}
}