using Bogus;
using Task1.DataAccess.DomainModels;

namespace Task1.DataAccess;

public static class ArticleDatabaseSeeder
{
    public static IEnumerable<Article> GenerateArticles(int size)
    {
        var faker = new Faker<Article>()
            .RuleFor(x => x.Id, f => Guid.NewGuid())
            .RuleFor(x => x.Name, f => f.Lorem.Sentence(3).Replace(".", ""))
            .RuleFor(x => x.PublishDate, f => f.Date.Past(3))
            .RuleFor(x => x.Source, f => f.Internet.Url());

        return faker.GenerateLazy(size);
    }
}