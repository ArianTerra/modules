using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Book_Task.Services.Encoders;

public class AesEncoder : IEncoder
{
    private const string KeyMatchingPattern = @"^([A-Z0-9]{2}-){31}[A-Z0-9]{2}$";
    private const string IvMatchingPattern = @"^([A-Z0-9]{2}-){15}[A-Z0-9]{2}$";
    private byte[] _key;
    private byte[] _iv;

    public AesEncoder()
    {
        GenerateNewKey();
    }

    public AesEncoder(string key, string iv)
    {
        Key = key;
        IV = iv;
    }

    public string Key
    {
        get
        {
            return BitConverter.ToString(_key);
        }

        set
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(Key));
            }

            if (!Regex.IsMatch(value, KeyMatchingPattern, RegexOptions.Multiline | RegexOptions.ExplicitCapture))
            {
                throw new FormatException("Input key does not match key pattern");
            }

            _key = value.Split('-').Select(b => Convert.ToByte(b, 16)).ToArray();
        }
    }

    public string IV
    {
        get
        {
            return BitConverter.ToString(_iv);
        }

        set
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(IV));
            }

            if (!Regex.IsMatch(value, IvMatchingPattern, RegexOptions.Multiline | RegexOptions.ExplicitCapture))
            {
                throw new FormatException("Input IV does not match key pattern");
            }

            _iv = value.Split('-').Select(b => Convert.ToByte(b, 16)).ToArray();
        }
    }

    public void GenerateNewKey()
    {
        Aes aes = Aes.Create();
        _key = aes.Key;
        _iv = aes.IV;
    }

    public byte[] Encode(string input)
    {
        byte[] encrypted;
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = _key;
            aesAlg.IV = _iv;

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(input);
                    }

                    encrypted = msEncrypt.ToArray();
                }
            }
        }

        return encrypted;
    }

    public string Decode(byte[] input)
    {
        string plaintext = null;

        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = _key;
            aesAlg.IV = _iv;

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msDecrypt = new MemoryStream(input))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }
        }

        return plaintext;
    }
}