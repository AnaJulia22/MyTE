using MyTe.API.Models.Contexts;
using MyTe.API.Models;
using MyTe.API.DAL;

namespace MyTe.API.Services
{
    public class WbssService
    {
        public GenericDao<Wbs, int> WbssDao { get; set; }
        private MyTeContext MyTeContext { get; set; }
        public WbssService(MyTeContext context)
        {
            this.WbssDao = new GenericDao<Wbs, int>(context);
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
        public Wbs? Buscar(int id)
        {
            return WbssDao.Buscar(id);
        }

    }
}
