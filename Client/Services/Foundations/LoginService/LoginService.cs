using DTO;
using System.Net.Http.Json;
using System.Net;
using Client.Services.Exceptions;
using Client.Services.Foundations.LocalStorageService;

namespace Client.Services.Foundations.LoginService
{
    public class LoginService : ILoginService
    {
        private HttpClient HttpClient { get; set; }
        private ILocalStorageServices localStorageService { get; set; }
        public LoginService(HttpClient httpClient, ILocalStorageServices localStorageService)
        {
            this.HttpClient = httpClient;
            this.localStorageService = localStorageService;
        }
        public async Task AuthentificationAccount(LoginAccountDto loginAccountDto)
        {
            var result = await this.HttpClient.PostAsJsonAsync<LoginAccountDto>("/api/UserAccount/LoginAccount", loginAccountDto);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                if (result.Content.Headers.ContentLength != 0)
                {
                    var key = await this.localStorageService.KeyAsync(1);
                    await this.localStorageService.SetItemAsync(key, result);
                }

            }
            else if (result.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new BadRequestException("Validation Error");
            }
            else if (result.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException("Authentification Is Invalid");
            }
            else if (result.StatusCode == HttpStatusCode.NotFound)
            {
                throw new NotFoundException("User Not Found iN System");
            }
            else
            {

            }
        }

        public async Task AuthentificationState()
        {
            var Result = await this.HttpClient.GetAsync("/api/UserAccount/AuthenticatedState");
            if (Result.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException("Account Not Authonticated in System");
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
