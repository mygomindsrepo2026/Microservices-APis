using FirstApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Models.Product> products = new List<Models.Product>
        {
            new Models.Product { ProductId = 1, ProductName = "OnePlus-Nord", Brand = "Oneplus", Price = 10.99m, Stock = 100, Description = "oneplus 78000", Category = 1 },
            new Models.Product { ProductId = 2, ProductName = "Iphone 16", Brand = "Apple", Price = 19.99m, Stock = 50, Description = "Apple brand", Category = 2 },
            new Models.Product { ProductId = 3, ProductName = "Hp Labtop", Brand = "HP", Price = 5.99m, Stock = 200, Description = "Description for Product 3", Category = 1 }
        };
        [HttpGet]
        public ActionResult<IEnumerable<Models.Product>> GetProducts()
        {
            return Ok(products);
        }
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Models.Product>> GetProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.ProductId == id);
            if(product==null)
                return NotFound("Product not found");
            return Ok(product);
        }
        [HttpPost]
        public IActionResult AddProduct(Models.Product product)
        {
            product.ProductId = products.Max(p => p.ProductId) + 1;
            products.Add(product);
            return Ok(product);
        }
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var product= products.FirstOrDefault(p => p.ProductId == id);
            if(product==null)
                return NotFound("Product not found");
            products.Remove(product);
            return Ok("product deleted succesfully");
        }
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id,Models.Product product)
        {
            var existingProduct = products.FirstOrDefault(p => p.ProductId == id);
            if(existingProduct==null)
                return NotFound("Product not found");
            products.Remove(existingProduct);
            product.ProductId=id;
            products.Add(product);
            return Ok(product);
        }
    }
}
