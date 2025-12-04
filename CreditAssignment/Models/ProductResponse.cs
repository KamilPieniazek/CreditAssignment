namespace CreditAssignment.Models
{
    public class ProductResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public int Quantity { get; set; }
        public bool IsBought { get; set; }
    }
}
