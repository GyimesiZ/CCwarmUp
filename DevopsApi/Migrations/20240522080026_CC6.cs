using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevopsApi.Migrations
{
    public partial class CC6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Teams_CC_TeamId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Teams_HomeId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_HomeId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Matches_CC_TeamId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "HomeId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "CC_TeamId",
                table: "Matches");

            migrationBuilder.AlterColumn<int>(
                name: "AwayGoals",
                table: "Matches",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "AwayId",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HomeId",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AwayId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "HomeId",
                table: "Matches");

            migrationBuilder.AddColumn<int>(
                name: "HomeId",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "AwayGoals",
                table: "Matches",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CC_TeamId",
                table: "Matches",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_HomeId",
                table: "Teams",
                column: "HomeId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_CC_TeamId",
                table: "Matches",
                column: "CC_TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Teams_CC_TeamId",
                table: "Matches",
                column: "CC_TeamId",
                principalTable: "Teams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Teams_HomeId",
                table: "Teams",
                column: "HomeId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
