using Client.Services.Exceptions;
using Client.Services.Foundations.LocalStorageService;
using DTO;
using System.Net;
using System.Net.Http.Json;

namespace Client.Services.Foundations.CabinetMedicalService
{
    public class CabinetMedicalService : ICabinetMedicalService
    {
        public HttpClient HttpClient { get; set; }
        public ILocalStorageServices localStorageServices { get; set; }
        public CabinetMedicalService(HttpClient HttpClient, ILocalStorageServices localStorageServices)
        {
            this.HttpClient = HttpClient;
            this.localStorageServices = localStorageServices;
        }
        public async Task<CabinetMedicalDto> GetInformationFromCabinetMedical()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/CabinetMedical/GetCabinetMedicalInformation");
            var JwtBearer = await this.localStorageServices.GetItemAsync<JwtDto>("JwtLocalStorage");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", JwtBearer.Token);
            var result = await HttpClient.SendAsync(request);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                if (result.Content.Headers.ContentLength != 0)
                {
                    return await result.Content.ReadFromJsonAsync<CabinetMedicalDto>();
                }
                else
                {
                    throw new NullException("Empty Data");
                }

            }
            else if (result.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new BadRequestException("Validation Error");
            }
            else if (result.StatusCode == HttpStatusCode.NotFound)
            {
                throw new NotFoundException("Data Not Found");
            }
            else if (result.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException("User Not Authorized in This Action");
            }
            else
            {
                throw new ProblemException("Erro Intern");
            }

        }
    }
}
