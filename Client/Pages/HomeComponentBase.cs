using Client.Services.Exceptions;
using Client.Services.Foundations.UserService;
using DTO;
using Microsoft.AspNetCore.Components;

namespace Client.Pages
{
    public class HomeComponentBase : ComponentBase
    {
        protected string ErrorMessage = null;
        protected bool IsLoading = true;
        protected string Index = null;
        protected List<DoctorSearchDto> ListDoctorsAvailble = new List<DoctorSearchDto>();
        [Inject]
        protected IUserService userService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                this.ListDoctorsAvailble = await this.userService.GetListDoctorAvailble();
                this.IsLoading = false;
            }
            catch (BadRequestException e)
            {
                this.ErrorMessage = e.Message;
            }
        }


    }
}
