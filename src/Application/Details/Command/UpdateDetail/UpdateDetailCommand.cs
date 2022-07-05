
using System.Reflection.Metadata;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;

using CleanArchitecture.Domain.Entities;
using MediatR;

public class UpdateDetailCommand : IRequest
{
    public int Id { get; set; }
    public string? JenisBahanBakar { get; set; }

    public string? JumlahTempatDuduk { get; set; }

    public string? KunciCadangan { get; set; }

    public string? GaransiPabrik { get; set; }

    public string? TanggalRegistrasi { get; set; }

    public string? Warna { get; set; }

    public string? BukuServis { get; set; }

    public string? MasaBerlakuStnk { get; set; }
}
public class UpdateDetailCommandHandler : IRequestHandler<UpdateDetailCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateDetailCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Details
        .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Detail), request.Id);
        }

        entity.JenisBahanBakar = request.JenisBahanBakar;
        entity.JumlahTempatDuduk = request.JumlahTempatDuduk;

        entity.KunciCadangan = request.KunciCadangan;
        entity.GaransiPabrik = request.GaransiPabrik;
        entity.TanggalRegistrasi = request.TanggalRegistrasi;
        entity.Warna = request.Warna;
        entity.BukuServis = request.BukuServis;
        entity.MasaBerlakuStnk = request.MasaBerlakuStnk;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}