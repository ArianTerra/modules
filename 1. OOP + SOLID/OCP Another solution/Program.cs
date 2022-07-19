using System.Linq;
using OCP_Another_solution.Specification;

namespace OCP_Another_solution
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var userManager = new UserManager();

            // BA: - We need to get all admins
            // You: - No problem
            var adminSpec = new AdminSpecification();
            var admins = userManager.Find(adminSpec);

            // BA: - We need to get all premium users as well
            // You: - Easy
            var premiumSpec = new PremiumUserSpecification();
            var premiumUsers = userManager.Find(premiumSpec);

            // BA: - We need to get all premium users and admins together
            // You: - Weeeelll... OK....
            var adminsAndPremiumUsers = userManager.Find(adminSpec.Or(premiumSpec));

            // BA: - We need to get all users that are not admins and premiums
            // You: - Got it
            var simpleSpec = new SimpleUserSpecification();
            var simpleUsers = userManager.Find(simpleSpec);

            // BA: - We need to get all users that are not admins and premiums
            // You: "Ummm... How do I call it? GetSimpleUsersWhosSubscriptionHasExpired?". - Done!
            var subExpiredSpec = new SubscribtionExpiredSpecification();
            var expiries = userManager.Find(simpleSpec.And(subExpiredSpec));

            // BA: - We need a custom filter that allows end user to filter users in a way he likes
            // You: "%$#%!&??@!!!!!". - I need time to re-write the code.
        }
    }
}
