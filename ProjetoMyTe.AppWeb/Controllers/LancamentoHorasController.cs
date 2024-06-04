using Microsoft.AspNetCore.Mvc;
using ProjetoMyTe.AppWeb.Models.Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using ProjetoMyTe.AppWeb.Models.DTO;
using ProjetoMyTe.AppWeb.Models.Entities;
using ProjetoMyTe.AppWeb.Services;
using System.Reflection;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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
        public IActionResult LancarHorasDTO(List<int> WbsId, List<int> Horas)
        {

            //listando a WBS para o usuário
            ViewBag.ListaDeWbss = new SelectList(_wbssService!.Listar(), "Id", "Descricao");

            //Criando a quinzena para sabermos quantos dias teremos na quinzena.
            var quinzena = _quinzenasService.CriarQuinzena();
            var num_registro = quinzena.DiasDoMes!.Count;

            try
            {
                var listaHoras = Horas;
                var listaWbs = WbsId;

                List<int> SomarHoras = new List<int>(new int[num_registro]);

                List<List<int>> SublistasHoras = new List<List<int>>();
                int TamSublista = num_registro;
                for (int i = 0; i < listaHoras.Count; i += TamSublista)
                {
                    List<int> sublista = listaHoras.GetRange(i, Math.Min(TamSublista, listaHoras.Count - i));
                    SublistasHoras.Add(sublista);
                }

                for (int i = 0; i < SublistasHoras.Count; i++)
                {
                    for (int j = 0; j < num_registro; j++)
                    {

                        SomarHoras[j] += SublistasHoras[i][j];
                    }
                }


                for (int x = 0; x < num_registro; x++)
                {
                    if (SomarHoras[x] != 8 && quinzena.DiasUteis!.Contains(quinzena.GetDia(x)))
                    {
                        throw new Exception("A carga horária de 8/dia não foi cumprida. Favor, revise seus lançamentos");
                    }

                }

                //Registrando cada wbs no banco
                for (int i = 0; i < SublistasHoras.Count; i++)
                {
                    for (int j = 0; j < num_registro; j++)
                    {

                        if (SublistasHoras[i][j] != 0)
                        {
                            var registro = _registroHorasService!.RegistroExiste(Utils.IdCpf!, quinzena.DiasDoMes[j], listaWbs[i]);

                            if (registro.Any())
                            {
                                throw new Exception($"Não é permitido lançar horas para a mesma WBS no mesmo dia: {quinzena.DiasDoMes[j + 1].Date}");
                            }
                            RegistroHoras rh = new RegistroHoras();
                            rh.DataRegistro = DateTime.Now;
                            rh.WbsId = listaWbs[i];
                            rh.CpfId = Utils.IdCpf;
                            rh.Dia = quinzena.DiasDoMes[j];
                            rh.Horas = SublistasHoras[i][j];

                            _registroHorasService!.Incluir(rh);
                            rh = null;
                        }

                    }
                }
                TempData["AlertMessage"] = "Registro criado com sucesso!!!";
                return RedirectToAction("ListarRegistrosQuinzena");
            }
            catch (Exception ex)
            {

                return View("_Erro", ex);
            }

            //return View();


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