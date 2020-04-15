using System;
using System.Collections.Generic;
using System.Text;
using TBoard.Entities;
using TBoard.Repository;
using TBoard.Repository.ResourceParameters;

namespace TBoard.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly ITournamentRepository tournamentRepository;


        public TournamentService(ITournamentRepository repo)
        {
            this.tournamentRepository = repo;

        }
        public void DeleteById(int id)
        {
            tournamentRepository.DeleteById(id);
        }

        public IEnumerable<Tournament> GetAll(TournamentResourceParameters tournamentResourceParams)
        {
            if (tournamentResourceParams == null)
            {
                return tournamentRepository.GetAll();
            }
            else
            {
                return tournamentRepository.GetAll(tournamentResourceParams);
            }
        }

        public Tournament GetById(int id)
        {
            var result = tournamentRepository.GetById(id);
            return result;
        }

        public void AddTournament(Tournament entity)
        {
            tournamentRepository.Add(entity);
        }

        public void Update(Tournament entity)
        {
            tournamentRepository.Update(entity);
        }

        public bool Exists(int tournamentId)
        {
            if (tournamentRepository.Exists(tournamentId))
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
            tournamentRepository.SaveChanges();
        }
    }
}
