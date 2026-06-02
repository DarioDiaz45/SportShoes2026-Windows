using SportShoes2026.Entities.Interface;

namespace SportShoes2026.Entities
{
    public class SiZe:IConcurrencyEntity
    {
        public int SizeId { get; set; }

        public decimal SizeNumber { get; set; }

        public bool Active { get; set; }

        public byte[] RowVersion { get; set; } = null!;
    }


}

