using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevopsApi.Migrations
{
    public partial class CC2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BetMakerId",
                table: "Bets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Score = table.Column<int>(type: "int", nullable: false),
                    Stake = table.Column<int>(type: "int", nullable: false),
                    Admin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bets_BetMakerId",
                table: "Bets",
                column: "BetMakerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_Players_BetMakerId",
                table: "Bets",
                column: "BetMakerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bets_Players_BetMakerId",
                table: "Bets");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Bets_BetMakerId",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "BetMakerId",
                table: "Bets");
        }
    }
}
