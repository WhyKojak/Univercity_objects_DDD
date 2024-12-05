using Microsoft.EntityFrameworkCore;


namespace Univercity_objects.Infrastructure;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) { }
}
