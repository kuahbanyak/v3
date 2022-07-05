
using System.Reflection.Metadata;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Details.Commands.DeleteDetail;

public class DeleteDetailCommand : IRequest 
{
    public int Id {get;set;}

}

public class DeleteDetailCommandHandler : IRequestHandler<DeleteDetailCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteDetailCommandHandler (IApplicationDbContext context)
    {
        _context = context;
    }

    public  async Task<Unit> Handle(DeleteDetailCommand request , CancellationToken cancellationToken)
    {
        var entity = await _context.Details
        .Where(d => d.Id == request.Id)
        .SingleOrDefaultAsync(cancellationToken);

        if(entity == null)
        {
            throw new NotFoundException(
                nameof(Details), request.Id);
        }
        _context.Details.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
