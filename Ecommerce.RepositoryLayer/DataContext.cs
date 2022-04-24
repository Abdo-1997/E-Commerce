using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ecommerce.DomainLayer;
using Ecommerce.DomainLayer.models;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.RepositoryLayer
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Product> products { set; get; }
        public DbSet<supcat> supcats { set; get; }
        public DbSet<maincat> maincats { set; get; }
        public DbSet<picture> pictures { set; get; }

        //enable lazy loading
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
