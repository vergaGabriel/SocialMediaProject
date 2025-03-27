using Domain;
using Infra.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostageController : ControllerBase
    {
        private readonly IPostageRepository _context;

        public PostageController(IPostageRepository context)
        {
            _context = context;
        }

        // GET: api/Postages
        [HttpGet]
        public ActionResult<List<Postage>> GetPostage()
        {
            return _context.GetAll();
        }

        // GET: api/Postages/5
        [HttpGet("{id}")]
        public ActionResult<Postage> GetPostage(int id)
        {
            var postage = _context.GetPostageById(id);

            if (postage == null)
            {
                return NotFound();
            }

            return postage;
        }

        // PUT: api/Postages
        [HttpPut]
        public IActionResult PutPostage(int id, Postage postage)
        {

            _context.UpdatePostage(id, postage);

            return Ok(new { message = "Postage updated with successufy!" });
        }

        // POST: api/Postages
        [HttpPost]
        public ActionResult<Postage> PostPostage(Postage postage)
        {
            _context.AddPostage(postage);
            return CreatedAtAction("GetPostage", new { id = postage.Id }, postage);
        }

        // DELETE: api/Postages/5
        [HttpDelete("{id}")]
        public IActionResult DeletePostage(int id)
        {
            if (_context.DeletePostage(id))
                return Ok("Postage deleted successfully!");

            return NotFound("Id not found!");
        }
    }
}
