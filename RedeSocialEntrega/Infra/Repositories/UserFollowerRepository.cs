using Domain;
using Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class UserFollowerRepository : IUserFollowerRepository
    {
        private readonly SqlContext sqlContext;

        public UserFollowerRepository()
        {
            sqlContext = new SqlContext();
        }

        public bool AddFollower(UserFollower userFollower)
        {
            if (userFollower == null || userFollower.UserId == userFollower.FollowerId) return false;
            if (HasRelation(userFollower.UserId, userFollower.FollowerId)) return false;
            sqlContext.UserFollowers.Add(userFollower);
            sqlContext.SaveChanges();
            return true;
        }

        public List<User> GetFollowersByUserId(int id)
        {
            //List<User> followers = new List<User>();

            var userFollower = sqlContext.UserFollowers
                .Where(uf => uf.UserId == id)
                .Select(uf => uf.Follower);

            return userFollower.ToList();
        }

        public bool HasRelation(int userId, int followerId)
        {
            return sqlContext.UserFollowers
                .Any(uf => uf.UserId == userId && uf.FollowerId == followerId);
        }
    }
}
