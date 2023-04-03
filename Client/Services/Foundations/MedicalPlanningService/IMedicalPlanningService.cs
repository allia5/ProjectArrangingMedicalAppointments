using DTO;

namespace Client.Services.Foundations.MedicalPlanningService
{
    public interface IMedicalPlanningService
    {
        public Task<AppointmentInformationDto> GetAppointmentInformationDto(KeysReservationMedicalDto keysReservationMedicalDto);
    }
}
