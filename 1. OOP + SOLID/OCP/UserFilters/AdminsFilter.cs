using OCP.Domain;
using System.Collections.Generic;
using System.Linq;

namespace OCP.UserFilters
{
    public class AdminsFilter : IUserFilter
    {
        public User[] FilterUsers(IEnumerable<User> users)
        {
            return users.Where(u => u.Role == Roles.Admin).ToArray();
        }
    }
}
