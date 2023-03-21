using DTO;
using Server.Models.CabinetMedicals;

namespace Server.Services.Foundation.CabinetMedicalService
{
    public static class CabinetMedicalMapperService
    {
        public static CabinetMedicalDto MapperToCabinetMedicalDto(CabinetMedical cabinetMedical)
        {
            return new CabinetMedicalDto
            {
                Adress = cabinetMedical.Adress,
                Image = cabinetMedical.image,
                JobTime = cabinetMedical.JobTime,
                mapAdress = cabinetMedical.MapAdress,
                name = cabinetMedical.NameCabinet,
                phoneNumber = cabinetMedical.numberPhone,
                Services = cabinetMedical.Services,
                Status = (StatusCabinet)cabinetMedical.statusService



            };
        }
    }
}
