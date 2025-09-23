using UnitTestControllerDemo.Models;

namespace UnitTestControllerDemo.Data
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        List<User> GetAllUsers();
        User AddUser(User user);
        User UpdateUser(User user);
        User DeleteUser(int id);
    }
}
