using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TBoard.WebApi.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);

        T Add(T entity);

        void DeleteById(int id);

        IQueryable<T> GetAll();

        public void SaveChanges();
    }
}
