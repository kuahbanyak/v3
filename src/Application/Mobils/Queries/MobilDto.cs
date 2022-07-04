using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Mobils.Queries.GetAllMobil;

public class MobilDto : IMapFrom<Mobil>
{
    public MobilDto()
    {

    }
     public Guid Id {get;set;}

    public string Merk {get;set;}

    public int Price {get; set;}

    public string Lokasi {get; set;}

    public Kategoriku Kategoriku {get;set;}


    public Detail Detail {get;set;}

}