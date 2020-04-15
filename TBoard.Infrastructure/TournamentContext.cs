using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TBoard.Entities;

namespace TBoard.Infrastructure
{
  public partial class TournamentContext:DbContext
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


        }
    }
}
