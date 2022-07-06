
using CleanArchitecture.Application.Details.Commands.CreateDetail;
using CleanArchitecture.Application.Details.Queries.GetAllDetail;
using CleanArchitecture.Application.Details.Commands.UpdateDetail;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Application.Details.Commands.DeleteDetail;

namespace CleanArchitecture.WebUI.Controllers;

public class DetailsController : ApiControllerBase

{
    [HttpPost]
    public async Task<ActionResult<int>>Create (CreateDetailCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var Details = await Mediator.Send(new GetAllDetailQuery());
        return Ok(Details);

    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateDetailCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteDetailCommand { Id = id });
            
        return NoContent();
    }
}