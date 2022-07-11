/* 
using System;
using MediatR;

namespace CleanArchitecture.Application.Penggunas.Commands.RegisterPengguna;

public class RegisterCommand : IRequest<Guid>
{
    public string Email {get; set;}

    public byte [] PasswordHash {get; set;}

    public byte [] PasswordSalt {get; set;}
}

public class  */