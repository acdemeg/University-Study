using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceFleet.Model
{
	class MiddleRangeShip : ASpaceship
	{
        private const double MIDDLE_RANGE = 0.0001;

		public MiddleRangeShip(string name, int capacity)
			: base(name, capacity){}

        public override double GetRange()
        {
            return MIDDLE_RANGE;
        }
    
    }
}
