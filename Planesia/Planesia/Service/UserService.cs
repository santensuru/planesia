using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Planesia.Repository;
using Planesia.Models;

namespace Planesia.Service
{
    public class UserService
    {
        IUserRepository userRepository;

        public UserService()
        {
            userRepository = new UserRepositoryDb();
        }

        public UserService(IUserRepository repository)
        {
            userRepository = repository;
        }

        public List<User> GetAllUsers()
        {
            return userRepository.Users;
        }

        public User GetUserById(int id)
        {
            return userRepository.GetUserById(id);
        }

        public void AddUser(User u)
        {
            userRepository.AddUser(u);
        }

        public void UpdateUser(User u)
        {
            userRepository.UpdateUser(u);
        }

        public void DeleteUser(int id)
        {
            userRepository.DeleteUser(id);
        }
    }
}