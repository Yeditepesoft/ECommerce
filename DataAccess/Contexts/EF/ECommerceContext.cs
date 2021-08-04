using System.Reflection;
using DataAccess.Entities;
using DataAccess.Extensions;
using DataAccess.Mappings.EF;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Contexts.EF
{
    public class ECommerceContext :DbContext
    {


        public DbSet<User> Users { get; set; } 
        public DbSet<UserGroup> UserGroups { get; set; } 
        public DbSet<Gender> Genders { get; set; }

        public ECommerceContext()
        {
            
        }
        
        public ECommerceContext(DbContextOptions options) :base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Server=localhost,1433;Database=ECommerce;User=sa;Password=Yaren#1998;");
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
            modelBuilder.SetDataType();
            
            base.OnModelCreating(modelBuilder);
        }
    }
}