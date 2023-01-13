using ORM;
using ORM.Models;
using ORM.Models.Enums;

using var ctx = new CinemaContext();

// uncomment and execute every block one by one

// var actor = new Actor()
// {
//     Name = "Jerry",
//     Year = 1983,
//     Gender = Gender.Male,
//     Country = "UK"
// };
//
// ctx.Actors.Add(actor);

// var film = new Film()
// {
//     Actors = ctx.Actors.Where(x => x.Name == "Jerry").ToHashSet(),
//     Name = "JERRY THE BLOODSUCKER",
//     Year = 2008,
//     Genre = "Comedy",
//     Country = "Uganda",
// };
//
// ctx.Films.Add(film);

// var comment = new Comment()
// {
//     Text = "This film is amazing!!! It tells a lot about our society.",
//     Emote = Emote.Positive,
//     Rating = 5,
//     Film = ctx.Films.Where(x => x.Name == "JERRY THE BLOODSUCKER").First(),
// };
//
// ctx.Comments.Add(comment);

// var actorComment = new Comment()
// {
//     Text = "I like Jerry, he is the best!!!11",
//     Emote = Emote.Positive,
//     Rating = 5,
//     Actor = ctx.Actors.Where(x => x.Name == "Jerry").First()
// };
//
// ctx.Comments.Add(actorComment);

//// THIS will throw validation error because of Range(1, 5)
// var incorrectComment = new Comment()
// {
//     Text = "I hate Jerry, he is the worst!!!11",
//     Emote = Emote.Negative,
//     Rating = 0,
//     Actor = ctx.Actors.Where(x => x.Name == "Jerry").First()
// };
//
// ctx.Comments.Add(incorrectComment);

// Testing Gender enum. Migration is not needed, wow
var actorFemale = new Actor()
{
    Name = "Monika",
    Gender = Gender.Female,
    Year = 1999,
    Country = "Canada"
};

ctx.Actors.Add(actorFemale);

ctx.SaveChanges();