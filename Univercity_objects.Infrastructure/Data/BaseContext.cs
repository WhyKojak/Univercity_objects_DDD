using Microsoft.EntityFrameworkCore;
using Univercity_objects.Domain;


namespace Univercity_objects.Infrastructure;

public class BaseContext : DbContext
{
    public DbSet<BaseEntity> BaseEntities { get; set; }
    public DbSet<Auditory> Auditories { get; set; }
    public DbSet<CafedraEntity> CafedraEntities { get; set; }
    public DbSet<AuditoryComponentEntity> AuditoryComponentEntities { get; set; }
    public DbSet<ComputerEntity> ComputerEntities { get; set; }
    public DbSet<FurnitureEntity> FurnitureEntities { get; set; }  
    public DbSet<MultimediaEqumentEntity> MultimediaEqumentEntities { get; set; }

    public BaseContext(DbContextOptions<BaseContext> options) : base(options) 
    {
        //Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
        modelBuilder.Entity<BaseEntity>().ToTable("BaseEntity");
        modelBuilder.Entity<Auditory>().ToTable("Auditory");
        modelBuilder.Entity<CafedraEntity>().ToTable("CafedraEntity");
        modelBuilder.Entity<AuditoryComponentEntity>().ToTable("AuditoryComponentEntity");
        modelBuilder.Entity<ComputerEntity>().ToTable("ComputerEntity");
        modelBuilder.Entity<FurnitureEntity>().ToTable("FurnitureEntity");
        modelBuilder.Entity<MultimediaEqumentEntity>().ToTable("MultimediaEqumentEntity");
        base.OnModelCreating(modelBuilder);
    }

}
