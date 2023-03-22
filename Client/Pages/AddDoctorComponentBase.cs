using Client.Services.Foundations.AuthentificationStatService;
using Client.Services.Foundations.DoctorService;
using DTO;
using Microsoft.AspNetCore.Components;

namespace Client.Pages
{
    public class AddDoctorComponentBase : ComponentBase
    {
        public string ErrorMessage = null;
        public List<DoctorInformationDto> Informations = new List<DoctorInformationDto>();
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IDoctorService doctorService { get; set; }
        [Inject]
        public AuthentificationStatService AuthentificationStatService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var UserStat = await this.AuthentificationStatService.GetAuthenticationStateAsync();
            if (UserStat.User.Identity?.IsAuthenticated ?? false)
            {
                this.Informations = await this.doctorService.GetListInformationDoctors();
            }
            else
            {
                this.NavigationManager.NavigateTo("/Home");
            }
        }


    }
}
