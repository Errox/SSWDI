using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    SurName = table.Column<string>(nullable: true),
                    WorkerNumber = table.Column<int>(nullable: true),
                    BIGNumber = table.Column<int>(nullable: true),
                    StudentNumber = table.Column<int>(nullable: true),
                    IsStudent = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PracticeRooms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracticeRooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Availabilties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(nullable: true),
                    StartAvailability = table.Column<DateTime>(nullable: false),
                    StopAvailability = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Availabilties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Availabilties_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicalFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    DiagnosisCode = table.Column<int>(nullable: false),
                    IntakeTherapistIdID = table.Column<int>(nullable: true),
                    IntakeSupervisionID = table.Column<int>(nullable: true),
                    DateOfCreation = table.Column<DateTime>(nullable: false),
                    DateOfDischarge = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalFiles_Employees_IntakeSupervisionID",
                        column: x => x.IntakeSupervisionID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicalFiles_Employees_IntakeTherapistIdID",
                        column: x => x.IntakeTherapistIdID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    CreatedUtc = table.Column<DateTime>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: true),
                    OpenForPatient = table.Column<bool>(nullable: false),
                    MedicalFileId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notes_MedicalFiles_MedicalFileId",
                        column: x => x.MedicalFileId,
                        principalTable: "MedicalFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 250, nullable: true),
                    SurName = table.Column<string>(maxLength: 250, nullable: true),
                    ImgData = table.Column<byte[]>(nullable: true),
                    IdNumber = table.Column<int>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    IsStudent = table.Column<bool>(nullable: false),
                    MedicalFileId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Patients_MedicalFiles_MedicalFileId",
                        column: x => x.MedicalFileId,
                        principalTable: "MedicalFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TreatmentPlans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    PracticeRoomId = table.Column<int>(nullable: true),
                    Particularities = table.Column<string>(nullable: true),
                    TreatmentPerformedByID = table.Column<int>(nullable: true),
                    TreatmentDate = table.Column<DateTime>(nullable: false),
                    AmountOfTreatmentsPerWeek = table.Column<int>(nullable: false),
                    MedicalFileId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreatmentPlans_MedicalFiles_MedicalFileId",
                        column: x => x.MedicalFileId,
                        principalTable: "MedicalFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TreatmentPlans_PracticeRooms_PracticeRoomId",
                        column: x => x.PracticeRoomId,
                        principalTable: "PracticeRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TreatmentPlans_Employees_TreatmentPerformedByID",
                        column: x => x.TreatmentPerformedByID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(nullable: true),
                    EmployeeID = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_EmployeeID",
                table: "Appointments",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientID",
                table: "Appointments",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Availabilties_EmployeeID",
                table: "Availabilties",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalFiles_IntakeSupervisionID",
                table: "MedicalFiles",
                column: "IntakeSupervisionID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalFiles_IntakeTherapistIdID",
                table: "MedicalFiles",
                column: "IntakeTherapistIdID");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_EmployeeID",
                table: "Notes",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_MedicalFileId",
                table: "Notes",
                column: "MedicalFileId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_MedicalFileId",
                table: "Patients",
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
                name: "IX_TreatmentPlans_TreatmentPerformedByID",
                table: "TreatmentPlans",
                column: "TreatmentPerformedByID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Availabilties");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "TreatmentPlans");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "PracticeRooms");

            migrationBuilder.DropTable(
                name: "MedicalFiles");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
