using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TBoard.Infrastructure.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Player_Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Tournament",
                columns: table => new
                {
                    TournamentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournament", x => x.TournamentId);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    PlayerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Surname = table.Column<string>(maxLength: 50, nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    Gmail = table.Column<string>(maxLength: 50, nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    PlayerRole = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_Player_Player_Role_PlayerRole",
                        column: x => x.PlayerRole,
                        principalTable: "Player_Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    GameId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TournamentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.GameId);
                    table.ForeignKey(
                        name: "FK_Game_Tournament_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournament",
                        principalColumn: "TournamentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Player_Game",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(nullable: true),
                    GameId = table.Column<int>(nullable: false),
                    IsWinner = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player_Game", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Player_Game_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Player_Game_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "Player_Role",
                columns: new[] { "RoleId", "Role" },
                values: new object[,]
                {
                    { 1, "admin" },
                    { 2, "user" }
                });

            migrationBuilder.InsertData(
                table: "Tournament",
                columns: new[] { "TournamentId", "Name" },
                values: new object[,]
                {
                    { 1, "Tournament1" },
                    { 2, "Tournament2" }
                });

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "GameId", "TournamentId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 1 },
                    { 7, 2 },
                    { 8, 2 },
                    { 9, 2 },
                    { 10, 2 },
                    { 11, 2 },
                    { 12, 2 }
                });

            migrationBuilder.InsertData(
                table: "Player",
                columns: new[] { "PlayerId", "Gmail", "Name", "Password", "PlayerRole", "Surname", "UserName" },
                values: new object[,]
                {
                    { 1, "aaa@gmail.com", "aaa", "admin", 1, "aaa", "a1" },
                    { 2, "bbb@gmail.com", "bbb", "admin", 1, "bbb", "b1" },
                    { 3, "ccc@gmail.com", "ccc", "user", 2, "ccc", "c1" },
                    { 4, "ddd@gmail.com", "ddd", "user", 2, "ddd", "d1" }
                });

            migrationBuilder.InsertData(
                table: "Player_Game",
                columns: new[] { "Id", "GameId", "IsWinner", "PlayerId" },
                values: new object[,]
                {
                    { 1, 1, true, 1 },
                    { 22, 11, false, 4 },
                    { 21, 11, true, 2 },
                    { 20, 10, false, 3 },
                    { 19, 10, true, 2 },
                    { 18, 9, false, 4 },
                    { 17, 9, true, 1 },
                    { 16, 8, false, 3 },
                    { 15, 8, true, 1 },
                    { 14, 7, false, 2 },
                    { 13, 7, true, 1 },
                    { 12, 6, false, 4 },
                    { 11, 6, true, 3 },
                    { 10, 5, false, 4 },
                    { 9, 5, true, 2 },
                    { 8, 4, false, 3 },
                    { 7, 4, true, 2 },
                    { 6, 3, false, 4 },
                    { 5, 3, true, 1 },
                    { 4, 2, false, 3 },
                    { 3, 2, true, 1 },
                    { 2, 1, false, 2 },
                    { 23, 12, true, 3 },
                    { 24, 12, false, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Game_TournamentId",
                table: "Game",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_Gmail",
                table: "Player",
                column: "Gmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Player_PlayerRole",
                table: "Player",
                column: "PlayerRole");

            migrationBuilder.CreateIndex(
                name: "IX_Player_UserName",
                table: "Player",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Player_Game_GameId",
                table: "Player_Game",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_Game_PlayerId",
                table: "Player_Game",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Player_Game");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Tournament");

            migrationBuilder.DropTable(
                name: "Player_Role");
        }
    }
}
