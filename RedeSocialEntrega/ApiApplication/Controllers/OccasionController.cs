using Domain.DTO;
using Domain;
using Infra.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccasionController : ControllerBase
    {
        private readonly IOccasionRepository _context;

        public OccasionController(IOccasionRepository context)
        {
            _context = context;
        }
        // GET: api/Occasions
        [HttpGet]
        public ActionResult<List<Occasion>> GetOccasion()
        {
            return _context.GetAll();
        }

        // GET: api/Occasions/5
        [HttpGet("{id}")]
        public ActionResult<Occasion> GetOccasion(int id)
        {
            var occasion = _context.GetOccasionById(id);

            if (occasion == null)
            {
                return NotFound();
            }

            return occasion;
        }

        // PUT: api/Occasions
        [HttpPut]
        public IActionResult PutOccasion(int id, Occasion occasion)
        {

            _context.UpdateOccasion(id, occasion);

            return Ok(new { message = "Occasion/Event updated with successufy!" });
        }

        // POST: api/Occasions
        [HttpPost]
        public ActionResult<User> PostOccasion(Occasion occasion)
        {
            _context.AddOccasion(occasion);
            return CreatedAtAction("GetOccasion", new { id = occasion.Id }, occasion);
        }

        // DELETE: api/Occasions/5
        [HttpDelete("{id}")]
        public IActionResult DeleteOccasion(int id)
        {
            if (_context.DeleteOccasion(id))
                return Ok("Occasion/Event deleted successfully!");

            return NotFound("Id not found!");
        }
    }
}
