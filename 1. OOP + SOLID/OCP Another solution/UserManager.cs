using OCP_Another_solution.Domain;
using OCP_Another_solution.Specification.Abstract;
using System.Linq;

namespace OCP_Another_solution
{
    public class UserManager
    {
        private readonly IUserStore _userStore = new UserStore();

        public User[] Find(Specification<User> specification)
        {
            return _userStore.Users.Where(user => specification.IsSatisfiedBy(user)).ToArray();
        }
    }
}
