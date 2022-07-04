
using CleanArchitecture.Application.Details.Commands.CreateDetail;  
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;

public class DetailsController : ApiControllerBase

{
    [HttpPost]
    public async Task<ActionResult<int>>Create (CreateDetailCommand command)
    {
        return await Mediator.Send(command);
    }
    
}