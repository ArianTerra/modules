using System;
using System.Linq.Expressions;
using OCP_Another_solution.Domain;
using OCP_Another_solution.Specification.Abstract;

namespace OCP_Another_solution.Specification
{
    public class SubscribtionExpiredSpecification : Specification<User>
    {
        public override Expression<Func<User, bool>> ToExpression()
        {
            throw new NotImplementedException();
        }
    }
}
