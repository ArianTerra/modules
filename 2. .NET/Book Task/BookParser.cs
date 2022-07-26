using Book_Task.Helpers;
using Book_Task.Models;

namespace Book_Task
{
    public class BookParser
    {
        private string _pattern = @"(?<Author>.+) – (?<Name>.+), (?<Pages_System_Int32>\d+) \((?<Date>.+)\).(?<Format>.+)";

        public Book Parse(string data)
        {
            RegexClassParser<Book> parser = new RegexClassParser<Book>(data, _pattern);
            return parser.ParseClass();
        }
    }
}