namespace CreditAssignment.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required int quantity { get; set; }
        public bool IsBought { get; set; }
        public Guid ShoppingListId { get; set; }

        public ShoppingList? ShoppingList { get; set; }
    }
}
