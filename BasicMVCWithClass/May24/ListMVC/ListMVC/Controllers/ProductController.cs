using ListMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;
using System.Reflection.Metadata.Ecma335;

namespace ListMVC.Controllers
{
	public class ProductController : Controller
	{
		//create a default list and add few products to it
		private static List<Product> products = new List<Product>
		{
			new Product{Id=1, Name="Product1", Price =3000},
			new Product{Id=2, Name="Product2", Price =2000},
			new Product{Id=3, Name="Product3", Price =1000}
		};
		public ActionResult Index()
		{
			return View(products);
		}

		//add functionality to create new product and add to the existing list
		public ActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Create(Product product)
		{
			//add new row to the list
			//by checking if the list has any rows in them
			//if exists then add new row id by +1
			//? : conditional operator - used instead of if else
			if (products.Any())
			{
				product.Id = products.Max(p => p.Id) + 1;
			}
			else
			{
				product.Id = 1;
			}
			products.Add(product);//adding name and price
			//after add items to the list, go back to index page
			return RedirectToAction("Index");
		}
		//edit functionality
		//to retrieve and display the record
		[HttpGet]
		public ActionResult Edit(int id)
		{
			var product=products.FirstOrDefault(p => p.Id == id);
			return View(product);
		}
		//update the changes made to the list
		[HttpPost]
		public ActionResult Edit(Product updatedProduct)
		{
			var product=products.FirstOrDefault(p=>p.Id == updatedProduct.Id);
			product.Name = updatedProduct.Name;
			product.Price = updatedProduct.Price;
			//after update display the list - go to index page
			return RedirectToAction("Index");
		}

		//delete functionality
		[HttpGet]
		public ActionResult Delete(int id)
		{
			var product=products.FirstOrDefault(p => p.Id == id);
			return View(product);
		}
		[HttpPost]
		public ActionResult DeleteConfirmed(int id)
		{
			var product=products.FirstOrDefault(p => p.Id == id);
			//delete using Remove method
			products.Remove(product);
			//after delete go to index page
			return RedirectToAction("Index");
		}
	}
}
