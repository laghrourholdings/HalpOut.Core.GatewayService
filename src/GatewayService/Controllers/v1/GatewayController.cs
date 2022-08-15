﻿using CommonLibrary.AspNetCore;
using CommonLibrary.Core;
using Microsoft.AspNetCore.Mvc;

namespace GatewayService.Controllers.v1;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ApiController]
public class GatewayController : ControllerBase
{
    /*
        public PicturesController(ILogger<PicturesController> logger){ }
        
        public IActionResult GetPictures([FromServices] IDatabaseService databaseService){
            return Ok(databaseService.GetPictures());
        }
        
        public IActionResult UploadPicture([FromForm] IFormFile file, [FromServices] IPictureService pictureService){
            return Ok(pictureService.Upload(file));
        }
     */
    private readonly IObjectRepository<IObject> _objectRepository;
    
    public GatewayController(IObjectRepository<IObject> objectRepository)
    {
        _objectRepository = objectRepository;
    }
    
    
}