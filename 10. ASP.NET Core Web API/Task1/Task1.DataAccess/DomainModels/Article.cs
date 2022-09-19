namespace Task1.DataAccess.DomainModels;

public class Article : BaseEntity
{
    public string Name { get; set; }

    public DateTime PublishDate { get; set; }

    public string Source { get; set; }
}