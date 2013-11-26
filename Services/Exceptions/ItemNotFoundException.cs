using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Exceptions
{
    public class ItemNotFoundException : ProjectException
    {
        public ItemNotFoundException(string message)
            : base(message)
        {
        }

        public ItemNotFoundException(Type itemType)
            : base("Item of type \"" + itemType.FullName + "\" not found.")
        {

        }
    }
}
