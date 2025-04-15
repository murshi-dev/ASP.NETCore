namespace EmpMgmt.Models
{
    public class AddEmployeeModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DOJ { get; set; }
        public string Designation { get; set; }
        public double Salary { get; set; }
    }
}
