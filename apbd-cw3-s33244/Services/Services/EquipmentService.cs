using apbd_cw3_s33244.Interfaces;
using apbd_cw3_s33244.Models;

namespace apbd_cw3_s33244.Services.Services;

public class EquipmentService : IEquipmentService
{
    private readonly List<Equipment> _equipment = new();
    
    public void AddEquipment(Equipment equipment)
    {
        _equipment.Add(equipment);
        Console.WriteLine($"[DODANO] {equipment.GetType().Name}: {equipment.Name}");
    }
    
    public List<Equipment> GetAllEquipment()
    {
        return _equipment;
    }
    
    public List<Equipment> GetAvailableEquipment()
    {
        return _equipment.Where(e => e.IsAvailable && !e.IsDamaged).ToList();
    }
    
    public Equipment? GetEquipmentById(string id)
    {
        return _equipment.FirstOrDefault(e => e.Id == id);
    }
}