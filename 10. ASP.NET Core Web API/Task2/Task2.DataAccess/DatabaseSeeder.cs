using Bogus;
using Task2.DataAccess.DomainModels;

namespace Task2.DataAccess;

public static class DatabaseSeeder
{
    public static IEnumerable<ArticleMaterial> GenerateArticles(int size)
    {
        var faker = new Faker<ArticleMaterial>()
            .RuleFor(x => x.Id, f => Guid.NewGuid())
            .RuleFor(x => x.Name, f => f.Lorem.Sentence(3).Replace(".", ""))
            .RuleFor(x => x.PublishDate, f => f.Date.Past(3))
            .RuleFor(x => x.Source, f => f.Internet.Url());

        return faker.GenerateLazy(size);
    }
}