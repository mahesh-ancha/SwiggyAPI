using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwiggyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwiggyAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]

    public class ProductsController : ControllerBase
    {
        private readonly UserContext _context;
        public ProductsController(UserContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }
        [HttpPost]
        public async Task<IActionResult> AddProducts([FromBody] Products p)
        {
            await _context.Products.AddAsync(p);
            await _context.SaveChangesAsync();
            return Ok(p);
        }
        //[HttpPost("AddCart/{productId}")]
        //public async Task<IActionResult> AddCart(int productId)
        //{
        //    Cart cart = new Cart();
        //    var product = await _context.Products.FindAsync(productId);
        //    cart.ProductName = product.ProductName;
        //    cart.Img = product.Img;
        //    cart.Category = product.Category;
        //    cart.Quantity = product.Quantity;
        //    cart.price = product.price;
        //    await _context.Cart.AddAsync(cart);
        //    await _context.SaveChangesAsync();
        //    return Ok(cart);
        //}
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct([FromBody] int ProductId)
        {
            var product = await _context.Products.FindAsync(ProductId);
            if (product == null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return Ok(product);
        }
    }
}
