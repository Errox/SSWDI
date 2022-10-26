using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PracticeRooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracticeRooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SurName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EmployeeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkerNumber = table.Column<int>(type: "int", nullable: true),
                    BIGNumber = table.Column<int>(type: "int", nullable: true),
                    StudentNumber = table.Column<int>(type: "int", nullable: true),
                    IsStudent = table.Column<bool>(type: "bit", nullable: true),
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CustomerType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgData = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    IdNumber = table.Column<int>(type: "int", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    Patient_IsStudent = table.Column<bool>(type: "bit", nullable: true),
                    MedicalFileId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationUser_ApplicationUser_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationUser_ApplicationUser_PatientId",
                        column: x => x.PatientId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Availabilties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StartAvailability = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StopAvailability = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Availabilties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Availabilties_ApplicationUser_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Availabilties_ApplicationUser_PatientId",
                        column: x => x.PatientId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MedicalFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DiagnosisCode = table.Column<int>(type: "int", nullable: false),
                    IntakeTherapistIdId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IntakeSupervisionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfDischarge = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PatientEmail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalFiles_ApplicationUser_IntakeSupervisionId",
                        column: x => x.IntakeSupervisionId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicalFiles_ApplicationUser_IntakeTherapistIdId",
                        column: x => x.IntakeTherapistIdId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TimeSlotId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_ApplicationUser_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Appointments_ApplicationUser_PatientId",
                        column: x => x.PatientId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Appointments_Availabilties_TimeSlotId",
                        column: x => x.TimeSlotId,
                        principalTable: "Availabilties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OpenForPatient = table.Column<bool>(type: "bit", nullable: false),
                    MedicalFileId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_ApplicationUser_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notes_MedicalFiles_MedicalFileId",
                        column: x => x.MedicalFileId,
                        principalTable: "MedicalFiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TreatmentPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PracticeRoomId = table.Column<int>(type: "int", nullable: true),
                    Particularities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TreatmentPerformedById = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TreatmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AmountOfTreatmentsPerWeek = table.Column<int>(type: "int", nullable: false),
                    MedicalFileId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreatmentPlans_ApplicationUser_TreatmentPerformedById",
                        column: x => x.TreatmentPerformedById,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TreatmentPlans_MedicalFiles_MedicalFileId",
                        column: x => x.MedicalFileId,
                        principalTable: "MedicalFiles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TreatmentPlans_PracticeRooms_PracticeRoomId",
                        column: x => x.PracticeRoomId,
                        principalTable: "PracticeRooms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_EmployeeId",
                table: "ApplicationUser",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_MedicalFileId",
                table: "ApplicationUser",
                column: "MedicalFileId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_PatientId",
                table: "ApplicationUser",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_EmployeeId",
                table: "Appointments",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_TimeSlotId",
                table: "Appointments",
                column: "TimeSlotId");

            migrationBuilder.CreateIndex(
                name: "IX_Availabilties_EmployeeId",
                table: "Availabilties",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Availabilties_PatientId",
                table: "Availabilties",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalFiles_IntakeSupervisionId",
                table: "MedicalFiles",
                column: "IntakeSupervisionId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalFiles_IntakeTherapistIdId",
                table: "MedicalFiles",
                column: "IntakeTherapistIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_EmployeeId",
                table: "Notes",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_MedicalFileId",
                table: "Notes",
                column: "MedicalFileId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentPlans_MedicalFileId",
                table: "TreatmentPlans",
                column: "MedicalFileId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentPlans_PracticeRoomId",
                table: "TreatmentPlans",
                column: "PracticeRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentPlans_TreatmentPerformedById",
                table: "TreatmentPlans",
                column: "TreatmentPerformedById");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUser_MedicalFiles_MedicalFileId",
                table: "ApplicationUser",
                column: "MedicalFileId",
                principalTable: "MedicalFiles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUser_MedicalFiles_MedicalFileId",
                table: "ApplicationUser");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "TreatmentPlans");

            migrationBuilder.DropTable(
                name: "Availabilties");

            migrationBuilder.DropTable(
                name: "PracticeRooms");

            migrationBuilder.DropTable(
                name: "MedicalFiles");

            migrationBuilder.DropTable(
                name: "ApplicationUser");
        }
    }
}
