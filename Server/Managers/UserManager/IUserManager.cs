using Server.Models.UserAccount;

namespace Server.Managers.UserManager
{
    public interface IUserManager
    {
        public Task<User> SelectUserByIdDoctor(Guid IdUser);
        public Task<User> SelectUserByIdCabinet(Guid IdCabinet);
    }
}
