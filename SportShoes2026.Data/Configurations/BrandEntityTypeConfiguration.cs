using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportShoes2026.Entities;

namespace SportShoes2026.Data.Configurations
{
    public class BrandEntityTypeConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasKey(b => b.BrandId);

            builder.Property(b => b.BrandName).IsRequired().HasMaxLength(50);

            builder.HasIndex(b => b.BrandName).IsUnique();

            builder.Property(b => b.RowVersion).IsRowVersion();
        }
    }
}
