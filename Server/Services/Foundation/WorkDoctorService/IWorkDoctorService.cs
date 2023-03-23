using DTO;

namespace Server.Services.Foundation.WorkDoctorService
{
    public interface IWorkDoctorService
    {
        public Task PostNewInvitationWorkDoctor(string Email, string UserId);
        public Task<List<InvitationsDoctorDto>> GetInvitationDoctor(string Email);
        public Task UpdateStatusServiceWorkDoctor(string Email, UpdateStatusWorkDoctorDto updateStatusWorkDoctorDto);
    }
}
