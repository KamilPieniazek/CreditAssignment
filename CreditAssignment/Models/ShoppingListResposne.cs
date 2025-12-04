namespace CreditAssignment.Models
{
    public class ShoppingListResposne
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public DateTime CreationTimeStamp { get; set; }
        public List<ProductResponse> Products { get; set; } = new();
    }
}
