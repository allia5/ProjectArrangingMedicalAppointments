using Client.Services.Exceptions;
using Client.Services.Foundations.SignInService;
using DTO;
using Microsoft.AspNetCore.Components;

namespace Client.Pages
{
    public class ValidationAccountBase : ComponentBase
    {
        protected MessageResultDto messageResult = new MessageResultDto();
        protected string ErrorMessage { get; set; }
        [Inject]
        protected ISignInService signInService { get; set; }
        [Parameter]
        public string Id { get; set; }
        [Parameter]
        public string Token { get; set; }
        protected override async void OnParametersSet()
        {
            try
            {
                if (this.Id != null && this.Token != null)
                {
                    messageResult = await this.signInService.ValidateAccountService(this.Id, this.Token);
                    if (messageResult == null)
                    {
                        ErrorMessage = "Empty Content";
                    }

                }
            }
            catch (BadRequestException Ex)
            {
                ErrorMessage = Ex.Message;

            }
            catch (UnauthorizedException Ex)
            {
                ErrorMessage = Ex.Message;
            }
            catch (Exception Ex)
            {
                ErrorMessage = Ex.Message;
            }




        }
    }
}
