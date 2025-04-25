namespace CosmeticSalon.Infrastructure.DAL.Models;

public sealed class TreatmentDbModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int RecordId { get; set; }
    public List<TreatmentUserDbModel> TreatmentUsers { get; set; } = [];
    public string Type { get; set; }
}
