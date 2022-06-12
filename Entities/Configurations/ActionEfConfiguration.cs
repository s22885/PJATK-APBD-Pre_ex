using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreKolos2.Entities.Configurations
{
    public class ActionEfConfiguration : IEntityTypeConfiguration<Action>
    {
        public void Configure(EntityTypeBuilder<Action> builder)
        {
            builder.HasKey(e => e.IdAction).HasName("Action_pk");
            builder.Property(e => e.IdAction);

            builder.Property(e => e.StartTime).IsRequired();
            builder.Property(e => e.EndTime);
            builder.Property(e => e.NeedSpecialEquipment);

            builder.ToTable("Action");
        }
    }
}
