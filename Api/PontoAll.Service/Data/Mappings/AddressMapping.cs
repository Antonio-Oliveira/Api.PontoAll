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
    class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("ADDRESS");

            // Propriedades
            builder.HasKey(a => a.AddressId); // PK

            builder.Property(a => a.AddressId)
                .IsRequired()
                .HasColumnName("ADDRESS_ID");

            builder.Property(a => a.Country)
                .IsRequired()
                .HasColumnName("COUNTRY");

            builder.Property(a => a.State)
                .IsRequired()
                .HasColumnName("STATE");

            builder.Property(a => a.City)
                .IsRequired()
                .HasColumnName("CITY");

            builder.Property(a => a.Street)
                .IsRequired()
                .HasColumnName("STREET");

            builder.Property(a => a.District)
                .IsRequired()
                .HasColumnName("DISTRICT");

            builder.Property(a => a.Number)
                .IsRequired()
                .HasColumnName("NUMBER");

            builder.Property(a => a.Reference)
                .HasColumnName("REFERENCE");

            builder.Property(a => a.CEP)
                .IsRequired()
                .HasMaxLength(Constants.CEP_LENGTH)
                .IsFixedLength()
                .HasColumnName("CEP");
        }
    }
}
