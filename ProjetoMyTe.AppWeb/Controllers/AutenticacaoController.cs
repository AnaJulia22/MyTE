using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoMyTe.AppWeb.Models.Common;
using ProjetoMyTe.AppWeb.Models.Entities;
using ProjetoMyTe.AppWeb.Services;

namespace ProjetoMyTe.AppWeb.Controllers
{
    public class AutenticacaoController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ColaboradoresService colaboradoresService;
        private readonly QuinzenasService quinzenaService;

        public AutenticacaoController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, ColaboradoresService colaboradoresService, QuinzenasService quinzenaService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.colaboradoresService = colaboradoresService;
            this.quinzenaService = quinzenaService; 
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registrar(UsuarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.Cpf
                };
                Utils.IdCpf = user.UserName;
                try
                {
                    if (colaboradoresService.Buscar(Utils.IdCpf!) == null)
                    {
                        Utils.IdCpf = null;
                        throw new Exception("Usuário não cadastrado na nossa base de dados de colaboradores");
                    }

                    var usuarioTemp = colaboradoresService.Buscar(Utils.IdCpf!);
                    model.Perfil = usuarioTemp!.Perfil;
                    var result = await userManager.CreateAsync(user, model.Senha!);

                    if (result.Succeeded)
                    {
                        quinzenaService.CriarQuinzena();
                        if (!string.IsNullOrEmpty(model.Perfil))
                        {
                            var appRole = await roleManager.FindByNameAsync(model.Perfil);
                            if (appRole != null)
                            {
                                await userManager.AddToRoleAsync(user, model.Perfil);
                            }
                        }
                        await signInManager.SignInAsync(user, isPersistent: false);
                        return User.IsInRole("ADMIN") ? RedirectToAction("ListarWbss", "Wbss") : User.IsInRole("COLABORADOR")
                                                      ? RedirectToAction("LancarHorasDTO", "LancamentoHoras") : User.IsInRole("GESTOR DE PROJETOS")
                                                      ? RedirectToAction("ListarWbsApi", "WbsApi")
                                                      : RedirectToAction("ShowDashboard", "Dashboard");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                catch (Exception ex)
                {

                    return View("_Erro", ex);
                }
               
                
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LogonViewModel model, string? returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Cpf!, model.Senha!, model.RememberMe, false);
                if (result.Succeeded)
                {
                    Utils.IdCpf = User.Identity!.Name;


                    return User.IsInRole("ADMIN") ? RedirectToAction("ListarWbss", "Wbss") : User.IsInRole("COLABORADOR")
                                                      ? RedirectToAction("LancarHorasDTO", "LancamentoHoras") : User.IsInRole("GESTOR DE PROJETOS")
                                                      ? RedirectToAction("ListarWbsApi", "WbsApi")
                                                      : RedirectToAction("ShowDashboard", "Dashboard");

                }

                ModelState.AddModelError(string.Empty, "Usuário ou senha inválidos.");
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            Utils.IdCpf = null;
            return RedirectToAction("Login", "Autenticacao");
        }

        [HttpGet]
        public IActionResult AlterarSenha()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AlterarSenha(AlterarSenhaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(model.CpfId!);
                if (user == null)
                {
                    return RedirectToAction("Login", "Autenticacao");
                }
                var passwordVerificationResult = userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash!, model.SenhaNova!);
                if (passwordVerificationResult == PasswordVerificationResult.Success)
                {
                    ModelState.AddModelError(string.Empty, "A nova senha não pode ser igual à antiga.");
                    return View(model);
                }

                var result = await userManager.ChangePasswordAsync(user, model.SenhaAntiga!, model.SenhaNova!);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View();
                }

                await signInManager.RefreshSignInAsync(user);

                return RedirectToAction("ChangePasswordConfirmation", "Autenticacao");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult ChangePasswordConfirmation()
        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            var erro = "Você não tem permissão para acessar este recurso!!";
            return View("_Erro", new Exception(erro));
        }

    }
}
