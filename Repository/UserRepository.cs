using Entities;
using System.Text.Json;
using System;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        SuperMarket214338766Context _superMarketContext;

        public UserRepository(SuperMarket214338766Context superMarketContext)
        {
            _superMarketContext = superMarketContext;
           
        }

        public async Task<User> getUserByUserNameAndPassword(string UserName, string Password)
        {
            return await _superMarketContext.Users.Where(i =>  i.UserName == UserName && i.Password == Password).FirstOrDefaultAsync();
        }





        public async Task<User> createNewUser(User user)
        {
            await _superMarketContext.AddAsync(user);
            await _superMarketContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> update(int id, User userToUpdate)
        {
            _superMarketContext.Users.Update(userToUpdate); ;
            await _superMarketContext.SaveChangesAsync();
            return userToUpdate;
        }


        public async Task<User> getUserById(int id)
        {
            return await _superMarketContext.Users.FindAsync(id);

        }


    }
}