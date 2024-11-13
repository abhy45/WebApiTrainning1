using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecondExample_CFWebApi.Data;
using SecondExample_CFWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondExample_CFWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly MyDBContext context;
        public ProductsController(MyDBContext context)
        {
            this.context = context;
        }

        [HttpGet("AllProducts")]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return Ok(await context.Products.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var foundProduct = await context.Products.FindAsync(id);
            if (foundProduct == null) return BadRequest("Product not found");
            return Ok(foundProduct);
        }

        [HttpPost("AddProduct")]
        public async Task<ActionResult<List<Product>>> AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return await context.Products.ToListAsync();
        }
    }
}
