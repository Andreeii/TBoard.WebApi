using AutoMapper;
using Microsoft.EntityFrameworkCore.Internal;
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
        private readonly IPlayerGameRepository playerGameRepository;
        private readonly IGameRepository gameRepository;
        private readonly IMapper mapper;


        public TournamentService(ITournamentRepository tournamentRepository, IGameRepository gameRepository, IPlayerGameRepository playerGameRepository, IMapper mapper)
        {
            this.tournamentRepository = tournamentRepository;
            this.gameRepository = gameRepository;
            this.playerGameRepository = playerGameRepository;
            this.mapper = mapper;

        }
        public void DeleteById(int id)
        {
            tournamentRepository.DeleteById(id);
            tournamentRepository.SaveChanges();
        }
        public object GetTournamentWithWinner(TournamentResourceParameters tournamentResourceParameters)
        {
            if (!string.IsNullOrWhiteSpace(tournamentResourceParameters.SearchQuery))
            {
                var searchQuery = tournamentResourceParameters.SearchQuery.Trim();
                var q3 = playerGameRepository.GetAll()
             .Where(x => x.IsWinner == true)
             .GroupBy(x => new { x.PlayerId, x.Game.TournamentId })
             .Select(x => new
             {
                 PlayerId = x.Key.PlayerId,
                 TournamentId = x.Key.TournamentId,
                 Wins = x.Count()

             });
                var q4 = playerGameRepository.GetAll()
                         .Where(x => x.IsWinner == true)
                         .GroupBy(x => new { x.PlayerId, x.Game.TournamentId, x.Game.Tournament.Name, x.Player.UserName })
                         .Select(x => new
                         {
                             PlayerId = x.Key.PlayerId,
                             TournamentId = x.Key.TournamentId,
                             NumberOfWins = x.Count(),
                             WinnerName = x.Key.UserName,
                             TournamentName = x.Key.Name

                         })
                         .Where(x => x.NumberOfWins == q3.Where(y => y.TournamentId == x.TournamentId).Max(y => y.Wins))
                         .Where(a => a.TournamentName.Contains(searchQuery));

                return q4.ToList();
            }
            var q1 = playerGameRepository.GetAll()
                 .Where(x => x.IsWinner == true)
                 .GroupBy(x => new { x.PlayerId, x.Game.TournamentId })
                 .Select(x => new
                 {
                     PlayerId = x.Key.PlayerId,
                     TournamentId = x.Key.TournamentId,
                     Wins = x.Count()

                 });
            var q2 = playerGameRepository.GetAll()
                     .Where(x => x.IsWinner == true)
                     .GroupBy(x => new { x.PlayerId, x.Game.TournamentId, x.Game.Tournament.Name, x.Player.UserName })
                     .Select(x => new
                     {
                         PlayerId = x.Key.PlayerId,
                         TournamentId = x.Key.TournamentId,
                         NumberOfWins = x.Count(),
                         WinnerName = x.Key.UserName,
                         TournamentName = x.Key.Name

                     })
                     .Where(x => x.NumberOfWins == q1.Where(y => y.TournamentId == x.TournamentId).Max(y => y.Wins));

            return q2.ToList();
        }

        public object GetWinnedTournaments(int playerId)
        {
            var q1 = playerGameRepository.GetAll()
            .Where(x => x.IsWinner == true)
            .Where(x => x.PlayerId == playerId)
            .GroupBy(x => new { x.PlayerId, x.Game.TournamentId })
            .Select(x => new
            {
                PlayerId = x.Key.PlayerId,
                TournamentId = x.Key.TournamentId,
                Wins = x.Count()

            });

            var q2 = playerGameRepository.GetAll()
                .Where(x => x.IsWinner == true)
                .GroupBy(x => new { x.Game.TournamentId, x.Game.Tournament.Name, x.Player.UserName })
                .Select(x => new
                {
                    TournamentId = x.Key.TournamentId,
                    NumberOfWins = x.Count(),
                    PlayerName = x.Key.UserName,
                    TournamentName = x.Key.Name
                })
                .Where(x => x.NumberOfWins == q1.Where(y => y.TournamentId == x.TournamentId).Max(y => y.Wins));
            return q2.ToList();
        }

        public TournamentDto GetById(int tournamentId)
        {
            var tournament = tournamentRepository.GetById(tournamentId);
            var tournamentDto = mapper.Map<TournamentDto>(tournament);
            return tournamentDto;
        }

        public TournamentDto AddTournament(TournamentDto tournament)
        {
            if (tournament == null)
            {
                throw new ArgumentNullException(nameof(tournament));
            }
            var tournamentEntity = mapper.Map<Tournament>(tournament);
            tournamentRepository.Add(tournamentEntity);
            tournamentRepository.SaveChanges();
            var tournamentDto = mapper.Map<TournamentDto>(tournamentEntity);
            return tournamentDto;

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
