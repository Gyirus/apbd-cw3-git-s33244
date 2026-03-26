namespace apbd_cw3_s33244.Models;

public class Rental
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public Equipment Equipment { get; set; }
    public User User { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public decimal? Fine { get; set; }
    public bool IsActive => ReturnDate == null;
    
    public Rental(Equipment equipment, User user, DateTime rentalDate, int rentalDays)
    {
        Equipment = equipment;
        User = user;
        RentalDate = rentalDate;
        DueDate = rentalDate.AddDays(rentalDays);
    }
    
    public decimal CalculateFine(decimal dailyFineRate)
    {
        if (ReturnDate == null || ReturnDate <= DueDate)
            return 0;
            
        var daysLate = (ReturnDate.Value - DueDate).Days;
        return daysLate * dailyFineRate;
    }
}