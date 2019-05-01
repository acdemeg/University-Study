using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceFleet.Model
{
	class LongRangeShip : ASpaceship
	{
        private const double LONG_RANGE = 0.001;

        public LongRangeShip(string name, int capacity)
			: base(name, capacity){}

        public override double GetRange() 
        {
	        return LONG_RANGE;
	    }
    }
}
