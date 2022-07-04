
using CleanArchitecture.Application.Kategori.Commands.CreateKategori;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;

public class KategoriController : ApiControllerBase

{
    [HttpPost]
    public async Task<ActionResult<int>>Create (CreateKategoriCommand command)
    {
        return await Mediator.Send(command);
    }
    
}