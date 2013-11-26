using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace DataAccess.Mappings
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            this.HasKey(e => e.UserId);

            this.Property(p => p.Name)
                .IsRequired();

            this.Property(p => p.Email)
               .IsRequired();

            this.HasMany(u => u.ExpenceCategories)
                .WithRequired(c => c.User)
                .HasForeignKey(c => c.UserId);
        }
    }

}
