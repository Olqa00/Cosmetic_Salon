namespace CosmeticSalon.Infrastructure.Identity.Configuration;

using CosmeticSalon.Infrastructure.Identity.Models;

internal sealed class UserConfiguration : IEntityTypeConfiguration<UserDbModel>
{
    public void Configure(EntityTypeBuilder<UserDbModel> builder)
    {
        builder.HasKey(user => user.Id);

        //builder.HasOne(u => u.Role)
        //    .WithMany(r => r.Users)
        //    .HasForeignKey(u => u.RoleId)
        //    .IsRequired();
    }
}
