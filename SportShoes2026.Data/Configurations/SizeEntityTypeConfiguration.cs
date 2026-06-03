using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportShoes2026.Entities;

namespace SportShoes2026.Data.Configurations
{
    public class SizeEntityTypeConfiguration : IEntityTypeConfiguration<SiZe>
    {
        public void Configure(EntityTypeBuilder<SiZe> builder)
        {
            builder.HasKey(s => s.SizeId);

            builder.Property(s => s.SizeNumber).HasColumnType("decimal(3,1)");

            builder.HasIndex(s => s.SizeNumber).IsUnique();

            builder.Property(b => b.RowVersion).IsRowVersion();
        }
    }
}
