using Domain.DTO;
using Domain;
using Infra.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserFollowerController : ControllerBase
    {
        private readonly IUserFollowerRepository _context;
        private readonly IUserRepository _contextUser;

        public UserFollowerController(IUserFollowerRepository context, IUserRepository contextUser)
        {
            _context = context;
            _contextUser = contextUser;
        }
        // POST: api/UserFollowers
        [HttpPost]
        public IActionResult PostFollower(UserFollowerDTO userFollowerDTO)
        {

            var userFollower = new UserFollower
            {
                UserId = userFollowerDTO.UserId,
                FollowerId = userFollowerDTO.FollowerId,
            };


            var following = _context.AddFollower(userFollower);


            if(!following)
            {
                return Conflict(new { message = "This User is already following!" });
            }

            return Ok(new { message = "User following with successufy!" });
        }

        // GET: api/UserFollowers
        [HttpGet("{id}")]
        public ActionResult<List<User>> GetFollowersByUserId(int id)
        {
            return _context.GetFollowersByUserId(id);
        }
    }
}
