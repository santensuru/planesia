using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Planesia.Models;
using System.Data.Entity;

namespace Planesia.Repository
{
    public class UserRepositoryDb : IUserRepository
    {
        public List<User> Users
        {
            get {
                List<User> result;

                using (PlanesiaDBsEntities context = new PlanesiaDBsEntities())
                {
                    result = context.Users.ToList<User>();
                }

                return result;
            }
        }

        public User GetUserById(int id)
        {
            User user;

            using (PlanesiaDBsEntities context = new PlanesiaDBsEntities())
            {
                user = (from u in context.Users
                        where u.UserId == id
                        select u).FirstOrDefault<User>();
            }

            return user;
        }

        public void AddUser(User u)
        {
            using (PlanesiaDBsEntities context = new PlanesiaDBsEntities())
            {
                context.Users.Add(u);
                context.SaveChanges();
            }
        }

        public void UpdateUser(User u)
        {
            using (PlanesiaDBsEntities context = new PlanesiaDBsEntities())
            {
                context.Entry(u).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteUser(int id)
        {
            User user;
            using (PlanesiaDBsEntities context = new PlanesiaDBsEntities())
            {
                user = context.Users.Find(id);
                context.Users.Remove(user);
                context.SaveChanges();
            }
        }
    }
}