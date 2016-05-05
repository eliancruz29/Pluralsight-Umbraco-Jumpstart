using Umbraco.Web.WebApi;
using ElianPrueba.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net;

namespace ElianPrueba.Controllers
{
    public class ProductsApiController : UmbracoApiController
    {
        Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Salsa", Price = 150m },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 5m },
            new Product { Id = 3, Name = "Hammer", Category = "hardware", Price = 1000m }
        };

        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        public Product GetProductById(int Id)
        {
            var product = products.FirstOrDefault((p) => p.Id == Id);
            if(null == product)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return product;
        }
    }
}