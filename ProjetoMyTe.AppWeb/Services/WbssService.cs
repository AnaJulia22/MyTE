using ProjetoMyTe.AppWeb.DAL;
using ProjetoMyTe.AppWeb.Models.Contexts;
using ProjetoMyTe.AppWeb.Models.DTO;
using ProjetoMyTe.AppWeb.Models.Entities;

namespace ProjetoMyTe.AppWeb.Services
{
    public class WbssService
    {
        public GenericDAO<Wbs> WbssDao { get; set; }
        public MyTeContext Context { get; set; }
        public WbssService(MyTeContext context) 
        {
            this.WbssDao = new GenericDAO<Wbs>(context);
            this.Context = context;
        }

        //public IEnumerable<Wbs> Listar() 
        //{
        //    return WbssDao.Listar();
        //}
        public IEnumerable<WbsDTO> Listar()
        {
            List<WbsDTO> wbss = new List<WbsDTO>();
            foreach(var item in WbssDao.Listar())
            {
                var c = new WbsDTO()
                {
                    Id = item.Id,
                    Codigo = item.Codigo,
                    Descricao = item.Codigo + " - " + item.Descricao,
                    Tipo = item.Tipo == 1 ? "Chargeability" : "Non-Chargeability"
                };
                wbss.Add(c);
            }
                return wbss;
        }
        public void AdicionarWbs(Wbs wbs) 
        {
            WbssDao.Adicionar(wbs);
        }

        public void Alterar(Wbs wbs)
        {
            WbssDao.Alterar(wbs);
        }
        public Wbs? Buscar(int id)
        {
            return WbssDao.Buscar(id);  
        }
        public void Remover(Wbs wbs)
        {
            WbssDao.Remover(wbs);
        }


    }
}
