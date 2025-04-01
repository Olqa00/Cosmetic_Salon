﻿namespace CosmeticSalon.Infrastructure.Identity.Models;

using CosmeticSalon.Domain.Exceptions;
using CosmeticSalon.Domain.ValueObjects;

public sealed class RoleModel : IdentityRole
{
    public RoleModel(string name)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length > 30)
        {
            throw new InvalidRoleException(name);
        }

        if (SystemRoles.All.Contains(name) is false)
        {
            throw new InvalidRoleException(name);
        }

        this.Name = name;
    }
}
