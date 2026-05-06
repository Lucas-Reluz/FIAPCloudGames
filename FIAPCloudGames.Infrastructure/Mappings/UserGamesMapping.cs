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
    public class UserGamesMapping : IEntityTypeConfiguration<UserGames>
    {
        public void Configure(EntityTypeBuilder<UserGames> builder)
        {

            builder.ToTable("UserGames");

            builder.HasKey(x => new { x.UserId, x.GameId });

            builder.HasOne(x => x.User)
                   .WithMany(u => u.PurchasedGames)
                   .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Game)
                   .WithMany(g => g.UserGames)
                   .HasForeignKey(x => x.GameId);
        }
    }
}
