﻿using CommonLibrary.Contracts.Gateway_Internal_Contracts;
using CommonLibrary.Entities.InternalService;
using CommonLibrary.Repositories;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace GatewayService.Controllers;

[Route("[controller]")]
[ApiController]
public class GatewayController : ControllerBase
{
    private readonly IObjectRepository _objectRepository;
    
    public GatewayController(IObjectRepository objectRepository)
    {
        _objectRepository = objectRepository;
    }
    
    
}