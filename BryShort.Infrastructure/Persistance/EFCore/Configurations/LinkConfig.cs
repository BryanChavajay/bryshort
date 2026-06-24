using BryShort.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BryShort.Infrastructure.Persistance.EFCore.Configurations;

internal class LinkConfig : IEntityTypeConfiguration<Link>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Link> builder)
    {
        builder.HasKey(prop => prop.Id);
        builder.Property(prop => prop.Id).UseIdentityColumn();

        builder.Property(prop => prop.ShortUrl).HasMaxLength(32).IsRequired();
        builder.HasIndex(prop => prop.ShortUrl);

        builder.ComplexProperty(prop => prop.UrlTo, action =>
        {
            action.Property(e => e.Value).HasColumnName("url").IsRequired();
            action.Property(e => e.ExpiresAt).HasColumnName("expires_at");
        });

        builder.HasIndex(p => p.IsDeleted);
    }
}
