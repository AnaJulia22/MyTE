using ProjetoMyTe.AppWeb.DAL;
using ProjetoMyTe.AppWeb.Models.Common;
using ProjetoMyTe.AppWeb.Models.Contexts;
using ProjetoMyTe.AppWeb.Models.DTO;
using ProjetoMyTe.AppWeb.Models.Entities;

namespace ProjetoMyTe.AppWeb.Services
{
    public class ColaboradoresService
    {
        public GenericDAO<Colaborador> ColaboraresDao { get; set; }
        public MyTeContext Context { get; set; }

        public ColaboradoresService(MyTeContext context) 
        {
            this.ColaboraresDao = new GenericDAO<Colaborador> (context);
            this.Context = context;
        }
        //list para ViewBag sem parametro
        public IEnumerable<Colaborador> Listar()
        {
            return ColaboraresDao.Listar();
        }
        public IEnumerable<Colaborador> Listar(int idCargo)
        {
            if(idCargo > 0)
            {
                return ColaboraresDao.Listar().Where(c => c.CargoId == idCargo).ToList();
            }
            return ColaboraresDao.Listar();
        }
        //Listar com DTO

        public IEnumerable<ColaboradorDTO> ListarCobaboradoresDTO(int idCargo)
        {
            List<ColaboradorDTO> colaboradores = new List<ColaboradorDTO>();
            foreach (var item in ColaboraresDao.Listar())
            {
                var c = new ColaboradorDTO()
                {
                    Id = item.Id,
                    CargoId = item.CargoId,
                    DescricaoCargo = item.CargoAtuacao!.Descricao,
                    //Administrador = item.Administrador,
                    Nome = item.Nome

                };
                colaboradores.Add(c);
            }
            if(idCargo > 0)
            {
                return colaboradores.Where(p => p.CargoId == idCargo);
            }
            return colaboradores;
        }

        public void Adicionar(Colaborador colaborador)
        {
            ColaboraresDao.Adicionar(colaborador);
        }

        public void Alterar(Colaborador colaborador)
        {
            ColaboraresDao.Alterar(colaborador);
        }

        public Colaborador? Buscar(int id)
        {
            return ColaboraresDao.Buscar(id);
        }

        public Colaborador? Buscar(string id)
        {
            return ColaboraresDao.Buscar(id);
        }

        public void Remover(Colaborador colaborador)
        {
            ColaboraresDao.Remover(colaborador);
        }

        public Colaborador? BuscarColaborador()
        {
            Colaborador? colaborador = Context.Colaboradores.FirstOrDefault(
                p => p.Id == Utils.IdCpf);

            return colaborador;

        }
    }
}
