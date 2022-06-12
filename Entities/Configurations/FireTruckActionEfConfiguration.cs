using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreKolos2.Entities.Configurations
{
    public class FireTruckActionEfConfiguration : IEntityTypeConfiguration<FireTruckAction>
    {
        public void Configure(EntityTypeBuilder<FireTruckAction> builder)
        {
            builder.HasKey(e => new { e.IdFireTruck, e.IdAction }).HasName("FireTruckAction_pk");

            builder.Property(e => e.AssignmentDate).IsRequired().HasDefaultValue(DateTime.Now);

            builder.HasOne(e => e.IdActionNavigation)
                .WithMany(e => e.FireTruckActions)
                .HasForeignKey(e => e.IdAction)
                .HasConstraintName("FileTruckAction_Action")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.IdFireTruckNavigation)
                .WithMany(e => e.FireTruckActions)
                .HasForeignKey(e => e.IdFireTruck)
                .HasConstraintName("FileTruckAction_FireTruck")
                .OnDelete(DeleteBehavior.Cascade);


            builder.ToTable("FireTruck_Action");
        }
    }
}
