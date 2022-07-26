using System.Globalization;
using Book_Task;
using Book_Task.Helpers;
using Book_Task.Models;

Console.InputEncoding = System.Text.Encoding.Unicode;
Console.OutputEncoding = System.Text.Encoding.Unicode;
Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("uk_UA");
//string pattern =  @"(?<Author>.+) – (?<Name>.+), (?<Pages_System_Int32>\d+) \((?<Date>.+)\).(?<Format>.+)";
//string data = "Е. Таненбаум – Сучасні операційні системи, 1365 (12.05.2013).pdf";
IBookStorage storage = new BookStorage();

Console.WriteLine("Enter Book string info:");
string data = Console.ReadLine();

var parser = new BookParser();

try
{
    var book = parser.Parse(data);
    storage.AddBook(book);
    Console.WriteLine("Book added!");
}
catch (Exception e)
{
    Console.WriteLine(e.GetBaseException().Message);
}

// var book = parser.Parse(data);
// storage.AddBook(book);