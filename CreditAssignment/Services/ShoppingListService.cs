
using CreditAssignment.Exceptions;
using CreditAssignment.Models;
using CreditAssignment.Repository;
using Microsoft.EntityFrameworkCore;

namespace CreditAssignment.Services
{
    public class ShoppingListService
    {
        private readonly ApplicationDbContext context;
        public ShoppingListService(ApplicationDbContext context) => this.context = context;

        public List<ShoppingList> GetAllShoppinhLists()
        {
            return [.. context.ShoppingLists.Include(l => l.Products)];
        }

        public ShoppingList GetById(Guid id)
        {
            var list = context.ShoppingLists
                .Include(l => l.Products)
                .FirstOrDefault(e => e.Id == id)
                ?? throw new NotFoundException($"List with id '{id}' not found.");

            return list;
        }

        public ShoppingList CreateShoppingList(ShoppingListRequest request)
        {
            var list = new ShoppingList
            {
                Name = request.Name,
                CreationTimeStamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                Products = []
            };

            context.Add(list);
            context.SaveChanges();

            return list;
        }

        public ShoppingList UpdateShoppingList(Guid id, ShoppingListRequest request)
        {
            var list = context.ShoppingLists.FirstOrDefault(e => e.Id == id)
                ?? throw new NotFoundException($"List with id '{id}' not found.");

            list.Name = request.Name;
            context.SaveChanges();

            return list;
        }

        public void DeleteeShoppingList(Guid id)
        {
            var list = context.ShoppingLists.FirstOrDefault(e => e.Id == id)
                ?? throw new NotFoundException($"List with id '{id}' not found.");

            context.ShoppingLists.Remove(list);  
            context.SaveChanges();
        }

        public List<Product> GetProductsForList(Guid listId)
        {
            var list = context.ShoppingLists
                .Include(l => l.Products)
                .FirstOrDefault(e => e.Id == listId)
                ?? throw new NotFoundException($"List with id '{listId}' not found.");

            return [.. list.Products];
        }

        public Product AddProductToList(Guid listId, ProductRequest request)
        {
            var list = context.ShoppingLists
                .FirstOrDefault(e => e.Id == listId)
                ?? throw new NotFoundException($"List with id '{listId}' not found.");

            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                quantity = request.Quantity,
                IsBought = false,
                ShoppingListId = listId  
            };

            list.Products.Add(product);
            context.Entry(product).State = EntityState.Added;
            context.SaveChanges();

            return product;
        }

        public Product UpdateProductInList(Guid listId, Guid productId, UpdateProductRequest request)
        {
            var list = context.ShoppingLists
                .Include(l => l.Products)
                .FirstOrDefault(l => l.Id == listId)
                ?? throw new NotFoundException($"Shopping list {listId} not found");

            var product = list.Products.FirstOrDefault(p => p.Id == productId)
                ?? throw new NotFoundException($"Product {productId} not found in list {listId}");

            product.Name = string.IsNullOrWhiteSpace(request.Name) ? product.Name : request.Name;
            product.quantity = request.Quantity.HasValue ? request.Quantity.Value : product.quantity;
            product.IsBought = request.IsBought.HasValue ? request.IsBought.Value : product.IsBought;

            context.SaveChanges();

            return product;
        }

        public void DeleteProduct(Guid listId, Guid productId)
        {
            var list = context.ShoppingLists
                .Include(l => l.Products)
                .FirstOrDefault(l => l.Id == listId)
                ?? throw new NotFoundException($"List with id '{listId}' not found");

            var product = list.Products
                .FirstOrDefault(p => p.Id == productId) ?? 
                throw new NotFoundException($"Product with id '{productId}' not found in this list");
            
            list.Products.Remove(product);
            context.SaveChanges();
        }
    }
}
