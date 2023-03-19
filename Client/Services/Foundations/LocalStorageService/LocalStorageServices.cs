using Blazored.LocalStorage;

namespace Client.Services.Foundations.LocalStorageService
{
    public class LocalStorageServices : ILocalStorageServices
    {
        public ILocalStorageService localStorageService { get; set; }
        public LocalStorageServices(ILocalStorageService localStorageService)
        {
            this.localStorageService = localStorageService;
        }
        public async Task ClearAsync()
        {
            await localStorageService.ClearAsync();
        }

        public async Task<T> GetItemAsync<T>(string key)
        {
            return await localStorageService.GetItemAsync<T>(key);
        }

        public async Task<string> KeyAsync(int index)
        {
            return await localStorageService.KeyAsync(index);
        }

        public async Task RemoveItemAsync(string key)
        {
            await localStorageService.RemoveItemAsync(key);
        }

        public async Task SetItemAsync<T>(string key, T value)
        {
            await localStorageService.SetItemAsync(key, value);
        }
    }
}
