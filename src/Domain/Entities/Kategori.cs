

using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain.Entities;

public class Kategori 
{
    [Key]
    public int Id {get;set;}

    public string Nama {get;set;}
}