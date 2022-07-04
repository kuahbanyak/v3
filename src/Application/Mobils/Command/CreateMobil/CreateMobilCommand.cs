using System.Xml;
using System.Reflection.Metadata;
using System.Dynamic;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Mobils.Commands.CreateMobil;

public class CreateMobilCommand : IRequest<Guid>
{
    public string? Merk {get;set;}

    public int Price {get; set;}

    public string? Lokasi {get;set;}

    public int KategoriId {get;set;}

    public int DetailId {get;set;} 
}
public class CreateMobilCommandHandler : IRequestHandler<CreateMobilCommand , Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateMobilCommandHandler (IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Guid> Handle(CreateMobilCommand request, CancellationToken cancellationToken)
    {
        var entity = new Mobil
        {
            Merk = request.Merk,
            Price = request.Price,
            Lokasi = request.Lokasi,
            KategoriId = request.KategoriId,
            DetailId = request.DetailId
        };
        _context.Mobils.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;

    }

}
