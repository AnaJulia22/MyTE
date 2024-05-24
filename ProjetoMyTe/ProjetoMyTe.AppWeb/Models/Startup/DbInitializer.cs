using ProjetoMyTe.AppWeb.Models.Contexts;

namespace ProjetoMyTe.AppWeb.Models.Startup
{
    public class DbInitializer
    {
        public static void Initialize(MyTeContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
