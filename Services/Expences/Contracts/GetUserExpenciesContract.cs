﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Expences.Contracts
{
    public class GetUserExpenciesContract
    {
        public int UserId { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
