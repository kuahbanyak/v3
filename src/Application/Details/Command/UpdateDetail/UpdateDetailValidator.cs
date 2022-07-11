
using System.Data;
using CleanArchitecture.Application.Common.Interfaces;
using FluentValidation;

namespace CleanArchitecture.Application.Details.Commands.UpdateDetail;

public class UpdateDetailCommandValidator : AbstractValidator<UpdateDetailCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateDetailCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(k =>k.JenisBahanBakar)
        .NotEmpty().WithMessage("Bahan Bakar harus di isi")
        .MaximumLength(30).WithMessage("Gelap");

        RuleFor(k => k.JumlahTempatDuduk)
        .NotEmpty().WithMessage("Jumlah Tempat duduk Harus di isi!")
        .MaximumLength(30).MaximumLength(30);

        RuleFor(k => k.KunciCadangan)
        .NotEmpty().WithMessage("Kunci Cadangan Harus di isi!")
        .MaximumLength(30).MaximumLength(30);

        RuleFor(k => k.GaransiPabrik)
        .NotEmpty().WithMessage("Garansi Pabrik Harus di isi!")
        .MaximumLength(30).MaximumLength(30);
        
        RuleFor(k => k.TanggalRegistrasi)
        .NotEmpty().WithMessage("Tanggal Regis Harus di isi!")
        .MaximumLength(30).MaximumLength(30);
        
        RuleFor(k => k.Warna)
        .NotEmpty().WithMessage("Warna Harus di isi!")
        .MaximumLength(30).MaximumLength(30);
        
        RuleFor(k => k.BukuServis)
        .NotEmpty().WithMessage("Buku Servis Harus di isi!")
        .MaximumLength(30).MaximumLength(30);
        
        RuleFor(k => k.MasaBerlakuStnk)
        .NotEmpty().WithMessage("Masa Berlaku Harus di isi!")
        .MaximumLength(30).MaximumLength(30);
    }
    

}

