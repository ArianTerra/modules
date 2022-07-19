using OCP_Another_solution.Domain;
using System.Collections.Generic;

namespace OCP_Another_solution
{
    public interface IUserStore
    {
        IEnumerable<User> Users { get; }
    }

    public class UserStore : IUserStore
    {
        public IEnumerable<User> Users { get; } = new List<User>();
    }
}
