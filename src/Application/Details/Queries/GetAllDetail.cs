
using System.Reflection.Metadata;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Details.Queries.GetAllDetail;

public class GetAllDetailQuery : IRequest<DetailVm>
{

}
public class GetAllDetailQueryHandler : IRequestHandler<GetAllDetailQuery, DetailVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllDetailQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<DetailVm> Handle(GetAllDetailQuery request, CancellationToken cancellationToken)
    {
        return new DetailVm
        {
            Lists = await _context.Details
            .AsNoTracking()
            .ProjectTo<DetailDto>(_mapper.ConfigurationProvider)
            .OrderBy(i => i.Id)
            .ToListAsync(cancellationToken)
        };
    }
}