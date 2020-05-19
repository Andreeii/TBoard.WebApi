using System.Linq;
using TBoard.WebApi.Repositories.Interfaces;

namespace TBoard.WebApi.Repositories.Implementation
{

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly TournamentContext tournamentContext;

        public GenericRepository(TournamentContext context)
        {
            tournamentContext = context;
        }


        public T Add(T entity)
        {
            var result = tournamentContext.Set<T>().Add(entity);
            return result.Entity;

        }


        public IQueryable<T> GetAll()
        {
            return tournamentContext.Set<T>();
        }

        public T GetById(int id)
        {
            return tournamentContext.Set<T>().Find(id);
        }


        public void DeleteById(int id)
        {
            T existing = tournamentContext.Set<T>().Find(id);
            tournamentContext.Set<T>().Remove(existing);
        }


        public void SaveChanges()
        {
            tournamentContext.SaveChanges();
        }

    }

}