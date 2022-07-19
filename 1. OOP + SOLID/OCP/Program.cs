using OCP.UserFilters;

namespace OCP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var userManager = new UserManager();

            // BA: - We need to get all admins
            // You: - No problem
            var admins = userManager.GetFilteredUsers(new AdminsFilter());

            // BA: - We need to get all premium users as well
            // You: - Easy
            var premiumUsers = userManager.GetFilteredUsers(new PremiumUsersFilter());

            // BA: - We need to get all premium users and admins together
            // You: - Weeeelll... OK....
            var adminsAndPremiumUsers = userManager.GetFilteredUsers(new AdminsAndPremiumUserFilter());

            // BA: - We need to get all users that are not admins and premiums
            // You: - Got it
            var simpleUsers = userManager.GetFilteredUsers(new SimpleUsersFilter());

            // BA: - We need to get all users that are not admins and premiums
            // You: "Ummm... - Done!
            var expiries = userManager.GetFilteredUsers(new SimpleUsersExpriredSubFliter());
        }
    }
}
