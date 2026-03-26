using apbd_cw3_s33244.Models;

namespace apbd_cw3_s33244.Interfaces;

public interface IRentalService
{
    bool RentEquipment(Equipment equipment, User user, int rentalDays);
    bool ReturnEquipment(string rentalId);
    List<Rental> GetActiveRentalsForUser(string userId);
    List<Rental> GetOverdueRentals();
    void MarkEquipmentAsDamaged(string equipmentId);
}