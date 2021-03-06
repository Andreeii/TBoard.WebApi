﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TBoard.WebApi;

namespace TBoard.WebApi.Migrations
{
    [DbContext(typeof(TournamentContext))]
    [Migration("20200420185429_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0-preview.2.20159.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TBoard.Entities.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TournamentId")
                        .HasColumnType("int");

                    b.HasKey("GameId");

                    b.HasIndex("TournamentId");

                    b.ToTable("Game");

                    b.HasData(
                        new
                        {
                            GameId = 1,
                            TournamentId = 1
                        },
                        new
                        {
                            GameId = 2,
                            TournamentId = 1
                        },
                        new
                        {
                            GameId = 3,
                            TournamentId = 1
                        },
                        new
                        {
                            GameId = 4,
                            TournamentId = 1
                        },
                        new
                        {
                            GameId = 5,
                            TournamentId = 1
                        },
                        new
                        {
                            GameId = 6,
                            TournamentId = 1
                        },
                        new
                        {
                            GameId = 7,
                            TournamentId = 2
                        },
                        new
                        {
                            GameId = 8,
                            TournamentId = 2
                        },
                        new
                        {
                            GameId = 9,
                            TournamentId = 2
                        },
                        new
                        {
                            GameId = 10,
                            TournamentId = 2
                        },
                        new
                        {
                            GameId = 11,
                            TournamentId = 2
                        },
                        new
                        {
                            GameId = 12,
                            TournamentId = 2
                        });
                });

            modelBuilder.Entity("TBoard.Entities.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Gmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("PlayerRole")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegistrationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("PlayerId");

                    b.HasIndex("Gmail")
                        .IsUnique();

                    b.HasIndex("PlayerRole");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Player");

                    b.HasData(
                        new
                        {
                            PlayerId = 1,
                            Gmail = "aaa@gmail.com",
                            Name = "aaa",
                            Password = "admin",
                            PlayerRole = 1,
                            RegistrationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Surname = "aaa",
                            UserName = "a1"
                        },
                        new
                        {
                            PlayerId = 2,
                            Gmail = "bbb@gmail.com",
                            Name = "bbb",
                            Password = "admin",
                            PlayerRole = 1,
                            RegistrationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Surname = "bbb",
                            UserName = "b1"
                        },
                        new
                        {
                            PlayerId = 3,
                            Gmail = "ccc@gmail.com",
                            Name = "ccc",
                            Password = "user",
                            PlayerRole = 2,
                            RegistrationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Surname = "ccc",
                            UserName = "c1"
                        },
                        new
                        {
                            PlayerId = 4,
                            Gmail = "ddd@gmail.com",
                            Name = "ddd",
                            Password = "user",
                            PlayerRole = 2,
                            RegistrationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Surname = "ddd",
                            UserName = "d1"
                        });
                });

            modelBuilder.Entity("TBoard.Entities.PlayerGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsWinner")
                        .HasColumnType("bit");

                    b.Property<int?>("PlayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Player_Game");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GameId = 1,
                            IsWinner = true,
                            PlayerId = 1
                        },
                        new
                        {
                            Id = 2,
                            GameId = 1,
                            IsWinner = false,
                            PlayerId = 2
                        },
                        new
                        {
                            Id = 3,
                            GameId = 2,
                            IsWinner = true,
                            PlayerId = 1
                        },
                        new
                        {
                            Id = 4,
                            GameId = 2,
                            IsWinner = false,
                            PlayerId = 3
                        },
                        new
                        {
                            Id = 5,
                            GameId = 3,
                            IsWinner = true,
                            PlayerId = 1
                        },
                        new
                        {
                            Id = 6,
                            GameId = 3,
                            IsWinner = false,
                            PlayerId = 4
                        },
                        new
                        {
                            Id = 7,
                            GameId = 4,
                            IsWinner = true,
                            PlayerId = 2
                        },
                        new
                        {
                            Id = 8,
                            GameId = 4,
                            IsWinner = false,
                            PlayerId = 3
                        },
                        new
                        {
                            Id = 9,
                            GameId = 5,
                            IsWinner = true,
                            PlayerId = 2
                        },
                        new
                        {
                            Id = 10,
                            GameId = 5,
                            IsWinner = false,
                            PlayerId = 4
                        },
                        new
                        {
                            Id = 11,
                            GameId = 6,
                            IsWinner = true,
                            PlayerId = 3
                        },
                        new
                        {
                            Id = 12,
                            GameId = 6,
                            IsWinner = false,
                            PlayerId = 4
                        },
                        new
                        {
                            Id = 13,
                            GameId = 7,
                            IsWinner = true,
                            PlayerId = 1
                        },
                        new
                        {
                            Id = 14,
                            GameId = 7,
                            IsWinner = false,
                            PlayerId = 2
                        },
                        new
                        {
                            Id = 15,
                            GameId = 8,
                            IsWinner = true,
                            PlayerId = 1
                        },
                        new
                        {
                            Id = 16,
                            GameId = 8,
                            IsWinner = false,
                            PlayerId = 3
                        },
                        new
                        {
                            Id = 17,
                            GameId = 9,
                            IsWinner = true,
                            PlayerId = 1
                        },
                        new
                        {
                            Id = 18,
                            GameId = 9,
                            IsWinner = false,
                            PlayerId = 4
                        },
                        new
                        {
                            Id = 19,
                            GameId = 10,
                            IsWinner = true,
                            PlayerId = 2
                        },
                        new
                        {
                            Id = 20,
                            GameId = 10,
                            IsWinner = false,
                            PlayerId = 3
                        },
                        new
                        {
                            Id = 21,
                            GameId = 11,
                            IsWinner = true,
                            PlayerId = 2
                        },
                        new
                        {
                            Id = 22,
                            GameId = 11,
                            IsWinner = false,
                            PlayerId = 4
                        },
                        new
                        {
                            Id = 23,
                            GameId = 12,
                            IsWinner = true,
                            PlayerId = 3
                        },
                        new
                        {
                            Id = 24,
                            GameId = 12,
                            IsWinner = false,
                            PlayerId = 4
                        });
                });

            modelBuilder.Entity("TBoard.Entities.PlayerRole", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("RoleId");

                    b.ToTable("Player_Role");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            Role = "admin"
                        },
                        new
                        {
                            RoleId = 2,
                            Role = "user"
                        });
                });

            modelBuilder.Entity("TBoard.Entities.Tournament", b =>
                {
                    b.Property<int>("TournamentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("TournamentId");

                    b.ToTable("Tournament");

                    b.HasData(
                        new
                        {
                            TournamentId = 1,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Tournament1"
                        },
                        new
                        {
                            TournamentId = 2,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Tournament2"
                        });
                });

            modelBuilder.Entity("TBoard.Entities.Game", b =>
                {
                    b.HasOne("TBoard.Entities.Tournament", "Tournament")
                        .WithMany("Game")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TBoard.Entities.Player", b =>
                {
                    b.HasOne("TBoard.Entities.PlayerRole", "PlayerRoleNavigation")
                        .WithMany("Player")
                        .HasForeignKey("PlayerRole")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("TBoard.Entities.PlayerGame", b =>
                {
                    b.HasOne("TBoard.Entities.Game", "Game")
                        .WithMany("PlayerGame")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TBoard.Entities.Player", "Player")
                        .WithMany("PlayerGame")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.SetNull);
                });
#pragma warning restore 612, 618
        }
    }
}
