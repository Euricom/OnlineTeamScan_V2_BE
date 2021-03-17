using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class updateUserPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password",
                table: "tbl_users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "tbl_users",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");
        }
    }
}
