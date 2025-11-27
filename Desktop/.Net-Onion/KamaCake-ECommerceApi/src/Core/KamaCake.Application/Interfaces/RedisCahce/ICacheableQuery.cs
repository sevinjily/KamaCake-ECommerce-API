namespace KamaCake.Application.Interfaces.RedisCahce
{
    public interface ICacheableQuery
    {
        string CacheKey { get; }
        double CacheTime { get; }
    }
}
