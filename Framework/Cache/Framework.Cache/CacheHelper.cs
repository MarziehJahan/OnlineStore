using Microsoft.Extensions.Caching.Memory;

namespace Framework.Cache
{
    public class CacheHelper<TItem>
    {
        private readonly IMemoryCache _memoryCache;
        public CacheHelper(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public TItem? OnGetCacheGetOrCreate(string key, Func<TItem> createItem)
        {
            if (!_memoryCache.TryGetValue(key, out TItem? cacheEntry))
            {
                cacheEntry = createItem();
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSize(10)//Size amount
                    //Priority on removing when reaching size limit (memory pressure)
                    .SetPriority(CacheItemPriority.High)
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(2))
                    // Remove from cache after this time, regardless of sliding expiration
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(10));

                _memoryCache.Set(key, cacheEntry, cacheEntryOptions);

            }
            return cacheEntry;
        }

    }
}
