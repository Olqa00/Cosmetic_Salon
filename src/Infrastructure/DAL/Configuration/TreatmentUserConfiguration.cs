namespace CosmeticSalon.Infrastructure.DAL.Configuration;

using CosmeticSalon.Infrastructure.DAL.Models;

internal sealed class TreatmentUserConfiguration : IEntityTypeConfiguration<TreatmentUserDbModel>
{
    public void Configure(EntityTypeBuilder<TreatmentUserDbModel> builder)
    {
        builder.HasKey(treatmentUser => treatmentUser.RecordId);

        builder.HasOne(treatmentUser => treatmentUser.Treatment)
            .WithMany(treatment => treatment.TreatmentUsers)
            .HasForeignKey(treatmentUser => treatmentUser.RecordId)
            ;
    }
}
