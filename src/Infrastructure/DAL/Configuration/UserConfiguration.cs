namespace CosmeticSalon.Infrastructure.DAL.Configuration;

using CosmeticSalon.Domain.Entities;
using CosmeticSalon.Domain.ValueObjects;

internal sealed class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasKey(user => user.Id);

        builder.Property(user => user.Id)
            .HasConversion(id => id.Value, id => new UserId(id));

        builder.Property(x => x.Email)
            .HasConversion(x => x.Value, x => new Email(x))
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(x => x.Role)
            .HasConversion(x => x.Value, x => new Role(x))
            .IsRequired()
            .HasMaxLength(100);
    }
}
