using Microsoft.EntityFrameworkCore;
using MyTe.API.Models.Contexts;

namespace MyTe.API.DAL
{
    public class GenericDao<T, K> where T : class
    {
        public MyTeContext Context { get; set; }
        public GenericDao(MyTeContext context)
        {
            this.Context = context;
        }
        // Listando todas as entidades
        public IEnumerable<T> Listar()
        {
            return Context.Set<T>().ToList();
        }

        // Buscando uma entidade pelo Id
        public T? Buscar(K id)
        {
            return Context.Set<T>().Find(id);
        }

        // Adicionar entidades
        public void Adicionar(T item)
        {
            //Context.Add<T>(item);
            Context.Entry<T>(item).State = EntityState.Added;
            Context.SaveChanges();
        }

        // Alterar Entidades
        public void Alterar(T item)
        {
            Context.Entry<T>(item).State = EntityState.Modified;
            Context.SaveChanges();
        }

        // Remover Entidades
        public void Remover(T item)
        {
            Context.Entry<T>(item).State = EntityState.Deleted;
            Context.SaveChanges();
        }
    }
}
