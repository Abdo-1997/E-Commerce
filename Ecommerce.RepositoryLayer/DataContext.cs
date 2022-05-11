using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ecommerce.DomainLayer;
using Ecommerce.DomainLayer.models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
namespace Ecommerce.RepositoryLayer
{
    public class DataContext: IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Product> products { set; get; }
        public DbSet<supcat> supcats { set; get; }
        public DbSet<maincat> maincats { set; get; }
        public DbSet<picture> pictures { set; get; }
        public DbSet<Cart> cart { set; get; }
        public DbSet<CartItems> cartitems { set; get; }
        //enable lazy loading
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
       
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
