using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Planesia.Models;

namespace Planesia.Repository
{
    public class UserRepositoryMock : IUserRepository
    {
        List<User> users;

        public UserRepositoryMock()
        {
            users = new List<User>();

            users.Add(new User() { UserId = 1, FirstName = "ABC", LastName = "DEF" });
            users.Add(new User() { UserId = 2, FirstName = "GHI", LastName = "JKL" });
            users.Add(new User() { UserId = 3, FirstName = "MNO", LastName = "PQR" });
            users.Add(new User() { UserId = 4, FirstName = "STU", LastName = "VWX" });
            users.Add(new User() { UserId = 5, FirstName = "YAA", LastName = "ZBB" });
        }
        
        public List<User> Users
        {
            get { return users; }
        }

        public User GetUserById(int id)
        {
            User result = (from u in users
                           where u.UserId == id
                           select u).FirstOrDefault<User>();

            return result;
        }

        public void AddUser(User u)
        {
            users.Add(u);
        }

        public void UpdateUser(User user)
        {
            //User result = (from u in users
            //               where u.UserId == user.UserId
            //               select u).FirstOrDefault<User>();

            int index = users.FindIndex(p => p.UserId == user.UserId);
            if (index < 0)
            {
                users.Add(user);
            }
            else
            {
                users[index] = user;
            }

            // Masih gagal :v
            //result = user;
        }

        public void DeleteUser(int id)
        {
            User result = (from u in users
                           where u.UserId == id
                           select u).FirstOrDefault<User>();

            users.Remove(result);
        }
    }
}