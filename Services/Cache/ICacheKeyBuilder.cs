using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Cache
{
    public interface ICacheKeyBuilder
    {
        ICacheKeyBuilder Add<T>(T part);
        ICacheKeyBuilder AddTag(params object[] list);

        string GetKey();
    }
}
