using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CleanArchitecture.WebUI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PenggunaController : ControllerBase
{
    public static Pengguna pengguna = new Pengguna();
    private readonly IConfiguration _configuration;

    public PenggunaController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost("Register")]
    public  async Task<ActionResult<Pengguna>> Register (PenggunaDto request)
    {
        CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

        pengguna.UserName = request.UserName;
        pengguna.PasswordHash = passwordHash;
        pengguna.PasswordSalt = passwordSalt;

        return Ok(pengguna);
    }


    [HttpPost("Login")]
    public async Task<ActionResult<string>>Login (PenggunaDto request)
    {
        if (pengguna.UserName != request.UserName)
        {
            return BadRequest("G ada");

        }
        if (!VerifPasswordHash(request.Password, pengguna.PasswordHash, pengguna.PasswordSalt))
        {
            return BadRequest("Eror kan");
        }
        string token = CreateToken(pengguna);
        return Ok(token);
    }


    private string CreateToken(Pengguna pengguna)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, pengguna.UserName),
            new Claim(ClaimTypes.Role, "Admin")
        };
        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creds);

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }

    private void CreatePasswordHash(string password , out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

        }    
    }

    private bool VerifPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512(pengguna.PasswordSalt))
        {
            var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computeHash.SequenceEqual(passwordHash);
        }
    }
}
