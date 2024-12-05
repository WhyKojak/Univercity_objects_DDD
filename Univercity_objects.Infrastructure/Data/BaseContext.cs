using Microsoft.EntityFrameworkCore;
using Univercity_objects.Domain;


namespace Univercity_objects.Infrastructure;

public class BaseContext : DbContext
{
    public BaseContext()
    {
    }

    public BaseContext(DbContextOptions<BaseContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) { }

    public DbSet<BaseEntity> BaseEntities { get; set; }
}
