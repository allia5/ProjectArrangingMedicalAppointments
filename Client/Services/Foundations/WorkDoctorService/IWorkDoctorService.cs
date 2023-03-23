using DTO;

namespace Client.Services.Foundations.WorkDoctorService
{
    public interface IWorkDoctorService
    {
        public Task SendInvitationWorkToDoctot(string IdUser);
        public Task<List<InvitationsDoctorDto>> invitationsDoctorService();
        public Task UpdateStatusServiceWorkDoctor(UpdateStatusWorkDoctorDto updateStatusWorkDoctorDto);
    }
}
