using System;
using System.Linq;
using System.Text;

namespace lab2
{
    class CheckPoint
    {
        private static string[] _stolenNumber = { "1a0", "2b1", "3c2", "4d3", "5e4" };
        private const int _MAXLETSPEED = 110;
        private static int currentSpeed;
        private static string _messageOverSpeed;
        private static string _messageStolen;
        private static string _bodyTypeMessage;

        public static CheckPointStatistics Statistics = new CheckPointStatistics();
        public static void RegisterCars(AVehicle aVehicle)
        {
            currentSpeed = aVehicle.Speed;
            if (currentSpeed > _MAXLETSPEED)
            {
                Statistics.SpeedLimitBreakersCountInc();
                _messageOverSpeed = "OverSpeed";
            }
            else
            {
                _messageOverSpeed = "";
            }

            if (_stolenNumber.Contains(aVehicle.LicencePlateNumber))
            {
                Statistics.StolenCarsCountInc();
                _messageStolen ="INTERCEPT!";
                
            }
            else
            {
                _messageStolen = "";
            }

            if (aVehicle.BodyType == BodyType.Car)
            {;
                _bodyTypeMessage = "Car";
                Statistics.CarsCountInc();
            }
            else if (aVehicle.BodyType == BodyType.Truck)
            {
                _bodyTypeMessage = "Truck";
                Statistics.TruckCountInc();
            }
            else if (aVehicle.BodyType == BodyType.Bus)
            {
                _bodyTypeMessage = "Bus";
                Statistics.BusesCountInc();
            }

            Console.WriteLine(" " + aVehicle.LicencePlateNumber + "\t\t" + aVehicle.Color + "\t\t"
                + _bodyTypeMessage + "\t\t" + aVehicle.HasPassenger + "\t\t" + currentSpeed + "\t" + _messageOverSpeed + "\t\t" + _messageStolen);

        }
    }
}






