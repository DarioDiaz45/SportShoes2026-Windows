namespace SportShoes2026.Entities.Interface
{
    public interface IConcurrencyEntity
    {
        public byte[] RowVersion { get; set; }
    }
}
