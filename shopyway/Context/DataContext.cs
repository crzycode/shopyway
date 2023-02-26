using Microsoft.EntityFrameworkCore;
using shopyway.Function;
using shopyway.Model;
using shopyway.Model.Electronics;
using shopyway.Model.Fashion;
using shopyway.Model.Men;
using shopyway.Model.Mobile_and_Accessory;
using shopyway.Model.Topdeals;
using shopyway.Model.Women;

namespace shopyway.Context
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext>options): base(options)
        {

        }
        public DbSet<Product> products { get; set; }
        
        public DbSet<User> users { get; set; }
        public DbSet<City_data> city { get; set; }
        public DbSet<Topdeals> topdeals { get; set; }
        public DbSet<TopElec_products> topElec { get; set; }
        public DbSet<TopElec_category> elec_category { get; set; }
        public DbSet<Fashion_category> fashion_Categories { get; set; }

        public DbSet<top_clothes> top_clothes { get; set; }

        public DbSet<Ajiomen> Ajiomen { get; set; }
        public DbSet<Ajiowomen> Ajiowomen { get; set; }

        public DbSet<Men_section> Men_section { get; set; }
        public DbSet<Women_section> Women_section { get; set; }

        public DbSet<Electronics_product_category> Electronics_product_category { get; set; }
        public DbSet<Electronic_products> Electronic_products { get; set; }

        public DbSet<Mobile_laptop_category> Mobile_accessory_category { get; set; }
        public DbSet<Mobile_laptop_product> Mobile_accessory_product { get; set; }
        public DbSet<Cart> cart { get; set; }
        public DbSet<Partner_user> partner_Users { get; set; }
        public DbSet<site> site { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           /* modelBuilder.Entity<gettype_fun>(c =>
            {
                c.HasNoKey();
            });*/
        }
        
    }
}
