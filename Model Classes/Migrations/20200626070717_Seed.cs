using Microsoft.EntityFrameworkCore.Migrations;

namespace Model_Classes.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Custom_Field",
                table: "Users",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "User_Id", "Custom_Field", "Email_Id", "First_Name", "Last_Name", "Password" },
                values: new object[] { 1, null, "rohitnegi30@yahoo.com", "Rohit", "Negi", "Rohit-Solutions" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "User_Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Custom_Field",
                table: "Users");
        }
    }
}
