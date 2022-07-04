using System.Security.Cryptography;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PenggunaController : ControllerBase
{
    public static Pengguna pengguna = new Pengguna();

    [HttpPost("Register")]
    public  async Task<ActionResult<Pengguna>> Register (PenggunaDto request)
    {
        CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

        pengguna.UserName = request.UserName;
        pengguna.PasswordHash = passwordHash;
        pengguna.PasswordSalt = passwordSalt;

        return Ok(pengguna);
    }

    private void CreatePasswordHash(string password , out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

        }    
    }
}
