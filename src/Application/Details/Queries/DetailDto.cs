
using CleanArchitecture.Application.Common.Mappings;

namespace CleanArchitecture.Application.Details.Queries.GetAllDetail;

public class DetailDto : IMapFrom<DetailDto>
{
    public DetailDto()
    {

    }
    public int Id {get; set;}

    public string JenisBahanBakar {get; set;}

    public string JumlahTempatDuduk {get; set;}

    public string KunciCadangan {get; set;}

    public string GaransiPabrik {get;set;}

    public string TanggalRegistrasi {get;set;}

    public string Warna {get;set;}

    public string BukuServis {get; set;}

    public string MasaBerlakuStnk {get; set;}
}