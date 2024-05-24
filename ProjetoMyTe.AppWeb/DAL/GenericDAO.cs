using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using ProjetoMyTe.AppWeb.Models.Contexts;

namespace ProjetoMyTe.AppWeb.DAL
    // a vantagem da criação dessa classe genérica é poder fazer uso dela, independente da classe, ou seja adicionar T tipos de dados, nas diferentes entidades.
{
    // limitando a criação da classe parametrizada de qualquer tipo, desde que seja uma classe (where T: class)
    public class GenericDAO<T> where T : class
    {
        private MyTeContext Context { get; set; }

        // criando o construtor (obrigando o passagem do parâmetro)
        public GenericDAO(MyTeContext context)
        {
            this.Context = context;
        }

        // adicionando entidades qualquer (T),  no sentido de registro
        public void Adicionar(T item)
        {
            Context.Add(item);
            Context.SaveChanges();
        }

        // listando as entidade qualquer que seja (T), ou seja: lista colaboradores, cargos, wbs, registrosHoras...etc

        public IEnumerable<T> Listar() 
        {
            return Context.Set<T>().ToList();
        }

        // alterando 
        public void Alterar(T item)
        {
            Context.Entry<T>(item).State = EntityState.Modified;
            Context.SaveChanges();
        }
        // definido com o tipo dynamic, por conta do id cpf que é uma string
        public T? Buscar(dynamic id)
        {
            return Context.Set<T>().Find(id);
        }
              
        // remover do uma entidade pelo id
       
        public void Remover(T item)
        {
            Context.Entry(item).State = EntityState.Deleted;
            Context.SaveChanges();
        }
    }
}
