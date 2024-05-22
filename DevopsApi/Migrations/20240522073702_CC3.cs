using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevopsApi.Migrations
{
    public partial class CC3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AwayGoals",
                table: "Bets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "HomeGoals",
                table: "Bets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MatchId",
                table: "Bets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Shootout",
                table: "Bets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Winner",
                table: "Bets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Planned = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Playoff = table.Column<bool>(type: "bit", nullable: false),
                    Winner = table.Column<bool>(type: "bit", nullable: false),
                    Shootout = table.Column<bool>(type: "bit", nullable: false),
                    HomeGoals = table.Column<int>(type: "int", nullable: false),
                    AwayGoals = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bets_MatchId",
                table: "Bets",
                column: "MatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_Matches_MatchId",
                table: "Bets",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bets_Matches_MatchId",
                table: "Bets");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Bets_MatchId",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "AwayGoals",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "HomeGoals",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "MatchId",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "Shootout",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "Winner",
                table: "Bets");
        }
    }
}
