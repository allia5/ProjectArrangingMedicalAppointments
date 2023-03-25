using Server.Models.UserAccount;

namespace Server.Managers.UserManager
{
    public interface IUserManager
    {
        public Task<User> SelectUserByIdDoctor(string IdUser);
    }
}
