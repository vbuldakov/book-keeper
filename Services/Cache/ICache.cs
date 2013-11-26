
using System.Runtime.Caching;

namespace Services.Cache
{
    public interface ICache
    {
        T Get<T>(string key) where T : class;
        void Set(string key, object item);
        void Set(string key, object item, CacheItemPolicy policy);
        bool Contains(string key);
        void Remove(string key);
    }
}
