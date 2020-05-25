using System;

namespace GeneticlAlgorithmCalculation.GACalculations.Models
{
    public class Place
    {
        public double X { get; set; }
        public double Y { get; set; }

        private double distance = -1;

        public Place()
        {
        }

        public Place(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double GetDistance(Place toCity)
        {
            if (distance != -1)
            {
                return distance;
            }

            var deltaX = Math.Pow(X - toCity.X, 2);
            var deltaY = Math.Pow(Y - toCity.Y, 2);

            distance = Math.Sqrt(Math.Abs(deltaX + deltaY));

            return distance;
        }
    }
}
