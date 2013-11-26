using System;
using System.Runtime.Caching;

namespace Services.Cache
{
    public class DefaultMemoryCache : ICache, ICacheTagManager
    {
        private readonly MemoryCache _cache = MemoryCache.Default;
        private readonly CacheItemPolicy _defaultCacheItemPolicy;
        private readonly CacheItemPolicy _tagCacheItemPolicy;

        public DefaultMemoryCache()
        {
            _defaultCacheItemPolicy = new CacheItemPolicy() { SlidingExpiration = TimeSpan.FromDays(1) };
            _tagCacheItemPolicy = new CacheItemPolicy() { SlidingExpiration = TimeSpan.FromDays(10) };
        }


        public DefaultMemoryCache(CacheItemPolicy defaultCacheItemPolicy, CacheItemPolicy tagCacheItemPolicy)
        {
            _defaultCacheItemPolicy = defaultCacheItemPolicy;
            _tagCacheItemPolicy = tagCacheItemPolicy;
        }

        public T Get<T>(string key) where T : class
        {
            return _cache[key] as T;
        }

        public void Set(string key, object item)
        {
            _cache.Set(key, item, _defaultCacheItemPolicy);
        }

        public void Set(string key, object item, CacheItemPolicy policy)
        {
            _cache.Set(key, item, policy);
        }

        public bool Contains(string key)
        {
            return _cache.Contains(key);
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }

        public string GetTag(string tagKey)
        {
            var tag = this.Get<string>(tagKey);
            if (tag == null)
            {
                tag = tagKey + DateTime.Now.Ticks;
                this.Set(tagKey, tag, _tagCacheItemPolicy);
            }

            return tag;
        }

        public void TouchTag(string tagKey)
        {
            var tag = tagKey + DateTime.Now.Ticks;
            this.Set(tagKey, tag, _tagCacheItemPolicy);
        }

    }
}
