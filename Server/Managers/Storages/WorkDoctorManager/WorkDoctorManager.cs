using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models.WorkDoctor;

namespace Server.Managers.Storages.WorkDoctorManager
{
    public class WorkDoctorManager : IWorkDoctorManager
    {
        public ServerDbContext ServerDbContext { get; set; }
        public WorkDoctorManager(ServerDbContext ServerDbContext)
        {
            this.ServerDbContext = ServerDbContext;
        }
        public async Task<List<WorkDoctors>> SelectWorksDoctorByIdCabinet(Guid IdCabinet)
        {
            return await (from Work in this.ServerDbContext.WorkDoctors where Work.IdCabinet == IdCabinet select Work).ToListAsync();
        }
    }
}
