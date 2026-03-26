using apbd_cw3_s33244.Models;

namespace apbd_cw3_s33244.Interfaces;

public interface IEquipmentService
{
    void AddEquipment(Equipment equipment);
    List<Equipment> GetAllEquipment();
    List<Equipment> GetAvailableEquipment();
    Equipment? GetEquipmentById(string id);
}