using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain.Entities;

public  class PenggunaRegister{
    [Required,EmailAddress]
    [Key]
    public string Email{get; set;} = string.Empty;

    [Required, MinLength(6)]
    public string Password {get; set;} = string.Empty;
    [Required, Compare("Password")]
    public string ConfirmPassword {get; set;} = string.Empty;

    public string UserName {get; set;} = string.Empty;
}