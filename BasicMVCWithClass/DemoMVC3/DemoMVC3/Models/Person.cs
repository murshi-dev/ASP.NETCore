namespace DemoMVC3.Models
{
	public class Person
	{
		public string PersonName { get; set; }
		public int PersonAge { get; set; }
		public string PersonLocation { get; set; }
	}
	public class ViewPerson
	{
		//use IEnumerable to loop over the person list using for each
		//can loop over an array or a list or any custom data types
		public IEnumerable<Person> Persons { get; set; }

	}


}
