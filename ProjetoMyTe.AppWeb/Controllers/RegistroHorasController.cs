﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoMyTe.AppWeb.Models.Common;
using ProjetoMyTe.AppWeb.Models.Entities;
using ProjetoMyTe.AppWeb.Services;


namespace ProjetoMyTe.AppWeb.Controllers
{

    public class RegistroHorasController : Controller
    {
        private readonly RegistroHorasService registroHorasService;
        private readonly ColaboradoresService colaboradoresService;
        private readonly QuinzenasService quinzenasService;
        private readonly WbssService wbssService;

        public RegistroHorasController(RegistroHorasService registroHorasService, ColaboradoresService colaboradoresService,QuinzenasService quinzenasService, WbssService wbssService)
        {
            this.registroHorasService = registroHorasService;
            this.colaboradoresService = colaboradoresService;
            this.quinzenasService = quinzenasService;
            this.wbssService = wbssService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ListarRegistros()
        {
            try
            {
                var quinzena = quinzenasService.CriarQuinzena();
                var inicioQuinzena = quinzena.InicioDaQuinzena;
                var fimQuinzena = quinzena.FimDaQuinzena;

                var lista = registroHorasService!.Listar(Utils.IdCpf!, inicioQuinzena, fimQuinzena);

                return View(lista);
            }
            catch (Exception ex)
            {

                return View("_Erro", ex);
            }
        }
        
       

        [HttpGet]
        public IActionResult IncluirRegistro()
        {
            ViewBag.ListaDeWbss = new SelectList(wbssService.Listar(), "Id", "Descricao");
            ViewBag.ListaDeColaboradores = new SelectList(colaboradoresService.Listar(), "Id", "Nome");
            return View();
        }

        [HttpPost]
        public IActionResult IncluirRegistro(RegistroHoras registroHoras)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                var registro = registroHorasService!.RegistroExiste(Utils.IdCpf!, registroHoras.Dia, registroHoras.WbsId);
                if (registro.Any())
                {
                    throw new Exception($"Não é permitido lançar horas para mesma WBS no mesmo dia: {registroHoras.Dia}");
                }
                registroHoras.CpfId = Utils.IdCpf;
                registroHoras.DataRegistro = DateTime.Now;

                if (registroHoras.Horas != 8)
                {
                    throw new Exception("A carga horária de 8/dia não foi cumprida. Favor, revise seu lançamento.");
                }
                
                registroHorasService.Incluir(registroHoras);

                TempData["AlertMessage"] = "Registro criado com sucesso!!!";
                
                return RedirectToAction("ListarRegistrosQuinzena", "LancamentoHoras");
            }
            catch (Exception e)
            {

                return View("_Erro", e);
            }
        }

        [HttpGet]
        public IActionResult AlterarRegistro(int id)
        {
            try
            {
                ViewBag.ListaDeWbss = new SelectList(wbssService.Listar(), "Id", "Descricao");
                if (id <= 0)
                {
                    throw new
                        ArgumentException($"O valor informado na URL ({id}) é inválido");
                }

                RegistroHoras? registroHoras = registroHorasService.Buscar(id);
                if (registroHoras == null)
                {
                    throw new ArgumentException($"Nenhum objeto com este id: {id}");
                }
                return View(registroHoras);
            }
            catch (Exception e)
            {
                return View("_Erro", e);
            }
        }

        [HttpPost]
        public IActionResult AlterarRegistro(RegistroHoras registroHoras)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                RegistroHoras rh = new RegistroHoras();
                rh.DataRegistro = DateTime.Now;
                rh.WbsId = registroHoras.WbsId;
                rh.CpfId = Utils.IdCpf;
                rh.Dia = registroHoras.Dia;
                rh.Horas = registroHoras.Horas;
                if(rh.Horas != 8)
                {
                    throw new Exception("A carga horária de 8/dia não foi cumprida. Favor, revise seu lançamento");
                }
                
                registroHorasService.Alterar(rh);
                TempData["AlertMessage"] = "Registro alterado com sucesso!!!";
                rh = null!;
                return RedirectToAction("ListarRegistrosQuinzena", "LancamentoHoras");
            }
            catch (Exception e)
            {

                return View("_Erro", e);
            }
        }

        //[HttpGet]
        //public IActionResult RemoverRegistro(int id)
        //{
        //    try
        //    {
        //        if (id <= 0)
        //        {
        //            throw new
        //                ArgumentException($"O valor informado na URL ({id}) é inválido");
        //        }

        //        RegistroHoras? registroHoras = registroHorasService.Buscar(id);
        //        if (registroHoras == null)
        //        {
        //            throw new ArgumentException($"Nenhum objeto com este id: {id}");
        //        }
        //        return View(registroHoras);
        //    }
        //    catch (Exception e)
        //    {
        //        return View("_Erro", e);
        //    }
        //}

        [HttpPost]
        public IActionResult RemoverRegistro(int id)
        {
            try
            {
                var registroExistente = registroHorasService.Buscar(id);
                if (registroExistente == null)
                {
                    return RedirectToAction("ListarRegistrosQuinzena", "LancamentoHoras"); 
                }

                registroHorasService.Remover(registroExistente!);
                TempData["AlertMessage"] = "Registro removido com sucesso!!!";

                return RedirectToAction("ListarRegistrosQuinzena", "LancamentoHoras");
            }
            catch (Exception e)
            {
                return View("_Erro", e);
            }
        }
    }
}