﻿// <auto-generated />
using System;
using EFFysioData.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFFysioData.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221202131732_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Core.DomainModel.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("EmployeeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PatientId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TimeSlotId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("PatientId");

                    b.HasIndex("TimeSlotId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Core.DomainModel.Availability", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("EmployeeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("PatientId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("StartAvailability")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StopAvailability")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("PatientId");

                    b.ToTable("Availabilties");
                });

            modelBuilder.Entity("Core.DomainModel.MedicalFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfDischarge")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("DiagnosisCode")
                        .HasColumnType("int");

                    b.Property<string>("IntakeSupervisionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IntakeTherapistIdId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PatientEmail")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IntakeSupervisionId");

                    b.HasIndex("IntakeTherapistIdId");

                    b.ToTable("MedicalFiles");
                });

            modelBuilder.Entity("Core.DomainModel.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("EmployeeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("MedicalFileId")
                        .HasColumnType("int");

                    b.Property<bool>("OpenForPatient")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("MedicalFileId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("Core.DomainModel.PracticeRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("PracticeRooms");
                });

            modelBuilder.Entity("Core.DomainModel.TreatmentPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AmountOfTreatmentsPerWeek")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("MedicalFileId")
                        .HasColumnType("int");

                    b.Property<string>("Particularities")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PracticeRoomId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TreatmentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TreatmentPerformedById")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MedicalFileId");

                    b.HasIndex("PracticeRoomId");

                    b.HasIndex("TreatmentPerformedById");

                    b.ToTable("TreatmentPlans");
                });

            modelBuilder.Entity("Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SurName")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ApplicationUser");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ApplicationUser");
                });

            modelBuilder.Entity("Core.DomainModel.Employee", b =>
                {
                    b.HasBaseType("Identity.ApplicationUser");

                    b.Property<int?>("BIGNumber")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsStudent")
                        .HasColumnType("bit")
                        .HasColumnName("Employee_IsStudent");

                    b.Property<int?>("StudentNumber")
                        .HasColumnType("int");

                    b.Property<int?>("WorkerNumber")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasIndex("EmployeeId");

                    b.HasDiscriminator().HasValue("Employee");
                });

            modelBuilder.Entity("Core.DomainModel.Patient", b =>
                {
                    b.HasBaseType("Identity.ApplicationUser");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<int>("IdNumber")
                        .HasColumnType("int");

                    b.Property<byte[]>("ImgData")
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("IsStudent")
                        .HasColumnType("bit");

                    b.Property<int?>("MedicalFileId")
                        .HasColumnType("int");

                    b.Property<string>("PatientId")
                        .HasColumnType("nvarchar(450)");

                    b.HasIndex("MedicalFileId");

                    b.HasIndex("PatientId");

                    b.HasDiscriminator().HasValue("Patient");
                });

            modelBuilder.Entity("Core.DomainModel.Appointment", b =>
                {
                    b.HasOne("Core.DomainModel.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("Core.DomainModel.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId");

                    b.HasOne("Core.DomainModel.Availability", "TimeSlot")
                        .WithMany()
                        .HasForeignKey("TimeSlotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Patient");

                    b.Navigation("TimeSlot");
                });

            modelBuilder.Entity("Core.DomainModel.Availability", b =>
                {
                    b.HasOne("Core.DomainModel.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("Core.DomainModel.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId");

                    b.Navigation("Employee");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Core.DomainModel.MedicalFile", b =>
                {
                    b.HasOne("Core.DomainModel.Employee", "IntakeSupervision")
                        .WithMany()
                        .HasForeignKey("IntakeSupervisionId");

                    b.HasOne("Core.DomainModel.Employee", "IntakeTherapistId")
                        .WithMany()
                        .HasForeignKey("IntakeTherapistIdId");

                    b.Navigation("IntakeSupervision");

                    b.Navigation("IntakeTherapistId");
                });

            modelBuilder.Entity("Core.DomainModel.Note", b =>
                {
                    b.HasOne("Core.DomainModel.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("Core.DomainModel.MedicalFile", null)
                        .WithMany("Notes")
                        .HasForeignKey("MedicalFileId");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Core.DomainModel.TreatmentPlan", b =>
                {
                    b.HasOne("Core.DomainModel.MedicalFile", null)
                        .WithMany("TreatmentPlans")
                        .HasForeignKey("MedicalFileId");

                    b.HasOne("Core.DomainModel.PracticeRoom", "PracticeRoom")
                        .WithMany()
                        .HasForeignKey("PracticeRoomId");

                    b.HasOne("Core.DomainModel.Employee", "TreatmentPerformedBy")
                        .WithMany()
                        .HasForeignKey("TreatmentPerformedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PracticeRoom");

                    b.Navigation("TreatmentPerformedBy");
                });

            modelBuilder.Entity("Core.DomainModel.Employee", b =>
                {
                    b.HasOne("Identity.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("Core.DomainModel.Patient", b =>
                {
                    b.HasOne("Core.DomainModel.MedicalFile", "MedicalFile")
                        .WithMany()
                        .HasForeignKey("MedicalFileId");

                    b.HasOne("Identity.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("PatientId");

                    b.Navigation("ApplicationUser");

                    b.Navigation("MedicalFile");
                });

            modelBuilder.Entity("Core.DomainModel.MedicalFile", b =>
                {
                    b.Navigation("Notes");

                    b.Navigation("TreatmentPlans");
                });
#pragma warning restore 612, 618
        }
    }
}