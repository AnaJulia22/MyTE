using MyTe.API.Models.Contexts;
using MyTe.API.Models;
using MyTe.API.DAL;
using MyTe.API.Models.DTO;

namespace MyTe.API.Services
{
    public class ColaboradoresService
    {
        public GenericDao<Colaborador, string> ColaboraresDao { get; set; }
        private MyTeContext MyTeContext { get; set; }
        public ColaboradoresService(MyTeContext context)
        {
            this.ColaboraresDao = new GenericDao<Colaborador, string>(context);
            this.MyTeContext = context;
        }
        public IEnumerable<Colaborador> Listar(int idCargo)
        {
            if (idCargo > 0)
            {
                return ColaboraresDao.Listar().Where(c => c.CargoId == idCargo).ToList();
            }
            return ColaboraresDao.Listar();
        }

        public IEnumerable<Colaborador> ListarColaboradores()
        {
            return ColaboraresDao.Listar();
        }
        public void Adicionar(Colaborador colaborador)
        {
            ColaboraresDao.Adicionar(colaborador);
        }

        public void Alterar(Colaborador colaborador)
        {
            ColaboraresDao.Alterar(colaborador);
        }

        public Colaborador? Buscar(string id)
        {
            return ColaboraresDao.Buscar(id);
        }

        public void Remover(Colaborador colaborador)
        {
            ColaboraresDao.Remover(colaborador);
        }
        public IEnumerable<ColaboradoresDTO> ListarColaboradoresDTO()
        {
            var lista = from col in MyTeContext.Colaboradores
                        join car in MyTeContext.Cargos on col.CargoId equals car.Id
                        select new ColaboradoresDTO
                        {
                            IdColaborador = col.CargoId,
                            Nome = col.Nome,
                            Cpf = col.Id,
                            Cargo = car.Descricao, 
                        };
            return lista.ToList();
        }

    }
}
