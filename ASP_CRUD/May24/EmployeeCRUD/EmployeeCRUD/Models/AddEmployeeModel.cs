namespace EmployeeCRUD.Models
{
    public class AddEmployeeModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfJoin { get; set; }
        public string Designation { get; set; }
        public double Salary { get; set; }
    }
}
