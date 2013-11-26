using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Exceptions
{
    public class ProjectException : ApplicationException
    {
        public ProjectException () : base()
	    {

	    }

        public ProjectException(string message) : base(message)
        {

        }

        public ProjectException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
