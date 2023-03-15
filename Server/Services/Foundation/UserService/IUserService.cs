﻿using DTO;
using Microsoft.AspNetCore.Identity;

namespace Server.Services.UserService
{
    public interface IUserService
    {
        public Task<MessageResultDto> RegistreAccountAsync(RegistreAccountDto registreAccountDto);
        public Task<MessageResultDto> ValidateAccountUserAsync(string Id, string Token);


    }
}
