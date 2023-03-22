namespace Server.Services.Foundation.WorkDoctorService
{
    public interface IWorkDoctorService
    {
        public Task PostNewInvitationWorkDoctor(string Email, string UserId);
    }
}
