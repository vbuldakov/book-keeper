using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Statistics
{
    public class CategorySummary
    {
        public string CategoryName
        {
            get;
            set;
        }

        public double Total
        {
            get;
            set;
        }

        public int ExpencesCount
        {
            get;
            set;
        }

        //public CategorySummary(string name, double total, int count)
        //{
        //    this.CategoryName = name;
        //    this.Total = total;
        //    this.ExpencesCount = count;
        //}

    }
}
