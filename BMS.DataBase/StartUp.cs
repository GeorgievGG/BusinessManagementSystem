using BMS.DataBaseData;
using BMS.DataBaseModels;

namespace BMS.DataBase
{
    public class StartUp
    {
        public static void Main()
        {
            using (var context = new BmsContex())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                SeedAdmin();
            }
        }

        // enter in the admin panel with:
        // Username: admin
        // Password: 123
        public static void SeedAdmin()
        {
            var admin = new User
            {
                Username = "admin",
                Type = ClearenceType.Admin,
                Password = "40BD001563085FC35165329EA1FF5C5ECBDBBEEF"
            };
            var db = new BmsContex();
            db.Add(admin);
            db.SaveChanges();
            System.Console.WriteLine("Admin profile created!");
        }
    }
}
