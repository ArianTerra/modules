using Microsoft.EntityFrameworkCore;
using Task1.DataAccess.DomainModels;

namespace Task1.DataAccess;

public class DatabaseContext : DbContext
{
    public DbSet<Article> Articles { get; set; }

    public DatabaseContext(DbContextOptions options) : base(options) {}

    //Generates random articles using Bogus data generator
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var randomArticles = ArticleDatabaseSeeder.GenerateArticles(100);
        modelBuilder.Entity<Article>().HasData(randomArticles);
    }
}