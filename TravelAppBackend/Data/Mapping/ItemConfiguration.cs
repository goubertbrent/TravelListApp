using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAppBackend.Models;

namespace TravelAppBackend.Data.Mapping
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasOne(i => i.Category)
                .WithMany()
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(i => i.User)
                .WithMany()
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
