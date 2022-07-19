using System;
using System.Linq.Expressions;
using OCP_Another_solution.Domain;
using OCP_Another_solution.Specification.Abstract;

namespace OCP_Another_solution.Specification
{
    public class SimpleUserSpecification : Specification<User>
    {
        public override Expression<Func<User, bool>> ToExpression()
        {
            return user => user.Role != Roles.Admin && !user.IsPremiumUser;
        }
    }
}
