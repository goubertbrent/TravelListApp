using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAppBackend.Models;

namespace TravelAppBackend.Data.Mapping
{
    public class ItemLineConfiguration : IEntityTypeConfiguration<ItemLine>
    {
        public void Configure(EntityTypeBuilder<ItemLine> builder)
        {
            builder.HasOne(il => il.Item)
                .WithMany()
                .IsRequired();

        }
    }
}
