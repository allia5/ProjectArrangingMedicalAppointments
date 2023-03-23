using Client.Services.Foundations.AuthentificationStatService;
using Client.Services.Foundations.WorkDoctorService;
using DTO;
using Microsoft.AspNetCore.Components;

namespace Client.Pages
{
    public class InvitationWorkComponentBase : ComponentBase
    {
        protected string Index { get; set; }
        protected bool IsLoding = true;
        public List<InvitationsDoctorDto> invitationsDoctorDtos = new List<InvitationsDoctorDto>();
        [Inject]
        public AuthentificationStatService AuthentificationStatService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IWorkDoctorService WorkDoctorService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            var UserStat = await this.AuthentificationStatService.GetAuthenticationStateAsync();
            if (UserStat.User.Identity?.IsAuthenticated ?? false)
            {
                this.invitationsDoctorDtos = await this.WorkDoctorService.invitationsDoctorService();
                this.IsLoding = false;
            }
            else
            {
                this.NavigationManager.NavigateTo("Login/InvitationWork");
            }
        }

    }
}
