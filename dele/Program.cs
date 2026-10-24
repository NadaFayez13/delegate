namespace dele
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<product> catalog = new()
            {
                new product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 1200, Stock = 10 },
                new product { Id = 2, Name = "Phone", Category = "Electronics", Price = 800, Stock = 25 },
                new product { Id = 3, Name = "T-Shirt", Category = "Clothing", Price = 30, Stock = 100 },
                new product { Id = 4, Name = "Jeans", Category = "Clothing", Price = 60, Stock = 50 },
                new product { Id = 5, Name = "Chocolate", Category = "Food", Price = 5, Stock = 200 },
                new product { Id = 6, Name = "Coffee Beans", Category = "Food", Price = 15, Stock = 80 },
                new product { Id = 7, Name = "C# Book", Category = "Books", Price = 45, Stock = 30 },
                new product { Id = 8, Name = "Novel", Category = "Books", Price = 20, Stock = 60 },
                new product { Id = 9, Name = "Headphones", Category = "Electronics", Price = 150, Stock = 40 },
                new product { Id = 10, Name = "Jacket", Category = "Clothing", Price = 120, Stock = 15 }
            };

            #region Task 01 : Smart Product Search
            static bool IsElectronic(product p)
            {
                return p.Category == "Electronics";
            }

            static bool IsCheap(product p)
            {
                return p.Price < 50;
            }

            static bool IsInStock(product p)
            {
                return p.Stock > 0;
            }

            static bool IsCheapClothing(product p)
            {
                return p.Category == "Clothing" && p.Price < 100;
            }


            static List<product> SearchProducts(List<product> products, Func<product, bool> filter)
            {
                List<product> result = new List<product>();

                foreach (var product in products)
                {
                    if (filter(product))
                    {
                        result.Add(product);
                    }
                }
                return result;
            }


            Console.WriteLine("---------- Electronics ----------");
            var electronics = SearchProducts(catalog, IsElectronic);
            foreach (var p in electronics)
            {
                Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})");
            }

            Console.WriteLine("\n---------- Under $50 -------------");
            var cheapProducts = SearchProducts(catalog, IsCheap);
            foreach (var p in cheapProducts)
            {
                Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})");
            }

            Console.WriteLine("\n---------- In Stock --------");
            var inStockProducts = SearchProducts(catalog, IsInStock);
            foreach (var p in inStockProducts)
            {
                Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})");
            }

            Console.WriteLine("\n---------- Clothing Under $100 ----------");
            var cheapClothing = SearchProducts(catalog, IsCheapClothing);
            foreach (var p in cheapClothing)
            {
                Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})");
            }
            #endregion
        }
    }
}
