using Microsoft.AspNetCore.Mvc;
using Infra.Repositories;
using Domain;
using Infra.Interfaces;
using Domain.DTO;

namespace ApiApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _context;

        public UserController(IUserRepository context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public ActionResult<List<User>> GetUsers()
        {
            return _context.GetAll();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _context.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users
        [HttpPut]
        public IActionResult PutUser(int id, UserDTO userDto)
        {
            var user = new User
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Course = userDto.Course,
                Followers = new List<UserFollower>()
            };

            _context.UpdateUser(id, user);

            return Ok(new { message = "User updated with successufy!" });
        }

        // POST: api/Users
        [HttpPost]
        public ActionResult<User> PostUser(UserDTO userDto)
        {
            var user = new User
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Course = userDto.Course,
                Followers = new List<UserFollower>()
            };

            _context.AddUser(user);
            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            if (_context.DeleteUser(id))
                return Ok("user deleted successfully!");

            return NotFound("Id not found!");
        }

    }
}
