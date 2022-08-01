using Book_Task.Models;
using Book_Task.Services.Parsers;
using Book_Task.Services.Storage;

namespace Book_Task;

public class BookManager
{
    private IBookStorage _storage;

    public BookManager(IBookStorage storage)
    {
        _storage = storage;
    }

    public void AddBook(Book book)
    {
        _storage.AddBook(book);
    }

    public void AddBook(string bookData)
    {
        var parser = new BookParser();
        var book = parser.Parse(bookData);
        AddBook(book);
    }

    public IEnumerable<Book> GetPage(int pageSize, int page)
    {
        return _storage.GetAll().Skip(page * pageSize).Take(pageSize);
    }

    // Next lines of code breaks OCP principle
    public Book? GetLastPublishedBook()
    {
        return _storage.GetAll().MaxBy(x => x.Date);
    }

    public IEnumerable<Book> GetBooksByDateRange(DateOnly first, DateOnly second)
    {
        var result = _storage.GetAll().Where(x => x.Date >= first && x.Date <= second);
        if (!result.Any())
        {
            throw new ArgumentException("No books for this time range");
        }

        return _storage.GetAll().Where(x => x.Date >= first && x.Date <= second);
    }

    public IEnumerable<IGrouping<string, Book>> GetBooksGroupedByAuthor(DateOnly date)
    {
        return _storage.GetAll().Where(x => x.Date > date).OrderByDescending(x => x.Author).ThenBy(x => x.Name)
            .GroupBy(x => x.Author);
    }

    public IEnumerable<Book> GetBooksByName(string name)
    {
        return _storage.GetAll().Where(x => x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
    }

    public string GetAllAuthors()
    {
        return string.Join(",", _storage.GetAll().Select(x => x.Author).Distinct().ToList());
    }
}