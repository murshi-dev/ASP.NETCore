//write a C# code to create a List
//and execute LINQ queries on the List
//LINQ - language Integrated Query
//has common format to access all Collections
//lists arrays xml sql and so on

public class Program
{
	public static void Main()
	{
		//create a List and add few products to it
		List<Product> products = new List<Product>()
		{
			new Product{Id=1,Name="Laptop",Price=5000},
			new Product{Id=2,Name="Mobile",Price=4000},
			new Product{Id=3,Name="Tablet",Price=2500},
			new Product{Id=4,Name="Monitor",Price=1500},
			new Product{Id=5,Name="Keyboard",Price=500}
		};
		
		//display the list in the console
		var productsName  = products.Select(p => p.Name);
		Console.WriteLine("Products in the List are:\n");
		foreach (var product in products)
		{
			Console.WriteLine(product.Name);
		}
		
		//display an item based on an ID
		//where - FirstOrDefault
		var specificProduct  = products.FirstOrDefault(p => p.Id == 3);
		if (specificProduct != null)
		{
			Console.WriteLine(specificProduct.Name);
		}
		else
		{
			Console.WriteLine("Product not found");
		}
		
		//display products with price > 2000
		var expProducts = products.Where(p => p.Price >=2000);
		Console.WriteLine("Products with price greater than 2000 in the List are:\n");
		foreach (var product in expProducts)
		{
			Console.WriteLine(product.Name,product.Price);
		}

		//sort products by name - ascending
		var sortedProducts = products.OrderBy(p => p.Name);
		Console.WriteLine("Products sorted in ascending order by name in the List are:\n");
		foreach (var product in sortedProducts)
		{
			Console.WriteLine(product.Name);
		}

		//display the max priced product
		var maxPrice = products.Max(p => p.Price);
		Console.WriteLine("Product with max price is ", maxPrice);

		//display the total value of all products
		var totalPrice = products.Sum(p => p.Price);
		Console.WriteLine("Total price of all products is ", totalPrice);
	}
}