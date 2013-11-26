using Domain.Expences;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace DataAccess.Mappings
{
    public class ExpenceCategoryConfiguration : EntityTypeConfiguration<ExpenceCategory>
    {
        public ExpenceCategoryConfiguration()
        {
            this.HasKey(e => e.ExpenceCategoryId);

            this.Property(e => e.Name)
                .IsRequired();

            this.Property(e => e.UserId)
                .IsRequired();

            //this.HasMany(c => c.Expences)
            //    .WithRequired(e => e.Category)
            //    .HasForeignKey(e => e.ExpenceCategoryId);
        }
    }
}
