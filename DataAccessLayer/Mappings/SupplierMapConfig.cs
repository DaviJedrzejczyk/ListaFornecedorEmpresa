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
    internal class SupplierMapConfig : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("SUPPLIERS");
            builder.Property(s => s.Name).HasMaxLength(50).IsUnicode(false).IsRequired().HasColumnName("NAME");
            builder.Property(s => s.PhoneNumber).HasMaxLength(14).IsUnicode(false).IsRequired().HasColumnName("PHONE_NUMBER");
            builder.Property(s => s.CNPJ).HasMaxLength(18).IsUnicode(false).HasColumnName("CNPJ");
            builder.Property(s => s.CPF).HasMaxLength(11).IsUnicode(false).HasColumnName("CPF");
            builder.Property(s => s.InsertDate).HasColumnType("datetime2").IsUnicode(false).IsRequired().HasColumnName("INSERT_DATE");
            builder.Property(s => s.RG).HasMaxLength(10).IsUnicode(false).HasColumnName("RG");
            builder.Property(s => s.BirthDate).HasColumnType("datetime2").IsUnicode(false).HasColumnName("BIRTH_DATE");
        }
    }
}
