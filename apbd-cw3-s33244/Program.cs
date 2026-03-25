using apbd_cw3_s33244.Interfaces;
using apbd_cw3_s33244.Models;
using apbd_cw3_s33244.Services.Services;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== WYPOŻYCZALNIA SPRZĘTU ===\n");
        
        IEquipmentService equipmentService = new EquipmentService();
        IUserService userService = new UserService();
        IRentalService rentalService = new RentalService(equipmentService, userService);
        
        Console.WriteLine("--- DODAWANIE SPRZĘTU ---");
        equipmentService.AddEquipment(new Laptop("Dell XPS", "Intel i7", 32));
        equipmentService.AddEquipment(new Laptop("MacBook Pro", "M2 Pro", 16));
        equipmentService.AddEquipment(new Projector("Epson EB-2250U", 5000, "1920x1200"));
        equipmentService.AddEquipment(new Camera("Canon EOS R5", 45, "RF 24-105mm"));
        
        Console.WriteLine("\n--- DODAWANIE UŻYTKOWNIKÓW ---");
        var student = new Student("Jan", "Kowalski", "s12345");
        var employee = new Employee("Anna", "Nowak", "e6789", "Informatyka");
        userService.AddUser(student);
        userService.AddUser(employee);
        
        Console.WriteLine("\n--- DOSTĘPNY SPRZĘT ---");
        foreach (var eq in equipmentService.GetAvailableEquipment())
            Console.WriteLine($"- {eq.Name}");
        
        Console.WriteLine("\n--- WYPOŻYCZENIE ---");
        var laptop = equipmentService.GetAvailableEquipment().First();
        rentalService.RentEquipment(laptop, student, 14);
        
        Console.WriteLine("\n--- PRÓBA PRZEKROCZENIA LIMITU ---");
        var projector = equipmentService.GetAvailableEquipment().First();
        rentalService.RentEquipment(projector, student, 14);
        var camera = equipmentService.GetAvailableEquipment().First();
        rentalService.RentEquipment(camera, student, 14); // powinno się nie udać
        
        Console.WriteLine("\n--- ZWROT W TERMINIE ---");
        var activeRental = rentalService.GetActiveRentalsForUser(student.Id).First();
        rentalService.ReturnEquipment(activeRental.Id);
        
        Console.WriteLine("\n--- SYMULACJA OPÓŹNIENIA ---");
        var camera2 = equipmentService.GetAvailableEquipment().First();
        rentalService.RentEquipment(camera2, employee, 1);
        Console.WriteLine("Symuluję opóźnienie 3 dni...");
        var rental = rentalService.GetActiveRentalsForUser(employee.Id).First();
        rental.ReturnDate = DateTime.Now.AddDays(3); // ręczna symulacja
        rentalService.ReturnEquipment(rental.Id);
        
        Console.WriteLine("\n=== RAPORT KOŃCOWY ===");
        Console.WriteLine($"Aktywne wypożyczenia: {rentalService.GetActiveRentalsForUser(student.Id).Count}");
        Console.WriteLine($"Przeterminowane: {rentalService.GetOverdueRentals().Count}");
        
        Console.WriteLine("\nNaciśnij dowolny klawisz...");
        Console.ReadKey();
    }
}