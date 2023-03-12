using Newtonsoft.Json;
using Server.Models.CabinetMedicals;
using Server.Models.MedicalOrder;
using Server.Models.UserAccount;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models.secretary
{
    public class Secretarys
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("CabinetMedical")]
        public Guid IdCabinetMedical { get; set; }

        public CabinetMedical cabinetMedical { get; set; }
        [ForeignKey("User")]
        public Guid IdUser { get; set; }
        public User User { get; set; }
        [JsonIgnore]
        public IEnumerable<MedicalOrdres> MedicalOrdres { get; set; }

    }
}
