﻿namespace CosmeticSalon.Infrastructure.Security;

using CosmeticSalon.Application.Security;

internal sealed class PasswordManager : IPasswordManager
{
    public string Secure(string password)
    {
        throw new NotImplementedException();
    }

    public bool Validate(string password, string securedPassword)
    {
        throw new NotImplementedException();
    }
}
