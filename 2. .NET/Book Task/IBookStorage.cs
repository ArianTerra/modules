using Book_Task.Models;

namespace Book_Task
{
    public interface IBookStorage
    {
        void AddBook(Book book);
        IEnumerable<Book> GetAll();
    }
}