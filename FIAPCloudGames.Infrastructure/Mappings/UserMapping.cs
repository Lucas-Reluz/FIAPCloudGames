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
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Name).IsRequired().HasMaxLength(100);
            builder.OwnsOne(u => u.Email, email =>
            {
                email.Property(e => e.EmailAddress).HasColumnName("Email").IsRequired().HasMaxLength(150);
            });
            builder.Property(u => u.Password).IsRequired().HasMaxLength(255);
            builder.Property(u => u.IsAdmin).IsRequired();
        }
    }
}
