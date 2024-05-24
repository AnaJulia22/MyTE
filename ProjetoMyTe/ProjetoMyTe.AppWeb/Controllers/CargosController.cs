using Microsoft.AspNetCore.Mvc;
using ProjetoMyTe.AppWeb.Models.Entities;
using ProjetoMyTe.AppWeb.Services;

namespace ProjetoMyTe.AppWeb.Controllers
{
    public class CargosController : Controller
    {
        private readonly CargosService cargosService;

        public CargosController(CargosService cargosService)
        {
            this.cargosService = cargosService;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AdicionarCargo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdicionarCargo(Cargo cargo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                cargosService.Adicionar(cargo);
                return RedirectToAction("ListarCargos");
            }
            catch (Exception)
            {

                throw;
            }
        
    }


        public IActionResult ListarCargos()
        {
            var listaCargos = cargosService.Listar();
            return View(listaCargos);
        }
        
        
        
        [HttpGet]
        public IActionResult AlterarCargo(int id) 
        {
            try
            {
                if(id <= 0)
                {
                    throw new ArgumentException($"Valor de id ({id}) eh invalido!");
                }
                Cargo? cargo = cargosService.Buscar(id); 
                if(cargo == null)
                {
                    throw new ArgumentException($"O cargo de id ({id}) não foi encontrado!");
                }
                return View(cargo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult AlterarCargo(Cargo cargo) 
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                cargosService.Alterar(cargo);
                return RedirectToAction("ListarCargos");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public IActionResult RemoverCargo(int id) 
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException($"Valor de id ({id}) eh invalido!");
                }
                Cargo? cargo = cargosService.Buscar(id);
                if (cargo == null)
                {
                    throw new ArgumentException($"O cargo de id ({id}) não foi encontrado!");
                }
                return View(cargo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult RemoverCargo(Cargo cargo)
        {
            try
            {
                cargosService.Remover(cargo);
                return RedirectToAction("ListarCargos");
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
