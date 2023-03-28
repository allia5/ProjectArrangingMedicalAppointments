using Client.Services.Exceptions;
using Client.Services.Foundations.AuthentificationStatService;
using Client.Services.Foundations.SecretaryService;
using DTO;
using Microsoft.AspNetCore.Components;
using System.Threading;

namespace Client.Pages
{
    public class AddSecretaryComponentBase : ComponentBase
    {
        protected string ErrorMessage = null;
        protected string SuccessMessage = null;
        protected string Index = null;
        protected bool isLoding = true;
        protected string Email = null;
        protected bool ButtonAddIsLoding = false;
        protected List<SecritaryDto> secritaryDtos = new List<SecritaryDto>();
        protected List<SecritaryDto> secritaryDtosActive = new List<SecritaryDto>();
        protected List<SecritaryDto> secritaryDtosBlocked = new List<SecritaryDto>();
        [Inject]
        protected ISercretaryService sercretaryService { get; set; }
        [Inject]
        protected NavigationManager NavigationManager { get; set; }
        [Inject]
        public AuthentificationStatService AuthentificationStatService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var UserStat = await this.AuthentificationStatService.GetAuthenticationStateAsync();
            if (UserStat.User.Identity?.IsAuthenticated ?? false)
            {
                this.secritaryDtos = await this.sercretaryService.GetAllSecretary();
                this.secritaryDtosBlocked = this.secritaryDtos.Where(e => e.StatusSecritary == StatusSecritary.Block).ToList();
                this.secritaryDtosActive = this.secritaryDtos.Where(e => e.StatusSecritary == StatusSecritary.Active).ToList();
                this.isLoding = false;
            }
            else
            {
                this.NavigationManager.NavigateTo("Login/AddSecretary");
            }
        }

        public async Task AddSecretary()
        {
            try
            {
                this.ButtonAddIsLoding = true;
                var result = await this.sercretaryService.AddSecretary(this.Email);
                this.secritaryDtosActive.Add(result);
                this.ButtonAddIsLoding = false;
                this.SuccessMessage = "Add Operation seccess ";
                Thread.Sleep(1000);
                this.SuccessMessage = null;


            }
            catch (BadRequestException Ex)
            {
                this.ErrorMessage = Ex.Message;
                Thread.Sleep(1000);
                this.ErrorMessage = null;
            }
            catch (NotFoundException Ex)
            {
                this.ErrorMessage = Ex.Message;
                Thread.Sleep(1000);
                this.ErrorMessage = null;
            }
            catch (ConflictException Ex)
            {
                this.ErrorMessage = Ex.Message;
                Thread.Sleep(1000);
                this.ErrorMessage = null;
            }
            catch (Exception e)
            {
                this.ErrorMessage = "Error Intern";
                Thread.Sleep(1000);
                this.ErrorMessage = null;
            }
        }
    }
}
