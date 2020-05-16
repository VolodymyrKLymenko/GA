using System;

namespace GeneticlAlgorithmCalculation.GACalculations
{
    public class TravelingSalesmanProblemCalculation
    {
        private int _maxNotChangedGenerations = 700;
        private int _populationSize = 100;
        private double _mutationRate = 0.001;
        private double _crossoverRate = 0.9;
        private int _elitismCount = 2;

        public TravelingSalesmanProblemCalculation()
        {
        }

        public TravelingSalesmanProblemCalculation(
            int maxNotChangedGenerations,
            int populationSize,
            double mutationRate,
            double crossoverRate,
            int elitismCount)
        {
            _maxNotChangedGenerations = maxNotChangedGenerations;
            _populationSize = populationSize;
            _mutationRate = mutationRate;
            _crossoverRate = crossoverRate;
            _elitismCount = elitismCount;
        }

        public Route CalculateBestRoute(City[] cities)
        {
            var rnd = new Random();

            // Initializa GA
            var ga = new GeneticAlgorithm(
                _populationSize,
                _mutationRate,
                _crossoverRate,
                _elitismCount,
                _maxNotChangedGenerations/*, 5*/); // TODO use '5' argument

            var population = ga.InitPopulation(cities.Length);

            // Evaluate population
            ga.EvaluatePopulation(population, cities);

            // Keep track of current population
            var generation = 1;

            // Start evaluation loop
            while (!ga.IsTerminationConditionMet(population))
            {
                // Apply crossover
                population = ga.CrossoverPopulation(population, rnd);

                // Apply mutation
                population = ga.MutatePopulation(population, rnd);

                // Evaluate population
                ga.EvaluatePopulation(population, cities);

                // Increment current generation
                generation++;
            }

            var result = new Route(population.GetFittest(0), cities);
            result.GetDistance();

            return result;
        }
    }

    public class City
    {
        public double X { get; set; }
        public double Y { get; set; }

        public City()
        {
        }

        public City(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double GetDistance(City toCity)
        {
            var deltaX = Math.Pow(X - toCity.X, 2);
            var deltaY = Math.Pow(Y - toCity.Y, 2);

            return Math.Sqrt(Math.Abs(deltaX + deltaY));
        }
    }

    public class Route
    {
        public City[] route { get; private set; }
        public double distance { get; private set; }

        public Route(Individual individual, City[] cities)
        {
            // get individual's chromosome
            var chromosome = individual.Chromosome;

            // create route
            route = new City[cities.Length];
            for (int genIndex = 0; genIndex < chromosome.Length; genIndex++)
            {
                route[genIndex] = cities[chromosome[genIndex]];
            }
        }

        public double GetDistance()
        {
            if (distance > 0)
            {
                return distance;
            }

            var totalDistance = 0.0;
            for (int cityIndex = 0; cityIndex < route.Length - 1; cityIndex++)
            {
                totalDistance += route[cityIndex].GetDistance(route[cityIndex + 1]);
            }

            totalDistance += route[route.Length - 1].GetDistance(route[0]);

            distance = totalDistance;

            return distance;
        }
    }
}
