using System.ComponentModel.DataAnnotations;
using ORM.Models.Enums;

namespace ORM.Models;

public class Comment : BaseEntity
{
    public string Text { get; set; }

    public Emote Emote { get; set; }

    [Range(1, 5)]
    public byte Rating { get; set; }

    public Film Film { get; set; } // One to many

    public Actor Actor { get; set; } // One to many
}