

using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain.Entities;

public class Kategoriku
{
    [Key]
    public int Id {get;set;}

    public string Nama {get;set;}

    public List<Mobil> Mobil {get; set;}
}