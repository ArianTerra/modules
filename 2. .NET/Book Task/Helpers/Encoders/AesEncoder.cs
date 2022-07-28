using System.Diagnostics.CodeAnalysis;

namespace Book_Task.Helpers.Encoders
{
    public class AesEncoder : IEncoder
    {
        private byte[] _key;

        public AesEncoder(string key)
        {
            Key = key;
        }
        
        public string Key
        {
            get
            {
                return BitConverter.ToString(_key);
            }
            set
            {
                if (value == null) //idk how to suppress 
                {
                    throw new ArgumentNullException();
                }
                
                if (!value.Contains('-'))
                {
                    
                }
                _key = value?.Split('-').Select(b => Convert.ToByte(b, 16)).ToArray();
            }
        }
        
        public string Encode(string input)
        {
            throw new NotImplementedException();
        }

        public string Decode(string input)
        {
            throw new NotImplementedException();
        }
    }
}