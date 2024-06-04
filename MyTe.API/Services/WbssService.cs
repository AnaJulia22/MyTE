using MyTe.API.Models.Contexts;
using MyTe.API.Models;
using MyTe.API.DAL;
using MyTe.API.Models.DTO;
using System.Linq;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System;

namespace MyTe.API.Services
{
    public class WbssService
    {
        public GenericDao<Wbs, string> WbssDao { get; set; }
        private MyTeContext MyTeContext { get; set; }
       
        public WbssService(MyTeContext context)
        {
            this.WbssDao = new GenericDao<Wbs, string>(context);
            this.MyTeContext = context;
        }

        public IEnumerable<Wbs> Listar()
        {
            return WbssDao.Listar();
        }

        public void AdicionarWbs(Wbs wbs)
        {
            WbssDao.Adicionar(wbs);
        }
        public void Alterar(Wbs wbs)
        {
            WbssDao.Alterar(wbs);
        }
        public void Remover(Wbs wbs)
        {
            WbssDao.Remover(wbs);
        }
        public Wbs? Buscar(string codigoWbs)
        {
            return WbssDao.Buscar(codigoWbs);
        }
        public IEnumerable<WbsDTOApi> ListarWbsDTO()
        {


            var listaWbs = from col in MyTeContext.Colaboradores
                           join car in MyTeContext.Cargos on col.CargoId equals car.Id
                           join rsg in MyTeContext.RegistroHoras on col.Id equals rsg.CpfId
                           join sbw in MyTeContext.Wbss on rsg.WbsId equals sbw.Id

                           group new { sbw, rsg } by sbw.Codigo into g

                           select new WbsDTOApi

                           {
                               codigoWbs = g.First().sbw.Codigo,
                               WbsDescricao = g.First().sbw.Descricao,
                               DataRegistro = g.First().rsg.DataRegistro,
                               Hora = g.Sum(total => total.rsg.Horas),
                               

                           };
            return listaWbs.ToList();
            
        }
        
   
        }

    }

