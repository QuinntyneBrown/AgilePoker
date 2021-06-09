namespace AgilePoker.Api.Data
{
    public static class SeedData
    {
        public static void Seed(AgilePokerDbContext context)
        {
            RoleConfiguration.Seed(context);
            UserConfiguration.Seed(context);
            ProductOwnerConfiguration.Seed(context);
            DeveloperConfiguration.Seed(context);
            PlanningSessionConfiguration.Seed(context);
        }

        internal class RoleConfiguration
        {
            internal static void Seed(AgilePokerDbContext context)
            {

            }
        }

        internal class UserConfiguration
        {
            internal static void Seed(AgilePokerDbContext context)
            {

            }
        }

        internal class ProductOwnerConfiguration
        {
            internal static void Seed(AgilePokerDbContext context)
            {

            }
        }

        internal class DeveloperConfiguration
        {
            internal static void Seed(AgilePokerDbContext context)
            {

            }
        }

        internal class PlanningSessionConfiguration
        {
            internal static void Seed(AgilePokerDbContext context)
            {

            }
        }
    }
}
