using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PontoAll.Models.Points;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoAll.Service.Data.Mappings
{
    public class PointMapping : IEntityTypeConfiguration<Point>
    {
        public void Configure(EntityTypeBuilder<Point> builder)
        {
            builder.ToTable("POINT");

            // Propriedades
            builder.HasKey(p => p.DatePoint); // PK

            builder.Property(p => p.PointId)
                .IsRequired()
                .HasColumnName("POINT_ID");

            builder.Property(p => p.TypePoint)
                .IsRequired()
                .HasColumnName("TYPE_POINT");

            builder.Property(p => p.UserPhotograph)
                .IsRequired()
                .HasColumnName("USER_PHOTOGRAPH");

            builder.Property(p => p.DatePoint)
                .IsRequired()
                .HasColumnName("DATE_POINT");

            builder.HasOne(p => p.Address)
                .WithMany()
                .HasForeignKey(fk => fk.AddressId)
                .HasConstraintName("FK_POINT_ADDRESS_ID");
        }
    }
}
