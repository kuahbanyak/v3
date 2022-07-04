using System.Reflection.Metadata;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Mobils.Queries.GetAllMobil;

public class GetAllMobilQueries  : IRequest<MobilVm>
{

}

public class  GetAllMobilQueriesHandler : IRequestHandler<GetAllMobilQueries, MobilVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllMobilQueriesHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<MobilVm> Handle (GetAllMobilQueries request, CancellationToken cancellationToken)
    {
        return new MobilVm
        {
            Lists = await _context.Mobils
                .AsNoTracking()
                .ProjectTo<MobilDto>(_mapper.ConfigurationProvider)
                .OrderBy(i => i.Id)
                .ToListAsync(cancellationToken)
        };
    }
}