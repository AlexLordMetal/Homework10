using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Supermarkets
{
    public class DBManagement
    {

        public void MainMenu()
        {
            var exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Select an action:");
                Console.WriteLine("1. Add a shop");
                Console.WriteLine("2. Add a product to shop");
                Console.WriteLine("3. Change product quantity");
                Console.WriteLine("4. Buy a product");
                Console.WriteLine("5. Exit");

                switch (Console.ReadLine())
                {
                    case "1":
                        AddShop();
                        break;
                    case "2":
                        AddProduct();
                        break;
                    case "3":
                        ChangeProductQuantity();
                        break;
                    //case "4":
                    //    BuyProduct();
                    //    break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Incorrect selection");
                        break;
                }
            }
        }

        public void AddShop()
        {
            Console.Clear();
            Console.WriteLine("Enter shop name:");
            var name = Console.ReadLine();
            Console.WriteLine("Enter shop address:");
            Console.WriteLine("Enter country:");
            var country = Console.ReadLine();
            Console.WriteLine("Enter city:");
            var city = Console.ReadLine();
            Console.WriteLine("Enter street:");
            var street = Console.ReadLine();
            Console.WriteLine("Enter building number:");
            var buildingNumber = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter postal code:");
            var postalCode = Console.ReadLine();

            var shop = new Shop
            {
                Name = name,
                Address = new Address
                {
                    Country = country,
                    City = city,
                    Street = street,
                    BuildingNumber = buildingNumber,
                    PostalCode = postalCode
                },
                Products = new List<Product>()
            };

            using (var context = new ShopsContext())
            {
                context.Shops.Add(shop);
                context.SaveChanges();
            }
        }

        public void AddProduct()
        {
            Console.Clear();
            Console.WriteLine("Enter product name:");
            var name = Console.ReadLine();
            Console.WriteLine("Enter product quantity:");
            var quantity = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter product price:");
            var price = Decimal.Parse(Console.ReadLine());

            var product = new Product
            {
                Name = name,
                Quantity = quantity,
                Price = price
            };

            using (var context = new ShopsContext())
            {
                Console.WriteLine("Select a shop to add the product:");
                Console.WriteLine(" 0. No shop");
                foreach (var shop in context.Shops)
                {
                    Console.WriteLine($" {shop.ID}. {shop.Name}");
                }
                var shopID = Int32.Parse(Console.ReadLine());

                if (shopID != 0)
                {
                    var shop = context.Shops.Find(shopID);
                    if (shop != null) shop.Products.Add(product);
                    context.SaveChanges();
                }
                else
                {
                    context.Products.Add(product);
                    context.SaveChanges();
                }
            }
        }

        public void ChangeProductQuantity()
        {
            Console.Clear();

            using (var context = new ShopsContext())
            {
                Console.WriteLine("Select a product to change its quantity:");
                foreach (var product in context.Products)
                {
                    Console.WriteLine($"\t{product.ID}. {product.Name},\tquantity - {product.Quantity}");
                }
                Console.WriteLine("Other - Go to main menu");

                var productID = Int32.Parse(Console.ReadLine());

                var productToChange = context.Products.Find(productID);
                if (productToChange != null)
                {
                    Console.WriteLine($"Enter changed quantity of {productToChange.Name}");
                    var quantity = Int32.Parse(Console.ReadLine());
                    productToChange.Quantity = quantity;
                    context.SaveChanges();
                }
            }
        }

    }
}
