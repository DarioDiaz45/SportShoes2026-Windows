using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportShoes2026.Entities;

namespace SportShoes2026.Data.Configurations
{
    public class SportEntityTypeyConfiguration : IEntityTypeConfiguration<Sport>
    {
        public void Configure(EntityTypeBuilder<Sport> builder)
        {
            builder.Property(b => b.SportName).IsRequired().HasMaxLength(50);

            builder.HasIndex(s => s.SportName).IsUnique();

            builder.Property(b => b.RowVersion).IsRowVersion();
        }
    }
}
