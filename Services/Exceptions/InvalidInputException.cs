using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Exceptions
{
    public class InvalidInputException : ProjectException
    {
        public InvalidInputException(string message) 
            : base(message)
        {

        }
    }
}
