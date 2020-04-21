using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TBoard.WebApi.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        //find objects
        T GetById(int id);

        //add objects
        void Add(T entity);

        //remove objects
        void DeleteById(int id);

        IEnumerable<T> GetAll();
        //update
        void Update(T entity);

        bool Exists(int id);

        public void SaveChanges();
    }
}
