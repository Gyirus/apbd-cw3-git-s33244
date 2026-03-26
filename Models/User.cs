namespace apbd_cw3_s33244.Models;

public abstract class User
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public abstract int MaxActiveRentals { get; }
    
    protected User(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    
    public string FullName => $"{FirstName} {LastName}";
}
