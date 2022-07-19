using OCP.Domain;

namespace OCP
{
    public class UserManager
    {
        private readonly IUserStore _userStore = new UserStore();

        // We took the responsibility for filtering users from this class and moved it
        // to IUserFilter interface. Now to add a new filter there's no need to modify this
        // class, instead we can create a new class and implement IUserFilter interface.
        public User[] GetFilteredUsers(IUserFilter filter)
        {
            return filter?.FilterUsers(_userStore.Users);
        }
    }
}
