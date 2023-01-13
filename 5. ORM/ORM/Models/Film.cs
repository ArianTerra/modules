using System.Collections;

namespace ORM.Models;

public class Film : BaseEntity
{
    public Film()
    {
        Actors = new HashSet<Actor>();
        Comments = new HashSet<Comment>();
    }

    public string Name { get; set; }

    public int Year { get; set; }

    public string Genre { get; set; }

    public string Country { get; set; }

    public ICollection<Actor> Actors { get; set; } // many to many relation

    public ICollection<Comment> Comments { get; set; } // one to many
}