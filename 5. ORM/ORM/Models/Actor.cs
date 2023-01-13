using System.Collections;
using ORM.Models.Enums;

namespace ORM.Models;

public class Actor : BaseEntity
{
    public Actor()
    {
        Films = new HashSet<Film>();
        Comments = new HashSet<Comment>();
    }

    public string Name { get; set; }

    public int Year { get; set; }

    public Gender Gender { get; set; }

    public string Country { get; set; }

    public ICollection<Film> Films { get; set; } // many to many relation

    public ICollection<Comment> Comments { get; set; } // one to many
}