using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CleanArchitecture.WebUI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PenggunasController : ControllerBase
{
    public static Pengguna pengguna = new Pengguna();
    private readonly IConfiguration _configuration;
    private readonly IApplicationDbContext _context;

    public PenggunasController(IConfiguration configuration, IApplicationDbContext context)
    {
        _configuration = configuration;
        _context = context;
    }

    [HttpPost("Register")]
    public  async Task<ActionResult> Register (PenggunaRegister request, CancellationToken cancellationToken)
    {
        if (_context.Penggunas.Any(e =>e.Email == request.Email))
        {
            return BadRequest("User Sudah Ada ");
        }
        CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
        var pengguna = new Pengguna{
        Email= request.Email,
        PasswordHash = passwordHash,
        PasswordSalt = passwordSalt,
        UserName = request.UserName
        };
        _context.Penggunas.Add(pengguna);
        await _context.SaveChangesAsync(cancellationToken);

        return Ok(pengguna);
    }


    [HttpPost("Login")]
    public async Task<ActionResult>Login (PenggunaLogin request, CancellationToken cancellationToken)
    {
        var pengguna = await _context.Penggunas.FirstOrDefaultAsync(e => e.Email == request.Email);
        if (pengguna == null)
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
            new Claim(ClaimTypes.Name, pengguna.Email),
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
        using (var hmac = new HMACSHA512(passwordSalt))
        {
            var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computeHash.SequenceEqual(passwordHash);
        }
    }
}


/* using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace  CleanArchitecture.WebUI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PenggunasController : ControllerBase
{
    [HttpPost("Register")]
    public async Task<ActionResult>Register (PenggunaRegister request)
    {
        return Ok();
    }

    [HttpPost("Login")]
    public async Task<ActionResult> Login (PenggunaLogin request)
    {
        return Ok();
    }
} */