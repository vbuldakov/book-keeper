using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Cache
{
    public class CacheValueObject<T>
    {
        public T Value
        {
            get;
            private set;
        }

        public CacheValueObject(T value)
        {
            this.Value = value;
        }
    }
}
