using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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

        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<PlayerGame> PlayerGames { get; set; }
        public virtual DbSet<Tournament> Tournaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Game>(entity =>
            {

                entity.HasOne(d => d.Tournament)
                    .WithMany(p => p.Games)
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

                entity.HasOne(d => d.Games)
                    .WithMany(p => p.PlayerGames)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Players)
                    .WithMany(p => p.PlayerGames)
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



    }
}



