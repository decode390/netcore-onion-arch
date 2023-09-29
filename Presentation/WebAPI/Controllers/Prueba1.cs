using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PruebaController : ControllerBase
{

    private readonly ILogger<PruebaController> _logger;

    public PruebaController(ILogger<PruebaController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<int> Get()
    {
      return Enumerable.Range(1,2).ToList();
    }
}
