﻿using DTO;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models.secretary;

namespace Server.Managers.Storages.SecretaryManager
{
    public class SecretaryManager : ISecretaryManager
    {
        public ServerDbContext ServerDbContext { get; set; }
        public SecretaryManager(ServerDbContext ServerDbContext)
        {
            this.ServerDbContext = ServerDbContext;
        }
        public async Task<Secretarys> InsertSecretary(Secretarys secretarys)
        {
            var secretary = this.ServerDbContext.Secretarys.Add(secretarys);
            await this.ServerDbContext.SaveChangesAsync();
            return secretary.Entity;
        }

        public async Task<Secretarys> SelectSecretaryByIdUserIdCabinet(string UserId, Guid CabinetId)
        {
            return await (from secreraty in this.ServerDbContext.Secretarys where secreraty.IdUser == UserId && secreraty.IdCabinetMedical == CabinetId select secreraty).FirstOrDefaultAsync();
        }

        public async Task<List<Secretarys>> SelectSecretayByIdUser(string UserId)
        {
            return await (from secreraty in this.ServerDbContext.Secretarys where secreraty.IdUser == UserId select secreraty).ToListAsync();
        }

        public async Task<Secretarys> UpdateSecretary(Secretarys secretarys)
        {
            var result = this.ServerDbContext.Secretarys.Update(secretarys);
            await this.ServerDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<List<Secretarys>> SelectSecretaryByIdCabinet(Guid CabinetId)
        {
            return await (from Secretary in this.ServerDbContext.Secretarys where Secretary.IdCabinetMedical == CabinetId select Secretary).ToListAsync();
        }





    }
}