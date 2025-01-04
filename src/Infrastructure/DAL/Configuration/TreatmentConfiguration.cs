namespace CosmeticSalon.Infrastructure.DAL.Configuration;

using CosmeticSalon.Domain.Entities;

internal sealed class TreatmentConfiguration : IEntityTypeConfiguration<TreatmentEntity>
{
    public void Configure(EntityTypeBuilder<TreatmentEntity> builder)
    {
        builder.HasKey(treatment => treatment.Id);

        builder.Property(treatment => treatment.Id)
            .HasConversion(id => id.Value, id => new TreatmentId(id));
    }
}
