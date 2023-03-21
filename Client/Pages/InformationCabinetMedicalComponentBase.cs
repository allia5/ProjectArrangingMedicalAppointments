using Client.Services.Exceptions;
using Client.Services.Foundations.AuthentificationStatService;
using Client.Services.Foundations.CabinetMedicalService;
using DTO;
using Microsoft.AspNetCore.Components;
using System.Reflection.Metadata;

namespace Client.Pages
{
    public class InformationCabinetMedicalComponentBase : ComponentBase
    {
        public string ErrorMessage = null;
        public CabinetMedicalDto CabinetMedicalInformation = new CabinetMedicalDto();
        [Inject]
        public ICabinetMedicalService CabinetMedicalService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public AuthentificationStatService AuthentificationStatService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            try
            {
                var ResultAuth = await this.AuthentificationStatService.GetAuthenticationStateAsync();
                if (ResultAuth.User.Identity?.IsAuthenticated ?? false)
                {
                    this.CabinetMedicalInformation = await this.CabinetMedicalService.GetInformationFromCabinetMedical();
                }
                else
                {
                    this.NavigationManager.NavigateTo("/Login/InformationCabinetMedical");
                }
            }
            catch (BadRequestException Ex)
            {
                ErrorMessage = "Validation Error";
            }
            catch (NotFoundException Ex)
            {
                ErrorMessage = "Data NOt Found ";
            }
            catch (UnauthorizedException Ex)
            {
                ErrorMessage = "You Are Not Authorized";
            }
            catch (NullException Ex)
            {
                ErrorMessage = "Empty Data ";
            }
            catch (ProblemException Ex)
            {
                ErrorMessage = "Error Intern ";
            }
        }
        public async Task Update()
        {

        }
    }
}
