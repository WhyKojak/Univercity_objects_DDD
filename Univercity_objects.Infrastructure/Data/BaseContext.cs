using Microsoft.EntityFrameworkCore;
using Univercity_objects.Domain;


namespace Univercity_objects.Infrastructure;

public class BaseContext : DbContext
{
    public DbSet<BaseEntity> BaseEntities { get; }
    public DbSet<Auditory> Auditories { get; set; }
    public DbSet<CafedraEntity> CafedraEntities { get; set; }
    public DbSet<AuditoryComponentEntity> AuditoryComponentEntities { get; }
    public DbSet<ComputerEntity> ComputerEntities { get; set; }
    public DbSet<FurnitureEntity> FurnitureEntities { get; set; }  
    public DbSet<MultimediaEqumentEntity> MultimediaEqumentEntities { get; set; }

    public BaseContext(DbContextOptions<BaseContext> options) : base(options) 
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
        modelBuilder.Entity<BaseEntity>().UseTpcMappingStrategy();
        modelBuilder.Entity<Auditory>();
        modelBuilder.Entity<CafedraEntity>();
        modelBuilder.Entity<AuditoryComponentEntity>().UseTpcMappingStrategy();
        modelBuilder.Entity<ComputerEntity>();
        modelBuilder.Entity<FurnitureEntity>();
        modelBuilder.Entity<MultimediaEqumentEntity>();
        base.OnModelCreating(modelBuilder);
    }

}
