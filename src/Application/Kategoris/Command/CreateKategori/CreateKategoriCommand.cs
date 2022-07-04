
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Kategori.Commands.CreateKategori;

public class CreateKategoriCommand  : IRequest <int>
{
    public string? Nama {get;set;}

}
public class CreateKategoriCommandHandler : IRequestHandler <CreateKategoriCommand , int>
{
    private readonly IApplicationDbContext _context;

    public CreateKategoriCommandHandler (IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<int> Handle (CreateKategoriCommand request, CancellationToken cancellationToken)
    {
        var entity = new Kategoriku
        {
            Nama = request.Nama
        };
        _context.Kategorikus.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}