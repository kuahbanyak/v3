
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;

public class AccountsController : ApiControllerBase
{

    public static Account account = new Account();
    [HttpPost("Register")]
    public async Task<ActionResult<Account>> Register (MarkDto request )
    {
        CreatePasswordHash(request.Password, out byte[] passwordHash, out byte [] passwordSalt);

        account.UserName = request.UserName;
        account.PasswordHash = passwordHash;
        account.PasswordSalt = passwordSalt;

        return Ok(account);
    }

    [HttpPost("Login")]
    public async Task<ActionResult<string>>Login (MarkDto request)
    {
        if (account.UserName != request.UserName)
        {
            return BadRequest("Not");
        }
        return Ok("NBC");
        if (!VerifyPasswordHash(request.Password, account.PasswordHash, account.PasswordSalt))
        {
            return BadRequest("wrong");
        }
        return Ok("DOne");
    }
    
    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }




    private void  CreatePasswordHash (string password , out byte[]passwordHash, out byte[]passwordSalt)
    {
        using(var hmac = new HMACSHA512() )
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
    
  

}