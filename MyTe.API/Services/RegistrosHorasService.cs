using MyTe.API.DAL;
using MyTe.API.Models.Contexts;
using MyTe.API.Models;
using MyTe.API.Models.DTO;

namespace MyTe.API.Services
{
    public class RegistrosHorasService
    {
        public GenericDao<RegistroHoras, int> RegistrosDao { get; set; }
        private MyTeContext MyTeContext { get; set; }
        public RegistrosHorasService(MyTeContext context)
        {
            this.RegistrosDao = new GenericDao<RegistroHoras, int>(context);
            this.MyTeContext = context;
        }

        public IEnumerable<RegistroHoras> ListarRegistros()
        {
            return RegistrosDao.Listar();
        }

        public IEnumerable<RegistroHorasDTO> ListarRegistrosDTO()
        {
            var lista = from col in MyTeContext.Colaboradores
                        join car in MyTeContext.Cargos on col.CargoId equals car.Id
                        join rsg in MyTeContext.RegistroHoras on col.Id equals rsg.CpfId
                        join sbw in MyTeContext.Wbss on rsg.WbsId equals sbw.Id
                        select new RegistroHorasDTO
                        {
                            CpfColaborador = col.Id,
                            NomeColaborador = col.Nome,
                            codigoWbs = sbw.Codigo,
                            WbsDescricao = sbw.Descricao,
                            Cargo = car.Descricao,
                            Dia = rsg.Dia,

                        };
            return lista.ToList();
        }
    }
}
