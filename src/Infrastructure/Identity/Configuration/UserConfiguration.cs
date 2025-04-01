namespace CosmeticSalon.Infrastructure.Identity.Configuration;

using CosmeticSalon.Domain.Entities;
using CosmeticSalon.Domain.ValueObjects;

internal sealed class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasKey(user => user.Id);

        builder.Property(user => user.Id)
            .HasConversion(id => id.Value, id => new UserId(id));

        builder.HasIndex(user => user.Username).IsUnique();

        builder.Property(user => user.Username)
            .IsRequired()
            .HasMaxLength(30);

        builder.HasIndex(user => user.Email).IsUnique();

        builder.Property(user => user.Email)
            .HasConversion(email => email.Value, email => new Email(email))
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(user => user.Role)
            .HasConversion(role => role.Value, role => new Role(role))
            .IsRequired()
            .HasMaxLength(100);

        builder.HasMany(user => user.Treatments)
            .WithMany(treatment => treatment.Employees)
            ;
    }
}
