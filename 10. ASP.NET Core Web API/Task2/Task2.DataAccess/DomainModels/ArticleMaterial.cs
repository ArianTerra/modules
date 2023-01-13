namespace Task2.DataAccess.DomainModels;

public class ArticleMaterial : BaseEntity
{
    public string Name { get; set; }

    public DateTime PublishDate { get; set; }

    public string Source { get; set; }
}