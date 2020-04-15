using System;
using System.Collections.Generic;
using System.Text;
using TBoard.Entities;
using TBoard.Repository.ResourceParameters;

namespace TBoard.Repository
{
    public interface ITournamentRepository
    {
        //find objects
        Tournament GetById(int id);

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
