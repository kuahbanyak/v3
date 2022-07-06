

using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain.Entities;
public  class Pengguna
{
    [Key]
    public Guid ID {get; set;}
    public string Email { get; set; }

    public byte[] PasswordHash { get; set; }

    public byte[] PasswordSalt { get; set; }

    public string UserName {get; set;}
}
