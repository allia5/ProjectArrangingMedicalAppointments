using DTO;
using Microsoft.AspNetCore.Components;

namespace Client.Pages
{
    public class LoginComponentBase : ComponentBase
    {
        public LoginAccountDto loginAccount = new LoginAccountDto();
        public string ErrorMessage = null;
        [Parameter]
        public string ReturnUrl { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }


        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }
        protected override Task OnParametersSetAsync()
        {
            return base.OnParametersSetAsync();
        }

    }
}
