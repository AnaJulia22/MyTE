using MyTe.API.Models.Contexts;

namespace MyTe.API.Models.Startup
{
    public class DbInitializer
    {
        public static void Initialize(MyTeContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
