using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Cache
{
    public class CacheKeyBuilder : ICacheKeyBuilder
    {
        private readonly StringBuilder _keyBuilder;
        private readonly ICacheTagManager _tagManager;

        public CacheKeyBuilder(ICacheTagManager tagManager)
        {
            _keyBuilder = new StringBuilder();
            _tagManager = tagManager;
        }

        public ICacheKeyBuilder Add<T>(T part)
        {
            _keyBuilder.Append(part.ToString());
            return this;
        }

        public ICacheKeyBuilder AddTag(params object[] list)
        {
            _keyBuilder.Append(_tagManager.GetTag(list));

            return this;
        }

        public string GetKey()
        {
            return _keyBuilder.ToString();
        }

    }
}
