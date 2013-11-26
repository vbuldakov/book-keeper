using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Exceptions
{
    public class ItemAlreadyExistException : ProjectException
    {
        public ItemAlreadyExistException(string message)
            : base(message)
        {
        }

        public ItemAlreadyExistException(Type itemType)
            : base("Item of type \"" + itemType.FullName + "\" already exist")
        {

        }
    }
}
