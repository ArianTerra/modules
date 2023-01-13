using System.Data.Entity;
using ORM.Models;

namespace ORM;

public class CinemaContext : DbContext
{
    public CinemaContext() : base()
    {

    }

    public DbSet<Film> Films { get; set; }

    public DbSet<Actor> Actors { get; set; }

    public DbSet<Comment> Comments { get; set; }
}