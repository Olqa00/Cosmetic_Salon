namespace CosmeticSalon.Infrastructure.DAL.Configuration;

using CosmeticSalon.Domain.Entities;

internal sealed class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasKey(user => user.Id);

        builder.Property(user => user.Id)
            .HasConversion(id => id.Value, id => new UserId(id));
    }
}
