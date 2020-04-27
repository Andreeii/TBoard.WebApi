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
        //find objects
        Tournament GetById(int id);

        void GetTournamentWinner();

        //add objects
        void Add(Tournament entity);

        //remove objects
        void DeleteById(int id);

        IEnumerable<Tournament> GetAll();
        IEnumerable<Tournament> GetAll(TournamentResourceParameters tournamentResourceParameters);
        //update
        void Update(Tournament entity);

        bool Exists(int id);

        public void SaveChanges();
    }
}
