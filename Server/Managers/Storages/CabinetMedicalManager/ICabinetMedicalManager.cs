using Server.Models.CabinetMedicals;

namespace Server.Managers.Storages.CabinetMedicalManager
{
    public interface ICabinetMedicalManager
    {
        public Task<CabinetMedical> SelectCabinetMedicalByUserId(string UserId);
    }
}
