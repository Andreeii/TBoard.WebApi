using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBoard.Entities;
using TBoard.WebApi.ResourceParameters;

namespace TBoard.WebApi.Repositories.Interfaces
{
    public interface ITournamentRepository
    {
        Tournament GetById(int id);

        //object GetTournamentWinner();

        void Add(Tournament entity);

        void DeleteById(int id);

        IEnumerable<Tournament> GetAll();
        void Update(Tournament entity);

        bool Exists(int id);

        public void SaveChanges();
    }
}
