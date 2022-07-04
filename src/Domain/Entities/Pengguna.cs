

namespace CleanArchitecture.Domain.Entities;
public  class Pengguna
{
    public string UserName { get; set; }

    public byte[] PasswordHash { get; set; }

    public byte[] PasswordSalt { get; set; }
}
