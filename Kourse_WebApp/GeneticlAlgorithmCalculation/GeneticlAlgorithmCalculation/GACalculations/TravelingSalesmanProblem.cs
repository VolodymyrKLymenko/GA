using System;
using GeneticlAlgorithmCalculation.GACalculations.Models;

namespace GeneticlAlgorithmCalculation.GACalculations
{
    public class TravelingSalesmanProblemCalculation : GeneticAlgorithmSolverBase
    {
        public TravelingSalesmanProblemCalculation(
            int maxNotChangedGenerations,
            int populationSize,
            double mutationRate,
            double crossoverRate,
            int elitismCount) : base(populationSize, mutationRate, crossoverRate, elitismCount, maxNotChangedGenerations)
        {
        }

        private double CalculateFitness(Individual individual, Place[] places)
        {
            var route = new Route(individual, places);

            var fitness = 1.0 / route.GetDistance();

            individual.Fitness = fitness;

            return fitness;
        }

        public Route CalculateBestRoute(Place[] places)
        {
            var rnd = new Random();
            var population = InitPopulation(places.Length);

            var startPoint = DateTime.Now;

            // Evaluate population
            EvaluatePopulation(population, (individual) => CalculateFitness(individual, places));

            // Keep track of current population
            var generation = 1;

            // Start evaluation loop
            while (!IsTerminationConditionMet(population))
            {
                // Apply crossover
                population = CrossoverPopulation(population, rnd);

                // Apply mutation
                population = AdaptiveMutatePopulation(population, rnd);

                // Evaluate population
                EvaluatePopulation(population, (individual) => CalculateFitness(individual, places));

                // Increment current generation
                generation++;
            }

            var endPoint = DateTime.Now;

            var result = new Route(population.GetFittest(0), places)
            {
                GenerationsCount = generation,
                DurationInMilliseconds = endPoint.Subtract(startPoint).TotalSeconds
            };
            result.GetDistance();

            return result;
        }
    }
}
