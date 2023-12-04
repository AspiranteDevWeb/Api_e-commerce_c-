using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions option) : base(option)
        {
            
        }

        public DbSet<Product> Products { get; set; }

    }
}

