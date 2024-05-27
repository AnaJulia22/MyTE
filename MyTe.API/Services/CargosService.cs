using MyTe.API.Models.Contexts;
using MyTe.API.Models;
using MyTe.API.DAL;

namespace MyTe.API.Services
{
    public class CargosService
    {
        public GenericDao<Cargo, int> CargosDao { get; set; }

        public CargosService(MyTeContext context)
        {
            this.CargosDao = new GenericDao<Cargo, int>(context);
        }
        public IEnumerable<Cargo> Listar()
        {
            return CargosDao.Listar();
        }
        public void Adicionar(Cargo cargo)
        {
            CargosDao.Adicionar(cargo);
        }
        public void Alterar(Cargo cargo)
        {
            CargosDao.Alterar(cargo);
        }
        public Cargo? Buscar(int id)
        {
            return CargosDao.Buscar(id);
        }
        public void Remover(Cargo cargo)
        {
            CargosDao.Remover(cargo);
        }

    }
}
