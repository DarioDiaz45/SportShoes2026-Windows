namespace SportShoes2026.Entities
{
    public class Brand
    {
        public int BrandId { get; set; }

        public string BrandName { get; set; } = null!;

        public bool Active { get; set; } = true;

        public byte[] RowVersion { get; set; } = null!;

        public ICollection<SportShoe> SportShoes { get; set; } = new List<SportShoe>();
    }
}
