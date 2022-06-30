

using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations;

public  class DetailConfiguration : IEntityTypeConfiguration<Detail>
{
    public void Configure(EntityTypeBuilder<Detail> builder)
    {
        builder.Property(c => c.JenisBahanBakar)
        .HasMaxLength(40)
        .IsRequired();

        builder.Property(c => c.JumlahTempatDuduk)
        .HasMaxLength(40)
        .IsRequired();

        builder.Property(c => c.KunciCadangan)
        .HasMaxLength(40)
        .IsRequired();

        builder.Property(c => c.GaransiPabrik)
        .HasMaxLength(40)
        .IsRequired();

        builder.Property(c => c.TanggalRegistrasi)
        .HasMaxLength(40)
        .IsRequired();

        builder.Property(c => c.Warna)
        .HasMaxLength(40)
        .IsRequired();

        builder.Property(c => c.BukuServis)
        .HasMaxLength(40)
        .IsRequired();

        builder.Property(c => c.MasaBerlakuStnk)
        .HasMaxLength(40)
        .IsRequired();
    }
}