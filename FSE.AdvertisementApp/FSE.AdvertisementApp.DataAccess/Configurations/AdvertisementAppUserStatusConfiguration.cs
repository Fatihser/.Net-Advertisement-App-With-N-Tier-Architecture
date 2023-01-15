using FSE.AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSE.AdvertisementApp.DataAccess.Configurations
{
    public class AdvertisementAppUserStatusConfiguration : IEntityTypeConfiguration<AdvertisementAppUserStatus>
    {
        public void Configure(EntityTypeBuilder<AdvertisementAppUserStatus> builder)
        {
            builder.Property(x => x.Definition).HasMaxLength(300).IsRequired();
        }
    }
}
