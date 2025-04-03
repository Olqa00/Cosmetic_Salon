namespace CosmeticSalon.Infrastructure.DAL.Configuration;

using CosmeticSalon.Infrastructure.DAL.Models;

internal sealed class TreatmentConfiguration : IEntityTypeConfiguration<TreatmentDbModel>
{
    public void Configure(EntityTypeBuilder<TreatmentDbModel> builder)
    {
        builder.HasKey(treatment => treatment.RecordId);

        builder.HasMany(treatment => treatment.TreatmentUsers)
            .WithOne(treatment => treatment.Treatment)
            .HasForeignKey(treatmentUser => treatmentUser.RecordId)
            ;
    }
}
