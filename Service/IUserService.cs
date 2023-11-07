using Entities;

namespace Service
{
    public interface IUserService
    {
        int checkPassword(string password);
        Task<User> createNewUser(User user);
        Task<User> getUserById(int id);
        Task<User> getUserByUserNameAndPassword(string UserName, string Password);
        Task<User> update(int id, User userToUpdate);
    }
}