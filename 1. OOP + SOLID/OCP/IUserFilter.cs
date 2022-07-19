using System.Collections.Generic;
using OCP.Domain;

namespace OCP
{
    //Using Strategy pattern we can move all filter logic outside of UserManager class
    public interface IUserFilter
    {
        public User[] FilterUsers(IEnumerable<User> users);
    }
}
