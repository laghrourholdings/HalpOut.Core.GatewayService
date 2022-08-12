using CommonLibrary.Core;
using CommonLibrary.Repositories;
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
    
    
}