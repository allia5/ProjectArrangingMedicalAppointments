using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models.Admin;
using Server.Models.CabinetMedicals;
using Server.Models.Doctor;

namespace Server.Managers.Storages.CabinetMedicalManager
{
    public class CabinetMedicalManager : ICabinetMedicalManager
    {
        public ServerDbContext ServerDbContext { get; set; }
        public CabinetMedicalManager(ServerDbContext ServerDbContext)
        {
            this.ServerDbContext = ServerDbContext;
        }
        public async Task<CabinetMedical> SelectCabinetMedicalByUserId(string UserId)
        {
            return await (from user in ServerDbContext.users
                          join Doctor in ServerDbContext.Doctors on user.Id equals Doctor.UserId
                          join admin in ServerDbContext.admins on Doctor.Id equals admin.IdDoctor
                          join Cabinet in ServerDbContext.cabinetMedicals on admin.IdCabinet equals Cabinet.Id
                          select Cabinet).FirstAsync();
        }
    }
}
