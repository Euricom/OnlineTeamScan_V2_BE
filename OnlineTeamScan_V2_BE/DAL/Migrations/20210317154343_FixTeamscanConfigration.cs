using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class FixTeamscanConfigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tbl_teamscans_team_id_title",
                table: "tbl_teamscans");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_teamscans_team_id_title_number",
                table: "tbl_teamscans",
                columns: new[] { "team_id", "title", "number" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tbl_teamscans_team_id_title_number",
                table: "tbl_teamscans");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_teamscans_team_id_title",
                table: "tbl_teamscans",
                columns: new[] { "team_id", "title" },
                unique: true);
        }
    }
}
