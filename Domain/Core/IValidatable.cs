using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Core
{
    public interface IValidatable
    {
        bool IsValid();
    }
}
