using apbd_cw3_s33244.Interfaces;
using apbd_cw3_s33244.Models;

namespace apbd_cw3_s33244.Services.Services;

public class RentalService : IRentalService
{
       private readonly List<Rental> _rentals = new();
    private readonly IEquipmentService _equipmentService;
    private readonly IUserService _userService;
    private const decimal DailyFineRate = 10m;
    
    public RentalService(IEquipmentService equipmentService, IUserService userService)
    {
        _equipmentService = equipmentService;
        _userService = userService;
    }
    
    public bool RentEquipment(Equipment equipment, User user, int rentalDays)
    {
        if (!equipment.IsAvailable || equipment.IsDamaged)
        {
            Console.WriteLine($"[BLAD] Sprzęt '{equipment.Name}' jest niedostępny!");
            return false;
        }
        
        var activeCount = GetActiveRentalsForUser(user.Id).Count;
        if (activeCount >= user.MaxActiveRentals)
        {
            Console.WriteLine($"[BLAD] {user.FullName} przekroczył limit {user.MaxActiveRentals} wypożyczeń!");
            return false;
        }
        
        var rental = new Rental(equipment, user, DateTime.Now, rentalDays);
        equipment.IsAvailable = false;
        _rentals.Add(rental);
        
        Console.WriteLine($"[OK] {user.FullName} wypożyczył {equipment.Name}. Zwrot do {rental.DueDate:dd.MM.yyyy}");
        return true;
    }
    
    public bool ReturnEquipment(string rentalId)
    {
        var rental = _rentals.FirstOrDefault(r => r.Id == rentalId && r.IsActive);
        if (rental == null)
        {
            Console.WriteLine("[BLAD] Nie znaleziono aktywnego wypożyczenia!");
            return false;
        }
        
        rental.ReturnDate = DateTime.Now;
        rental.Fine = rental.CalculateFine(DailyFineRate);
        rental.Equipment.IsAvailable = true;
        
        if (rental.Fine > 0)
            Console.WriteLine($"[KARA] Opóźnienie {rental.Fine:C} zł");
        else
            Console.WriteLine("[OK] Zwrot w terminie");
        
        return true;
    }
    
    public List<Rental> GetActiveRentalsForUser(string userId)
    {
        return _rentals.Where(r => r.User.Id == userId && r.IsActive).ToList();
    }
    
    public List<Rental> GetOverdueRentals()
    {
        return _rentals.Where(r => r.IsActive && r.DueDate < DateTime.Now).ToList();
    }
    
    public void MarkEquipmentAsDamaged(string equipmentId)
    {
        var eq = _equipmentService.GetEquipmentById(equipmentId);
        if (eq != null)
        {
            eq.IsDamaged = true;
            eq.IsAvailable = false;
            Console.WriteLine($"[OK] Sprzęt '{eq.Name}' oznaczony jako uszkodzony");
        }
    }
}