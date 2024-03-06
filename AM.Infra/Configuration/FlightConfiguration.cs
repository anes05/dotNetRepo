using AM.ApplicationCore.domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infra.Configuration
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            //configuratoin de la relation may to many between Flight and Passengers
            builder.HasMany(f => f.Passengers)
                   .WithMany(p => p.Flights)
                   .UsingEntity(t => t.ToTable("VolsPassengers"));
            // this is the configuration of foreign key and one to many relation between flights and plane and delete behaviour 
            /*builder.HasOne(p => p.Plane)
                   .WithMany(f => f.Flights)
                   .HasForeignKey(fk => fk.PlaneFK)
                   .OnDelete(DeleteBehavior.Cascade);*/









        }
    }
}
