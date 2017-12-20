using BMS.DataBaseData;

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
            }
        }     
    }
}
