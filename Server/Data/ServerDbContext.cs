using Microsoft.EntityFrameworkCore;
using Server.Models.Admin;
using Server.Models.Analyse;
using Server.Models.CabinetMedicals;
using Server.Models.ChronicDiseases;
using Server.Models.Doctor;
using Server.Models.FileChronicDisease;
using Server.Models.fileMedical;
using Server.Models.MedicalAnalysis;
using Server.Models.MedicalOrder;
using Server.Models.MedicalPlannings;
using Server.Models.Pharmacist;
using Server.Models.PrescriptionLine;
using Server.Models.Prescriptions;
using Server.Models.Radiologys;
using Server.Models.RadioMedical;
using Server.Models.ResultAnalyses;
using Server.Models.ResultsRadio;
using Server.Models.secretary;
using Server.Models.Specialites;
using Server.Models.SpecialtieDoctor;
using Server.Models.UserAccount;
using Server.Models.WorkDoctor;



namespace Server.Data
{
    public class ServerDbContext : DbContext
    {
        public ServerDbContext(DbContextOptions<ServerDbContext> option) : base(option)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(modelBuilder);

        }
        public DbSet<User> users { get; set; }
        public DbSet<Admins> admins { get; set; }
        public DbSet<Analyses> Analyses { get; set; }
        public DbSet<CabinetMedical> cabinetMedicals { get; set; }
        public DbSet<ChronicDisease> chronicDiseases { get; set; }
        public DbSet<Doctors> Doctors { get; set; }
        public DbSet<FileChronicDiseases> FileChronicDiseases { get; set; }
        public DbSet<fileMedicals> fileMedicals { get; set; }
        public DbSet<MedicalAnalyse> medicalAnalyses { get; set; }
        public DbSet<MedicalOrdres> MedicalOrdres { get; set; }
        public DbSet<MedicalPlanning> medicalPlannings { get; set; }
        public DbSet<Pharmacists> Pharmacists { get; set; }
        public DbSet<PrescriptionLines> PrescriptionLines { get; set; }
        public DbSet<Prescription> prescriptions { get; set; }
        public DbSet<Radiology> radiologies { get; set; }
        public DbSet<Radio> Radio { get; set; }
        public DbSet<ResultAnalyse> resultAnalyses { get; set; }
        public DbSet<ResultRadio> RadioResult { get; set; }
        public DbSet<Secretarys> Secretarys { get; set; }
        public DbSet<Specialite> specialites { get; set; }
        public DbSet<SpecialtiesDoctor> specialtiesDoctors { get; set; }

        public DbSet<WorkDoctors> WorkDoctors { get; set; }

    }
}
