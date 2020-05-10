using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBoard.Entities;
using TBoard.Entities.Auth;

namespace TBoard.WebApi
{
    public class Seed
    {

        public static async Task SeedTournaments(TournamentContext context)
        {
            if (!context.Tournament.Any())
            {
                var t1 = new Tournament()
                {
                    Name = "Tournament1",
                    CreationDate = DateTime.Now,
                    Game = new List<Game>()
                    {
                        new Game
                        {
                          PlayerGame = new List<PlayerGame>()
                          {
                              new PlayerGame
                              {
                                  PlayerId = 1,
                                  IsWinner = true
                              },
                              new PlayerGame
                              {
                                  PlayerId = 2,
                                  IsWinner = false
                              }
                          }
                        },
                        new Game
                        {
                          PlayerGame = new List<PlayerGame>()
                          {
                              new PlayerGame
                              {
                                  PlayerId = 1,
                                  IsWinner = true
                              },
                              new PlayerGame
                              {
                                  PlayerId = 3,
                                  IsWinner = false
                              }
                          }

                        },
                        new Game
                        {
                         PlayerGame = new List<PlayerGame>()
                          {
                              new PlayerGame
                              {
                                  PlayerId = 2,
                                  IsWinner = true
                              },
                              new PlayerGame
                              {
                                  PlayerId = 3,
                                  IsWinner = false
                              }
                          }
                        }
                    }
                };

                context.Tournament.Add(t1);
                await context.SaveChangesAsync();
            }
        }
     

        public static async Task SeedPlayers(Microsoft.AspNetCore.Identity.UserManager<Player> userManager)
        {
            if (!userManager.Users.Any())
            {
                var player1 = new Player()
                {
                    Name = "aaa",
                    Surname = "aaa",
                    UserName = "a1",
                    Email = "aaa@gmail.com",
                    
                };
                var player2 = new Player()
                {
                    Name = "bbb",
                    Surname = "bbb",
                    UserName = "b1",
                    Email = "bbb@gmail.com"
                };
                var player3 = new Player()
                {
                    Name = "ccc",
                    Surname = "ccc",
                    UserName = "c1",
                    Email = "ccc@gmail.com"
                };
                var user = await userManager.CreateAsync(player1, "Admin@1");
                var user1 = await userManager.CreateAsync(player2, "Admin@2");
                var user2 = await userManager.CreateAsync(player3, "Player@1");
            }
        }

        public static async Task SeedRoles(TournamentContext context)
        {
            if (!context.Roles.Any())
            {
                var admin = new Role()
                {
                    Name = "admin",
                    NormalizedName = "ADMIN"
                };
                var user = new Role()
                {
                    Name = "user",
                    NormalizedName = "USER"
                };
                context.Roles.Add(admin);
                context.Roles.Add(user);
                await context.SaveChangesAsync();
            }
        }
    }
}
