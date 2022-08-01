using Newtonsoft.Json;

namespace Book_Task.Models;

public class Book
{
    public string Name { get; set; }

    public string Author { get; set; }

    public int Pages { get; set; }

    public string DateString { get; set; }

    public string Format { get; set; }

    [JsonIgnore]
    public DateOnly Date
    {
        get
        {
            int year;
            if (int.TryParse(DateString, out year))
            {
                return new DateOnly(year, 1, 1);
            }

            DateOnly date;
            if (DateOnly.TryParse(DateString, out date))
            {
                return date;
            }

            throw new FormatException("DateString is not a year or a Date");
        }
    }

    public override string ToString()
    {
        return $"Name: {Name} Author: {Author} Pages: {Pages} Date/Year: {DateString} Format: {Format}";
    }
}