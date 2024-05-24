using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoMyTe.AppWeb.Models.Entities;
using ProjetoMyTe.AppWeb.Services;


namespace ProjetoMyTe.AppWeb.Controllers
{
    public class ColaboradoresController : Controller
    {
        private readonly ColaboradoresService colaboradoresService;
        private readonly CargosService cargosService;

        public ColaboradoresController(ColaboradoresService colaboradoresService, CargosService cargosService)
        {
            this.colaboradoresService = colaboradoresService;
            this.cargosService = cargosService;
        }
    
        public IActionResult Index()
        {
            return View();
        }

        // action para adicionar colaboradores
        [HttpGet]
        public IActionResult AdicionarColaborador()
        {
            ViewBag.ListaDeCargos = new SelectList(cargosService.Listar(), "Id", "Descricao");
            return View();
        }
        
        [HttpPost]
        public IActionResult AdicionarColaboradores(Colaborador colaborador) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return View();
                }
                colaboradoresService.Adicionar(colaborador);
                return RedirectToAction("ListarColaboradoresDTO");
            }
            catch (Exception)
            {

                throw;
            }
        }

        //public IActionResult ListarColaboradores(int idCargo)
        //{
        //    try
        //    {
        //        ViewBag.ListaDeCargos = new SelectList(cargosService.Listar(), "Id", "Descricao");
        //        return View(colaboradoresService.Listar(idCargo));
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        [HttpGet]
        public IActionResult ListarColaboradoresDTO(int idCargo)
        {
            try
            {
                ViewBag.ListaDeCargos = new SelectList(cargosService.Listar(), "Id", "Descricao");
                return View(colaboradoresService.ListarCobaboradoresDTO(idCargo));
            }
            catch (Exception ex)
            {

                return View("_Erro", ex);
            }
        }
        [HttpGet]
        public IActionResult AlterarColaborador(string id)
        {
            try
            {
                if (id.Length <= 0)
                {
                    throw new ArgumentException($"Valor de id ({id}) eh invalido!");
                }
               Colaborador? colaborador = colaboradoresService.Buscar(id);
                if (colaborador == null)
                {
                    throw new ArgumentException($"O cargo de id ({id}) não foi encontrado!");
                }
                return View(colaborador);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult AlterarColaborador(Colaborador colaborador)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                colaboradoresService.Alterar(colaborador);
                return RedirectToAction("ListarColaboradoresDTO");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public IActionResult RemoverColaborador(string id)
        {
            try
            {
                if (id.Length <= 0)
                {
                    throw new ArgumentException($"Valor de id ({id}) eh invalido!");
                }
                Colaborador? colaborador = colaboradoresService.Buscar(id);
                if (colaborador == null)
                {
                    throw new ArgumentException($"O cargo de id ({id}) não foi encontrado!");
                }
                return View(colaborador);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult RemoverColaborador(Colaborador colaborador)
        {
            try
            {
                colaboradoresService.Remover(colaborador);
                return RedirectToAction("ListarColaboradoresDTO");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
