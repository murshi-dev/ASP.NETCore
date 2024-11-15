using Microsoft.AspNetCore.Mvc;
using ListMVC.Models;
namespace ListMVC.Controllers
{
	public class ProductController : Controller
	{
		//create a static list 
		private static List<Product> products = new List<Product>
		{
			new Product { Id = 1,Name="Product1",Price=1000 },
			new Product { Id = 2,Name="Product2",Price=2000 },
			new Product { Id = 3,Name="Product3",Price=3000 }
		};
		//Index() is the default method that will be invoked 
		//when the application starts
		public ActionResult Index()
		{
			return View(products);//display the list of products
		}

		//handle create GET method
		public ActionResult Create()
		{
			return View();
		}

		//handle create POST method
		[HttpPost]
		public ActionResult Create(Product product)
		{
			if (products.Any())//if the list has items
			{
				product.Id = products.Max(p => p.Id) + 1;
			}
			else//if the list is empty
			{
				product.Id = 1;
			}
			products.Add(product);//add name and price to list
			//after adding the item to the list, go back to index page
			return RedirectToAction("Index");
		}

		//edit list item
		[HttpGet]
		public ActionResult Edit(int id)
		{
			var product= products.FirstOrDefault(p => p.Id == id);
			return View(product);
		}
		[HttpPost]
		public ActionResult Edit(Product editedProduct)
		{
			var product=products.FirstOrDefault(p=>p.Id == editedProduct.Id);
			if(product != null)
			{
				product.Name = editedProduct.Name;
				product.Price = editedProduct.Price;
			}
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult Delete(int id)
		{
			var product = products.FirstOrDefault(p => p.Id == id);
			return View(product);
		}
		[HttpPost]
		public ActionResult DeleteConfirmed(int id)
		{
			var product = products.FirstOrDefault(p => p.Id == id);
			if(product != null)
			{
				products.Remove(product);
			}
			return RedirectToAction("Index");
		}
	}
}
