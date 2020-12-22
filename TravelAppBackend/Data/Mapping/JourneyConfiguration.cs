using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAppBackend.Models;

namespace TravelAppBackend.Data.Mapping
{
    public class JourneyConfiguration : IEntityTypeConfiguration<Journey>
    {
        public void Configure(EntityTypeBuilder<Journey> builder)
        {
            builder.HasMany(j => j.Items)
                .WithOne()
                .IsRequired(false);

            builder.HasOne(j => j.User)
                .WithMany()
                .IsRequired();

            builder.HasMany(j => j.Tasks)
                .WithOne()
                .IsRequired(false);
        }
    }
}
