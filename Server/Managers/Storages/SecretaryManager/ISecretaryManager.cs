using DTO;
using Server.Models.secretary;

namespace Server.Managers.Storages.SecretaryManager
{
    public interface ISecretaryManager
    {
        public Task<Secretarys> SelectSecretaryByIdUserIdCabinet(string UserId, Guid CabinetId);
        public Task<Secretarys> InsertSecretary(Secretarys secretarys);
        public Task<List<Secretarys>> SelectSecretayByIdUser(string UserId);
        public Task<Secretarys> UpdateSecretary(Secretarys secretarys);
        public Task<List<Secretarys>> SelectSecretaryByIdCabinet(Guid CabinetId);
        public Task<Secretarys> SelectSecretaryByIdAndIdCabinet(Guid Id, Guid CabinetId);
    }
}
