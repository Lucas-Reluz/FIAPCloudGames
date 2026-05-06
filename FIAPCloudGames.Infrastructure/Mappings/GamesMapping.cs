using FIAPCloudGames.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPCloudGames.Infrastructure.Mappings
{
    public class GamesMapping : IEntityTypeConfiguration<Games>
    {
        public void Configure(EntityTypeBuilder<Games> builder)
        {
            builder.ToTable("Games");

            builder.HasKey(u => u.Id);
            builder.Property( u => u.GameName).IsRequired().HasMaxLength(200);
            builder.Property( u => u.Description).IsRequired().HasMaxLength(1000);
            builder.Property( u => u.Genre).IsRequired().HasMaxLength(100);
            builder.Property( u => u.Price).IsRequired().HasColumnType("decimal(18,2)");
        }
    }
}
