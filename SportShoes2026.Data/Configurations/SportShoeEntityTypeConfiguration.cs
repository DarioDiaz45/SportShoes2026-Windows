using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportShoes2026.Entities;

namespace SportShoes2026.Data.Configurations
{
    public class SportShoeEntityTypeConfiguration : IEntityTypeConfiguration<SportShoe>
    {
        public void Configure(EntityTypeBuilder<SportShoe> builder)
        {
            builder.HasKey(s => s.ShoeId);

            builder.Property(s => s.Model).IsRequired().HasMaxLength(150);

            builder.Property(s => s.Price).HasColumnType("decimal(18,2)");

            builder.Property(b => b.RowVersion).IsRowVersion();
        }
    }
}
