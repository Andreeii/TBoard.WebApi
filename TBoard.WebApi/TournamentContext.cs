using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBoard.Entities;

namespace TBoard.WebApi
{
    public partial class TournamentContext : DbContext
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
        public virtual DbSet<PlayerRole> PlayerRole { get; set; }
        public virtual DbSet<Tournament> Tournament { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(entity =>
            {

                entity.HasOne(d => d.Tournament)
                    .WithMany(p => p.Game)
                    .HasForeignKey(d => d.TournamentId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasIndex(e => e.Gmail)
                    .IsUnique();


                entity.HasIndex(e => e.UserName)
                    .IsUnique();

                entity.Property(e => e.Gmail)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                   .IsRequired()
                   .HasMaxLength(50);

                entity.Property(e => e.Surname)
                  .IsRequired()
                  .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RegistrationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.PlayerRoleNavigation)
                    .WithMany(p => p.Player)
                    .HasForeignKey(d => d.PlayerRole)
                    .OnDelete(DeleteBehavior.SetNull);
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

            modelBuilder.Entity<PlayerRole>(entity =>
            {
                entity.ToTable("Player_Role");

                entity.Property(e => e.Role).HasMaxLength(50);
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

            SeedData(modelBuilder);
        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            var tournament1 = new Tournament()
            {
                TournamentId = 1,
                Name = "Tournament1"
                //CreationDate = new DateTime(2020-02-21) //remember not to include date time in post json

            };
            var tournament2 = new Tournament()
            {
                TournamentId = 2,
                Name = "Tournament2",

            };
            var player1 = new Player()
            {
                PlayerId = 1,
                Name = "aaa",
                Surname = "aaa",
                UserName = "a1",
                Password = "admin",
                Gmail = "aaa@gmail.com",
                PlayerRole = 1
            };
            var player2 = new Player()
            {
                PlayerId = 2,
                Name = "bbb",
                Surname = "bbb",
                UserName = "b1",
                Password = "admin",
                Gmail = "bbb@gmail.com",
                PlayerRole = 1
            };
            var player3 = new Player()
            {
                PlayerId = 3,
                Name = "ccc",
                Surname = "ccc",
                UserName = "c1",
                Password = "user",
                Gmail = "ccc@gmail.com",
                PlayerRole = 2
            };
            var player4 = new Player()
            {
                PlayerId = 4,
                Name = "ddd",
                Surname = "ddd",
                UserName = "d1",
                Password = "user",
                Gmail = "ddd@gmail.com",
                PlayerRole = 2
            };
            var game1 = new Game
            {
                GameId = 1,
                TournamentId = 1
            };
            var game2 = new Game
            {
                GameId = 2,
                TournamentId = 1
            };
            var game3 = new Game
            {
                GameId = 3,
                TournamentId = 1
            };
            var game4 = new Game
            {
                GameId = 4,
                TournamentId = 1
            };
            var game5 = new Game
            {
                GameId = 5,
                TournamentId = 1
            };
            var game6 = new Game
            {
                GameId = 6,
                TournamentId = 1
            };
            var game7 = new Game
            {
                GameId = 7,
                TournamentId = 2
            };
            var game8 = new Game
            {
                GameId = 8,
                TournamentId = 2
            };
            var game9 = new Game
            {
                GameId = 9,
                TournamentId = 2
            };
            var game10 = new Game
            {
                GameId = 10,
                TournamentId = 2
            };
            var game11 = new Game
            {
                GameId = 11,
                TournamentId = 2
            };
            var game12 = new Game
            {
                GameId = 12,
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
            var admin = new PlayerRole()
            {
                RoleId = 1,
                Role = "admin"
            };
            var player = new PlayerRole()
            {
                RoleId = 2,
                Role = "user"
            };

            modelBuilder.Entity<Tournament>()
                .HasData(tournament1, tournament2);
            modelBuilder.Entity<Game>()
                .HasData(
                game1, game2, game3, game4, game5, game6,
                game7, game8, game9, game10, game11, game12
                );
            modelBuilder.Entity<Player>()
                .HasData(player1, player2, player3, player4);
            modelBuilder.Entity<PlayerGame>()
                .HasData(playerGame1, playerGame2, playerGame3, playerGame4, playerGame5,
                         playerGame6, playerGame7, playerGame8, playerGame9, playerGame10,
                         playerGame11, playerGame12, playerGame13, playerGame14,
                         playerGame15, playerGame16, playerGame17, playerGame18, playerGame19,
                         playerGame20, playerGame21, playerGame22, playerGame23, playerGame24);
            modelBuilder.Entity<PlayerRole>()
                .HasData(admin, player);
        }
    }
}


