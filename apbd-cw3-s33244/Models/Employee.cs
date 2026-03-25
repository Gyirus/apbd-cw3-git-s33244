namespace apbd_cw3_s33244.Models;

public class Employee : User
{
    public string EmployeeId { get; set; }
    public string Department { get; set; }
    public override int MaxActiveRentals => 5;
    
    public Employee(string firstName, string lastName, string employeeId, string department) 
        : base(firstName, lastName)
    {
        EmployeeId = employeeId;
        Department = department;
    }
}