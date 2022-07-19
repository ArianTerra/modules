using Newtonsoft.Json;
using System.IO;

namespace SRP
{
    public class UserFileSaver
    {
        private User _user;

        public UserFileSaver(User user)
        {
            _user = user;
        }

        public void SaveToJson(string fileName)
        {
            File.WriteAllText(fileName, JsonConvert.SerializeObject(this));
        }
    }
}
