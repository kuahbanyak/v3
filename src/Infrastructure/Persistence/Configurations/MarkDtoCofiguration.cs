/* 

using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations;

public class MarkDtoConfiguration : IEntityTypeConfiguration<MarkDto>
{
    public void Configure(EntityTypeBuilder<MarkDto>builder)
    {
        builder.Property(f => f.UserName)
        .HasMaxLength(20)
        .IsRequired();

        builder.Property(f => f.Password)
        .HasMaxLength(20)
        .IsRequired();
    }
} */