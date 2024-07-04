class Program
{
    static void Main(string[] args)
    {
        //craete a var that represents the AppDbContext class
        using (var dbContext = new AppDbContext())
        {
            //ensure the db is created in sql server
            dbContext.Database.EnsureCreated();

            //add new employee to the employee table
            //use Any() linq method to check if any records already exists
            //in the table
            if(!dbContext.Employees.Any())
            {
                dbContext.Employees.Add(new Employee {  EmpName = "Jane", Salary = 5000 });
                dbContext.Employees.Add(new Employee { EmpName = "Kate", Salary = 6000 });
                dbContext.Employees.Add(new Employee { EmpName = "Lim", Salary = 7000 });
                dbContext.Employees.Add(new Employee { EmpName = "Amy", Salary = 8000 });
                dbContext.Employees.Add(new Employee { EmpName = "Nate", Salary = 9000 });
              
                dbContext.SaveChanges();
            }
            //retrieved data from table and display in the console
            var allEmployees = dbContext.Employees.ToList();
            foreach (var employee in allEmployees)
            {
                Console.WriteLine($"EmpId: {employee.Id} EmpName: {employee.EmpName} " +
                    $"EmpSalary: {employee.Salary}");
            }
            //retrieve records based on condition
            //display emp with salary>=7000
            var highPaidEmployees = dbContext.Employees.Where(e=>e.Salary >= 7000).ToList();
            Console.WriteLine("High Paid Employees:\n ");
            foreach (var employee in highPaidEmployees)
            {
                Console.WriteLine($"EmpId: {employee.Id} EmpName: {employee.EmpName} " +
                    $"EmpSalary: {employee.Salary}");
            }
        }
    }
}