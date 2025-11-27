namespace KamaCake.Application.Interfaces.RedisCahce
{
    public interface IRedisCacheService
    {
        Task<T> GetAsync<T>(string key);
        Task SetAsync<T>(string key, T value,DateTime? expirationTime=null);
    }
}
