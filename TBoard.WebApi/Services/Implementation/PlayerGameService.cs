using AutoMapper;
using System;
using TBoard.Dto;
using TBoard.Entities;
using TBoard.WebApi.Repositories.Interfaces;
using TBoard.WebApi.Services.Interfaces;

namespace TBoard.WebApi.Services.Implementation
{
    public class PlayerGameService:IPlayerGameService
    {
        private readonly IPlayerGameRepository playerGameRepository;
        private readonly IMapper mapper;


        public PlayerGameService(IPlayerGameRepository playerGameRepository, IMapper mapper)
        {
            this.playerGameRepository = playerGameRepository;
            this.mapper = mapper;
        }


        public PlayerGameDto Post(PlayerGameDto playerGame)
        {
            var gameEntity = mapper.Map<PlayerGame>(playerGame);
            playerGameRepository.Post(gameEntity);
            playerGameRepository.SaveChanges();
            var gameToReturn = mapper.Map<PlayerGameDto>(gameEntity);

            return gameToReturn;
        }

        public PlayerGameDto[] PostAll(PlayerGameDto[] playerGames)
        {
            PlayerGame[] gamesEntity = new PlayerGame[playerGames.Length];
            for (int i = 0; i < playerGames.Length; i++)
            {
                gamesEntity[i] = mapper.Map<PlayerGame>(playerGames[i]);
            }
            playerGameRepository.PostAll(gamesEntity);
            playerGameRepository.SaveChanges();

            return playerGames;

        }

    }
}
