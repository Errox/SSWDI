using Microsoft.EntityFrameworkCore.Migrations;

namespace Fysio_WebApplication.Migrations.ApplicationDb
{
    public partial class RemovalOfDoubleEntity2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "MedicalFiles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PatientId",
                table: "MedicalFiles",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
