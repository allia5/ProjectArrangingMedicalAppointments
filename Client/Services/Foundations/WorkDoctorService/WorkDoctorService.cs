using DTO;
using System.Text.Json;
using System.Text;
using System.Net;
using System.Net.Http.Json;
using Client.Services.Foundations.LocalStorageService;
using Client.Services.Exceptions;

namespace Client.Services.Foundations.WorkDoctorService
{
    public class WorkDoctorService : IWorkDoctorService
    {
        public readonly HttpClient httpClient;
        public readonly ILocalStorageServices localStorageServices;
        public WorkDoctorService(ILocalStorageServices localStorageServices, HttpClient httpClient)
        {
            this.httpClient = httpClient;
            this.localStorageServices = localStorageServices;
        }
        public async Task SendInvitationWorkToDoctot(string IdUser)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/WorkDoctor/PostInvitationWorkDoctor");
            var JsCabinetMedical = JsonSerializer.Serialize(IdUser);
            var byteObject = System.Text.Encoding.UTF8.GetBytes(JsCabinetMedical);
            request.Content = new StringContent(JsCabinetMedical, Encoding.UTF8, "application/json");
            var JwtBearer = await this.localStorageServices.GetItemAsync<JwtDto>("JwtLocalStorage");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", JwtBearer.Token);
            var result = await httpClient.SendAsync(request);

            if (result.StatusCode == HttpStatusCode.NotFound)
            {
                throw new NotFoundException("Error Data Source ");
            }
            else if (result.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new BadRequestException("Validation Error");
            }
            else if (result.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException("You Are not Authorize in this Action");
            }
            else if (result.StatusCode == HttpStatusCode.InternalServerError)
            {
                throw new ProblemException("Error Intern");
            }
        }
    }
}
