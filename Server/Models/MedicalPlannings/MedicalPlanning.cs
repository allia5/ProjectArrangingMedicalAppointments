using Server.Models.CabinetMedicals;
using Server.Models.Doctor;
using Server.Models.UserAccount;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models.MedicalPlannings
{
    public class MedicalPlanning
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public DateTime AppointmentDate { get; set; }
        [Required]
        public DateTime AppointmentTime { get; set; }
        [Required]
        public int AppointmentCount { get; set; }
        [Required]
        public string AppointmentAdress { get; set; }
        [ForeignKey("User")]
        public Guid IdUser { get; set; }
        public User user { get; set; }
        [ForeignKey("Doctors")]
        public Guid IdDoctor { get; set; }
        public Doctors doctor { get; set; }
        [ForeignKey("CabinetMedical")]
        public Guid IdCabinet { get; set; }
        public CabinetMedical CabinetMedical { get; set; }
    }
}
