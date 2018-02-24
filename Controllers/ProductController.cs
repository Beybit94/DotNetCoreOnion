using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using test.Data;
using test.Service;

namespace test.Controllers {
    [Route ("api/[controller]/[action]")]
    public class ProductController : Controller {
        private readonly IProductService productService;
        
        public ProductController(IProductService productService){
            this.productService=productService;
        }

        [HttpGet]
        public IEnumerable<Product> Get(){
            return productService.GetProducts();
        }

        [HttpGet("{id}",Name="GetProductById")]
        public Product Get(int id){
            return productService.GetProduct(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Product product){
            if(product==null){
                return BadRequest();
            }

            product.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString ();
            product.ModifiedDate = DateTime.Now;
            productService.InsertProduct(product);

            return Ok();
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Product product){
            if(product==null){
                return BadRequest();
            }

            var item = productService.GetProduct(product.Id);
            if (item == null) {
                return NotFound ();
            }

            item.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString ();
            item.ModifiedDate = DateTime.Now;
            item.name=product.name;
            item.count=product.count;
            productService.UpdateProduct(item);
            
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id){
            var item = productService.GetProduct(id);
            if (item == null) {
                return NotFound ();
            }

            productService.DeleteProduct(item.Id);
            return NoContent();
        }
    }
}