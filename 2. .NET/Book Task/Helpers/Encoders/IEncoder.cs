namespace Book_Task.Helpers.Encoders
{
    public interface IEncoder
    {
        string Encode(string input);
        string Decode(string input);
    }
}