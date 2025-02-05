namespace CosmeticSalon.Application.Treatments.ViewModels;

public sealed record class Treatment
{
    public Guid Id { get; init; } = Guid.Empty;
    [Display(Name = "Name")]
    public string Name { get; init; } = string.Empty;
    [Display(Name = "Type")]
    public string Type { get; init; } = string.Empty;
}
