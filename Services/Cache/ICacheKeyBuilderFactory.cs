using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Cache
{
    public interface ICacheKeyBuilderFactory
    {
        ICacheKeyBuilder CreateKey();
    }
}
