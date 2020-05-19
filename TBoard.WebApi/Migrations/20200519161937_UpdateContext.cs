using Microsoft.EntityFrameworkCore.Migrations;

namespace TBoard.WebApi.Migrations
{
    public partial class UpdateContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Tournament_TournamentId",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Player_Game_Game_GameId",
                table: "Player_Game");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tournament",
                table: "Tournament");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Game",
                table: "Game");

            migrationBuilder.RenameTable(
                name: "Tournament",
                newName: "Tournaments");

            migrationBuilder.RenameTable(
                name: "Game",
                newName: "Games");

            migrationBuilder.RenameIndex(
                name: "IX_Game_TournamentId",
                table: "Games",
                newName: "IX_Games_TournamentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tournaments",
                table: "Tournaments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Games",
                table: "Games",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Tournaments_TournamentId",
                table: "Games",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Game_Games_GameId",
                table: "Player_Game",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Tournaments_TournamentId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Player_Game_Games_GameId",
                table: "Player_Game");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tournaments",
                table: "Tournaments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Games",
                table: "Games");

            migrationBuilder.RenameTable(
                name: "Tournaments",
                newName: "Tournament");

            migrationBuilder.RenameTable(
                name: "Games",
                newName: "Game");

            migrationBuilder.RenameIndex(
                name: "IX_Games_TournamentId",
                table: "Game",
                newName: "IX_Game_TournamentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tournament",
                table: "Tournament",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Game",
                table: "Game",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Tournament_TournamentId",
                table: "Game",
                column: "TournamentId",
                principalTable: "Tournament",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Game_Game_GameId",
                table: "Player_Game",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
