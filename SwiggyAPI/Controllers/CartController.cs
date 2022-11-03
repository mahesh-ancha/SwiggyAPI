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
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]

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
            var products = await _context.Cart.ToListAsync();
            return Ok(products);
        }
        [HttpPost]
        public async Task<IActionResult> AddCart([FromBody] Products product)
        {
            Cart cart = new Cart();
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
