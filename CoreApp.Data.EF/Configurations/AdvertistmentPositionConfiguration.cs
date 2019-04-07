using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using CoreApp.Data.EF.Extensions;
using CoreApp.Data.Entities;

namespace CoreApp.Data.EF.Configurations
{
    public class AdvertistmentPositionConfiguration : DbEntityConfiguration<AdvertisementPosition>
    {
        public override void Configure(EntityTypeBuilder<AdvertisementPosition> entity)
        {
            entity.Property(c => c.Id).HasMaxLength(20).IsRequired();
            // etc.
        }
    }
}
