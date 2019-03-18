namespace lab2
{
    class Bus : AVehicle
    {
        private const int _LOWSPEED = 80;
        private const int _HIGHTSPEED = 110;

        public override int Speed { get { return _random.Next(_LOWSPEED, _HIGHTSPEED + 1); } }

        public Bus(string color, string licensePlateNumber, bool hasPassenger)
            : base(color, BodyType.Bus, licensePlateNumber, hasPassenger) { }
    }
}
