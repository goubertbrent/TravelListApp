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
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(j => j.User)
                .WithMany()
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(j => j.Tasks)
                .WithOne()
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
