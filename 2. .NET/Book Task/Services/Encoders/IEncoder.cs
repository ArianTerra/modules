namespace Book_Task.Services.Encoders;

public interface IEncoder
{
    byte[] Encode(string input);

    string Decode(byte[] input);
}