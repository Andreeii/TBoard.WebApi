using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBoard.Dto;
using TBoard.Entities;
using TBoard.WebApi.Repositories.Interfaces;
using TBoard.WebApi.ResourceParameters;

namespace TBoard.WebApi.Services.Implementation
{
    public class TournamentService : ITournamentService
    {
        private readonly ITournamentRepository tournamentRepository;
        private readonly IMapper mapper;


        public TournamentService(ITournamentRepository tournamentRepository, IMapper mapper)
        {
            this.tournamentRepository = tournamentRepository;
            this.mapper = mapper;

        }
        public void DeleteById(int id)
        {
            tournamentRepository.DeleteById(id);
            tournamentRepository.SaveChanges();
        }

        public IEnumerable<TournamentDto> GetAll(TournamentResourceParameters tournamentResourceParameters)
        {
            IEnumerable<Tournament> result;
            if (tournamentResourceParameters == null)
            {
                result = tournamentRepository.GetAll();
                return mapper.Map<IEnumerable<TournamentDto>>(result);
            }
            else
            {
                result = tournamentRepository.GetAll(tournamentResourceParameters);
                return mapper.Map<IEnumerable<TournamentDto>>(result);
            }
        }

        public TournamentDto GetById(int tournamentId)
        {
            var result = tournamentRepository.GetById(tournamentId);
            return mapper.Map<TournamentDto>(result);
        }

        public Tournament AddTournament(TournamentForCreationDto tournament)
        {
            var tournamentEntity = mapper.Map<Tournament>(tournament);
            tournamentRepository.Add(tournamentEntity);
            tournamentRepository.SaveChanges();
            var tournamentToReturn = mapper.Map<Tournament>(tournamentEntity);
            return tournamentToReturn;

        }

        public TournamentDto Update(TournamentDto tournament)
        {
            var tournamentEntity = mapper.Map<Tournament>(tournament);
            tournamentRepository.Update(tournamentEntity);
            tournamentRepository.SaveChanges();
            var tournamentToReturn = mapper.Map<TournamentDto>(tournamentEntity);
            return tournamentToReturn;
        }

    }
}
