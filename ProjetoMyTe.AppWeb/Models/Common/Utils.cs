using Microsoft.AspNetCore.Identity;

namespace ProjetoMyTe.AppWeb.Models.Common
{
    public class Utils
    {
        public static async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roleNames = { "ADMIN", "COLABORADOR", "GESTOR DE PROJETOS" , "RH"};

            IdentityResult result;
            foreach (var role in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);
                if (!roleExist)
                {
                    result = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

        }
        public static string? IdCpf = null;
        public static int totalHorasWbs = 0;
    }
}
