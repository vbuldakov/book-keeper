using Domain.Expences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class User
    {
        public int UserId 
        { 
            get; 
            private set; 
        }

        public string Email 
        { 
            get; 
            private set; 
        }

        public string Name 
        { 
            get; 
            set; 
        }

        public virtual ICollection<ExpenceCategory> ExpenceCategories
        {
            get;
            private set;
        }

        //private ICollection<ExpenceCategory> _expenceCategories;
        //public virtual ICollection<ExpenceCategory> ExpenceCategories
        //{
        //    get
        //    {
        //        return _expenceCategories;
        //    }
        //}

        public User(string email, string name) : this()
        {
            this.Email = email;
            this.Name = name;
        }

        public User()
        {
            ExpenceCategories = new List<ExpenceCategory>();
        }

        //public void AddExpenceCategory(ExpenceCategory category)
        //{
        //    _expenceCategories.Add(category);
        //}
    }
}
