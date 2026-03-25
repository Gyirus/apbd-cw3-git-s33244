namespace apbd_cw3_s33244.Models;

public class Student : User
{
    public string StudentId { get; set; }
    public override int MaxActiveRentals => 2;
    
    public Student(string firstName, string lastName, string studentId) 
        : base(firstName, lastName)
    {
        StudentId = studentId;
    }
}