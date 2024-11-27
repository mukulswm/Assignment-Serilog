using ClassLibrary1;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_Serilog.Controllers
{
    [ApiController]
    [Route("api/demo")]
    public class DemoController : ControllerBase
    {
        private readonly IDemoService _service;
        private readonly ILogger<DemoController> _logger;

        public DemoController(IDemoService service, ILogger<DemoController> logger) {
            _service = service;
            _logger = logger;   
        }

        [HttpGet("doSomething")]
        public IActionResult DoSomethingEndpoint()
        {
            _logger.LogInformation("Process start");
            _service.DoSomething();
            _logger.LogInformation("Process end");
            return Ok("success");
        }
    }
}
