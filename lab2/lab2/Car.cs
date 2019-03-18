
namespace lab2
{
    class Car : AVehicle
    {
        private const int _LOWSPEED = 90;
        private const int _HIGHTSPEED = 150;

        public override int Speed { get { return _random.Next(_LOWSPEED, _HIGHTSPEED + 1); } }

        public Car(string color, string licensePlateNumber, bool hasPassenger)
            : base(color, BodyType.Car, licensePlateNumber, hasPassenger) { }
    }
}
