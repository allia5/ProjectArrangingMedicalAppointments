using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models.UserAccount;

namespace Server.Managers.Storages.DoctorManager
{
    public class DoctorManager : IDoctorManager
    {
        public ServerDbContext ServerDbContext { get; set; }
        public DoctorManager(ServerDbContext ServerDbContext)
        {
            this.ServerDbContext = ServerDbContext;
        }
        public async Task<List<User>> SelectDoctor()
        {
            return await (from DoctorItem in this.ServerDbContext.Doctors join userItem in this.ServerDbContext.users on DoctorItem.UserId equals userItem.Id select userItem).ToListAsync();
        }
    }
}
