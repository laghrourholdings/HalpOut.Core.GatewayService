using CommonLibrary.Contracts.Gateway_Internal_Contracts;
using CommonLibrary.Entities.InternalService;
using CommonLibrary.Repositories;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace GatewayService.Controllers;

[Route("[controller]")]
[ApiController]
public class ObjectsController : ControllerBase
{
    private readonly IObjectRepository _objectRepository;
    
    public ObjectsController(IObjectRepository objectRepository)
    {
        _objectRepository = objectRepository;
    }
    
    
    [HttpPost()]
    public async Task<IActionResult> CreateObject()
    {
        await _objectRepository.CreateAsync(null);
        return Ok("");
    }
}