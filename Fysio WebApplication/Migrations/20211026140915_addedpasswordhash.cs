using Microsoft.EntityFrameworkCore.Migrations;

namespace Fysio_WebApplication.Migrations
{
    public partial class addedpasswordhash : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7530fc90-82dd-407f-a20e-4b5bd5bd1925", "AQAAAAEAACcQAAAAEEPVg5cwhwcpglvaTEnek4Stm3+Nj8BFXKfXcviSNvrKK19mqQY3OYzdVDAifJAVig==", "cbf8e236-d7ba-4274-bae0-24f2b5d7c187" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e74ddd12-6340-4840-95c2-db12254843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a21c2b5b-9e8d-4f09-9a11-62816843346f", "AQAAAAEAACcQAAAAEChnmAihXsXiVKfNukQ15B5UpKXaBuOVMxD5xcgQoF3BmRItPYYQhGJuQvyQs/mp8A==", "d0a6e8c3-9c9f-4d9a-8bf6-043a7fe6d7b9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6efd4929-e827-4acb-ba38-1be5ec2beb07", null, "cd997430-c066-43ea-ab9b-098b073f6667" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e74ddd12-6340-4840-95c2-db12254843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a6b20124-b3eb-46b0-b3c0-0cc22a16b81b", null, "5fe81cbc-1033-4a54-9836-8c5710a09006" });
        }
    }
}
