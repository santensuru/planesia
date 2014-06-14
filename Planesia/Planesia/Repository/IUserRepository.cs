using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planesia.Models;

namespace Planesia.Repository
{
    public interface IUserRepository
    {
        List<User> Users { get; }

        User GetUserById(int id);

        void AddUser(User u);

        void UpdateUser(User u);

        void DeleteUser(int id);
    }
}
