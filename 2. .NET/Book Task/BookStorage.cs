using Book_Task.Models;
using FluentValidation;

namespace Book_Task
{
    public class BookStorage : IBookStorage
    {
        private List<Book> _books = new List<Book>();
        
        public void AddBook(Book book)
        {
            var validator = new BookValidator();
            validator.ValidateAndThrow(book);
            _books.Add(book);
        }

        public IEnumerable<Book> GetAll()
        {
            return _books.AsReadOnly();
        }
    }
}