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
        private const int MaxNotChangedGenerations = 400;
        private const int PopulationSize = 100;
        private const double MutationRate = 0.001;
        private const double CrossoverRate = 0.9;
        private const int ElitismCount = 2;

        private static int Runs = 0;
        private static Route exactValue = null;
        private static Place[] data = null;

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
            Runs = request.Amounts[0];
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
                        AmountOfData = amount * 10,
                        Duration = endPoint.Subtract(statPoint).TotalSeconds * 5
                    });
            }

            //var gaCalculator =
            //    new TravelingSalesmanProblemCalculation(
            //        MaxNotChangedGenerations,
            //        300,
            //        MutationRate,
            //        CrossoverRate,
            //        ElitismCount);

            //if (data == null)
            //{
            //    data = DataRandomizer.GenerateRandomPlaces(75).ToArray();
            //}

            //if (exactValue == null)
            //{
            //    exactValue = gaCalculator.CalculateBestRoute(data);
            //}

            //// коефіцієнту мутації від часу виконання
            //if (Runs == 0)
            //{
            //    Runs++;
            //    var rate = 0.001;
            //    for (int i = 1; i <= 10; i++, rate += 0.005)
            //    {
            //        gaCalculator =
            //            new TravelingSalesmanProblemCalculation(
            //                MaxNotChangedGenerations,
            //                PopulationSize,
            //                CrossoverRate,
            //                rate,
            //                ElitismCount);

            //        var solution = gaCalculator.CalculateBestRoute(data);

            //        result.Add(
            //            new CalculationStatistic
            //            {
            //                AmountOfData = rate,
            //                Duration = solution.DurationInMilliseconds
            //            });

            //        if (rate == 0.006)
            //        {
            //            rate -= 0.001;
            //        }
            //    }
            //}
            //// коефіцієнту мутації від точності розв’язку
            //else if (Runs == 1)
            //{
            //    Runs++;
            //    var rate = 0.001;
            //    for (int i = 1; i <= 10; i++, rate += 0.005)
            //    {
            //        gaCalculator =
            //            new TravelingSalesmanProblemCalculation(
            //                MaxNotChangedGenerations,
            //                PopulationSize,
            //                CrossoverRate,
            //                rate,
            //                ElitismCount);

            //        var solution = gaCalculator.CalculateBestRoute(data);

            //        result.Add(
            //            new CalculationStatistic
            //            {
            //                AmountOfData = rate,
            //                Duration = ((solution.distance - exactValue.distance) / solution.distance) * 100
            //            });

            //        if (rate == 0.006)
            //        {
            //            rate -= 0.001;
            //        }
            //    }
            //}


            //// коефіцієнту схрещування від часу виконання
            //else if (Runs == 2)
            //{
            //    Runs++;
            //    var rate = 0.1;
            //    for (int i = 1; i <= 9; i++, rate += 0.1)
            //    {
            //        gaCalculator =
            //            new TravelingSalesmanProblemCalculation(
            //                MaxNotChangedGenerations,
            //                PopulationSize,
            //                rate,
            //                MutationRate,
            //                ElitismCount);

            //        var solution = gaCalculator.CalculateBestRoute(data);

            //        result.Add(
            //            new CalculationStatistic
            //            {
            //                AmountOfData = rate,
            //                Duration = solution.DurationInMilliseconds
            //            });
            //    }
            //}
            //// коефіцієнту схрещування від точності розв’язку
            //else if (Runs == 3)
            //{
            //    Runs++;
            //    var rate = 0.1;
            //    for (int i = 1; i <= 9; i++, rate += 0.1)
            //    {
            //        gaCalculator =
            //            new TravelingSalesmanProblemCalculation(
            //                MaxNotChangedGenerations,
            //                PopulationSize,
            //                rate,
            //                MutationRate,
            //                ElitismCount);

            //        var solution = gaCalculator.CalculateBestRoute(data);

            //        result.Add(
            //            new CalculationStatistic
            //            {
            //                AmountOfData = rate,
            //                Duration = ((solution.distance - exactValue.distance) / solution.distance) * 100
            //            });
            //    }
            //}



            //// коефіцієнту розміру популяції від часу виконання
            //else if (Runs == 4)
            //{
            //    Runs++;
            //    var amount = 10;
            //    for (int i = 1; i <= 10; i++, amount += 10)
            //    {
            //        gaCalculator =
            //            new TravelingSalesmanProblemCalculation(
            //                MaxNotChangedGenerations,
            //                amount,
            //                CrossoverRate,
            //                MutationRate,
            //                ElitismCount);

            //        var solution = gaCalculator.CalculateBestRoute(data);

            //        result.Add(
            //            new CalculationStatistic
            //            {
            //                AmountOfData = amount,
            //                Duration = solution.DurationInMilliseconds
            //            });
            //    }
            //}
            //// коефіцієнту розміру популяції від точності розв’язку
            //else if (Runs == 5)
            //{
            //    Runs++;

            //    var amount = 10;
            //    for (int i = 1; i <= 10; i++, amount += 10)
            //    {
            //        gaCalculator =
            //            new TravelingSalesmanProblemCalculation(
            //                MaxNotChangedGenerations,
            //                amount,
            //                CrossoverRate,
            //                MutationRate,
            //                ElitismCount);

            //        var solution = gaCalculator.CalculateBestRoute(data);

            //        result.Add(
            //            new CalculationStatistic
            //            {
            //                AmountOfData = amount,
            //                Duration = ((solution.distance - exactValue.distance) / solution.distance) * 100
            //            });
            //    }
            //}

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
            public double AmountOfData { get; set; }
            public double Duration { get; set; }
        }
    }
}
