using KamaCake.Application.Interfaces.RedisCahce;
using MediatR;

namespace KamaCake.Application.Behaviors
{
    public class RedisCacheBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IRedisCacheService redisCacheService;

        public RedisCacheBehavior(IRedisCacheService redisCacheService)
        {
            this.redisCacheService = redisCacheService;
        }
        
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(request is ICacheableQuery query)
            {
                var cacheKey=query.CacheKey;
                var cacheTime = query.CacheTime;

                var cachedData = await redisCacheService.GetAsync<TResponse>(cacheKey);

                if (cachedData != null) return cachedData;

                var response = await next();
                if(response != null) 
                     await redisCacheService.SetAsync(cacheKey,response,DateTime.Now.AddMinutes(cacheTime))  ;

                return response;

            }

            return await next();
        }
    }
}
