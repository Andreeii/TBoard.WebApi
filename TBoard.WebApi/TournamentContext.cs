using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBoard.Entities;
using TBoard.Entities.Auth;
using TBoard.WebApi.Schemas;

namespace TBoard.WebApi
{
    public partial class TournamentContext : IdentityDbContext<Player, Role, int, PlayerClaim, PlayerRole, PlayerLogin, RoleClaim, PlayerToken>
    {
        public TournamentContext()
        {
        }

        public TournamentContext(DbContextOptions<TournamentContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<Player> Player { get; set; }
        public virtual DbSet<PlayerGame> PlayerGame { get; set; }
        public virtual DbSet<Tournament> Tournament { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Game>(entity =>
            {

                entity.HasOne(d => d.Tournament)
                    .WithMany(p => p.Game)
                    .HasForeignKey(d => d.TournamentId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Player>(entity =>
            {

                entity.Property(e => e.Name)
                   .IsRequired()
                   .HasMaxLength(50);

                entity.Property(e => e.Surname)
                  .IsRequired()
                  .HasMaxLength(50);

                entity.Property(e => e.RegistrationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<PlayerGame>(entity =>
            {
                entity.ToTable("Player_Game");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.PlayerGame)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.PlayerGame)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Tournament>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });


            ApplyIdentityMapConfiguration(modelBuilder);
            //SeedData(modelBuilder);
            
        }
        private void ApplyIdentityMapConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().ToTable("Players", SchemaConsts.Auth);
            modelBuilder.Entity<PlayerClaim>().ToTable("UserClaims", SchemaConsts.Auth);
            modelBuilder.Entity<PlayerLogin>().ToTable("UserLogins", SchemaConsts.Auth);
            modelBuilder.Entity<PlayerToken>().ToTable("UserRoles", SchemaConsts.Auth);
            modelBuilder.Entity<Role>().ToTable("Roles", SchemaConsts.Auth);
            modelBuilder.Entity<RoleClaim>().ToTable("RoleClaims", SchemaConsts.Auth);
            modelBuilder.Entity<PlayerRole>().ToTable("PlayerRole", SchemaConsts.Auth);
        }
        private static void SeedData(ModelBuilder modelBuilder)
        {
            var tournament1 = new Tournament()
            {
                Id = 1,
                Name = "Tournament1"
            };
            var tournament2 = new Tournament()
            {
                Id = 2,
                Name = "Tournament2",

            };
            var player1 = new Player()
            {
                Id = 1,
                Name = "aaa",
                Surname = "aaa",
                UserName = "a1",
                PasswordHash = "admin",
                Email = "aaa@gmail.com"
            };
            var player2 = new Player()
            {
                Id = 2,
                Name = "bbb",
                Surname = "bbb",
                UserName = "b1",
                PasswordHash = "admin",
                Email = "bbb@gmail.com"
            };
            var player3 = new Player()
            {
                Id = 3,
                Name = "ccc",
                Surname = "ccc",
                UserName = "c1",
                PasswordHash = "user",
                Email = "ccc@gmail.com"
            };
            var player4 = new Player()
            {
                Id = 4,
                Name = "ddd",
                Surname = "ddd",
                UserName = "d1",
                PasswordHash = "user",
                Email = "ddd@gmail.com"
            };
            var game1 = new Game
            {
                Id = 1,
                TournamentId = 1
            };
            var game2 = new Game
            {
                Id = 2,
                TournamentId = 1
            };
            var game3 = new Game
            {
                Id = 3,
                TournamentId = 1
            };
            var game4 = new Game
            {
                Id = 4,
                TournamentId = 1
            };
            var game5 = new Game
            {
                Id = 5,
                TournamentId = 1
            };
            var game6 = new Game
            {
                Id = 6,
                TournamentId = 1
            };
            var game7 = new Game
            {
                Id = 7,
                TournamentId = 2
            };
            var game8 = new Game
            {
                Id = 8,
                TournamentId = 2
            };
            var game9 = new Game
            {
                Id = 9,
                TournamentId = 2
            };
            var game10 = new Game
            {
                Id = 10,
                TournamentId = 2
            };
            var game11 = new Game
            {
                Id = 11,
                TournamentId = 2
            };
            var game12 = new Game
            {
                Id = 12,
                TournamentId = 2
            };
            var playerGame1 = new PlayerGame()
            {
                Id = 1,
                PlayerId = 1,
                GameId = 1,
                IsWinner = true
            };
            var playerGame2 = new PlayerGame()
            {
                Id = 2,
                PlayerId = 2,
                GameId = 1,
                IsWinner = false
            };
            var playerGame3 = new PlayerGame()
            {
                Id = 3,
                PlayerId = 1,
                GameId = 2,
                IsWinner = true
            };
            var playerGame4 = new PlayerGame()
            {
                Id = 4,
                PlayerId = 3,
                GameId = 2,
                IsWinner = false
            };
            var playerGame5 = new PlayerGame()
            {
                Id = 5,
                PlayerId = 1,
                GameId = 3,
                IsWinner = true
            };

            var playerGame6 = new PlayerGame()
            {
                Id = 6,
                PlayerId = 4,
                GameId = 3,
                IsWinner = false
            };
            var playerGame7 = new PlayerGame()
            {
                Id = 7,
                PlayerId = 2,
                GameId = 4,
                IsWinner = true
            };
            var playerGame8 = new PlayerGame()
            {
                Id = 8,
                PlayerId = 3,
                GameId = 4,
                IsWinner = false
            };
            var playerGame9 = new PlayerGame()
            {
                Id = 9,
                PlayerId = 2,
                GameId = 5,
                IsWinner = true
            };
            var playerGame10 = new PlayerGame()
            {
                Id = 10,
                PlayerId = 4,
                GameId = 5,
                IsWinner = false
            };
            var playerGame11 = new PlayerGame()
            {
                Id = 11,
                PlayerId = 3,
                GameId = 6,
                IsWinner = true
            };
            var playerGame12 = new PlayerGame()
            {
                Id = 12,
                PlayerId = 4,
                GameId = 6,
                IsWinner = false
            };

            var playerGame13 = new PlayerGame()
            {
                Id = 13,
                PlayerId = 1,
                GameId = 7,
                IsWinner = true
            };
            var playerGame14 = new PlayerGame()
            {
                Id = 14,
                PlayerId = 2,
                GameId = 7,
                IsWinner = false
            };
            var playerGame15 = new PlayerGame()
            {
                Id = 15,
                PlayerId = 1,
                GameId = 8,
                IsWinner = true
            };
            var playerGame16 = new PlayerGame()
            {
                Id = 16,
                PlayerId = 3,
                GameId = 8,
                IsWinner = false
            };
            var playerGame17 = new PlayerGame()
            {
                Id = 17,
                PlayerId = 1,
                GameId = 9,
                IsWinner = true
            };

            var playerGame18 = new PlayerGame()
            {
                Id = 18,
                PlayerId = 4,
                GameId = 9,
                IsWinner = false
            };
            var playerGame19 = new PlayerGame()
            {
                Id = 19,
                PlayerId = 2,
                GameId = 10,
                IsWinner = true
            };
            var playerGame20 = new PlayerGame()
            {
                Id = 20,
                PlayerId = 3,
                GameId = 10,
                IsWinner = false
            };
            var playerGame21 = new PlayerGame()
            {
                Id = 21,
                PlayerId = 2,
                GameId = 11,
                IsWinner = true
            };
            var playerGame22 = new PlayerGame()
            {
                Id = 22,
                PlayerId = 4,
                GameId = 11,
                IsWinner = false
            };
            var playerGame23 = new PlayerGame()
            {
                Id = 23,
                PlayerId = 3,
                GameId = 12,
                IsWinner = true
            };
            var playerGame24 = new PlayerGame()
            {
                Id = 24,
                PlayerId = 4,
                GameId = 12,
                IsWinner = false
            };

            modelBuilder.Entity<Tournament>()
                .HasData(tournament1, tournament2);
            modelBuilder.Entity<Game>()
                .HasData(
                game1, game2, game3, game4, game5, game6,
                game7, game8, game9, game10, game11, game12
                );
            //modelBuilder.Entity<Player>()
            //    .HasData(player1, player2, player3, player4);
            modelBuilder.Entity<PlayerGame>()
                .HasData(playerGame1, playerGame2, playerGame3, playerGame4, playerGame5,
                         playerGame6, playerGame7, playerGame8, playerGame9, playerGame10,
                         playerGame11, playerGame12, playerGame13, playerGame14,
                         playerGame15, playerGame16, playerGame17, playerGame18, playerGame19,
                         playerGame20, playerGame21, playerGame22, playerGame23, playerGame24);

        }


        public static void SeedPlayers(Microsoft.AspNetCore.Identity.UserManager<Player> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new Player()
                {
                    Name = "abc",
                    Surname = "aaa",
                    UserName = "a1",
                    Email = "aaa@gmail.com"
                };
                var user2 = new Player()
                {
                    Name = "bbb",
                    Surname = "bbb",
                    UserName = "b1",
                    Email = "bbb@gmail.com"
                };
                var user3 = new Player()
                {
                    Name = "ccc",
                    Surname = "ccc",
                    UserName = "c1",
                    Email = "ccc@gmail.com"
                };
                var user4 = new Player()
                {
                    Name = "ddd",
                    Surname = "ddd",
                    UserName = "d1",
                    Email = "ddd@gmail.com"
                };
                userManager.CreateAsync(user, "admin1");
                userManager.CreateAsync(user2, "admin2");
                userManager.CreateAsync(user3, "user1");
                userManager.CreateAsync(user4, "user2");
            }
        }
    }
}


