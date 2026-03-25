using apbd_cw3_s33244.Models;

namespace apbd_cw3_s33244.Interfaces;

public interface IUserService
{
    void AddUser(User user);
    List<User> GetAllUsers();
    User? GetUserById(string id);
}