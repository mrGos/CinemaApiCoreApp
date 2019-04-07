using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CoreApp.Data.EF.Extensions;
using CoreApp.Data.Entities;

namespace CoreApp.Data.EF.Configurations
{
    public class BlogTagConfiguration : DbEntityConfiguration<BlogTag>
    {
        public override void Configure(EntityTypeBuilder<BlogTag> entity)
        {
            entity.Property(c => c.TagId).HasMaxLength(50).IsRequired()
            .HasColumnType("varchar(50)");
            // etc.
        }
    }
}