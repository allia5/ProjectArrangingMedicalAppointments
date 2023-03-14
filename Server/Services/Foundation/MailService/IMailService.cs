using DTO;
using Microsoft.AspNetCore.Identity;
using Server.Models.UserAccount;

namespace Server.Services.Foundation.MailService
{
    public interface IMailService
    {
        public Task<IdentityResult> ValidateCompteUserService(string id, string token);
        public Task<MessageResultDto> SendValidationMailToClient(User user);


    }
}
