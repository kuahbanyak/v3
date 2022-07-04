

using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations;

public class KategoriConfiguration : IEntityTypeConfiguration<Kategoriku>
{
    public void Configure(EntityTypeBuilder<Kategoriku> builder)
    {
        builder.Property(c => c.Nama)
        .HasMaxLength(20)
        .IsRequired();
    }
}