using Book_Task.Models;
using Book_Task.Services;

namespace Book_Task
{
    public class BookParser
    {
        private string _pattern = @"(?<Author>.+) – (?<Name>.+), (?<Pages_System_Int32>\d+) \((?<DateString>.+)\).(?<Format>.+)";

        public Book Parse(string data)
        {
            RegexClassParser<Book> parser = new RegexClassParser<Book>(data, _pattern);
            return parser.ParseClass();
        }
    }
}