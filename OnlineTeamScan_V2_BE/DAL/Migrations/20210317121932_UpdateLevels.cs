using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class UpdateLevels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "color",
                table: "tbl_levels",
                type: "char(7)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "tbl_levels",
                keyColumn: "id",
                keyValue: 1,
                column: "color",
                value: "#F95656");

            migrationBuilder.UpdateData(
                table: "tbl_levels",
                keyColumn: "id",
                keyValue: 2,
                column: "color",
                value: "#FFD54A");

            migrationBuilder.UpdateData(
                table: "tbl_levels",
                keyColumn: "id",
                keyValue: 3,
                column: "color",
                value: "#93EB5F");

            migrationBuilder.InsertData(
                table: "tbl_levels",
                columns: new[] { "id", "color", "lower_limit", "upper_limit" },
                values: new object[] { 4, "#D8D8D8", 0m, 0m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tbl_levels",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "color",
                table: "tbl_levels");
        }
    }
}
