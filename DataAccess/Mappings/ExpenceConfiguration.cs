using Domain.Expences;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace DataAccess.Mappings
{
    public class ExpenceConfiguration : EntityTypeConfiguration<Expence>
    {
        public ExpenceConfiguration()
        {
            this.HasKey(e => e.ExpenceId);

            this.Property(e => e.Date)
                .IsRequired();

            this.Property(e => e.ExpenceCategoryId)
                .IsRequired();

            this.Property(e => e.Total)
                .IsRequired();
        }
    }
}
