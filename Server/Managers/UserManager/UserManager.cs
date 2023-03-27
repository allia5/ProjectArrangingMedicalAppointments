using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models.UserAccount;

namespace Server.Managers.UserManager
{
    public class UserManager : IUserManager
    {
        protected ServerDbContext ServerDbContext { get; set; }
        public UserManager(ServerDbContext ServerDbContext)
        {
            this.ServerDbContext = ServerDbContext;
        }
        public async Task<User> SelectUserByIdDoctor(Guid IdDoctor)
        {
            return await (from doctor in this.ServerDbContext.Doctors
                          where doctor.Id == IdDoctor
                          join user in this.ServerDbContext.users on doctor.UserId equals user.Id
                          select user).FirstAsync();
        }

        public async Task<User> SelectUserByIdCabinet(Guid IdCabinet)
        {
            return await (from cabinet in this.ServerDbContext.cabinetMedicals
                          where cabinet.Id == IdCabinet
                          join Admin in this.ServerDbContext.admins on cabinet.Id equals Admin.IdCabinet
                          join doctor in this.ServerDbContext.Doctors on Admin.IdDoctor equals doctor.Id
                          join user in this.ServerDbContext.users on doctor.UserId equals user.Id
                          select user).FirstAsync();
        }
    }
}
