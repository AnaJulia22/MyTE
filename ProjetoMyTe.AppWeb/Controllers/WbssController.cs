using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoMyTe.AppWeb.Models.DTO;
using ProjetoMyTe.AppWeb.Models.Entities;
using ProjetoMyTe.AppWeb.Services;

namespace ProjetoMyTe.AppWeb.Controllers
{
    public class WbssController : Controller
    {
        private readonly WbssService wbssService;

        public WbssController(WbssService wbssService)
        {
            this.wbssService = wbssService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListarWbss()
        {
            try
            {
                //var listaWbss = wbssService.Listar();
                //if (!string.IsNullOrEmpty(tipoSelecionado))
                //{
                //    listaWbss = listaWbss.Where(w => w.Tipo == tipoSelecionado);
                //}
                //ViewBag.ListaDeWbss = new SelectList(wbssService.Listar(), "Id", "Descricao");
                return View(wbssService.Listar());
            }
            catch (Exception ex)
            {

                return View("_Erro", ex);
            }
        }
        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public IActionResult AdicionarWbs()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdicionarWbs(Wbs wbs)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                wbssService.AdicionarWbs(wbs);
                return RedirectToAction("ListarWbss");
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet]
        public IActionResult AlterarWbs(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException($"Valor de id ({id}) eh invalido!");
                }
                Wbs? wbs = wbssService.Buscar(id);
                if (wbs == null)
                {
                    throw new ArgumentException($"A wbs de id ({id}) não foi encontrado!");
                }
                return View(wbs);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult AlterarWbs(Wbs wbs)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                wbssService.Alterar(wbs);
                return RedirectToAction("ListarWbss");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public IActionResult RemoverWbs(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException($"Valor de id ({id}) eh invalido!");
                }
                Wbs? wbs = wbssService.Buscar(id);
                if (wbs == null)
                {
                    throw new ArgumentException($"A wbs de id ({id}) não foi encontrado!");
                }
                return View(wbs);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult RemoverWbs(Wbs wbs)
        {
            try
            {
                wbssService?.Remover(wbs);  
                return RedirectToAction("ListarWbss");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
