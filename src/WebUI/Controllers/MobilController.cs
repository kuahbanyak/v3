using CleanArchitecture.Application.Mobils.Commands.CreateMobil;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;

public class MobilsController : ApiControllerBase

{
    [HttpPost]
    public async Task<ActionResult<Guid>>Create (CreateMobilCommand command)
    {
        return await Mediator.Send(command);
    }
        
}