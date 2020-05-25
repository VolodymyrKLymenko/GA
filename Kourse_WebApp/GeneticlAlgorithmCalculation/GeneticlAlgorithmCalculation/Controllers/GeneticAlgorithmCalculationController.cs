using GeneticlAlgorithmCalculation.GACalculations;
using GeneticlAlgorithmCalculation.GACalculations.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace GeneticlAlgorithmCalculation.Controllers
{
    [ApiController]
    [Route("calculations")]
    public class GeneticAlgorithmCalculationController : ControllerBase
    {
        private const int MaxNotChangedGenerations = 700;
        private const int PopulationSize = 100;
        private const double MutationRate = 0.001;
        private const double CrossoverRate = 0.9;
        private const int ElitismCount = 2;

        private readonly ILogger<GeneticAlgorithmCalculationController> _logger;

        public GeneticAlgorithmCalculationController(
            ILogger<GeneticAlgorithmCalculationController> logger)
        {
            _logger = logger;
        }

        [HttpPost("bestroute")]
        public ActionResult<Route> Calculate(TravellingSalesmanProblemRequest request)
        {
            var gaCalculator =
                new TravelingSalesmanProblemCalculation(
                    MaxNotChangedGenerations,
                    PopulationSize,
                    MutationRate,
                    CrossoverRate,
                    ElitismCount);

            return gaCalculator.CalculateBestRoute(request.Places);
        }

        public class TravellingSalesmanProblemRequest
        {
            public Place[] Places { get; set; }
        }

        [HttpPost("statistic")]
        public ActionResult<CalculationStatistic[]> CalculateStatistic(CalculationStatisticRequest request)
        {
            var result = new List<CalculationStatistic>();

            var gaCalculator =
                new TravelingSalesmanProblemCalculation(
                    MaxNotChangedGenerations,
                    PopulationSize,
                    MutationRate,
                    CrossoverRate,
                    ElitismCount);

            foreach (var amount in request.Amounts)
            {
                var data = DataRandomizer.GenerateRandomPlaces(amount).ToArray();

                var statPoint = DateTime.Now;

                gaCalculator.CalculateBestRoute(data);

                var endPoint = DateTime.Now;

                result.Add(
                    new CalculationStatistic
                    {
                        AmountOfData = amount,
                        Duration = endPoint.Subtract(statPoint).TotalSeconds
                    });
            }

            return result.ToArray();
        }

        public class CalculationStatisticRequest
        {
            public int[] Amounts { get; set; }

            public CalculationStatisticRequest()
            {
                Amounts = new[] { 100, 200 };
            }
        }

        public class CalculationStatistic
        {
            public int AmountOfData { get; set; }
            public double Duration { get; set; }
        }
    }
}
