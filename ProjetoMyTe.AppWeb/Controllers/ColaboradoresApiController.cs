using Microsoft.AspNetCore.Mvc;
using ProjetoMyTe.AppWeb.Services;

namespace ProjetoMyTe.AppWeb.Controllers
{
    public class ColaboradoresApiController : Controller
    {
        private readonly ColaboradorServiceApi colaboradorServiceApi;
        public ColaboradoresApiController(ColaboradorServiceApi colaboradorServiceApi)
        {
            this.colaboradorServiceApi = colaboradorServiceApi;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ListarColaboradoresApi()
        {
            try
            {
                var colaboradores = await colaboradorServiceApi.ListarColaboraresAsyn();
                return View(colaboradores);
            }
            catch (Exception ex)
            {
                return View("_Erro", ex);
            }
        }
    }
}
