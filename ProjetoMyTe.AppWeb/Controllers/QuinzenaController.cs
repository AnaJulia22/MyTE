using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoMyTe.AppWeb.Services;


namespace ProjetoMyTe.AppWeb.Controllers
{
    public class QuinzenaController : Controller
    {
        private readonly QuinzenasService quinzenasService;
        private readonly WbssService? wbssService;

        public QuinzenaController(QuinzenasService quinzenasService, WbssService wbssService)
        {
            this.quinzenasService = quinzenasService;
            this.wbssService = wbssService;
        }
        public IActionResult CriarQuinzena()
        {
            ViewBag.ListaDeWbss = new SelectList(wbssService!.Listar(), "Id", "Descricao");
            return View();
        }

        
        
    }
}
