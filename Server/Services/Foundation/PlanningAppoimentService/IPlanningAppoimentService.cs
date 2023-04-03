using DTO;

namespace Server.Services.Foundation.PlanningAppoimentService
{
    public interface IPlanningAppoimentService
    {
        public Task<AppointmentInformationDto> PostNewPlanningAppoimentMedical(string Email, KeysReservationMedicalDto keysReservationMedicalDto);
    }
}
