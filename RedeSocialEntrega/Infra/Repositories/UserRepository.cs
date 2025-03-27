using Domain;
using Domain.DTO;
using Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlContext sqlContext;

        public UserRepository()
        {
            sqlContext = new SqlContext();
        }

        public bool AddUser(User user)
        {
            if (user == null) return false;
            sqlContext.Users.Add(user);
            sqlContext.SaveChanges();
            return true;
        }

        public bool DeleteUser(int id)
        {
            if (id <= 0) return false;
            var user = sqlContext.Users.Find(id);
            sqlContext.Users.Remove(user);
            return true;
        }

        public List<User> GetAll()
        {
            return sqlContext.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return sqlContext.Users.Find(id);
        }

        public bool UpdateUser(int id, User user)
        {
            var userOld = sqlContext.Users.Find(id);

            if (userOld == null)
            {
                throw new KeyNotFoundException("User not found!");
            }

            userOld.Name = user.Name;
            userOld.Email = user.Email;
            userOld.Course = user.Course;

            sqlContext.SaveChanges();
            return true;
        }
    }
}
