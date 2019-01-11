namespace Supermarkets.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Supermarkets.ShopsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Supermarkets.ShopsContext context)
        {
            var products1 = new List<Product>
            {
                new Product { Name="Potato", Quantity=500, Price=1.5M },
                new Product { Name="Tomato", Quantity=100, Price=5.0M },
                new Product { Name="Cucumber", Quantity=80, Price=3.5M },
                new Product { Name="Carrot", Quantity=50, Price=2.0M },
                new Product { Name="Onion", Quantity=20, Price=2.0M },
            };

            var address1 = new Address
            {
                Country = "Belarus",
                City = "Minsk",
                Street = "V.Khoruzhei",
                BuildingNumber = 8,
                PostalCode = "220100"
            };

            var shop1 = new Shop
            {
                Name = "Komarovka",
                Address = address1,
                Products = products1
            };

            var products2 = new List<Product>
            {
                new Product { Name="Chicken", Quantity=300, Price=5.5M },
                new Product { Name="Duck", Quantity=50, Price=14.5M },
                new Product { Name="Pork", Quantity=500, Price=11.0M },
                new Product { Name="Beef", Quantity=100, Price=14.0M },
                new Product { Name="Mutton", Quantity=30, Price=18.0M },
            };

            var address2 = new Address
            {
                Country = "Belarus",
                City = "Minsk",
                Street = "Kozlova",
                BuildingNumber = 5,
                PostalCode = "220034"
            };

            var shop2 = new Shop
            {
                Name = "Myasnaya Derzhava",
                Address = address2,
                Products = products2
            };

            context.Shops.AddOrUpdate(x=>x.Name, shop1, shop2);
            context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
