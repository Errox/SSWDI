using Microsoft.EntityFrameworkCore.Migrations;

namespace Fysio_WebApplication.Migrations
{
    public partial class AddIdenttSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BIGNumber", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsStudent", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StudentNumber", "SurName", "TwoFactorEnabled", "UserName", "WorkerNumber" },
                values: new object[] { "b74ddd14-6340-4840-95c2-db12554843e5", 0, 1000052, "6efd4929-e827-4acb-ba38-1be5ec2beb07", "ryangroenewold@hotmail.com", false, "Ryan", false, false, null, null, null, null, "+3163173150", false, "cd997430-c066-43ea-ab9b-098b073f6667", null, "Groenewold", false, "ryangroenewold@hotmail.com", 8527441 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BIGNumber", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsStudent", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StudentNumber", "SurName", "TwoFactorEnabled", "UserName", "WorkerNumber" },
                values: new object[] { "e74ddd12-6340-4840-95c2-db12254843e5", 0, null, "a6b20124-b3eb-46b0-b3c0-0cc22a16b81b", "Student@student.nl", false, "Ida", true, false, null, null, null, null, "+3163173150", false, "5fe81cbc-1033-4a54-9836-8c5710a09006", 1000052, "Jones", false, "Student@student.nl", 8527441 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e74ddd12-6340-4840-95c2-db12254843e5");
        }
    }
}
