using Example.DataAccess.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace Example.DataAccess;

public class DatabaseContext : DbContext
{
    public DbSet<Contact> Contacts { get; set; }

    public DatabaseContext(DbContextOptions options) : base(options) {}
}