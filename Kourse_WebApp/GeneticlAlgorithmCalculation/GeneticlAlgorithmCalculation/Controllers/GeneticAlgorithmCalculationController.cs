using System.Collections.Generic;
using GeneticlAlgorithmCalculation.GACalculations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GeneticlAlgorithmCalculation.Controllers
{
    [ApiController]
    [Route("calculations")]
    public class GeneticAlgorithmCalculationController : ControllerBase
    {
        private readonly ILogger<GeneticAlgorithmCalculationController> _logger;

        public GeneticAlgorithmCalculationController(
            ILogger<GeneticAlgorithmCalculationController> logger)
        {
            _logger = logger;
        }

        [HttpPost("bestroute")]
        public ActionResult<Route> Calculate(TravellingSalesmanProblemRequest request)
        {
            var ga = new TravelingSalesmanProblemCalculation();

            return ga.CalculateBestRoute(request.Cities);
        }

        public class TravellingSalesmanProblemRequest
        {
            public City[] Cities { get; set; }
        }
    }
}
