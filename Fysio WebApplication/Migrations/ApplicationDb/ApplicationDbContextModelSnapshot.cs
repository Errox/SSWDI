﻿// <auto-generated />
using System;
using Fysio_WebApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Fysio_WebApplication.Migrations.ApplicationDb
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Fysio_WebApplication.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmployeeId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Fysio_WebApplication.Models.MedicalFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfDischarge")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<int>("DiagnosisCode")
                        .HasColumnType("int");

                    b.Property<string>("IntakeSupervision")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IntakeTherapistId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MedicalFiles");
                });

            modelBuilder.Entity("Fysio_WebApplication.Models.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("IdEmployee")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MedicalFileId")
                        .HasColumnType("int");

                    b.Property<bool>("OpenForPatient")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("MedicalFileId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("Fysio_WebApplication.Models.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("GenderString")
                        .HasColumnName("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdNumber")
                        .HasColumnType("int");

                    b.Property<byte[]>("ImgData")
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("IsStudent")
                        .HasColumnType("bit");

                    b.Property<int?>("MedicalFileId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SurName")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.HasKey("PatientId");

                    b.HasIndex("MedicalFileId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Fysio_WebApplication.Models.PracticeRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("PracticeRooms");
                });

            modelBuilder.Entity("Fysio_WebApplication.Models.TreatmentPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AmountOfTreatmentsPerWeek")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<int?>("MedicalFileId")
                        .HasColumnType("int");

                    b.Property<string>("Particularities")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PracticeRoomId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TreatmentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TreatmentPerformedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MedicalFileId");

                    b.HasIndex("PracticeRoomId");

                    b.ToTable("TreatmentPlans");
                });

            modelBuilder.Entity("Fysio_WebApplication.Models.Note", b =>
                {
                    b.HasOne("Fysio_WebApplication.Models.MedicalFile", null)
                        .WithMany("Notes")
                        .HasForeignKey("MedicalFileId");
                });

            modelBuilder.Entity("Fysio_WebApplication.Models.Patient", b =>
                {
                    b.HasOne("Fysio_WebApplication.Models.MedicalFile", "MedicalFile")
                        .WithMany()
                        .HasForeignKey("MedicalFileId");
                });

            modelBuilder.Entity("Fysio_WebApplication.Models.TreatmentPlan", b =>
                {
                    b.HasOne("Fysio_WebApplication.Models.MedicalFile", null)
                        .WithMany("TreatmentPlans")
                        .HasForeignKey("MedicalFileId");

                    b.HasOne("Fysio_WebApplication.Models.PracticeRoom", "PracticeRoom")
                        .WithMany()
                        .HasForeignKey("PracticeRoomId");
                });
#pragma warning restore 612, 618
        }
    }
}
