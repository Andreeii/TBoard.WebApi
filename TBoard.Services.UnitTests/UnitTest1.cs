using System;
using System.Collections.Generic;
using TBoard.Dto;
using TBoard.WebApi.Repositories.Implementation;
using TBoard.WebApi.Services.Implementation;
using Xunit;

namespace TBoard.Services.UnitTests
{
    public class UnitTest1
    {
        private readonly ITournamentService tournamentService;
        public UnitTest1()
        {
           
        }

        [Fact]
        public void Test1()
        {
            //
            

            var tournament = new TournamentDto()
            {
                Name = "Tournament12",
                Game = new List<GameDto>()
                {
                    new GameDto
                    {
                        PlayerGame = new List<PlayerGameDto>()
                        {
                            new PlayerGameDto
                            {
                                Game = new GameDto(),
                                Player = new PlayerDto()
                                {
                                    Name = "aaa",
                                    Surname = "aaa",
                                    UserName = "a1",
                                    PasswordHash = "admin",
                                    Email = "aaa@gmail.com" 
                                } 
                            } 
                        } 
                    } 
                }
            };

            //act
           
            //assert

        }


    }
}
