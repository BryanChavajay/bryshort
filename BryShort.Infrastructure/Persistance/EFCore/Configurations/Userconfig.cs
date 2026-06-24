using BryShort.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BryShort.Infrastructure.Persistance.EFCore.Configurations;

internal class Userconfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(prop => prop.Id);
        builder.Property(prop => prop.Id)
            .UseIdentityColumn();

        builder.Property(prop => prop.PublicId)
            .HasMaxLength(64);
        builder.HasIndex(prop => prop.PublicId).IsUnique();

        builder.Property(prop => prop.Username)
            .HasMaxLength(64)
            .IsRequired();
        builder.HasIndex(prop => prop.Username).IsUnique();

        builder.Property(prop => prop.Password)
            .IsRequired();
    }
}
