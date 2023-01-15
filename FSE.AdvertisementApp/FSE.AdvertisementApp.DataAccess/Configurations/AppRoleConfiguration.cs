using FSE.AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSE.AdvertisementApp.DataAccess.Configurations
{
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.Property(x => x.Definition).HasMaxLength(300).IsRequired();
            builder.HasData(new AppRole[]
            {
                new AppRole()
                {
                    Definition="Admin",
                    Id=1
                },
                new AppRole()
                {
                    Definition="Member",
                    Id=2
                }
            });
        }
    }
}
