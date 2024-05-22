using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevopsApi.Migrations
{
    public partial class CC5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CC_TeamId",
                table: "Matches",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisplayName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    StillInGame = table.Column<bool>(type: "bit", nullable: false),
                    HomeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Teams_HomeId",
                        column: x => x.HomeId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_CC_TeamId",
                table: "Matches",
                column: "CC_TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_HomeId",
                table: "Teams",
                column: "HomeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Teams_CC_TeamId",
                table: "Matches",
                column: "CC_TeamId",
                principalTable: "Teams",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Teams_CC_TeamId",
                table: "Matches");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Matches_CC_TeamId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "CC_TeamId",
                table: "Matches");
        }
    }
}
