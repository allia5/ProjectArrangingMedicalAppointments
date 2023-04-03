using Server.Models.MedicalPlannings;

namespace Server.Managers.Storages.PlanningAppoimentManager
{
    public interface IPlanningAppoimentManager
    {
        public Task<List<MedicalPlanning>> SelectMedicalPlanningByIdDoctorIdCabinet(Guid CabinetId, Guid DoctorId, DateTime Date);

        public Task<MedicalPlanning> InsertMedicalPlanning(MedicalPlanning medicalPlanning);
        public Task<List<MedicalPlanning>> SelectMedicalPlanningByIdUser(string UserId);
    }
}
