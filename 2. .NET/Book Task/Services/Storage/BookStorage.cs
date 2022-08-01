using System.Configuration;
using Book_Task.Models;
using Book_Task.Services.Encoders;
using Book_Task.Services.Validators;
using FluentValidation;
using Newtonsoft.Json;

namespace Book_Task.Services.Storage;

public class BookStorage : IBookStorage
{
    private List<Book> _books = new List<Book>();
    private string _key;
    private string _iv;
    private string _fileName = "books_storage";

    public BookStorage()
    {
        _key = ConfigurationManager.AppSettings.Get("AesEncoderKey");
        _iv = ConfigurationManager.AppSettings.Get("AesEncoderIV");
        if (_key == null || _iv == null)
        {
            throw new ConfigurationErrorsException("Configuration file not found");
        }

        LoadFromFile();
    }

    public void AddBook(Book book)
    {
        var validator = new BookValidator();
        validator.ValidateAndThrow(book);
        _books.Add(book);
        SaveToFile();
    }

    public IEnumerable<Book> GetAll()
    {
        return _books.AsReadOnly();
    }

    public void SaveToFile()
    {
        string json = JsonConvert.SerializeObject(_books);
        IEncoder encoder = new AesEncoder(_key, _iv);
        var message = encoder.Encode(json);

        using var stream = File.Create(Environment.CurrentDirectory + "/" + _fileName);
        stream.Write(message, 0, message.Length);
    }

    public void LoadFromFile()
    {
        if (File.Exists(Environment.CurrentDirectory + "/" + _fileName))
        {
            IEncoder encoder = new AesEncoder(_key, _iv);
            var message = File.ReadAllBytes( Environment.CurrentDirectory + "/" + _fileName);
            string json = encoder.Decode(message);
            _books = JsonConvert.DeserializeObject<List<Book>>(json);
        }
    }
}