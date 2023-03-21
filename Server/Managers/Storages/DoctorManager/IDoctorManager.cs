using Server.Models.UserAccount;

namespace Server.Managers.Storages.DoctorManager
{
    public interface IDoctorManager
    {
        public Task<List<User>> SelectDoctor();
    }
}
