
using System.Reflection.Metadata;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Details.Commands.CreateDetail;

public class CreateDetailCommand : IRequest<int>
{
    public string? JenisBahanBakar {get; set;}

    public string? JumlahTempatDuduk{get; set;}

    public string? KunciCadangan {get; set;}

    public string? GaransiPabrik {get; set;}

    public string TanggalRegistrasi {get; set;}

    public string? Warna {get; set;}

    public string? BukuServis {get;set;}

    public string? MasaBerlakuStnk {get;set;}
}

public class CreateDetailCommandHandler : IRequestHandler<CreateDetailCommand , int>
{
    private readonly IApplicationDbContext _context;

    public CreateDetailCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<int> Handle(CreateDetailCommand request , CancellationToken cancellationToken)
    {
        var entity = new Detail
        {
            JenisBahanBakar = request.JenisBahanBakar,
            JumlahTempatDuduk = request.JumlahTempatDuduk,
            KunciCadangan = request.KunciCadangan,
            GaransiPabrik = request.GaransiPabrik,
            TanggalRegistrasi = request.TanggalRegistrasi,
            Warna = request.Warna,
            BukuServis = request.BukuServis,
            MasaBerlakuStnk = request.MasaBerlakuStnk
        };
        _context.Details.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
