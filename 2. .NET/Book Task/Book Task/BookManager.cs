using System.Text.RegularExpressions;

namespace Book_Task
{
    public class BookManager
    {
        public IEnumerable<Book> Books;

        public string ParsingPattern { get; set; } = @"(?<Author>.+) – (?<Name>.+), (?<Pages>\d+) \((?<Date>.+)\).(?<Format>.+)";
        public Book ParseBook(string book)
        {
            var matches = Regex.Match(book, ParsingPattern);

            var errorMessage = "";
            
            var author = matches.Groups[0];
            var name = matches.Groups[1];
            var pages = matches.Groups[2];
            var date = matches.Groups[3];
            var format = matches.Groups[4];

            int pagesParsed = 0;
            if (!int.TryParse(pages.Value, out pagesParsed))
            {
                errorMessage += $"Failed to parse {pages.Name}\n";
            }
            
            //DateOnly dateParsed = DateOnly.Parse(date);
            
            //TODO maybe implement that FluentValidator interface

            return new Book()
            {

            };
        }
    }
}