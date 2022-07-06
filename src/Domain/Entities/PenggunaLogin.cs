

using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain.Entities;
public class PenggunaLogin
{
    [Required, EmailAddress]
    [Key]
    public string Email { get; set; } = string.Empty;
    [Required, MinLength(6)]
    public string Password { get; set; } = string.Empty;
}
