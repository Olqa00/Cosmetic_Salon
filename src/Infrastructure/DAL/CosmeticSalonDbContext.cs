namespace CosmeticSalon.Infrastructure.DAL;

using CosmeticSalon.Infrastructure.DAL.Configuration;
using CosmeticSalon.Infrastructure.DAL.Models;

internal sealed class CosmeticSalonDbContext : DbContext
{
    public DbSet<TreatmentDbModel> Treatments { get; set; }
    public DbSet<TreatmentUserDbModel> TreatmentUsers { get; set; }

    public CosmeticSalonDbContext(DbContextOptions<CosmeticSalonDbContext> dbContextOptions)
        : base(dbContextOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TreatmentConfiguration());
        modelBuilder.ApplyConfiguration(new TreatmentUserConfiguration());
    }
}
