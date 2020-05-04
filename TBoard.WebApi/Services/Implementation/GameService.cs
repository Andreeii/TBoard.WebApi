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
        private readonly IMapper mapper;

        public GameService(IGameRepository gameRepository,IMapper mapper)
        {
            this.gameRepository = gameRepository;
            this.mapper = mapper;
        }
        public void DeleteById(int id)
        {
            gameRepository.DeleteById(id);
            gameRepository.SaveChanges();
        }

        public ICollection<GameDto> GetAll(int tournamentId)
        {
           var result = gameRepository.GetByTournamentId(tournamentId).ToList();

            return mapper.Map<ICollection<GameDto>>(result);

        }


        public GameDto GetById(int id)
        {
            var result = gameRepository.GetById(id);
            return (mapper.Map<GameDto>(result)); 
        }


        public GameDto[] PostAll(GameDto[] games)
        {
            Game[] gamesEntity = new Game[games.Length];
            for (int i = 0; i < games.Length; i++)
            {
                gamesEntity[i] = mapper.Map<Game>(games[i]);
            }
            gameRepository.PostAll(gamesEntity);
            gameRepository.SaveChanges();

            return games;

        }


        public void Update(Game entity)
        {
            gameRepository.Update(entity);
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
