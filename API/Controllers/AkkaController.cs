using Akka.Actor;
using AkkaConsole.Models;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/akka")]
    public class AkkaController : ControllerBase
    {
        private readonly ICheckingService _checkingService;
        private readonly ILogger<AkkaController> _logger;

        public AkkaController(ICheckingService actorRef, ILogger<AkkaController> logger)
        {
            _checkingService = actorRef;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> DemoAkka([FromBody] RequestMessage request)
        {
            return Ok(await _checkingService.Actor.Ask(request));
        }
    }
}