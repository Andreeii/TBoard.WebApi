using AutoMapper;
using System;
using System.Linq;
using TBoard.Dto;
using TBoard.Entities;
using TBoard.WebApi.Repositories.Interfaces;

namespace TBoard.WebApi.Services.Implementation
{
    public class TournamentService : ITournamentService
    {
        private readonly ITournamentRepository tournamentRepository;
        private readonly IGenericRepository<PlayerGame> playerGameRepository;
        private readonly IMapper mapper;


        public TournamentService(ITournamentRepository tournamentRepository, IGenericRepository<PlayerGame> playerGameRepository, IMapper mapper)
        {
            this.tournamentRepository = tournamentRepository;
            this.playerGameRepository = playerGameRepository;
            this.mapper = mapper;

        }
        public void DeleteById(int id)
        {
            tournamentRepository.DeleteById(id);
            tournamentRepository.SaveChanges();
        }
        public object GetTournamentWithWinner()
        {
            var q3 = playerGameRepository.GetAll()
                     .Where(x => x.IsWinner == true)
                     .GroupBy(x => new { x.PlayerId, x.Games.TournamentId })
                     .Select(x => new
                     {
                         PlayerId = x.Key.PlayerId,
                         TournamentId = x.Key.TournamentId,
                         Wins = x.Count()

                     });
            var q4 = playerGameRepository.GetAll()
                     .Where(x => x.IsWinner == true)
                     .GroupBy(x => new { x.PlayerId, x.Games.TournamentId, x.Games.Tournament.Name, x.Players.UserName })
                     .Select(x => new
                     {
                         PlayerId = x.Key.PlayerId,
                         TournamentId = x.Key.TournamentId,
                         NumberOfWins = x.Count(),
                         WinnerName = x.Key.UserName,
                         TournamentName = x.Key.Name

                     })
                     .Where(x => x.NumberOfWins == q3.Where(y => y.TournamentId == x.TournamentId).Max(y => y.Wins));

            return q4.ToList();
        }

        public object GetWinnedTournaments(int playerId)
        {
            var q1 = playerGameRepository.GetAll()
                    .Where(x => x.IsWinner == true)
                    .Where(x => x.PlayerId == playerId)
                    .GroupBy(x => new { x.PlayerId, x.Games.Tournament.Id, x.Games.Tournament.Name })
                    .Select(x => new
                    {
                        TournamentId = x.Key.Id,
                        TournamentName = x.Key.Name,
                        Wins = x.Count()
                    });
            return q1.ToList();
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
