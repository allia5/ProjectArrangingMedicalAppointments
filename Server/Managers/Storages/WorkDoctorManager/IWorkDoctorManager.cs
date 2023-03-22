using Server.Models.WorkDoctor;

namespace Server.Managers.Storages.WorkDoctorManager
{
    public interface IWorkDoctorManager
    {
        public Task<List<WorkDoctors>> SelectWorksDoctorByIdCabinet(Guid IdCabinet);
        public Task<WorkDoctors> InsertWorkDoctor(WorkDoctors workDoctors);
    }
}
