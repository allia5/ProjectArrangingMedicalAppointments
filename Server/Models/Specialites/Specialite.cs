using Newtonsoft.Json;
using Server.Models.SpecialtieDoctor;
using System.ComponentModel.DataAnnotations;

namespace Server.Models.Specialites
{
    public class Specialite
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NameSpecialite { get; set; }
        [JsonIgnore]
        public IEnumerable<SpecialtiesDoctor> specialtiesDoctors { get; set; }
    }
}
