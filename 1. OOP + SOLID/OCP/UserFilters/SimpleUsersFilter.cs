using OCP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP.UserFilters
{
    public class SimpleUsersFilter : IUserFilter
    {
        public User[] FilterUsers(IEnumerable<User> users)
        {
            return users.Where(u => u.Role != Roles.Admin && !u.IsPremiumUser).ToArray();
        }
    }
}
