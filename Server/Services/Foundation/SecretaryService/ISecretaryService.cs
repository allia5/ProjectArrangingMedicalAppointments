using DTO;

namespace Server.Services.Foundation.SecretaryService
{
    public interface ISecretaryService
    {
        public Task<SecritaryDto> AddSecretaryService(string EmailSecretary, string EmailAdmin);
        public Task<List<SecritaryDto>> GetAllSecretary(string Email);
    }
}
