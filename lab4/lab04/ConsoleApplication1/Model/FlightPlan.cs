using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceFleet.Model
{
    class FlightPlan
    {
        private Dictionary<String, Double> _distanceToPlanets = new Dictionary<String, Double>();

        public Dictionary<String, Double> getDistanceToPlanets()
        {
            return _distanceToPlanets;
        }

        public void EvaluateDistanceToPlanets(List<Planet> planets)
        {
            double xEarth;
            double distance;

            IEnumerator<Planet> enumerator = planets.GetEnumerator();
            enumerator.MoveNext();
            xEarth = enumerator.Current.X;

            while(enumerator.MoveNext())
            {
                //evaluate distance 
                distance = Math.Sqrt(Math.Pow(enumerator.Current.X - xEarth, 2) + Math.Pow(enumerator.Current.Y, 2));
                _distanceToPlanets.Add(enumerator.Current.Name, distance);
            }
            
        }
    }
}
