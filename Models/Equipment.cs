namespace apbd_cw3_s33244.Models;

public class Equipment
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; }
    public bool IsAvailable { get; set; } = true;
    public bool IsDamaged { get; set; } = false;
    
    protected Equipment(string name)
    {
        Name = name;
    }
}