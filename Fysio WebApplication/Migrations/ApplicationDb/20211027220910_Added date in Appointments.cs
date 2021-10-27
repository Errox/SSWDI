using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fysio_WebApplication.Migrations.ApplicationDb
{
    public partial class AddeddateinAppointments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Appointments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Appointments");
        }
    }
}
