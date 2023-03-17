using DTO;

using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Server.Managers.Storages.UserRoleManager;
using Server.Models.Doctor.Exceptions;
using Server.Models.Exceptions;
using Server.Models.UserAccount;
using Server.Services.Foundation.MailService;
using static Server.Services.UserService.UserMapperService;

namespace Server.Services.UserService
{
    public partial class UserService : IUserService
    {
        public readonly UserManager<User> _userManager;
        public IMailService mailService { get; set; }
        public readonly IUserRoleManager userRoleManager;
        public UserService(UserManager<User> _userManager, IMailService mailService, IUserRoleManager userRoleManager)
        {
            this._userManager = _userManager;
            this.mailService = mailService;
            this.userRoleManager = userRoleManager;
        }
        public async Task<MessageResultDto> RegistreAccountAsync(RegistreAccountDto registreAccountDto) =>
            await TryCatch(async () =>
                 {

                     await ValidateUsenOnCreate(registreAccountDto);
                     var User = registreAccountDto.MaperToUser();
                     var identityResult = await this._userManager.CreateAsync(User, registreAccountDto.Password);

                     if (identityResult != null)
                     {
                         if (identityResult.Succeeded)
                         {
                             var UserAccount = await this._userManager.FindByEmailAsync(User.Email);
                             return await this.mailService.SendValidationMailToClient(UserAccount);
                         }
                         else
                         {
                             throw new FailedCreateUserException(nameof(User));
                         }
                     }
                     else
                     {
                         throw new FailedCreateUserException(nameof(User));
                     }


                 });
        private async Task ValidateUserAccountIsNotInSystem(string Email)
        {
            var UserAccount = await this._userManager.FindByEmailAsync(Email);
            var Exception = new Exception();

            if (!CheckUserIsNull(UserAccount))
            {
                throw new AlreadyExistsException(nameof(UserAccount));
            }
        }
        private async Task<IdentityResult> ValidateCompteUserService(User user, string Token)
        {
            try
            {
                return await this._userManager.ConfirmEmailAsync(user, Token);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<MessageResultDto> ValidateAccountUserAsync(string Id, string Token)
        =>
            await TryCatch(async () =>
            {
                ValidateEntryConfirmeEmail(Id, Token);
                var User = await this._userManager.FindByIdAsync(Id);
                ValidateUserIsNull(User);
                var IdentityResult = await ValidateCompteUserService(User, Token);
                ValidateIdentityToken(IdentityResult);
                var userRole = MaperToUserRole(User.Id, Guid.Parse("b275d069-0f86-4069-952b-cba00510638b"));
                await this.userRoleManager.InsertUserRoleAsync(userRole);
                return new MessageResultDto
                {
                    EmailAdress = User.Email,
                    Message = "Your Account has been Created Succeffely please retry Login "
                };






            });

    }


}
