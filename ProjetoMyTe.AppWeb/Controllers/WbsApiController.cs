using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using ProjetoMyTe.AppWeb.Models;
using ProjetoMyTe.AppWeb.Services;

namespace ProjetoMyTe.AppWeb.Controllers
{
    public class WbsApiController : Controller
    {
        private readonly WbsServiceApi wbsServiceApi;
        public WbsApiController(WbsServiceApi wbsServiceApi)
        {
            this.wbsServiceApi = wbsServiceApi;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ListarWbsApi()
        {
            try
            {

                var wbss = await wbsServiceApi.ListarWbsAsync();
                return View(wbss);
            }
            catch (Exception ex)
            {
                return View("_Erro", ex);
            }
        }
        





    }
}
