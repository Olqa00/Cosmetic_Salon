namespace CosmeticSalon.Infrastructure.Identity;

using CosmeticSalon.Domain.Entities;
using CosmeticSalon.Infrastructure.Identity.Configuration;
using CosmeticSalon.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

internal sealed class UserDbContext : IdentityDbContext<UserIdentityModel, RoleModel, string>
{
    public DbSet<UserEntity> UserEntities { get; set; }

    public UserDbContext(DbContextOptions<UserDbContext> dbContextOptions)
        : base(dbContextOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}
