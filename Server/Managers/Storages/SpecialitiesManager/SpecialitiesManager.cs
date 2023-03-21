using Server.Data;
using Server.Models.Specialites;

namespace Server.Managers.Storages.SpecialitiesManager
{
    public class SpecialitiesManager : ISpecialitiesManager
    {
        public ServerDbContext ServerDbContext { get; set; }
        public SpecialitiesManager(ServerDbContext ServerDbContext)
        {
            this.ServerDbContext = ServerDbContext;
        }
        public async Task<List<Specialite>> SelectSpecialitiesByIdUser(string IdUser)
        {
            return await (from userItem in this.ServerDbContext.users join doctorItem in this.ServerDbContext.Doctors on userItem.Id equals doctorItem.UserId join spDoctor in this.ServerDbContext.specialtiesDoctors )
        }
    }
}
