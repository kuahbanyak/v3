using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    DbSet<Kategoriku>   Kategorikus {get;}

    DbSet<Mobil>Mobils {get;}

    DbSet<Detail>Details{get;}

    DbSet<Pengguna>Penggunas {get;}
    DbSet<PenggunaLogin> PenggunaLogins {get;}

    DbSet<PenggunaRegister> PenggunaRegisters {get; }
    /* DbSet<MarkDto>MarkDtos {get;}
 */
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
