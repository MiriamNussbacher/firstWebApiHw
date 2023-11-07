using Entities;

namespace Repository
{
    public interface IUserRepository
    {
        Task<User> createNewUser(User user);
        Task<User> getUserById(int id);
        Task<User> getUserByUserNameAndPassword(string UserName, string Password);
        Task<User> update(int id, User userToUpdate);
    }
}