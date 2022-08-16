using CommonLibrary.AspNetCore;
using CommonLibrary.Core;
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;

namespace GatewayService.Controllers.v1;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ApiController]
public class ObjectsController : ControllerBase
{
    private readonly IObjectRepository<IIObject> _objectRepository;
    private readonly ILogger _logger;

    public ObjectsController(IObjectRepository<IIObject> objectRepository, ILogger logger)
    {
        _objectRepository = objectRepository;
        _logger = logger;
    }
    
    
    [HttpPost()]
    public async Task<IActionResult> CreateObject()
    {
        await _objectRepository.CreateAsync(null);
        return Ok("");
    }
    
    [HttpGet()]
    public async Task<IActionResult> GetAllObjects()
    {
        var objs = await _objectRepository.GetAllAsync();
        return Ok(objs);
    }
}