namespace EmployeeCRUDJan24.Models
{
	public class Employee
	{
		//guid - global unique identifier
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public DateTime DateOfJoin { get; set; }
		public string Designation {  get; set; }
		public double Salary { get; set; }
	}
}
