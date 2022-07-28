using System.Globalization;
using System.Security.Cryptography;

Console.InputEncoding = System.Text.Encoding.Unicode;
Console.OutputEncoding = System.Text.Encoding.Unicode;
Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("uk_UA");

// IBookStorage storage = new BookStorage();
//
// Console.WriteLine("Enter Book string info:");
// string data = Console.ReadLine();
//
// var parser = new BookParser();
//
// try
// {
//     var book = parser.Parse(data);
//     storage.AddBook(book);
//     Console.WriteLine("Book added!");
// }
// catch (Exception e)
// {
//     Console.WriteLine(e.GetBaseException().Message);
// }

Aes aes = Aes.Create();
foreach (var b in aes.Key)
{
    Console.Write($"{b} ");
}

Console.WriteLine();

var key = BitConverter.ToString(aes.Key);
Console.WriteLine(key);

byte[] data = key.Split('-').Select(b => Convert.ToByte(b, 16)).ToArray();

foreach (var b in data)
{
    Console.Write($"{b} ");
}

