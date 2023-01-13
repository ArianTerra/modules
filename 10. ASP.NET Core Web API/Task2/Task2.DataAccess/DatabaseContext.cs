using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Task2.DataAccess.DomainModels;

namespace Task2.DataAccess;

public class DatabaseContext : IdentityDbContext
{
    public DbSet<ArticleMaterial> Articles { get; set; }

    public DatabaseContext(DbContextOptions options) : base(options) {}

    //Generates random articles using Bogus data generator
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var randomArticles = DatabaseSeeder.GenerateArticles(100);
        modelBuilder.Entity<ArticleMaterial>().HasData(randomArticles);

        //model configuration
        // modelBuilder.Entity<ArticleMaterial>()
        //     .HasOne(x => x.CreatedBy)
        //     .WithMany()
        //     .HasForeignKey(x => x.CreatedById);
        //
        // modelBuilder.Entity<ArticleMaterial>()
        //     .HasOne(x => x.UpdatedBy)
        //     .WithMany()
        //     .HasForeignKey(x => x.UpdatedById);
    }
}