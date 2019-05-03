using System;
using System.Linq;
using System.Text;

namespace lab2
{
   class CheckPoint
    {
       // объявляем делегат и событие
       public delegate void ConsoleInput(CheckPointInfo checkPointInfo);
       public static event ConsoleInput CheckPointEventInstance;

        private static string[] _stolenNumber = { "1a0", "2b1", "3c2", "4d3", "5e4" };
        private const int _MAXLETSPEED = 110;
        public static CheckPointStatistics Statistics = new CheckPointStatistics();

        public static void RegisterCars(AVehicle aVehicle)
        {
            CheckPointInfo checkPointInfo = new CheckPointInfo();

            checkPointInfo.LicencePlateNumber = aVehicle.LicencePlateNumber;
            checkPointInfo.Color = aVehicle.Color;
            checkPointInfo.HasPassenger = aVehicle.HasPassenger;
            checkPointInfo.CurrentSpeed = aVehicle.Speed;

            if (checkPointInfo.CurrentSpeed > _MAXLETSPEED)
            {
                Statistics.SpeedLimitBreakersCountInc();
               checkPointInfo.MessageOverSpeed =  "OverSpeed";
            }
            else
            {
                checkPointInfo.MessageOverSpeed = "";
            }

            if (_stolenNumber.Contains(aVehicle.LicencePlateNumber))
            {
                Statistics.StolenCarsCountInc();
                checkPointInfo.MessageStolen = "INTERCEPT!";
            }
            else
            {
                checkPointInfo.MessageStolen = "";
            }

            if (aVehicle.BodyType == BodyType.Car)
            {
                checkPointInfo.BodyTypeMessage = "Car";
                Statistics.CarsCountInc();
            }
            else if (aVehicle.BodyType == BodyType.Truck)
            {
                checkPointInfo.BodyTypeMessage = "Truck";
                Statistics.TruckCountInc();
            }
            else if (aVehicle.BodyType == BodyType.Bus)
            {
                checkPointInfo.BodyTypeMessage = "Bus";
                Statistics.BusesCountInc();
            }

            // если обработчик установлен вызываем событие
            if (CheckPointEventInstance != null)   
                    CheckPointEventInstance(checkPointInfo); 
        }
    }
}






