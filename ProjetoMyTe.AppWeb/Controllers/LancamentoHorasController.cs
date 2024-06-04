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
               //listando a WBS para o usuário
                ViewBag.ListaDeWbss = new SelectList(_wbssService!.Listar(), "Id", "Descricao");

                //Criando a quinzena para sabermos quantos dias teremos na quinzena.
                var quinzena = _quinzenasService.CriarQuinzena();
                var num_registro = quinzena.DiasDoMes!.Count;

                //criando uma lista para armazenar as propriedades e seus respectivos valores que virão do post
                List<object> propridadesLancamentoHoras = new List<object>();

                //do PropertyInfo, ele que fará o trabalho de capturar as propriedades, da classe referida em parâmetro
                PropertyInfo[] propertyInfos = typeof(LancamentoHorasDTO).GetProperties();

                //percorrendo as propriedade capturadas e associando a elas os valores passados pelo usuário
                foreach (var propertyInfo in propertyInfos)
                {
                    //atente-se a ordem que os dados virão, pois teremos que saber as posições chaves para manupula-lo
                    propridadesLancamentoHoras.Add(propertyInfo.GetValue(lancamentoHorasDTO)!);
                }

                

                //verificando se a primeira propriedade é a WBS, pois ela deve ser validada, seu início é maior que 0
                if ((int)propridadesLancamentoHoras[0] == 0)
                {
                    throw new ArgumentException($"Necessário informar uma Wbs.");
                }

                //laço de verificação de campo vazio e lançamento duplicado
                var dias_sem_preencher = 0;
                for (int j = 0; j < num_registro; j++)
                {
                    
                    //verificando se foi lançada hora
                    if ((int)propridadesLancamentoHoras[j+1] <= 0)
                    {
                        dias_sem_preencher++;
                    }
                    //verificando se temos registro do mesmo usuário para o mesmo dia e wbs, o retorno será uma lista.
                    var registro = _registroHorasService!.RegistroExiste(Utils.IdCpf!, quinzena.DiasDoMes[j], (int)propridadesLancamentoHoras[0]);
                //se houver algum registro dá uma exceção   
                    if (registro.Any())
                    {
                        throw new Exception($"Não é permitido lançar horas para a mesma WBS no mesmo dia: {quinzena.DiasDoMes[j+1].Date}");
                    }
                   
                 }
                if (dias_sem_preencher >= quinzena.DiasDoMes.Count)
                {
                    throw new ArgumentException($"Pelo menos 1 campo de horas deve ser preenchido.");
                }
                //tudo validade, vamos adicionar 1 registro por vez para que os dados fiquem bem granulado.
                for (int i = 0; i < num_registro; i++)
                {
                    //criando uma referencia ao objeto do tipo registro hora
                    RegistroHoras rh = new RegistroHoras();
                    if ((int)propridadesLancamentoHoras[i+1] > 0) 
                    { 
                        rh.DataRegistro = DateTime.Now;
                        rh.WbsId = (int)propridadesLancamentoHoras[0];
                        rh.CpfId = Utils.IdCpf;
                        rh.Dia = quinzena.DiasDoMes[i];
                        rh.Horas = (int)propridadesLancamentoHoras[i+1];

                    _registroHorasService!.Incluir(rh);
                        rh = null;
                    }
                }
                return RedirectToAction("ListarRegistrosQuinzena");
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