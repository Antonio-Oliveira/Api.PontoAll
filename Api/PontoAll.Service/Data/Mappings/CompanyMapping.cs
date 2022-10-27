using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PontoAll.Models;
using PontoAll.Models.Companys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoAll.Service.Data.Mappings
{
    public class CompanyMapping : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("COMPANY");

            builder.HasKey(c => c.CompanyId); // PK

            builder.Property(c => c.CompanyId)
                .IsRequired()
                .HasColumnName("COMPANY_ID");

            builder.Property(c => c.CorporateName)
                .IsRequired()
                .HasColumnName("CORPORATE_NAME");

            builder.Property(c => c.FantasyName)
                .IsRequired()
                .HasColumnName("FANTASY_NAME");

            builder.Property(c => c.CNPJ)
                .IsRequired()
                .HasMaxLength(Constants.CNPJ_LENGTH)
                .IsFixedLength()
                .HasColumnName("CNPJ");

            builder.Property(c => c.PhoneNumber)
                .IsRequired()
                .HasMaxLength(Constants.PHONE_NUMBER_LENGTH)
                .IsFixedLength()
                .HasColumnName("PHONE_NUMBER");

            builder.Property(c => c.Email)
                .IsRequired()
                .HasColumnName("EMAIL");
        }
    }
}
