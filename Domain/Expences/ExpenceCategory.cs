using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Expences
{
    public class ExpenceCategory
    {
        public int ExpenceCategoryId 
        { 
            get; 
            private set; 
        }

        public int UserId 
        { 
            get; 
            private set; 
        }

        public virtual User User
        {
            get;
            private set;
        }

        public string Name 
        { 
            get; 
            set; 
        }

        public virtual ICollection<Expence> Expences
        {
            get;
            private set;
        }

        //private ICollection<Expence> _expences;
        //public virtual IEnumerable<Expence> Expences 
        //{
        //    get
        //    {
        //        return _expences;
        //    }
        //}

        public ExpenceCategory(int userId) : this()
        {
            this.UserId = userId;
        }

        public ExpenceCategory()
        {
            //_expences = new List<Expence>();
            this.Expences = new List<Expence>();
        }

        //public void AddExpence(Expence exp)
        //{
        //    exp.Category = this;
        //    _expences.Add(exp);
        //}
    }
}
