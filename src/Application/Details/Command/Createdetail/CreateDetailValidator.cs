
using System.Data;
using CleanArchitecture.Application.Common.Interfaces;
using FluentValidation;

namespace CleanArchitecture.Application.Details.Commands.CreateDetail;

public class CreateDetailCommandValidator : AbstractValidator<CreateDetailCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateDetailCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(k =>k.JenisBahanBakar)
        .NotEmpty().WithMessage("Bahan Bakar harus di isi")
        .MaximumLength(30).WithMessage("Gelap");

        RuleFor(k => k.JumlahTempatDuduk)
        .NotEmpty().WithMessage("Jumlah Tempat duduk Harus di isi!")
        .MaximumLength(30).MaximumLength(30);

        RuleFor(k => k.KunciCadangan)
        .NotEmpty().WithMessage("Jumlah Tempat duduk Harus di isi!")
        .MaximumLength(30).MaximumLength(30);

        RuleFor(k => k.GaransiPabrik)
        .NotEmpty().WithMessage("Jumlah Tempat duduk Harus di isi!")
        .MaximumLength(30).MaximumLength(30);
        
        RuleFor(k => k.TanggalRegistrasi)
        .NotEmpty().WithMessage("Jumlah Tempat duduk Harus di isi!")
        .MaximumLength(30).MaximumLength(30);
        
        RuleFor(k => k.Warna)
        .NotEmpty().WithMessage("Jumlah Tempat duduk Harus di isi!")
        .MaximumLength(30).MaximumLength(30);
        
        RuleFor(k => k.BukuServis)
        .NotEmpty().WithMessage("Jumlah Tempat duduk Harus di isi!")
        .MaximumLength(30).MaximumLength(30);
        
        RuleFor(k => k.MasaBerlakuStnk)
        .NotEmpty().WithMessage("Jumlah Tempat duduk Harus di isi!")
        .MaximumLength(30).MaximumLength(30);
    }
    

}

