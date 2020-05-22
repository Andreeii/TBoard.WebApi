using AutoMapper;
using System;
using System.Collections.Generic;
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
        public ICollection<TournamentWinnerDto> GetTournamentWithWinner()
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
                     .Select(x => new TournamentWinnerDto
                     {
                         //PlayerId = x.Key.PlayerId,
                         TournamentId = x.Key.TournamentId,
                         NumberOfWins = x.Count(),
                         WinnerName = x.Key.UserName,
                         TournamentName = x.Key.Name

                     })
                     .Where(x => x.NumberOfWins == q3.Where(y => y.TournamentId == x.TournamentId).Max(y => y.Wins))
                     .OrderBy(x => x.TournamentId);

            return q4.ToList();
        }


        public IList<int> GetProgress()
        {
            IList<int> progresList = new List<int>();
            var q5 = playerGameRepository.GetAll()
                .GroupBy(x => x.Games.TournamentId)
                .Select(x => x.Count())
                .ToList();

            var q6 = playerGameRepository.GetAll()
                .Where(x => x.IsWinner == true)
                .GroupBy(x => x.Games.TournamentId)
                .Select(x => x.Count())
                .ToList();

            for (int i = 0; i < q5.Count; i++)
            {
                //var total = q5[i] / 2;
                //var played = q6[i];
                var res = (int)((double)q6[i] / (q5[i] / 2) * 100);
                progresList.Add(res);
            }
            return progresList;

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
