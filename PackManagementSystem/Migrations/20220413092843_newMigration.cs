using Microsoft.EntityFrameworkCore.Migrations;

namespace PackManagementSystem.Migrations
{
    public partial class newMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Email", "Firstname", "Lastname", "Password", "PhoneNumber" },
                values: new object[] { 1, "oladejimujeeb@yahoo.com", "Mujib", "Oladeji", "mujib", "08136794915" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
