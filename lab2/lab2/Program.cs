using System;

namespace lab2
{
    public enum BodyType
    {
        Car,
        Truck,
        Bus
    }

    class Program
    {

        static void Main(string[] args)
        {
            CheckPoint.CheckPointEventInstance += InformationView;
            
            Console.WriteLine();
            Console.WriteLine(" Number\t\tColor\t\tBodyType\tHasPassanger\tSpeed");
            Console.WriteLine();
            Random random = new Random();

            do
            {
                CheckPoint.RegisterCars(generationCars());
                System.Threading.Thread.Sleep(random.Next(500, 1500));
            }
            while (!Console.KeyAvailable);

            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t\tSTATISTICS");
            Console.WriteLine();
            Console.WriteLine(" CarsCount\tBusesCount\tTruckCount\tCommonCount\tSpeedLimitBreakersCount\t\tStolenCarsCount");
            Console.WriteLine(" " + CheckPoint.Statistics.CarsCount + "\t\t" + CheckPoint.Statistics.BusesCount + "\t\t"
                + CheckPoint.Statistics.TruckCount + "\t\t" + CheckPoint.Statistics.CommonCount + "\t\t"
                + CheckPoint.Statistics.SpeedLimitBreakersCount + "\t\t\t\t" + CheckPoint.Statistics.StolenCarsCount );

            Console.Read();
        }

        static AVehicle generationCars()
        {
            Random random = new Random();
            string[] listColor = { "Yellow", "Green", "Blue", "Brown", "White", "Red", "Orange", "Pink", "Gray", "Black" };
            string[] listNumbersAuto = { "1a1", "1a2", "1a3", "1a4", "1a5", "1a6", "1a7", "1a8", "1a9", "1a0",
                                         "2b0", "2b1", "2b2", "2b3", "2b4", "2b5", "2b6", "2b7", "2b8", "2b9",
                                         "3c0", "3c1", "3c2", "3c3", "3c4", "3c5", "3c6", "3c7", "3c8", "3c9",
                                         "4d0", "4d1", "4d2", "4d3", "4d4", "4d5", "4d6", "4d7", "4d8", "4d9",
                                         "5e0", "5e1", "5e2", "5e3", "5e4", "5e5", "5e6", "5e7", "5e8", "5e9"};
            bool hasPassenger = (random.Next(2) == 1) ? true : false;
            switch (random.Next(Enum.GetNames(typeof(BodyType)).Length))
            {
                case 0:
                    return new Car(listColor[random.Next(listColor.Length)], listNumbersAuto[random.Next(listNumbersAuto.Length)], hasPassenger);
                case 1:
                    return new Truck(listColor[random.Next(listColor.Length)], listNumbersAuto[random.Next(listNumbersAuto.Length)], hasPassenger);
                case 2:
                    return new Bus(listColor[random.Next(listColor.Length)], listNumbersAuto[random.Next(listNumbersAuto.Length)], hasPassenger);
                default: return null;
            }
        }
       
        //обработчик события
        public static void InformationView(CheckPointInfo checkPoinInfo)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(" " + checkPoinInfo.LicencePlateNumber);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t" + checkPoinInfo.Color);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\t\t" + checkPoinInfo.BodyTypeMessage);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\t\t" + checkPoinInfo.HasPassenger);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\t\t" + checkPoinInfo.CurrentSpeed);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("\t" + checkPoinInfo.MessageOverSpeed);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\t\t" + checkPoinInfo.MessageStolen);
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}

