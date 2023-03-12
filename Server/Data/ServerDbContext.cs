using Microsoft.EntityFrameworkCore;
using Server.Models.Admin;
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

namespace Server.Data
{
    public class ServerDbContext : DbContext
    {
        public ServerDbContext(DbContextOptions<ServerDbContext> option) : base(option)
        {

        }
        public DbSet<Admins> admins { get; set; }
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

    }
}
