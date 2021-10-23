using APIGoldenRaspberryAwards.Entities;
using APIGoldenRaspberryAwards.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIGoldenRaspberryAwards.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IntervaloPremiosController : ControllerBase
    {
        [HttpGet]
        public IntervaloPremios Get([FromServices] IMoviesService moviesService)
        {
            return moviesService.GetIntervaloPremios();
        }
    }
}
