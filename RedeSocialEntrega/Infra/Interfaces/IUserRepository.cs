using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Infra.Interfaces
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        bool AddUser(User user);
        List<User> GetAll();
        bool UpdateUser(int id, User user);
        bool DeleteUser(int id);

    }
}
