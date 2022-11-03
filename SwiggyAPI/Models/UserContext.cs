using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwiggyAPI.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Products> Products { get; set; }

        public DbSet<Cart> Cart { get; set; }
        public DbSet<Orders> Orders { get; set; }
    }
}
