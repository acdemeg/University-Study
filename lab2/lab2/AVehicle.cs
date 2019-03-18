using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    abstract class AVehicle
    {
        protected static Random _random = new Random();

        public AVehicle(string color, BodyType bodyType, string licensePlateNumber, bool hasPassenger)
        {
            Color = color;
            BodyType = bodyType;
            LicencePlateNumber = licensePlateNumber;
            HasPassenger = hasPassenger;
        }

        public string Color { get; private set; }

        public BodyType BodyType { get; private set; }

        public string LicencePlateNumber { get; set; }

        public virtual int Speed { get; set; }

        public bool HasPassenger { get; set; }
    }

}
