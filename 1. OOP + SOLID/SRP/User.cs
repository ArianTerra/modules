using Newtonsoft.Json;
using System;
using System.IO;

namespace SRP
{
    public class User
    {
        private IUserStore _store;
        private string _name;

        public User(IUserStore store)
        {
            _store = store;
        }

        public string Name
        {
            get => _name;
            set
            {
                var userExists = _store.FindUserByName(value) != null;

                if (userExists)
                {
                    throw new Exception($"The name {value} is already taken");
                }

                _name = value;
            }
        }
    }
}
