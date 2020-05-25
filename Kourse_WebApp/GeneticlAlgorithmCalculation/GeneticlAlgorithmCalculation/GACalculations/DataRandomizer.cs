using GeneticlAlgorithmCalculation.GACalculations.Models;
using System;
using System.Collections.Generic;

namespace GeneticlAlgorithmCalculation.GACalculations
{
    public static class DataRandomizer
    {
        public static List<Place> GenerateRandomPlaces(int count)
        {
            var rnd = new Random();
            var res = new List<Place>(count);

            for (int i = 0; i < count; i++)
            {
                res.Add(new Place((rnd.NextDouble() - rnd.NextDouble()) * 179.0, (rnd.NextDouble() - rnd.NextDouble()) * 80));
            }

            return res;
        }
    }
}
