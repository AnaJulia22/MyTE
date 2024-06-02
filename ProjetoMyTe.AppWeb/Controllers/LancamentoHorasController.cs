using Microsoft.AspNetCore.Mvc;
using ProjetoMyTe.AppWeb.Models.Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using ProjetoMyTe.AppWeb.Models.DTO;
using ProjetoMyTe.AppWeb.Models.Entities;
using ProjetoMyTe.AppWeb.Services;
using System.Reflection;

namespace ProjetoMyTe.AppWeb.Controllers
{
    public class LancamentoHorasController : Controller
    {
        private readonly RegistroHorasService? _registroHorasService;
        private readonly WbssService? _wbssService;
        private readonly QuinzenasService _quinzenasService;
        

        public LancamentoHorasController(RegistroHorasService registroHorasService, WbssService wbssService, QuinzenasService quinzenasService)
        {
            this._registroHorasService = registroHorasService;
            this._wbssService = wbssService;
            this._quinzenasService = quinzenasService;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult LancarHorasDTO()
        {
            ViewBag.ListaDeWbss = new SelectList(_wbssService!.Listar(), "Id", "Descricao");
            return View();
        }

        [HttpPost]
        public IActionResult LancarHorasDTO(LancamentoHorasDTO lancamentoHorasDTO)
        {
            try
            {
                ViewBag.ListaDeWbss = new SelectList(_wbssService!.Listar(), "Id", "Descricao");

                List<object> propridadesLancamentoHoras = new List<object>();

                PropertyInfo[] propertyInfos = typeof(LancamentoHorasDTO).GetProperties();
                foreach (var propertyInfo in propertyInfos)
                {
                    propridadesLancamentoHoras.Add(propertyInfo.GetValue(lancamentoHorasDTO)!);
                }
                var quinzena = _quinzenasService.CriarQuinzena();
                var num_registro = quinzena.DiasDoMes!.Count;

                RegistroHoras rh = new RegistroHoras();
                if ((int)propridadesLancamentoHoras[0] == 0)
                {
                    throw new ArgumentException($"Necessário informar uma Wbs.");
                }
                    for (int j = 0; j < num_registro; j++)
                {
                    if ((int)propridadesLancamentoHoras[j] < 0)
                    {
                        throw new ArgumentException($"Todos os campos devem ser preenchidos.");
                    }

                    var registro = _registroHorasService!.RegistroExiste(Utils.IdCpf!, quinzena.DiasDoMes[j], (int)propridadesLancamentoHoras[0]);
                        if (registro.Any())
                    {
                        throw new Exception($"Não é permitido lançar horas para mesma WBS no mesmo dia: {quinzena.DiasDoMes[j+1]}");
                    }
                }
                
                for (int i = 0; i < num_registro; i++)
                {
                    rh.DataRegistro = DateTime.Now;
                    rh.WbsId = (int)propridadesLancamentoHoras[0];
                    rh.CpfId = Utils.IdCpf;
                    rh.Dia = quinzena.DiasDoMes[i];
                    rh.Horas = (int)propridadesLancamentoHoras[i+1];

                    _registroHorasService!.Incluir(rh);
                    
                }
            }
            catch (Exception ex)
            {

                return View("_Erro", ex);
            }
            return View();
        }



        [HttpGet]
        public IActionResult ListarRegistrosQuinzena()
        {
            try
            {
                var quinzena = _quinzenasService.CriarQuinzena();
                var cpf = Utils.IdCpf;
                var inicioQuinzena = quinzena.InicioDaQuinzena;
                var fimQuinzena = quinzena.FimDaQuinzena;

                var lista = _registroHorasService!.Listar(cpf!, inicioQuinzena, fimQuinzena);

                return View(lista);
            }
            catch (Exception ex)
            {

                return View("_Erro", ex);
            }
        }

    }
}