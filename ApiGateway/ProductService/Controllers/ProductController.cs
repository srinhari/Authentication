using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ProductService.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IList<Product> _products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Radio",
                Price = 300.00f

            },
            new Product {
                Id = 2,
                Name = "TV",
                Price = 30000.00f

            },
            new Product {
                Id = 3,
                Name = "Fridge",
                Price = 25000.00f

            }
        };

        [HttpGet("/products")]
        public ActionResult Index()
        {
            return Ok(_products);
        }

        [HttpGet("/products/{id}")]
        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return Ok(_products.SingleOrDefault(product => product.Id == id));
        }
    }
}
