using Book_Task;

var book1 = new Book()
{
    Name = "AAAA"
};
var book2 = new Book()
{
    Name = "       "
};

var validator = new BookValidator();

Console.WriteLine(validator.Validate(book1).IsValid);
Console.WriteLine(validator.Validate(book2).IsValid);
