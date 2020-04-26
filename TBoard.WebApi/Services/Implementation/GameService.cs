using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBoard.Dto;
using TBoard.Entities;
using TBoard.WebApi.Repositories.Interfaces;
using TBoard.WebApi.Services.Interfaces;

namespace TBoard.WebApi.Services.Implementation
{
    public class GameService : IGameService
    {
        private readonly IGameRepository gameRepository;
        private readonly ITournamentRepository tournamentRepository;
        private readonly IMapper mapper;

        public GameService(IGameRepository gameRepository, ITournamentRepository tournamentRepository,IMapper mapper)
        {
            this.gameRepository = gameRepository;
            this.tournamentRepository = tournamentRepository;
            this.mapper = mapper;
        }
        public void DeleteById(int id)
        {
            gameRepository.DeleteById(id);
            gameRepository.SaveChanges();
        }

        public IEnumerable<GameDto> GetByTournamentId(int tournamentId)
        {
           var result = gameRepository.GetByTournamentId(tournamentId);
            return mapper.Map<IEnumerable<GameDto>>(result);

        }
        public GameDto GetById(int id)
        {
            var result = gameRepository.GetById(id);
            return (mapper.Map<GameDto>(result)); ;
        }

        public GameDto Post(GameForCreationDto game)
        {

            var gameEntity = mapper.Map<Game>(game);
            gameRepository.Post(gameEntity);
            gameRepository.SaveChanges();
            var gameToReturn = mapper.Map<GameDto>(gameEntity);

            return gameToReturn;
        }

        public void Update(Game entity)
        {
            gameRepository.Update(entity);
        }

        public bool TournamentExists(int id)
        {
            if (tournamentRepository.Exists(id) == true)
                return true;
            else
                return false;
        }

        public bool GameExists(int id)
        {
            if (gameRepository.GameExists(id) == true)
                return true;
            else
                return false;
        }

        public void SaveChanges()
        {
            gameRepository.SaveChanges();
        }
    }
}
