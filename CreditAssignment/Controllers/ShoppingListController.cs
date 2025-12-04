using CreditAssignment.Models;
using CreditAssignment.Services;
using Microsoft.AspNetCore.Mvc;

namespace CreditAssignment.Controllers
{
    [Route("api/list")]
    [ApiController]
    public class ShoppingListController : ControllerBase
    {
        private readonly ShoppingListService _shoppingListService;
            public ShoppingListController(
                ShoppingListService shoppingListService)
            {
                this._shoppingListService = shoppingListService;
            }

        [HttpGet]
        public IActionResult GetAllLists()
        {
            var lists = _shoppingListService.GetAllShoppinhLists();

            var response = lists.Select(l => new ShoppingListResposne
            {
                Id = l.Id,
                Name = l.Name,
                CreationTimeStamp = l.CreationTimeStamp,
                Products = l.Products.Select(p => new ProductResponse
                {
                    Id = p.Id,
                    Name = p.Name,
                    Quantity = p.quantity,
                    IsBought = p.IsBought
                }).ToList()
            }).ToList();

            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetListById(Guid id)
        {
            var list = _shoppingListService.GetById(id); // już z Include

            var response = new ShoppingListResposne
            {
                Id = list.Id,
                Name = list.Name,
                CreationTimeStamp = list.CreationTimeStamp,
                Products = list.Products.Select(p => new ProductResponse
                {
                    Id = p.Id,
                    Name = p.Name,
                    Quantity = p.quantity,
                    IsBought = p.IsBought
                }).ToList()
            };

            return Ok(response);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] ShoppingListRequest request)
        {
            return Ok(_shoppingListService.CreateShoppingList(request));
        }


        [HttpPut("update/{id:guid}")]
        public IActionResult UpdateShoppingList(Guid id, [FromBody]ShoppingListRequest request)
        {
            return Ok(_shoppingListService.UpdateShoppingList(id, request));
        }

        [HttpDelete("remove/{id:guid}")]
        public void DeleteShoppingList(Guid id)
        {
            _shoppingListService.DeleteeShoppingList(id);
        }

        [HttpGet("{listId:guid}/products")]
        public IActionResult GetProductsForList(Guid listId)
        {
            var products = _shoppingListService.GetProductsForList(listId);

            var response = products.Select(p => new ProductResponse
            {
                Id = p.Id,
                Name = p.Name,
                Quantity = p.quantity,
                IsBought = p.IsBought
            });

            return Ok(response);
        }

        [HttpPost("{listId:guid}/products")]
        public IActionResult AddProductToList(Guid listId, [FromBody] ProductRequest request)
        {
            var product = _shoppingListService.AddProductToList(listId, request);

            var response = new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Quantity = product.quantity,
                IsBought = product.IsBought
            };

            return Ok(response);
        }
    }
}
