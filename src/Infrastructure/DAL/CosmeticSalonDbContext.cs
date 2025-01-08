namespace CosmeticSalon.Infrastructure.DAL;

using CosmeticSalon.Domain.Entities;

internal sealed class CosmeticSalonDbContext : DbContext
{
    public DbSet<TreatmentEntity> Treatments { get; set; }
    public DbSet<UserEntity> Users { get; set; }

    public CosmeticSalonDbContext(DbContextOptions<CosmeticSalonDbContext> dbContextOptions)
        : base(dbContextOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}
