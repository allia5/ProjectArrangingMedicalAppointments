using Client.Services.Exceptions;
using Client.Services.Foundations.AuthentificationStatService;
using Client.Services.Foundations.WorkDoctorService;
using DTO;
using Microsoft.AspNetCore.Components;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Processing;
using System.IO;


namespace Client.Pages
{
    public class JobsDoctorComponentBase : ComponentBase
    {
        protected bool Isloding = true;
        protected string Index = null;
        protected string ErrorMessage = null;
        public List<JobsDoctorDto> jobs = new List<JobsDoctorDto>();
        [Inject]
        public AuthentificationStatService AuthentificationStatService { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }
        [Inject]
        protected IWorkDoctorService WorkDoctorService { get; set; }


        public static Image ByteArrayToImage(byte[] byteArray)
        {
            if (byteArray == null)
            {
                return null;
            }

            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                Image image = Image.Load(ms);
                return image;
            }
        }
        protected override async Task OnInitializedAsync()
        {
            try
            {
                var UserStat = await this.AuthentificationStatService.GetAuthenticationStateAsync();
                if (UserStat.User.Identity?.IsAuthenticated ?? false)
                {
                    this.Isloding = true;
                    this.jobs = await this.WorkDoctorService.GetJobsDoctorService();
                    this.Isloding = false;
                }
                else
                {
                    this.navigationManager.NavigateTo("Login/JobsDoctor");
                }
            }
            catch (UnauthorizedException Ex)
            {
                this.ErrorMessage = "You are Not Authorized";
            }
            catch (Exception e)
            {
                this.ErrorMessage = e.Message;
            }

        }
        protected async Task UnAcceptedJob(string IdJob)
        {
            try
            {
                this.Index = IdJob;
                await this.WorkDoctorService.UpdateStatusServiceWorkDoctor(new UpdateStatusWorkDoctorDto { Status = StatusWorkDoctor.Notaccepted, WorkId = IdJob });
                this.jobs = this.jobs.Where(e => e.IdJob != IdJob).ToList();
                this.Index = null;
            }
            catch (Exception e)
            {
                this.ErrorMessage = e.Message;
            }
        }



    }
}
