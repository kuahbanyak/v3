

using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations;

public class MobilConfiguratuin : IEntityTypeConfiguration<Mobil>
{
    public void Configure(EntityTypeBuilder<Mobil> builder)
    {
        builder.Property(d => d.Merk)
        .HasMaxLength(20)
        .IsRequired();
        
        builder.Property(d =>d.Lokasi)
        .HasMaxLength(20)
        .IsRequired();
    }
}