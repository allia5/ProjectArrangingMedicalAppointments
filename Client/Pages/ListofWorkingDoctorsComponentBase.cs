using Client.Services.Foundations.AuthentificationStatService;
using Client.Services.Foundations.WorkDoctorService;
using DTO;
using Microsoft.AspNetCore.Components;

namespace Client.Pages
{
    public class ListofWorkingDoctorsComponentBase : ComponentBase
    {
        protected string ErrorMessage = null;
        protected bool IsLoading = true;
        [Inject]
        public AuthentificationStatService AuthentificationStatService { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }
        [Inject]
        protected IWorkDoctorService WorkDoctorService { get; set; }
        protected List<DoctorCabinetDto> doctorCabinetDtos = new List<DoctorCabinetDto>();

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var UserStat = await this.AuthentificationStatService.GetAuthenticationStateAsync();
                if (UserStat.User.Identity?.IsAuthenticated ?? false)
                {
                    var result = await this.WorkDoctorService.GetListDoctorsInformationCabinet();
                    this.doctorCabinetDtos = result.Where(s => s.StatusWork == StatusWorkDoctor.accepted).ToList();
                    this.IsLoading = false;
                }
                else
                {
                    this.navigationManager.NavigateTo("Login/ListWorkingDoctor");
                }
            }
            catch (Exception e)
            {
                this.ErrorMessage = e.Message;
            }
        }

    }
}
