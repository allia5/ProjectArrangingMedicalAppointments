using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Server.Models.Doctor;
using Server.Models.FileChronicDisease;
using Server.Models.MedicalOrder;
using Server.Models.UserAccount;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models.fileMedical
{
    [Index(nameof(firstname), nameof(Lastname))]
    public class fileMedicals
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string MedicalIdentification { get; set; }
        [Required]
        public string firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public DateOnly DateOfBirth { get; set; }
        [Required]
        public EnumSexe Sexe { get; set; }
        [ForeignKey("User")]
        public Guid IdUser { get; set; }
        public User user { get; set; }
        [ForeignKey("Doctors")]
        public Guid IdDoctor { get; set; }
        public Doctors doctor { get; set; }
        [JsonIgnore]
        public IEnumerable<MedicalOrdres> MedicalOrders { get; set; }
        [JsonIgnore]
        public IEnumerable<FileChronicDiseases> FileChronicDiseases { get; set; }

    }
}
