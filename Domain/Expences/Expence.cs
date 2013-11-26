using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Expences
{
    public class Expence
    {
        public int ExpenceId 
        { 
            get; 
            private set; 
        }

        public int ExpenceCategoryId 
        { 
            get;
            internal set; 
        }

        public virtual ExpenceCategory Category 
        { 
            get;
            set; 
        }

        public DateTime Date 
        { 
            get; 
            set; 
        }

        public string Comments 
        { 
            get; 
            set; 
        }

        public double Total 
        { 
            get; 
            set; 
        }
    }
}
