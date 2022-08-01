using Book_Task.Models;

namespace Book_Task.Services.Storage;

public interface IBookStorage
{
    void AddBook(Book book);

    IEnumerable<Book> GetAll();
}