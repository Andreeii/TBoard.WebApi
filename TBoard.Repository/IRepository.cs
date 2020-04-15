using System;
using System.Collections.Generic;
using System.Text;

namespace TBoard.Repository
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
