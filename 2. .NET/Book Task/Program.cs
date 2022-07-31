using System.Configuration;
using System.Globalization;
using Book_Task;
using Book_Task.Services.Encoders;

Console.InputEncoding = System.Text.Encoding.Unicode;
Console.OutputEncoding = System.Text.Encoding.Unicode;
Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("uk_UA");

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

// AesEncoder encoder = new AesEncoder();
// var a = encoder.Encode("Text\n");
// var b = encoder.Decode(a);
// Console.WriteLine(b);
// Console.WriteLine(encoder.Key);
// Console.WriteLine(encoder.IV);