using Microsoft.AspNetCore.Mvc;
using UnitTestControllerDemo.Data;
using UnitTestControllerDemo.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UnitTestControllerDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repo;
        public UsersController(IUserRepository repo)
        {
            this._repo = repo;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IActionResult Get()
        {
            var users=_repo.GetAllUsers();

            if (users == null) return NoContent();

            return Ok(users);            
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _repo.GetUserById(id);
            if (user == null) return NotFound();

            return Ok(user);
        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult Post([FromBody] User user)
        {
            if(String.IsNullOrEmpty(user.Name)) return BadRequest(ModelState);

            var createdUser = _repo.AddUser(user);

            return Ok(createdUser);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] User user)
        {
            if (!ModelState.IsValid) return BadRequest();
            
            var u = _repo.UpdateUser(user);
            
            if (u == null) return NotFound();

            return Ok(u);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user=_repo.DeleteUser(id);

            if(user== null) return NotFound();

            return Ok(user);
        }
    }
}
