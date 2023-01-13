using System.Globalization;
using Book_Task;
using Book_Task.Services.Storage;

Console.InputEncoding = System.Text.Encoding.Unicode;
Console.OutputEncoding = System.Text.Encoding.Unicode;
Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("uk_UA");

BookManager manager = new(new BookStorage());

AddBook();
GetAllBooks(2); // show all books using pages

Console.WriteLine($"Last book: {manager.GetLastPublishedBook()}");

// that one method with author groups
foreach (var group in manager.GetBooksGroupedByAuthor(new DateOnly(2010, 1, 1)))
{
    foreach (var book in group)
    {
        Console.WriteLine($"{book.Author}\t\t{book.Name}");
    }
}

void AddBook()
{
    Console.WriteLine("Enter Book string info:");
    string data = Console.ReadLine();

    try
    {
        manager.AddBook(data);
        Console.WriteLine("Book added!");
    }
    catch (Exception e)
    {
        Console.WriteLine(e.GetBaseException().Message);
    }
}

void GetAllBooks(int pageSize)
{
    for (int i = 0; i < pageSize; i++)
    {
        var page = manager.GetPage(pageSize, i);
        Console.WriteLine($"Page {i}");
        foreach (var book in page)
        {
            Console.WriteLine(book);
        }

        Console.WriteLine("Press any key to go to the next page...");
        Console.Read();
    }
}