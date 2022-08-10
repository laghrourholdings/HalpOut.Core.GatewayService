using CommonLibrary.Contracts.Gateway_Internal_Contracts;
using CommonLibrary.Entities.InternalService;
using CommonLibrary.Implementations.InternalService;
using CommonLibrary.Repository;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace GatewayService.Controllers;

[Route("[controller]")]
[ApiController]
public class GatewayController : ControllerBase
{
    private readonly IObjectRepository<IObject> _objectRepository;
    
    public GatewayController(IObjectRepository<IObject> objectRepository)
    {
        _objectRepository = objectRepository;
    }
    
    [HttpPost("object")]
    public async Task<IActionResult> CreateObject()
    {
        var obj = new IIObject
        {
            Id = Guid.NewGuid(),
            CreationDate = DateTimeOffset.Now,
            IsDeleted = false,
            DeletedDate = default,
            IsSuspended = false,
            SuspendedDate = default,
            LogHandleId = default,
            Descriptor = null
        };
        await _objectRepository.CreateAsync(obj);
        Console.WriteLine($"Sending Object {obj.Id.ToString()} created at {obj.CreationDate.ToString()} for verification...");
        return Ok($"Sending Object {obj.Id.ToString()} created at {obj.CreationDate.ToString()} for verification...");
    }
}