using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mappings
{
    internal class CompanyMapConfig : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("COMPANIES");
            builder.Property(c => c.FantasyName).HasMaxLength(50).IsUnicode(false).IsRequired().HasColumnName("FANTASY_NAME");
            builder.Property(c => c.UF).HasMaxLength(2).IsUnicode(false).IsRequired().HasColumnName("UF");
            builder.Property(c => c.CNPJ).HasMaxLength(11).IsUnicode(false).IsRequired().HasColumnName("CNPJ");
        }
    }
}
