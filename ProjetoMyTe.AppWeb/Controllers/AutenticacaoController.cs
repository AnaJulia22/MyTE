using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoMyTe.AppWeb.Models.Common;
using ProjetoMyTe.AppWeb.Models.Entities;

namespace ProjetoMyTe.AppWeb.Controllers
{
    public class AutenticacaoController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AutenticacaoController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            var roles = roleManager.Roles.ToList();
            var listaRoles = roles.Select(p => p.Name).ToList();
            ViewBag.Roles = new SelectList(listaRoles);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registrar(UsuarioViewModel model)
        {
            var roles = roleManager.Roles.ToList();
            var listaRoles = roles.Select(p => p.Name).ToList();
            ViewBag.Roles = new SelectList(listaRoles);
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.Cpf
                };
                var result = await userManager.CreateAsync(user, model.Senha!);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.Perfil))
                    {
                        var appRole = await roleManager.FindByNameAsync(model.Perfil);
                        if (appRole != null)
                        {
                            await userManager.AddToRoleAsync(user, model.Perfil);
                        }
                    }
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return User.IsInRole("GESTOR DE PROJETOS") ? RedirectToAction("ListarWbss", "Wbss") : User.IsInRole("COLABORADOR")
                                                  ? RedirectToAction("ListarRegistros", "RegistroHoras")
                                                  : RedirectToAction("ShowDashboard", "Dashboard");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
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
        public async Task<IActionResult> Login(LogonViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Cpf!, model.Senha!, model.RememberMe, false);
                if (result.Succeeded)
                {
                    Utils.IdCpf = User.Identity!.Name;
                    return User.IsInRole("ADMIN") ? RedirectToAction("ListarWbss", "Wbss") : User.IsInRole("USER")
                                                  ? RedirectToAction("ListarRegistros", "RegistroHoras")
                                                  //: RedirectToAction("ShowDashboard", "Dashboard");
                                                  : RedirectToAction("LancarHorasDTO", "LancamentoHoras");

                }
                ModelState.AddModelError(string.Empty, "Usuário ou senha inválidos.");
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
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
