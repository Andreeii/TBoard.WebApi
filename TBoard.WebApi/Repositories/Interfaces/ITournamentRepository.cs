using System.Collections.Generic;
using TBoard.Entities;

namespace TBoard.WebApi.Repositories.Interfaces
{
    public interface ITournamentRepository
    {
        Tournament GetById(int id);
        Tournament Add(Tournament entity);

        void DeleteById(int id);

        IEnumerable<Tournament> GetAll();
        void Update(Tournament entity);

        void SaveChanges();
    }
}
