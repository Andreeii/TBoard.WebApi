using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBoard.WebApi.Repositories.Interfaces;

namespace TBoard.WebApi.Repositories.Implementation
{

    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly TournamentContext TContext;

        protected DbSet<T> table;

        public Repository(TournamentContext context)
        {
            TContext = context;
            table = context.Set<T>();
        }


        public void Add(T entity)
        {
            TContext.Set<T>().Add(entity);
        }


        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(int id)
        {
            return table.Find(id);
        }


        public void DeleteById(int id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }

        public void Update(T entity)
        {
            table.Attach(entity);
            TContext.Entry(entity).State = EntityState.Modified;
        }

        public bool Exists(int id)
        {
            T existing = table.Find(id);
            if (existing != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void SaveChanges()
        {
            TContext.SaveChanges();
        }

    }

}