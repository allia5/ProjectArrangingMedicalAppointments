using DTO;

using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Server.Models.Doctor.Exceptions;
using Server.Models.Exceptions;
using Server.Models.UserAccount;
using Server.Services.Foundation.MailService;

namespace Server.Services.UserService
{
    public partial class UserService : IUserService
    {
        public readonly UserManager<User> _userManager;
        public IMailService mailService { get; set; }
        public UserService(UserManager<User> _userManager, IMailService mailService)
        {
            this._userManager = _userManager;
            this.mailService = mailService;
        }
        public async Task<MessageResultDto> RegistreAccountAsync(RegistreAccountDto registreAccountDto)
        {

            await TryCatch(async () =>
                 {
                     ValidateUsenOnCreate(registreAccountDto);
                     var User = registreAccountDto.MaperToUser();
                     var identityResult = await this._userManager.CreateAsync(User, registreAccountDto.Password);
                     if (identityResult != null)
                     {
                         if (identityResult.Succeeded)
                         {
                             return await this.mailService.SendValidationMailToClient(User);
                         }
                         throw new FailedCreateUserException(nameof(User));


                     }




                 });
        }
    }
}
