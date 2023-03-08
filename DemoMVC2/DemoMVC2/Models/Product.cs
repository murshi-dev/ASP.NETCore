namespace DemoMVC2.Models
{
	public class Product
	{
		public string PName { get; set; }
		public double PPrice { get; set; }
		public int PQuantity { get; set; }

		public double DiscountPercent { get; set; }

		public int VendorContact { get; set; }
	}
}
