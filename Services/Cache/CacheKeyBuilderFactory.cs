using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Cache
{
    public class CacheKeyBuilderFactory : ICacheKeyBuilderFactory
    {
        private readonly ICacheTagManager _tagManager;

        public CacheKeyBuilderFactory(ICacheTagManager tagManager)
        {
            _tagManager = tagManager;
        }

        public ICacheKeyBuilder CreateKey()
        {
            var builder = new CacheKeyBuilder(_tagManager);
            return builder;
        }
    }
}
