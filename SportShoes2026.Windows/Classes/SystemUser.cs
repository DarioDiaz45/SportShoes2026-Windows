using SportShoes2026.Entities;

namespace SportShoes2026.Windows.Classes
{
    public class SystemUser
    {
        public static List<User> Users { get; } =
       [
           new User
        {
            UserName = "admin",
            Password = "1234"
        },

        new User
        {
            UserName = "empleado",
            Password = "1234"
        }
       ];
    }
}
