using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Reflection.Controllers;

[Controller]
public class HealthCheck(ILogger<HealthCheck> logger) : ControllerBase
{
    private readonly ILogger<HealthCheck> _logger = logger;

    [HttpGet, Route("api/healthcheck")]
    public IActionResult Get()
    {
        _logger.LogInformation("Healthz");
        return Ok("I'm ok");
    }
}