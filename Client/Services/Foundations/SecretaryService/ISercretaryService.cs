using DTO;

namespace Client.Services.Foundations.SecretaryService
{
    public interface ISercretaryService
    {
        public Task<SecritaryDto> AddSecretary(string Email);
        public Task<List<SecritaryDto>> GetAllSecretary();
    }
}
