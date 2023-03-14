using DTO;

namespace Server.Services.UserService
{
    public interface IUserService
    {
        public Task<MessageResultDto> RegistreAccountAsync(RegistreAccountDto registreAccountDto);


    }
}
