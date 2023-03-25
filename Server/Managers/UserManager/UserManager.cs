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
        public async Task<User> SelectUserByIdDoctor(string IdUser)
        {
            return await (from user in this.ServerDbContext.users where user.Id == IdUser select user).FirstAsync();
        }


    }
}
