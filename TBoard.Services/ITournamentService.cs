using System;
using System.Collections.Generic;
using System.Text;
using TBoard.Entities;
using TBoard.Repository.ResourceParameters;

namespace TBoard.Services
{
    public interface ITournamentService
    {

        public IEnumerable<Tournament> GetAll(TournamentResourceParameters tournamentResourceParameters);
        public Tournament GetById(int id);
        public void DeleteById(int id);
        public void AddTournament(Tournament entity);

        public void Update(Tournament entity);
        bool Exists(int id);

        public void SaveChanges();
    }
}
