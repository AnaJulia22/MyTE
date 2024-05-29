using Microsoft.AspNetCore.Identity;

namespace ProjetoMyTe.AppWeb.Services
{
    public class AutenticacoesService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager; 
        private readonly RoleManager <IdentityRole> roleManager;

        public AutenticacoesService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signManager;
            this.roleManager = roleManager;
        }
        public List <string?> ListarPerfis()
        {
            return roleManager.Roles.Select(r => r.Name).ToList();        }
    }
}
