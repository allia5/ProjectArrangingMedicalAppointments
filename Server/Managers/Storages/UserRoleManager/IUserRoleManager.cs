using Server.Models.UserRoles;

namespace Server.Managers.Storages.UserRoleManager
{
    public interface IUserRoleManager
    {
        public Task<UserRole> InsertUserRoleAsync(UserRole UserRole);
    }
}
