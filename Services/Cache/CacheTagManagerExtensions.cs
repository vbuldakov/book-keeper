using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Cache
{
    public static class CacheTagManagerExtensions
    {
        public static string GetTag(this ICacheTagManager mgr, params object[] list)
        {
            var builder = new StringBuilder();
            foreach (var item in list)
            {
                builder.Append(item);
            }

            return mgr.GetTag(builder.ToString());
        }

        public static void TouchTag(this ICacheTagManager mgr, params object[] list)
        {
            var builder = new StringBuilder();
            foreach (var item in list)
            {
                builder.Append(item);
            }

            mgr.TouchTag(builder.ToString());
        }

    }
}
