namespace OCP_Another_solution.Domain
{
    public class User
    {
        public string Role { get; set; }

        public bool IsPremiumUser { get; set; }

        public Subscription Subscription { get; set; }
    }
}
