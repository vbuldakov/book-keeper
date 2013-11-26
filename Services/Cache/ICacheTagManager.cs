using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Cache
{
    public interface ICacheTagManager
    {
        string GetTag(string tagKey);
        void TouchTag(string tagKey);
    }
}
