namespace CosmeticSalon.Infrastructure.Identity.Configuration;

using CosmeticSalon.Infrastructure.Identity.Models;

internal sealed class RoleConfiguration : IEntityTypeConfiguration<RoleDbModel>
{
    public void Configure(EntityTypeBuilder<RoleDbModel> builder)
    {
        builder.HasKey(user => user.Id);
    }
}
