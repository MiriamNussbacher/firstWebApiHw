using Entities;

namespace Repository
{
    public interface IUserRepository
    {
        User createNewUser(User user);
        Task<string> getUserById(int id);
        Task<User> getUserByUserNameAndPassword(string UserName, string Password);
        Task update(int id, User userToUpdate);
    }
}