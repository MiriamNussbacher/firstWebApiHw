using Entities;

namespace Repository
{
    public interface IUserRepository
    {
        User createNewUser(User user);
        string getUserById(int id);
        User getUserByUserNameAndPassword(string UserName, string Password);
        void update(int id, User userToUpdate);
    }
}