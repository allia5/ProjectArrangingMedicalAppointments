using DTO;

namespace Server.Services.Foundation.CabinetMedicalService
{
    public interface ICabinetMedicalService
    {
        public Task<CabinetMedicalDto> SelectCabinetMedicalByAdmin(string Email);

    }
}
