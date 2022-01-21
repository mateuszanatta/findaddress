using Microsoft.EntityFrameworkCore;
using AddressService.Models;

namespace AddressService.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }    
    }
}