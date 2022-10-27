using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PontoAll.Models;
using PontoAll.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoAll.Service.Data.Mappings
{
    public class ApplicationUserMapping : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(u => u.CPF)
                .IsRequired()
                .HasMaxLength(Constants.CPF_LENGTH)
                .IsFixedLength()
                .HasColumnName("CPF");

            builder.Property(u => u.BirthDate)
                .IsRequired()
                .HasColumnName("BIRTHDATE");

            builder.HasOne(u => u.Company)
                .WithMany()
                .HasForeignKey(fk => fk.CompanyId)
                .HasConstraintName("FK_COMPANY_ID");

            builder.HasOne(u => u.Address)
                .WithMany()
                .HasForeignKey(fk => fk.AddressId)
                .HasConstraintName("FK_ADDRESS_ID");
        }
    }
}
