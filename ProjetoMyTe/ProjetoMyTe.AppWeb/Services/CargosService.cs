using ProjetoMyTe.AppWeb.DAL;
using ProjetoMyTe.AppWeb.Models.Contexts;
using ProjetoMyTe.AppWeb.Models.Entities;

namespace ProjetoMyTe.AppWeb.Services
{
    public class CargosService
    {
        public GenericDAO<Cargo> CargosDao { get; set; }
        
        public CargosService(MyTeContext context) 
        {
            this.CargosDao = new GenericDAO<Cargo>(context);
            
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
