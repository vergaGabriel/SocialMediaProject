using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interfaces
{
    public interface IUserFollowerRepository
    {
        bool AddFollower(UserFollower userFollower);
        List<User> GetFollowersByUserId(int id);
        bool HasRelation(int userId, int followerId);
    }
}
