﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<WorkDoctors> InsertWorkDoctor(WorkDoctors workDoctors)
        {
            try
            {
                var result = await this.ServerDbContext.WorkDoctors.AddAsync(workDoctors);
                await this.ServerDbContext.SaveChangesAsync();
                return result.Entity;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
          
        }
    }
}
