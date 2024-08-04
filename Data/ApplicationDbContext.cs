using ConstructionTransaction.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Project> Projects { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<loginuseractivity> loginuseractivity { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<loginuseractivity>(entity =>
        {
            entity.HasKey(e => e.loginid);
            entity.Property(e => e.loginid).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.logintimestamp).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });
    }
}