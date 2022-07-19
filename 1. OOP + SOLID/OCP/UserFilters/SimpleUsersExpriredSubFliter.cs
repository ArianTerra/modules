using OCP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP.UserFilters
{
    internal class SimpleUsersExpriredSubFliter : IUserFilter
    {
        public User[] FilterUsers(IEnumerable<User> users)
        {
            throw new NotImplementedException();
        }
    }
}
