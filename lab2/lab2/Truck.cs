namespace lab2
{
    class Truck : AVehicle
    {
        private const int _LOWSPEED = 70;
        private const int _HIGHTSPEED = 100;

        public override int Speed { get { return _random.Next(_LOWSPEED, _HIGHTSPEED + 1); } }

        public Truck(string color, string licensePlateNumber, bool hasPassenger)
            : base(color, BodyType.Truck, licensePlateNumber, hasPassenger) { }
    }
}
