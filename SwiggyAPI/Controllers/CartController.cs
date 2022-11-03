using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwiggyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwiggyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : Controller
    {

        private readonly UserContext _context;


        public CartController(UserContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCart()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }
        [HttpPost]
        public async Task<IActionResult> AddCart(int productId)
        {
            Cart cart=new Cart();
            var product = await _context.Products.FindAsync(productId);
            cart.ProductName = product.ProductName;
            cart.Img = product.Img;
            cart.Category = product.Category;
            cart.Quantity = product.Quantity;
            cart.price = product.price;
            await _context.Cart.AddAsync(cart);
            await _context.SaveChangesAsync();
            return Ok(cart);
        }
    }
}
