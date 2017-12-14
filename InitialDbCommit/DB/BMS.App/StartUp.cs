using BMS.Data;
using Microsoft.EntityFrameworkCore;

namespace BMS.App
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var context = new BmsDbContext())
            {
                context.Database.Migrate();
            }
        }
    }
}
