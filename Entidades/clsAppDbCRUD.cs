using Microsoft.EntityFrameworkCore;
using System;

namespace TramposGestaoPedidosAPI.Entidades
{
    public class clsAppDbCRUD : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public clsAppDbCRUD(DbContextOptions<clsAppDbCRUD> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
