using System.Net.Http.Headers;

namespace CreditAssignment.Models
{
    public class ShoppingList
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public long CreationTimeStamp { get; set; }
        public ICollection<Product> Products { get; set; } = [];
    }
}
