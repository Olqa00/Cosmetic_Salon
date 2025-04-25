namespace CosmeticSalon.Infrastructure.Identity;

using CosmeticSalon.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

internal sealed class IdentityUserContext : IdentityDbContext<UserDbModel, RoleDbModel, Guid>
{
    public DbSet<RoleDbModel> Roles { get; set; }
    public DbSet<UserDbModel> Users { get; set; }

    public IdentityUserContext(DbContextOptions<IdentityUserContext> dbContextOptions)
        : base(dbContextOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
