namespace lab2
{
    class CheckPointStatistics
    {
        public int CarsCount { get; private set; }

        public int TruckCount { get; private set; }

        public int BusesCount { get; private set; }

        public int SpeedLimitBreakersCount { get; private set; }

        public int StolenCarsCount { get; private set; }

        public int CommonCount { get { return BusesCount + TruckCount + CarsCount; } }

        public void CarsCountInc() { CarsCount++; }

        public void TruckCountInc() { TruckCount++; }

        public void BusesCountInc() { BusesCount++; }

        public void SpeedLimitBreakersCountInc() { SpeedLimitBreakersCount++; }

        public void StolenCarsCountInc() { StolenCarsCount++; }
    }
}
