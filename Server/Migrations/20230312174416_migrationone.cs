using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class migrationone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cabinetMedicals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameCabinet = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MapAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numberPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Services = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cabinetMedicals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "chronicDiseases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameChronicDiseases = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chronicDiseases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "specialites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSpecialite = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specialites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sexe = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateExpireRefreshToken = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumberRRPS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsuranceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusDoctor = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "medicalAnalyses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameMedicalAnalyse = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AuthenticationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicalAnalyses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_medicalAnalyses_users_userAccountId",
                        column: x => x.userAccountId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pharmacists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PharmacistName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AuthenticationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdressPharmacist = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    idUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pharmacists_users_idUser",
                        column: x => x.idUser,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Secretarys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCabinetMedical = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cabinetMedicalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Secretarys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Secretarys_cabinetMedicals_cabinetMedicalId",
                        column: x => x.cabinetMedicalId,
                        principalTable: "cabinetMedicals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Secretarys_users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCabinet = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdDoctor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_admins_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_admins_cabinetMedicals_IdCabinet",
                        column: x => x.IdCabinet,
                        principalTable: "cabinetMedicals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "fileMedicals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicalIdentification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    firstname = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sexe = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdDoctor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    doctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fileMedicals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_fileMedicals_Doctors_doctorId",
                        column: x => x.doctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_fileMedicals_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "medicalPlannings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppointmentTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppointmentCount = table.Column<int>(type: "int", nullable: false),
                    AppointmentAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdDoctor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    doctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCabinet = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicalPlannings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_medicalPlannings_Doctors_doctorId",
                        column: x => x.doctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_medicalPlannings_cabinetMedicals_IdCabinet",
                        column: x => x.IdCabinet,
                        principalTable: "cabinetMedicals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_medicalPlannings_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "radiologies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Services = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Materiel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdDoctor = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_radiologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_radiologies_Doctors_IdDoctor",
                        column: x => x.IdDoctor,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "specialtiesDoctors",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDoctor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdSpecialites = table.Column<int>(type: "int", nullable: false),
                    Specialite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specialtiesDoctors", x => x.id);
                    table.ForeignKey(
                        name: "FK_specialtiesDoctors_Doctors_IdDoctor",
                        column: x => x.IdDoctor,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_specialtiesDoctors_specialites_Specialite",
                        column: x => x.Specialite,
                        principalTable: "specialites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkDoctors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReadyTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    statusServcie = table.Column<int>(type: "int", nullable: false),
                    statusReservation = table.Column<int>(type: "int", nullable: false),
                    StatusWork = table.Column<int>(type: "int", nullable: false),
                    NbPatientAvailble = table.Column<int>(type: "int", nullable: false),
                    IdDoctor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCabinet = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cabinetMedicalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkDoctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkDoctors_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkDoctors_cabinetMedicals_cabinetMedicalId",
                        column: x => x.cabinetMedicalId,
                        principalTable: "cabinetMedicals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FileChronicDiseases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdFile = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdChronicDisease = table.Column<int>(type: "int", nullable: false),
                    chronicDiseaseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileChronicDiseases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileChronicDiseases_chronicDiseases_chronicDiseaseId",
                        column: x => x.chronicDiseaseId,
                        principalTable: "chronicDiseases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FileChronicDiseases_fileMedicals_IdFile",
                        column: x => x.IdFile,
                        principalTable: "fileMedicals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicalOrdres",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IdDoctor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdFileMedical = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileMedicalsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdSecritary = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalOrdres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalOrdres_Doctors_IdDoctor",
                        column: x => x.IdDoctor,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicalOrdres_Secretarys_IdSecritary",
                        column: x => x.IdSecritary,
                        principalTable: "Secretarys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicalOrdres_fileMedicals_FileMedicalsId",
                        column: x => x.FileMedicalsId,
                        principalTable: "fileMedicals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Analyses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QrCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instruction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IdPharmacist = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    pharmacistsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdOrdreMedical = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicalAnalyseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analyses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Analyses_MedicalOrdres_IdOrdreMedical",
                        column: x => x.IdOrdreMedical,
                        principalTable: "MedicalOrdres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Analyses_Pharmacists_pharmacistsId",
                        column: x => x.pharmacistsId,
                        principalTable: "Pharmacists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Analyses_medicalAnalyses_MedicalAnalyseId",
                        column: x => x.MedicalAnalyseId,
                        principalTable: "medicalAnalyses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "prescriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    qrCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    instruction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdMedicalOrdre = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_prescriptions_MedicalOrdres_IdMedicalOrdre",
                        column: x => x.IdMedicalOrdre,
                        principalTable: "MedicalOrdres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Radio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QrCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instruction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DateValidation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdRadiology = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdOrdreMedical = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Radio_MedicalOrdres_IdOrdreMedical",
                        column: x => x.IdOrdreMedical,
                        principalTable: "MedicalOrdres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Radio_radiologies_IdRadiology",
                        column: x => x.IdRadiology,
                        principalTable: "radiologies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "resultAnalyses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReferenceFile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<int>(type: "int", nullable: false),
                    IdAnalyse = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    analysesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resultAnalyses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_resultAnalyses_Analyses_analysesId",
                        column: x => x.analysesId,
                        principalTable: "Analyses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PrescriptionLines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicamentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dosage = table.Column<int>(type: "int", nullable: false),
                    StatusPrescriptionLine = table.Column<int>(type: "int", nullable: false),
                    DateValidation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdPrescription = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPharmacist = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescriptionLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrescriptionLines_Pharmacists_IdPharmacist",
                        column: x => x.IdPharmacist,
                        principalTable: "Pharmacists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrescriptionLines_prescriptions_IdPrescription",
                        column: x => x.IdPrescription,
                        principalTable: "prescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RadioResult",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReferenceFile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<int>(type: "int", nullable: false),
                    IdRadio = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RadioResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RadioResult_Radio_IdRadio",
                        column: x => x.IdRadio,
                        principalTable: "Radio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_admins_DoctorId",
                table: "admins",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_admins_IdCabinet",
                table: "admins",
                column: "IdCabinet");

            migrationBuilder.CreateIndex(
                name: "IX_Analyses_IdOrdreMedical",
                table: "Analyses",
                column: "IdOrdreMedical");

            migrationBuilder.CreateIndex(
                name: "IX_Analyses_MedicalAnalyseId",
                table: "Analyses",
                column: "MedicalAnalyseId");

            migrationBuilder.CreateIndex(
                name: "IX_Analyses_pharmacistsId",
                table: "Analyses",
                column: "pharmacistsId");

            migrationBuilder.CreateIndex(
                name: "IX_cabinetMedicals_NameCabinet",
                table: "cabinetMedicals",
                column: "NameCabinet");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_UserId",
                table: "Doctors",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FileChronicDiseases_chronicDiseaseId",
                table: "FileChronicDiseases",
                column: "chronicDiseaseId");

            migrationBuilder.CreateIndex(
                name: "IX_FileChronicDiseases_IdFile",
                table: "FileChronicDiseases",
                column: "IdFile");

            migrationBuilder.CreateIndex(
                name: "IX_fileMedicals_doctorId",
                table: "fileMedicals",
                column: "doctorId");

            migrationBuilder.CreateIndex(
                name: "IX_fileMedicals_firstname_Lastname",
                table: "fileMedicals",
                columns: new[] { "firstname", "Lastname" });

            migrationBuilder.CreateIndex(
                name: "IX_fileMedicals_userId",
                table: "fileMedicals",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_medicalAnalyses_NameMedicalAnalyse",
                table: "medicalAnalyses",
                column: "NameMedicalAnalyse");

            migrationBuilder.CreateIndex(
                name: "IX_medicalAnalyses_userAccountId",
                table: "medicalAnalyses",
                column: "userAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalOrdres_FileMedicalsId",
                table: "MedicalOrdres",
                column: "FileMedicalsId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalOrdres_IdDoctor",
                table: "MedicalOrdres",
                column: "IdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalOrdres_IdSecritary",
                table: "MedicalOrdres",
                column: "IdSecritary");

            migrationBuilder.CreateIndex(
                name: "IX_medicalPlannings_doctorId",
                table: "medicalPlannings",
                column: "doctorId");

            migrationBuilder.CreateIndex(
                name: "IX_medicalPlannings_IdCabinet",
                table: "medicalPlannings",
                column: "IdCabinet");

            migrationBuilder.CreateIndex(
                name: "IX_medicalPlannings_userId",
                table: "medicalPlannings",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacists_idUser",
                table: "Pharmacists",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacists_PharmacistName",
                table: "Pharmacists",
                column: "PharmacistName");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionLines_IdPharmacist",
                table: "PrescriptionLines",
                column: "IdPharmacist");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionLines_IdPrescription",
                table: "PrescriptionLines",
                column: "IdPrescription");

            migrationBuilder.CreateIndex(
                name: "IX_prescriptions_IdMedicalOrdre",
                table: "prescriptions",
                column: "IdMedicalOrdre");

            migrationBuilder.CreateIndex(
                name: "IX_Radio_IdOrdreMedical",
                table: "Radio",
                column: "IdOrdreMedical");

            migrationBuilder.CreateIndex(
                name: "IX_Radio_IdRadiology",
                table: "Radio",
                column: "IdRadiology");

            migrationBuilder.CreateIndex(
                name: "IX_radiologies_IdDoctor",
                table: "radiologies",
                column: "IdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_RadioResult_IdRadio",
                table: "RadioResult",
                column: "IdRadio");

            migrationBuilder.CreateIndex(
                name: "IX_resultAnalyses_analysesId",
                table: "resultAnalyses",
                column: "analysesId");

            migrationBuilder.CreateIndex(
                name: "IX_Secretarys_cabinetMedicalId",
                table: "Secretarys",
                column: "cabinetMedicalId");

            migrationBuilder.CreateIndex(
                name: "IX_Secretarys_IdUser",
                table: "Secretarys",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_specialtiesDoctors_IdDoctor",
                table: "specialtiesDoctors",
                column: "IdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_specialtiesDoctors_Specialite",
                table: "specialtiesDoctors",
                column: "Specialite");

            migrationBuilder.CreateIndex(
                name: "IX_users_Email",
                table: "users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_WorkDoctors_cabinetMedicalId",
                table: "WorkDoctors",
                column: "cabinetMedicalId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkDoctors_DoctorId",
                table: "WorkDoctors",
                column: "DoctorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropTable(
                name: "FileChronicDiseases");

            migrationBuilder.DropTable(
                name: "medicalPlannings");

            migrationBuilder.DropTable(
                name: "PrescriptionLines");

            migrationBuilder.DropTable(
                name: "RadioResult");

            migrationBuilder.DropTable(
                name: "resultAnalyses");

            migrationBuilder.DropTable(
                name: "specialtiesDoctors");

            migrationBuilder.DropTable(
                name: "WorkDoctors");

            migrationBuilder.DropTable(
                name: "chronicDiseases");

            migrationBuilder.DropTable(
                name: "prescriptions");

            migrationBuilder.DropTable(
                name: "Radio");

            migrationBuilder.DropTable(
                name: "Analyses");

            migrationBuilder.DropTable(
                name: "specialites");

            migrationBuilder.DropTable(
                name: "radiologies");

            migrationBuilder.DropTable(
                name: "MedicalOrdres");

            migrationBuilder.DropTable(
                name: "Pharmacists");

            migrationBuilder.DropTable(
                name: "medicalAnalyses");

            migrationBuilder.DropTable(
                name: "Secretarys");

            migrationBuilder.DropTable(
                name: "fileMedicals");

            migrationBuilder.DropTable(
                name: "cabinetMedicals");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
