using Microsoft.CodeAnalysis.Options;
using ProjetoMyTe.AppWeb.DAL;
using ProjetoMyTe.AppWeb.Models.Contexts;
using ProjetoMyTe.AppWeb.Models.DTO;
using ProjetoMyTe.AppWeb.Models.Entities;
using ProjetoMyTe.AppWeb.Services;

namespace ProjetoMyTe.AppWeb.Services
{
    public class RegistroHorasService
    {
        public GenericDAO<RegistroHoras> RegistrosDao { get; set; }
        public MyTeContext Context { get; set; }
        public QuinzenasService quinzenasService { get; set; }

        public RegistroHorasService(MyTeContext context, QuinzenasService quinzenasService)
        {
            this.RegistrosDao = new GenericDAO<RegistroHoras>(context);
            this.Context = context;
            this.quinzenasService = quinzenasService;
        }

        //public IEnumerable<RegistroHoras> Listar()
        //{
        //    return this.RegistrosDao.Listar();
        //}
        public IEnumerable<RegistroHorasDTO> Listar()
        {
            var lista = from r in Context.RegistroHoras
                        join w in Context.Wbss
                        on r.WbsId equals w.Id
                        join c in Context.Colaboradores
                        on r.CpfId equals c.Id
                        select new RegistroHorasDTO
                        {
                            Id = r.Id,
                            DataRegistro = r.DataRegistro,
                            CodigoWbs = w.Codigo,
                            WbsId = w.Descricao,
                            CpfId = c.Id,
                            NomeColaborador = c.Nome,
                            Dia = r.Dia,
                            Horas = r.Horas

                        };
            return lista.ToList();
        }
        public IEnumerable<RegistroHorasDTO> Listar(string cpf, DateTime inicioQuinzena, DateTime fimQuinzena)
        {
            var lista = from r in Context.RegistroHoras
                        join w in Context.Wbss
                        on r.WbsId equals w.Id
                        join c in Context.Colaboradores
                        on r.CpfId equals c.Id
                        where r.CpfId == cpf
                        && r.Dia >= inicioQuinzena
                        && r.Dia <= fimQuinzena
                        select new RegistroHorasDTO
                        {
                            Id = r.Id,
                            DataRegistro = r.DataRegistro,
                            CodigoWbs = w.Codigo,
                            WbsId = w.Descricao,
                            CpfId = c.Id,
                            NomeColaborador = c.Nome,
                            Dia = r.Dia,
                            Horas = r.Horas

                        };
            return lista.ToList();
        }

        

        public RegistroHoras? Buscar(int id)
        {
            return RegistrosDao.Buscar(id);
        }

        public void Incluir(RegistroHoras registroHora)
        {
            RegistrosDao.Adicionar(registroHora);
        }

        public void Alterar(RegistroHoras registroHora)
        {
            RegistrosDao.Alterar(registroHora);
        }

        public void Remover(RegistroHoras registroHora)
        {
            RegistrosDao.Remover(registroHora);
        }
    }
}
