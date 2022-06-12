using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreKolos2.Entities.Configurations
{
    public class FireTruckEfConfiguration : IEntityTypeConfiguration<FireTruck>
    {
        public void Configure(EntityTypeBuilder<FireTruck> builder)
        {
            builder.HasKey(e => e.IdFiretruck).HasName("FireTruck_pk");
            builder.Property(e => e.IdFiretruck).UseIdentityColumn();

            builder.Property(e => e.OperationNumber).IsRequired().HasMaxLength(10);
            builder.Property(e => e.SpecialEquipment).IsRequired();

            builder.ToTable("FireTruck");
        }
    }
}
