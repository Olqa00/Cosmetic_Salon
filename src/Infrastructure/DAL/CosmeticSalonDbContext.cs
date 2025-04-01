namespace CosmeticSalon.Infrastructure.DAL;

using CosmeticSalon.Domain.Entities;
using CosmeticSalon.Infrastructure.DAL.Configuration;

internal sealed class CosmeticSalonDbContext : DbContext
{
    public DbSet<TreatmentEntity> Treatments { get; set; }

    public CosmeticSalonDbContext(DbContextOptions<CosmeticSalonDbContext> dbContextOptions)
        : base(dbContextOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TreatmentConfiguration());
    }
}
