using apbd_cw3_s33244.Interfaces;
using apbd_cw3_s33244.Models;

namespace apbd_cw3_s33244.Services.Services;

public class UserService : IUserService
{
    private readonly List<User> _users = new();
    
    public void AddUser(User user)
    {
        _users.Add(user);
        Console.WriteLine($"[DODANO] {user.GetType().Name}: {user.FullName}");
    }
    
    public List<User> GetAllUsers()
    {
        return _users;
    }
    
    public User? GetUserById(string id)
    {
        return _users.FirstOrDefault(u => u.Id == id);
    }
}