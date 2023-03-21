using DTO;

namespace Client.Services.Foundations.CabinetMedicalService
{
    public interface ICabinetMedicalService
    {
        public Task<CabinetMedicalDto> GetInformationFromCabinetMedical();
    }
}
