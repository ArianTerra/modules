using OCP.Domain;
using System.Collections.Generic;
using System.Linq;

namespace OCP.UserFilters
{
    public class AdminsAndPremiumUserFilter : IUserFilter
    {
        public User[] FilterUsers(IEnumerable<User> users)
        {
            var admins = new AdminsFilter().FilterUsers(users);
            var premiums = new PremiumUsersFilter().FilterUsers(users);
            return admins.Concat(premiums).ToArray();
        }
    }
}
