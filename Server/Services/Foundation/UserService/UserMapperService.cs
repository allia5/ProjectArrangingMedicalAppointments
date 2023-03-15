using DTO;
using Server.Models.UserAccount;
using Server.Models.UserRoles;

namespace Server.Services.UserService
{
    public static class UserMapperService
    {
        public static User MaperToUser(this RegistreAccountDto registreAccountDto)
        {
            return new User
            {
                Email = registreAccountDto.Email,
                UserName = registreAccountDto.Email,
                LastName = registreAccountDto.LastName,
                Firstname = registreAccountDto.FirstName,
                Sexe = (EnumSexe)(int)registreAccountDto.Sexe,
                NationalNumber = registreAccountDto.NationalNumber,
                PhoneNumber = registreAccountDto.PhoneNumber,
                DateOfBirth = registreAccountDto.DateOfBirth



            };
        }
        public static UserRole MaperToUserRole(string idUser, Guid IdRole)
        {
            return new UserRole
            {
                Id = Guid.NewGuid(),
                IdUser = idUser,
                RoleId = IdRole

            };
        }
    }
}
