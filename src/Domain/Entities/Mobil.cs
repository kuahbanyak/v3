

namespace CleanArchitecture.Domain.Entities;

public class Mobil 
{
    public Guid Id {get;set;}

    public string Merk {get;set;}

    public int Price {get; set;}

    public string Lokasi {get; set;}

    public Kategori Kategori {get;set;}

    public int KategoriId   {get;set;}

    public Detail Detail {get;set;}

    public int DetailId {get;set;}
}