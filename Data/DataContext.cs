using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Identity;
using OnLineClothing.Models;
using MySql.Data;


namespace OnLineClothing.Data
{
    
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options)
        {

        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<OrderHistory> OrderHistory { get; set; }
    }
}
