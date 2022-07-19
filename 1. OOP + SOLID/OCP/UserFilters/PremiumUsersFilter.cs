using OCP.Domain;
using System.Collections.Generic;
using System.Linq;

namespace OCP.UserFilters
{
    internal class PremiumUsersFilter : IUserFilter
    {
        public User[] FilterUsers(IEnumerable<User> users)
        {
            return users.Where(u => u.IsPremiumUser && u.Subscription.IsActive).ToArray();
        }
    }
}
