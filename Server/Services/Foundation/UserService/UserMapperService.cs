using DTO;
using Server.Models.UserAccount;
using Server.Models.UserRoles;
using System.Runtime.CompilerServices;

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
                DateOfBirth = registreAccountDto.DateOfBirth,
                Status = UserStatus.Activated



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
        public static List<object> MapperToList(IQueryable obj)
        {
            return new List<object>((IEnumerable<object>)obj);
        }
        public static User AppendRfToken(User user, string RefreshToken, DateTime DateExpired)
        {
            user.RefreshToken = RefreshToken;
            user.DateExpireRefreshToken = DateExpired;
            return user;
        }
        public static JwtDto MapperToJwtResult(string Token, string RefreshToken)
        {
            return new JwtDto
            {
                Token = Token,
                RefreshToken = RefreshToken
            };
        }
    }
}
